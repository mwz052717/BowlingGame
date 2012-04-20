using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingGameTest
{
    class Game
    {
        private int currentFrame = 0;
        private bool isFirstThrow = true;
        private Scorer scorer = new Scorer();

        public int Score
        {
            get { return ScoreForFrame(currentFrame); }
        }

        public int ScoreForFrame(int theFrame)
        {
            return scorer.ScoreForFrame(theFrame);
        }

        public void Add(int pins)
        {
            scorer.AddThrow(pins);
            AdjustCurrentFrame(pins);
        }

        private void AdjustCurrentFrame(int pins)
        {
            if (LastBallInFrame(pins))
                AdvanceFrame();
            else
                isFirstThrow = false;
        }

        private void AdvanceFrame()
        {
            currentFrame++;
            if (currentFrame > 10)
                currentFrame = 10;
        }

        private bool LastBallInFrame(int pins)
        {
            return Strike(pins) || (!isFirstThrow);
        }

        private bool Strike(int pins)
        {
            return (isFirstThrow && pins == 10);
        }
    }
}
