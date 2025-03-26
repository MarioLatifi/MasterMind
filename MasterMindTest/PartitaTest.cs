using MasterMindLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MasterMindTest
{
    [TestClass]
    public sealed class PartitaTest
    {
        private Giocatore giocatore;
        private Partita partita;
        private Colors[] fixedCode;

        [TestInitialize]
        public void Setup()
        {
            giocatore = new Giocatore();
            fixedCode = new Colors[] { Colors.RED, Colors.GREEN, Colors.BLUE, Colors.YELLOW };
            FixedGenerator fixedGenerator =new FixedGenerator(fixedCode);
            partita = new Partita(giocatore, 6, fixedGenerator);
        }

        [TestMethod]
        public void Partita_Constructor_InitializesCorrectly()
        {
            Assert.IsNotNull(partita.Player);
            Assert.IsNotNull(partita.SecretCode);
            Assert.AreEqual(6, partita.NumOfColors);
            Assert.AreEqual(7, partita.Tentativi);
            Assert.AreEqual(StatusOfGame.INPROGRESS, partita.StatusOfThisGame);
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
            Colors[] attempt = new Colors[] { Colors.RED, Colors.RED, Colors.BLUE, Colors.YELLOW };
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
        [TestMethod]
        public void TestDoRound_Win()
        {
            StatusOfGame status = partita.DoRound(fixedCode);
            Assert.AreEqual(StatusOfGame.WON, status);
            Assert.AreEqual(1, giocatore.WonCounter);
            Assert.AreEqual(1, giocatore.PlayedCounter);
        }

        [TestMethod]
        public void TestDoRound_Lose()
        {
            Colors[] wrongAttempt = new Colors[] { Colors.WHITE, Colors.WHITE, Colors.WHITE, Colors.WHITE };
            int tentativi = partita.Tentativi;
            for (int i = 0; i < tentativi; i++)
            {
                partita.DoRound(wrongAttempt);
            }
            StatusOfGame status = partita.DoRound(wrongAttempt);
            Assert.AreEqual(StatusOfGame.LOST, status);
            Assert.AreEqual(1, giocatore.LostCounter);
            Assert.AreEqual(partita.NumOfColors + 2, giocatore.PlayedCounter);//piú due pk nell'ultimo ha finito i tentativi
        }

        [TestMethod]
        public void TestGetNumOfRightColorsWrongPositions()
        {
            Colors[] attempt = new Colors[] { Colors.GREEN, Colors.RED, Colors.YELLOW, Colors.BLUE };
            partita.DoRound(attempt);
            Assert.AreEqual(4, partita.ColWrongPosButRightCol);
        }

        [TestMethod]
        public void TestGetNumOfRightColorsRightPositions()
        {
            Colors[] attempt = new Colors[] { Colors.RED, Colors.GREEN, Colors.BLUE, Colors.YELLOW };
            partita.DoRound(attempt);
            Assert.AreEqual(4, partita.ColRightPos);
        }
    }
}
