using System.Drawing;
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
        Giocatore giocatore;
        //Partita Partita = new Partita(giocatore, [classe che genera colori]);

        public MainWindow()
        {
            InitializeComponent();
            giocatore = new Giocatore();
            Difficolta = new DifficoltaWpf(this); // inizializzazione nel costruttore
        }
        
        private void Btn_RedirecToRegolamento(object sender, RoutedEventArgs e)
        {
            if(sender is Button)
            {
                this.Hide();
                Button btn = new Button();
                btn = sender as Button;
                Regolamento regolamento = new Regolamento(this);
                regolamento.Show();
                

            }
        }
        private DifficoltaWpf Difficolta; // dichiarazione senza inizializzazione
        private PartitaWpf partitaWpf;
        private void btn_diff_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Difficolta= new DifficoltaWpf(this);
            Difficolta.Show();
        }

        private void btn_inizia_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            //devo settare una variabile globale di tipo Difficoltá che mi permette di creare la partita
            //se la variabile vale 0 o ad 1 (non cambiata) uso il costruttore di default

            Partita partita; // dichiarazione della variabile partita

            //Partita Partita = new Partita(giocatore, [classe che genera colori]); creo qui la partita
            if (Difficolta.CheckBoxCounter == 0 || Difficolta.CheckBoxCounter == 1)
            {
                partita = new Partita(giocatore);
            }
            else
            {
                partita = new Partita(giocatore, Difficolta.CheckBoxCounter);
            }
            partitaWpf = new PartitaWpf(this, partita);
            partitaWpf.Show();
        }
    }
}