using Costvel.Api.Extensions;
using Costvel.Business.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
                .DisallowCredentials()
                .SetPreflightMaxAge(TimeSpan.FromDays(1));
        });
});
builder.Services.AddControllers();
builder.Services.ConfigureDatabase();
builder.Services.ConfigureBusiness();

var app = builder.Build();

await app.UseMigration();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors();
app.MapControllers();

app.Run();