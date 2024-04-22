--
-- File generated with SQLiteStudio v3.4.4 on Mon Apr 22 14:42:58 2024
--
-- Text encoding used: System
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Table: Addresses
CREATE TABLE IF NOT EXISTS Addresses (
    uid      TEXT (36)  PRIMARY KEY
                        NOT NULL,
    line1    TEXT (255) NOT NULL,
    line2    TEXT (255),
    line3    TEXT (255),
    town     TEXT (255) NOT NULL,
    postcode TEXT (8)   NOT NULL
);


COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
