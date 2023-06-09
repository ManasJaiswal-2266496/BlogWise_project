﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using BlogWise_project.PostMicroservice.DataAccessLayer.Repository;
using BlogWise_project.PostMicroservice.Services;
using BlogWise_project.DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using UserMicroservice.DataAccessLayer.Data;
using VoteMicroservice.DataAccessLayer.Data;
using UserMicroservice.DataAccessLayer.Repository;
using UserMicroservice.BusinessLayer.Services;
using VoteMicroservice.DataAccessLayer.Repository;
using VoteMicroservice.BusinessLayer.Services;

namespace BlogWise_project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BlogWise API", Version = "v1" });
            });

            builder.Services.AddDbContext<BlogWiseDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IPostRepository, PostRepository>();
            builder.Services.AddScoped<IPostService, PostService>();

            builder.Services.AddDbContext<UserMicroserviceDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddDbContext<VoteMicroserviceDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IVoteRepository, VoteRepository>();
            builder.Services.AddScoped<IVoteService, VoteService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BlogWise API v1");
                });
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
