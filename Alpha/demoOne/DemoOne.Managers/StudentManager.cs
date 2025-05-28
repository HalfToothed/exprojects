using DemoOne.Datalayer.Repositories;
using DemoOne.Dto.Project;
using DemoOne.Entities;
using DemoOne.Factories;
using DemoOne.Models;

namespace DemoOne.Managers
{
    public class StudentManager
    {
        private readonly StudentRepository _studentRepository;
        private readonly string _userId;
        public StudentManager(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
            _userId = String.Empty;
        }

        public Student Add(AddStudentModel model)
        {
            var entity = StudentFactory.Create(model);
            _studentRepository.Add(entity);
            return entity;
        }

        public Student Edit(EditStudentModel model)
        {
             var entity = _studentRepository.Get(model.Id);
             StudentFactory.Update(model,entity,_userId);
             _studentRepository.Edit(entity);
               return entity;
        }

        public List<StudentDto> FilterWithText(string s, int x, int y)
        {
            return _studentRepository.FilterText(s, x, y);
        }
        public List<StudentDto> GetFilter(int x, int y)
        {
            return _studentRepository.GetFilter(x, y);
        }
        public List<StudentDto> GetList(int x, int y)
        {
            return _studentRepository.GetList(x, y);
        }

        public StudentDto Getid(int id)
        {
            return _studentRepository.Getid(id);
        }


        public void Delete(int id)
        {
           _studentRepository.Delete(id);
        }

        public void Toggle(int id)
        {
            _studentRepository.Toggle(id);
        }
    }
}