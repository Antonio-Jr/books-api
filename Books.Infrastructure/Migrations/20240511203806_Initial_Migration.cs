using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: true),
                    last_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_authors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: true),
                    isbn = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: true),
                    book_type = table.Column<int>(type: "integer", nullable: false),
                    total_copies = table.Column<int>(type: "integer", nullable: false),
                    copies_in_use = table.Column<int>(type: "integer", nullable: false),
                    author_id = table.Column<Guid>(type: "uuid", nullable: false),
                    category_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_books", x => x.id);
                    table.ForeignKey(
                        name: "fk_books_authors_author_id",
                        column: x => x.author_id,
                        principalTable: "authors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_books_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "authors",
                columns: new[] { "id", "first_name", "last_name" },
                values: new object[,]
                {
                    { new Guid("1c98c000-8f8e-4d3c-8d1e-7ec0ec93f1bb"), "Jane", "Austen" },
                    { new Guid("251e8346-65c1-496d-823c-cd433649347c"), "Harper", "Lee" },
                    { new Guid("517c6f8c-8abc-4183-a2b9-5bb9e76b3b3a"), "J.D", "Salinger" },
                    { new Guid("55febf99-1b0d-42b8-a43b-8e5a1c4b3690"), "F. Scott", "Fitzgerald" },
                    { new Guid("7b453ac1-18ca-4887-a8d9-ab81b4276d1e"), "Paulo", "Coelho" },
                    { new Guid("8997e2d9-5f02-4da4-a4ad-d069608fccde"), "Markus", "Zusak" },
                    { new Guid("b48af8fc-0899-4b36-9140-19c64a4f6fcd"), "C.S", "Lewis" },
                    { new Guid("b614713f-239b-4e6a-8ade-b87c9425c874"), "Dan", "Brown" },
                    { new Guid("c32c75c2-d6be-4391-97d5-b35f54a5520c"), "John", "Steinbeck" },
                    { new Guid("e9c23ec1-d8d2-4142-84ae-bbfdf1beab9a"), "Douglas", "Adams" },
                    { new Guid("f0024628-4947-41b2-8ed0-aab6c9e2bd51"), "Herman", "Melville" }
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("1994ecb4-d361-4739-871d-c2bf902e463c"), "Fiction" },
                    { new Guid("21bcefe9-7b70-48a5-9438-fe9281411403"), "Non-Fiction" },
                    { new Guid("46123bcc-66c8-4360-a10e-c020989b66e5"), "Biography" },
                    { new Guid("534f3066-8ac4-49c4-abac-db5351d916bf"), "Mystery" },
                    { new Guid("d09ddf34-e274-4807-94ec-ea5566358746"), "Sci-Fi" }
                });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "id", "author_id", "book_type", "category_id", "copies_in_use", "isbn", "status", "title", "total_copies" },
                values: new object[,]
                {
                    { new Guid("0e733f33-1e0b-4702-822a-8723e77509db"), new Guid("8997e2d9-5f02-4da4-a4ad-d069608fccde"), 0, new Guid("534f3066-8ac4-49c4-abac-db5351d916bf"), 11, "1234567896", null, "The Book Thief", 75 },
                    { new Guid("16056931-4d00-4aca-958d-ae698f8f64cd"), new Guid("b614713f-239b-4e6a-8ade-b87c9425c874"), 1, new Guid("d09ddf34-e274-4807-94ec-ea5566358746"), 40, "1234567898", null, "The Da Vinci Code", 50 },
                    { new Guid("2c471656-d95e-4a3f-b4f0-5c8b30aa8011"), new Guid("251e8346-65c1-496d-823c-cd433649347c"), 1, new Guid("21bcefe9-7b70-48a5-9438-fe9281411403"), 0, "9012345678", null, "To Kill a Mockingbird", 20 },
                    { new Guid("3112e468-a139-464b-bff3-40fd3e30d7c9"), new Guid("e9c23ec1-d8d2-4142-84ae-bbfdf1beab9a"), 1, new Guid("21bcefe9-7b70-48a5-9438-fe9281411403"), 35, "1234567900", null, "The Hitchhiker''s Guide to the Galaxy", 50 },
                    { new Guid("339d8705-50fa-4bf6-b69b-f91456e3c907"), new Guid("251e8346-65c1-496d-823c-cd433649347c"), 1, new Guid("1994ecb4-d361-4739-871d-c2bf902e463c"), 65, "1234567892", null, "To Kill a Mockingbird", 75 },
                    { new Guid("7da57676-de31-4104-825c-c895db522ab2"), new Guid("b48af8fc-0899-4b36-9140-19c64a4f6fcd"), 1, new Guid("d09ddf34-e274-4807-94ec-ea5566358746"), 14, "1234567897", null, "The Chronicles of Narnia", 100 },
                    { new Guid("a4804e31-4e9c-4d44-be70-57e084134a28"), new Guid("517c6f8c-8abc-4183-a2b9-5bb9e76b3b3a"), 0, new Guid("21bcefe9-7b70-48a5-9438-fe9281411403"), 1, "0123456789", null, "The Catcher in the Rye", 10 },
                    { new Guid("a7e05753-b12f-41e0-86b1-0b639c25eacd"), new Guid("55febf99-1b0d-42b8-a43b-8e5a1c4b3690"), 0, new Guid("21bcefe9-7b70-48a5-9438-fe9281411403"), 22, "1234567894", null, "The Great Gatsby", 50 },
                    { new Guid("abbb48f7-1eee-4c02-99e1-039a5ed353cb"), new Guid("f0024628-4947-41b2-8ed0-aab6c9e2bd51"), 0, new Guid("1994ecb4-d361-4739-871d-c2bf902e463c"), 8, "8901234567", null, "Moby-Dick", 30 },
                    { new Guid("c2c9d469-d4d9-4f3e-86c6-88dcddf9a406"), new Guid("1c98c000-8f8e-4d3c-8d1e-7ec0ec93f1bb"), 0, new Guid("1994ecb4-d361-4739-871d-c2bf902e463c"), 80, "1234567891", null, "Pride and Prejudice", 100 },
                    { new Guid("cb577182-fe3c-4c6f-ae4e-45e4d3cd202f"), new Guid("c32c75c2-d6be-4391-97d5-b35f54a5520c"), 0, new Guid("1994ecb4-d361-4739-871d-c2bf902e463c"), 35, "1234567899", null, "The Grapes of Wrath", 50 },
                    { new Guid("dc6efd59-b2b6-4f81-9608-dce9c39945cf"), new Guid("517c6f8c-8abc-4183-a2b9-5bb9e76b3b3a"), 0, new Guid("1994ecb4-d361-4739-871d-c2bf902e463c"), 45, "1234567893", null, "The Catcher in the Rye", 50 },
                    { new Guid("e172454f-82aa-472f-bdb2-6781477c651a"), new Guid("7b453ac1-18ca-4887-a8d9-ab81b4276d1e"), 0, new Guid("46123bcc-66c8-4360-a10e-c020989b66e5"), 35, "1234567895", null, "The Alchemist", 50 }
                });

            migrationBuilder.CreateIndex(
                name: "ix_books_author_id",
                table: "books",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "ix_books_category_id",
                table: "books",
                column: "category_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
