namespace MasterMindLib
{
    public class Giocatore
    {
        public Giocatore()//tecnicamente avrei dovuto chiedergli un  nome ma nelal wpf mi sono scordato
        {
        }
        private int _wonCounter=0;

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
            get { return _lostCounter; }
            internal set
            {
                if (value < 0 || value > PlayedCounter) throw new ArgumentOutOfRangeException("lost counter mustmn't be higher than played's counter or lower than 0 ");
                _lostCounter = value;
            }
        }
        private int _playedCounter=0;

        public int PlayedCounter
        {
            get { return _playedCounter; }
            internal set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("played's counter must be higher than 0");
                _playedCounter = value;
            }
        }

    }
}
