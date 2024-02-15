using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleTodoApi.Models;

[ApiController]
[Route("[controller]")]

public class TodoController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public TodoController (ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetTodo()
    {
        var todo =await _dbContext.Items.ToListAsync();
        return Ok(todo); 
    }

    [HttpGet("{id}")]
        public ActionResult<TodoItem> Get(int id)
        {
            var user = _dbContext.Items.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

    [HttpPost]
    public async Task<IActionResult> AddTodo(TodoItem item)
    {
        _dbContext.Items.Add(item);
        await _dbContext.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
    }

    [HttpPut("{id}")]
    public ActionResult<TodoItem> Put(int id, TodoItem updatedTodo)
    {
        var todo = _dbContext.Items.Find(id);
        if (todo == null)
        {
            return NotFound();
        }

        todo.Title = updatedTodo.Title;
        todo.IsDone = updatedTodo.IsDone;

        _dbContext.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult<TodoItem> Delete(int id)
    {
        var user = _dbContext.Items.Find(id);
        if(user == null)
        {
            return NotFound();
        }
        _dbContext.Items.Remove(user);
        _dbContext.SaveChanges();
        return NoContent();
    }

}