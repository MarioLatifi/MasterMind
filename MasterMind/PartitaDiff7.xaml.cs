using MasterMindLib;
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
    /// Logica di interazione per PartitaDiff7.xaml
    /// </summary>
    public partial class PartitaDiff7 : Window
    {
        private MainWindow Main;
        private Partita Partita;
        public Colors LastColorToBeClicked = Colors.BLACK;
        public PartitaDiff7(MainWindow main, Partita partita)
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
        private void btn_Orange_Click(object sender, RoutedEventArgs e)
        {
            LastColorToBeClicked = Colors.ORANGE;
        }
        private void btn_Purple_Click(object sender, RoutedEventArgs e)
        {
            LastColorToBeClicked = Colors.PURPLE;
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
                case Colors.ORANGE:
                    return System.Windows.Media.Colors.Orange;
                case Colors.PURPLE:
                    return System.Windows.Media.Colors.MediumPurple;
                default:
                    return System.Windows.Media.Colors.White;
            }
        }
        public Colors[] ColoriInOrdineDaSinistraVersoDestra { get; private set; } = new Colors[4];

        // ...
        private void click_AddColorToSequence(object sender, RoutedEventArgs e)
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
                if (btn.Name == "btn_1" || btn.Name == "btn_5" || btn.Name == "btn_9" || btn.Name == "btn_13" || btn.Name == "btn_17" || btn.Name == "btn_21" || btn.Name == "btn_25" || btn.Name == "btn_29" || btn.Name == "btn_33")
                {
                    ColoriInOrdineDaSinistraVersoDestra[0] = LastColorToBeClicked;
                }
                else if (btn.Name == "btn_2" || btn.Name == "btn_6" || btn.Name == "btn_10" || btn.Name == "btn_14" || btn.Name == "btn_18" || btn.Name == "btn_22" || btn.Name == "btn_26" || btn.Name == "btn_30" || btn.Name == "btn_34")
                {
                    ColoriInOrdineDaSinistraVersoDestra[1] = LastColorToBeClicked;
                }
                else if (btn.Name == "btn_3" || btn.Name == "btn_7" || btn.Name == "btn_11" || btn.Name == "btn_15" || btn.Name == "btn_19" || btn.Name == "btn_23" || btn.Name == "btn_27" || btn.Name == "btn_31" || btn.Name == "btn_35")
                {
                    ColoriInOrdineDaSinistraVersoDestra[2] = LastColorToBeClicked;
                }
                else if (btn.Name == "btn_4" || btn.Name == "btn_8" || btn.Name == "btn_12" || btn.Name == "btn_16" || btn.Name == "btn_20" || btn.Name == "btn_24" || btn.Name == "btn_28" || btn.Name == "btn_32" || btn.Name == "btn_36")
                {
                    ColoriInOrdineDaSinistraVersoDestra[3] = LastColorToBeClicked;
                }
            }
        }

        private void Button_Confirm(object sender, RoutedEventArgs e)
        {
            //devo controllare se la sequenza corrisponde a quella di MasterMindPc
            if (Partita.DoRound(ColoriInOrdineDaSinistraVersoDestra) == StatusOfGame.WON)
            {
                MessageBox.Show("Hai vinto");
                this.Close();
                Main.Show();
            }
            else
            {
                MessageBox.Show("Hai perso");
                Button btn = sender as Button;
                int roundNumber = int.Parse(btn.Name.Split('_')[2]);
                int startLabelIndex = (roundNumber - 1) * 4 + 1;

                for (int i = 0; i < Partita.ColRightPos; i++)
                {
                    Label label = (Label)FindName($"lbl_{startLabelIndex + i}");
                    ChangeCololorToLabel(label, System.Windows.Media.Colors.Black);
                }

                for (int i = 0; i < Partita.ColWrongPosButRightCol; i++)
                {
                    Label label = (Label)FindName($"lbl_{startLabelIndex + Partita.ColRightPos + i}");//brow sono quelli pos sbagliata ma colore giusto
                    ChangeCololorToLabel(label, System.Windows.Media.Colors.Brown);
                }
                btn.Visibility = Visibility.Hidden;
            }

        }
        private void ChangeCololorToLabel(Label label, System.Windows.Media.Color color)
        {
            if (label != null)
            {
                label.Background = new SolidColorBrush(color);
            }
        }

        private void btn_Replay(object sender, RoutedEventArgs e)
        {
            this.Close();
            Main.Show();
        }
    }
}
