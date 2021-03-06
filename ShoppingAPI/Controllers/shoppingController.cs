using Microsoft.AspNetCore.Mvc;
using ShoppingAPI.Models;
using ShoppingAPI.Services;

namespace ShoppingAPI.Controllers
{
    [ApiController]

    [Route("[controller]")]//URL: http://localhost:5066/todo

    public class shoppingController : ControllerBase

    {

        private readonly ICrudService<shoppingItem, int> _todoService;

        public shoppingController(ICrudService<shoppingItem, int> todoService)

        {

            _todoService = todoService;

        }

        // GET all action

        [HttpGet] // auto returns data with a Content-Type of application/json

        public ActionResult<List<shoppingItem>> GetAll() => _todoService.GetAll().ToList();

        // GET by Id action

        [HttpGet("{id}")]

        public ActionResult<shoppingItem> Get(int id)

        {

            var todo = _todoService.Get(id);

            if (todo is null) return NotFound();

            else return todo;

        }

        // POST action

        [HttpPost]

        public IActionResult Create(shoppingItem todo)

        {

            // Runs validation against model using data validation attributes

            if (ModelState.IsValid)

            {

                _todoService.Add(todo);

                return CreatedAtAction(nameof(Create), new { id = todo.Id }, todo);

            }

            return BadRequest();

        }

        // PUT action

        [HttpPut("{id}")]

        public IActionResult Update(int id, shoppingItem todo)

        {

            var existingTodoItem = _todoService.Get(id);

            if (existingTodoItem is null || existingTodoItem.Id != id)

            {

                return BadRequest();

            }

            if (ModelState.IsValid)

            {

                _todoService.Update(existingTodoItem, todo);

                return NoContent();

            }

            return BadRequest();

        }

        // DELETE action

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)

        {

            var todo = _todoService.Get(id);

            if (todo is null) return NotFound();

            _todoService.Delete(id);

            return NoContent();

        }
        [HttpGet]
        [Route("info")]
        public ActionResult<List<string>> GetInfo()
        {
            return ((shoppingService)_todoService).GetJoinedData().ToList();
        }

    }
}
