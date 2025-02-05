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
        public Partita(Giocatore player1,  bool isCustom)
        {
            Player1 = player1;
            //Player2 = new MasterMindPc();
            IsCustom = isCustom;
            MasterMindPc masterMindPc = new MasterMindPc();
            SecretCode = masterMindPc.Code;
        }
        /*
        public Partita(Giocatore player1, Giocatore player2, bool isCustom, Enum difficulty, List<Colors>secretCode )
        {
            Player1 = player1;
            Player2 = player2;
            IsCustom = isCustom;
            Difficulty = difficulty;
            SecretCode = secretCode;
        }
        */

        public Giocatore Player1
        {
            get;
            set;
        }
        public List<Colors> SecretCode { get; private set; }
        /*
        public Giocatore Player2
        {
            get;
            set;
        }
        */

        public Vector<List<Colors>> Game
        {
            get => default;
            private set
            {
            }
        }

        public bool IsCustom
        {
            get => default;
            set
            {
            }
        }

        public void AddSlide()//pusha una lista di colori al vettore game
        {
            throw new System.NotImplementedException();
        }

        public void RemoveSlide()//poppa una lista di colori al vettore game
        {
            throw new System.NotImplementedException();
        }
        public void DoRound(List<Colors> ColoriInOrdineDaSinistraVersoDestra)//il nome è temporaneo
        {

            throw new System.NotImplementedException();
        }

        public void CheckGame()
        {
            throw new System.NotImplementedException();
        }

        public Giocatore Giocatore
        {
            get => default;
            set
            {
            }
        }

        public Giocatore Giocatore1
        {
            get => default;
            set
            {
            }
        }
    }
}
