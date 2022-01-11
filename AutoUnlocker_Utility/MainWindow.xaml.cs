using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace AutoUnlocker_Utility
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly GlobalKeyboardHook hook;
        readonly GlobalKeyboardHook hook2;
        public MainWindow()
        {
            hook = new GlobalKeyboardHook();
            hook2 = new GlobalKeyboardHook();
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hook.HookedKeys.Add(Keys.F9);
            hook.KeyUp += Hook_KeyUp;
            hook2.HookedKeys.Add(Keys.F10);
            hook2.KeyUp += Hook_Break;
        }

        private void Hook_Break(object sender, KeyEventArgs e) => Close();

        private void Hook_KeyUp(object sender, KeyEventArgs e) => new Task(new Core.AutoUnlockerDayZ().Start).Start();
    }
}