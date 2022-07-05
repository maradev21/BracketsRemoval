using BracketsRemoval;
using BracketsRemoval.WebAPI.DTOs;
using NLog;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Logging.ClearProviders();
builder.Host.UseNLog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var logger = LogManager.GetCurrentClassLogger();

app.MapPost("/bracketsRemoval", (Request request) =>
{
    try
    {
        logger.Trace("Received request: {@Request}", request);
        string result = BracketsService.RemoveExternalBrackets(request.DirtyText);
        var response = new Response(request, result);
        logger.Trace("Returned response: {@Response}", response);
        return response;
    }
    catch (PathologicalBracketsException ex)
    {
        var response = new Response(request, ex);
        logger.Trace("Returned pathological response: {@Response}", response);
        return response;
    }
});

app.Run();