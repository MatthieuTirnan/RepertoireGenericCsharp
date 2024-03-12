using FirstGenericRepository.Api.Helpers;
using FirstGenericRepository.Domain.Repository;
using Microsoft.AspNetCore.Mvc;
using Shared.Enums;

namespace FirstGenericRepository.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController(IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;


        [HttpGet]
        [AuthorizeRoles(RoleEnum.Admin, RoleEnum.Aucun)]
        public ActionResult Get()
        {
            var actorFromRepo = _unitOfWork.Actor.GetAll();

            return Ok(actorFromRepo);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetbyId(
            [FromRoute]
            int id
            )
        {
            var actorFromRepo = _unitOfWork.Actor.GetById(id);

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
