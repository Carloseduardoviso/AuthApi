using AuthApi.Helpers;
using Helpers.Extensions;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var tokenKey = configuration["Token:Key"];
var tokenIssuer = configuration["Token:Issuer"];
var tokenAudience = configuration["Token:Audience"];


builder.Services.AddControllers();
builder.Services.AddDbContext(builder.Configuration.GetConnectionString("AuthDb"));
builder.Services.AddAutoMapper();
builder.Services.AddScopeds();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
builder.Services.AddAuth(tokenKey, tokenIssuer, tokenAudience);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
