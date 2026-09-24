using FootballResultsWeb.Services;
using Microsoft.Azure.Cosmos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();

// Football match results are stored in Azure Cosmos DB. When no connection
// string is configured (e.g. local development or tests), fall back to an
// in-memory repository so the app still runs without provisioning Cosmos DB.
builder.Services.Configure<CosmosDbOptions>(builder.Configuration.GetSection(CosmosDbOptions.SectionName));
var cosmosDbOptions = builder.Configuration.GetSection(CosmosDbOptions.SectionName).Get<CosmosDbOptions>() ?? new CosmosDbOptions();

if (!string.IsNullOrWhiteSpace(cosmosDbOptions.ConnectionString))
{
    var cosmosClientOptions = new CosmosClientOptions
    {
        UseSystemTextJsonSerializerWithOptions = new System.Text.Json.JsonSerializerOptions()
    };
    builder.Services.AddSingleton(new CosmosClient(cosmosDbOptions.ConnectionString, cosmosClientOptions));
    builder.Services.AddSingleton<IFootballMatchRepository, CosmosDbFootballMatchRepository>();
}
else
{
    builder.Services.AddSingleton<IFootballMatchRepository, InMemoryFootballMatchRepository>();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapControllers();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
