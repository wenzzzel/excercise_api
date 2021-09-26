using System;
using System.ComponentModel.DataAnnotations;

namespace excercise_api
{
    public class Set
    {
        public int Id { get; set; }
        [Required]
        public Excercice Excercice { get; set; }
        public int Reps { get; set; }
        public DateTime PerformedAt { get; set; }
    }
}