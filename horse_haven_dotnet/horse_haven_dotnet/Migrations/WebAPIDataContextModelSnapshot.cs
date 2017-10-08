using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using horse_haven_dotnet;

namespace horse_haven_dotnet.Migrations
{
    [DbContext(typeof(WebAPIDataContext))]
    partial class WebAPIDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("horse_haven_dotnet.Models.Boarding", b =>
                {
                    b.Property<int>("BoardingId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BoardingTypeId");

                    b.Property<DateTime>("EndDate");

                    b.Property<int>("HorseId");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("BoardingId");

                    b.HasIndex("BoardingTypeId");

                    b.HasIndex("HorseId");

                    b.ToTable("Boardings");
                });

            modelBuilder.Entity("horse_haven_dotnet.Models.BoardingType", b =>
                {
                    b.Property<int>("BoardingTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("DailyRate");

                    b.Property<string>("Description");

                    b.HasKey("BoardingTypeId");

                    b.ToTable("BoardingTypes");
                });

            modelBuilder.Entity("horse_haven_dotnet.Models.Case", b =>
                {
                    b.Property<int>("CaseId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("CaseId");

                    b.ToTable("Cases");
                });

            modelBuilder.Entity("horse_haven_dotnet.Models.Horse", b =>
                {
                    b.Property<int>("HorseId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AdopterId");

                    b.Property<int>("Age");

                    b.Property<DateTime>("ArrivalDate");

                    b.Property<string>("Breed");

                    b.Property<int>("CaseId");

                    b.Property<string>("Color");

                    b.Property<string>("CountyOfOrigin");

                    b.Property<DateTime>("DepartureDate");

                    b.Property<DateTime>("EligibleForOwnership");

                    b.Property<string>("Gender");

                    b.Property<string>("HorseHavenId");

                    b.Property<int>("HorseStatusId");

                    b.Property<string>("Name");

                    b.HasKey("HorseId");

                    b.HasIndex("AdopterId");

                    b.HasIndex("CaseId");

                    b.HasIndex("HorseStatusId");

                    b.ToTable("Horses");
                });

            modelBuilder.Entity("horse_haven_dotnet.Models.HorseStatus", b =>
                {
                    b.Property<int>("HorseStatusId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("HorseStatusId");

                    b.ToTable("HorseStatuses");
                });

            modelBuilder.Entity("horse_haven_dotnet.Models.HorseWeight", b =>
                {
                    b.Property<int>("HorseWeightId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateWeighed");

                    b.Property<int>("HorseId");

                    b.Property<decimal>("Weight");

                    b.HasKey("HorseWeightId");

                    b.HasIndex("HorseId");

                    b.ToTable("HorseWeights");
                });

            modelBuilder.Entity("horse_haven_dotnet.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<int>("PersonTypeId");

                    b.Property<int>("Phone");

                    b.HasKey("PersonId");

                    b.HasIndex("PersonTypeId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("horse_haven_dotnet.Models.PersonType", b =>
                {
                    b.Property<int>("PersonTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("PersonTypeId");

                    b.ToTable("PersonTypes");
                });

            modelBuilder.Entity("horse_haven_dotnet.Models.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("CostOfService");

                    b.Property<DateTime>("DateOfService");

                    b.Property<string>("Description");

                    b.Property<int>("HorseId");

                    b.Property<int>("ServiceProviderId");

                    b.Property<int?>("ServiceProviderId.");

                    b.Property<int>("ServiceTypeId");

                    b.HasKey("ServiceId");

                    b.HasIndex("HorseId");

                    b.HasIndex("ServiceProviderId.");

                    b.HasIndex("ServiceTypeId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("horse_haven_dotnet.Models.ServiceType", b =>
                {
                    b.Property<int>("ServiceTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("ServiceTypeId");

                    b.ToTable("ServiceTypes");
                });

            modelBuilder.Entity("horse_haven_dotnet.Models.Boarding", b =>
                {
                    b.HasOne("horse_haven_dotnet.Models.BoardingType", "BoardingType")
                        .WithMany("Boardings")
                        .HasForeignKey("BoardingTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("horse_haven_dotnet.Models.Horse", "Horse")
                        .WithMany("Boardings")
                        .HasForeignKey("HorseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("horse_haven_dotnet.Models.Horse", b =>
                {
                    b.HasOne("horse_haven_dotnet.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("AdopterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("horse_haven_dotnet.Models.Case", "Case")
                        .WithMany("Horses")
                        .HasForeignKey("CaseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("horse_haven_dotnet.Models.HorseStatus", "HorseStatus")
                        .WithMany("Horses")
                        .HasForeignKey("HorseStatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("horse_haven_dotnet.Models.HorseWeight", b =>
                {
                    b.HasOne("horse_haven_dotnet.Models.Horse", "Horse")
                        .WithMany("Weighings")
                        .HasForeignKey("HorseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("horse_haven_dotnet.Models.Person", b =>
                {
                    b.HasOne("horse_haven_dotnet.Models.PersonType", "PersonType")
                        .WithMany("People")
                        .HasForeignKey("PersonTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("horse_haven_dotnet.Models.Service", b =>
                {
                    b.HasOne("horse_haven_dotnet.Models.Horse", "Horse")
                        .WithMany("Services")
                        .HasForeignKey("HorseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("horse_haven_dotnet.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("ServiceProviderId.");

                    b.HasOne("horse_haven_dotnet.Models.ServiceType", "ServiceType")
                        .WithMany("Services")
                        .HasForeignKey("ServiceTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
