use GSC;

drop table Movie;

CREATE TABLE Movie
(
  MovieID int NOT NULL AUTO_INCREMENT,
  Name VARCHAR(100),
  Rating VARCHAR(10),
  Duration  int(250),
  Summary VARCHAR(500),
  CreatedDate DATE, 
  EndDate DATE,
  PRIMARY KEY (MovieID)
);

INSERT INTO Movie (Name,Rating,Duration,Summary,CreatedDate,EndDate) VALUES('Titanic','G', 90, 'JACK DIED', '2016-11-25', '2016-12-10');

