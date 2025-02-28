using System.Windows;
using System.Windows.Controls;

namespace MasterMind
{
    public partial class Difficolta : Window
    {
        public int CheckBoxCounter { get; private set; } = 0;

        public Difficolta()
        {
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBoxCounter++;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBoxCounter--;
        }
    }
}
