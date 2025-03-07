using System.Windows;
using System.Windows.Controls;

namespace MasterMind
{
    public partial class DifficoltaWpf : Window
    {
        public int CheckBoxCounter { get; private set; } = 0;
        public MainWindow PrincipalMain { get; private set; }
        public DifficoltaWpf(MainWindow main)
        {
            InitializeComponent();
            PrincipalMain = main;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBoxCounter++;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBoxCounter--;
        }

        private void btn_backMain_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            PrincipalMain.Show();
        }
    }
}
