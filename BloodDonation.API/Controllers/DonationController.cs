﻿using BloodDonation.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonation.API.Controllers
{
    [Route("api/donation")]
    [ApiController]
    public class DonationController : ControllerBase
    {
        private readonly IMediator _mediatR;
        public DonationController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Donor donor)
        {

            return CreatedAtAction(nameof(GetById), new { id = donor.Id }, donor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Donor donor)
        {
            return NoContent();
        }

    }
}
