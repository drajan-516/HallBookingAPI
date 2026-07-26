using System.Reflection;
using HallBookingAPI.Persistence;
using HallBookingAPI.Persistence.Repositories;
using HallBookingAPI.Persistence.Repositories.IRepositories;
using HallBookingAPI.Exceptions;
using HallBookingAPI.UseCases.Bookings;
using HallBookingAPI.UseCases.Halls;
using HallBookingAPI.UseCases.Reports;
using HallBookingAPI.UseCases.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IHallRepository, HallRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();

builder.Services.AddScoped<GetRevenueByHall>();
builder.Services.AddScoped<CreateHall>();
builder.Services.AddScoped<UpdateHall>();
builder.Services.AddScoped<DeleteHall>();
builder.Services.AddScoped<SearchAvailableHalls>();
builder.Services.AddScoped<CreateBooking>();
builder.Services.AddScoped<CreateService>();


builder.Services.AddDbContext<HallDbContext>(options =>
    options.UseSqlite("Data Source=bookings.db"));

builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<HallDbContext>();
    context.Database.Migrate();
    HallDbSeeder.Seed(context);
}

app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI();

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var exceptionFeature = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>();
        var exception = exceptionFeature?.Error;

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = exception switch
        {
            NotFoundException => StatusCodes.Status404NotFound,
            ValidationException => StatusCodes.Status400BadRequest,
            InvalidOperationException => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError
        };

        await context.Response.WriteAsJsonAsync(new { error = exception?.Message });
    });
});

app.UseAuthorization();
app.MapControllers();

app.Run();

app.UseAuthorization();
app.MapControllers();

app.Run();