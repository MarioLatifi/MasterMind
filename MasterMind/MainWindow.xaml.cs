using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MasterMindLib;
namespace MasterMind
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //va fatto nel costruttore
        Giocatore giocatore = new Giocatore();
        Partita Partita= new Partita(giocatore, [classe che genera colori]);
        public MainWindow()
        {
            InitializeComponent();
            //devo inizializzre la classe partita
        }
        
        private void Btn_RedirecToRegolamento(object sender, RoutedEventArgs e)
        {
            if(sender is Button)
            {
                this.Hide();
                Button btn = new Button();
                btn = sender as Button;
                Regolamento regolamento = new Regolamento();
                regolamento.Show();
                

            }
        }
        private Difficolta difficolta;
        private PartitaWpf partita;
        private void btn_diff_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            difficolta= new Difficolta(this);
            difficolta.Show();
        }

        private void btn_inizia_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            //devo settare una variabile globale di tipo Difficoltá che mi permette di creare la partita
            //se la variabile vale -1 (non cambiata) uso il costruttore di default
            partita = new PartitaWpf();
            partita.Show();
        }
    }
}