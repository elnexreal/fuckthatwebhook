using System.Windows;
using System.Diagnostics;

namespace fuckthatwebhook
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private WebhookFuncs webhookFuncs;
		public MainWindow()
		{
			webhookFuncs = new WebhookFuncs();
			InitializeComponent();
		}

		private void GitHubBtn(object sender, RoutedEventArgs e)
		{
			string url = "https://github.com/elnexreal/fuckthatwebhook";
			Process.Start(new ProcessStartInfo(url)
			{
				UseShellExecute = true
			});
		}

		private void StopSpam(object sender, RoutedEventArgs e)
		{
			webhookFuncs.StopSpam();
		}

		private void StartSpam(object sender, RoutedEventArgs e)
		{
			webhookFuncs.SpamHook(spamTextBox.Text, urlTextBox.Text);
		}

		private void SendMessage(object sender, RoutedEventArgs e)
		{
			webhookFuncs.SendMsg(msgTextBox.Text, urlTextBox.Text);
		}
	}
}