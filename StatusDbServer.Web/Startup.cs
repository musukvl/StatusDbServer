﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;

namespace StatusDbServer.Web
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
            if (Configuration != null)
                services.AddSingleton<IConfiguration>(Configuration);
            services.AddLogging(builder => ConfigureLogging(builder, Configuration));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseMvc();

        }

        private void ConfigureLogging(ILoggingBuilder loggingBuilder, IConfiguration config)
        {
            var serilogLogger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .CreateLogger();

            loggingBuilder.AddSerilog(serilogLogger);
        }
    }
}
