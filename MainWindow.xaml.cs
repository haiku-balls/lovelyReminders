using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using Microsoft.Toolkit.Uwp.Notifications;
using System.Timers;
using friendly_remindersWinUI;

namespace winui_app
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {   // runs on init
            this.InitializeComponent();
            this.Title = "Lovely Reminders";
            ExtendsContentIntoTitleBar = true;
            // SetTitleBar(AppTitleBar);
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private static void altReminderTimer_Tick(Object source, ElapsedEventArgs e)
        {
            string[] reminderArr;
            Random reminderRandID = new Random();

            reminderArr = new string[17] { // change [#] to number of quotes.
                "i hope bby is alright <3", // 1
                "mmwah <333333", // 2
                "so much mwah mwahs for my baby <333", // 3
                "mwah ily <3", // 4
                "weewoo", // 5
                "ur such a good boy <3", // 6
                "ur my good boy hehe <3", // 7
                "lovely cutie <33", // 8
                "i love you my good boy <3", // 9
                "ilysm baby <3", // 10
                "i love youuuuu <33333", // 11
                "bby cocker", // 12
                "bby boner :o", // 13
                "lovely so cute howwwwww >:(", // 14
                "i love you lovely <3", // 15
                "ilysm lovely <3", // 16
                "i love you so much my bby <3" // 17
            };

            int reminderID = reminderRandID.Next(1, 17); // Change the second number to the maximum
            new ToastContentBuilder()
            .AddText("hey! :>")
            .AddText(reminderArr[reminderID])
            .Show();
        }

        //
        //
        // Normal Starting (for cami :3)
        private void startButton_Click(object sender, RoutedEventArgs e)
        {

            // Disable buttons; return user to home.
            startButton.IsEnabled = false;
            contentFrame.Navigate(typeof(homePage));
            NavView.SelectedItem = NavView.MenuItems[0];
            NavView.IsSettingsVisible = false;
            NavView.IsEnabled = false;


            if (GLOBALS.altMode == true)
            {
                // VERY EXPERIMENTAL LOOOOOOOOOOOOOOOOOL :3
                new ToastContentBuilder()
                .AddText("Alternative Reminders are on!")
                .AddText("Every " + GLOBALS.minRemind + " minutes I'll send ya something sweet. <3")
                .Show();

                // Very scuffed array system. Randomly chooses a toast.
                Timer reminderTimer = new Timer();
                reminderTimer.Interval = GLOBALS.minRemind * 60000;
                reminderTimer.Elapsed += reminderTimer_Tick;
                reminderTimer.Enabled = true;
            }
            if (GLOBALS.altMode == false)
            {
                // VERY EXPERIMENTAL LOOOOOOOOOOOOOOOOOL :3
                new ToastContentBuilder()
                .AddText("Reminders are on!")
                .AddText("Every " + GLOBALS.minRemind + " minutes I'll send ya something sweet. <3")
                .Show();

                // Very scuffed array system. Randomly chooses a toast.
                Timer reminderTimer = new Timer();
                reminderTimer.Interval = GLOBALS.minRemind * 60000;
                reminderTimer.Elapsed += reminderTimer_Tick;
                reminderTimer.Enabled = true;
            }
        }

        private void reminderTimer_Tick(Object source, ElapsedEventArgs e)
        {
            string[] altReminderArr;
            string[] reminderArr;

            altReminderArr = new string[17] { // change [#] to number of quotes.
                "i hope bby is alright <3", // 1
                "mmwah <333333", // 2
                "so much mwah mwahs for my baby <333", // 3
                "mwah ily <3", // 4
                "weewoo", // 5
                "ur such a good boy <3", // 6
                "ur my good boy hehe <3", // 7
                "lovely cutie <33", // 8
                "i love you my good boy <3", // 9
                "ilysm baby <3", // 10
                "i love youuuuu <33333", // 11
                "bby cocker", // 12
                "bby boner :o", // 13
                "lovely so cute howwwwww >:(", // 14
                "i love you lovely <3", // 15
                "ilysm lovely <3", // 16
                "i love you so much my bby <3" // 17
            };

            Random reminderRandID = new Random();

            reminderArr = new string[40] { // change [#] to number of quotes.
                "boop lovely <3", // 1
                "ilysm bby <3333", // 2
                "You're so cute. <3", // 3
                "*mwah* kisses for bby <3", // 4
                "imma smother you in huggies ^^", // 5
                "i love you bby <3", // 6
                "cmere bby, mwah! <3", // 7
                "awe look at my adorable baby hehe <3", // 8
                "camiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii", // 9
                "cute people use my program, that's you :)", // 10
                "i'll always be there for you my lovely <3", // 11
                "fumofumo hehe :>", // 12
                "my baby so cute omg :o", // 13
                "you're such a good girl awe <3", // 14
                "i love you so much cutie <3", // 15
                "you're so adorable aweeeee <3", // 16
                "Is it seokjin saturday yet?", // 17
                "my bby will always be special to me ^^", // 18
                "Maybe bby needs some huggies :)", // 19
                "weewoo my baby cute :o", // 20
                // "gn bby <3" (Possible timed ?)
                "ily cutie <3", // 21
                "i love you cutie <3", // 22
                "i love you so much my baby <3", // 23
                "i love you my good girl <3", // 24
                "bby cocker mmmmm :horny:", // 25
                "Friendly reminder to suck my cocker pls. thx <3", // 26
                "'bby boner' shut.", // 27
                "All I think about is your adorable face, I never think of anything else hehe. <3", // 28
                "boop ^^", // 29
                "ahehehe cutie <3", // 30
                "should see this source code jeez haha :o", // 31
                "so many quotes for my baby :o", // 32
                "I would die for you my lovely baby <333", // 33
                "I always imagine you right beside me ^^", // 34
                "Reminder to kiss me irl. thx <3", // 35
                "huggies from mommy? :o", // 36
                "ur so fkin sexc omg :horny:", // 37
                "Can we perhaps makeout lovely? :o", // 38
                "weewoo", // 39
                "How bby so cute? Howwwww >:(" // 40
            };


            if (GLOBALS.altMode == true)
            {
                int reminderID = reminderRandID.Next(1, 17); // Change the second number to the maximum
                new ToastContentBuilder()
                .AddText("hey! :>")
                .AddText(altReminderArr[reminderID])
                .Show();
            }
            if (GLOBALS.altMode == false)
            {
                int reminderID = reminderRandID.Next(1, 40); // Change the second number to the maximum
                new ToastContentBuilder()
                .AddText("hey! :>")
                .AddText(reminderArr[reminderID])
                .Show();
            }
        }
        

        /*

        private async void aboutButton_Click(object sender, RoutedEventArgs e)
        {
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            ContentDialog aboutDialog = new ContentDialog
            {
                Title = "About",
                Content = "Baka's Friendly Reminders\nA program to remind you of how much ily.\nVersion: " + version + "-alpha",
                PrimaryButtonText = "OK"
            };

            aboutDialog.XamlRoot = this.Content.XamlRoot;
            ContentDialogResult result = await aboutDialog.ShowAsync();
        }

        */

        private void NavigationView_Loaded(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(homePage));
            NavView.SelectedItem = NavView.MenuItems[0];
        }
        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if(args.IsSettingsSelected)
            {
                // Settings page.
                contentFrame.Navigate(typeof(settingsPage));
            }
            else
            {
                // Everything else.
                NavigationViewItem item = args.SelectedItem as NavigationViewItem;

                switch (item.Tag.ToString())
                {
                    case "home":
                        contentFrame.Navigate(typeof(homePage));
                        break;
                }
            }
        }
    }
}
