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
    public class ClassController : ApiController
    {
        private IClassRepository _repo;
        public ClassController(IClassRepository repo)
        {
            _repo = repo;
        }

        //GET api/class
        public IEnumerable<VMClass> GetClasss()
        {
            var classList = _repo.GetClassList();
            return classList;
        }
    }
}
