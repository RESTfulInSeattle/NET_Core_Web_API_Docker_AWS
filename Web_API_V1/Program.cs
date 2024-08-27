using Web_API_V1.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/*Experimenting with basic Middleware
app.Use(async (ctx, next) =>
{
    var start = DateTime.UtcNow;
    //Pass the context
    await next.Invoke(ctx);
    app.Logger.LogInformation($"Request {ctx.Request.Path}: {(DateTime.UtcNow - start).TotalMilliseconds} ms");
});


app.Use((HttpContext ctx, Func<Task> next) =>
{
    app.Logger.LogInformation("Terminating the Request");
    return Task.CompletedTask;
});

app.UseMiddleware<TimingMiddleware>();
*/

app.UseTimingMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
