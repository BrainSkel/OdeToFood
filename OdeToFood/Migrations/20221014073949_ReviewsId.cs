using Microsoft.EntityFrameworkCore.Migrations;

namespace OdeToFood.Migrations
{
    public partial class ReviewsId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantReviewId",
                table: "RestaurantReviews",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantReviews_RestaurantReviewId",
                table: "RestaurantReviews",
                column: "RestaurantReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantReviews_RestaurantReviews_RestaurantReviewId",
                table: "RestaurantReviews",
                column: "RestaurantReviewId",
                principalTable: "RestaurantReviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantReviews_RestaurantReviews_RestaurantReviewId",
                table: "RestaurantReviews");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantReviews_RestaurantReviewId",
                table: "RestaurantReviews");

            migrationBuilder.DropColumn(
                name: "RestaurantReviewId",
                table: "RestaurantReviews");
        }
    }
}
