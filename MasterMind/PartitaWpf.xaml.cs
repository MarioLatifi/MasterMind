using System;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MasterMindLib;
namespace MasterMind
{
    /// <summary>
    /// Logica di interazione per Partita.xaml
    /// </summary>
    public partial class PartitaWpf : Window
    {
        private MainWindow Main;
        private Partita Partita;
        private Colors LastColorToBeClicked = Colors.BLACK;

        public PartitaWpf(MainWindow main, Partita partita)
        {
            InitializeComponent();
            Partita = partita;
            Main = main;
        }

        private void btn_Green_Click(object sender, RoutedEventArgs e)
        {
            LastColorToBeClicked = Colors.GREEN;
        }

        private void btn_Red_Click(object sender, RoutedEventArgs e)
        {
            LastColorToBeClicked = Colors.RED;
        }

        private void btn_Blue_Click(object sender, RoutedEventArgs e)
        {
            LastColorToBeClicked = Colors.BLUE;
        }

        private void btn_Yellow_Click(object sender, RoutedEventArgs e)
        {
            LastColorToBeClicked = Colors.YELLOW;
        }

        private void btn_Pink_Click(object sender, RoutedEventArgs e)
        {
            LastColorToBeClicked = Colors.PINK;
        }

        private void btn_LightBlue_Click(object sender, RoutedEventArgs e)
        {
            LastColorToBeClicked = Colors.LIGHTBLUE;
        }

        private System.Windows.Media.Color GetColor(Colors color)
        {
            switch (color)
            {
                case Colors.GREEN:
                    return System.Windows.Media.Colors.Green;
                case Colors.RED:
                    return System.Windows.Media.Colors.Red;
                case Colors.BLUE:
                    return System.Windows.Media.Colors.Blue;
                case Colors.YELLOW:
                    return System.Windows.Media.Colors.Yellow;
                case Colors.PINK:
                    return System.Windows.Media.Colors.Pink;
                case Colors.LIGHTBLUE:
                    return System.Windows.Media.Colors.LightBlue;
                default:
                    return System.Windows.Media.Colors.White;
            }
        }
        Colors[] ColoriInOrdineDaSinistraVersoDestra = new Colors[4];

        // ...

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // Trova l'ellisse all'interno del template del bottone
                var grid = btn.Template.FindName("buttonGrid", btn) as Grid;
                if (grid != null)
                {
                    var ellipse = grid.Children[0] as Ellipse;
                    if (ellipse != null)
                    {
                        // Cambia il colore di riempimento dell'ellisse
                        ellipse.Fill = new SolidColorBrush(GetColor(LastColorToBeClicked));
                    }
                }

                // Aggiorna l'array ColoriInOrdineDaSinistraVersoDestra
                if (btn.Name == "btn_1" || btn.Name == "btn_5" || btn.Name == "btn_9" || btn.Name == "btn_13" || btn.Name == "btn_17" || btn.Name == "btn_21" || btn.Name == "btn_25")
                {
                    ColoriInOrdineDaSinistraVersoDestra[0] = LastColorToBeClicked;
                }
                else if (btn.Name == "btn_2" || btn.Name == "btn_6" || btn.Name == "btn_10" || btn.Name == "btn_14" || btn.Name == "btn_18" || btn.Name == "btn_22" || btn.Name == "btn_26")
                {
                    ColoriInOrdineDaSinistraVersoDestra[1] = LastColorToBeClicked;
                }
                else if (btn.Name == "btn_3" || btn.Name == "btn_7" || btn.Name == "btn_11" || btn.Name == "btn_15" || btn.Name == "btn_19" || btn.Name == "btn_23" || btn.Name == "btn_27")
                {
                    ColoriInOrdineDaSinistraVersoDestra[2] = LastColorToBeClicked;
                }
                else if (btn.Name == "btn_4" || btn.Name == "btn_8" || btn.Name == "btn_12" || btn.Name == "btn_16" || btn.Name == "btn_20" || btn.Name == "btn_24" || btn.Name == "btn_28")
                {
                    ColoriInOrdineDaSinistraVersoDestra[3] = LastColorToBeClicked;
                }
            }
        }

    }
}
