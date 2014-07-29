using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

#if __IOS__
using MonoTouch.Foundation;
#endif

namespace EventDay.Shared.Data
{
	class Gravatar
	{
		public enum Rating { G, PG, R, X }

		const string _url = "http://www.gravatar.com/avatar.php?gravatar_id=";

		public static string GetURL (string email, int size, Rating rating = Rating.PG)
		{
			var hash = MD5Hash (email.ToLower ());

			if (size < 1 | size > 600) {
				throw new ArgumentOutOfRangeException("size", "The image size should be between 20 and 80");
			}

			return _url + hash + "&s=" + size.ToString () + "&r=" + rating.ToString ().ToLower ();
		}

#if !WINDOWS_PHONE
		public static async Task<byte[]> GetImageBytes (string email, int size, Rating rating = Rating.PG)
		{
			var url = GetURL (email, size, rating);
			var client = new WebClient ();
			return await client.DownloadDataTaskAsync (url);
		}
#endif

#if __IOS__
		public static async Task<NSData> GetImageData (string email, int size, Rating rating = Rating.PG)
		{
			byte[] data = await GetImageBytes (email, size, rating);
			return NSData.FromStream (new System.IO.MemoryStream (data));
		}
#endif

		static string MD5Hash (string input)
		{
      var builder = new StringBuilder ();
#if WINDOWS_PHONE
      var bytes = Encoding.UTF8.GetBytes(input);
      var data = MD5Core.GetHash(bytes);
#else
      var hasher = MD5.Create ();
			var data = hasher.ComputeHash (Encoding.Default.GetBytes (input));
#endif
			foreach (byte datum in data)
				builder.Append (datum.ToString ("x2"));

			return builder.ToString ();
		}
	}
}

