using System.Windows;
using System.Net.Http;

namespace fuckthatwebhook
{
	internal class WebhookFuncs
	{
		private readonly HttpClient _httpClient;
		private bool isRunning;

		public WebhookFuncs()
		{
			isRunning = false;
			_httpClient = new HttpClient();
		}

		private async Task<HttpResponseMessage> SendRequest(string text, string url)
		{
			var values = new Dictionary<string, string>
			{
				{ "content", text }
			};

			var body = new FormUrlEncodedContent(values);

			var request = new HttpRequestMessage(HttpMethod.Post, url);
			request.Content = body;
			var response = await _httpClient.SendAsync(request);

			return response;
		}

		public async void SpamHook(string text, string url)
		{
			isRunning = true;

			while (isRunning)
			{
				try
				{
					var req = await SendRequest(text, url);

					if (req.StatusCode == System.Net.HttpStatusCode.BadRequest)
					{
						MessageBox.Show("BAD REQUEST (text must contain at least one letter, not only whitespace)");
						break;
					}
				}
				catch (Exception ex) 
				{
					MessageBox.Show(ex.Message);
					break;
				}
			}
		}
		public void StopSpam()
		{
			isRunning = false;
		}

		public async void SendMsg(string text, string url)
		{
			try
			{
				var req = await SendRequest(text, url);

				if (req.StatusCode == System.Net.HttpStatusCode.BadRequest)
				{
					MessageBox.Show("BAD REQUEST (text must contain at least one letter, not only whitespace)");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
