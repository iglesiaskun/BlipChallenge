using ChallengeAPI.Repositories;
using ChallengeAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<IGitHubRepository, GitHubRepository>(client =>
{
    client.DefaultRequestHeaders.UserAgent.ParseAdd("ChallengeAPI");
    client.BaseAddress = new Uri("https://api.github.com/");
});

builder.Services.AddScoped<IRepositoryService, RepositoryService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

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