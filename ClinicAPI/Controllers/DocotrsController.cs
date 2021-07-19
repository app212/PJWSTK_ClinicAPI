using ClinicAPI.DTOs;
using ClinicAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClinicAPI.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DocotrsController : ControllerBase
    {
        private readonly IDbService _dbservice;
        public DocotrsController(IDbService dbService)
        {
            _dbservice = dbService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            var doctors = await _dbservice.GetDoctorsAsync();
            return Ok(doctors);
        }

        [HttpDelete("{idDoctor}")]
        public async Task<IActionResult> RemoveDoctor(int idDoctor)
        {
            var removed = await _dbservice.DeleteDoctorAsync(idDoctor);
            if (!removed) return NotFound("There is no doctor with this id");
            return Ok($"Doctor with id {idDoctor} has been removed");
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctor([FromBody]DoctorDTO doctor)
        {
            var added = await _dbservice.InsertDoctorAsync(doctor);
            return Ok("Doctor has been added");
        }

        [HttpPut("{idDoctor}")]
        public async Task<IActionResult> UpdateDoctor(int idDoctor, [FromBody]DoctorDTO doctor)
        {
            var updated = await _dbservice.UpdateDoctorAsync(idDoctor, doctor);
            if (!updated) return NotFound("There is no doctor with this id");
            return Ok($"Doctor with id {idDoctor} has been updated");
        }
    }
}
