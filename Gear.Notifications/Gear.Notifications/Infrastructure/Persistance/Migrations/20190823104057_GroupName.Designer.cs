﻿// <auto-generated />
using System;
using Gear.Notifications.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gear.Notifications.Infrastructure.Persistance.Migrations
{
    [DbContext(typeof(GearNotificationsContext))]
    [Migration("20190823104057_GroupName")]
    partial class GroupName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Gear.Notifications.Domain.BaseModels.Event", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<Guid>("HtmlEventMarkupId");

                    b.Property<string>("NotificationTypes");

                    b.Property<string>("PropagationTypes");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Gear.Notifications.Domain.BaseModels.HtmlEventMarkup", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("ChangesMarkup")
                        .IsRequired();

                    b.Property<Guid>("EventId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Subtitle")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("EventId")
                        .IsUnique();

                    b.ToTable("HtmlEventMarkups");
                });

            modelBuilder.Entity("Gear.Notifications.Domain.BaseModels.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Message");

                    b.Property<int>("NotificationType");

                    b.Property<Guid?>("PrimaryEntityGroup");

                    b.Property<string>("PrimaryEntityGroupName");

                    b.Property<string>("RedirectAction");

                    b.Property<string>("Users");

                    b.HasKey("Id");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Gear.Notifications.Domain.BaseModels.NotificationProfile", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("NotificationProfiles");
                });

            modelBuilder.Entity("Gear.Notifications.Domain.Helpers.NotificationEvent", b =>
                {
                    b.Property<Guid>("EventId");

                    b.Property<Guid>("NotificationProfileId");

                    b.HasKey("EventId", "NotificationProfileId");

                    b.HasIndex("NotificationProfileId");

                    b.ToTable("NotificationEvents");
                });

            modelBuilder.Entity("Gear.Notifications.Domain.Helpers.NotificationUser", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("NotificationProfileId");

                    b.HasKey("UserId", "NotificationProfileId");

                    b.HasIndex("NotificationProfileId");

                    b.ToTable("NotificationUsers");
                });

            modelBuilder.Entity("Gear.Notifications.Domain.BaseModels.HtmlEventMarkup", b =>
                {
                    b.HasOne("Gear.Notifications.Domain.BaseModels.Event", "Event")
                        .WithOne("HtmlEventMarkup")
                        .HasForeignKey("Gear.Notifications.Domain.BaseModels.HtmlEventMarkup", "EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Gear.Notifications.Domain.Helpers.NotificationEvent", b =>
                {
                    b.HasOne("Gear.Notifications.Domain.BaseModels.Event", "Event")
                        .WithMany("NotificationEvents")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Gear.Notifications.Domain.BaseModels.NotificationProfile", "NotificationProfile")
                        .WithMany("NotificationEvents")
                        .HasForeignKey("NotificationProfileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Gear.Notifications.Domain.Helpers.NotificationUser", b =>
                {
                    b.HasOne("Gear.Notifications.Domain.BaseModels.NotificationProfile", "NotificationProfile")
                        .WithMany("NotificationUsers")
                        .HasForeignKey("NotificationProfileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
