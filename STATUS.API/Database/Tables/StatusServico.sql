CREATE TABLE [dbo].[StatusServico]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Autorizador] VARCHAR(10),
	[Autorizacao4] BIT,
	[RetornoAutorizacao4] BIT,
	[Inutilizacao4] BIT,
	[ConsultaProtocolo4] BIT,
	[StatusServico4] BIT,
	[TempoMedio] VARCHAR(10),
	[ConsultaCadastro4] BIT,
	[RecepcaoEvento4] BIT,
	[DataRegistro] DateTime
)
