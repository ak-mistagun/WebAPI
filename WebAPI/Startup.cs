using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WebAPI.Database;
using WebAPI.Mappings;
using WebAPI.Repositories;
using WebAPI.Repositories.Impl;
using WebAPI.Services;
using WebAPI.Services.Impl;
using WebAPI.Untils;

namespace WebAPI
{
    public class Startup
    {
	    private const string MsSqlConnectionString = nameof(MsSqlConnectionString);
		
		public Startup(IConfiguration cfg)
		{
			Cfg = cfg;
		}

		public IConfiguration Cfg { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			// Mapping profile cfg.
			services.AddSingleton(new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()))
				.CreateMapper());

			if (Cfg.IsInMemoryDatabase())
			{
				services.AddDbContext<WebApiDbContext>(options => options.UseInMemoryDatabase("InMemoryDatabase"));
			}
			else
			{
				services.AddDbContext<WebApiDbContext>(options =>
					options.UseSqlServer(Cfg.GetConnectionString(MsSqlConnectionString)));
			}

			// Angular
			if (Cfg.IsAngularActive())
				services.AddSpaStaticFiles(cfg => cfg.RootPath = "wwwroot");
			
			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
			});
			
			// Repositories registers.
			services.AddScoped<IFeedbackRepository, FeedbackRepository>();
			services.AddScoped<ITopicRepository, TopicRepository>();
			services.AddScoped<IMessageRepository, MessageRepository>();
			services.AddScoped<IContactRepository, ContactRepository>();

			// Services registers.
			services.AddScoped<IFeedbackService, FeedbackService>();
			services.AddScoped<IContactService, ContactService>();
			services.AddScoped<ITopicService, TopicService>();
			services.AddScoped<IMessageService, MessageService>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
			}

			// Angular
			if (Cfg.IsAngularActive())
			{
				app.UseDefaultFiles();
				app.UseStaticFiles();
				app.UseSpaStaticFiles();
			}

			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseAuthorization();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
			
			// Angular
			if (Cfg.IsAngularActive())
			{
				app.UseSpa(spa =>
				{
					spa.Options.SourcePath = "ClientApp";
					if (env.IsDevelopment()) spa.UseAngularCliServer("start"); 
				});
			}
		}
	}
}
