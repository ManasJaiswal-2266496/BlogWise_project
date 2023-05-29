using BlogWise_project.DataAccessLayer.Data;
using BlogWise_project.PostMicroservice.DataAccessLayer.Repository;
using BlogWise_project.PostMicroservice.Services;
using Microsoft.EntityFrameworkCore;
using UserMicroservice.BusinessLayer.Services;
using UserMicroservice.DataAccessLayer.Data;
using UserMicroservice.DataAccessLayer.Repository;
using VoteMicroservice.BusinessLayer.Services;
using VoteMicroservice.DataAccessLayer.Data;
using VoteMicroservice.DataAccessLayer.Repository;

namespace BlogWise_project
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Configure the DbContext
            services.AddDbContext<BlogWiseDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<UserMicroserviceDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddDbContext<VoteMicroserviceDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            // Register the repository and service
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IPostService, PostService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IVoteRepository, VoteRepository>();
            services.AddScoped<IVoteService, VoteService>();

            // Add other services and configurations

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
