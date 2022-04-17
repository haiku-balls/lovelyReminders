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
            versionExpander.Header = "Version " + version; // -> "1.1.2.10"
                                                                      // Major doesn't change unless rewrite or V2. Minor is the month. Build is the Day. Rev. is the revision number (auto. changes)
            // Mode check.
            if (GLOBALS.remindMode == 0) { modeSelect.SelectedIndex = 0; }
            else if (GLOBALS.remindMode == 1) { modeSelect.SelectedIndex = 1; }
            else if (GLOBALS.remindMode == 2) { modeSelect.SelectedIndex = 2; }

            // Developer toggles check.
            if (GLOBALS.intDev_mode_insMode)
            {
                hornySwitch.IsEnabled = false;
                sleepSwitch.IsEnabled = false;
                minSlider.IsEnabled = false;
                modeSelect.IsEnabled = false;
                modeSelect.SelectedIndex = 3;
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
                    // override some things (this mode cannot be used with alternative or ral modes)
                    modeSelect.IsEnabled = false;
                    modeSelect.SelectedIndex = 0;
                    GLOBALS.remindMode = 0;
                    
                    // disable the othr stuff.
                    sleepSwitch.IsEnabled = false;
                    GLOBALS.hornyMode = true;
                }
                if (toggleSwitch.IsOn == false)
                {
                    // disable stuff.
                    modeSelect.IsEnabled = true;
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
                    hornySwitch.IsEnabled = false;
                    GLOBALS.sleepMode = true;
                }
                if (toggleSwitch.IsOn == false)
                {
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
            if (modeSelect.SelectedIndex == GLOBALS.remindMode) { } // debounce
            else if (modeSelect.SelectedIndex == 0) { GLOBALS.remindMode = 0; }
            else if (modeSelect.SelectedIndex == 1) { GLOBALS.remindMode = 1; }
            else if (modeSelect.SelectedIndex == 2) { GLOBALS.remindMode = 2; }
        }
    }
}
