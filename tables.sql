USE master

-- Проверка на существование базы

if db_id('RPBDIS')IS NOT NULL

DROP DATABASE RPBDIS

-- Создание базы

CREATE DATABASE RPBDIS

GO

ALTER DATABASE RPBDIS SET RECOVERY SIMPLE

GO

USE RPBDIS

IF OBJECT_ID(N'dbo.Companies','U') IS NOT NULL

DROP TABLE "dbo.Companies"

IF OBJECT_ID(N'dbo.ProductionTypes','U') IS NOT NULL

DROP TABLE "dbo.ProductionTypes"

IF OBJECT_ID(N'dbo.Productions','U') IS NOT NULL

DROP TABLE "dbo.Productions"

IF OBJECT_ID(N'dbo.Outputs','U') IS NOT NULL

DROP TABLE "dbo.Outputs"

IF OBJECT_ID(N'dbo.Releases','U') IS NOT NULL

DROP TABLE "dbo.Releases"

--IsOperable

--Создание таблиц

CREATE TABLE dbo.Companies (CompanyID int Identity(1,1) not null PRIMARY KEY, NameOfCompany nvarchar(50), HeadName nvarchar(50), TypeOfActivity nvarchar(50), OwnershipType nvarchar(50))--Предприятия

CREATE TABLE dbo.ProductionTypes (TypeID int IDENTITY(1,1) not null PRIMARY KEY, ProductionType nvarchar(50))--Виды продукции

CREATE TABLE dbo.Productions (ProductionID int IDENTITY(1,1) not null PRIMARY KEY, TypeID int, ProductionName nvarchar(50), Features nvarchar(50), ProductionTypeUnit nvarchar(50), Photo image))--Продукция

CREATE TABLE dbo.Outputs(OutputID int IDENTITY(1,1) not null PRIMARY KEY, TypeID int, OutputPlan int, OutputFact int, CompanyID int, ProductionID int, OutputYear int)--Выпуск

CREATE TABLE dbo.Releases(ReleaseID int IDENTITY(1,1) not null PRIMARY KEY, TypeID int, ReleasesPlan int, ReleasesFact int, CompanyID int, ProductionID int, ReleaseYear int)--Реализация

--Создание связей между таблицами

ALTER TABLE dbo.Productions ADD FOREIGN KEY (TypeID) REFERENCES dbo.ProductionTypes (TypeID)

ALTER TABLE dbo.Releases ADD FOREIGN KEY (CompanyID) REFERENCES dbo.Companies (CompanyID)

ALTER TABLE dbo.Releases ADD FOREIGN KEY (ProductionID) REFERENCES dbo.Productions (ProductionID)

ALTER TABLE dbo.Releases ADD FOREIGN KEY (TypeID) REFERENCES dbo.Productions (TypeID)

ALTER TABLE dbo.Outputs ADD FOREIGN KEY (CompanyID) REFERENCES dbo.Companies (CompanyID)

ALTER TABLE dbo.Outputs ADD FOREIGN KEY (ProductionID) REFERENCES dbo.Productions (ProductionID)

ALTER TABLE dbo.Outputs ADD FOREIGN KEY (TypeID) REFERENCES dbo.Productions (TypeID)
