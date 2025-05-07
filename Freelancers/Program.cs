
using Freelancers.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddCustomServices(builder.Configuration) 
    .AddSwaggerDocumantation()
    .AddUseCors();


var app = builder.Build();

app.UseCors("AllowAll");

app.UseCustomSwagger(app.Environment)
    .UseHttpsRedirection()
    .UseAuthorization();

app.MapControllers();

app.Run();
