using System;

namespace excercise_api
{
    public class HighScore
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public DateTime Date { get; set; }
        
        public int Score { get; set; }
    }
}
