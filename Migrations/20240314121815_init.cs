using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApartmentFinder.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street1 = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Street2 = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressID);
                });

            migrationBuilder.CreateTable(
                name: "Amenities",
                columns: table => new
                {
                    AmenityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenities", x => x.AmenityID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    InternalUserID = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Leases",
                columns: table => new
                {
                    ListingID = table.Column<int>(type: "int", nullable: false),
                    TenantID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leases", x => new { x.ListingID, x.TenantID });
                });

            migrationBuilder.CreateTable(
                name: "ListingAmenities",
                columns: table => new
                {
                    ListingID = table.Column<int>(type: "int", nullable: false),
                    AmenityID = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListingAmenities", x => new { x.ListingID, x.AmenityID });
                });

            migrationBuilder.CreateTable(
                name: "Listings",
                columns: table => new
                {
                    ListingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerID = table.Column<int>(type: "int", nullable: false),
                    AddressID = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    Bedrooms = table.Column<int>(type: "int", nullable: false),
                    Bathrooms = table.Column<int>(type: "int", nullable: false),
                    SquareFoot = table.Column<float>(type: "real", nullable: false),
                    DateAvailable = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Months = table.Column<int>(type: "int", nullable: false),
                    MonthlyRate = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listings", x => x.ListingID);
                });

            migrationBuilder.CreateTable(
                name: "ListingUtilities",
                columns: table => new
                {
                    ServiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilityID = table.Column<int>(type: "int", nullable: false),
                    ListingID = table.Column<int>(type: "int", nullable: false),
                    UtilitiesEstimate = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListingUtilities", x => x.ServiceID);
                });

            migrationBuilder.CreateTable(
                name: "Utilities",
                columns: table => new
                {
                    UtilityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilityType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    EstMonRate = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilities", x => x.UtilityID);
                });

            migrationBuilder.CreateTable(
                name: "ZipCodes",
                columns: table => new
                {
                    ZipCode = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZipCodes", x => x.ZipCode);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressID", "Street1", "Street2", "ZipCode" },
                values: new object[,]
                {
                    { 1, "123 Main St", null, "32501" },
                    { 2, "456 Elm St", null, "32501" },
                    { 3, "222 Maple Ave", null, "32505" },
                    { 4, "333 Cedar St", null, "32505" },
                    { 5, "777 Walnut St", null, "32509" },
                    { 6, "888 Chestnut St", null, "32509" },
                    { 7, "999 Willow St", "Suite 100", "32514" },
                    { 8, "222 Elmwood Dr", null, "32514" },
                    { 9, "333 Oakwood Dr", null, "32514" },
                    { 10, "444 Pinecrest Ln", null, "32526" },
                    { 11, "555 Cedarwood Ln", null, "32526" },
                    { 12, "123 Beach Blvd", null, "32561" },
                    { 13, "456 Seaside Dr", null, "32561" },
                    { 14, "222 Shoreline Dr", null, "32566" },
                    { 15, "333 Coastal Way", null, "32566" },
                    { 16, "444 Harbor View Dr", null, "32571" },
                    { 17, "555 Bayfront Ave", null, "32571" },
                    { 18, "999 Sailboat Cir", "2nd Floor", "32591" },
                    { 19, "111 Anchor Dr", "Building B", "32591" }
                });

            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "AmenityID", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Outdoor pool available for residents.", "Swimming Pool" },
                    { 2, "Fully-equipped fitness center with cardio and strength training equipment.", "Fitness Center" },
                    { 3, "On-site dog park for residents with pets.", "Dog Park" },
                    { 4, "Well-maintained tennis court available for resident use.", "Tennis Court" },
                    { 5, "Spacious clubhouse with social areas and events for residents.", "Clubhouse" },
                    { 6, "On-site business center with computers, printers, and meeting rooms.", "Business Center" },
                    { 7, "Outdoor playground area for children.", "Playground" },
                    { 8, "On-site pet grooming station with bathing facilities.", "Pet Spa" },
                    { 9, "Dedicated yoga studio for residents to practice yoga and meditation.", "Yoga Studio" },
                    { 10, "Outdoor grilling and picnic area for resident use.", "Grilling Area" },
                    { 11, "Game room with billiards, foosball, and other entertainment options.", "Game Room" },
                    { 12, "Secure bike storage area for residents.", "Bike Storage" },
                    { 13, "On-site movie theater with regular movie screenings.", "Movie Theater" },
                    { 14, "Relaxing sauna available for resident use.", "Sauna" },
                    { 15, "Convenient car wash station for residents.", "Car Wash Station" },
                    { 16, "Scenic roof deck with panoramic views of the city.", "Roof Deck" },
                    { 17, "Daily valet trash service for residents' convenience.", "Valet Trash Service" },
                    { 18, "Secure gated entry with controlled access for residents.", "Gated Entry" },
                    { 19, "Package lockers for secure delivery and retrieval of packages.", "Package Lockers" },
                    { 20, "24-hour emergency maintenance service for residents.", "24-Hour Maintenance" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "InternalUserID", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0c510bf1-bbf4-4338-8ebb-55a8f5cf8637", 0, "031fefeb-3776-4b67-b1ea-493d2dfb8c01", "InternalUser", null, false, "David", 5, "Brown", false, null, null, null, null, null, false, "ea77b40d-3dd1-481d-9059-60ad8e001d68", false, null },
                    { "0eb31035-05e8-4036-b1b2-167c74822f97", 0, "a1756d14-3b94-44b7-9c3c-190f0b04d963", "InternalUser", null, false, "RyanUser", 2, "Southwell", false, null, null, null, null, null, false, "2f7c373b-bc05-4fd0-a627-aa661b4b5238", false, null },
                    { "18af29aa-8277-467d-94fb-0005bb79daf2", 0, "5a2c2a15-4dbb-49aa-954d-f82c1ac2940c", "InternalUser", null, false, "James", 13, "Anderson", false, null, null, null, null, null, false, "9031e55a-7682-4cf9-b95d-d9e7e3fd4d35", false, null },
                    { "1983219a-ca6c-4f4b-b798-9020bddb91c8", 0, "e08bf46f-c609-4deb-a91d-f21d9972b12d", "InternalUser", null, false, "Jessica", 12, "Wilson", false, null, null, null, null, null, false, "f3e1e598-4e6a-4d0e-833b-0aa6e7fb2673", false, null },
                    { "34acfa6b-df7c-4744-ac18-a2bea07fc896", 0, "ffa426c7-7645-4b40-9a07-bbcdba5c3fb1", "InternalUser", null, false, "Ryan", 17, "Jackson", false, null, null, null, null, null, false, "44030986-6480-41c5-8a56-3a0f8d1997d9", false, null },
                    { "3dde58e5-4eb3-40a7-8f0a-4cfc3b6e125d", 0, "2a8b35c4-fc97-4b2a-bde7-08a5fd1976ee", "InternalUser", null, false, "Michael", 3, "Johnson", false, null, null, null, null, null, false, "f26b4d5f-011d-4762-8512-f79e61e4bfa2", false, null },
                    { "3f4c2158-dc87-415d-a75b-6a9693aa67cf", 0, "6ce8fd14-c646-4378-b07a-55b797159b91", "InternalUser", null, false, "Sarah", 6, "Jones", false, null, null, null, null, null, false, "d388f88d-72ff-4961-a0b6-b6105a779a81", false, null },
                    { "47b99e84-4a80-40c6-8eb3-412f177ab86b", 0, "97a805ea-c22e-4083-9572-1d454e4ae7e4", "InternalUser", null, false, "Stephanie", 20, "Martin", false, null, null, null, null, null, false, "9acfab4e-b8d2-456a-a7d5-7f9ee34e7784", false, null },
                    { "520a8b55-34fd-4f63-a606-850660fb47af", 0, "92694286-9d00-460e-9f56-1d38eabb10b0", "InternalUser", null, false, "RyanAdmin", 1, "Southwell", false, null, null, null, null, null, false, "23a259ac-41f0-4ed9-a3e7-3a46575452cc", false, null },
                    { "62542426-ce5f-4d44-9e19-e5a2d8761a5e", 0, "02d72491-6600-4e54-b7b4-3c04ec2a9573", "InternalUser", null, false, "Daniel", 7, "Garcia", false, null, null, null, null, null, false, "d5ef986e-a2f7-4943-b7b6-a8c8e537b792", false, null },
                    { "7ec89834-14be-4be9-bfa2-0927e14e882e", 0, "c792cc4d-f236-40bf-9c66-93b3a86168e2", "InternalUser", null, false, "John", 21, "Doe", false, null, null, null, null, null, false, "3d0e9165-dae9-43da-bfd2-66d7f7e78dde", false, null },
                    { "914cc941-f476-42bb-96a9-aaf02c493310", 0, "b7cf730b-deb1-4865-a328-a0bd0effd4bf", "InternalUser", null, false, "Emily", 4, "Williams", false, null, null, null, null, null, false, "646127b9-bced-4d35-872e-8ae5fc59b724", false, null },
                    { "91697bcd-2f1d-4857-be33-e67eab1100d8", 0, "b087ecfc-e555-41ae-9616-36d81a1ecc83", "InternalUser", null, false, "Robert", 15, "Taylor", false, null, null, null, null, null, false, "cc338d23-486f-4e1e-9727-b1070ff5b832", false, null },
                    { "9d263bee-84ad-421f-bf34-5faee7cccded", 0, "d566f666-d238-4c07-ac5a-aa67356dcb84", "InternalUser", null, false, "Amanda", 16, "Moore", false, null, null, null, null, null, false, "e7032212-ebd5-46c8-89d5-ac729498a7e5", false, null },
                    { "b5a12cf8-fc1b-4419-b7aa-fd2cc6d9cd19", 0, "34757ae9-6f16-42dd-8237-1dcc86a34af6", "InternalUser", null, false, "Michelle", 18, "White", false, null, null, null, null, null, false, "72dd4886-c388-4b70-84da-f016fb552db5", false, null },
                    { "bfb8e405-0b54-4175-b110-620cd970e236", 0, "7bf6ddfd-557b-4161-8dc5-c7d6dcc17b77", "InternalUser", null, false, "Jennifer", 8, "Martinez", false, null, null, null, null, null, false, "3a07e232-b711-46ff-9b0f-aae8d87e0323", false, null },
                    { "d1fb8bb6-72ab-4535-b77e-9e34091cdb0b", 0, "b495e373-2f13-4b22-8388-9eeb1aa68020", "InternalUser", null, false, "William", 19, "Harris", false, null, null, null, null, null, false, "d02bd6f3-2ab9-4ec7-8e13-9318d7bdbd8f", false, null },
                    { "d6ab3f8e-a91b-4445-8cef-5bbbb923091d", 0, "ce56e3df-726a-4c29-b5a4-28440b7e42a2", "InternalUser", null, false, "Ashley", 14, "Thomas", false, null, null, null, null, null, false, "a2e03762-598b-4ad3-a39b-541dac676200", false, null },
                    { "d8f2e245-82ad-4bda-ae56-307ad38b8e32", 0, "59bfdfec-fb53-4ac7-9190-a92bfe7a77f5", "InternalUser", null, false, "Christopher", 9, "Hernandez", false, null, null, null, null, null, false, "d40d6d7f-a501-4775-a7cf-8c8b072bc5dc", false, null },
                    { "ebef3681-9c81-48b9-bee3-d79166b52081", 0, "d01cb59a-1754-4f66-aa21-6339654e39f2", "InternalUser", null, false, "Matthew", 11, "Gonzalez", false, null, null, null, null, null, false, "8b7944ae-ed1e-40c8-b010-c23554756b08", false, null },
                    { "fe2b0270-167e-4eab-8db0-f15772a69a69", 0, "c2c3c7c8-0824-4370-92cf-096aae4b5266", "InternalUser", null, false, "Lisa", 10, "Lopez", false, null, null, null, null, null, false, "e1fed37e-6afb-47c6-ae41-f90363019e92", false, null },
                    { "ff6027dd-ac2d-4377-8f79-3d518ec1581a", 0, "26313ddb-d564-4187-b2aa-00c7c05f8442", "InternalUser", null, false, "Jane", 22, "Smith", false, null, null, null, null, null, false, "b8d92c98-44c7-490a-9b94-47159bd1a6a2", false, null }
                });

            migrationBuilder.InsertData(
                table: "Leases",
                columns: new[] { "ListingID", "TenantID", "Status" },
                values: new object[,]
                {
                    { 3, 20, 2 },
                    { 4, 19, 2 },
                    { 5, 18, 2 },
                    { 6, 17, 3 },
                    { 7, 16, 2 },
                    { 8, 15, 0 },
                    { 9, 14, 3 },
                    { 10, 13, 3 },
                    { 11, 12, 0 },
                    { 12, 11, 0 },
                    { 13, 10, 3 },
                    { 14, 9, 0 },
                    { 15, 8, 3 },
                    { 16, 7, 0 },
                    { 17, 6, 0 },
                    { 18, 5, 0 },
                    { 19, 4, 0 },
                    { 20, 3, 0 },
                    { 21, 2, 3 },
                    { 22, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "ListingAmenities",
                columns: new[] { "AmenityID", "ListingID", "Notes" },
                values: new object[,]
                {
                    { 19, 21, "Iteration 1 of seed data" },
                    { 18, 22, "Iteration 2 of seed data" },
                    { 17, 23, "Iteration 3 of seed data" },
                    { 16, 24, "Iteration 4 of seed data" },
                    { 15, 25, "Iteration 5 of seed data" },
                    { 14, 26, "Iteration 6 of seed data" },
                    { 13, 27, "Iteration 7 of seed data" },
                    { 12, 28, "Iteration 8 of seed data" },
                    { 11, 29, "Iteration 9 of seed data" },
                    { 10, 30, "Iteration 10 of seed data" },
                    { 9, 31, "Iteration 11 of seed data" },
                    { 8, 32, "Iteration 12 of seed data" },
                    { 7, 33, "Iteration 13 of seed data" },
                    { 6, 34, "Iteration 14 of seed data" },
                    { 5, 35, "Iteration 15 of seed data" }
                });

            migrationBuilder.InsertData(
                table: "ListingUtilities",
                columns: new[] { "ServiceID", "ListingID", "UtilitiesEstimate", "UtilityID" },
                values: new object[,]
                {
                    { 1, 4, 487.991864699266000m, 4 },
                    { 2, 24, 137.302347516441500m, 9 },
                    { 3, 1, 95.483086102680500m, 9 },
                    { 4, 16, 327.865943139483000m, 9 },
                    { 5, 5, 28.8083806768298500m, 1 },
                    { 6, 31, 139.740532723405500m, 7 },
                    { 7, 10, 145.598472522938000m, 2 },
                    { 8, 1, 262.158318314923000m, 5 },
                    { 9, 36, 179.904993796139000m, 1 },
                    { 10, 30, 414.597545116867500m, 6 },
                    { 11, 1, 129.489192908635500m, 4 },
                    { 12, 20, 488.236561426852000m, 3 },
                    { 13, 34, 494.250506117614500m, 2 },
                    { 14, 17, 496.866414755059500m, 2 },
                    { 15, 14, 384.953832497559500m, 4 }
                });

            migrationBuilder.InsertData(
                table: "Listings",
                columns: new[] { "ListingID", "AddressID", "Bathrooms", "Bedrooms", "DateAvailable", "MonthlyRate", "Months", "OwnerID", "SquareFoot", "Unit" },
                values: new object[,]
                {
                    { 1, 16, 1, 3, new DateTime(2024, 4, 3, 7, 18, 14, 870, DateTimeKind.Local).AddTicks(6832), 1744m, 2, 5, 2098f, "Unit 1" },
                    { 2, 9, 1, 4, new DateTime(2024, 4, 4, 7, 18, 14, 870, DateTimeKind.Local).AddTicks(6919), 1182m, 10, 16, 2218f, "Unit 2" },
                    { 3, 7, 2, 1, new DateTime(2024, 4, 11, 7, 18, 14, 870, DateTimeKind.Local).AddTicks(6924), 1329m, 2, 4, 2480f, "Unit 3" },
                    { 4, 6, 1, 1, new DateTime(2024, 4, 8, 7, 18, 14, 870, DateTimeKind.Local).AddTicks(6929), 1858m, 8, 14, 2205f, "Unit 4" },
                    { 5, 17, 3, 3, new DateTime(2024, 4, 10, 7, 18, 14, 870, DateTimeKind.Local).AddTicks(6935), 2144m, 12, 16, 1970f, "Unit 5" },
                    { 6, 12, 1, 5, new DateTime(2024, 3, 17, 7, 18, 14, 870, DateTimeKind.Local).AddTicks(6943), 2840m, 8, 7, 2801f, "Unit 6" },
                    { 7, 13, 3, 5, new DateTime(2024, 3, 23, 7, 18, 14, 870, DateTimeKind.Local).AddTicks(6949), 657m, 5, 2, 886f, "Unit 7" },
                    { 8, 11, 2, 2, new DateTime(2024, 4, 3, 7, 18, 14, 870, DateTimeKind.Local).AddTicks(6954), 592m, 8, 6, 813f, "Unit 8" },
                    { 9, 4, 2, 4, new DateTime(2024, 3, 23, 7, 18, 14, 870, DateTimeKind.Local).AddTicks(6959), 2422m, 10, 6, 1832f, "Unit 9" },
                    { 10, 1, 1, 3, new DateTime(2024, 3, 30, 7, 18, 14, 870, DateTimeKind.Local).AddTicks(6965), 2714m, 7, 10, 2413f, "Unit 10" },
                    { 11, 12, 2, 3, new DateTime(2024, 3, 28, 7, 18, 14, 870, DateTimeKind.Local).AddTicks(6970), 1663m, 4, 5, 1142f, "Unit 11" },
                    { 12, 4, 2, 2, new DateTime(2024, 4, 13, 7, 18, 14, 870, DateTimeKind.Local).AddTicks(6975), 1012m, 3, 13, 920f, "Unit 12" },
                    { 13, 16, 1, 1, new DateTime(2024, 4, 10, 7, 18, 14, 870, DateTimeKind.Local).AddTicks(6980), 741m, 11, 3, 2689f, "Unit 13" },
                    { 14, 6, 3, 3, new DateTime(2024, 4, 9, 7, 18, 14, 870, DateTimeKind.Local).AddTicks(6985), 2591m, 3, 7, 2571f, "Unit 14" },
                    { 15, 13, 2, 3, new DateTime(2024, 3, 17, 7, 18, 14, 870, DateTimeKind.Local).AddTicks(6989), 2685m, 12, 12, 1147f, "Unit 15" },
                    { 16, 3, 3, 3, new DateTime(2024, 4, 4, 7, 18, 14, 870, DateTimeKind.Local).AddTicks(6994), 1983m, 7, 19, 1410f, "Unit 16" },
                    { 17, 1, 2, 3, new DateTime(2024, 4, 11, 7, 18, 14, 870, DateTimeKind.Local).AddTicks(6999), 628m, 9, 3, 2398f, "Unit 17" },
                    { 18, 16, 1, 3, new DateTime(2024, 4, 2, 7, 18, 14, 870, DateTimeKind.Local).AddTicks(7138), 990m, 9, 5, 1820f, "Unit 18" },
                    { 19, 14, 2, 1, new DateTime(2024, 3, 31, 7, 18, 14, 870, DateTimeKind.Local).AddTicks(7143), 2106m, 12, 16, 936f, "Unit 19" },
                    { 20, 7, 3, 3, new DateTime(2024, 4, 1, 7, 18, 14, 870, DateTimeKind.Local).AddTicks(7145), 605m, 11, 5, 907f, "Unit 20" },
                    { 21, 18, 2, 5, new DateTime(2024, 4, 2, 7, 18, 14, 870, DateTimeKind.Local).AddTicks(7148), 967m, 6, 10, 2500f, "Unit 21" },
                    { 22, 6, 3, 3, new DateTime(2024, 3, 19, 7, 18, 14, 870, DateTimeKind.Local).AddTicks(7150), 2569m, 9, 8, 2916f, "Unit 22" },
                    { 23, 16, 2, 2, new DateTime(2024, 4, 2, 7, 18, 14, 870, DateTimeKind.Local).AddTicks(7153), 2066m, 12, 10, 865f, "Unit 23" },
                    { 24, 6, 2, 2, new DateTime(2024, 4, 1, 7, 18, 14, 870, DateTimeKind.Local).AddTicks(7156), 1079m, 5, 5, 2366f, "Unit 24" },
                    { 25, 10, 2, 5, new DateTime(2024, 3, 29, 7, 18, 14, 870, DateTimeKind.Local).AddTicks(7160), 1431m, 8, 12, 1637f, "Unit 25" },
                    { 26, 10, 3, 4, new DateTime(2024, 4, 1, 7, 18, 14, 870, DateTimeKind.Local).AddTicks(7162), 634m, 2, 7, 1603f, "Unit 26" },
                    { 27, 15, 2, 1, new DateTime(2024, 3, 17, 7, 18, 14, 870, DateTimeKind.Local).AddTicks(7164), 1683m, 6, 1, 2189f, "Unit 27" },
                    { 28, 10, 3, 5, new DateTime(2024, 4, 3, 7, 18, 14, 870, DateTimeKind.Local).AddTicks(7166), 2841m, 9, 4, 950f, "Unit 28" },
                    { 29, 6, 1, 2, new DateTime(2024, 3, 23, 7, 18, 14, 870, DateTimeKind.Local).AddTicks(7169), 1814m, 5, 22, 2654f, "Unit 29" },
                    { 30, 17, 3, 3, new DateTime(2024, 3, 22, 7, 18, 14, 870, DateTimeKind.Local).AddTicks(7171), 792m, 1, 11, 916f, "Unit 30" },
                    { 31, 9, 2, 3, new DateTime(2024, 3, 20, 7, 18, 14, 870, DateTimeKind.Local).AddTicks(7173), 1258m, 6, 15, 1938f, "Unit 31" },
                    { 32, 12, 3, 3, new DateTime(2024, 4, 4, 7, 18, 14, 870, DateTimeKind.Local).AddTicks(7175), 1765m, 1, 3, 1216f, "Unit 32" },
                    { 33, 4, 2, 1, new DateTime(2024, 3, 29, 7, 18, 14, 870, DateTimeKind.Local).AddTicks(7177), 2524m, 5, 14, 2700f, "Unit 33" },
                    { 34, 6, 1, 4, new DateTime(2024, 4, 6, 7, 18, 14, 870, DateTimeKind.Local).AddTicks(7182), 2665m, 6, 11, 981f, "Unit 34" },
                    { 35, 5, 3, 2, new DateTime(2024, 3, 24, 7, 18, 14, 870, DateTimeKind.Local).AddTicks(7184), 674m, 9, 1, 869f, "Unit 35" },
                    { 36, 12, 1, 1, new DateTime(2024, 3, 25, 7, 18, 14, 870, DateTimeKind.Local).AddTicks(7186), 1407m, 1, 7, 1948f, "Unit 36" },
                    { 37, 12, 2, 2, new DateTime(2024, 3, 28, 7, 18, 14, 870, DateTimeKind.Local).AddTicks(7188), 2578m, 11, 4, 1980f, "Unit 37" },
                    { 38, 6, 3, 5, new DateTime(2024, 3, 23, 7, 18, 14, 870, DateTimeKind.Local).AddTicks(7190), 958m, 4, 10, 851f, "Unit 38" },
                    { 39, 12, 1, 2, new DateTime(2024, 3, 19, 7, 18, 14, 870, DateTimeKind.Local).AddTicks(7193), 2775m, 9, 11, 1424f, "Unit 39" },
                    { 40, 19, 3, 1, new DateTime(2024, 3, 29, 7, 18, 14, 870, DateTimeKind.Local).AddTicks(7195), 549m, 5, 7, 1151f, "Unit 40" }
                });

            migrationBuilder.InsertData(
                table: "Utilities",
                columns: new[] { "UtilityID", "EstMonRate", "Name", "UtilityType", "Website" },
                values: new object[,]
                {
                    { 1, 50.00m, "Gas Company A", 0, "http://www.gascompanya.com/" },
                    { 2, 70.00m, "Electric Company B", 1, "http://www.electriccompanyb.com/" },
                    { 3, 80.00m, "Cable Company C", 2, "http://www.cablecompanyc.com/" },
                    { 4, 40.00m, "Water Company D", 3, "http://www.watercompanyd.com/" },
                    { 5, 30.00m, "Garbage Company E", 4, "http://www.garbagecompanye.com/" },
                    { 6, 60.00m, "Telecom Company F", 5, "http://www.telecomcompanyf.com/" },
                    { 7, 55.00m, "Gas Company G", 0, "http://www.gascompanyg.com/" },
                    { 8, 75.00m, "Electric Company H", 1, "http://www.electriccompanyh.com/" },
                    { 9, 85.00m, "Cable Company I", 2, "http://www.cablecompanyi.com/" },
                    { 10, 45.00m, "Water Company J", 3, "http://www.watercompanyj.com/" }
                });

            migrationBuilder.InsertData(
                table: "ZipCodes",
                columns: new[] { "ZipCode", "City", "State" },
                values: new object[,]
                {
                    { "32501", "Pensacola", "FL" },
                    { "32505", "Pensacola", "FL" },
                    { "32509", "Pensacola", "FL" },
                    { "32514", "Pensacola", "FL" },
                    { "32526", "Pensacola", "FL" },
                    { "32561", "Gulf Breeze", "FL" },
                    { "32566", "Navarre", "FL" },
                    { "32571", "Milton", "FL" },
                    { "32591", "Milton", "FL" },
                    { "33954", "Port Charlotte", "FL" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Amenities");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Leases");

            migrationBuilder.DropTable(
                name: "ListingAmenities");

            migrationBuilder.DropTable(
                name: "Listings");

            migrationBuilder.DropTable(
                name: "ListingUtilities");

            migrationBuilder.DropTable(
                name: "Utilities");

            migrationBuilder.DropTable(
                name: "ZipCodes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
