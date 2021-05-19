using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Messages_DAL.Database;
using Messages_DAL.Repositories.Chats;
using Messages_DAL.Repositories.Messages;
using Messages_DAL.Services.Chats;
using Messages_DAL.Services.Messages;
using Messages_PubSubAPI.Hubs.App;
using Messages_PubSubAPI.Hubs.Chats;
using Messages_PubSubAPI.Hubs.Messages;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Messages_PubSubAPI
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
            services.AddScoped<IChatsRepository, ChatsRepository>();
            services.AddScoped<IChatsService, ChatsService>();

            services.AddScoped<IMessagesRepository, MessagesRepository>();
            services.AddScoped<IMessagesService, MessagesService>();

            services.AddDbContext<MessagesContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });

            services.AddAutoMapper(typeof(Startup));

            services.AddSignalR();

            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials()
                       .WithOrigins("http://localhost:4200");
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<AppHub>("hubs/app");
                endpoints.MapHub<ChatHub>("hubs/chat");
                endpoints.MapHub<MessageHub>("hubs/messages");
            });
        }
    }
}
