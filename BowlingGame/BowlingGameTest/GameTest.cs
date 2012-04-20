using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGameTest
{
    /// <summary>
    /// GameTest 的摘要说明
    /// </summary>
    [TestClass]
    public class GameTest
    {
        private Game game;
        public void SetUp()
        {
            game = new Game();
        }

        [TestMethod]
        public void TestTwoThrowsNoMark()
        {
            SetUp();
            game.Add(5);
            game.Add(4);
            Assert.AreEqual(9,game.Score);
        }


        [TestMethod]
        public void TestFourThrowsNoMark()
        {
            SetUp();
            game.Add(5);
            game.Add(4);
            game.Add(7);
            game.Add(2);
            Assert.AreEqual(18, game.Score);
            Assert.AreEqual(9, game.ScoreForFrame(1));
            Assert.AreEqual(18, game.ScoreForFrame(2));
        }

        [TestMethod]
        public void TestSimpleSpare()
        {
            SetUp();
            game.Add(3);
            game.Add(7);
            game.Add(3);
            Assert.AreEqual(13, game.ScoreForFrame(1));
        }

        [TestMethod]
        public void TestSimpleFrameAfterSpare()
        {
            SetUp();
            game.Add(3);
            game.Add(7);
            game.Add(3);
            game.Add(2);
            Assert.AreEqual(13, game.ScoreForFrame(1));
            Assert.AreEqual(18, game.ScoreForFrame(2));
            Assert.AreEqual(18, game.Score);
        }

        [TestMethod]
        public void TestSimpleStrike()
        {
            SetUp();
            game.Add(10);;
            game.Add(3);
            game.Add(6);
            Assert.AreEqual(19, game.ScoreForFrame(1));
            Assert.AreEqual(28, game.Score);
        }

        [TestMethod]
        public void TestPerfectGame()
        {
            SetUp();
            for (int i = 0; i < 12; i++)
            {
                game.Add(10);
            }
            Assert.AreEqual(300, game.Score);
        }

        [TestMethod]
        public void TestEndOfArray()
        {
            SetUp();
            for (int i = 0; i < 9; i++)
            {
                game.Add(0);
                game.Add(0);
            }
            game.Add(2);
            game.Add(8);
            game.Add(10);
            Assert.AreEqual(20, game.Score);
        }

        [TestMethod]
        public void TestSampleGame()
        {
            SetUp();
            game.Add(1);
            game.Add(4);
            game.Add(4);
            game.Add(5);
            game.Add(6);
            game.Add(4);
            game.Add(5);
            game.Add(5);
            game.Add(10);
            game.Add(0);
            game.Add(1);
            game.Add(7);
            game.Add(3);
            game.Add(6);
            game.Add(4);
            game.Add(10);
            game.Add(2);
            game.Add(8);
            game.Add(6);
            Assert.AreEqual(133, game.Score);
        }

        [TestMethod]
        public void TestHeartBreak()
        {
            SetUp();
            for (int i = 0; i < 11; i++)
                game.Add(10);
            game.Add(9);
            Assert.AreEqual(299, game.Score);
        }

        [TestMethod]
        public void TestTenthFrameSpare()
        {
            SetUp();
            for (int i = 0; i < 9; i++)
                game.Add(10);
            game.Add(9);
            game.Add(1);
            game.Add(1);
            Assert.AreEqual(270, game.Score);
        }
    }
}
