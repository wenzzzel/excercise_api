using System;

namespace excercise_api
{
    public class Set
    {
        public int Id { get; set; }
        public Excercice Excercice { get; set; }
        public int Reps { get; set; }
        public DateTime PerformedAt { get; set; }
    }
}