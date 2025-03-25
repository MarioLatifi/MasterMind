using MasterMindLib;

namespace MasterMindTest
{
    [TestClass]
    public sealed class PartitaTest
    {
        private Giocatore giocatore;
        private Partita partita;

        [TestInitialize]
        public void Setup()
        {
            giocatore = new Giocatore();
            partita = new Partita(giocatore);
        }

        [TestMethod]
        public void Partita_Constructor_InitializesCorrectly()
        {
            Assert.IsNotNull(partita.Player1);
            Assert.IsNotNull(partita.MasterMindPc);
            Assert.IsNotNull(partita.SecretCode);
            Assert.AreEqual(6, partita.NumOfColors);
            Assert.AreEqual(7, partita.Tentativi);
            Assert.AreEqual(StatusOfGame.INPROGRESS, partita.StatusOfThisGame);
        }

        [TestMethod]
        public void AddSlide_AddsNewSlide()
        {
            int initialCount = partita.Game.Count;
            partita.AddSlide();
            Assert.AreEqual(initialCount + 1, partita.Game.Count);
        }

        [TestMethod]
        public void RemoveSlide_RemovesLastSlide()
        {
            partita.AddSlide();
            int initialCount = partita.Game.Count;
            partita.RemoveSlide();
            Assert.AreEqual(initialCount - 1, partita.Game.Count);
        }

        [TestMethod]
        public void DoRound_UpdatesGameStatus()
        {
            Colors[] attempt = new Colors[] { Colors.RED, Colors.GREEN, Colors.BLUE, Colors.YELLOW };
            StatusOfGame status = partita.DoRound(attempt);
            Assert.AreEqual(StatusOfGame.INPROGRESS, status);
            Assert.AreEqual(1, giocatore.PlayedCounter);
        }

        [TestMethod]
        public void DoRound_WinsGame()
        {
            partita = new Partita(giocatore, 4);
            Colors[] secretCode = partita.SecretCode;
            StatusOfGame status = partita.DoRound(secretCode);
            Assert.AreEqual(StatusOfGame.WON, status);
        }

        [TestMethod]
        public void DoRound_LosesGame()
        {
            partita = new Partita(giocatore, 1);
            Colors[] attempt = new Colors[] { Colors.RED, Colors.RED, Colors.RED, Colors.YELLOW };
            for (int i = 0; i <= partita.Tentativi; i++)
            {
                partita.DoRound(attempt);
            }
            StatusOfGame status = partita.DoRound(attempt);
            Assert.AreEqual(StatusOfGame.LOST, status);
        }
    }
    
}
