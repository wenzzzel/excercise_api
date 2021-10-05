using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using excercise_api;
using System.Threading.Tasks;
using excercise_api.Models.DTOs.Responses;
using Microsoft.EntityFrameworkCore;

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

        [HttpPost]
        //TODO: Add authentication to this endpoint
        public async Task<IActionResult> Post([FromBody] Excercice excercice)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(new RegistrationResponse(){ //TODO: Create new response-model for this
                    Errors = new List<string>() {
                        "Invalid payload"
                    },
                    Success = false
                });
            }

            var isCreated = await _myDbContext.AddAsync(excercice);
            await _myDbContext.SaveChangesAsync();

            if(isCreated.IsKeySet)
            {
                return Ok(excercice);
            }
            else
            {
                return BadRequest(new RegistrationResponse(){ //TODO: Create new response-model for this
                    Errors = new List<string>() {
                        "Invalid payload"
                    },
                    Success = false
                });
            }

        }
    }
}