﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using PGameServerCore.RestAPI.Models;
using PGameServerCore.RestAPI.Services;
using PGameServerCore.RestAPI.Data;
using PGameServerCore.Shared.Entities;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace PGameServerCore.RestAPI
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
            services.AddMvc(setupAction =>
            {
                setupAction.ReturnHttpNotAcceptable = true;
                setupAction.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
            });

            services.AddDbContext<GameContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("GameContext")));

            services.AddScoped<IGameRepository, GameRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, GameContext gameContext)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            gameContext.EnsureSeedDataForContext();

            AutoMapper.Mapper.Initialize(cfg =>
            {
            cfg.CreateMap<Trainer, TrainerDto>();
            cfg.CreateMap<Pokemon, PokemonDto>()
            .ForMember(dest => dest.TotalIV, 
            opt => opt.MapFrom(
                src => 
                src.IV_HP + 
                src.IV_ATK + 
                src.IV_DEF + 
                src.IV_SPEC_ATK +
                src.IV_SPEC_DEF + 
                src.IV_SPEED));

                cfg.CreateMap<TrainerForCreationDto, Trainer>();
                cfg.CreateMap<PokemonForCreationDto, Pokemon>();
            });

            
            app.UseMvc();
        }
    }
}
