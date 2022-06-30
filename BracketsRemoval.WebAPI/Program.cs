using BracketsRemoval;
using BracketsRemoval.WebAPI.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

app.UseHttpsRedirection();

app.MapPost("/bracketsRemoval", (Request request) =>
{
    try
    {
        string result = BracketsService.RemoveExternalBrackets(request.OriginalText);
        var response = new Response
        {
            FixedText = result,
            Request = request,
            ErrorMessage = string.Empty
        };
        return response;
    }
    catch (Exception ex)
    {
        return new Response
        {
            FixedText = string.Empty,
            Request = request,
            ErrorMessage = ex.Message
        };
    }

});

app.Run();