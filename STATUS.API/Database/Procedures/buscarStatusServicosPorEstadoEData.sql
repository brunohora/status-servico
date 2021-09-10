CREATE OR ALTER PROCEDURE buscarStatusServicosPorEstadoEData
	@UF VARCHAR(2), @DATA VARCHAR(08)
AS

SELECT 
	SS.*
FROM StatusServico SS
LEFT JOIN ServicosCompartilhados SC ON SC.UF = @UF
WHERE SC.UF = @UF AND
	CONVERT(VARCHAR(10), SS.DataRegistro, 112) = @DATA