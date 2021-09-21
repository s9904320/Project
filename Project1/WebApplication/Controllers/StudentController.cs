using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DB_Context;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        //讀取資料庫指定的資料表資訊
        private readonly DB_Student DB_Student_context;


        public StudentController(DB_Student context_dB_Student)
        {
            DB_Student_context = context_dB_Student;
        }

        [HttpGet("StudentInfo/sex/{sex}")]
        public IEnumerable<StudentInfoT> SearchSex(bool sex)
        {
            var SearchSex_sex = new SqlParameter("@sex", sex); //給參數
            
            string SearchSex_sql = "select * from [stundent] where sex = @sex"; //sql語法 避免sql injection 用SqlParameter帶入

            var result = DB_Student_context.StudentInfo.FromSqlRaw(SearchSex_sql, SearchSex_sex).ToList();
            return result;
        }

        [HttpPost("StudentInfo/post")]
        public IEnumerable<StudentInfoT> Add_StudentInfo([FromBody] StudentInfoT value)
        {
            DB_Student_context.StudentInfo.Add(value);
            DB_Student_context.SaveChanges();
            return DB_Student_context.StudentInfo.Where(a => a.recno == value.recno).ToList();
        }

        [HttpPut("StudentInfo/Update/{recno}")]
        public IActionResult PutUpdateStudentInfo(string recno, [FromBody] StudentInfoT value)
        {
            if (int.Parse(recno) != value.recno)
            {
                return BadRequest();
            }
            DB_Student_context.Entry(value).State = EntityState.Modified;
            DB_Student_context.SaveChanges();

            return NoContent();
        }

    }
}
