var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOutputCache(opt =>
{
    opt.DefaultExpirationTimeSpan = TimeSpan.FromSeconds(30);
    opt.AddPolicy("MasterData", builder => builder.Expire(TimeSpan.FromSeconds(10)));
    opt.AddPolicy("Reports", builder => builder.Expire(TimeSpan.FromSeconds(60)));
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseOutputCache();
app.MapControllers();
app.Run();
