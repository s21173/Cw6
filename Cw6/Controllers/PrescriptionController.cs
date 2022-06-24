using Cw6.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cw6.Controllers
{
    [Route("api/prescription")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IDbService dbService;

        public PrescriptionController(IDbService dbService)
        {
            this.dbService = dbService;
        }

        [HttpGet("{idPrescription}")]
        public async Task<IActionResult> GetPrescription([FromRoute] int idPrescription)
        {
            var result = await dbService.GetPrescription(idPrescription);
            return Ok(result);
        }

    }
}
