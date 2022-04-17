using Microsoft.UI.Xaml.Controls;

namespace friendly_remindersWinUI
{
    public sealed partial class homePage : Page
    {
        public homePage()
        {
            this.InitializeComponent();
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            versionExpander.Header = "Version " + version; // -> "1.1.2.10"
        }
    }
}
