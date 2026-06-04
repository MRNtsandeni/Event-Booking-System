-- Venue Table
CREATE TABLE `bookingsystem`.`venue` (
  `VenueID` INT NOT NULL AUTO_INCREMENT,
  `VenueName` VARCHAR(100) NOT NULL,
  `Location` VARCHAR(255) NOT NULL,
  `Capacity` INT NOT NULL,
  `ImageUpload` VARCHAR(255) NULL,
  PRIMARY KEY (`VenueID`));

-- Event Table
CREATE TABLE `bookingsystem`.`events` (
  `EventID` INT NOT NULL AUTO_INCREMENT,
  `EventName` VARCHAR(100) NOT NULL,
  `Description` VARCHAR(255) NOT NULL,
  `EventDate` DATE NOT NULL,
  `EventTime` TIME NOT NULL,
  `ImageUpload` VARCHAR(255) NULL,
  PRIMARY KEY (`EventID`));

-- Booking Table
CREATE TABLE `bookingsystem`.`booking` (
  `BookingID` INT NOT NULL AUTO_INCREMENT,
  `VenueID` INT NOT NULL,
  `EventID` INT NOT NULL,
  `BookingStatus` VARCHAR(45) NULL,
  `StartDate` DATETIME NOT NULL,
  `EndDate` DATETIME NOT NULL, -- Changed from EndTime to EndDate for consistency
  PRIMARY KEY (`BookingID`),
  CONSTRAINT `FK_Venue` FOREIGN KEY (`VenueID`) REFERENCES `bookingsystem`.`venue` (`VenueID`),
  CONSTRAINT `FK_Event` FOREIGN KEY (`EventID`) REFERENCES `bookingsystem`.`events` (`EventID`)
);