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
                return BadRequest(new GeneralActionResponse(){
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
                return BadRequest(new GeneralActionResponse(){
                    Errors = new List<string>() {
                        "Invalid payload"
                    },
                    Success = false
                });
            }

        }

        [HttpDelete]
        //TODO: Add authentication to this endpoint
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //Check that the id provided actually exists in the database
            if(!_myDbContext.Excercices.Any<Excercice>(e => e.Id == id))
            {
                return NotFound(new GeneralActionResponse(){
                    Errors = new List<string>(){
                        "Id does not exist"
                    },
                    Success = false
                });
            }

            Excercice excerciseToRemove = new Excercice() {
                Id = id
            };

            try
            {
                _myDbContext.Remove(excerciseToRemove);
                await _myDbContext.SaveChangesAsync();
            }
            catch
            {                
                return StatusCode(500, new GeneralActionResponse(){
                    Errors = new List<string>() {
                        "Unknown server-side error occured when trying to remove record"
                    },
                    Success = false
                });
            }

            return Ok(new GeneralActionResponse(){
                Errors = new List<string>() {
                    ""
                },
                Success = true
            });
            
        }
    }
}