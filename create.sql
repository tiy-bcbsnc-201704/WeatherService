USE master

IF EXISTS(SELECT * FROM sys.databases WHERE name = 'WeatherService')
	DROP DATABASE WeatherService
GO

CREATE DATABASE WeatherService
GO

USE WeatherService

CREATE TABLE Earthquake
(
      EarthquakeId                 int identity(1,1) primary key not null,
      EventTime                    datetime NOT NULL,
      Latitude                     decimal,
      Longitude                    decimal,
      Depth                        decimal,
      Magnitude                    decimal,
      MagnitudeType                NVARCHAR(2),
      SeismicStations              int,
      AzimuthalGap                 decimal,
      EpiCenterDistance            decimal,
      RootMeanSquare               decimal,
      DataContributorId            NVARCHAR(2), 
      NetworkIdentifier            NVARCHAR(10),
      RecentUpdateTime             datetime ,
      GeographicRegion             NVARCHAR(10),
      SeismicEventType             NVARCHAR(20),
      HorizontalError              decimal ,
      DepthError                   decimal ,
      MagnitudeError               decimal ,
      MagniteOfEarthquake          int   ,
      EventsReviewed               NVARCHAR(20),
      LocationSource               NVARCHAR(2),     
      MagnitudeSource              NVARCHAR(2)
)

CREATE TABLE SolarWind
(
SolarWindId INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
MeasurementDateTime DATETIME NOT NULL,
XCoordinate DECIMAL(5,2) NOT NULL,
YCoordinate DECIMAL(5,2) NOT NULL,
ZCoordinate DECIMAL(5,2) NOT NULL,
Longitude DECIMAL(5,2) NOT NULL,
Latitude DECIMAL(5,2) NOT NULL,
Temperature DECIMAL(5,2) NOT NULL
)

create table WeatherDataService
(
  Id INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
  StationID NVARCHAR(20) NOT NULL,
  Location NVARCHAR(500) NOT NULL,
  Latitude DECIMAL,
  Longitude DECIMAL,
  ObservationTime DATETIME,
  WeatherCondition NVARCHAR(20)NOT NULL,
  Temperature DECIMAL,
  Humidity INT,
  CreationDateTime DATETIME  
)

CREATE TABLE ServiceEvent (
EventId INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
ServiceName NVARCHAR(100) NOT NULL,
EventDescription NVARCHAR(200) NOT NULL,
EventDateTime DATETIME NOT NULL,
)