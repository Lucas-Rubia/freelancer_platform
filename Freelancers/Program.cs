
using Freelancers.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddCustomServices(builder.Configuration) 
    .AddSwaggerDocumantation();


var app = builder.Build();

app.UseCustomSwagger(app.Environment)
    .UseHttpsRedirection()
    .UseAuthorization();

app.MapControllers();

app.Run();
