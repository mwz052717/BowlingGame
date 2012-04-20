using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingGameTest
{
    class Scorer
    {
        private int ball;
        private int[] throws = new int[21];
        private int currentThrow;

        public void AddThrow(int pins)
        {
            throws[currentThrow++] = pins;
        }

        public int ScoreForFrame(int theFrame)
        {
            ball = 0;
            int score = 0;
            for (int currentFrame = 0;
                currentFrame < theFrame;
                currentFrame++)
            {
                if (Strike())
                {
                    score += 10 + NextTwoBallsForStrike;
                    ball++;
                }
                else if (Spare())
                {
                    score += 10 + NextBallsForSpare;
                    ball += 2;
                }
                else
                {
                    score += TwoBallsInFrame;
                    ball += 2;
                }
            }

            return score;
        }

        private bool Spare()
        {
            return throws[ball] + throws[ball + 1] == 10;
        }

        private bool Strike()
        {
            return throws[ball] == 10;
        }

        private int NextTwoBallsForStrike
        { get { return (throws[ball + 1] + throws[ball + 2]); } }

        private int NextBallsForSpare
        { get { return throws[ball + 2]; } }


        private int TwoBallsInFrame
        { get { return throws[ball] + throws[ball + 1]; } }

    }
}
    


