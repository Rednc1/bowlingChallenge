using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bowlingChallenge.Models
{
    internal class Frame
    {
        public int frameCounter { get; set; }
        public int roll1 { get; set; } = 0;
        public int roll2 { get; set; } = 0;
        public int roll3 { get; set; } = 0;
        public int? totalScore { get; set; } = 0;
        public string? notes { get; set; } = string.Empty;

        public List<Frame> DataSet()
        {
            List<Frame> dataSet = new List<Frame>() {
                new Frame() { frameCounter = 1, roll1 = 1, roll2 = 4 },
                new Frame() { frameCounter = 2, roll1 = 4, roll2 = 5 },
                new Frame() { frameCounter = 3, roll1 = 6, roll2 = 4 },
                new Frame() { frameCounter = 4, roll1 = 5, roll2 = 5 },
                new Frame() { frameCounter = 5, roll1 = 10, roll2 = 0 },
                new Frame() { frameCounter = 6, roll1 = 0, roll2 = 1 },
                new Frame() { frameCounter = 7, roll1 = 7, roll2 = 3 },
                new Frame() { frameCounter = 8, roll1 = 6, roll2 = 4 },
                new Frame() { frameCounter = 9, roll1 = 10, roll2 = 0 },
                new Frame() { frameCounter = 10, roll1 = 2, roll2 = 8, roll3 = 6 },
            };

            return dataSet;
        }
    }
}
