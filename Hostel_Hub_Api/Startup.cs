using AutoMapper;
using Hostel_App.Automapper;
using Hostel_Hub_Api.Models;
using Hostel_Hub_Api.Repositories.Base;
using Hostel_Hub_Api.Repositories.FileStoreRepository;
using Hostel_Hub_Api.Repositories.HostelPhotoRepository;
using Hostel_Hub_Api.Repositories.HostelRatingRepository;
using Hostel_Hub_Api.Repositories.HostelRepository;
using Hostel_Hub_Api.Repositories.HostelReviewRepository;
using Hostel_Hub_Api.Repositories.HostelRoomRepository;
using Hostel_Hub_Api.Repositories.RoomPhotoRepository;
using Hostel_Hub_Api.Repositories.RoomRepository;
using Hostel_Hub_Api.Services.FileStoreService;
using Hostel_Hub_Api.Services.HostelRatingService;
using Hostel_Hub_Api.Services.HostelReviewService;
using Hostel_Hub_Api.Services.HostelRoomService;
using Hostel_Hub_Api.Services.HostelService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Hostel_Hub_Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutomapperProfile());
            });

            services.AddScoped<DbContext>(sp => sp.GetService<Hostel_HubContext>());
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddDbContext<Hostel_HubContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //Repository Scops
            services.AddScoped<IHostelRepository, HostelRepository>();

            services.AddScoped<IHostelPhotoRepository, HostelPhotoRepository>();

            services.AddScoped<IHostelRatingRepository, HostelRatingRepository>();

            services.AddScoped<IHostelReviewRepository, HostelReviewRepository>();

            services.AddScoped<IHostelRoomRepository, HostelRoomRepository>();

            services.AddScoped<IRoomPhotoRepository, RoomPhotoRepository>();

            services.AddScoped<IRoomRepository, RoomRepository>();

            services.AddScoped<IFileStoreRepository, FileStoreRepository>();


            //Service Scops
            services.AddScoped<IHostelService, HostelService>();

            services.AddScoped<IHostelPhotoService, HostelPhotoService>();

            services.AddScoped<IHostelRatingService, HostelRatingService>();

            services.AddScoped<IHostelReviewService, HostelReviewService>();

            services.AddScoped<IHostelRoomService, HostelRoomService>();

            services.AddScoped<IRoomPhotoService, RoomPhotoService>();

            services.AddScoped<IRoomService, RoomService>();

            services.AddScoped<IFileStoreService, FileStoreService>();


            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hostel_Hub_Api", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hostel_Hub_Api v1"));
            }

            app.UseExceptionHandler(a => a.Run(async context =>
            {
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = exceptionHandlerPathFeature.Error;


                //File.AppendAllText(@"D:\Dev\Visual Studio\KNUSTTimetable\KNUSTTimeTable.API\bin\Debug\net5.0" + DateTime.Now.ToString("yyyyMMdd") + ".txt", exception.Message + Environment.NewLine + Environment.NewLine);

                var result = JsonConvert.SerializeObject(new { error = exception.Message });
                if (exception is CustomException || exception is SecurityTokenException)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }

                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(result);
            }));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
