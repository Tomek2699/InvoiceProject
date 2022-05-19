USE [ProjectInvoice]
GO

CREATE TABLE [OurCompany](
	[CompanyID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [varchar](150) NOT NULL,
	[Address] [varchar](200) NOT NULL,
	[NIP] [varchar](20) NOT NULL,
	[PhoneNumber] [char](9) NOT NULL,
	[BankName] [varchar](50) Not NULL,
	[BankAccountNumber] [varchar](100) Not NULL,

CONSTRAINT [PK_OurCompany] PRIMARY KEY CLUSTERED
(
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO