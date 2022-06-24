using Cw6.DataAccess;
using Cw6.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw6.Controllers
{
    [Route("api/doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDbService dbService;

        public DoctorController(IDbService dbService)
        {
            this.dbService = dbService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            IList<SomeKindOfDoctor> result = await dbService.GetDoctors();
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> PostDoctor(SomeKindOfDoctor someKindOfDoctor)
        {
            bool result = await dbService.AddDoctor(someKindOfDoctor);
            if (!result)
            {
                return BadRequest("Check the data and try again");
            }
            return Ok("Doctor was added");
        }

        [HttpPut("{idDoctor}")]
        public async Task<IActionResult> PutDoctor([FromRoute] int idDoctor, SomeKindOfDoctor someKindOfDoctor)
        {
            bool result = await dbService.UpdateDoctor(idDoctor, someKindOfDoctor);
            if (!result)
            {
                return BadRequest("Check the data and try again");
            }
            return Ok("Doctor was updated");
        }

        [HttpDelete("{idDoctor}")]
        public async Task<IActionResult> DeleteDoctor([FromRoute] int idDoctor)
        {
          bool  result= await dbService.RemoveDoctor(idDoctor);
            if (!result)
            {
               return BadRequest("Check the data and try again");
            }
            return Ok("OK");
        }
    }
}
