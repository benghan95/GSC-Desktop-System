use gsc;

drop table TicketHistory;

CREATE TABLE Ticket
(
  TicketID int NOT NULL AUTO_INCREMENT,
  TicketCode int(200),
  SeatNo VARCHAR(10),
  TicketPrice double,
  TicketType VARCHAR(50),
  ShowTimeID int,
  PRIMARY KEY (TicketID),
  foreign Key (ShowTimeID) References ShowTime(ShowTimeID)
);

INSERT INTO Ticket (TicketCode,TicketPrice,TicketType,ShowTimeID) VALUES(1000, 20.00, 'adult', 1);
INSERT INTO Ticket (TicketCode,TicketPrice,TicketType,ShowTimeID) VALUES(2000, 15.00, 'child', 1);


select * from Ticket;
