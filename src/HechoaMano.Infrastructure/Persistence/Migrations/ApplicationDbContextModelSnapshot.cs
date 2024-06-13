﻿// <auto-generated />
using System;
using HechoaMano.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HechoaMano.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HechoaMano.Domain.Clients.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("DocumentId")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ShopName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Clients", (string)null);
                });

            modelBuilder.Entity("HechoaMano.Domain.Employees.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DocumentId")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Employees", (string)null);
                });

            modelBuilder.Entity("HechoaMano.Domain.Inventory.Aggregates.ClientOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("ClientOrders", (string)null);
                });

            modelBuilder.Entity("HechoaMano.Domain.Inventory.Aggregates.EmployeeOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("EmployeeOrders", (string)null);
                });

            modelBuilder.Entity("HechoaMano.Domain.Inventory.Aggregates.InventoryControl", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("InventoryControls", (string)null);
                });

            modelBuilder.Entity("HechoaMano.Domain.Products.Entities.Family", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Families", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("791ea326-1110-4952-b6a9-b5c1762e1fb0"),
                            Name = "BOLSO"
                        },
                        new
                        {
                            Id = new Guid("a5a5d59e-05d2-48c3-bf8c-77d9c3a342ec"),
                            Name = "MONEDERO"
                        },
                        new
                        {
                            Id = new Guid("5a5b20cc-ab3a-4c1f-89ce-ee7b8671c67b"),
                            Name = "PORTAVASO"
                        },
                        new
                        {
                            Id = new Guid("782fcf19-4c25-4c71-8af0-fce32fd5ecde"),
                            Name = "JUEGO DE COPA"
                        },
                        new
                        {
                            Id = new Guid("c6c7f7ef-4667-4667-9264-c2419685039d"),
                            Name = "JUEGO BAR BOTELLA"
                        },
                        new
                        {
                            Id = new Guid("f9a82640-55d0-4397-92b4-231c253de55c"),
                            Name = "COPA UN TRAGO"
                        },
                        new
                        {
                            Id = new Guid("e6598dca-0faa-4655-a7ab-49843e8e4189"),
                            Name = "COPA TEQUILERA"
                        },
                        new
                        {
                            Id = new Guid("55eee6be-64b1-4066-84b5-8599d4bfdb07"),
                            Name = "ESTUCHE"
                        },
                        new
                        {
                            Id = new Guid("311c88c1-f1e9-444a-9db8-315d30bbd4f3"),
                            Name = "COPA MINI"
                        },
                        new
                        {
                            Id = new Guid("979a8121-0aee-495c-aaf3-659475b4f5e4"),
                            Name = "LLAVERO"
                        },
                        new
                        {
                            Id = new Guid("734ffdbd-7825-42a5-91c0-34e432f9b046"),
                            Name = "ESPEJO"
                        },
                        new
                        {
                            Id = new Guid("dfee3615-a13a-4873-bcc0-ea8899f1fef1"),
                            Name = "BURBUJA"
                        },
                        new
                        {
                            Id = new Guid("17a7f4e9-8b04-4bf7-bb1d-a6ef058052df"),
                            Name = "IMAN"
                        },
                        new
                        {
                            Id = new Guid("9cbce495-90e9-4958-8a4f-cb0705f8dd0e"),
                            Name = "GORRA"
                        },
                        new
                        {
                            Id = new Guid("8aaf977d-a876-49c5-8005-1e0eca0205f1"),
                            Name = "CIGARRILLERA"
                        },
                        new
                        {
                            Id = new Guid("77d8eedd-173f-4259-b74e-0b0af1b70561"),
                            Name = "PLATO"
                        },
                        new
                        {
                            Id = new Guid("9aa075c1-8da7-46e0-bbbe-eed2d0f2515f"),
                            Name = "DESTAPADOR"
                        });
                });

            modelBuilder.Entity("HechoaMano.Domain.Products.Entities.FamilyType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("FamilyTypes", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("070a6b5b-17af-46a7-b02d-48a60a6b93a6"),
                            Name = "COLOR"
                        },
                        new
                        {
                            Id = new Guid("06f06c09-87d9-4395-905c-c3372d8d9968"),
                            Name = "TRADICIONAL"
                        });
                });

            modelBuilder.Entity("HechoaMano.Domain.Products.Entities.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("da663528-86f4-422a-badb-da8ca9b6b720"),
                            Name = "COLOMBIA"
                        },
                        new
                        {
                            Id = new Guid("be0cac98-67dd-4e1e-b61e-a68b7995f251"),
                            Name = "MEDELLIN"
                        },
                        new
                        {
                            Id = new Guid("6b1c12fb-75a0-4740-aba1-2242eff9f1f1"),
                            Name = "CALI"
                        },
                        new
                        {
                            Id = new Guid("ef5cabc2-f7a5-4967-ac14-99e6c008307b"),
                            Name = "BARRANQUILLA"
                        },
                        new
                        {
                            Id = new Guid("c77c3a42-5228-4660-869c-551c5ea74ddd"),
                            Name = "CARTAGENA"
                        },
                        new
                        {
                            Id = new Guid("9de4f31d-53b3-406f-8551-469708b0f614"),
                            Name = "SAN ANDRES"
                        },
                        new
                        {
                            Id = new Guid("4fba73e9-c904-4cbf-86eb-625fc3e86225"),
                            Name = "SANTA MARTA"
                        },
                        new
                        {
                            Id = new Guid("7a927084-d92d-4f05-b692-08176b8daf5d"),
                            Name = "GUATAPE"
                        },
                        new
                        {
                            Id = new Guid("2669b589-1183-4d04-9c8b-8c3d9e992b48"),
                            Name = "ARMENIA"
                        },
                        new
                        {
                            Id = new Guid("fa99f2fb-073f-4bf7-834d-ed9b55e8759e"),
                            Name = "GENERAL"
                        });
                });

            modelBuilder.Entity("HechoaMano.Domain.Products.Entities.Size", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sizes", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("a846a3ec-8ad7-473f-9107-81169cedf740"),
                            Name = "GRANDE"
                        },
                        new
                        {
                            Id = new Guid("470a16c8-e584-4f1f-85c5-04b07a87471e"),
                            Name = "PEQUEÑO"
                        },
                        new
                        {
                            Id = new Guid("a015c766-3c91-4904-a7ac-bd54be7f4121"),
                            Name = "No 0"
                        },
                        new
                        {
                            Id = new Guid("a487b028-b61a-4b80-94fb-65242878eaee"),
                            Name = "No 1"
                        },
                        new
                        {
                            Id = new Guid("8d4eab22-900b-489c-91fa-ed9fe695cbd6"),
                            Name = "No 2"
                        },
                        new
                        {
                            Id = new Guid("c123e369-172e-41ca-b3b8-a6a6c30724ff"),
                            Name = "No 3"
                        },
                        new
                        {
                            Id = new Guid("eaf3733b-85d6-4911-ae70-13820d431c80"),
                            Name = "MEDIANO"
                        },
                        new
                        {
                            Id = new Guid("5e7de310-e9ca-4b58-908c-31b3b6412495"),
                            Name = "X2"
                        },
                        new
                        {
                            Id = new Guid("de79c6d2-c572-4391-aa77-210056c8f9f7"),
                            Name = "X3"
                        },
                        new
                        {
                            Id = new Guid("e1bfaa2f-a5aa-43c4-bdbe-617cd254cdbb"),
                            Name = "X4"
                        },
                        new
                        {
                            Id = new Guid("05a34005-8a4c-420e-84bf-d04fcb747502"),
                            Name = "X6"
                        },
                        new
                        {
                            Id = new Guid("5ed80180-fa8c-4c74-93bd-edfab30154b2"),
                            Name = "X5"
                        },
                        new
                        {
                            Id = new Guid("a37ea663-7a40-4abb-9bc2-e6e3d4016f66"),
                            Name = "MINI"
                        });
                });

            modelBuilder.Entity("HechoaMano.Domain.Products.Entities.SubFamily", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SubFamilies", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("d52044c1-6fa7-496b-8deb-204cb124f12c"),
                            Name = "PIRAMIDE"
                        },
                        new
                        {
                            Id = new Guid("a6db5cfa-1b5c-44a9-9b94-5aa19c809cbd"),
                            Name = "TELAR"
                        },
                        new
                        {
                            Id = new Guid("b25a7cce-87fd-4679-a93b-99f507e63418"),
                            Name = "DOBLE APLIQUE"
                        },
                        new
                        {
                            Id = new Guid("4c95de06-d202-4649-91cb-578e8d71b5fa"),
                            Name = "MEDIA LUNA"
                        },
                        new
                        {
                            Id = new Guid("e582ccfe-8f6f-41b2-b4e3-562c8b961ba2"),
                            Name = "CHIVA"
                        },
                        new
                        {
                            Id = new Guid("3354f67e-f863-4403-b064-233ed7975ab7"),
                            Name = "SOMBRERO"
                        },
                        new
                        {
                            Id = new Guid("8fda733b-bbf8-428f-b448-21125c0ca6c8"),
                            Name = "SERVILLETERO ROMBO"
                        },
                        new
                        {
                            Id = new Guid("e41f4ff9-4b66-47f0-bd16-148faecf1a4a"),
                            Name = "SERVILLETERO MORA"
                        },
                        new
                        {
                            Id = new Guid("0954cf7b-551e-4ea7-af6d-480d5565e974"),
                            Name = "ESTUCHE"
                        },
                        new
                        {
                            Id = new Guid("5d0b3852-1aa8-4bd6-8562-81fb591b53d8"),
                            Name = "SERVILLETERO JUAN VALDES"
                        },
                        new
                        {
                            Id = new Guid("b79832af-48e5-4309-917e-d58bcc79254d"),
                            Name = "SERVILLETERO CUNA"
                        },
                        new
                        {
                            Id = new Guid("52b07f65-a126-4150-b7e0-0ded5b6b3a9a"),
                            Name = "UN TRAGO"
                        },
                        new
                        {
                            Id = new Guid("638d96e8-d303-4c2c-b645-89f58594f64c"),
                            Name = "BARCO COPAS UN TRAGO"
                        },
                        new
                        {
                            Id = new Guid("1ffa24ea-5fc4-45a3-b65e-f9cc0805e193"),
                            Name = "FORRO CUERO"
                        },
                        new
                        {
                            Id = new Guid("eecff842-c38b-40ce-b7c5-24fffdfdf133"),
                            Name = "COLGAR CUERO"
                        },
                        new
                        {
                            Id = new Guid("57e9568a-3ced-4379-b0b8-539898d954ef"),
                            Name = "DISEÑO CRISTAL"
                        },
                        new
                        {
                            Id = new Guid("0c5934ac-c5f2-4d76-b099-ec58ab3dd78e"),
                            Name = "DISEÑO OPALIZADA"
                        },
                        new
                        {
                            Id = new Guid("ee4ae14c-664b-4743-af9b-214496dbe4b4"),
                            Name = "CHIVA BAR MINI"
                        },
                        new
                        {
                            Id = new Guid("0421e866-ff74-4a0a-a022-885d85bcfc22"),
                            Name = "CARRETA BAR MINI"
                        },
                        new
                        {
                            Id = new Guid("dcbc0be6-0650-454d-be30-e23446c5e3a8"),
                            Name = "COPA MINI"
                        },
                        new
                        {
                            Id = new Guid("e06eae6b-73b5-4000-8a5f-74a703c258bd"),
                            Name = "CORTAUÑA"
                        },
                        new
                        {
                            Id = new Guid("d3de0d9c-c42b-4ef9-b514-830967f15560"),
                            Name = "ESPEJO"
                        },
                        new
                        {
                            Id = new Guid("aa85c690-a984-43ae-b67f-c699f7454503"),
                            Name = "DESTAPADOR"
                        },
                        new
                        {
                            Id = new Guid("987924b7-9829-4721-84c2-e31676da9f82"),
                            Name = "PLACA"
                        },
                        new
                        {
                            Id = new Guid("5a55df02-3667-45f2-9466-9e68a27283f0"),
                            Name = "CUERO"
                        },
                        new
                        {
                            Id = new Guid("861c8747-0b32-4139-8ffc-669ca8b7c9ff"),
                            Name = "TAGUA MULTICOLOR"
                        },
                        new
                        {
                            Id = new Guid("4daba243-31d9-4b52-91c7-d34523c98a35"),
                            Name = "COLLAGE"
                        },
                        new
                        {
                            Id = new Guid("67abcc4d-e158-41ea-9941-d30df062c785"),
                            Name = "BOTERO"
                        },
                        new
                        {
                            Id = new Guid("d81b19c6-578b-47ac-b8cf-71832f9ce296"),
                            Name = "HUEVO"
                        },
                        new
                        {
                            Id = new Guid("7096db25-29fc-4719-8305-e307e36ad2d5"),
                            Name = "GATO"
                        },
                        new
                        {
                            Id = new Guid("3402719e-fec2-485b-8cf5-f4a78911ad7b"),
                            Name = "PUEBLITO PAISA"
                        },
                        new
                        {
                            Id = new Guid("6be8f6d2-2708-4c8b-bfdc-c6fbbeb6c48d"),
                            Name = "GUATAPE"
                        },
                        new
                        {
                            Id = new Guid("acfb1398-bbc1-427e-b6c3-52a4f5f92f02"),
                            Name = "PLATOS CERAMICA"
                        },
                        new
                        {
                            Id = new Guid("459fb84d-cd4c-45c7-9858-7eeb9ea3eb0f"),
                            Name = "MARCO"
                        },
                        new
                        {
                            Id = new Guid("ee135c7d-3635-4161-a97c-065165589866"),
                            Name = "RECINA"
                        },
                        new
                        {
                            Id = new Guid("c8be2ada-2a7f-4996-891e-41ef6d4ba0bf"),
                            Name = "RECTANGULO"
                        },
                        new
                        {
                            Id = new Guid("a64e0faa-f323-4542-b69a-b02a5bd52e0a"),
                            Name = "FLORES"
                        },
                        new
                        {
                            Id = new Guid("21ddd364-1028-4020-ac27-e02d3cb80552"),
                            Name = "FINAS"
                        },
                        new
                        {
                            Id = new Guid("de1efbd5-07c5-48ae-88a6-837ab750b471"),
                            Name = "BORDADA"
                        },
                        new
                        {
                            Id = new Guid("74afd2e9-729a-4175-b4f4-8bced0820b31"),
                            Name = "MALLA"
                        },
                        new
                        {
                            Id = new Guid("89acacbb-bda9-4882-91c6-51619e23691c"),
                            Name = "TINTERO"
                        },
                        new
                        {
                            Id = new Guid("c46c694a-fab4-462b-ae7b-a23f8f53d58a"),
                            Name = "METAL"
                        });
                });

            modelBuilder.Entity("HechoaMano.Domain.Products.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("BuyPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FamilyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FamilyTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("SellPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("SizeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SubFamilyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("FamilyId");

                    b.HasIndex("FamilyTypeId");

                    b.HasIndex("RegionId");

                    b.HasIndex("SizeId");

                    b.HasIndex("SubFamilyId");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("HechoaMano.Domain.Clients.Client", b =>
                {
                    b.OwnsOne("HechoaMano.Domain.Clients.ValueObjects.ContactInformation", "ContactInfo", b1 =>
                        {
                            b1.Property<Guid>("ClientId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Address");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("City");

                            b1.Property<string>("PhoneNumber")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("PhoneNumber");

                            b1.HasKey("ClientId");

                            b1.ToTable("Clients");

                            b1.WithOwner()
                                .HasForeignKey("ClientId");
                        });

                    b.Navigation("ContactInfo")
                        .IsRequired();
                });

            modelBuilder.Entity("HechoaMano.Domain.Inventory.Aggregates.ClientOrder", b =>
                {
                    b.OwnsMany("HechoaMano.Domain.Inventory.Entities.OrderDetail", "Details", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("ClientOrderId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Price")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Quantity")
                                .HasColumnType("int");

                            b1.HasKey("Id", "ClientOrderId");

                            b1.HasIndex("ClientOrderId");

                            b1.ToTable("ClientOrderDetails", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("ClientOrderId");
                        });

                    b.Navigation("Details");
                });

            modelBuilder.Entity("HechoaMano.Domain.Inventory.Aggregates.EmployeeOrder", b =>
                {
                    b.OwnsMany("HechoaMano.Domain.Inventory.Entities.OrderDetail", "Details", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("EmployeeOrderId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Price")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Quantity")
                                .HasColumnType("int");

                            b1.HasKey("Id", "EmployeeOrderId");

                            b1.HasIndex("EmployeeOrderId");

                            b1.ToTable("EmployeeOrderDetails", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("EmployeeOrderId");
                        });

                    b.Navigation("Details");
                });

            modelBuilder.Entity("HechoaMano.Domain.Inventory.Aggregates.InventoryControl", b =>
                {
                    b.OwnsMany("HechoaMano.Domain.Inventory.Entities.InventoryControlDetail", "Details", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("InventoryControlId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("CountedQuantity")
                                .HasColumnType("int");

                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("SystemQuantity")
                                .HasColumnType("int");

                            b1.HasKey("Id", "InventoryControlId");

                            b1.HasIndex("InventoryControlId");

                            b1.ToTable("InventoryControlDetails", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("InventoryControlId");
                        });

                    b.Navigation("Details");
                });

            modelBuilder.Entity("HechoaMano.Domain.Products.Product", b =>
                {
                    b.HasOne("HechoaMano.Domain.Products.Entities.Family", "Family")
                        .WithMany("Products")
                        .HasForeignKey("FamilyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HechoaMano.Domain.Products.Entities.FamilyType", "FamilyType")
                        .WithMany("Products")
                        .HasForeignKey("FamilyTypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HechoaMano.Domain.Products.Entities.Region", "Region")
                        .WithMany("Products")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HechoaMano.Domain.Products.Entities.Size", "Size")
                        .WithMany("Products")
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HechoaMano.Domain.Products.Entities.SubFamily", "SubFamily")
                        .WithMany("Products")
                        .HasForeignKey("SubFamilyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.OwnsOne("HechoaMano.Domain.Products.ValueObjects.ProductStock", "ProductStock", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Value")
                                .HasColumnType("int")
                                .HasColumnName("Stock");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.Navigation("Family");

                    b.Navigation("FamilyType");

                    b.Navigation("ProductStock")
                        .IsRequired();

                    b.Navigation("Region");

                    b.Navigation("Size");

                    b.Navigation("SubFamily");
                });

            modelBuilder.Entity("HechoaMano.Domain.Products.Entities.Family", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("HechoaMano.Domain.Products.Entities.FamilyType", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("HechoaMano.Domain.Products.Entities.Region", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("HechoaMano.Domain.Products.Entities.Size", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("HechoaMano.Domain.Products.Entities.SubFamily", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
