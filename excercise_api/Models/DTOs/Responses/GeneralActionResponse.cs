using System;
using System.Collections.Generic;

namespace excercise_api.Models.DTOs.Responses
{
    public class GeneralActionResponse
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}