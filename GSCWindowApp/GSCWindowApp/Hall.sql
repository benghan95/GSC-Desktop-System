use gsc;

drop table screen;

CREATE TABLE Hall
(
  HallID int NOT NULL AUTO_INCREMENT,
  HallCapacity int(200),
  PRIMARY KEY (HallID)
);

INSERT INTO Hall (HallCapacity) VALUES(100);
Insert into Hall (HallCapacity) VALUES(100);
Insert into Hall (HallCapacity) VALUES(50);

select * from Hall;

