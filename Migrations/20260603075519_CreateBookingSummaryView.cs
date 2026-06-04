using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class CreateBookingSummaryView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        CREATE VIEW View_BookingSummary AS
        SELECT 
            b.BookingID, 
            e.EventName, 
            v.VenueName, 
            b.StartDate AS BookingDate 
        FROM dbo.Bookings b
        JOIN dbo.Events e ON b.EventID = e.EventID
        JOIN dbo.Venues v ON b.VenueID = v.VenueID
    ");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW View_BookingSummary");
        }
    }
}
