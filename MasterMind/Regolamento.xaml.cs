using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MasterMind
{
    /// <summary>
    /// Logica di interazione per Regolamento.xaml
    /// </summary>
    public partial class Regolamento : Window
    {
        private MainWindow MainWindow;
        public Regolamento(MainWindow main)
        {
            InitializeComponent();
            MainWindow = main;
        }

        private void back2Main(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow.Show();
        }
    }
}
