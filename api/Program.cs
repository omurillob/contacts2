using contacts2.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<ContactService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.UseAuthorization();

app.MapControllers();

app.UseCors(builder =>
{
    builder.WithOrigins("http://localhost:60871")
           .AllowAnyMethod()
           .AllowAnyHeader();
});

app.Run();