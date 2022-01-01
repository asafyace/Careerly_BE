using Careerly.Models;
using Careerly.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:8080/",
                                                    "http://10.61.50.2:8080/",
                                                  "http://localhost:8080",
                                              "https://localhost:5001/swagger/index.html",
                                              "https://localhost:44316/swagger/index.html",
                                              "https://localhost:7050/swagger/index.html",
                                              "http://localhost:7050/swagger/index.html",
                                              "https://localhost")
                                             .AllowAnyHeader()
                                             .AllowAnyMethod();
                          ;

                      });
});


//Add Scopes
builder.Services.AddScoped<IExperienceRepository, ExperienceRepository>();
builder.Services.AddScoped<IAwardRepository, AwardRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IEducationRepository, EducationRepository>();

//Add DB connection
builder.Services.AddDbContext<ModelsContext>(options =>options.UseSqlServer("Server=127.0.0.1,1433;Database=Careerly;User Id=SA;Password=Password!1;MultipleActiveResultSets=true"));

//Add all controllers API
builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Careerly", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseSwagger();

app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Careerly API v1"));


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapRazorPages();

app.Run();