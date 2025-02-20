namespace MasterMindLib
{
    internal class Giocatore
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
            set
            {
            }
        }

        public int LostCounter
        {
            get => default;
             set
            {
            }
        }

        public int PlayedCounter
        {
            get => default;
            set
            {
            }
        }
        
    }
}
