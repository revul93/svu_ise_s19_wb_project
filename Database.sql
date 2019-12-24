CREATE TABLE [dbo].[Orphanage] (
    [id]                  INT            IDENTITY (1, 1) NOT NULL,
    [name]                NVARCHAR (50)  NOT NULL,
    [logo]                NVARCHAR (100) NULL,
    [description]         NVARCHAR (MAX) NULL,
    [address_city]        NVARCHAR (50)  NOT NULL,
    [address_street]      NVARCHAR (50)  NOT NULL,
    [address_description] NVARCHAR (MAX) NOT NULL,
    [address_coordinates] VARCHAR (50)   NULL,
    [email]               VARCHAR (50)   NULL,
    [telephone]           VARCHAR (20)   NOT NULL,
    [capacity]            INT            NULL,
    [sponsored_orphans]   INT            NULL,
    CONSTRAINT [Pk_Orphanage] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[User] (
    [id]           INT            IDENTITY (1, 1) NOT NULL,
    [username]     VARCHAR (50)   NOT NULL,
    [password]     VARCHAR (50)   NOT NULL,
    [name]         NVARCHAR (50)  NULL,
    [role]         NVARCHAR (100) NULL,
    [mobile]       VARCHAR (20)   NULL,
    [email]        VARCHAR (50)   NULL,
    [is_admin]     BIT            DEFAULT ((0)) NULL,
    [orphanage_id] INT            NULL,
    CONSTRAINT [Pk_User] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [Fk_Orphanage_Manager] FOREIGN KEY ([orphanage_id]) REFERENCES [dbo].[Orphanage] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE [dbo].[Plan] (
    [id]              INT            IDENTITY (1, 1) NOT NULL,
    [orphanage_id]    INT            NOT NULL,
    [name]            NVARCHAR (100) NOT NULL,
    [description]     NVARCHAR (MAX) NULL,
    [type]            NVARCHAR (50)  NOT NULL,
    [amount_required] INT            NOT NULL,
    [completed]       BIT            DEFAULT ((0)) NOT NULL,
    [hidden]          BIT            DEFAULT ((0)) NULL,
    CONSTRAINT [Pk_Plan] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [Fk_Plan_Orphanage] FOREIGN KEY ([orphanage_id]) REFERENCES [dbo].[Orphanage] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE [dbo].[Donor] (
    [id]                  INT            IDENTITY (1, 1) NOT NULL,
    [name]                NVARCHAR (50)  NOT NULL,
    [address_city]        NVARCHAR (50)  NOT NULL,
    [address_street]      NVARCHAR (50)  NOT NULL,
    [address_description] NVARCHAR (MAX) NULL,
    [mobile]              VARCHAR (20)   NOT NULL,
    [email]               VARCHAR (50)   NULL,
    CONSTRAINT [Pk_Donor] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Donation] (
    [id]                 INT           IDENTITY (1, 1) NOT NULL,
    [donor_id]           INT           NOT NULL,
    [plan_id]            INT           NOT NULL,
    [amount]             INT           NOT NULL,
    [method]             NVARCHAR (50) NULL,
    [donor_contacted]    BIT           DEFAULT ((0)) NULL,
    [donation_collected] BIT           DEFAULT ((0)) NULL,
    CONSTRAINT [Pk_Donation] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [Fk_Donation_Plan] FOREIGN KEY ([plan_id]) REFERENCES [dbo].[Plan] ([Id]),
    CONSTRAINT [Fk_Donation_Donor] FOREIGN KEY ([donor_id]) REFERENCES [dbo].[Donor] ([Id])
);