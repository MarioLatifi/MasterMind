using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
public enum Colors{
    BLUE,GREEN,RED,LIGHTBLUE,YELLOW,PURPLE,MAGENTA,WHITE,BLACK,BROWN
}
namespace MasterMindLib
{
    public class Partita
    {
        public Partita(Giocatore player1,int numOfColors)
        {
            Player1 = player1;
            MasterMindPc masterMindPc = new MasterMindPc();
            SecretCode = masterMindPc.Code;
            NumOfColors = numOfColors;
        }
        public Giocatore Player1{get; set;}
        public Colors[] SecretCode { get; private set; }
        public Vector<Colors[]> Game { get; private set; }
        public int NumOfColors { get; private set; }
        private Colors[] Temp = new Colors[4];
        public void AddBallToCurrentRound(Colors color, int timesCalled)
        {
            //bisogna controllare che il colore sia tra quelli che ci permette di usare il dato NumOfColors
            //se e' la quarta volta che questo metodo viene chiamato bisogna chiamare DoRound if(timesCalled==4) DoRound();
            //ma prima a prescindere dall'if bisogna aggiungere il colore ad un array Temporaneo

            //dopo aver chiamato DoRound bisogna svuotare l'array Temporaneo
            throw new System.NotImplementedException();
        }

        public void AddSlide()//pusha una lista di colori al vettore game
        {
            throw new System.NotImplementedException();
        }

        public void RemoveSlide()//poppa una lista di colori al vettore game
        {
            throw new System.NotImplementedException();
        }

        public void DoRound(Colors[] ColoriInOrdineDaSinistraVersoDestra)//il nome è temporaneo
        {
            //aggiunge al vettore game la lista di colori

            //controlla se la lista di colori è uguale al codice segreto chiamando il checkgame

            //se è uguale incrementa il contatore di vittorie del giocatore
            //se non è uguale incrementa il contatore di sconfitte del giocatore
            //incrementa il contatore di partite giocate del giocatore

            //calcola quanti colori hai indovinato nella posizione corretta chiamando GetNumOfRightColorsRightPositions
            //calcola quanti colori hai indovinato ma non in posizione corretta chiamando GetNumOfRightColorsWrongPositions
        }
        public int numberOfRightColorsWithIncorrectPosition { get; private set; }
        private int GetNumOfRightColorsWrongPositions(Colors[] ColoriInOrdineDaSinistraVersoDestra)
        {
            //controlla quanti colori hai indovinato ma non in posizione corretta
            throw new System.NotImplementedException();
        }
        public int numberOfRightColorsWithCorrectPosition { get; private set; }
        private int GetNumOfRightColorsRightPositions(Colors[] ColoriInOrdineDaSinistraVersoDestra)
        {
            //controlla quanti colori hai indovinato nella posizione corretta
            throw new System.NotImplementedException();
        }
        public bool CheckGame()
        {
            //controlla se la lista di colori è uguale al codice segreto
            throw new System.NotImplementedException();
        }
        public MasterMindPc MasterMindPc{get;}
    }
}
