﻿CREATE TABLE [BLOBs] (
[index] INTEGER  NOT NULL PRIMARY KEY AUTOINCREMENT,
[BLOBData] BLOB  NULL
);

CREATE TABLE [InputGroups] (
[Index] INTEGER  NOT NULL PRIMARY KEY,
[Type] INTEGER  NULL,
[Segments] INTEGER  NULL
);

CREATE TABLE [Parameters] (
[ParameterName] VARCHAR(32)  UNIQUE NOT NULL PRIMARY KEY,
[ParameterValue] TEXT  NULL
);

CREATE TABLE [Results] (
[ResultID] INTEGER  PRIMARY KEY AUTOINCREMENT NOT NULL,
[RunID] INTEGER  NULL,
[Iteration] INTEGER  NULL,
[TimeElapsed] FLOAT  NULL,
[Fitness] FLOAT  NULL
);

CREATE TABLE [Runs] (
[RunID] INTEGER  PRIMARY KEY AUTOINCREMENT NOT NULL,
[StartTime] TIMESTAMP  NULL,
[EndTime] TIMESTAMP  NULL,
[Status] INTEGER  NULL,
[BLOBindex] INTEGER  NULL,
[JobUUID] TEXT NULL
);

CREATE TABLE [Sources] (
[Index] INTEGER  PRIMARY KEY NOT NULL,
[Name] TEXT  NULL,
[Filename] TEXT  NULL,
[Width] INTEGER  NULL,
[Height] INTEGER  NULL,
[SampleType] INTEGER  NULL,
[Cached] BOOLEAN  NULL,
[ImageBLOBRef] INTEGER  NULL,
[SourceType] INTEGER  NULL
);
