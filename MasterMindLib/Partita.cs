using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMindLib
{
    public class Partita
    {
        public Giocatore Player1
        {
            get => default;
            set
            {
            }
        }

        public Giocatore Player2
        {
            get => default;
            set
            {
            }
        }

        public System.Numerics.Vector<System.Numerics.Vector<int>> Game
        {
            get => default;
            set
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

        public System.Enum Difficulty
        {
            get => default;
            set
            {
            }
        }

        public Giocatore Giocatore
        {
            get => default;
            set
            {
            }
        }

        public void AddSlide()
        {
            throw new System.NotImplementedException();
        }

        public void RemoveSlide()
        {
            throw new System.NotImplementedException();
        }

        public void DoRound()
        {
            throw new System.NotImplementedException();
        }

        public void GetResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
