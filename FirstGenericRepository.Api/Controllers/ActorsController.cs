﻿using FirstGenericRepository.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FirstGenericRepository.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController(IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        [HttpGet]
        public ActionResult Get()
        {
            var actorFromRepo = _unitOfWork.Actor.GetAll();

            return Ok(actorFromRepo);
        }

        [HttpGet("movies")]
        public ActionResult GetWithMovies()
        {
            var actorFromRepo = _unitOfWork.Actor.GetActorsWithMovie();

            return Ok(actorFromRepo);
        }
    }
}
