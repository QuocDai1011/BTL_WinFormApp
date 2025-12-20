using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.Interfaces;
using BaiTapLonWinForm.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public List<Student> getAllStudentByClassId(long classId)
        {
            List<Student> students = new List<Student>();
            students = _studentRepository.getAllStudentByClassId(classId);
            if (students != null && students.Count > 0) 
            {
                return students;
            }
            return null;
        }
    }
}
