using System.Windows;
using System.Diagnostics;
using System.Windows.Controls;

namespace fuckthatwebhook
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private WebhookFuncs WebhookFuncs;
		public MainWindow()
		{
			WebhookFuncs = new WebhookFuncs();
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

		private void BtnHandler(object sender, RoutedEventArgs e)
		{
			Button button = (Button)sender;

			if (UrlTextBox.Text.Length == 0) {
				MessageBox.Show("URL field must not be empty.");
				return;
			}

			switch (button.Name)
			{
				case "SpamBtn":
					if (SpamTextBox.Text.Length <= 0)
					{
						MessageBox.Show("Text field must not be empty.");
						break;
					}

					WebhookFuncs.StartSpammer(SpamTextBox.Text, UrlTextBox.Text);
					break;

				case "StopBtn":
					if (!WebhookFuncs.isRunning)
					{
						MessageBox.Show("Spammer is not running.");
						break;
					}

					WebhookFuncs.StopSpammer();
					break;

				case "SendMsgBtn":
					if (MsgTextBox.Text.Length <= 0)
					{
						MessageBox.Show("Text field must not be empty.");
						break;
					}

					WebhookFuncs.SendMsg(MsgTextBox.Text, UrlTextBox.Text);
					break;
			}
		}
	}
}