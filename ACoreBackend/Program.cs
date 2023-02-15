using ACoreBackend.Models;
using ACoreBackend.Repositories;
using Microsoft.OpenApi.Models;

namespace ACoreBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(swaggerGenOptions =>
            {
                swaggerGenOptions.SwaggerDoc(name: "v1", info: new OpenApiInfo { Title = "Asp.Net Core API", Version = "v1" });
            });

            var app = builder.Build();
            app.UseSwagger();
            app.UseSwaggerUI(swaggerUiOptions =>
            {
                swaggerUiOptions.DocumentTitle = "Testa Anställda API";
                swaggerUiOptions.SwaggerEndpoint("/swagger/v1/swagger.json", name: "RN Api ger dig en enkel testmiljö över anställda.");
                swaggerUiOptions.RoutePrefix = string.Empty;

            });

            app.UseHttpsRedirection();
            //******************************************************************************************
            app.MapGet("/get-all-students", async () => await StudentRepository.GetStudentAsync())
                .WithTags("Students Endpoint");
            //*****************************************************************************************
            app.MapGet(pattern: "/get-student-by-id/{studentId}", handler: async (int studentId) =>
            {
                Student studentToReturn = await StudentRepository.GetStudentByIdAsync(studentId);
                if (studentToReturn != null)
                {
                    return Results.Ok(value: studentToReturn);
                }
                else
                {
                    return Results.BadRequest();
                }
            }).WithTags("Students Endpoint");
            //*********************************************************************************************
            app.MapPost(pattern: "/create-student", handler: async (Student studentToCreate) =>
            {
                bool createSuccessful = await StudentRepository.CreateStudentAsync(studentToCreate);
                if (createSuccessful)
                {
                    return Results.Ok(value: "Create successful");
                }
                else
                {
                    return Results.BadRequest();
                }
            }).WithTags("Students Endpoint");
            //*********************************************************************************************
            app.MapPut(pattern: "/update-student", handler: async (Student studentToUpdate) =>
            {
                bool updateSuccessful = await StudentRepository.UpdateStudentAsync(studentToUpdate);
                if (updateSuccessful)
                {
                    return Results.Ok(value: "Update successful");
                }
                else
                {
                    return Results.BadRequest();
                }
            }).WithTags("Students Endpoint");
            //*********************************************************************************************
            app.MapDelete(pattern: "/delete-student-by-id/{studentId}", handler: async (int studentId) =>
            {
                bool deleteSuccessful = await StudentRepository.DeleteStudentAsync(studentId);
                if (deleteSuccessful)
                {
                    return Results.Ok(value: "Delete was successful");
                }
                else
                {
                    return Results.BadRequest();
                }
            }).WithTags("Students Endpoint");
            //*********************************************************************************************
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.Run();
        }
    }
}