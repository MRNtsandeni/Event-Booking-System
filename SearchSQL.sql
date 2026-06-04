CREATE VIEW View_BookingSummary AS
SELECT 
    b.BookingID,
    b.StartDate,
    b.EndDate,
    b.BookingStatus,
    v.VenueName,
    v.Location AS VenueLocation,
    e.EventName,
    e.Description AS EventDescription
FROM Bookings b
INNER JOIN Venues v ON b.VenueID = v.VenueID
INNER JOIN Events e ON b.EventID = e.EventID;
