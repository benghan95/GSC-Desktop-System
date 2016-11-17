use gsc;

CREATE TABLE TicketHistory
(
  code int NOT NULL AUTO_INCREMENT,
  Number int(200),
  type VARCHAR(10),
  PRIMARY KEY (code)
);

INSERT INTO TicketHistory (Number,type) VALUES(3, 'adult');

select * from TicketHistory;