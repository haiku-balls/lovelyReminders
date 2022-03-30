using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using System.IO;
using System.Media;
using Microsoft.UI;

namespace friendly_remindersWinUI
{
    public sealed partial class intDev_devControlsPage : Page
    {
        public intDev_devControlsPage()
        {
            this.InitializeComponent();
            // Pre-check
            if (GLOBALS.intDev_mode_insMode == true)
            {
                insModeToggle.IsOn = true;
                insModeToggleText.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                GLOBALS.intDev_mode_insMode = false;
            }
        }

        private void insModeToggle_Toggled(object sender, RoutedEventArgs e)
        {
            // // !TODO: Do something really funny here. Was thinking maybe doom music...? :) //! Maybe like a sound? Or something? Or maybe not. Whatever.
            // get the directory of this program.
            string dir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            SoundPlayer player = new SoundPlayer(dir + "\\" + "Assets\\BGM\\itsTime.wav");
            if (insModeToggle.IsOn && GLOBALS.intDev_mode_insMode == true)
            {
                // do nothing.
            }
            else if (insModeToggle.IsOn)
            {
                GLOBALS.intDev_mode_insMode = true;
                player.Play();
                insModeToggleText.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                GLOBALS.intDev_mode_insMode = false;
                player.Stop();
                insModeToggleText.Foreground = new SolidColorBrush(Colors.White);
            }
        }

        private void intDev_element_forceTimeSwitch_Togged(object sender, RoutedEventArgs e)
        {
            if (intDev_element_forceTimeSwitch.IsOn)
            {
                GLOBALS.intDev_feature_debugForceTime = true;
            }
            else
            {
                GLOBALS.intDev_feature_debugForceTime = false;
            }
        }

        // Hidden page. When you enter the global secret it'll navigate you to it. You have to start the program after entering it. :)
        private void intDev_element_pageChanged(object sender, RoutedEventArgs e)
        {
            if (intDev_element_hiddenPageTextBox.Text == GLOBALS.intDev_page_hiddenMsgCode)
            {
                GLOBALS.intDev_feature_hiddenMsgPage = true;
                intDev_element_hiddenPageTextBox.IsEnabled = false;
                intDev_element_hiddenPageTextBox.Text = "";
            }
        }
    }
}
