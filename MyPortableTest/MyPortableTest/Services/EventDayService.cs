using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using EventDay.Api.Client;
using EventDay.Api.Client.Configuration;
using MyPortableTest.Interfaces;
using EventDayApiConfiguration = EventDay.Api.Client.EventDayApiConfiguration;

namespace MyPortableTest.Services
{
    public class EventDayService : IEventDayService
    {
        private readonly IScopedApiClient _apiClient;

        public EventDayService(ILogger logger)
        {

            var configuration = new EventDayApiConfiguration
            {
                VerifyValidSsl = true,
                Endpoint = new Uri("https://api.eventday.com"),
                MaximumOperationRetries = 5,
                MediaType = "Json",
                EventConfiguration = new EventConfiguration
                {
                    ApiKey = "8186a825fcce486b985231805a05d7f5e3832aa1b8e4d01059f3cd52385bbbf6",
                    EventId = Guid.Parse("f59522431ff74d72ac2d6871fc820d1d")
                }
            };
            _apiClient = new JsonEventDayApiClient(configuration, new TrafficObserver(logger));
        }

        public Task<IEnumerable<SessionState>> GetSessions()
        {
            return _apiClient.GetSessionsAsync();
        }

        public Task<EventState> GetEntireEvent()
        {
            return _apiClient.GetEventAsync(
                expander =>
                {
                    expander.Add(e => e.Sessions);
                    expander.Add(e => e.Speakers);
                    expander.Add(e => e.Sponsors);
                    expander.Add(e => e.Evaluations);
                    //expander.Add(e => e.Rooms);
                }
                );
        }

        public Task<string> GenerateAuthCode(string emailAddress)
        {
            return _apiClient.GetInboxAuthenticationPasscode(emailAddress);
        }

        public Task<TicketState> ValidateAuthCode(string code)
        {
            return _apiClient.ExchangeInboxAuthenticationPasscode(code);
        }

        public Task<SessionState[]> FavoriteSession(Guid sessionId, Guid ticketId)
        {
            return _apiClient.AddSessionToTicketScheduleAsync(sessionId, ticketId);
        }

        public Task<SessionState[]> RemoveFavoriteSession(Guid sessionId, Guid ticketId)
        {
            return _apiClient.RemoveSessionFromTicketScheduleAsync(sessionId, ticketId);
        }
    }


    internal class TrafficObserver : ITrafficObserver
    {
        private static readonly Task EmptyTask = MakeEmptyTask();
        private readonly ILogger _logger;

        public TrafficObserver(ILogger logger)
        {
            _logger = logger;
        }

        public Task ObserveResponse(HttpResponseMessage response)
        {
            _logger.Info(response.ToString());
            return EmptyTask;
        }

        public Task ObserveRequest(HttpRequestMessage request)
        {
            _logger.Info(request.ToString());
            return EmptyTask;
        }

        public Task ObserveError(EventDayException exception)
        {
            _logger.Error(exception.ToString());
            return EmptyTask;
        }

        private static Task MakeEmptyTask()
        {
            var tcs = new TaskCompletionSource<object>();
            tcs.SetResult(null);
            return tcs.Task;
        }
    }

    public interface ILogger
    {
        void Info(string message);
        void Error(string message);
    }

    public class NullLogger : ILogger
    {
        public void Info(string message)
        {
        }

        public void Error(string message)
        {
        }
    }
}