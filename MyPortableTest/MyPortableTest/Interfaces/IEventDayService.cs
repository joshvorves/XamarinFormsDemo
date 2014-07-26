using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EventDay.Api.Client;

namespace MyPortableTest.Interfaces
{
    public interface IEventDayService
    {
        Task<IEnumerable<SessionState>> GetSessions();
        Task<EventState> GetEntireEvent();
        Task<string> GenerateAuthCode(string emailAddress);
        Task<TicketState> ValidateAuthCode(string code);
        Task<SessionState[]> FavoriteSession(Guid sessionId, Guid ticketId);
        Task<SessionState[]> RemoveFavoriteSession(Guid sessionId, Guid ticketId);
    }
}
