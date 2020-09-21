using AssignmentSchool.ErrorLog;
using AssignmentSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentSchool.Data
{
    public class ClassRepository : IClassRepository
    {
        public DbSchoolEntities _context;
        public ClassRepository()
        {
            _context = new DbSchoolEntities();
        }

        public IEnumerable<VMClass> GetClassList()
        {

            try
            {
                var classList = _context.Classes.Select(x => new VMClass
                {
                    ClassId = x.ClassId,
                    ClassDescription = x.ClassDescription
                }).ToList();
                //throw new Exception("Test runtime exception");
                return classList;
                
            }
            catch (Exception exception)
            {
                LogTracker.Error(exception, "Class");
                throw exception;
            }
        }

        public IEnumerable<VMTimeTableForStudent> GetTimeTableByClassId(int classId)
        {
            try
            {
                var timeTableList = (from timeTableMapping in _context.TimeTableMappings
                                     join classes in _context.Classes on timeTableMapping.ClassId equals classes.ClassId
                                     join teacher in _context.Teachers on timeTableMapping.TeacherId equals teacher.TeacherId
                                     join subject in _context.Subjects on teacher.SubjectId equals subject.SubjectId
                                     join period in _context.PeriodTables on timeTableMapping.PeriodId equals period.PeriodId                                     
                                     where classes.ClassId == classId
                                     select new VMTimeTableForStudent
                                     {                                        
                                         ClassDescription = classes.ClassDescription,
                                         SubjectName = subject.SubjectName,
                                         TeacherName = teacher.TeacherName,
                                         Day = period.Day,
                                         Time = period.Time
                                     }).ToList();
                return timeTableList;
            }
            catch (Exception exception)
            {
                LogTracker.Error(exception,"Class");
                throw exception;
            }
        }
    }
}