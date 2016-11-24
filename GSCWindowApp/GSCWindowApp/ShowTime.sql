use gsc;

CREATE TABLE ShowTime
(
  ShowTimeID int NOT NULL AUTO_INCREMENT,
  StartTime time,
  EndTime time,
  TicketAvailable int,
  MovieID int,
  HallID int,
  PRIMARY KEY (ShowTimeID),
  foreign Key (MovieID) References Movie(MovieID),
  foreign Key (HallID) references Hall(HallID)
);

insert into ShowTime  (StartTime,EndTime,TicketAvailable,MovieID,HallID) values ('12:00:00', '14:00:00', 10, 1, 3);

select * from test;