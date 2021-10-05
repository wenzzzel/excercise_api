using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using excercise_api;

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
        public IEnumerable<Excercice> Get()
        {   
            return _myDbContext.Excercices;
        }

        [HttpGet]
        [Route("{id}")]
        public IEnumerable<Excercice> Get(int id)
        {
            return _myDbContext.Excercices.Where(x => x.Id == id);
        }
    }
}