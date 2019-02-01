﻿using System;
using BirdWatcher.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BirdWatcher.Web.Controllers
{
    [Route("observation")]
    public class ObservationController : Controller
    {
        private readonly Repository _repo;

        public ObservationController(Repository repo)
        {
            _repo = repo;
        }

        [HttpPost("recreate")]
        public IActionResult RecreateDatabase()
        {
            _repo.RecreateDatabase();
            return Ok();
        }

        [HttpPost]
        public IActionResult Add([FromBody]Observation observation)
        {
            //Adderat allt
            if (observation == null)
            {
                return BadRequest("News is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repo.Add(observation);

            return Ok(observation.Id);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            //Adderat allt
            var all = _repo.GetAll();
            return Ok(all);
        }

    }
}
