using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace excercise_api
{
    public class GymSession
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Note { get; set; }
        public List<Set> Sets { get; set; }
        public DateTime PerformedAt { get; set; }
    }
}