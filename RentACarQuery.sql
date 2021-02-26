CREATE TABLE [dbo].[Colors] (
    [Id]        INT          IDENTITY (1, 1) NOT NULL,
    [ColorName] VARCHAR (20) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Brands] (
    [Id]        INT          IDENTITY (1, 1) NOT NULL,
    [BrandName] VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Cars] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [BrandId]     INT          NULL,
    [ColorId]     INT          NULL,
    [ModelYear]   INT          NULL,
    [DailyPrice]  MONEY        NULL,
    [Description] VARCHAR (50) NULL,
    CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Cars] FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brands] ([Id]),
    CONSTRAINT [FK_Cars2] FOREIGN KEY ([ColorId]) REFERENCES [dbo].[Colors] ([Id])
);

CREATE TABLE [dbo].[Users] (
    [Id]        INT          IDENTITY (1, 1) NOT NULL,
    [FirstName] VARCHAR (50) NULL,
    [LastName]  VARCHAR (50) NULL,
    [Email]     VARCHAR (50) NULL,
    [Password]  VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Customers] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [UserId]      INT          NULL,
    [CompanyName] VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);

CREATE TABLE [dbo].[Rentals] (
    [Id]         INT      IDENTITY (1, 1) NOT NULL,
    [CarId]      INT      NULL,
    [CustomerId] INT      NULL,
    [RentDate]   DATETIME NULL,
    [ReturnDate] DATETIME NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Rentals_Cars] FOREIGN KEY ([CarId]) REFERENCES [dbo].[Cars] ([Id]),
    CONSTRAINT [FK_Rentals_Customers] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([Id])
);

CREATE TABLE [dbo].[CarImages] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [CarId]     INT            NULL,
    [ImagePath] NVARCHAR (MAX) NULL,
    [Date]      DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CarImages_Cars] FOREIGN KEY ([CarId]) REFERENCES [dbo].[Cars] ([Id])
);

