using TodoList.Data;
using TodoList.Routes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<TodoContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.TodoRoutes();

app.Lifetime.ApplicationStopping.Register(() =>
{
    Console.WriteLine("Encerrando a aplicação...");
});

app.UseHttpsRedirection();
app.Run();
