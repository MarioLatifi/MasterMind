using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
public enum Colors{
    WHITE, RED,GREEN,BLUE, YELLOW,PINK,LIGHTBLUE,ORANGE,PURPLE, MAGENTA,BROWN, BLACK
}
public enum StatusOfGame
{
    WON,LOST,INPROGRESS
}
namespace MasterMindLib
{
    public class Partita
    {
        public Partita(Giocatore player, int numOfColors=6,IGenerator? generator=null )
        {
            Player = player;
            if (generator==null)
            {
                _generator = new MasterMindPc(numOfColors);
            }
            else
            {
                _generator = generator;
            }
            SecretCode = _generator.GenerateSecretCode();
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
        private IGenerator _generator;
        public int Tentativi { get; private set; }
        public Giocatore Player { get; set; }
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

            // controlla se la lista di colori è uguale al codice segreto chiamando il checkgame
            StatusOfThisGame = CheckGame(ColoriInOrdineDaSinistraVersoDestra);

            // incrementa il contatore di partite giocate del giocatore
            Player.PlayedCounter++;

            // se è uguale incrementa il contatore di vittorie del giocatore
            if (StatusOfThisGame == StatusOfGame.WON)
            {
                Player.WonCounter++;
            }
            // calcola quanti colori hai indovinato ma non in posizione corretta chiamando GetNumOfRightColorsWrongPositions
            GetNumOfRightColorsWrongPositions(ColoriInOrdineDaSinistraVersoDestra);

            // controlla se il counter di partite ha superato il massimo
            if (Tentativi == 0 && StatusOfThisGame != StatusOfGame.WON)
            {
                StatusOfThisGame = StatusOfGame.LOST;
                Player.LostCounter++;
            }
            // decrementa il numero di tentativi rimasti
            Tentativi--;

            return StatusOfThisGame;
        }
        private void GetNumOfRightColorsWrongPositions(Colors[] ColoriInOrdineDaSinistraVersoDestra)
        {
            ColWrongPosButRightCol = 0;
            // controlla quanti colori hai indovinato ma non in posizione corretta
            for (int i = 0; i < NUM_OF_COLORS_TO_GUESS; i++)
            {
                for (int j = 0; j < NUM_OF_COLORS_TO_GUESS; j++)
                {
                    if (ColoriInOrdineDaSinistraVersoDestra[j] == SecretCode[i] && j != i)
                    {
                        ColWrongPosButRightCol++;

                    }
                }
            }
        }
        private void GetNumOfRightColorsRightPositions(Colors[] ColoriInOrdineDaSinistraVersoDestra)
        {
            ColRightPos = 0;
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
            ColRightPos = 0;
            GetNumOfRightColorsRightPositions(attempt);
            if (ColRightPos == SecretCode.Length)
            {
                return StatusOfGame.WON;
            }
            else if (Tentativi<=0)
            {
                return StatusOfGame.LOST;
            }
            else
            {
                return StatusOfGame.INPROGRESS;
            }
        }
    }
}
