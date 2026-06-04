ALTER VIEW View_BookingSummary AS
SELECT 
    b.BookingID, 
    b.StartDate, 
    b.EndDate, 
    e.EventName, 
    v.VenueName,
    et.Name AS EventTypeName,
    b.BookingStatus,
    b.EventTypeID -- This is the missing piece!
FROM Bookings b
JOIN Events e ON b.EventID = e.EventID
JOIN Venues v ON b.VenueID = v.VenueID
JOIN EventTypes et ON b.EventTypeID = et.EventTypeID;