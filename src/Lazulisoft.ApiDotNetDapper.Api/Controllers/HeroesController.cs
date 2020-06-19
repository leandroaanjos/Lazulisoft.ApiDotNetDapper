using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Lazulisoft.ApiDotNetDapper.Api.Models;
using Lazulisoft.ApiDotNetDapper.Api.Repositories;
using Lazulisoft.ApiDotNetDapper.Api.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lazulisoft.ApiDotNetDapper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly IHeroRepository _heroRepository;
        private readonly IMapper _mapper;

        public HeroesController(IHeroRepository heroRepository, IMapper mapper)
        {
            _heroRepository = heroRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var heroes = await _heroRepository.GetAll();
            return Ok(_mapper.Map<List<HeroViewModel>>(heroes));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var hero = await _heroRepository.Get(id);

            if (hero == null)
                return BadRequest();

            return Ok(_mapper.Map<HeroViewModel>(hero));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] HeroViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var newHero = _mapper.Map<Hero>(model);
                await _heroRepository.Add(newHero);

                return CreatedAtAction(nameof(Get), new { id = newHero.Id }, _mapper.Map<HeroViewModel>(newHero));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Msg = ex.Message });
            }
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] HeroViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var updateHero = await _heroRepository.Get(model.Id.Value);

                if (updateHero == null)
                    return NotFound();

                updateHero = _mapper.Map<Hero>(model);
                await _heroRepository.Update(updateHero);

                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Msg = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deleteHero = await _heroRepository.Get(id);

                if (deleteHero == null)
                    return NotFound();

                await _heroRepository.Delete(deleteHero.Id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Msg = ex.Message
                });
            }
        }
    }
}
