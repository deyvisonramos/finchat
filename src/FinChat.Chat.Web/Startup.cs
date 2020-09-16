using System;
using System.Threading;
using FinChat.Chat.Application.EventHandlers;
using FinChat.Chat.Application.Events;
using FinChat.Chat.Data.Context;
using FinChat.Chat.Domain.Entities;
using FinChat.Chat.IoC;
using FinChat.Chat.Web.Areas.Identity;
using FinChat.Chat.Web.Models;
using FinChat.Chat.Web.Transformers;
using FinChat.Chat.Web.Transformers.Interfaces;
using FinChat.Chat.WebSocket.Hubs;
using FinChat.Domain.Core.Bus;
using FinChat.Infra.Core.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FinChat.Chat.Web
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
            services.AddDbContext<FinChatDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("FinChatDbCS"));
            });

            services
                .AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<FinChatDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

            services.AddCoreEventBus();
            services.RegisterChatServices();
            services.RegisterChatEventHandlers();

            services.AddScoped<ITransformer<ChatRoom, ChatRoomViewModel>, ChatRoomTransformer>();
            services.AddScoped<ITransformer<ChatMessage, ChatMessageViewModel>, ChatMessageTransformer>();

            services.AddControllersWithViews();
            services.AddSignalR();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors(builder =>
            {
                builder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHub<ChatHub>("/chatHub");
                endpoints.MapRazorPages();
            });

            ConfigureEventBus(app);
        }

        private static void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe<CommandProcessedEvent, CommandProcessedEventHandler>();
        }
    }
}
