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

CREATE TABLE Logind(
BrugerID int identity (1,1) PRIMARY KEY NOT NULL,
Brugernavn nvarchar(255),
Kodeord nvarchar (255)
)

CREATE TABLE Kortinfo(
Kortnummer int identity (1000,1) PRIMARY KEY NOT NULL,
Kortstatus bit NOT NULL, -- aktiv/spærret
Kortnavn nvarchar(255),
FK_Nemkonto bit NOT NULL,
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
Fødselsdato DateTime,
Telefonnummer int,
Email nvarchar(255),
Adresse nvarchar(255),
Personnummer int,
FK_BrugerID int FOREIGN KEY REFERENCES Logind(BrugerID)
)

CREATE TABLE ProfilKonto(
ProfilkontoID int identity (1,1) PRIMARY KEY NOT NULL,
FK_ProfilID int FOREIGN KEY REFERENCES Profil(ProfilID),
FK_KontoID int FOREIGN KEY REFERENCES Konto(KontoID)
)



