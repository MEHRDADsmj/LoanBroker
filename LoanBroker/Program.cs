var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IBankProviderFactory.IBankProviderFactory, BankProviderFactory.BankProviderFactory>();
builder.Services.AddControllers();

var app = builder.Build();
app.UseRouting();
app.MapControllers();
app.MapGet("/", () =>
{
    return "Hello World";
});

app.Run();
