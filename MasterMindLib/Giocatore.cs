namespace MasterMindLib
{
    public class Giocatore
    {
        public Giocatore(string name)
        {
            Name= name;
        }
        public string Name
        {
            get => default;
            private set
            {
                //controlli
            }
        }
        private List<Colors> _round;
        public void addBallToCurrentRound(Colors Color)
        {
            //fai controllo per vedere se è grande quando la difficoltà prevista
            _round.Add(Color);
        }
        public int WonCounter
        {
            get => default;
            private set
            {
            }
        }

        public int LostCounter
        {
            get => default;
            private set
            {
            }
        }

        public int PlayedCounter
        {
            get => default;
            private set
            {
            }
        }
        
    }
}
