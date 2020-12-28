using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class CreateAzureDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Username = table.Column<string>(type: "varchar(50)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    Phone = table.Column<long>(type: "bigint", nullable: false),
                    Role = table.Column<string>(type: "char(10)", nullable: false),
                    HashedPassword = table.Column<byte[]>(type: "binary(32)", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "VehicleModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "varchar(50)", nullable: false),
                    Model = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(type: "int", nullable: false),
                    UploaderUsername = table.Column<string>(type: "varchar(50)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false, computedColumnSql: "getdate()"),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    Used = table.Column<bool>(type: "bit", nullable: false),
                    Purchased_Year = table.Column<int>(type: "int", nullable: true),
                    Purchased_Month = table.Column<int>(type: "int", nullable: true),
                    Engine_Hp = table.Column<int>(type: "int", nullable: false),
                    Engine_Kw = table.Column<int>(type: "int", nullable: false),
                    Engine_Volume = table.Column<float>(type: "real", nullable: true),
                    Engine_Type = table.Column<int>(type: "int", nullable: false),
                    Engine_FuelType = table.Column<int>(type: "int", nullable: false),
                    Engine_EuroEmissionsStandard = table.Column<int>(type: "int", nullable: true),
                    Engine_NumberOfCylinders = table.Column<int>(type: "int", nullable: true),
                    Gearbox_GearboxType = table.Column<int>(type: "int", nullable: true),
                    Gearbox_NumberOfGears = table.Column<int>(type: "int", nullable: true),
                    ChassisType = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "char(20)", nullable: false),
                    KilometersDriven = table.Column<int>(type: "int", nullable: false),
                    DriveWheels = table.Column<int>(type: "int", nullable: false),
                    SteeringWheelSide = table.Column<int>(type: "int", nullable: false),
                    NumberOfDoors = table.Column<int>(type: "int", nullable: false),
                    Seats = table.Column<int>(type: "int", nullable: false),
                    NextVehicleInspection_Year = table.Column<int>(type: "int", nullable: true),
                    NextVehicleInspection_Month = table.Column<int>(type: "int", nullable: true),
                    WheelSize = table.Column<string>(type: "char(20)", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    OriginalPurchaseCountry = table.Column<string>(type: "varchar(50)", nullable: true),
                    Vin = table.Column<string>(type: "char(17)", nullable: true),
                    Defects = table.Column<string>(type: "varchar(200)", nullable: true),
                    AdditionalProperties = table.Column<string>(type: "varchar(200)", nullable: true),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "varchar(1000)", nullable: true),
                    Hidden = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Users_UploaderUsername",
                        column: x => x.UploaderUsername,
                        principalTable: "Users",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleModels_ModelId",
                        column: x => x.ModelId,
                        principalTable: "VehicleModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserLikedAds",
                columns: table => new
                {
                    LikedAdsId = table.Column<int>(type: "int", nullable: false),
                    LikedByUsername = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLikedAds", x => new { x.LikedAdsId, x.LikedByUsername });
                    table.ForeignKey(
                        name: "FK_UserLikedAds_Users_LikedByUsername",
                        column: x => x.LikedByUsername,
                        principalTable: "Users",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLikedAds_Vehicles_LikedAdsId",
                        column: x => x.LikedAdsId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserLikedAds_LikedByUsername",
                table: "UserLikedAds",
                column: "LikedByUsername");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ModelId",
                table: "Vehicles",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_UploaderUsername",
                table: "Vehicles",
                column: "UploaderUsername");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLikedAds");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "VehicleModels");
        }
    }
}
