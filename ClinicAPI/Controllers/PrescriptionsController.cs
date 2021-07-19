using ClinicAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClinicAPI.Controllers
{
    [ApiController]
    [Route("api/prescriptions")]
    public class PrescriptionsController : ControllerBase
    {
        private readonly IDbService _dbservice;

        public PrescriptionsController(IDbService dbService)
        {
            _dbservice = dbService;
        }

        [HttpGet("{idPrescription}")]
        public async Task<IActionResult> GetPrescription(int idPrescription)
        {
            var prescription = await _dbservice.GetPrescriptionByIdAsync(idPrescription);
            if (prescription == null) 
                return NotFound("There is no prescription with this id");
            return Ok(prescription);
        }
    }
}
