﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace excercise_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class HighScoreController : ControllerBase
    {
        private readonly ILogger<HighScoreController> _logger;
        private readonly MyDbContext _db;

        public HighScoreController(ILogger<HighScoreController> logger, MyDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        public ActionResult<HighScore> Get()
        {
            var query = 
                from hs in _db.HighScore
                select hs;
	        
            if(query.Count() > 0){
                return Ok(query);
            } else{
                return NoContent();
            }
        }

        [HttpPost]
        public async Task<ActionResult<HighScore>> PostHighScoreItem(HighScore highScore)
        {
            _db.HighScore.Add(highScore);
            await _db.SaveChangesAsync();

            return highScore;
        }
    }
}
