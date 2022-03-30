using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;

namespace friendly_remindersWinUI
{
    public sealed partial class settingsPage : Page
    {
        public settingsPage()
        {
            this.InitializeComponent();
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            versionExpander.Header = "Version " + version + GLOBALS.programBranch; // -> "1.1.2.10"
                                                                      // Major doesn't change unless rewrite or V2. Minor is the month. Build is the Day. Rev. is the revision number (auto. changes)
            modeSelect.SelectedIndex = 0; // Selects default mode.
            // Developer toggles check.
            if (GLOBALS.intDev_mode_insMode)
            {
                altSwitch.IsEnabled = false;
                hornySwitch.IsEnabled = false;
                sleepSwitch.IsEnabled = false;
                minSlider.IsEnabled = false;
                testBSwitch.IsEnabled = false;
                modeSelect.IsEnabled = false;
                settingsInfoBar.Severity = InfoBarSeverity.Error;
                settingsInfoBar.Message = "You have a developer flag enabled that isn't compatible with some of these settings. You must disable the flag to enable these settings again.";
            }
            else if (GLOBALS.intDev_feature_debugForceTime)
            {
                sleepSwitch.IsEnabled = false;
                minSlider.IsEnabled = false;
                settingsInfoBar.Severity = InfoBarSeverity.Error;
                settingsInfoBar.Message = "You have a developer flag enabled that isn't compatible with some of these settings. You must disable the flag to enable these settings again.";
            }
        }
        private void altSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch != null)
            {
                if (toggleSwitch.IsOn == true)
                {
                    hornySwitch.IsEnabled = false;
                    sleepSwitch.IsEnabled = false;
                    GLOBALS.altMode = true;
                }
                if (toggleSwitch.IsOn == false)
                {
                    hornySwitch.IsEnabled = true;
                    sleepSwitch.IsEnabled = true;
                    GLOBALS.altMode = false;
                }
            }
        }

        private void Slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            GLOBALS.minRemind = (int)e.NewValue;
        }

        private void hornySwitch_Toggled(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch != null)
            {
                if (toggleSwitch.IsOn == true)
                {
                    altSwitch.IsEnabled = false;
                    sleepSwitch.IsEnabled = false;
                    GLOBALS.hornyMode = true;
                }
                if (toggleSwitch.IsOn == false)
                {
                    altSwitch.IsEnabled = true;
                    sleepSwitch.IsEnabled = true;
                    GLOBALS.hornyMode = false;
                }
            }
        }

        private void sleepSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch != null)
            {
                if (toggleSwitch.IsOn == true)
                {
                    altSwitch.IsEnabled = false;
                    hornySwitch.IsEnabled = false;
                    GLOBALS.sleepMode = true;
                }
                if (toggleSwitch.IsOn == false)
                {
                    altSwitch.IsEnabled = true;
                    hornySwitch.IsEnabled = true;
                    GLOBALS.sleepMode = false;
                }
            }
        }

        private void modeSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Mode IDs:
            // 0: Default
            // 1: Alternative (Myself)
            // 2: ral (wip)
            if (modeSelect.SelectedIndex == 0)
            {

            }
        }
    }
}
