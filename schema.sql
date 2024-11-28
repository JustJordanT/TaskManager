CREATE TABLE Tenant (
    Id INT PRIMARY KEY,
    TenantName NVARCHAR(255),
    TenantDescription NVARCHAR(255),
    Date_Created DateTime,
    Date_Modified DateTime
)

CREATE TABLE ApplicationUser ( 
    Id INT PRIMARY KEY,
    TenantId INT FOREIGN KEY REFERENCES Tenant(Id),
    EntraID NVARCHAR(255),
    DisplayName NVARCHAR(255),
    Email NVARCHAR(255)
)

CREATE TABLE Team (
    Id INT PRIMARY KEY,
    TenantId INT FOREIGN KEY REFERENCES Tenant(Id),
    TeamName NVARCHAR(255),
    TeamOwner INT FOREIGN KEY REFERENCES ApplicationUser(Id),
    TeamDescription NVARCHAR(255),
    TeamStatus NVARCHAR(255),
    Date_Created DateTime,
    Date_Modified DateTime,
    Date_Deleted DateTime
)

CREATE TABLE Projects (
    Id INT PRIMARY KEY,
    TenantId INT FOREIGN KEY REFERENCES Tenant(Id),
    ProjectName NVARCHAR(255),
    ProjectOwner INT FOREIGN KEY REFERENCES ApplicationUser(Id),
    ProjectDescription NVARCHAR(255),
    ProjectStatus NVARCHAR(255),
    Date_Created DateTime,
    Date_Modified DateTime,
    Date_Deleted DateTime
)

CREATE TABLE TeamMembers (
    TeamId INT FOREIGN KEY REFERENCES Team(Id),
    UserId INT FOREIGN KEY REFERENCES ApplicationUser(Id),
    PRIMARY KEY (TeamId, UserId)
)

CREATE TABLE ProjectMembers (
    ProjectId INT FOREIGN KEY REFERENCES Projects(Id),
    UserId INT FOREIGN KEY REFERENCES ApplicationUser(Id),
    TeamId INT FOREIGN KEY REFERENCES Team(Id),
    PRIMARY KEY (ProjectId, UserId, TeamId)
)

CREATE TABLE Tasks (
    Id INT PRIMARY KEY,
    TaskName NVARCHAR(255),
    TaskDescription NVARCHAR(255),
    TaskStatus NVARCHAR(255),
    ProjectId INT FOREIGN KEY REFERENCES Projects(Id),
    AssignedTo INT FOREIGN KEY REFERENCES ApplicationUser(Id),
    Date_Created DateTime,
    Date_Modified DateTime,
    Date_Deleted DateTime
)

CREATE TABLE TeamProjects (
    TeamId INT FOREIGN KEY REFERENCES Team(Id),
    ProjectId INT FOREIGN KEY REFERENCES Projects(Id),
    PRIMARY KEY (TeamId, ProjectId)
)
