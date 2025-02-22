namespace MasterMindLib
{
    public class Giocatore
    {
        public Giocatore(string name)
        {
            Name = name;
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("error");
        }
        public string Name
        {
            get { return Name; }
            internal set
            {
                Name = value;
            }
        }
        private int _wonCounter;

        public int WonCounter
        {
            get { return _wonCounter; }
            internal set
            {
                if (value < 0 || value > PlayedCounter) throw new ArgumentOutOfRangeException("won counter mustn't be higher than played's counter or lower than 0");
                _wonCounter = value;
            }

        }
        private int _lostCounter;

        public int LostCounter
        {
            get { return LostCounter; }
            internal set
            {
                if (value < 0 || value > PlayedCounter) throw new ArgumentOutOfRangeException("lost counter mustmn't be higher than played's counter or lower than 0 ");
                _lostCounter = value;
            }
        }
        private int _playedCounter;

        public int PlayedCounter
        {
            get { return PlayedCounter; }
            internal set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("played's counter must be higher than 0");
                PlayedCounter = value;
            }
        }

    }
}
