using MasterMindLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MasterMindTest
{
    [TestClass]
    public class GiocatoreTest
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
        public void WonCounter_IncrementsCorrectly()
        {
            Colors[] secretCode = partita.SecretCode;
            StatusOfGame status = partita.DoRound(secretCode);
            Assert.AreEqual(StatusOfGame.WON, status);
            Assert.AreEqual(1, giocatore.WonCounter);
            Assert.AreEqual(1, giocatore.PlayedCounter);
        }

        [TestMethod]
        public void LostCounter_IncrementsCorrectly()
        {
            partita = new Partita(giocatore, 1);
            Colors[] attempt = new Colors[] { Colors.RED, Colors.GREEN, Colors.BLUE, Colors.YELLOW };
            for (int i = 0; i < partita.Tentativi; i++)
            {
                partita.DoRound(attempt);
            }
            StatusOfGame status = partita.DoRound(attempt);
            Assert.AreEqual(StatusOfGame.LOST, status);
            Assert.AreEqual(1, giocatore.LostCounter);
            Assert.AreEqual(1, giocatore.PlayedCounter);
        }

        [TestMethod]
        public void PlayedCounter_IncrementsCorrectly()
        {
            Colors[] attempt = new Colors[] { Colors.RED, Colors.GREEN, Colors.BLUE, Colors.YELLOW };
            partita.DoRound(attempt);
            Assert.AreEqual(1, giocatore.PlayedCounter);
        }
    }
}
