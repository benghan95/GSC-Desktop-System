use GSC;

drop table Staff;

CREATE TABLE Staff
(
  LoginID int NOT NULL AUTO_INCREMENT,
  password VARCHAR(20),
  isAdmin  BOOLEAN,
  PRIMARY KEY (LoginID)
);

INSERT INTO Staff (password,isAdmin) VALUES('derp',false);
INSERT INTO Staff (password,isAdmin) VALUES('me888',true);

SELECT * from Staff; 