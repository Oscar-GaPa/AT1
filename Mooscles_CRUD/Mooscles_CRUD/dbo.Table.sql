CREATE TABLE [dbo].[Customer] (
    [Customer_ID]   INT            IDENTITY (1, 1) NOT NULL,
    [Customer_Name] NVARCHAR (50)  NULL,
    [Address]       NVARCHAR (100) NULL,
    [Phone_NO]      INT            NULL,
    [DOB]           NVARCHAR (50)  NULL,
    [Starting_Date] NVARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([Customer_ID] ASC)
);

