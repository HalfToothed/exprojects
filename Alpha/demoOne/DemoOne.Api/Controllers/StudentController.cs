using DemoOne.Dto.Project;
using DemoOne.Entities;
using DemoOne.Managers;
using DemoOne.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace DemoOne.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {

        private readonly StudentManager _manager;

        public StudentController(StudentManager manager)
        {
            _manager = manager;
        }

        [HttpPost]
        public IActionResult Add([FromBody] AddStudentModel model)
        {
            var entity = _manager.Add(model);
            return Ok(entity);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] EditStudentModel model)
        {
            return Ok(_manager.Edit(model));
        }

        [HttpGet]
        public IActionResult FilterWithText(string text,int skip, int print)
        {
            return Ok(_manager.FilterWithText(text,skip, print));
        }

        [HttpGet]
        [Route("{skip},{print}")]

        public IActionResult GetFilter(int skip, int print)
        {
            return Ok(_manager.GetFilter(skip, print));
        }


        [HttpGet]
        [Route("{ID_1},{ID_2}")]
        public IActionResult GetList(int ID_1, int ID_2)
        {
            return Ok(_manager.GetList(ID_1, ID_2));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var entity = _manager.Getid(id);
            return Ok(entity);
        }

        [HttpDelete()]
        [Route("{id}")]

        public IActionResult Delete(int id)
        {
            _manager.Delete(id);
            return Ok(id);
           
        }

        [HttpPost("Toggle/{id}")]
        public IActionResult Toggle(int id)
        {
            _manager.Toggle(id);
            return Ok(id);
        }



    }
       



    
}