using TodoAPI.Interface;
using TodoAPI.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ITodoService, TodoService>();
builder.Services.AddCors(options =>  
    {  
      
    options.AddDefaultPolicy(  
        policy =>  
        {  
            policy.WithOrigins("http://localhost:3000")  
                .AllowAnyHeader()  
                .AllowAnyMethod();  
        });  
});  


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
