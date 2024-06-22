using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VShop.ProductApi.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                            table: "Categories",
                            columns: new[] { "Id", "Name" },
                            values: new object[,]
                            {
                                { 1, "Lanches" },
                                { 2, "Bebidas" },
                                { 3, "Sobremesas" }
                            });

            migrationBuilder.InsertData(
                            table: "Products",
                            columns: new[] { "Id", "Name", "Price", "Description", "ImageUrl", "Stock", "CategoryId" },
                            values: new object[,]
                            {
                                { new Guid("C78DE24E-4979-402C-A61E-8E73A17E6187"), "Coca Cola Zero 350ml", 5.0M, "Refrigerante Coca Cola Zero Açucar Lata (350ml)", "cocacolazero.png", 15, 2 },
                                { new Guid("F3009DD7-800E-47B9-9EB9-C4001009E214"), "Coca Cola 350ml", 5.0M, "Refrigerante Coca Cola Açucar Lata (350ml)", "cocacola.png", 15, 2 },
                                { new Guid("78F9CD9B-B11F-4E15-A61F-9D7F9772F471"), "Fanta Laranja 350ml", 5.0M, "Refrigerante Fanta Laranja Lata (350ml)", "fantalaranja.png", 15, 2 },
                                { new Guid("7CFBE08C-31B7-4912-BE37-DC37FC873895"), "Fanta Uva 350ml", 5.0M, "Refrigerante Fanta Uva Lata (350ml)", "fantauva.png", 15, 2 },
                                { new Guid("D01CD4C8-6848-464D-979F-D98408E7B961"), "X-Bacon", 15.0M, "Pão, hambúrguer, bacon, queijo, alface, tomate e maionese", "xbacon.png", 15, 1 },
                                { new Guid("3C78C26C-3C00-4698-B988-4CFA7C54911A"), "X-Burger", 10.0M, "Pão, hambúrguer, queijo, alface, tomate e maionese", "xburger.png", 15, 1 },
                                { new Guid("683C6A71-9F58-4D1A-9EBC-ABB809526074"), "X-Egg", 10.0M, "Pão, hambúrguer, queijo, ovo, alface, tomate e maionese", "xegg.png", 15, 1 },
                                { new Guid("35801812-55D6-4805-8C43-CF1E7206992A"), "X-Frango", 10.0M, "Pão, frango, queijo, alface, tomate e maionese", "xfrango.png", 15, 1 },
                                { new Guid("682A304E-0E04-4D7D-BB77-172CE841381A"), "Pudim", 7.0M, "Pudim de leite condensado", "pudim.png", 15, 3 },
                                { new Guid("B2707AEE-C1DD-4EE5-B558-1C6A6C021598"), "Sorvete", 10.0M, "Sorvete de creme", "sorvete.png", 15, 3}
                            });
        }
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
