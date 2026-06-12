using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GRADECOMPUTATIONAPI.Controllers
{
    [Route("api/Grades")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly GradeCalculator _appservice;

        public GradesController()
        {
            _appservice = new GradeCalculator();
        }

        // GET: api/Grades
        [HttpGet]
        public ActionResult<IEnumerable<DModels>> GetAllGrades()
        {
            var records = _appservice.GetGradeLogs();
            return Ok(records);
        }

        // GET: api/Grades/5
        [HttpGet("{id:int}")]
        public ActionResult<DModels> GetGradeById(int id)
        {
            var record = _appservice.GetGradeById(id);

            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }

        // POST: api/Grades
        [HttpPost]
        public IActionResult CreateGradeRecord([FromBody] DModels account)
        {
            if (account == null)
            {
                return BadRequest("Grade data is required.");
            }

            var newGrade = new DModels
            {
                StudentName = account.StudentName,
                SubjectName = account.SubjectName,
                Sw1 = account.Sw1,
                Sw2 = account.Sw2,
                Qz1 = account.Qz1,
                Qz2 = account.Qz2,
                Assign = account.Assign,
                Lab = account.Lab,
                Exam = account.Exam,
                MidtermGrade = account.MidtermGrade,
                FinalsGrade = account.FinalsGrade
            };

            var created = _appservice.Register(newGrade);

            if (!created)
            {
                return Conflict("Grade record could not be created.");
            }

            return Ok(new { student = newGrade.StudentName });
        }

        // PATCH: api/Grades/4
        [HttpPatch("{id:int}")]
        public IActionResult UpdateAccount(int id, [FromBody] DModels account)
        {
            // Fix: Added the missing condition check here
            if (account == null)
            {
                return BadRequest("Account data is required.");
            }

            var existingAccount = _appservice.GetGradeById(id);

            if (existingAccount == null)
            {
                return NotFound();
            }

            var updatedAccount = new DModels
            {
                S_ID = id,
                StudentName = account.StudentName ?? existingAccount.StudentName, 
                SubjectName = account.SubjectName ?? existingAccount.SubjectName,
                Sw1 = existingAccount.Sw1,
                Sw2 = existingAccount.Sw2,
                Qz1 = existingAccount.Qz1,
                Qz2 = existingAccount.Qz2,
                Assign = existingAccount.Assign,
                Lab = existingAccount.Lab,
                Exam = existingAccount.Exam,
                MidtermGrade = existingAccount.MidtermGrade,
                FinalsGrade = existingAccount.FinalsGrade
            };

            _appservice.UpdateUser(updatedAccount);

            return NoContent();
        }

        // DELETE: api/Grades/5
        [HttpDelete("{id:int}")]
        public IActionResult DeleteAccount(int id)
        {
            var existingAccount = _appservice.GetGradeById(id);

            if (existingAccount == null)
            {
                return NotFound();
            }

            _appservice.RemoveUser(id);
            return NoContent();
        }
    }
}