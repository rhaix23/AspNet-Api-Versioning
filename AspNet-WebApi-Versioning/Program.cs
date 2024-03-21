using Asp.Versioning;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(2); // default version
    options.ReportApiVersions = true; // report supported versions
    options.AssumeDefaultVersionWhenUnspecified = true; // assume default version when not specified
    options.ApiVersionReader = new UrlSegmentApiVersionReader(); // url segment versioning e.g., /api/v1.0/Values
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'V"; // format for versioning
    options.SubstituteApiVersionInUrl = true; // substitute version in url
});

var app = builder.Build();

app.MapControllers();

app.Run();