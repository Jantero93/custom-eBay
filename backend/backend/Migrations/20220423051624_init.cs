using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backend.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    city = table.Column<string>(type: "text", nullable: false),
                    lat = table.Column<string>(type: "text", nullable: false),
                    lng = table.Column<string>(type: "text", nullable: false),
                    country = table.Column<string>(type: "text", nullable: false),
                    admin_name = table.Column<string>(type: "text", nullable: false),
                    population = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_locations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    username = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    password = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    firstname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    lastname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    phonenumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    locationid = table.Column<long>(type: "bigint", nullable: true),
                    role = table.Column<int>(type: "integer", nullable: false),
                    created = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                    table.ForeignKey(
                        name: "fk_users_locations_locationid",
                        column: x => x.locationid,
                        principalTable: "locations",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "salesarticles",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    itemcondition = table.Column<int>(type: "integer", nullable: false),
                    userid = table.Column<long>(type: "bigint", nullable: false),
                    locationid = table.Column<long>(type: "bigint", nullable: false),
                    created = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_salesarticles", x => x.id);
                    table.ForeignKey(
                        name: "fk_salesarticles_locations_locationid",
                        column: x => x.locationid,
                        principalTable: "locations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_salesarticles_users_userid",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "image",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    data = table.Column<byte[]>(type: "bytea", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    type = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    salesarticleid = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_image", x => x.id);
                    table.ForeignKey(
                        name: "fk_image_salesarticles_salesarticleid",
                        column: x => x.salesarticleid,
                        principalTable: "salesarticles",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "locations",
                columns: new[] { "id", "admin_name", "city", "country", "lat", "lng", "population" },
                values: new object[,]
                {
                    { 1L, "Uusimaa", "Espoo", "Finland", "60.2100", "24.6600", 269802 },
                    { 2L, "Pirkanmaa", "Tampere", "Finland", "61.4981", "23.7608", 225118 },
                    { 3L, "Uusimaa", "Vantaa", "Finland", "60.3000", "25.0333", 214605 },
                    { 4L, "Pohjois-Pohjanmaa", "Oulu", "Finland", "65.0142", "25.4719", 200526 },
                    { 5L, "Varsinais-Suomi", "Turku", "Finland", "60.4517", "22.2700", 187604 },
                    { 6L, "Keski-Suomi", "Jyväskylä", "Finland", "62.2333", "25.7333", 137368 },
                    { 7L, "Pohjois-Savo", "Kuopio", "Finland", "62.8925", "27.6783", 120246 },
                    { 8L, "Päijät-Häme", "Lahti", "Finland", "60.9804", "25.6550", 118119 },
                    { 9L, "Kymenlaakso", "Kouvola", "Finland", "60.8681", "26.7042", 85855 },
                    { 10L, "Satakunta", "Pori", "Finland", "61.4847", "21.7972", 85363 },
                    { 11L, "Pohjois-Karjala", "Joensuu", "Finland", "62.6000", "29.7639", 75514 },
                    { 12L, "Etelä-Karjala", "Lappeenranta", "Finland", "61.0583", "28.1861", 72875 },
                    { 13L, "Kanta-Häme", "Hämeenlinna", "Finland", "61.0000", "24.4414", 68011 },
                    { 14L, "Pohjanmaa", "Vaasa", "Finland", "63.1000", "21.6167", 67619 },
                    { 15L, "Lappi", "Rovaniemi", "Finland", "66.5028", "25.7285", 61763 },
                    { 16L, "Etelä-Pohjanmaa", "Seinäjoki", "Finland", "62.7903", "22.8403", 61530 },
                    { 17L, "Etelä-Savo", "Mikkeli", "Finland", "61.6875", "27.2736", 54665 },
                    { 18L, "Kymenlaakso", "Kotka", "Finland", "60.4667", "26.9458", 54319 },
                    { 19L, "Varsinais-Suomi", "Salo", "Finland", "60.3831", "23.1331", 53890 },
                    { 20L, "Uusimaa", "Porvoo", "Finland", "60.3931", "25.6639", 49928 },
                    { 21L, "Keski-Pohjanmaa", "Kokkola", "Finland", "63.8376", "23.1320", 47570 },
                    { 22L, "Uusimaa", "Lohja", "Finland", "60.2500", "24.0667", 47353 },
                    { 23L, "Uusimaa", "Hyvinkää", "Finland", "60.6306", "24.8597", 46463 },
                    { 24L, "Uusimaa", "Nurmijärvi", "Finland", "60.4667", "24.8083", 42709 },
                    { 25L, "Uusimaa", "Järvenpää", "Finland", "60.4722", "25.0889", 40106 },
                    { 26L, "Satakunta", "Rauma", "Finland", "61.1167", "21.5000", 39809 },
                    { 27L, "Uusimaa", "Kirkkonummi", "Finland", "60.1167", "24.4167", 38649 },
                    { 28L, "Uusimaa", "Tuusula", "Finland", "60.4028", "25.0292", 38646 },
                    { 29L, "Kainuu", "Kajaani", "Finland", "64.2250", "27.7333", 37622 },
                    { 30L, "Keski-Suomi", "Jyväskylän Maalaiskunta", "Finland", "62.2889", "25.7417", 36100 },
                    { 31L, "Etelä-Savo", "Savonlinna", "Finland", "61.8667", "28.8831", 35523 },
                    { 32L, "Uusimaa", "Kerava", "Finland", "60.4028", "25.1000", 35293 },
                    { 33L, "Pirkanmaa", "Nokia", "Finland", "61.4767", "23.5053", 33322 },
                    { 34L, "Pirkanmaa", "Ylöjärvi", "Finland", "61.5500", "23.5833", 32738 },
                    { 35L, "Varsinais-Suomi", "Kaarina", "Finland", "60.4069", "22.3722", 32590 },
                    { 36L, "Pirkanmaa", "Kangasala", "Finland", "61.4639", "24.0650", 32229 },
                    { 37L, "Kanta-Häme", "Riihimäki", "Finland", "60.7333", "24.7667", 29269 },
                    { 38L, "Uusimaa", "Vihti", "Finland", "60.4167", "24.3331", 28919 },
                    { 39L, "Uusimaa", "Raseborg", "Finland", "59.9750", "23.4361", 28405 },
                    { 40L, "Etelä-Karjala", "Imatra", "Finland", "61.1931", "28.7764", 27835 },
                    { 41L, "Pirkanmaa", "Sastamala", "Finland", "61.3417", "22.9083", 25220 },
                    { 42L, "Pohjois-Pohjanmaa", "Raahe", "Finland", "64.6847", "24.4792", 25165 },
                    { 43L, "Varsinais-Suomi", "Raisio", "Finland", "60.4861", "22.1694", 24290 },
                    { 44L, "Päijät-Häme", "Hollola", "Finland", "60.9886", "25.5128", 23915 },
                    { 45L, "Pirkanmaa", "Lempäälä", "Finland", "61.3139", "23.7528", 22536 },
                    { 46L, "Pohjois-Savo", "Iisalmi", "Finland", "63.5611", "27.1889", 21945 },
                    { 47L, "Lappi", "Tornio", "Finland", "65.8497", "24.1441", 21928 },
                    { 48L, "Pohjois-Savo", "Siilinjärvi", "Finland", "63.0750", "27.6600", 21794 },
                    { 49L, "Lappi", "Kemi", "Finland", "65.7336", "24.5634", 21758 },
                    { 50L, "Etelä-Pohjanmaa", "Kurikka", "Finland", "62.6167", "22.4000", 21734 },
                    { 51L, "Keski-Suomi", "Jämsä", "Finland", "61.8639", "25.1903", 21542 },
                    { 52L, "Pohjois-Savo", "Varkaus", "Finland", "62.3167", "27.8833", 21155 },
                    { 53L, "Pirkanmaa", "Valkeakoski", "Finland", "61.2667", "24.0306", 20800 },
                    { 54L, "Uusimaa", "Mäntsälä", "Finland", "60.6331", "25.3167", 20685 },
                    { 55L, "Keski-Suomi", "Äänekoski", "Finland", "62.6042", "25.7264", 19919 },
                    { 56L, "Kymenlaakso", "Hamina", "Finland", "60.5697", "27.1981", 19877 },
                    { 57L, "Päijät-Häme", "Heinola", "Finland", "61.2028", "26.0319", 19575 },
                    { 58L, "Pohjanmaa", "Jakobstad", "Finland", "63.6667", "22.7000", 19436 },
                    { 59L, "Uusimaa", "Sipoo", "Finland", "60.3764", "25.2722", 19399 },
                    { 60L, "Pohjanmaa", "Korsholm", "Finland", "63.1125", "21.6778", 19302 },
                    { 61L, "Varsinais-Suomi", "Lieto", "Finland", "60.5000", "22.4497", 19263 },
                    { 62L, "Varsinais-Suomi", "Naantali", "Finland", "60.4681", "22.0264", 18916 },
                    { 63L, "Pirkanmaa", "Pirkkala", "Finland", "61.4667", "23.6500", 18913 },
                    { 64L, "Keski-Suomi", "Laukaa", "Finland", "62.4167", "25.9500", 18865 },
                    { 65L, "Etelä-Savo", "Pieksämäki", "Finland", "62.3000", "27.1583", 18220 },
                    { 66L, "Kanta-Häme", "Forssa", "Finland", "60.8167", "23.6167", 17422 },
                    { 67L, "Pohjois-Pohjanmaa", "Kempele", "Finland", "64.9125", "25.5083", 17066 },
                    { 68L, "Pirkanmaa", "Toijala", "Finland", "61.1667", "23.8681", 17043 },
                    { 69L, "Etelä-Pohjanmaa", "Kauhava", "Finland", "63.1014", "23.0639", 16784 },
                    { 70L, "Varsinais-Suomi", "Loimaa", "Finland", "60.8514", "23.0583", 16467 },
                    { 71L, "Päijät-Häme", "Orimattila", "Finland", "60.8042", "25.7333", 16326 },
                    { 72L, "Pohjois-Pohjanmaa", "Kuusamo", "Finland", "65.9667", "29.1667", 15688 },
                    { 73L, "Varsinais-Suomi", "Uusikaupunki", "Finland", "60.7833", "21.4167", 15510 },
                    { 74L, "Varsinais-Suomi", "Pargas", "Finland", "60.3000", "22.3000", 15457 },
                    { 75L, "Uusimaa", "Loviisa", "Finland", "60.4569", "26.2250", 15311 },
                    { 76L, "Pohjois-Pohjanmaa", "Ylivieska", "Finland", "64.0722", "24.5375", 15039 },
                    { 77L, "Päijät-Häme", "Nastola", "Finland", "60.9477", "25.9301", 14890 },
                    { 78L, "Pohjois-Karjala", "Kontiolahti", "Finland", "62.7667", "29.8500", 14827 },
                    { 79L, "Etelä-Pohjanmaa", "Lapua", "Finland", "62.9708", "23.0069", 14609 },
                    { 80L, "Etelä-Pohjanmaa", "Kauhajoki", "Finland", "62.4319", "22.1794", 13875 },
                    { 81L, "Satakunta", "Ulvila", "Finland", "61.4292", "21.8750", 13237 },
                    { 82L, "Pohjois-Pohjanmaa", "Kalajoki", "Finland", "64.2597", "23.9486", 12621 },
                    { 83L, "Etelä-Pohjanmaa", "Ilmajoki", "Finland", "62.7333", "22.5833", 12159 },
                    { 84L, "Pohjois-Karjala", "Liperi", "Finland", "62.5333", "29.3833", 12150 },
                    { 85L, "Satakunta", "Eura", "Finland", "61.1333", "22.0833", 12128 },
                    { 86L, "Etelä-Pohjanmaa", "Alavus", "Finland", "62.5861", "23.6194", 12044 },
                    { 87L, "Pohjois-Karjala", "Lieksa", "Finland", "63.3167", "30.0167", 11772 },
                    { 88L, "Satakunta", "Kankaanpää", "Finland", "61.8042", "22.3944", 11769 },
                    { 89L, "Ahvenanmaa", "Mariehamn", "Finland", "60.0986", "19.9444", 11461 },
                    { 90L, "Pohjois-Pohjanmaa", "Nivala", "Finland", "63.9292", "24.9778", 10876 },
                    { 91L, "Pohjois-Karjala", "Kitee", "Finland", "62.0986", "30.1375", 10832 },
                    { 92L, "Pirkanmaa", "Hämeenkyrö", "Finland", "61.6333", "23.2000", 10667 },
                    { 93L, "Varsinais-Suomi", "Paimio", "Finland", "60.4569", "22.6861", 10620 },
                    { 94L, "Kainuu", "Sotkamo", "Finland", "64.1333", "28.3833", 10523 },
                    { 95L, "Satakunta", "Huittinen", "Finland", "61.1764", "22.6986", 10473 },
                    { 96L, "Keski-Suomi", "Keuruu", "Finland", "62.2597", "24.7069", 10117 },
                    { 97L, "Etelä-Pohjanmaa", "Alajärvi", "Finland", "63.0000", "23.8167", 10006 },
                    { 98L, "Pohjois-Savo", "Lapinlahti", "Finland", "63.3667", "27.3833", 9982 },
                    { 99L, "Pohjois-Pohjanmaa", "Ii", "Finland", "65.3167", "25.3722", 9966 },
                    { 100L, "Pohjois-Savo", "Leppävirta", "Finland", "62.4917", "27.7875", 9953 },
                    { 101L, "Pohjois-Pohjanmaa", "Liminka", "Finland", "64.8083", "25.4167", 9937 },
                    { 102L, "Keski-Suomi", "Saarijärvi", "Finland", "62.7056", "25.2569", 9915 },
                    { 103L, "Keski-Suomi", "Muurame", "Finland", "62.1292", "25.6722", 9791 },
                    { 104L, "Varsinais-Suomi", "Masku", "Finland", "60.5708", "22.1000", 9706 },
                    { 105L, "Uusimaa", "Kauniainen", "Finland", "60.2097", "24.7264", 9486 },
                    { 106L, "Pirkanmaa", "Orivesi", "Finland", "61.6778", "24.3569", 9408 },
                    { 107L, "Pohjanmaa", "Närpes", "Finland", "62.4736", "21.3375", 9387 },
                    { 108L, "Varsinais-Suomi", "Somero", "Finland", "60.6292", "23.5139", 9093 },
                    { 109L, "Pohjois-Pohjanmaa", "Muhos", "Finland", "64.8000", "26.0000", 9063 },
                    { 110L, "Uusimaa", "Karkkila", "Finland", "60.5347", "24.2097", 8969 },
                    { 111L, "Uusimaa", "Hanko", "Finland", "59.8236", "22.9681", 8864 },
                    { 112L, "Kainuu", "Kuhmo", "Finland", "64.1250", "29.5167", 8806 },
                    { 113L, "Lappi", "Sodankylä", "Finland", "67.4149", "26.5907", 8782 },
                    { 114L, "Pohjois-Savo", "Kiuruvesi", "Finland", "63.6528", "26.6194", 8600 },
                    { 115L, "Varsinais-Suomi", "Laitila", "Finland", "60.8792", "21.6931", 8520 },
                    { 116L, "Lappi", "Keminmaa", "Finland", "65.7990", "24.5426", 8388 },
                    { 117L, "Kainuu", "Suomussalmi", "Finland", "64.8833", "28.9167", 8336 },
                    { 118L, "Pohjois-Pohjanmaa", "Pudasjärvi", "Finland", "65.3583", "27.0000", 8257 },
                    { 119L, "Kanta-Häme", "Loppi", "Finland", "60.7181", "24.4417", 8175 },
                    { 120L, "Pohjanmaa", "Laihia", "Finland", "62.9764", "22.0111", 8090 },
                    { 121L, "Pohjois-Karjala", "Nurmes", "Finland", "63.5444", "29.1333", 7996 },
                    { 122L, "Etelä-Pohjanmaa", "Jalasjärvi", "Finland", "62.4917", "22.7667", 7885 },
                    { 123L, "Varsinais-Suomi", "Mynämäki", "Finland", "60.6833", "21.9833", 7859 },
                    { 124L, "Lappi", "Kemijärvi", "Finland", "66.7150", "27.4306", 7766 },
                    { 125L, "Pohjois-Pohjanmaa", "Oulainen", "Finland", "64.2667", "24.8167", 7610 },
                    { 126L, "Satakunta", "Kokemäki", "Finland", "61.2556", "22.3486", 7591 },
                    { 127L, "Pohjanmaa", "Nykarleby", "Finland", "63.5167", "22.5333", 7564 },
                    { 128L, "Pohjois-Pohjanmaa", "Haapajärvi", "Finland", "63.7486", "25.3181", 7438 },
                    { 129L, "Pohjois-Savo", "Suonenjoki", "Finland", "62.6250", "27.1222", 7390 },
                    { 130L, "Satakunta", "Harjavalta", "Finland", "61.3139", "22.1417", 7296 },
                    { 131L, "Pirkanmaa", "Ikaalinen", "Finland", "61.7694", "23.0681", 7207 },
                    { 132L, "Pohjois-Pohjanmaa", "Haapavesi", "Finland", "64.1375", "25.3667", 7167 },
                    { 133L, "Pohjois-Karjala", "Outokumpu", "Finland", "62.7250", "29.0167", 7139 },
                    { 134L, "Pirkanmaa", "Mänttä", "Finland", "62.0292", "24.6236", 7077 },
                    { 135L, "Satakunta", "Säkylä", "Finland", "61.0500", "22.3500", 7070 },
                    { 136L, "Pirkanmaa", "Virrat", "Finland", "62.2403", "23.7708", 7002 },
                    { 137L, "Lappi", "Inari", "Finland", "68.9055", "27.0176", 6804 },
                    { 138L, "Pohjois-Pohjanmaa", "Tyrnävä", "Finland", "64.7500", "25.6500", 6793 },
                    { 139L, "Pohjanmaa", "Kristinestad", "Finland", "62.2736", "21.3778", 6793 },
                    { 140L, "Pirkanmaa", "Parkano", "Finland", "62.0097", "23.0250", 6766 },
                    { 141L, "Pohjanmaa", "Vörå", "Finland", "63.1333", "22.2500", 6714 },
                    { 142L, "Pohjanmaa", "Kronoby", "Finland", "63.7250", "23.0333", 6682 },
                    { 143L, "Pirkanmaa", "Pälkäne", "Finland", "61.3389", "24.2681", 6676 },
                    { 144L, "Keski-Suomi", "Viitasaari", "Finland", "63.0750", "25.8597", 6666 },
                    { 145L, "Etelä-Savo", "Juva", "Finland", "61.8972", "27.8569", 6548 },
                    { 146L, "Lappi", "Kittilä", "Finland", "67.6531", "24.9114", 6416 },
                    { 147L, "Kanta-Häme", "Tammela", "Finland", "60.8000", "23.7667", 6280 },
                    { 148L, "Uusimaa", "Siuntio", "Finland", "60.1333", "24.2167", 6182 },
                    { 149L, "Etelä-Savo", "Mäntyharju", "Finland", "61.4181", "26.8792", 6159 },
                    { 150L, "Varsinais-Suomi", "Rusko", "Finland", "60.5417", "22.2222", 6110 },
                    { 151L, "Etelä-Pohjanmaa", "Ähtäri", "Finland", "62.5500", "24.0694", 6068 },
                    { 152L, "Satakunta", "Eurajoki", "Finland", "61.2000", "21.7333", 5938 },
                    { 153L, "Satakunta", "Nakkila", "Finland", "61.3653", "22.0042", 5651 },
                    { 154L, "Etelä-Savo", "Kangasniemi", "Finland", "61.9900", "26.6417", 5628 },
                    { 155L, "Pohjanmaa", "Malax", "Finland", "62.9417", "21.5500", 5545 },
                    { 156L, "Uusimaa", "Ingå", "Finland", "60.0458", "24.0056", 5541 },
                    { 157L, "Keski-Pohjanmaa", "Kannus", "Finland", "63.9017", "23.9151", 5520 },
                    { 158L, "Etelä-Pohjanmaa", "Teuva", "Finland", "62.4861", "21.7472", 5482 },
                    { 159L, "Kanta-Häme", "Jokioinen", "Finland", "60.8042", "23.4861", 5425 },
                    { 160L, "Pohjois-Karjala", "Ilomantsi", "Finland", "62.6667", "30.9333", 5336 },
                    { 161L, "Etelä-Karjala", "Ruokolahti", "Finland", "61.2917", "28.8167", 5312 },
                    { 162L, "Keski-Suomi", "Hankasalmi", "Finland", "62.3889", "26.4361", 5240 },
                    { 163L, "Etelä-Karjala", "Parikkala", "Finland", "61.5500", "29.5000", 5235 },
                    { 164L, "Pohjanmaa", "Larsmo", "Finland", "63.7500", "22.8000", 5147 },
                    { 165L, "Uusimaa", "Pornainen", "Finland", "60.4750", "25.3750", 5125 },
                    { 166L, "Pohjois-Pohjanmaa", "Sievi", "Finland", "63.9069", "24.5167", 5124 },
                    { 167L, "Etelä-Savo", "Joroinen", "Finland", "62.1792", "27.8278", 5110 },
                    { 168L, "Uusimaa", "Askola", "Finland", "60.5278", "25.6000", 5104 },
                    { 169L, "Pohjois-Karjala", "Juuka", "Finland", "63.2417", "29.2500", 5034 },
                    { 170L, "Varsinais-Suomi", "Nousiainen", "Finland", "60.6000", "22.0833", 4859 },
                    { 171L, "Pirkanmaa", "Urjala", "Finland", "61.0833", "23.5500", 4829 },
                    { 172L, "Etelä-Karjala", "Taipalsaari", "Finland", "61.1597", "28.0597", 4815 },
                    { 173L, "Pohjois-Savo", "Juankoski", "Finland", "63.0639", "28.3278", 4804 },
                    { 174L, "Pohjanmaa", "Isokyrö", "Finland", "63.0000", "22.3167", 4785 },
                    { 175L, "Pohjois-Savo", "Pielavesi", "Finland", "63.2333", "26.7583", 4740 },
                    { 176L, "Pohjois-Karjala", "Tohmajärvi", "Finland", "62.2264", "30.3319", 4738 },
                    { 177L, "Pohjois-Pohjanmaa", "Ruukki", "Finland", "64.6639", "25.1014", 4721 },
                    { 178L, "Keski-Suomi", "Joutsa", "Finland", "61.7417", "26.1153", 4688 },
                    { 179L, "Ahvenanmaa", "Jomala", "Finland", "60.1500", "19.9500", 4648 },
                    { 180L, "Pirkanmaa", "Ruovesi", "Finland", "61.9833", "24.0833", 4623 },
                    { 181L, "Pohjois-Karjala", "Polvijärvi", "Finland", "62.8550", "29.3667", 4556 },
                    { 182L, "Pirkanmaa", "Vesilahti", "Finland", "61.3167", "23.6167", 4489 },
                    { 183L, "Lappi", "Ylitornio", "Finland", "66.3167", "23.6667", 4291 },
                    { 184L, "Pohjois-Savo", "Sonkajärvi", "Finland", "63.6667", "27.5167", 4278 },
                    { 185L, "Keski-Suomi", "Karstula", "Finland", "62.8750", "24.8000", 4268 },
                    { 186L, "Keski-Suomi", "Pihtipudas", "Finland", "63.3667", "25.5750", 4221 },
                    { 187L, "Pohjois-Pohjanmaa", "Taivalkoski", "Finland", "65.5750", "28.2417", 4199 },
                    { 188L, "Päijät-Häme", "Sysmä", "Finland", "61.5028", "25.6847", 4040 },
                    { 189L, "Lappi", "Ranua", "Finland", "65.9275", "26.5184", 4020 },
                    { 190L, "Keski-Suomi", "Petäjävesi", "Finland", "62.2500", "25.1833", 4008 },
                    { 191L, "Varsinais-Suomi", "Aura", "Finland", "60.6472", "22.5903", 3991 },
                    { 192L, "Pohjois-Savo", "Maaninka", "Finland", "63.1583", "27.3000", 3773 },
                    { 193L, "Pohjois-Savo", "Vieremä", "Finland", "63.7431", "27.0014", 3757 },
                    { 194L, "Etelä-Savo", "Rantasalmi", "Finland", "62.0667", "28.3000", 3733 },
                    { 195L, "Lappi", "Salla", "Finland", "66.8333", "28.6667", 3727 },
                    { 196L, "Etelä-Pohjanmaa", "Kuortane", "Finland", "62.8083", "23.5083", 3715 },
                    { 197L, "Keski-Suomi", "Uurainen", "Finland", "62.5000", "25.4367", 3666 },
                    { 198L, "Lappi", "Pello", "Finland", "66.7756", "23.9635", 3623 },
                    { 199L, "Etelä-Karjala", "Savitaipale", "Finland", "61.2000", "27.6833", 3613 },
                    { 200L, "Etelä-Savo", "Heinävesi", "Finland", "62.4250", "28.6333", 3574 },
                    { 201L, "Kainuu", "Paltamo", "Finland", "64.4083", "27.8417", 3488 },
                    { 202L, "Lappi", "Posio", "Finland", "66.1097", "28.1739", 3477 },
                    { 203L, "Satakunta", "Luvia", "Finland", "61.3611", "21.6250", 3349 },
                    { 204L, "Kymenlaakso", "Virolahti", "Finland", "60.5833", "27.7000", 3347 },
                    { 205L, "Varsinais-Suomi", "Kimito", "Finland", "60.1639", "22.7278", 3339 },
                    { 206L, "Keski-Pohjanmaa", "Toholampi", "Finland", "63.7750", "24.2500", 3311 },
                    { 207L, "Pohjois-Savo", "Rautalampi", "Finland", "62.6217", "26.8333", 3303 },
                    { 208L, "Keski-Pohjanmaa", "Veteli", "Finland", "63.4753", "23.7886", 3302 },
                    { 209L, "Lappi", "Simo", "Finland", "65.6613", "25.0623", 3238 },
                    { 210L, "Etelä-Pohjanmaa", "Lappajärvi", "Finland", "63.2167", "23.6333", 3215 },
                    { 211L, "Pohjois-Pohjanmaa", "Pyhäjoki", "Finland", "64.4667", "24.2583", 3211 },
                    { 212L, "Lappi", "Tervola", "Finland", "66.0821", "24.8080", 3195 },
                    { 213L, "Pohjois-Savo", "Kaavi", "Finland", "62.9750", "28.4833", 3194 },
                    { 214L, "Satakunta", "Merikarvia", "Finland", "61.8583", "21.5000", 3185 },
                    { 215L, "Päijät-Häme", "Padasjoki", "Finland", "61.3500", "25.2750", 3143 },
                    { 216L, "Kainuu", "Vaala", "Finland", "64.5500", "26.8333", 3074 },
                    { 217L, "Etelä-Karjala", "Lemi", "Finland", "61.0611", "27.8042", 3073 },
                    { 218L, "Etelä-Pohjanmaa", "Vimpeli", "Finland", "63.1617", "23.8167", 3073 },
                    { 219L, "Pirkanmaa", "Punkalaidun", "Finland", "61.1117", "23.1050", 3049 },
                    { 220L, "Varsinais-Suomi", "Sauvo", "Finland", "60.3417", "22.6917", 3019 },
                    { 221L, "Päijät-Häme", "Hartola", "Finland", "61.5784", "26.0142", 2982 },
                    { 222L, "Pohjois-Pohjanmaa", "Reisjärvi", "Finland", "63.6056", "24.9319", 2894 },
                    { 223L, "Pohjois-Pohjanmaa", "Utajärvi", "Finland", "64.7500", "26.4167", 2861 },
                    { 224L, "Keski-Pohjanmaa", "Perho", "Finland", "63.2167", "24.4167", 2860 },
                    { 225L, "Kainuu", "Puolanka", "Finland", "64.8681", "27.6708", 2776 },
                    { 226L, "Uusimaa", "Lappträsk", "Finland", "60.6167", "26.2000", 2774 },
                    { 227L, "Keski-Suomi", "Konnevesi", "Finland", "62.6283", "26.2833", 2757 },
                    { 228L, "Etelä-Savo", "Sulkava", "Finland", "61.7875", "28.3708", 2724 },
                    { 229L, "Pohjois-Pohjanmaa", "Alavieska", "Finland", "64.1667", "24.3083", 2687 },
                    { 230L, "Pohjois-Pohjanmaa", "Kärsämäki", "Finland", "63.9750", "25.7583", 2658 },
                    { 231L, "Satakunta", "Köyliö", "Finland", "61.1167", "22.3083", 2647 },
                    { 232L, "Pohjois-Savo", "Tuusniemi", "Finland", "62.8083", "28.4917", 2597 },
                    { 233L, "Etelä-Pohjanmaa", "Evijärvi", "Finland", "63.3667", "23.4750", 2499 },
                    { 234L, "Satakunta", "Karvia", "Finland", "62.1333", "22.5583", 2475 },
                    { 235L, "Keski-Suomi", "Toivakka", "Finland", "62.1000", "26.0833", 2431 },
                    { 236L, "Kainuu", "Hyrynsalmi", "Finland", "64.6750", "28.4917", 2422 },
                    { 237L, "Kanta-Häme", "Ypäjä", "Finland", "60.8083", "23.2833", 2411 },
                    { 238L, "Kanta-Häme", "Humppila", "Finland", "60.9250", "23.3667", 2388 },
                    { 239L, "Pohjois-Savo", "Keitele", "Finland", "63.1783", "26.3500", 2379 },
                    { 240L, "Varsinais-Suomi", "Koski Tl", "Finland", "60.6542", "23.1403", 2359 },
                    { 241L, "Lappi", "Muonio", "Finland", "67.9593", "23.6772", 2358 },
                    { 242L, "Pohjois-Karjala", "Rääkkylä", "Finland", "62.3133", "29.6250", 2349 },
                    { 243L, "Keski-Suomi", "Kuhmoinen", "Finland", "61.5667", "25.1833", 2334 },
                    { 244L, "Pohjois-Karjala", "Valtimo", "Finland", "63.6800", "28.8167", 2324 },
                    { 245L, "Etelä-Savo", "Hirvensalmi", "Finland", "61.6389", "26.7806", 2290 },
                    { 246L, "Etelä-Savo", "Puumala", "Finland", "61.5250", "28.1833", 2260 },
                    { 247L, "Satakunta", "Pomarkku", "Finland", "61.6917", "22.0083", 2240 },
                    { 248L, "Etelä-Pohjanmaa", "Soini", "Finland", "62.8750", "24.2083", 2224 },
                    { 249L, "Pohjanmaa", "Korsnäs", "Finland", "62.7833", "21.1833", 2201 },
                    { 250L, "Pohjois-Savo", "Vesanto", "Finland", "62.9333", "26.4167", 2191 },
                    { 251L, "Varsinais-Suomi", "Pyhäranta", "Finland", "60.9500", "21.4417", 2136 },
                    { 252L, "Etelä-Pohjanmaa", "Isojoki", "Finland", "62.1139", "21.9583", 2123 },
                    { 253L, "Päijät-Häme", "Hämeenkoski", "Finland", "61.0250", "25.1500", 2104 },
                    { 254L, "Kymenlaakso", "Miehikkälä", "Finland", "60.6708", "27.7000", 2085 },
                    { 255L, "Pohjois-Pohjanmaa", "Lumijoki", "Finland", "64.8367", "25.1867", 2076 },
                    { 256L, "Pirkanmaa", "Kihniö", "Finland", "62.2083", "23.1792", 2038 },
                    { 257L, "Varsinais-Suomi", "Marttila", "Finland", "60.5833", "22.9000", 2028 },
                    { 258L, "Ahvenanmaa", "Lemland", "Finland", "60.0806", "20.1000", 1991 },
                    { 259L, "Uusimaa", "Pukkila", "Finland", "60.6450", "25.5833", 1971 },
                    { 260L, "Uusimaa", "Myrskylä", "Finland", "60.6667", "25.8500", 1969 },
                    { 261L, "Varsinais-Suomi", "Tarvasjoki", "Finland", "60.5833", "22.7333", 1958 },
                    { 262L, "Satakunta", "Jämijärvi", "Finland", "61.8167", "22.6917", 1948 },
                    { 263L, "Satakunta", "Lavia", "Finland", "61.5958", "22.5861", 1890 },
                    { 264L, "Lappi", "Enontekiö", "Finland", "68.3847", "23.6389", 1861 },
                    { 265L, "Pohjois-Pohjanmaa", "Pulkkila", "Finland", "64.2667", "25.8667", 1843 },
                    { 266L, "Etelä-Savo", "Pertunmaa", "Finland", "61.5028", "26.4792", 1817 },
                    { 267L, "Satakunta", "Honkajoki", "Finland", "61.9931", "22.2639", 1793 },
                    { 268L, "Keski-Suomi", "Kinnula", "Finland", "63.3667", "24.9667", 1745 },
                    { 269L, "Pohjois-Savo", "Rautavaara", "Finland", "63.4944", "28.2986", 1737 },
                    { 270L, "Keski-Suomi", "Multia", "Finland", "62.4083", "24.7950", 1710 },
                    { 271L, "Varsinais-Suomi", "Taivassalo", "Finland", "60.5617", "21.6083", 1633 },
                    { 272L, "Pohjois-Savo", "Tervo", "Finland", "62.9556", "26.7556", 1608 },
                    { 273L, "Pohjois-Pohjanmaa", "Pyhäntä", "Finland", "64.0972", "26.3306", 1587 },
                    { 274L, "Ahvenanmaa", "Hammarland", "Finland", "60.2167", "19.7403", 1537 },
                    { 275L, "Satakunta", "Siikainen", "Finland", "61.8833", "21.8167", 1527 },
                    { 276L, "Etelä-Savo", "Enonkoski", "Finland", "62.0889", "28.9333", 1473 },
                    { 277L, "Keski-Suomi", "Kannonkoski", "Finland", "62.9750", "25.2667", 1462 },
                    { 278L, "Keski-Suomi", "Kyyjärvi", "Finland", "63.0431", "24.5639", 1379 },
                    { 279L, "Varsinais-Suomi", "Oripää", "Finland", "60.8556", "22.6972", 1377 },
                    { 280L, "Etelä-Pohjanmaa", "Karijoki", "Finland", "62.3083", "21.7083", 1369 },
                    { 281L, "Kainuu", "Ristijärvi", "Finland", "64.5056", "28.2139", 1351 },
                    { 282L, "Pohjanmaa", "Kaskinen", "Finland", "62.3847", "21.2222", 1285 },
                    { 283L, "Lappi", "Utsjoki", "Finland", "69.9078", "27.0265", 1250 },
                    { 284L, "Keski-Pohjanmaa", "Halsua", "Finland", "63.4633", "24.1667", 1225 },
                    { 285L, "Keski-Suomi", "Kivijärvi", "Finland", "63.1200", "25.0750", 1200 },
                    { 286L, "Pohjois-Pohjanmaa", "Merijärvi", "Finland", "64.2967", "24.4467", 1134 },
                    { 287L, "Lappi", "Savukoski", "Finland", "67.2917", "28.1667", 1061 },
                    { 288L, "Pohjois-Pohjanmaa", "Hailuoto", "Finland", "65.0167", "24.7167", 993 },
                    { 289L, "Lappi", "Pelkosenniemi", "Finland", "67.1083", "27.5167", 958 },
                    { 290L, "Ahvenanmaa", "Eckerö", "Finland", "60.2167", "19.5500", 935 },
                    { 291L, "Varsinais-Suomi", "Kustavi", "Finland", "60.5467", "21.3583", 895 },
                    { 292L, "Keski-Pohjanmaa", "Lestijärvi", "Finland", "63.5250", "24.6653", 798 },
                    { 293L, "Keski-Suomi", "Luhanka", "Finland", "61.8000", "25.7000", 761 },
                    { 294L, "Ahvenanmaa", "Brändö", "Finland", "60.4117", "21.0453", 515 },
                    { 295L, "Ahvenanmaa", "Geta", "Finland", "60.3750", "19.8500", 495 },
                    { 296L, "Ahvenanmaa", "Vårdö", "Finland", "60.2417", "20.3750", 441 },
                    { 297L, "Ahvenanmaa", "Lumparland", "Finland", "60.1167", "20.2583", 398 },
                    { 298L, "Ahvenanmaa", "Kumlinge", "Finland", "60.2583", "20.7783", 317 },
                    { 299L, "Ahvenanmaa", "Sottunga", "Finland", "60.1333", "20.6667", 92 },
                    { 300L, "Uusimaa", "Nummela", "Finland", "60.3333", "24.3333", null },
                    { 301L, "Kanta-Häme", "Turenki", "Finland", "60.9167", "24.6333", null },
                    { 302L, "Kanta-Häme", "Parola", "Finland", "61.0500", "24.3667", null },
                    { 303L, "Kanta-Häme", "Oitti", "Finland", "60.7833", "25.0333", null },
                    { 304L, "Ahvenanmaa", "Godby", "Finland", "60.2300", "19.9881", null },
                    { 305L, "Päijät-Häme", "Järvelä", "Finland", "60.8680", "25.2730", null },
                    { 306L, "Kymenlaakso", "Siltakylä", "Finland", "60.4958", "26.7097", null },
                    { 307L, "Päijät-Häme", "Vääksy", "Finland", "61.1722", "25.5472", null },
                    { 308L, "Ahvenanmaa", "Ödkarby", "Finland", "60.3073", "19.9862", null },
                    { 309L, "Pohjanmaa", "Bennäs", "Finland", "63.6000", "22.7917", null },
                    { 310L, "Keski-Pohjanmaa", "Kaustinen", "Finland", "63.5481", "23.6999", null },
                    { 311L, "Varsinais-Suomi", "Kyrö", "Finland", "60.7000", "22.7500", null },
                    { 312L, "Varsinais-Suomi", "Vinkkilä", "Finland", "60.6833", "21.7167", null },
                    { 313L, "Kymenlaakso", "Kausala", "Finland", "60.8928", "26.3394", null },
                    { 314L, "Etelä-Karjala", "Simpele", "Finland", "61.4333", "29.3670", null },
                    { 315L, "Varsinais-Suomi", "Dalsbruk", "Finland", "60.0333", "22.5167", null },
                    { 316L, "Ahvenanmaa", "Björby", "Finland", "60.2572", "20.1342", null },
                    { 317L, "Pirkanmaa", "Korkeakoski", "Finland", "61.8000", "24.3667", null },
                    { 318L, "Etelä-Karjala", "Taavetti", "Finland", "60.9167", "27.5667", null },
                    { 319L, "Ahvenanmaa", "Föglö", "Finland", "60.0000", "20.4333", null },
                    { 320L, "Pohjois-Pohjanmaa", "Pyhäsalmi", "Finland", "63.6833", "25.9833", null },
                    { 321L, "Ahvenanmaa", "Karlby", "Finland", "59.9167", "20.9000", null },
                    { 322L, "Lappi", "Kolari", "Finland", "67.3317", "23.7913", null },
                    { 323L, "Lappi", "Ivalo", "Finland", "68.6565", "27.5404", null },
                    { 324L, "Ahvenanmaa", "Åva", "Finland", "60.4667", "21.0833", null }
                });

            migrationBuilder.CreateIndex(
                name: "ix_image_salesarticleid",
                table: "image",
                column: "salesarticleid");

            migrationBuilder.CreateIndex(
                name: "ix_salesarticles_locationid",
                table: "salesarticles",
                column: "locationid");

            migrationBuilder.CreateIndex(
                name: "ix_salesarticles_userid",
                table: "salesarticles",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "ix_users_locationid",
                table: "users",
                column: "locationid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "image");

            migrationBuilder.DropTable(
                name: "salesarticles");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "locations");
        }
    }
}
