using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OfferStoreDbContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(OfferStoreDbContext)));
    });

builder.Services.AddScoped<IOffersService, OffersService>();
builder.Services.AddScoped<ISuppliersService, SuppliersService>();
builder.Services.AddScoped<IOffersRepository, OffersRepository>();
builder.Services.AddScoped<ISuppliersRepository, SuppliersRepository>();

var app = builder.Build();

app.UseExceptionsHandling();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<OfferStoreDbContext>();
    Thread.Sleep(5000);
    dbContext.Database.Migrate();
}

//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.MapControllers();
 
app.Run();
