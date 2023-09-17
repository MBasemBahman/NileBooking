using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountStates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ColorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ColorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookingStates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ColorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DashboardAccessLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateAccess = table.Column<bool>(type: "bit", nullable: false),
                    EditAccess = table.Column<bool>(type: "bit", nullable: false),
                    ViewAccess = table.Column<bool>(type: "bit", nullable: false),
                    DeleteAccess = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardAccessLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DashboardAdministrationRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardAdministrationRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DashboardViews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ViewPath = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardViews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HotelFeatureCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelFeatureCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HotelTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "roomFoodTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ColorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roomFoodTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ColorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacebookToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwitterToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppleToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedInToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstagramToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Culture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsExternalLogin = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountStateLang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fk_Source = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountStateLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountStateLang_AccountStates_Fk_Source",
                        column: x => x.Fk_Source,
                        principalTable: "AccountStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountTypeLang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fk_Source = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypeLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountTypeLang_AccountTypes_Fk_Source",
                        column: x => x.Fk_Source,
                        principalTable: "AccountTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingStateLang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fk_Source = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingStateLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingStateLang_BookingStates_Fk_Source",
                        column: x => x.Fk_Source,
                        principalTable: "BookingStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_Country = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Areas_Countries_Fk_Country",
                        column: x => x.Fk_Country,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryLang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fk_Source = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryLang_Countries_Fk_Source",
                        column: x => x.Fk_Source,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DashboardAccessLevelLang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    Fk_Source = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardAccessLevelLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DashboardAccessLevelLang_DashboardAccessLevels_Fk_Source",
                        column: x => x.Fk_Source,
                        principalTable: "DashboardAccessLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DashboardAdministrationRoleLang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    Fk_Source = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardAdministrationRoleLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DashboardAdministrationRoleLang_DashboardAdministrationRoles_Fk_Source",
                        column: x => x.Fk_Source,
                        principalTable: "DashboardAdministrationRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdministrationRolePremissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_DashboardAccessLevel = table.Column<int>(type: "int", nullable: false),
                    Fk_DashboardAdministrationRole = table.Column<int>(type: "int", nullable: false),
                    Fk_DashboardView = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministrationRolePremissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdministrationRolePremissions_DashboardAccessLevels_Fk_DashboardAccessLevel",
                        column: x => x.Fk_DashboardAccessLevel,
                        principalTable: "DashboardAccessLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdministrationRolePremissions_DashboardAdministrationRoles_Fk_DashboardAdministrationRole",
                        column: x => x.Fk_DashboardAdministrationRole,
                        principalTable: "DashboardAdministrationRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdministrationRolePremissions_DashboardViews_Fk_DashboardView",
                        column: x => x.Fk_DashboardView,
                        principalTable: "DashboardViews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DashboardViewLang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    Fk_Source = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardViewLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DashboardViewLang_DashboardViews_Fk_Source",
                        column: x => x.Fk_Source,
                        principalTable: "DashboardViews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelFeatureCategoryLang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fk_Source = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelFeatureCategoryLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelFeatureCategoryLang_HotelFeatureCategories_Fk_Source",
                        column: x => x.Fk_Source,
                        principalTable: "HotelFeatureCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_HotelFeatureCategory = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelFeatures_HotelFeatureCategories_Fk_HotelFeatureCategory",
                        column: x => x.Fk_HotelFeatureCategory,
                        principalTable: "HotelFeatureCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelTypeLang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fk_Source = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelTypeLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelTypeLang_HotelTypes_Fk_Source",
                        column: x => x.Fk_Source,
                        principalTable: "HotelTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomFoodTypeLang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fk_Source = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomFoodTypeLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomFoodTypeLang_roomFoodTypes_Fk_Source",
                        column: x => x.Fk_Source,
                        principalTable: "roomFoodTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypeLang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fk_Source = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypeLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomTypeLang_RoomTypes_Fk_Source",
                        column: x => x.Fk_Source,
                        principalTable: "RoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_User = table.Column<int>(type: "int", nullable: false),
                    Fk_AccountType = table.Column<int>(type: "int", nullable: false),
                    Fk_AccountState = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_AccountStates_Fk_AccountState",
                        column: x => x.Fk_AccountState,
                        principalTable: "AccountStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_AccountTypes_Fk_AccountType",
                        column: x => x.Fk_AccountType,
                        principalTable: "AccountTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_Users_Fk_User",
                        column: x => x.Fk_User,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DashboardAdministrators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_User = table.Column<int>(type: "int", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fk_DashboardAdministrationRole = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardAdministrators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DashboardAdministrators_DashboardAdministrationRoles_Fk_DashboardAdministrationRole",
                        column: x => x.Fk_DashboardAdministrationRole,
                        principalTable: "DashboardAdministrationRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DashboardAdministrators_Users_Fk_User",
                        column: x => x.Fk_User,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_User = table.Column<int>(type: "int", nullable: false),
                    NotificationToken = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeviceType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Devices_Users_Fk_User",
                        column: x => x.Fk_User,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_User = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Revoked = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RevokedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReplacedByToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonRevoked = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_Fk_User",
                        column: x => x.Fk_User,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Verifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_User = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Verifications_Users_Fk_User",
                        column: x => x.Fk_User,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AreaLang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fk_Source = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AreaLang_Areas_Fk_Source",
                        column: x => x.Fk_Source,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fk_HotelType = table.Column<int>(type: "int", nullable: false),
                    Fk_Area = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotels_Areas_Fk_Area",
                        column: x => x.Fk_Area,
                        principalTable: "Areas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hotels_HotelTypes_Fk_HotelType",
                        column: x => x.Fk_HotelType,
                        principalTable: "HotelTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelFeatureLang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fk_Source = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelFeatureLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelFeatureLang_HotelFeatures_Fk_Source",
                        column: x => x.Fk_Source,
                        principalTable: "HotelFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_Account = table.Column<int>(type: "int", nullable: false),
                    Fk_Hotel = table.Column<int>(type: "int", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fk_BookingState = table.Column<int>(type: "int", nullable: false),
                    TotalRoomPrice = table.Column<double>(type: "float", nullable: false),
                    TotalExtraPrice = table.Column<double>(type: "float", nullable: false),
                    Fees = table.Column<double>(type: "float", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Accounts_Fk_Account",
                        column: x => x.Fk_Account,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_BookingStates_Fk_BookingState",
                        column: x => x.Fk_BookingState,
                        principalTable: "BookingStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Hotels_Fk_Hotel",
                        column: x => x.Fk_Hotel,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_Hotel = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileLength = table.Column<double>(type: "float", nullable: false),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelAttachments_Hotels_Fk_Hotel",
                        column: x => x.Fk_Hotel,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelExtraPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_Hotel = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelExtraPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelExtraPrices_Hotels_Fk_Hotel",
                        column: x => x.Fk_Hotel,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelLang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fk_Source = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelLang_Hotels_Fk_Source",
                        column: x => x.Fk_Source,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_Hotel = table.Column<int>(type: "int", nullable: false),
                    Fk_RoomType = table.Column<int>(type: "int", nullable: false),
                    Fk_RoomFoodType = table.Column<int>(type: "int", nullable: false),
                    MaxCount = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelRooms_Hotels_Fk_Hotel",
                        column: x => x.Fk_Hotel,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelRooms_RoomTypes_Fk_RoomType",
                        column: x => x.Fk_RoomType,
                        principalTable: "RoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelRooms_roomFoodTypes_Fk_RoomFoodType",
                        column: x => x.Fk_RoomFoodType,
                        principalTable: "roomFoodTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelSelectedFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_Hotel = table.Column<int>(type: "int", nullable: false),
                    Fk_HotelFeature = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelSelectedFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelSelectedFeatures_HotelFeatures_Fk_HotelFeature",
                        column: x => x.Fk_HotelFeature,
                        principalTable: "HotelFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelSelectedFeatures_Hotels_Fk_Hotel",
                        column: x => x.Fk_Hotel,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_Booking = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingReviews_Bookings_Fk_Booking",
                        column: x => x.Fk_Booking,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelExtraPriceLang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fk_Source = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelExtraPriceLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelExtraPriceLang_HotelExtraPrices_Fk_Source",
                        column: x => x.Fk_Source,
                        principalTable: "HotelExtraPrices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_Booking = table.Column<int>(type: "int", nullable: false),
                    Fk_HotelRoom = table.Column<int>(type: "int", nullable: false),
                    AdultCount = table.Column<int>(type: "int", nullable: false),
                    ChildCount = table.Column<int>(type: "int", nullable: false),
                    TotalAdultPrice = table.Column<double>(type: "float", nullable: false),
                    TotalChildPrice = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingRooms_Bookings_Fk_Booking",
                        column: x => x.Fk_Booking,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingRooms_HotelRooms_Fk_HotelRoom",
                        column: x => x.Fk_HotelRoom,
                        principalTable: "HotelRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HotelRoomPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_HotelRoom = table.Column<int>(type: "int", nullable: false),
                    AdultPrice = table.Column<double>(type: "float", nullable: false),
                    ChildPrice = table.Column<double>(type: "float", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelRoomPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelRoomPrices_HotelRooms_Fk_HotelRoom",
                        column: x => x.Fk_HotelRoom,
                        principalTable: "HotelRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingRoomExtras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_BookingRoom = table.Column<int>(type: "int", nullable: false),
                    Fk_HotelExtra = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingRoomExtras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingRoomExtras_BookingRooms_Fk_BookingRoom",
                        column: x => x.Fk_BookingRoom,
                        principalTable: "BookingRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingRoomExtras_HotelExtraPrices_Fk_HotelExtra",
                        column: x => x.Fk_HotelExtra,
                        principalTable: "HotelExtraPrices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AccountStates",
                columns: new[] { "Id", "ColorCode", "Name" },
                values: new object[,]
                {
                    { 1, null, "Active" },
                    { 2, null, "Pending" },
                    { 3, null, "Ban" }
                });

            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "Id", "ColorCode", "Name" },
                values: new object[] { 1, null, "Client" });

            migrationBuilder.InsertData(
                table: "BookingStates",
                columns: new[] { "Id", "ColorCode", "Name" },
                values: new object[,]
                {
                    { 1, null, "Pending" },
                    { 2, null, "Confirmed" },
                    { 3, null, "Cancelled" },
                    { 4, null, "Completed" },
                    { 5, null, "Refunded" }
                });

            migrationBuilder.InsertData(
                table: "DashboardAccessLevels",
                columns: new[] { "Id", "CreateAccess", "DeleteAccess", "EditAccess", "Name", "ViewAccess" },
                values: new object[,]
                {
                    { 1, true, true, true, "FullAccess", true },
                    { 2, true, false, true, "DataControl", true },
                    { 3, false, false, false, "Viewer", true }
                });

            migrationBuilder.InsertData(
                table: "DashboardAdministrationRoles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Developer" });

            migrationBuilder.InsertData(
                table: "DashboardViews",
                columns: new[] { "Id", "Name", "ViewPath" },
                values: new object[,]
                {
                    { 1, "Home", "Home" },
                    { 2, "User", "User" },
                    { 3, "DashboardAdministrator", "DashboardAdministrator" },
                    { 4, "DashboardAccessLevel", "DashboardAccessLevel" },
                    { 5, "DashboardAdministrationRole", "DashboardAdministrationRole" },
                    { 6, "DashboardView", "DashboardView" },
                    { 7, "RefreshToken", "RefreshToken" },
                    { 8, "UserDevice", "UserDevice" },
                    { 9, "Verification", "Verification" }
                });

            migrationBuilder.InsertData(
                table: "HotelTypes",
                columns: new[] { "Id", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, null, "Hotel" },
                    { 2, null, "Resort" },
                    { 3, null, "Apartment" },
                    { 4, null, "Hostel" },
                    { 6, null, "Villa" },
                    { 7, null, "Motel" }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "ColorCode", "Name" },
                values: new object[,]
                {
                    { 1, null, "Single" },
                    { 2, null, "Double" },
                    { 3, null, "Triple" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AppleToken", "Culture", "EmailAddress", "FacebookToken", "FirstName", "GoogleToken", "InstagramToken", "IsExternalLogin", "LastModifiedBy", "LastName", "LinkedInToken", "OtherToken", "Password", "PhoneNumber", "TwitterToken", "UserName" },
                values: new object[] { 1, null, null, "user@mail.com", null, "Developer", null, null, false, null, "Account", null, null, "$2a$11$jWCzmQ3YtZj59iCIjDtUSu8MHJ9ldwWrC37.cyOeQZCoVszefAtjC", null, null, "Developer" });

            migrationBuilder.InsertData(
                table: "roomFoodTypes",
                columns: new[] { "Id", "ColorCode", "Name" },
                values: new object[,]
                {
                    { 1, null, "BedAndBreakfast" },
                    { 2, null, "HalfBoard" },
                    { 3, null, "FullBoard" },
                    { 4, null, "AllInclusive" },
                    { 5, null, "RoomOnly" }
                });

            migrationBuilder.InsertData(
                table: "AccountStateLang",
                columns: new[] { "Id", "Fk_Source", "Language", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, 1, 0, null, "Active" },
                    { 2, 2, 0, null, "Pending" },
                    { 3, 3, 0, null, "Ban" },
                    { 4, 1, 1, null, "Active" },
                    { 5, 2, 1, null, "Pending" },
                    { 6, 3, 1, null, "Ban" }
                });

            migrationBuilder.InsertData(
                table: "AccountTypeLang",
                columns: new[] { "Id", "Fk_Source", "Language", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, 1, 0, null, "Client" },
                    { 2, 1, 1, null, "Client" }
                });

            migrationBuilder.InsertData(
                table: "AdministrationRolePremissions",
                columns: new[] { "Id", "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 1, 1, 2 },
                    { 3, 1, 1, 3 },
                    { 4, 1, 1, 4 },
                    { 5, 1, 1, 5 },
                    { 6, 1, 1, 6 },
                    { 7, 1, 1, 7 },
                    { 8, 1, 1, 8 },
                    { 9, 1, 1, 9 }
                });

            migrationBuilder.InsertData(
                table: "BookingStateLang",
                columns: new[] { "Id", "Fk_Source", "Language", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, 1, 0, null, "Pending" },
                    { 2, 2, 0, null, "Confirmed" },
                    { 3, 3, 0, null, "Cancelled" },
                    { 4, 4, 0, null, "Completed" },
                    { 5, 5, 0, null, "Refunded" },
                    { 6, 1, 1, null, "Pending" },
                    { 7, 2, 1, null, "Confirmed" },
                    { 8, 3, 1, null, "Cancelled" },
                    { 9, 4, 1, null, "Completed" },
                    { 10, 5, 1, null, "Refunded" }
                });

            migrationBuilder.InsertData(
                table: "DashboardAdministrationRoleLang",
                columns: new[] { "Id", "Fk_Source", "Language", "Name" },
                values: new object[,]
                {
                    { 1, 1, 0, "Developer" },
                    { 2, 1, 1, "Developer" }
                });

            migrationBuilder.InsertData(
                table: "DashboardAdministrators",
                columns: new[] { "Id", "Fk_DashboardAdministrationRole", "Fk_User", "JobTitle", "LastModifiedBy" },
                values: new object[] { 1, 1, 1, "Developer", null });

            migrationBuilder.InsertData(
                table: "HotelTypeLang",
                columns: new[] { "Id", "Fk_Source", "Language", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, 1, 0, null, "Hotel" },
                    { 2, 2, 0, null, "Resort" },
                    { 3, 3, 0, null, "Apartment" },
                    { 4, 4, 0, null, "Hostel" },
                    { 5, 6, 0, null, "Villa" },
                    { 6, 7, 0, null, "Motel" },
                    { 7, 1, 1, null, "Hotel" },
                    { 8, 2, 1, null, "Resort" },
                    { 9, 3, 1, null, "Apartment" },
                    { 10, 4, 1, null, "Hostel" },
                    { 11, 6, 1, null, "Villa" },
                    { 12, 7, 1, null, "Motel" }
                });

            migrationBuilder.InsertData(
                table: "RoomFoodTypeLang",
                columns: new[] { "Id", "Fk_Source", "Language", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, 1, 0, null, "BedAndBreakfast" },
                    { 2, 2, 0, null, "HalfBoard" },
                    { 3, 3, 0, null, "FullBoard" },
                    { 4, 4, 0, null, "AllInclusive" },
                    { 5, 5, 0, null, "RoomOnly" },
                    { 6, 1, 1, null, "BedAndBreakfast" },
                    { 7, 2, 1, null, "HalfBoard" },
                    { 8, 3, 1, null, "FullBoard" },
                    { 9, 4, 1, null, "AllInclusive" },
                    { 10, 5, 1, null, "RoomOnly" }
                });

            migrationBuilder.InsertData(
                table: "RoomTypeLang",
                columns: new[] { "Id", "Fk_Source", "Language", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, 1, 0, null, "Single" },
                    { 2, 2, 0, null, "Double" },
                    { 3, 3, 0, null, "Triple" },
                    { 4, 1, 1, null, "Single" },
                    { 5, 2, 1, null, "Double" },
                    { 6, 3, 1, null, "Triple" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Fk_AccountState",
                table: "Accounts",
                column: "Fk_AccountState");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Fk_AccountType",
                table: "Accounts",
                column: "Fk_AccountType");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Fk_User",
                table: "Accounts",
                column: "Fk_User",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountStateLang_Fk_Source",
                table: "AccountStateLang",
                column: "Fk_Source");

            migrationBuilder.CreateIndex(
                name: "IX_AccountStates_Name",
                table: "AccountStates",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountTypeLang_Fk_Source",
                table: "AccountTypeLang",
                column: "Fk_Source");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTypes_Name",
                table: "AccountTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdministrationRolePremissions_Fk_DashboardAccessLevel",
                table: "AdministrationRolePremissions",
                column: "Fk_DashboardAccessLevel");

            migrationBuilder.CreateIndex(
                name: "IX_AdministrationRolePremissions_Fk_DashboardAdministrationRole_Fk_DashboardView",
                table: "AdministrationRolePremissions",
                columns: new[] { "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdministrationRolePremissions_Fk_DashboardView",
                table: "AdministrationRolePremissions",
                column: "Fk_DashboardView");

            migrationBuilder.CreateIndex(
                name: "IX_AreaLang_Fk_Source",
                table: "AreaLang",
                column: "Fk_Source");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_Fk_Country",
                table: "Areas",
                column: "Fk_Country");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_Name",
                table: "Areas",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookingReviews_Fk_Booking",
                table: "BookingReviews",
                column: "Fk_Booking",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookingRoomExtras_Fk_BookingRoom",
                table: "BookingRoomExtras",
                column: "Fk_BookingRoom");

            migrationBuilder.CreateIndex(
                name: "IX_BookingRoomExtras_Fk_HotelExtra",
                table: "BookingRoomExtras",
                column: "Fk_HotelExtra");

            migrationBuilder.CreateIndex(
                name: "IX_BookingRooms_Fk_Booking",
                table: "BookingRooms",
                column: "Fk_Booking");

            migrationBuilder.CreateIndex(
                name: "IX_BookingRooms_Fk_HotelRoom",
                table: "BookingRooms",
                column: "Fk_HotelRoom");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_Fk_Account",
                table: "Bookings",
                column: "Fk_Account");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_Fk_BookingState",
                table: "Bookings",
                column: "Fk_BookingState");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_Fk_Hotel",
                table: "Bookings",
                column: "Fk_Hotel");

            migrationBuilder.CreateIndex(
                name: "IX_BookingStateLang_Fk_Source",
                table: "BookingStateLang",
                column: "Fk_Source");

            migrationBuilder.CreateIndex(
                name: "IX_BookingStates_Name",
                table: "BookingStates",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Name",
                table: "Countries",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CountryLang_Fk_Source",
                table: "CountryLang",
                column: "Fk_Source");

            migrationBuilder.CreateIndex(
                name: "IX_DashboardAccessLevelLang_Fk_Source",
                table: "DashboardAccessLevelLang",
                column: "Fk_Source");

            migrationBuilder.CreateIndex(
                name: "IX_DashboardAccessLevels_Name",
                table: "DashboardAccessLevels",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DashboardAdministrationRoleLang_Fk_Source",
                table: "DashboardAdministrationRoleLang",
                column: "Fk_Source");

            migrationBuilder.CreateIndex(
                name: "IX_DashboardAdministrationRoles_Name",
                table: "DashboardAdministrationRoles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DashboardAdministrators_Fk_DashboardAdministrationRole",
                table: "DashboardAdministrators",
                column: "Fk_DashboardAdministrationRole");

            migrationBuilder.CreateIndex(
                name: "IX_DashboardAdministrators_Fk_User",
                table: "DashboardAdministrators",
                column: "Fk_User",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DashboardViewLang_Fk_Source",
                table: "DashboardViewLang",
                column: "Fk_Source");

            migrationBuilder.CreateIndex(
                name: "IX_DashboardViews_Name",
                table: "DashboardViews",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DashboardViews_ViewPath",
                table: "DashboardViews",
                column: "ViewPath",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Devices_Fk_User",
                table: "Devices",
                column: "Fk_User");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_NotificationToken",
                table: "Devices",
                column: "NotificationToken",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HotelAttachments_Fk_Hotel",
                table: "HotelAttachments",
                column: "Fk_Hotel");

            migrationBuilder.CreateIndex(
                name: "IX_HotelExtraPriceLang_Fk_Source",
                table: "HotelExtraPriceLang",
                column: "Fk_Source");

            migrationBuilder.CreateIndex(
                name: "IX_HotelExtraPrices_Fk_Hotel",
                table: "HotelExtraPrices",
                column: "Fk_Hotel");

            migrationBuilder.CreateIndex(
                name: "IX_HotelExtraPrices_Name",
                table: "HotelExtraPrices",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HotelFeatureCategories_Name",
                table: "HotelFeatureCategories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HotelFeatureCategoryLang_Fk_Source",
                table: "HotelFeatureCategoryLang",
                column: "Fk_Source");

            migrationBuilder.CreateIndex(
                name: "IX_HotelFeatureLang_Fk_Source",
                table: "HotelFeatureLang",
                column: "Fk_Source");

            migrationBuilder.CreateIndex(
                name: "IX_HotelFeatures_Fk_HotelFeatureCategory",
                table: "HotelFeatures",
                column: "Fk_HotelFeatureCategory");

            migrationBuilder.CreateIndex(
                name: "IX_HotelFeatures_Name",
                table: "HotelFeatures",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HotelLang_Fk_Source",
                table: "HotelLang",
                column: "Fk_Source");

            migrationBuilder.CreateIndex(
                name: "IX_HotelRoomPrices_Fk_HotelRoom",
                table: "HotelRoomPrices",
                column: "Fk_HotelRoom");

            migrationBuilder.CreateIndex(
                name: "IX_HotelRooms_Fk_Hotel",
                table: "HotelRooms",
                column: "Fk_Hotel");

            migrationBuilder.CreateIndex(
                name: "IX_HotelRooms_Fk_RoomFoodType",
                table: "HotelRooms",
                column: "Fk_RoomFoodType");

            migrationBuilder.CreateIndex(
                name: "IX_HotelRooms_Fk_RoomType",
                table: "HotelRooms",
                column: "Fk_RoomType");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_Fk_Area",
                table: "Hotels",
                column: "Fk_Area");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_Fk_HotelType",
                table: "Hotels",
                column: "Fk_HotelType");

            migrationBuilder.CreateIndex(
                name: "IX_HotelSelectedFeatures_Fk_Hotel",
                table: "HotelSelectedFeatures",
                column: "Fk_Hotel");

            migrationBuilder.CreateIndex(
                name: "IX_HotelSelectedFeatures_Fk_HotelFeature",
                table: "HotelSelectedFeatures",
                column: "Fk_HotelFeature");

            migrationBuilder.CreateIndex(
                name: "IX_HotelTypeLang_Fk_Source",
                table: "HotelTypeLang",
                column: "Fk_Source");

            migrationBuilder.CreateIndex(
                name: "IX_HotelTypes_Name",
                table: "HotelTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_Fk_User",
                table: "RefreshTokens",
                column: "Fk_User");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_Token",
                table: "RefreshTokens",
                column: "Token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoomFoodTypeLang_Fk_Source",
                table: "RoomFoodTypeLang",
                column: "Fk_Source");

            migrationBuilder.CreateIndex(
                name: "IX_roomFoodTypes_Name",
                table: "roomFoodTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoomTypeLang_Fk_Source",
                table: "RoomTypeLang",
                column: "Fk_Source");

            migrationBuilder.CreateIndex(
                name: "IX_RoomTypes_Name",
                table: "RoomTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Verifications_Code",
                table: "Verifications",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Verifications_Fk_User",
                table: "Verifications",
                column: "Fk_User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountStateLang");

            migrationBuilder.DropTable(
                name: "AccountTypeLang");

            migrationBuilder.DropTable(
                name: "AdministrationRolePremissions");

            migrationBuilder.DropTable(
                name: "AreaLang");

            migrationBuilder.DropTable(
                name: "BookingReviews");

            migrationBuilder.DropTable(
                name: "BookingRoomExtras");

            migrationBuilder.DropTable(
                name: "BookingStateLang");

            migrationBuilder.DropTable(
                name: "CountryLang");

            migrationBuilder.DropTable(
                name: "DashboardAccessLevelLang");

            migrationBuilder.DropTable(
                name: "DashboardAdministrationRoleLang");

            migrationBuilder.DropTable(
                name: "DashboardAdministrators");

            migrationBuilder.DropTable(
                name: "DashboardViewLang");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "HotelAttachments");

            migrationBuilder.DropTable(
                name: "HotelExtraPriceLang");

            migrationBuilder.DropTable(
                name: "HotelFeatureCategoryLang");

            migrationBuilder.DropTable(
                name: "HotelFeatureLang");

            migrationBuilder.DropTable(
                name: "HotelLang");

            migrationBuilder.DropTable(
                name: "HotelRoomPrices");

            migrationBuilder.DropTable(
                name: "HotelSelectedFeatures");

            migrationBuilder.DropTable(
                name: "HotelTypeLang");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "RoomFoodTypeLang");

            migrationBuilder.DropTable(
                name: "RoomTypeLang");

            migrationBuilder.DropTable(
                name: "Verifications");

            migrationBuilder.DropTable(
                name: "BookingRooms");

            migrationBuilder.DropTable(
                name: "DashboardAccessLevels");

            migrationBuilder.DropTable(
                name: "DashboardAdministrationRoles");

            migrationBuilder.DropTable(
                name: "DashboardViews");

            migrationBuilder.DropTable(
                name: "HotelExtraPrices");

            migrationBuilder.DropTable(
                name: "HotelFeatures");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "HotelRooms");

            migrationBuilder.DropTable(
                name: "HotelFeatureCategories");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "BookingStates");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "RoomTypes");

            migrationBuilder.DropTable(
                name: "roomFoodTypes");

            migrationBuilder.DropTable(
                name: "AccountStates");

            migrationBuilder.DropTable(
                name: "AccountTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "HotelTypes");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
