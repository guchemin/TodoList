using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using TodoList.Models;

namespace TodoList.Routes;

public static class TodoRoute
{
    public static void TodoRoutes(this WebApplication app)
    {
        var route = app.MapGroup("todo");
        route.MapPost("", 
            async (TodoRequest req, TodoContext context) => 
            {
                var todo = new TodoModel(req.title);
                await context.AddAsync(todo);
                await context.SaveChangesAsync();
            });

        route.MapGet("", 
            async (TodoContext context) => 
            {
                // Filtra as tarefas que não têm o título "Atividade Deletada"
                var todos = await context.Todos
                    .Where(todo => todo.Title != "Atividade Deletada")
                    .ToListAsync();

                return Results.Ok(todos);
            });


        route.MapPut("{id:int}", 
            async (int id, TodoRequestUpdate req, TodoContext context) => 
            {
                var todo = await context.Todos.FirstOrDefaultAsync(x => x.Id == id);
                
                if (todo == null)
                    return Results.NotFound();
                    
                todo.ChangeIsCompleted(req.isCompleted);
                await context.SaveChangesAsync();

                return Results.Ok(todo);
            });

        route.MapDelete("{id:int}",
            async (int id, TodoContext context) => 
            {
                var todo = await context.Todos.FirstOrDefaultAsync(x => x.Id == id);
                
                if (todo == null)
                    return Results.NotFound();

                todo.SetInactive();
                await context.SaveChangesAsync();

                return Results.Ok(todo);
            });
            
    }
}