﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using PGameServerCore.RestAPI.Models;
using System;

namespace PGameServerCore.RestAPI.Migrations
{
    [DbContext(typeof(GameContext))]
    [Migration("20170824045101_create_user_update_poke_and_trnr")]
    partial class create_user_update_poke_and_trnr
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PGameServerCore.Shared.Entities.Pokemon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BreedNum");

                    b.Property<short>("EV_ATK");

                    b.Property<short>("EV_DEF");

                    b.Property<short>("EV_HP");

                    b.Property<short>("EV_SPEC_ATK");

                    b.Property<short>("EV_SPEC_DEF");

                    b.Property<short>("EV_SPEED");

                    b.Property<short>("IV_ATK");

                    b.Property<short>("IV_DEF");

                    b.Property<short>("IV_HP");

                    b.Property<short>("IV_SPEC_ATK");

                    b.Property<short>("IV_SPEC_DEF");

                    b.Property<short>("IV_SPEED");

                    b.Property<string>("Name");

                    b.Property<Guid>("Trainer");

                    b.Property<Guid>("TrainerId");

                    b.HasKey("Id");

                    b.ToTable("Pokemon");
                });

            modelBuilder.Entity("PGameServerCore.Shared.Entities.Trainer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Trainer");
                });
#pragma warning restore 612, 618
        }
    }
}
