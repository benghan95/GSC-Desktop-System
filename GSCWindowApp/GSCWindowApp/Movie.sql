use GSC;

CREATE TABLE Movie
(
  MovieID int NOT NULL AUTO_INCREMENT,
  Name VARCHAR(100),
  Rating VARCHAR(10),
  Duration  int(250),
  Summary VARCHAR(500),
  Venue VARCHAR(50),
  Cinema int(10),
  date DATE, 
  time TIME,
  PRIMARY KEY (MovieID)
);

INSERT INTO Movie (Name,Rating,Duration,Summary,Venue,Cinema,date,time) VALUES('Titanic','G', 90, 'JACK DIED', 'Paradigm', 2, '2016-10-20', '20:00:00');

SELECT Name from Movie;

SELECT * from Movie; 