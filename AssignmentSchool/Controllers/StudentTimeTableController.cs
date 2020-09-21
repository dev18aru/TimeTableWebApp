using AssignmentSchool.Data;
using AssignmentSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AssignmentSchool.Controllers
{
    public class StudentTimeTableController : ApiController
    {
        private IClassRepository _repo;

        public StudentTimeTableController(IClassRepository repo)
        {
            _repo = repo;
        }

        //POST api/studentTimeTable/1  
        [HttpPost]
        public IEnumerable<VMTimeTableForStudent> GetTimeTableForStudent(int id)
        {
            var timeTableList = _repo.GetTimeTableByClassId(id);
            if (timeTableList == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return timeTableList;
        }
    }
}
