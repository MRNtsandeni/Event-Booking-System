ALTER VIEW View_BookingSummary AS
SELECT 
    b.BookingID, 
    b.BookingStatus, 
    b.StartDate, 
    b.EndDate, 
    e.EventName, 
    v.VenueName
FROM dbo.Bookings b
JOIN dbo.Events e ON b.EventID = e.EventID
JOIN dbo.Venues v ON b.VenueID = v.VenueID;