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
  isAvailable BOOLEAN,
  PRIMARY KEY (movieID)
);

INSERT INTO Movie (name, ageRating, duration, summary, createdDate, isAvailable) 
	VALUES('Warcraft', 'PG', 120, 'Warcraft is a 2016 American action-fantasy film directed by Duncan Jones and written by Jones, Charles Leavitt and Chris Metzen.', '2016-05-23T12:00:00', true);
INSERT INTO Movie (name, ageRating, duration, summary, createdDate, isAvailable) 
	VALUES('Avengers 2', '13', 150, 'Marvel good movie', '2015-12-20T12:00:00', false);
INSERT INTO Movie (name, ageRating, duration, summary, createdDate, isAvailable) 
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
  seatsLayout VARCHAR(10000),
  movieID INT,
  hallID INT,
  PRIMARY KEY (showtimeID),
  CONSTRAINT FK_ToMovie FOREIGN KEY (movieID) REFERENCES Movie(movieID),
  CONSTRAINT FK_ToHall FOREIGN KEY (hallID) REFERENCES Hall(hallID)
);

INSERT INTO Showtime (startDateTime, endDateTime, ticketsAvailable, seatsLayout, movieID, hallID) 
	VALUES('2016-11-01T13:00:00', '2016-12-01T16:00:00', '300','A01 A02 A03 A04 A05 A06 A07 A08 A09 A10 A11 A12 A13 A14 A15 A16 A17 A18 A19 A20 
B01 B02 B03 B04 B05 B06 B07 B08 B09 B10 B11 B12 B13 B14 B15 B16 B17 B18 B19 B20 
C01 C02 C03 C04 C05 C06 C07 C08 C09 C10 C11 C12 C13 C14 C15 C16 C17 C18 C19 C20 
D01 D02 D03 D04 D05 D06 D07 D08 D09 D10 D11 D12 D13 D14 D15 D16 D17 D18 D19 D20 
E01 E02 E03 E04 E05 E06 E07 E08 E09 E10 E11 E12 E13 E14 E15 E16 E17 E18 E19 E20 
F01 F02 F03 F04 F05 F06 F07 F08 F09 F10 F11 F12 F13 F14 F15 F16 F17 F18 F19 F20 
G01 G02 G03 G04 G05 G06 G07 G08 G09 G10 G11 G12 G13 G14 G15 G16 G17 G18 G19 G20 
H01 H02 H03 H04 H05 H06 H07 H08 H09 H10 H11 H12 H13 H14 H15 H16 H17 H18 H19 H20 
I01 I02 I03 I04 I05 I06 I07 I08 I09 I10 I11 I12 I13 I14 I15 I16 I17 I18 I19 I20 
J01 J02 J03 J04 J05 J06 J07 J08 J09 J10 J11 J12 J13 J14 J15 J16 J17 J18 J19 J20 
K01 K02 K03 K04 K05 K06 K07 K08 K09 K10 K11 K12 K13 K14 K15 K16 K17 K18 K19 K20 
L01 L02 L03 L04 L05 L06 L07 L08 L09 L10 L11 L12 L13 L14 L15 L16 L17 L18 L19 L20 
M01 M02 M03 M04 M05 M06 M07 M08 M09 M10 M11 M12 M13 M14 M15 M16 M17 M18 M19 M20 
N01 N02 N03 N04 N05 N06 N07 N08 N09 N10 N11 N12 N13 N14 N15 N16 N17 N18 N19 N20 
O01 O02 O03 O04 O05 O06 O07 O08 O09 O10 O11 O12 O13 O14 O15 O16 O17 O18 O19 O20 
' , 3, 1);
INSERT INTO Showtime (startDateTime, endDateTime, ticketsAvailable, seatsLayout, movieID, hallID) 
	VALUES('2016-11-28T11:00:00', '2016-12-01T13:00:00', '118','A01 A02 A03 A04 A05 A06 A07 A08 A09 A10 A11 A12 A13 A14 A15 A16 A17 A18 A19 A20 
B01 B02 B03 B04 B05 B06 B07 B08 B09 B10 B11 B12 B13 B14 B15 B16 B17 B18 B19 B20 
C01 C02 C03 C04 C05 C06 C07 C08 C09 C10 C11 C12 C13 C14 C15 C16 C17 C18 C19 C20 
D01 D02 D03 D04 D05 D06 D07 D08 D09 D10 D11 D12 D13 D14 D15 D16 D17 D18 D19 D20 
E01 E02 E03 E04 E05 E06 E07 E08 E09 E10 E11 E12 E13 E14 E15 E16 E17 E18 E19 E20 
F01 F02 F03 F04 F05 F06 F07 F08 F09 F10 F11 F12 F13 F14 F15 F16 F17 F18 F19 F20 
G01 G02 G03 G04 G05 G06 G07 G08 G09 G10 G11 G12 G13 G14 G15 G16 G17 G18 G19 G20 
H01 H02 H03 H04 H05 H06 H07 H08 H09 H10 H11 H12 H13 H14 H15 H16 H17 H18 H19 H20 
I01 I02 I03 I04 I05 I06 I07 I08 I09 I10 I11 I12 I13 I14 I15 I16 I17 I18 I19 I20 
J01 J02 J03 J04 J05 J06 J07 J08 J09 J10 J11 J12 J13 J14 J15 J16 J17 J18 J19 J20 
K01 K02 K03 K04 K05 K06 K07 K08 K09 K10 K11 K12 K13 K14 K15 K16 K17 K18 K19 K20 
L01 L02 L03 L04 L05 L06 L07 L08 L09 L10 L11 L12 L13 L14 L15 L16 L17 L18 L19 L20 
M01 M02 M03 M04 M05 M06 M07 M08 M09 M10 M11 M12 M13 M14 M15 M16 M17 M18 M19 M20 
N01 N02 N03 N04 N05 N06 N07 N08 N09 N10 N11 N12 N13 N14 N15 N16 N17 N18 N19 N20 
O01 O02 O03 O04 O05 O06 O07 O08 O09 O10 O11 O12 O13 O14 O15 O16 O17 O18 O19 O20 
', 1, 2);

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
  CONSTRAINT FK_ToShowtime FOREIGN KEY (showtimeID) REFERENCES Showtime(showtimeID)
);

INSERT INTO Ticket (ticketCode, seatNo, ticketPrice, ticketType, showtimeID) 
	VALUES(1001, 'J1', 12.00, 'Couple', 2);
INSERT INTO Ticket (ticketCode, seatNo, ticketPrice, ticketType, showtimeID) 
	VALUES(1002, 'J2', 12.00, 'Couple', 2);

SELECT * FROM Ticket;
/* End Ticket table */
