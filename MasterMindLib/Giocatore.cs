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
