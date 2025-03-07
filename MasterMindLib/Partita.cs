using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
public enum Colors{
    WHITE,BLUE,GREEN,RED,LIGHTBLUE,YELLOW,PURPLE,MAGENTA,BLACK,BROWN,PINK
}
public enum StatusOfGame
{
    WON,LOST,INPROGRESS
}
namespace MasterMindLib
{
    public class Partita
    {
        public Partita(Giocatore player1, int numOfColors=6 )
        {
            Player1 = player1;
            MasterMindPc = new MasterMindPc(); // Initialize MasterMindPc here
            SecretCode = MasterMindPc.Code;
            NumOfColors = numOfColors;
            Tentativi = NumOfColors + 1;
            Colors[] cols = new Colors[NUM_OF_COLORS_TO_GUESS];
            Game = new List<Colors[]>();

            for (int i = 0; i < Tentativi; i++)
            {
                Game.Add(cols);
            }
        }

        private int NUM_OF_COLORS_TO_GUESS = 4;

        public int Tentativi { get; private set; }
        public Giocatore Player1 { get; set; }
        public Colors[] SecretCode { get; private set; }
        public List<Colors[]> Game { get; private set; }
        public int NumOfColors { get; private set; }
        public StatusOfGame StatusOfThisGame { get; private set; } = StatusOfGame.INPROGRESS;
        public void AddSlide() // pusha una lista di colori al vettore game
        {
            Game.Add(new Colors[NUM_OF_COLORS_TO_GUESS]);
        }

        public void RemoveSlide() // poppa una lista di colori al vettore game
        {
            Game.RemoveAt(Game.Count() - 1);
        }
        public int ColRightPos { get; private set; }
        public int ColWrongPosButRightCol { get; private set; }
        public StatusOfGame DoRound(Colors[] ColoriInOrdineDaSinistraVersoDestra) // il nome è temporaneo
        {
            // aggiunge al vettore game la lista di colori
            Game.Add(ColoriInOrdineDaSinistraVersoDestra);
            StatusOfThisGame = CheckGame(ColoriInOrdineDaSinistraVersoDestra);
            // incrementa il contatore di partite giocate del giocatore
            Player1.PlayedCounter++;
            // controlla se la lista di colori è uguale al codice segreto chiamando il checkgame

            // se è uguale incrementa il contatore di vittorie del giocatore
            // se non è uguale incrementa il contatore di sconfitte del giocatore

            // controlla se lo stato della partita è in progress MA NON QUI, da un altra parte tipo xaml cs

            // controlla se il counter di partite ha superato il massimo
            // calcola quanti colori hai indovinato nella posizione corretta chiamando GetNumOfRightColorsRightPositions
            GetNumOfRightColorsRightPositions(ColoriInOrdineDaSinistraVersoDestra);

            // calcola quanti colori hai indovinato ma non in posizione corretta chiamando GetNumOfRightColorsWrongPositions
            GetNumOfRightColorsWrongPositions(ColoriInOrdineDaSinistraVersoDestra);

            return StatusOfThisGame;
        }
        public int numberOfRightColorsWithIncorrectPosition { get; private set; }
        private void GetNumOfRightColorsWrongPositions(Colors[] ColoriInOrdineDaSinistraVersoDestra)
        {
            // controlla quanti colori hai indovinato ma non in posizione corretta
            for (int i = 0; i < NUM_OF_COLORS_TO_GUESS; i++)
            {
                for (int j = 0; j < NUM_OF_COLORS_TO_GUESS; j++)
                {
                    if (ColoriInOrdineDaSinistraVersoDestra[i] == SecretCode[j] && j != i)
                    {
                        ColWrongPosButRightCol++;

                    }
                }
            }

        }
        public int numberOfRightColorsWithCorrectPosition { get; private set; }
        private void GetNumOfRightColorsRightPositions(Colors[] ColoriInOrdineDaSinistraVersoDestra)
        {
            // controlla quanti colori hai indovinato nella posizione corretta
            for (int i = 0; i < NUM_OF_COLORS_TO_GUESS; i++)
            {
                if (ColoriInOrdineDaSinistraVersoDestra[i] == SecretCode[i])
                {
                    ColRightPos++;
                }
            }
        }
        private StatusOfGame CheckGame(Colors[] attempt) // setta lo stato del game se sono uguali
        {
            GetNumOfRightColorsRightPositions(attempt);
            if (ColRightPos == SecretCode.Length)
            {
                return StatusOfGame.WON;
            }
            else if (Player1.PlayedCounter > Tentativi)
            {
                return StatusOfGame.LOST;
            }
            else
            {
                return StatusOfGame.INPROGRESS;
            }
        }
        public MasterMindPc MasterMindPc { get; }
    }
}
