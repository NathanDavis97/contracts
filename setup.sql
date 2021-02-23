USE bricks3;

-- CREATE TABLE jobs
-- (
--   id INT AUTO_INCREMENT,
--   Title VARCHAR(255) NOT NULL,
--   Pay DECIMAL(10 , 2) NOT NULL,
--   PRIMARY KEY (id)
-- );


-- CREATE TABLE contractors
-- (
--   id INT AUTO_INCREMENT,
--   Name VARCHAR(255) NOT NULL,
--   yearsInProf INT,
--   PRIMARY KEY (id)
-- );

CREATE TABLE contracts
(
  id INT AUTO_INCREMENT,
  jobId INT,
  contractorId INT,
  PRIMARY KEY (id),

FOREIGN KEY (jobId)
  REFERENCES jobs(id)
  ON DELETE CASCADE,

FOREIGN KEY (contractorId)
  REFERENCES contractors(id)
  ON DELETE CASCADE
);



-- DECIMAL( NUMS , NUMSPASTDEC)

-- CREATE
-- INSERT INTO burgers
-- (name, description, price)
-- VALUES
-- ("Santa Burger", "Its from very fatty", 201.21);


/* Find All of Collection */
/* SELECT * FROM burgers; */


/* Find by Value from Collection */
/* SELECT * FROM burgers WHERE name="bingo" OR age=6; */



/* Add To Collection */
/* INSERT INTO burgers (name, age, hungry) VALUES ("spot", 2, true);
INSERT INTO burgers (name, age, hungry) VALUES ("rover", 5, true);
INSERT INTO burgers (name, age, hungry) VALUES ("max", 6, true);
INSERT INTO burgers (name, age, hungry) VALUES ("rin-tin-tin", 25, true); */



-- DROP TABLE bricks