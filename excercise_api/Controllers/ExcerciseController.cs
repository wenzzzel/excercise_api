using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace excercise_api .Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExcerciseController: ControllerBase
    {
        private readonly MyDbContext _myDbContext;
        public ExcerciseController(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        [HttpGet]
        public  IEnumerable<Excercice> Get()
        {
            IEnumerable<Excercice> excercises = _myDbContext.Excercices;
            return excercises;
        }
    }
}