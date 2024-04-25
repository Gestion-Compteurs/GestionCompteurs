var builder = WebApplication.CreateBuilder(args);

var iServiceCollection = builder.Services;
// Add services to the container.

iServiceCollection.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
iServiceCollection.AddEndpointsApiExplorer();
iServiceCollection.AddSwaggerGen();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();