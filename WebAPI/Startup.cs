using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WebAPI.Mappings;
using WebAPI.Repositories;
using WebAPI.Repositories.Impl;
using WebAPI.Services;
using WebAPI.Services.Impl;
using WebDbContext = WebAPI.Database.DbContext;

namespace WebAPI
{
    public class Startup
    {
	    private const string MsSqlConnectionString = nameof(MsSqlConnectionString);
	    private const string IsInMemoryDatabase = nameof(IsInMemoryDatabase);
	    private const string IsAngularActive = nameof(IsAngularActive);
		
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

			if (Cfg.GetValue<bool>(IsInMemoryDatabase))
			{
				services.AddDbContext<WebDbContext>(options => options.UseInMemoryDatabase("InMemoryDatabase"));
			}
			else
			{
				services.AddDbContext<WebDbContext>(options =>
					options.UseSqlServer(Cfg.GetConnectionString(MsSqlConnectionString)));
			}

			// Angular
			if (Cfg.GetValue<bool>(IsAngularActive))
				services.AddSpaStaticFiles(cfg => cfg.RootPath = "ClientApp/dist");
			
			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
			});
			
			// Repositories registers.
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
			else
			{
				app.UseExceptionHandler("/error");
			}

			// Angular
			if (Cfg.GetValue<bool>(IsAngularActive))
			{
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
			if (Cfg.GetValue<bool>(IsAngularActive))
			{
				app.UseSpa(spa =>
				{
					spa.Options.SourcePath = "ClientApp";
					spa.UseAngularCliServer("start"); 
				});
			}
		}
	}
}
