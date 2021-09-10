CREATE OR ALTER PROCEDURE buscarServicosCompartilhadosPorEstado
	@UF VARCHAR(2)
AS

SELECT 
	SC.ID,
	SC.SIGLA,
	SC.UF
FROM ServicosCompartilhados SC 
WHERE SC.UF = @UF