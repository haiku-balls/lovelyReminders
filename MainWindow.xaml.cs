using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using Microsoft.Toolkit.Uwp.Notifications;
using System.Threading.Tasks;
using System.Timers;

namespace winui_app
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {   // runs on init
            this.InitializeComponent();
            ExtendsContentIntoTitleBar = true;
            // SetTitleBar(AppTitleBar);
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            versionExpander.Header = "Version " + version + "-beta"; // -> "1.1.2.10"
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {

            startButton.IsEnabled = false;
            // VERY EXPERIMENTAL LOOOOOOOOOOOOOOOOOL :3
            new ToastContentBuilder()
            .AddText("Reminders are on!")
            .AddText("Every 5 minutes I'll send ya something sweet. <3")
            .Show();

            // Very scuffed array system. Randomly chooses a toast.
            Timer reminderTimer = new Timer();
            reminderTimer.Interval = 300000; // 5 minute-interval
            reminderTimer.Elapsed += reminderTimer_Tick;
            reminderTimer.Enabled = true;
        }

        private static void reminderTimer_Tick(Object source, ElapsedEventArgs e)
        {
            string[] reminderArr;
            Random reminderRandID = new Random();

            reminderArr = new string[5] { 
                "boop lovely <3", 
                "ilysm bby <3333", 
                "You're so cute. <3",
                "*mwah* kisses for bby <3",
                "imma smother you in huggies ^^"
            }; // change [#] to number of quotes.

            int reminderID = reminderRandID.Next(0, 3);
            new ToastContentBuilder()
            .AddText("Reminder.")
            .AddText(reminderArr[reminderID])
            .Show();
        }

        private async void aboutButton_Click(object sender, RoutedEventArgs e)
        {
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            ContentDialog aboutDialog = new ContentDialog
            {
                Title = "About",
                Content = "Baka's Friendly Reminders\nA program to remind you of how much ily.\nVersion: " + version + "-beta",
                PrimaryButtonText = "OK"
            };

            aboutDialog.XamlRoot = this.Content.XamlRoot;
            ContentDialogResult result = await aboutDialog.ShowAsync();
        }
    }
}
