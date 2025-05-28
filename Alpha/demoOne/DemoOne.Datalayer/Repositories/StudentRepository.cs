using DemoOne.Entities;
using Microsoft.EntityFrameworkCore;
using DemoOne.Dto.Project;
using System.Security.Cryptography;
using System.Collections.Generic;

namespace DemoOne.Datalayer.Repositories
{
    public class StudentRepository
    {
        private readonly DataContext _dataContext;

        public StudentRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(Student entity)
        {
            _dataContext.Students.Add(entity);
            _dataContext.SaveChanges();
        }

        public void Edit(Student entity)
        {
            _dataContext.Students.Update(entity);
            _dataContext.SaveChanges();
        }

        public Student Get(int id)
        {
            return _dataContext.Students.Single(x => x.Id == id);
        }

        public void Toggle(int id)
        {
            var student = _dataContext.Students.Find(id);

            if (student.State == Utilities.Constants.RecordStatus.Inactive)
            {
                student.State = Utilities.Constants.RecordStatus.Active;
            }
            else
            {
                student.State = Utilities.Constants.RecordStatus.Inactive;
            }

            _dataContext.Students.Update(student);
            _dataContext.SaveChanges();
           

        }

        public StudentDto Getid(int id)
        {
            return (from x in _dataContext.Students
                    where x.Id == id
                    select new StudentDto
                    {
                        Id = x.Id,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Email = x.Email,
                        PhoneNumber = x.PhoneNumber,
                        Status = x.Status,
                        State = x.State,
                    })
                        .SingleOrDefault();
        }

        public List<StudentDto> GetList(int n, int m)
        {
          return    (from x in _dataContext.Students
                    where x.Id > n && x.Id < m
                    select new StudentDto
                    {
                        Id = x.Id,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Email = x.Email,
                        PhoneNumber = x.PhoneNumber,
                        Status = x.Status,
                        State = x.State,
                    }).ToList();
        }

        public List<StudentDto> FilterText(string s, int n, int m)
        {
            return  (from x in _dataContext.Students
                    where x.FirstName.Contains(s)
                    select new StudentDto
                    {
                        Id = x.Id,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Email = x.Email,
                        PhoneNumber = x.PhoneNumber,
                        Status = x.Status,
                        State = x.State,
                    }
                    ).Skip(n).Take(m).ToList();
        }

        public List<StudentDto> GetFilter(int n, int m)
        {

             return (from x in _dataContext.Students
                     select new StudentDto
                    {
                        Id = x.Id,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Email = x.Email,
                        PhoneNumber = x.PhoneNumber,
                        Status = x.Status,
                        State = x.State,
                    }).Skip(n).Take(m).ToList();
        }

        public void Delete(int id)
        {
            var entity = _dataContext.Students.Find(id);
           _dataContext.Students.Remove(entity);
            _dataContext.SaveChanges();
        }
    }
}
