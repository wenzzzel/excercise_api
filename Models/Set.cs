using System;

namespace excercise_api
{
    public class Set
    {
        public int Id { get; set; }
        public Excercice excercice { get; set; }
        public int reps { get; set; }
        public DateTime PerformedAt { get; set; }
    }
}