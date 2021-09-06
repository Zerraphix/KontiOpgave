USE master
GO
IF(EXISTS(SELECT name FROM master.dbo.sysdatabases
WHERE name='VoresBankDB'))
BEGIN
ALTER DATABASE VoresBankDB SET single_user with rollback immediate
DROP DATABASE VoresBankDB
END
GO
CREATE DATABASE VoresBankDB
GO
USE VoresBankDB
GO

-- CREATE TABLES (start) *********************************************************************************************************************

CREATE TABLE Logind(
BrugerID int identity (1,1) PRIMARY KEY NOT NULL,
Brugernavn nvarchar(255),
Kodeord nvarchar (255)
)

CREATE TABLE Kortinfo(
Kortnummer int identity (1000,1) PRIMARY KEY NOT NULL,
Kortstatus bit NOT NULL, -- aktiv/spærret
Kortnavn nvarchar(255)
--FK_BrugerID int FOREIGN KEY REFERENCES Logind(BrugerID)
)
CREATE TABLE Konto(
KontoID int identity (1,1) PRIMARY KEY NOT NULL,
Kontotype nvarchar(255),
Beløb decimal,
Nemkonto bit NOT NULL,
FK_Kortnummer int FOREIGN KEY REFERENCES Kortinfo(Kortnummer)
)
CREATE TABLE Profil(
ProfilID int identity (1,1) PRIMARY KEY NOT NULL,
Navn nvarchar(255),
Kundetype nvarchar(255),
Fødselsdato Date,
Telefonnummer int,
Email nvarchar(255),
Adresse nvarchar(255),
Personnummer bigint,
FK_BrugerID int FOREIGN KEY REFERENCES Logind(BrugerID)
)

CREATE TABLE ProfilKonto(
ProfilkontoID int identity (1,1) PRIMARY KEY NOT NULL,
FK_ProfilID int FOREIGN KEY REFERENCES Profil(ProfilID),
FK_KontoID int FOREIGN KEY REFERENCES Konto(KontoID)
)

-- CREATE TABLES (end) **********


-- ---------------------------------------------------------------------------------------


-- INSERT DATA INTO TABLES (start) *********************************************************************************************************************

INSERT INTO Logind (Brugernavn, Kodeord)
VALUES 
('user1', 'Passw0rd!'),
('user2', 'Passw0rd!'),
('user3', 'Passw0rd!'),
('user4', 'Passw0rd!'),
('user5', 'Passw0rd!'),
('user6', 'Passw0rd!');
SELECT * FROM Logind;

INSERT INTO Kortinfo (Kortstatus, Kortnavn)
VALUES 
(1, 'Yes Bank Card'),
(0, 'Sofie'),
(1, 'Mastercard'),
(1, 'Fortnite'),
(1, 'Mastercard'),
(0, 'Visa'),
(0, 'Visa'),
(0, 'Fortnite');
SELECT * FROM Kortinfo;

INSERT INTO Konto (Kontotype, Beløb, Nemkonto, FK_Kortnummer)
VALUES
('NemKonto', 20000, 1, 1000),
('Opsparing', 2000, 0, 1000),
('NemKonto', 800, 1, 1002),
('Fortnite', 100, 0, 1002),
('NemKonto', 500, 1, 1003),
('NemKonto', 2200, 1, 1004),
('Opsparing', 10000, 0, 1004);
SELECT * FROM Konto;

INSERT INTO Profil (Navn, Kundetype, Fødselsdato, Telefonnummer, Email, Adresse, Personnummer, FK_BrugerID)
VALUES
('Mette efternavn', 'Kunde+', '1992-04-11', 12345678, 'NedeMette@gmail.com', 'Ole vej 2', 1104921234, 1),
('Benjamin efternavn', 'Ung', '2005-12-25', 39123253, 'NoneOfYourBuisseness@hotmail.com', 'Betlehelm 1', 2512054321, 2),
('Janekk efternavn', 'Kunde+', '1902-02-24', 69123456, 'JanekTheDude@outlook.com', 'strandvejen 42', 2402021234, 3),
('Jasmin efternavn', 'Standard', '1980-01-01', 98765432, 'Jasmin@outlook.dk', 'Pardis æblevej 90', 0101801234, 4),
('Ida efternavn', 'Ung', '2002-02-24', 69123455, 'idajungles@gmail.dk', 'Danmarkvej 7', 2402021234, 5),
('Jess efternavn', 'Standard', '1908-02-24', 69123457, 'jessman@outlook.com', 'jess vej 4', 2402026231, 6);
SELECT * FROM Profil;

INSERT INTO ProfilKonto (FK_ProfilID, FK_KontoID)
VALUES
(1, 1),
(1, 2),
(2, 3),
(2, 4),
(3, 5),
(4, 6),
(4, 7);
SELECT * FROM ProfilKonto;
SELECT Konto.*, Profil.*, Kortinfo.*
FROM ProfilKonto
INNER JOIN Profil ON FK_ProfilID = Profil.ProfilID
INNER JOIN Konto ON FK_KontoID = Konto.KontoID
INNER JOIN Kortinfo ON FK_Kortnummer = Kortinfo.Kortnummer;

-- INSERT DATA INTO TABLES (end) **********