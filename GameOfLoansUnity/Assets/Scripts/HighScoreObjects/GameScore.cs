using System;
using System.Collections.Generic;

namespace Assets.Scripts.HighScoreObjects
{
    [Serializable]
    public class GameScore  {
        public int? Id;
        public string Name;
        public string TeamName;
        public int Score;
        public int LoansClosed;
    }

    [Serializable]
    public class GameScoreList
    {
        public GameScore[] Data;
    }
}