USE [ProjectInvoice]
GO

CREATE TABLE [Commodity](
	[CommodityID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceID] [int] NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[Amount] [int] NOT NULL,
	[Unit] [varchar](30) NOT NULL,
	[PriceNetto] [int] NOT NULL,
	[ValueNetto] [int] NOT NULL,
	[VAT] [int] NOT NULL,
	[AmountVAT] [int] NOT NULL,
	[AmountBrutto] [int] NOT NULL,

CONSTRAINT [PK_Commodity] PRIMARY KEY CLUSTERED
(
	[CommodityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [Commodity]  WITH CHECK ADD  CONSTRAINT [FK_Commodity_Invoice] FOREIGN KEY([InvoiceID])
REFERENCES [Invoice] ([InvoiceID])
GO

ALTER TABLE [Invoice] CHECK CONSTRAINT [FK_Commodity_Invoice]
GO