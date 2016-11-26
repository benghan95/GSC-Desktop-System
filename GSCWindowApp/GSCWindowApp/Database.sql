DROP DATABASE IF EXISTS GSC;

CREATE DATABASE GSC;

USE GSC;

/* Create Staff table */
DROP TABLE IF EXISTS Staff;

CREATE TABLE Staff
(
  staffID INT NOT NULL AUTO_INCREMENT,
  username VARCHAR(20),
  email VARCHAR(30),
  password VARCHAR(20),
  isAdmin  BOOLEAN,
  PRIMARY KEY (staffID)
);

INSERT INTO Staff (username, email, password, isAdmin) 
	VALUES('beng', 'beng@gmail.com', 'beng123', true);
INSERT INTO Staff (username, email, password, isAdmin) 
	VALUES('derp', 'derp@gmail.com', '1234', false);
INSERT INTO Staff (username, email, password, isAdmin) 
	VALUES('hello', 'hello@gmail.com', '1234', false);
INSERT INTO Staff (username, email, password, isAdmin) 
	VALUES('wengfai', 'wengfai@gmail.com', 'wengfai123', true);
INSERT INTO Staff (username, email, password, isAdmin) 
	VALUES('cl', 'cl@gmail.com', 'cl123', true);
INSERT INTO Staff (username, email, password, isAdmin) 
	VALUES('ezra', 'ezra@gmail.com', 'ezra123', true);

SELECT * FROM Staff; 
/* End Staff table */

/* Create Movie table */
DROP TABLE IF EXISTS Movie;

CREATE TABLE Movie
(
  movieID INT NOT NULL AUTO_INCREMENT,
  name VARCHAR(100),
  ageRating VARCHAR(10),
  duration  INT(32),
  summary VARCHAR(500),
  createdDate DATETIME,
  available BOOLEAN,
  PRIMARY KEY (movieID)
);

INSERT INTO Movie (name, ageRating, duration, summary, createdDate, available) 
	VALUES('Warcraft', 'PG', 120, 'Warcraft is a 2016 American action-fantasy film directed by Duncan Jones and written by Jones, Charles Leavitt and Chris Metzen.', '2016-05-23T12:00:00', true);
INSERT INTO Movie (name, ageRating, duration, summary, createdDate, available) 
	VALUES('Avengers 2', '13', 150, 'Marvel good movie', '2015-12-20T12:00:00', false);
INSERT INTO Movie (name, ageRating, duration, summary, createdDate, available) 
	VALUES('Civil War', '13', 180, 'Captain America vs Ironman', '2016-08-13T12:00:00', true);

SELECT * FROM Movie; 
/* End Movie table */

/* Create Hall table */
DROP TABLE IF EXISTS Hall;

CREATE TABLE Hall
(
  hallID INT NOT NULL AUTO_INCREMENT,
  capacity INT(32),
  noOfRows INT(32),
  noOfColumns INT(32),
  PRIMARY KEY (hallID)
);

INSERT INTO Hall (capacity, noOfRows, noOfColumns) 
	VALUES('300', '15', '20');
INSERT INTO Hall (capacity, noOfRows, noOfColumns) 
	VALUES('120', '10', '12');
INSERT INTO Hall (capacity, noOfRows, noOfColumns) 
	VALUES('210', '14', '15');
INSERT INTO Hall (capacity, noOfRows, noOfColumns) 
	VALUES('180', '12', '15');

SELECT * FROM Hall;
/* End Hall table */

/* Create Showtime table */
DROP TABLE IF EXISTS Showtime;

CREATE TABLE Showtime
(
  showtimeID INT NOT NULL AUTO_INCREMENT,
  startDateTime DATETIME,
  endDateTime DATETIME,
  ticketsAvailable INT(32),
  movieID INT,
  hallID INT,
  PRIMARY KEY (showtimeID),
  FOREIGN KEY (movieID) REFERENCES Movie(movieID),
  FOREIGN KEY (hallID) REFERENCES Hall(hallID)
);

INSERT INTO Showtime (startDateTime, endDateTime, ticketsAvailable, movieID, hallID) 
	VALUES('2016-09-01T13:00:00', '2016-09-01T16:00:00', '300', 3, 1);
INSERT INTO Showtime (startDateTime, endDateTime, ticketsAvailable, movieID, hallID) 
	VALUES('2016-08-28T11:00:00', '2016-09-01T13:00:00', '118', 1, 2);

SELECT * FROM Showtime;
/* End Showtime table */

/* Create Ticket table */
DROP TABLE IF EXISTS Ticket;

CREATE TABLE Ticket
(
  ticketID INT NOT NULL AUTO_INCREMENT,
  ticketCode INT(32),
  seatNo VARCHAR(3),
  ticketPrice DOUBLE,
  ticketType VARCHAR(10),
  showtimeID INT,
  PRIMARY KEY (ticketID),
  FOREIGN KEY (showtimeID) REFERENCES Showtime(showtimeID)
);

INSERT INTO Ticket (ticketCode, seatNo, ticketPrice, ticketType, showtimeID) 
	VALUES(1001, 'J1', 12.00, 'Couple', 2);
INSERT INTO Ticket (ticketCode, seatNo, ticketPrice, ticketType, showtimeID) 
	VALUES(1002, 'J2', 12.00, 'Couple', 2);

SELECT * FROM Ticket;
/* End Ticket table */
