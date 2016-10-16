using Interview.WebApp.Data;
using Interview.WebApp.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Interview.WebApp.Controllers
{
    [Route("api/[controller]")]
    public class TodoController
    {
        private readonly TodoContext _todoContext;

        public TodoController()
        {
            _todoContext = new TodoContext();
        }

        [HttpPost]
        public Todo Create([FromBody] Todo todo)
        {
            _todoContext.Todos.Add(todo);
            _todoContext.SaveChanges();
            return todo;
        }

        [HttpGet("{id}")]
        public Todo GetById(int id)
        {
            foreach (var todo in _todoContext.Todos)
            {
                if (todo.TodoId == id)
                {
                    return todo;
                }
            }
            return null;
        }

        [HttpGet]
        public ICollection<Todo> GetAll() {
            return _todoContext.Todos.ToList();
        }

        [HttpGet("completed")]
        public ICollection<Todo> GetAllCompleted()
        {
            var completed = new List<Todo>();
            foreach (var todo in _todoContext.Todos)
            {
                if (todo.Completed)
                {
                    completed.Add(todo);
                }
            }
            return completed;
        }

        [HttpGet("overdue")]
        public ICollection<Todo> GetAllOverdue()
        {
            var overdue = new List<Todo>();
            foreach (var todo in _todoContext.Todos)
            {
                if (todo.DueDate < DateTime.Now)
                {
                    overdue.Add(todo);
                }
            }
            return overdue;
        }

        [HttpPut]
        public Todo Update([FromBody] Todo todo)
        {
            _todoContext.Todos.Update(todo);
            _todoContext.SaveChanges();
            return todo;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Todo todo = GetById(id);
            if (todo != null)
            {
                _todoContext.Todos.Remove(todo);
                _todoContext.SaveChanges();
            }
        }
    }
}