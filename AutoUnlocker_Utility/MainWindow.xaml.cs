using System.Windows;

namespace AutoUnlocker_Utility
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly GlobalKeyboardHook hook;
        public MainWindow()
        {
            hook = new GlobalKeyboardHook();
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hook.HookedKeys.Add(System.Windows.Forms.Keys.F9);
            hook.KeyUp += Hook_KeyUp; ;
        }

        private void Hook_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            Core.IAutoUnlocker autoUnlocker = new Core.AutoUnlockerDayZ();
            autoUnlocker.Start();
        }
    }
}