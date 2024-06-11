using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable IDE0300 // Simplify collection initialization
#pragma warning disable CA1861 // Avoid constant arrays as arguments

namespace HechoaMano.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DocumentId = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShopName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DocumentId = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Families",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Families", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FamilyTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventoryControls",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryControls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubFamilies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubFamilies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientOrderDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientOrderDetails", x => new { x.Id, x.ClientOrderId });
                    table.ForeignKey(
                        name: "FK_ClientOrderDetails_ClientOrders_ClientOrderId",
                        column: x => x.ClientOrderId,
                        principalTable: "ClientOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeOrderDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeOrderDetails", x => new { x.Id, x.EmployeeOrderId });
                    table.ForeignKey(
                        name: "FK_EmployeeOrderDetails_EmployeeOrders_EmployeeOrderId",
                        column: x => x.EmployeeOrderId,
                        principalTable: "EmployeeOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryControlDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InventoryControlId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountedQuantity = table.Column<int>(type: "int", nullable: false),
                    SystemQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryControlDetails", x => new { x.Id, x.InventoryControlId });
                    table.ForeignKey(
                        name: "FK_InventoryControlDetails_InventoryControls_InventoryControlId",
                        column: x => x.InventoryControlId,
                        principalTable: "InventoryControls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FamilyTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FamilyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubFamilyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SizeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    SellPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BuyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Families_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Families",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_FamilyTypes_FamilyTypeId",
                        column: x => x.FamilyTypeId,
                        principalTable: "FamilyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_SubFamilies_SubFamilyId",
                        column: x => x.SubFamilyId,
                        principalTable: "SubFamilies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Families",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("17a7f4e9-8b04-4bf7-bb1d-a6ef058052df"), "IMAN" },
                    { new Guid("311c88c1-f1e9-444a-9db8-315d30bbd4f3"), "COPA MINI" },
                    { new Guid("55eee6be-64b1-4066-84b5-8599d4bfdb07"), "ESTUCHE" },
                    { new Guid("5a5b20cc-ab3a-4c1f-89ce-ee7b8671c67b"), "PORTAVASO" },
                    { new Guid("734ffdbd-7825-42a5-91c0-34e432f9b046"), "ESPEJO" },
                    { new Guid("77d8eedd-173f-4259-b74e-0b0af1b70561"), "PLATO" },
                    { new Guid("782fcf19-4c25-4c71-8af0-fce32fd5ecde"), "JUEGO DE COPA" },
                    { new Guid("791ea326-1110-4952-b6a9-b5c1762e1fb0"), "BOLSO" },
                    { new Guid("8aaf977d-a876-49c5-8005-1e0eca0205f1"), "CIGARRILLERA" },
                    { new Guid("979a8121-0aee-495c-aaf3-659475b4f5e4"), "LLAVERO" },
                    { new Guid("9aa075c1-8da7-46e0-bbbe-eed2d0f2515f"), "DESTAPADOR" },
                    { new Guid("9cbce495-90e9-4958-8a4f-cb0705f8dd0e"), "GORRA" },
                    { new Guid("a5a5d59e-05d2-48c3-bf8c-77d9c3a342ec"), "MONEDERO" },
                    { new Guid("c6c7f7ef-4667-4667-9264-c2419685039d"), "JUEGO BAR BOTELLA" },
                    { new Guid("dfee3615-a13a-4873-bcc0-ea8899f1fef1"), "BURBUJA" },
                    { new Guid("e6598dca-0faa-4655-a7ab-49843e8e4189"), "COPA TEQUILERA" },
                    { new Guid("f9a82640-55d0-4397-92b4-231c253de55c"), "COPA UN TRAGO" }
                });

            migrationBuilder.InsertData(
                table: "FamilyTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("06f06c09-87d9-4395-905c-c3372d8d9968"), "TRADICIONAL" },
                    { new Guid("070a6b5b-17af-46a7-b02d-48a60a6b93a6"), "COLOR" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2669b589-1183-4d04-9c8b-8c3d9e992b48"), "ARMENIA" },
                    { new Guid("4fba73e9-c904-4cbf-86eb-625fc3e86225"), "SANTA MARTA " },
                    { new Guid("6b1c12fb-75a0-4740-aba1-2242eff9f1f1"), "CALI" },
                    { new Guid("7a927084-d92d-4f05-b692-08176b8daf5d"), "GUATAPE" },
                    { new Guid("9de4f31d-53b3-406f-8551-469708b0f614"), "SAN ANDRES" },
                    { new Guid("be0cac98-67dd-4e1e-b61e-a68b7995f251"), "MEDELLIN" },
                    { new Guid("c77c3a42-5228-4660-869c-551c5ea74ddd"), "CARTAGENA" },
                    { new Guid("da663528-86f4-422a-badb-da8ca9b6b720"), "COLOMBIA" },
                    { new Guid("ef5cabc2-f7a5-4967-ac14-99e6c008307b"), "BARRANQUILLA" },
                    { new Guid("fa99f2fb-073f-4bf7-834d-ed9b55e8759e"), "GENERAL" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("05a34005-8a4c-420e-84bf-d04fcb747502"), "X6" },
                    { new Guid("470a16c8-e584-4f1f-85c5-04b07a87471e"), "PEQUEÑO" },
                    { new Guid("5e7de310-e9ca-4b58-908c-31b3b6412495"), "X2" },
                    { new Guid("5ed80180-fa8c-4c74-93bd-edfab30154b2"), "X5" },
                    { new Guid("8d4eab22-900b-489c-91fa-ed9fe695cbd6"), "No 2" },
                    { new Guid("a015c766-3c91-4904-a7ac-bd54be7f4121"), "No 0" },
                    { new Guid("a37ea663-7a40-4abb-9bc2-e6e3d4016f66"), "MINI" },
                    { new Guid("a487b028-b61a-4b80-94fb-65242878eaee"), "No 1" },
                    { new Guid("a846a3ec-8ad7-473f-9107-81169cedf740"), "GRANDE" },
                    { new Guid("c123e369-172e-41ca-b3b8-a6a6c30724ff"), "No 3" },
                    { new Guid("de79c6d2-c572-4391-aa77-210056c8f9f7"), "X3" },
                    { new Guid("e1bfaa2f-a5aa-43c4-bdbe-617cd254cdbb"), "X4" },
                    { new Guid("eaf3733b-85d6-4911-ae70-13820d431c80"), "MEDIANO" }
                });

            migrationBuilder.InsertData(
                table: "SubFamilies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0421e866-ff74-4a0a-a022-885d85bcfc22"), "CARRETA BAR MINI" },
                    { new Guid("0954cf7b-551e-4ea7-af6d-480d5565e974"), "ESTUCHE" },
                    { new Guid("0c5934ac-c5f2-4d76-b099-ec58ab3dd78e"), "DISEÑO OPALIZADA" },
                    { new Guid("1ffa24ea-5fc4-45a3-b65e-f9cc0805e193"), "FORRO CUERO" },
                    { new Guid("21ddd364-1028-4020-ac27-e02d3cb80552"), "FINAS" },
                    { new Guid("3354f67e-f863-4403-b064-233ed7975ab7"), "SOMBRERO" },
                    { new Guid("3402719e-fec2-485b-8cf5-f4a78911ad7b"), "PUEBLITO PAISA" },
                    { new Guid("459fb84d-cd4c-45c7-9858-7eeb9ea3eb0f"), "MARCO" },
                    { new Guid("4c95de06-d202-4649-91cb-578e8d71b5fa"), "MEDIA LUNA" },
                    { new Guid("4daba243-31d9-4b52-91c7-d34523c98a35"), "COLLAGE" },
                    { new Guid("52b07f65-a126-4150-b7e0-0ded5b6b3a9a"), "UN TRAGO" },
                    { new Guid("57e9568a-3ced-4379-b0b8-539898d954ef"), "DISEÑO CRISTAL" },
                    { new Guid("5a55df02-3667-45f2-9466-9e68a27283f0"), "CUERO" },
                    { new Guid("5d0b3852-1aa8-4bd6-8562-81fb591b53d8"), "SERVILLETERO JUAN VALDES" },
                    { new Guid("638d96e8-d303-4c2c-b645-89f58594f64c"), "BARCO COPAS UN TRAGO" },
                    { new Guid("67abcc4d-e158-41ea-9941-d30df062c785"), "BOTERO" },
                    { new Guid("6be8f6d2-2708-4c8b-bfdc-c6fbbeb6c48d"), "GUATAPE" },
                    { new Guid("7096db25-29fc-4719-8305-e307e36ad2d5"), "GATO" },
                    { new Guid("74afd2e9-729a-4175-b4f4-8bced0820b31"), "MALLA" },
                    { new Guid("861c8747-0b32-4139-8ffc-669ca8b7c9ff"), "TAGUA MULTICOLOR" },
                    { new Guid("89acacbb-bda9-4882-91c6-51619e23691c"), "TINTERO" },
                    { new Guid("8fda733b-bbf8-428f-b448-21125c0ca6c8"), "SERVILLETERO ROMBO" },
                    { new Guid("987924b7-9829-4721-84c2-e31676da9f82"), "PLACA" },
                    { new Guid("a64e0faa-f323-4542-b69a-b02a5bd52e0a"), "FLORES" },
                    { new Guid("a6db5cfa-1b5c-44a9-9b94-5aa19c809cbd"), "TELAR" },
                    { new Guid("aa85c690-a984-43ae-b67f-c699f7454503"), "DESTAPADOR" },
                    { new Guid("acfb1398-bbc1-427e-b6c3-52a4f5f92f02"), "PLATOS CERAMICA" },
                    { new Guid("b25a7cce-87fd-4679-a93b-99f507e63418"), "DOBLE APLIQUE" },
                    { new Guid("b79832af-48e5-4309-917e-d58bcc79254d"), "SERVILLETERO CUNA" },
                    { new Guid("c46c694a-fab4-462b-ae7b-a23f8f53d58a"), "METAL" },
                    { new Guid("c8be2ada-2a7f-4996-891e-41ef6d4ba0bf"), "RECTANGULO" },
                    { new Guid("d3de0d9c-c42b-4ef9-b514-830967f15560"), "ESPEJO" },
                    { new Guid("d52044c1-6fa7-496b-8deb-204cb124f12c"), "PIRAMIDE" },
                    { new Guid("d81b19c6-578b-47ac-b8cf-71832f9ce296"), "HUEVO" },
                    { new Guid("dcbc0be6-0650-454d-be30-e23446c5e3a8"), "COPA MINI" },
                    { new Guid("de1efbd5-07c5-48ae-88a6-837ab750b471"), "BORDADA" },
                    { new Guid("e06eae6b-73b5-4000-8a5f-74a703c258bd"), "CORTAUÑA" },
                    { new Guid("e41f4ff9-4b66-47f0-bd16-148faecf1a4a"), "SERVILLETERO MORA" },
                    { new Guid("e582ccfe-8f6f-41b2-b4e3-562c8b961ba2"), "CHIVA" },
                    { new Guid("ee135c7d-3635-4161-a97c-065165589866"), "RECINA" },
                    { new Guid("ee4ae14c-664b-4743-af9b-214496dbe4b4"), "CHIVA BAR MINI" },
                    { new Guid("eecff842-c38b-40ce-b7c5-24fffdfdf133"), "COLGAR CUERO" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientOrderDetails_ClientOrderId",
                table: "ClientOrderDetails",
                column: "ClientOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeOrderDetails_EmployeeOrderId",
                table: "EmployeeOrderDetails",
                column: "EmployeeOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryControlDetails_InventoryControlId",
                table: "InventoryControlDetails",
                column: "InventoryControlId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_FamilyId",
                table: "Products",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_FamilyTypeId",
                table: "Products",
                column: "FamilyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_RegionId",
                table: "Products",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SizeId",
                table: "Products",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubFamilyId",
                table: "Products",
                column: "SubFamilyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientOrderDetails");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "EmployeeOrderDetails");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "InventoryControlDetails");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ClientOrders");

            migrationBuilder.DropTable(
                name: "EmployeeOrders");

            migrationBuilder.DropTable(
                name: "InventoryControls");

            migrationBuilder.DropTable(
                name: "Families");

            migrationBuilder.DropTable(
                name: "FamilyTypes");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "SubFamilies");
        }
    }
}

#pragma warning restore CA1861 // Avoid constant arrays as arguments
#pragma warning restore IDE0300 // Simplify collection initialization