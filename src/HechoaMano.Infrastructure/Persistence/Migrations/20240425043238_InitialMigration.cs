using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HechoaMano.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Family",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Family", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FamilyType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubFamily",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubFamily", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    FamilyTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    FamilyId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubFamilyId = table.Column<Guid>(type: "uuid", nullable: false),
                    SizeId = table.Column<Guid>(type: "uuid", nullable: false),
                    RegionId = table.Column<Guid>(type: "uuid", nullable: false),
                    SellPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    BuyPrice = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_FamilyType_FamilyTypeId",
                        column: x => x.FamilyTypeId,
                        principalTable: "FamilyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Family_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Family",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Size_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Size",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_SubFamily_SubFamilyId",
                        column: x => x.SubFamilyId,
                        principalTable: "SubFamily",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Family",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0263a484-83d0-4f5b-aaa1-7139d5872d6a"), "JUEGO BAR BOTELLA" },
                    { new Guid("2a0e232e-9f10-40b4-ba83-de30df9882e3"), "ESPEJO" },
                    { new Guid("2d331347-79b7-49e1-8244-71f142d47c6c"), "CIGARRILLERA" },
                    { new Guid("4cf67052-6009-40c8-a18d-a76d4309bf93"), "GORRA" },
                    { new Guid("504a1741-78a3-4d8f-957c-b8253472b1d4"), "DESTAPADOR" },
                    { new Guid("6e204ba0-242e-4dfa-bbd7-44faa14b4b09"), "BURBUJA" },
                    { new Guid("712b01f2-16c1-485b-a706-3c69e4039b04"), "JUEGO DE COPA" },
                    { new Guid("909e82ed-0701-4a6b-8209-e514ebf21ad7"), "ESTUCHE" },
                    { new Guid("91200448-6687-4cba-821e-beb03101284a"), "LLAVERO" },
                    { new Guid("9594d7b6-5493-4caf-ae3a-26e5508ccfa1"), "COPA MINI" },
                    { new Guid("ac7725cb-a113-462a-abb9-11a1eeb28c8a"), "MONEDERO" },
                    { new Guid("bee3184d-535c-4b8d-a9a9-6fb4f0f8af86"), "PORTAVASO" },
                    { new Guid("c228f565-b01f-4cbb-9af9-a8be668bde5a"), "PLATO" },
                    { new Guid("c3b6aa5a-5a0e-447c-ba11-f59201644b3e"), "COPA UN TRAGO" },
                    { new Guid("d90acb8c-ffb9-41f0-bb7a-7e19f4550bc5"), "COPA TEQUILERA" },
                    { new Guid("df982bf9-019c-4803-a457-6b695999c0e1"), "BOLSO" },
                    { new Guid("ff3d99b5-af8f-4967-b584-bce184378be3"), "IMAN" }
                });

            migrationBuilder.InsertData(
                table: "FamilyType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("8f3188b6-8ca7-482c-99af-50696bdd54d5"), "COLOR" },
                    { new Guid("a36ce337-d584-430b-8f42-f42e6feb238b"), "TRADICIONAL" }
                });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("00f98968-ea5f-4794-b713-d5cc2e353dfa"), "ARMENIA" },
                    { new Guid("0c9e8e75-8fc0-46c0-a8b7-3db0e0f5ffda"), "SAN ANDRES" },
                    { new Guid("2a0fa02c-1931-4652-be45-e29b7326ff95"), "MEDELLIN" },
                    { new Guid("2c819989-bd3d-4b6e-82df-98cc700ac6ca"), "GUATAPE" },
                    { new Guid("7813e404-a9a8-47a4-9253-4a13b1599d20"), "BARRANQUILLA" },
                    { new Guid("7b827de3-0669-4561-81db-e314ba753e72"), "CALI" },
                    { new Guid("a08fc5d7-5dd9-4eea-be75-da04959dd869"), "SANTA MARTA " },
                    { new Guid("a740e73d-b53a-4c7f-be18-a19cf12981bf"), "CARTAGENA" },
                    { new Guid("c5e3f563-6285-45ce-b61c-2a07b54e2a2c"), "COLOMBIA" },
                    { new Guid("dd68b5f8-7137-4969-85d6-da59c68fe34e"), "GENERAL" }
                });

            migrationBuilder.InsertData(
                table: "Size",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2dfacc69-35c9-423e-a08d-98aad4b3afa1"), "MEDIANO" },
                    { new Guid("3800bd7c-f9f8-4e14-9aad-d29ced527d29"), "GRANDE" },
                    { new Guid("43ac00bc-c8a7-4d06-8790-d5a97ad4e60c"), "X5" },
                    { new Guid("6a574c0c-6b6b-4be4-8c03-6ec8f338f188"), "No 3" },
                    { new Guid("72132e04-6bf2-44c3-8b49-fa289a6c72da"), "PEQUEÑO" },
                    { new Guid("78f38613-e708-4ea2-9fd0-9d7bcc12477f"), "No 0" },
                    { new Guid("82d3d0e8-86d7-4f08-a588-21d6ae1a1617"), "No 1" },
                    { new Guid("86131149-6a38-418c-87f2-daa6a02a4366"), "X4" },
                    { new Guid("8ffd0ad9-c046-483d-84c7-b215ee16e535"), "No 2" },
                    { new Guid("c73fb604-7552-45d5-b5fb-989fbb9557f2"), "X2" },
                    { new Guid("c98dce0c-12c6-435a-9591-bca60a3e2b14"), "X3" },
                    { new Guid("d103bf0e-c39f-479d-ab83-143048175d7a"), "MINI" },
                    { new Guid("daab74f6-0e08-43e6-a40f-056c2474d248"), "X6" }
                });

            migrationBuilder.InsertData(
                table: "SubFamily",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("00d9ce6f-d79f-41c8-be27-9af2e297f84c"), "PLACA" },
                    { new Guid("0c4b816a-c3de-48bb-b162-4f2b4d0e9dcd"), "SERVILLETERO CUNA" },
                    { new Guid("0f5b0115-4414-4840-8a03-183e765b9b34"), "MEDIA LUNA" },
                    { new Guid("179092b3-3ee1-43eb-a81e-e42ec359adfd"), "SERVILLETERO JUAN VALDES" },
                    { new Guid("1edb1dc3-078b-4170-a0bb-896ed3e0e883"), "SERVILLETERO ROMBO" },
                    { new Guid("23ba186c-3793-46b8-a58c-8cd3398ff1e4"), "PUEBLITO PAISA" },
                    { new Guid("25eadf3c-665c-482e-8a13-9b3d42b66463"), "BARCO COPAS UN TRAGO" },
                    { new Guid("2bdf07ce-39c1-4c16-9ac7-8fdccf4af4ce"), "FORRO CUERO" },
                    { new Guid("33127463-2b78-4e3e-9e15-daaf76920af3"), "TELAR" },
                    { new Guid("3a01e83c-cd94-4d60-a886-aa05ce1bd6b2"), "TAGUA MULTICOLOR" },
                    { new Guid("42359aa0-ac34-401d-8d15-bf1f6688b6d0"), "BOTERO" },
                    { new Guid("466d23e9-9e29-4c78-98f1-90592032c774"), "CHIVA BAR MINI" },
                    { new Guid("51e4466b-31ae-48e3-96ee-d53314dceb04"), "CUERO" },
                    { new Guid("582f4bca-bb05-4bf4-a833-b44e81a862d2"), "DISEÑO CRISTAL" },
                    { new Guid("62abc136-e744-4eb1-b25a-7cf8e776f75f"), "COLGAR CUERO" },
                    { new Guid("62b65e1e-132f-4991-aa97-87f7615bb66f"), "BORDADA" },
                    { new Guid("6db4d206-c71d-40ef-82bb-5eae5d435563"), "CHIVA" },
                    { new Guid("75f1c417-1bfa-4dab-8cb0-c2d17bad3f97"), "DESTAPADOR" },
                    { new Guid("83953d5a-81cd-4652-9c5a-54712b32a477"), "SOMBRERO" },
                    { new Guid("8db0bb97-f4d8-482b-ab74-a122ef68d83c"), "UN TRAGO" },
                    { new Guid("97ae7023-1ddc-4c49-b1ee-c655763d343b"), "GUATAPE" },
                    { new Guid("99478d56-10e6-4975-9b6b-459eced55226"), "FLORES" },
                    { new Guid("a259d3ca-5546-4e9c-a10b-4c7d6eb57106"), "ESTUCHE" },
                    { new Guid("a7177299-67ce-4dfa-8297-75c2209b8607"), "DISEÑO OPALIZADA" },
                    { new Guid("a77b8975-ceaa-4d82-b3b0-e045c1044ee9"), "CARRETA BAR MINI" },
                    { new Guid("a794799b-9e72-4017-bddf-1200b3014621"), "RECTANGULO" },
                    { new Guid("b27a54df-9f69-4361-820c-63d433b7190d"), "MARCO" },
                    { new Guid("bc96b721-86ae-49d9-83b8-385b7116ee6d"), "COLLAGE" },
                    { new Guid("be64776e-307c-4dd3-b45d-5b6ae64441c8"), "CORTAUÑA" },
                    { new Guid("c02637a3-ae54-45e5-a012-78abba3156e8"), "PLATOS CERAMICA" },
                    { new Guid("c469684c-284d-4076-93ee-b1fe178dd584"), "RECINA" },
                    { new Guid("cfadbd49-6943-4c4a-82e2-d46e9f436e2a"), "GATO" },
                    { new Guid("d14962a2-917f-4f55-8362-9f79b629a4ef"), "COPA MINI" },
                    { new Guid("dfbd09ed-74a1-4d82-82f7-0b16115883f2"), "FINAS" },
                    { new Guid("dfe08ea5-6722-4bcb-9e32-6ce9e69e6e44"), "ESPEJO" },
                    { new Guid("e384d0c3-f99d-44e4-a694-c0b13e201f06"), "HUEVO" },
                    { new Guid("e5838980-58cf-46f0-9016-848919a56f3e"), "METAL" },
                    { new Guid("ea67017f-44b1-4769-8283-c4408273c96a"), "MALLA" },
                    { new Guid("ecfd59c1-bf4b-4cac-9365-0993a47cec39"), "PIRAMIDE" },
                    { new Guid("f1404373-b654-403e-b91d-9a241c0ccfbc"), "TINTERO" },
                    { new Guid("f6346c1f-4829-459a-b0bf-686ba96bdf41"), "SERVILLETERO MORA" },
                    { new Guid("fd0ad594-5276-422b-ba21-575e7fb00fd9"), "DOBLE APLIQUE" }
                });

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
                name: "Products");

            migrationBuilder.DropTable(
                name: "FamilyType");

            migrationBuilder.DropTable(
                name: "Family");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropTable(
                name: "SubFamily");
        }
    }
}
