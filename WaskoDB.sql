CREATE DATABASE WASKO;
USE WASKO;

CREATE TABLE cars (
	id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
	manufacturer CHAR(15) NOT NULL,
	model CHAR(15) NOT NULL,
	capacity FLOAT NOT NULL
)
ENGINE = innodb
DEFAULT CHARACTER SET utf8 COLLATE utf8_unicode_ci;

