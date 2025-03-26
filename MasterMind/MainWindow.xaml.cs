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
        private PartitaDiff1 partitaDiff1;
        private PartitaDiff2 partitaDiff2;
        private PartitaDiff3 partitaDiff3;
        private PartitaDiff4 partitaDiff4;
        private PartitaDiff6 partitaDiff6;
        private PartitaDiff7 partitaDiff7;
        private PartitaDiff8 partitaDiff8;
        private PartitaDiff9 partitaDiff9;


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
                partitaWpf = new PartitaWpf(this, partita);
                partitaWpf.Show();//la partita di default
            }
            else
            {
                if (Difficolta.CheckBoxCounter == 0 || Difficolta.CheckBoxCounter == 1)
                {
                    partita = new Partita(giocatore);
                }
                else
                {
                    partita = new Partita(giocatore, Difficolta.CheckBoxCounter);
                }
            }
            if(Difficolta.CheckBoxCounter == 2)
            {
                partitaDiff1 = new PartitaDiff1(this, partita);
                partitaDiff1.Show();
            }
            if(Difficolta.CheckBoxCounter == 3)
            {
                partitaDiff2 = new PartitaDiff2(this, partita);
                partitaDiff2.Show();
            }
            if (Difficolta.CheckBoxCounter == 4)
            {
                partitaDiff3 = new PartitaDiff3(this, partita);
                partitaDiff3.Show();
            }
            if (Difficolta.CheckBoxCounter == 5)
            {
                partitaDiff4 = new PartitaDiff4(this, partita);
                partitaDiff4.Show();
            }
            if(Difficolta.CheckBoxCounter == 6)
            {
                partitaWpf  = new PartitaWpf(this, partita);
                partitaWpf.Show();
            }
            if(Difficolta.CheckBoxCounter == 7)
            {
                partitaDiff6 = new PartitaDiff6(this, partita);
                partitaDiff6.Show();
            }
            if (Difficolta.CheckBoxCounter == 8)
            {
                partitaDiff7 = new PartitaDiff7(this, partita);
                partitaDiff7.Show();
            }
            if (Difficolta.CheckBoxCounter == 9)
            {
                partitaDiff8 = new PartitaDiff8(this, partita);
                partitaDiff8.Show();
            }
            if (Difficolta.CheckBoxCounter == 10)
            {
                partitaDiff9 = new PartitaDiff9(this, partita);
                partitaDiff9.Show();
            }
        }
    }
}