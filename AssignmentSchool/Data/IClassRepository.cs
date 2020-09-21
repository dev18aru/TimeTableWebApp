using AssignmentSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentSchool.Data
{
    public interface IClassRepository
    {
        IEnumerable<VMClass> GetClassList();
        IEnumerable<VMTimeTableForStudent> GetTimeTableByClassId(int classId);
    }
}
