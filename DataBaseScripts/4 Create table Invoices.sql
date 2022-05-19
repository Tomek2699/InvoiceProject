USE [ProjectInvoice]
GO

CREATE TABLE [Invoice](
	[InvoiceID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyID] [int] NOT NULL,
	[ForeignCompanyID] [int] NOT NULL,
	[NoInvoice] [varchar](50) NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[FinishDateDelivery] [datetime2](7) NOT NULL,
	[PaymentDate] [datetime2](7) NOT NULL,
	[PaymentWay] [varchar](30) NOT NULL,
	[IsPay] [bit] NULL,

CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED
(
	[InvoiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_OurCompany] FOREIGN KEY([CompanyID])
REFERENCES [OurCompany] ([CompanyID])
GO

ALTER TABLE [Invoice] CHECK CONSTRAINT [FK_Invoice_OurCompany]
GO

ALTER TABLE [Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_ForeignCompany] FOREIGN KEY([ForeignCompanyID])
REFERENCES [ForeignCompany] ([ForeignCompanyID])
GO

ALTER TABLE [Invoice] CHECK CONSTRAINT [FK_Invoice_ForeignCompany]
GO