using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Entity;
using SharedFiles.Entities;
using TaskDAL.Helpers;
using TaskDAL.IRepository;

namespace TaskAPI.Controllers
{
    [Authorize(Roles = Roles.User)]
    [ApiController]
    [Route("api/[controller]")]
    public class PublicationController : ControllerBase
    {
        private IPublicationRepository _publicationRepo;
        public PublicationController(IPublicationRepository publicationRepo)
        {
            _publicationRepo = publicationRepo;
        }

        [HttpPost("AddPublication")]
        public IActionResult AddPublication(Publication publication)
        {
            publication.userId = this.User.GetUserId();
            _publicationRepo.AddPublication(publication);
            return Ok();
        }

        [HttpPut("UpdatePublication")]
        public IActionResult UpdatePublication(Publication publication)
        {
            publication.userId = this.User.GetUserId();
            _publicationRepo.UpdatePublication(publication);
            return Ok();
        }

        [HttpDelete("DeletePublication/{publicationId}")]
        public IActionResult DeletePublication(int publicationId)
        {
            _publicationRepo.DeletePublication(publicationId);
            return Ok();
        }

        [HttpGet("GetUserPublications")]
        public IActionResult GetUserPublications()
        {
            return Ok(_publicationRepo.GetUserPublications(this.User.GetUserId()));
        }
    }
}
