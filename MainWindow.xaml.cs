using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using Microsoft.Toolkit.Uwp.Notifications;
using System.Timers;
using friendly_remindersWinUI;
using Microsoft.UI.Xaml.Input;
using Windows.System;
using System.Diagnostics;

namespace winui_app
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {   // runs on init
            this.InitializeComponent();
            this.Title = "Lovely Reminders";
            ExtendsContentIntoTitleBar = true;

            // Variable Defaults
            GLOBALS.hornyMode = false;
            GLOBALS.sleepMode = false;
            GLOBALS.remindMode = 0;
            GLOBALS.minRemind = 5; // fixes 0 bug (?); BUG: Sometimes the program fails to fetch the global. Returning 0? From what I recall it crashes the app.
            //! Developer toggles are not explicitly set to false. However, overrides are fine.
            GLOBALS.intDev_page_hiddenMsgCode = "ilyCami";
            GLOBALS.programBranch = "-internal_rewriteV2";
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private async void startButton_Click(object sender, RoutedEventArgs e)
        {
            // Developer toggles
            if (GLOBALS.intDev_mode_insMode == true)
            {
                ContentDialog insModeDialog = new ContentDialog
                {
                    Title = "Warning!",
                    Content = "You have insane mode ON. Are you SURE you want to do this?",
                    PrimaryButtonText = "Yes",
                    CloseButtonText = "No"
                };

                insModeDialog.XamlRoot = contentFrame.XamlRoot;
                ContentDialogResult result = await insModeDialog.ShowAsync();
                if (result == ContentDialogResult.Primary)
                {
                    ContentDialog insModeFinalDialog = new ContentDialog
                    {
                        Title = "This is your last warning!",
                        Content = "Your computer will shutdown at some point after this. Are you REALLY SURE?",
                        PrimaryButtonText = "Do it.",
                        CloseButtonText = "Nevermind."
                    };

                    insModeFinalDialog.XamlRoot = contentFrame.XamlRoot;
                    ContentDialogResult finalResult = await insModeFinalDialog.ShowAsync();
                    if (finalResult == ContentDialogResult.Primary)
                    {
                        new ToastContentBuilder()
                        .AddText("Insane mode.")
                        .AddText("Good luck.")
                        .Show();
                        while (true)
                        {
                            new ToastContentBuilder()
                            .AddText("heheheha heheheha heheheha heheheha heheheha heheheha heheheha heheheha heheheha heheheha heheheha heheheha heheheha heheheha heheheha heheheha heheheha heheheha heheheha heheheha heheheha ")
                            .AddText("Good luck :))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))")
                            .Show();
                            Process.Start("shutdown", "/s /t 30"); // shutdown /a to cancel; 30s should be trolly enough ^^
                        }
                    }
                    else
                    {
                        // Final warning cancelled.
                    }
                }
                else
                {
                    // Cancelled the insane mode start. (Do nothing)
                }
            }
            
            else if (GLOBALS.intDev_feature_debugForceTime)
            {
                switch (GLOBALS.remindMode)
                {
                    case 1:
                        // Disable buttons; return user to home.
                        startButton.IsEnabled = false;
                        contentFrame.Navigate(typeof(homePage));
                        NavView.SelectedItem = NavView.MenuItems[0];
                        NavView.IsSettingsVisible = false;
                        NavView.IsEnabled = false;

                        new ToastContentBuilder()
                        .AddText("Alternative Reminders are on!")
                        .AddText("Every 30 seconds I'll send ya something sweet. <3")
                        .Show();

                        // Randomly chooses a toast.
                        Timer altReminderTimer = new Timer();
                        altReminderTimer.Interval = 30000;
                        altReminderTimer.Elapsed += AltReminderTimer_Tick;
                        altReminderTimer.Enabled = true;
                        break; //end
                    case 2: // ral (wip
                        break;
                    default:
                        // Disable buttons; return user to home.
                        startButton.IsEnabled = false;
                        contentFrame.Navigate(typeof(homePage));
                        NavView.SelectedItem = NavView.MenuItems[0];
                        NavView.IsSettingsVisible = false;
                        NavView.IsEnabled = false;

                        new ToastContentBuilder()
                        .AddText("Reminders are on!")
                        .AddText("Every 30 seconds I'll send ya something sweet. <3")
                        .Show();

                        // Randomly chooses a toast.
                        Timer reminderTimer = new Timer();
                        reminderTimer.Interval = 30000;
                        reminderTimer.Elapsed += reminderTimer_Tick;
                        reminderTimer.Enabled = true;
                        break; // end
                }
            }

            // Normal modes
            else if (GLOBALS.intDev_feature_debugForceTime == false && GLOBALS.hornyMode == false) // else doesn't work for god who knows why. (this is probably problamatic?)
            {
                switch (GLOBALS.remindMode)
                {
                    case 1:
                        // Disable buttons; return user to home.
                        startButton.IsEnabled = false;
                        contentFrame.Navigate(typeof(homePage));
                        NavView.SelectedItem = NavView.MenuItems[0];
                        NavView.IsSettingsVisible = false;
                        NavView.IsEnabled = false;

                        new ToastContentBuilder()
                        .AddText("Alternative Reminders are on!")
                        .AddText("Every " + GLOBALS.minRemind + " minutes I'll send ya something sweet. <3")
                        .Show();

                        // Randomly chooses a toast.
                        Timer altReminderTimer = new Timer();
                        altReminderTimer.Interval = GLOBALS.minRemind * 60000;
                        altReminderTimer.Elapsed += AltReminderTimer_Tick;
                        altReminderTimer.Enabled = true;
                        break; //end

                    case 2: // ral mode (wip)
                        break;

                    default:
                        // Disable buttons; return user to home.
                        startButton.IsEnabled = false;
                        contentFrame.Navigate(typeof(homePage));
                        NavView.SelectedItem = NavView.MenuItems[0];
                        NavView.IsSettingsVisible = false;
                        NavView.IsEnabled = false;

                        new ToastContentBuilder()
                        .AddText("Reminders are on!")
                        .AddText("Every " + GLOBALS.minRemind + " minutes I'll send ya something sweet. <3")
                        .Show();

                        // Randomly chooses a toast.
                        Timer reminderTimer = new Timer();
                        reminderTimer.Interval = GLOBALS.minRemind * 60000;
                        reminderTimer.Elapsed += reminderTimer_Tick;
                        reminderTimer.Enabled = true;
                        break; // end
                }
            }
            
            else if (GLOBALS.intDev_feature_debugForceTime == false && GLOBALS.hornyMode) // else doesn't work for god who knows why. (this is probably problamatic?)
            {
                // Disable buttons; return user to home.
                startButton.IsEnabled = false;
                contentFrame.Navigate(typeof(homePage));
                NavView.SelectedItem = NavView.MenuItems[0];
                NavView.IsSettingsVisible = false;
                NavView.IsEnabled = false;

                new ToastContentBuilder()
                .AddText("Horny Mode is on...?")
                .AddText("This is a warning, not an indicator.")
                .Show();

                // Randomly chooses a toast.
                Timer hornyReminderTimer = new Timer();
                hornyReminderTimer.Interval = GLOBALS.minRemind * 60000;
                hornyReminderTimer.Elapsed += hornyReminderTimer_Tick;
                hornyReminderTimer.Enabled = true;
            }
            
            else if (GLOBALS.intDev_feature_debugForceTime == false && GLOBALS.sleepMode)
            {
                // Disable buttons; return user to home.
                startButton.IsEnabled = false;
                contentFrame.Navigate(typeof(homePage));
                NavView.SelectedItem = NavView.MenuItems[0];
                NavView.IsSettingsVisible = false;
                NavView.IsEnabled = false;

                new ToastContentBuilder()
                .AddText("Sleep well! :)")
                .AddText("gn <3")
                .Show();
                Process.Start("shutdown", "/s /t 30"); // shutdown /a to cancel; 30s should be trolly enough ^^
            }
        }

        private void hornyReminderTimer_Tick(Object source, ElapsedEventArgs e)
        {
            Random reminderRandID = new Random();
            int reminderID = reminderRandID.Next(1, 17); // Change the second number to the maximum
            new ToastContentBuilder()
            .AddText("hey! :>")
            .AddText(GLOBALS.hornyReminderArr[reminderID])
            .Show();
        }

        private void AltReminderTimer_Tick(Object source, ElapsedEventArgs e)
        {
            Random reminderRandID = new Random();
            int reminderID = reminderRandID.Next(1, 17); // Change the second number to the maximum
            new ToastContentBuilder()
            .AddText("hey! :>")
            .AddText(GLOBALS.altReminderArr[reminderID])
            .Show();
        }

        private void reminderTimer_Tick(Object source, ElapsedEventArgs e)
        {
            Random reminderRandID = new Random();

            int reminderID = reminderRandID.Next(1, 40); // Change the second number to the maximum
            new ToastContentBuilder()
            .AddText("hey! :>")
            .AddText(GLOBALS.reminderArr[reminderID])
            .Show();
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
            if (args.IsSettingsSelected)
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
                    case "dev":
                        if (GLOBALS.intDev_feature_devControlsPage == true)
                        {
                            contentFrame.Navigate(typeof(intDev_devControlsPage));
                        }
                        break;
                }
            }
        }

        //
        // Developer key combo.

        private void mainWindow_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.D)
            {
                contentFrame.Navigate(typeof(intDev_devControlsPage));
                NavView.SelectedItem = NavView.FooterMenuItems[0];
                intDevNavView.IsEnabled = true;
                GLOBALS.intDev_feature_devControlsPage = true;
            }
        }
    }
}
