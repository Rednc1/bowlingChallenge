// See https://aka.ms/new-console-template for more information
using bowlingChallenge;
using bowlingChallenge.Models;

BowlingGame start = new BowlingGame();
//start.StartGame();

//
Frame frames = new Frame();
List<Frame> gameResult = new List<Frame>();
gameResult = frames.DataSet();
start.TallyScore(gameResult);