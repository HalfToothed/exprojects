using DemoOne.Entities;
using DemoOne.Models;

namespace DemoOne.Factories
{
    public class StudentFactory
    {
        public static Student Create(AddStudentModel model)
        {
            return new Student
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Status = model.Status,
                State = model.State

        };
        }

        public static void Create(Student entity, AddStudentModel model)
        {
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.Email = model.Email;
            entity.PhoneNumber = model.PhoneNumber;
            entity.Status = model.Status;
            entity.State = model.State;
        }

        public static void Update(EditStudentModel model,Student entity , string _userId)
        {   
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.Email = model.Email;
            entity.PhoneNumber = model.PhoneNumber;
            entity.Status = model.Status;
            entity.State = model.State;
        }
    }
}