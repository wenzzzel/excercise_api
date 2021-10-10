using System;
using System.ComponentModel.DataAnnotations;

namespace excercise_api
{
    public class Excercice
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
    }
}