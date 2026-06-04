using Azure.Data.Tables;
using Azure;

namespace BookingSystem.Models
{
    public class ProfileLog: ITableEntity
    {
        // Required properties for Azure Tables
        //Gemini,2026
        //Microsoft,2026 - https://learn.microsoft.com/en-us/dotnet/api/overview/azure/data.tables-readme?view=azure-dotnet
        public string PartitionKey { get; set; } = "VenueUpload";
        public string RowKey { get; set; } = Guid.NewGuid().ToString();
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }

        // Your custom property
        public string Message { get; set; } = string.Empty;
    }
}
