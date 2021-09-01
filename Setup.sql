/* NOTE Name your table. Give an int, it cannot be null it must have a value. Every collection needs a primary key which is what it's indexed by. AUTO_INCREMENT means everytime I create one of these, automatically create it for the next one. The Id is not a super private thing. So you don't need a ton of unique keys. If I delete two, it's going to create four it doesn't delete that position. primary lets you have intellisense. */
/* NOTE We only need to do this at the start of the application the very first time. This isn't something you are going to attach to actual code. Once you create that table, you will realisticly never do it again. This is VSCode talking to */
/* NOTE The default timestamps that were built in. Line 5 is where we do things unique to us. There is no such thing as a string in mySQL it's a varchar. It's not characters, its bytes. But in most case a character is a single byte. Don't assume thats 255 characters, it's bytes. There is no such thing as bool in MySql you use TINYINT it defaults to binary, 0 is false, 1 is true. */
CREATE TABLE knights (
  id int NOT NULL primary key AUTO_INCREMENT comment 'primary key',
  name varchar(255) NOT NULL comment 'knight name',
  kingdom varchar(255) NOT NULL comment 'knight kingdom',
  age INT NOT NULL comment 'knight age'
) default charset utf8 comment '';
/*REVIEW */
Create TABLE castles (
  id int NOT NULL primary key AUTO_INCREMENT comment 'primary key',
  name VARCHAR(255) NOT NULL comment 'knight name',
  knightId int NOT NULL,
  FOREIGN KEY (knightId) REFERENCES knights(id) ON DELETE CASCADE
);
-- NOTE ALTERING A TABLE. So if you want to add, edit or do whatever with the column. Alter Table's come into play when you have a ton of stuff done. If you want something required, use NOTNULL
-- ALTER TABLE
-- ALTER COLUMN name VARCHAR(255) comment 'knight name';
-- NOTE CRUD METHODS
-- SECTION CREATE
INSERT INTO
  knights (name, kingdom, age)
VALUES
  ('Charles', 'Britain', 40);
  /*
                          SECTION READ '*' is all columns
                          */
SELECT
  *
FROM
  knights;
-- SECTION GetBY
SELECT
  *
from
  knights
WHERE
  id = 2
LIMIT
  1;
-- SECTION UPDATE
UPDATE
  knights
SET
  name = "Matthew "
WHERE
  id = 2;
  /*SECTION DESTROY*/
DELETE FROM
  knights
WHERE
  id = 5
LIMIT
  1;
  /*SECTION Danger
              Removes all rows if not provided where*/
  -- FIXME DELETES ALL INFO
DELETE FROM
  knights;
-- FIXME DELETES WHOLE TABLE
  DROP TABLE knights;
-- FIXME DELETS THE WHOLE DATABASE
  DROP DATABASE Classroom;