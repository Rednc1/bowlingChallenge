using bowlingChallenge.Models;
using bowlingChallenge.Utilities;

namespace bowlingChallenge
{
    internal class BowlingGame
    {
        Roller roller = new Roller();
        List<Frame> gameResults = new List<Frame>();

        //Generate score result from a game
        public void StartGame()
        {
            for (int i = 1; i < 11; i++)
            {
                Frame frame = new Frame();
                
                int pins = 10;
                int roll1 = roller.RandomRoller(pins);
                int roll2 = roller.RandomRoller(pins - roll1);           

                frame.frameCounter = i;
                frame.roll1 = roll1;
                frame.roll2 = roll2;

                if (i == 10)
                {
                    if (roll1 == 10 || (roll1+roll2 == 10))
                    {
                        frame.roll3 = roller.RandomRoller(10);
                    }   
                }
                gameResults.Add(frame);
            }
            TallyScore(gameResults);
        }

        // Tally the score and print result
        public void TallyScore(List<Frame> gameResult)
        {
            int totalScore = 0;

            for (int i = 0; i < gameResult.Count(); i++)
            {
                //last frame
                if (i == gameResult.Count() - 1)
                {
                    totalScore = totalScore + LastFrame(gameResult, i);
                    gameResult[i].totalScore = totalScore;
                    continue;
                }           
                // neither strike or spare
                else if (gameResult[i].roll1 + gameResult[i].roll2 < 10)
                {
                    totalScore = totalScore + NormalFrame(gameResult, i); 
                    gameResult[i].totalScore = totalScore;
                    continue;
                } 
                //strike
                else if (gameResult[i].roll1 == 10 && (i != gameResult.Count() - 1))
                {
                    totalScore = totalScore + Strike(gameResult, i); 
                    gameResult[i].totalScore = totalScore;
                    gameResult[i].notes = "Strike";
                    continue;
                } 
                // spare
                else if (gameResult[i].roll1 + gameResult[i].roll2 == 10)
                {
                    totalScore = totalScore + Spare(gameResult, i); 
                    gameResult[i].totalScore = totalScore;
                    gameResult[i].notes = "Spare";
                }
            }

            PrintScore(gameResult);
        }

        public void PrintScore(List<Frame> gameResults)
        {
            string roll3 = "";

            for (int i = 0; i < gameResults.Count; i++)
            {
                if (i == gameResults.Count - 1)
                {
                    roll3 = " | Roll3: " + gameResults[i].roll3.ToString();
                }

                Console.WriteLine("------------");
                Console.WriteLine("Frame: " + gameResults[i].frameCounter + " | Roll1: " + gameResults[i].roll1 + " | Roll2: " + gameResults[i].roll2 + "" + roll3 +  " | Score: " + gameResults[i].totalScore + " | Notes: " + gameResults[i].notes);
            }
        }

        private int LastFrame(List<Frame> gameResult, int i)
        {
            int result = gameResult[i].roll1 +
                         gameResult[i].roll2 +
                         gameResult[i].roll3;
            return result;
        }

        private int Strike(List<Frame> gameResult, int i)
        {
            int result = gameResult[i].roll1 +
                         gameResult[i + 1].roll1 +
                         gameResult[i + 1].roll2;
            return result;

        }

        private int Spare(List<Frame> gameResult, int i)
        {
            int result = gameResult[i].roll1 +
                         gameResult[i].roll2 +
                         gameResult[i + 1].roll1;
            return result;
        }

        private int NormalFrame(List<Frame> gameResult, int i)
        {
            int result = gameResult[i].roll1 +
                         gameResult[i].roll2;
            return result;
        }
    }
}
