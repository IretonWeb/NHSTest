using NHSTest.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using NHSTest.Application.Command.Staff;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseContext")));

// Add services to the container.
builder.Services.AddScoped<IDataContext>(p => p.GetService<DataContext>());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly((typeof(AddStaffMemberCommand).Assembly)));
builder.Services.AddSwaggerGen(config =>
{
    //some swagger configuration code.

    //use fully qualified object names
    config.CustomSchemaIds(x => x.FullName);
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost", "http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyHeader()
                .AllowAnyHeader()
                .AllowCredentials();


        });
});

var app = builder.Build();
app.UseCors(MyAllowSpecificOrigins);


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
