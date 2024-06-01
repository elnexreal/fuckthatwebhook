using System.Windows;
using System.Net.Http;

namespace fuckthatwebhook
{
	internal class WebhookFuncs
	{
		private readonly HttpClient _httpClient;
		public bool isRunning;

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

			if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
			{
				MessageBox.Show("BAD REQUEST (text must contain at least one letter, not only whitespace)");
			}

			return response;
		}

		public async void StartSpammer(string text, string url)
		{
			isRunning = true;

			while (isRunning)
			{
				try
				{
					await SendRequest(text, url);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					break;
				}
			}
		}
		public void StopSpammer()
		{
			isRunning = false;
		}

		public async void SendMsg(string text, string url)
		{
			try
			{
				await SendRequest(text, url);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
