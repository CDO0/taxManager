var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();  
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Enable CORS to allow frontend access
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorFrontend",
        policy => policy.WithOrigins("http://localhost:5196") 
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();

// Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowBlazorFrontend");  

app.UseAuthorization();
app.MapControllers();  

app.Run();
