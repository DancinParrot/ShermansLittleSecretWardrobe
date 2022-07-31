# ShermansLittleSecretWardrobe
2022 Assignment Project for Ngee Ann Polytechnic's Secure Software Development Module.

# Important
If you have problems with applying migration for the table, AspNetRoles, do execute this script in the SQL Server Object Explorer in your Visual Studio.

```
CREATE TABLE [dbo].[AspNetRoles] (
    [Id]               NVARCHAR (450) NOT NULL,
    [Name]             NVARCHAR (256) NULL,
    [NormalizedName]   NVARCHAR (256) NULL,
    [ConcurrencyStamp] NVARCHAR (MAX) NULL,
    [CreatedDate]      DATETIME2 (7)  DEFAULT ('0001-01-01T00:00:00.0000000') NOT NULL,
    [IPAddress]        NVARCHAR (MAX) NULL,
    [description]      NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex]
    ON [dbo].[AspNetRoles]([NormalizedName] ASC) WHERE ([NormalizedName] IS NOT NULL);
```

Likewise, if you have problems with applying migration for the table, AuditRecord, do execute this script in the SQL Server Object Explorer in your Visual Studio.

```
CREATE TABLE [dbo].[AuditRecord] (
    [Audit_ID]        INT            IDENTITY (1, 1) NOT NULL,
    [AuditActionType] NVARCHAR (MAX) NOT NULL,
    [Username]        NVARCHAR (MAX) NOT NULL,
    [DateTimeStamp]   DATETIME2 (7)  NOT NULL,
    [ProductID]       INT            NOT NULL,
    CONSTRAINT [PK_AuditRecord] PRIMARY KEY CLUSTERED ([Audit_ID] ASC)
);
```
