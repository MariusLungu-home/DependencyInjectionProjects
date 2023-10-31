using DIDemoLib;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IMessages, Messages>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Define the Messages endpoint
app.MapGet("/api/Messages/SayHello", (IMessages messagesService) =>
{
    // Your logic to get messages here.
    // For example, it could be something like this:
    return messagesService.SayHello();
});


// Define the Messages endpoint
app.MapGet("/api/Messages/SayGoodbye", (IMessages messagesService) =>
{
    // Your logic to get messages here.
    // For example, it could be something like this:
    return messagesService.SayGoodbye();
});

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    options.RoutePrefix = string.Empty; // To serve the Swagger UI at the application's root (e.g., at http://localhost:5000/)
    options.DocumentTitle = "My API - Messages";
    options.DefaultModelsExpandDepth(-1); // Disable schemas section
    options.DefaultModelExpandDepth(1);
    options.DefaultModelRendering(Swashbuckle.AspNetCore.SwaggerUI.ModelRendering.Model);
    options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
});

app.Run();