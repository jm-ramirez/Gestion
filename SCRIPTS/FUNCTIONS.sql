CREATE FUNCTION `GetCompraArticulo`(plu INTEGER(11), fecha DATE)
    RETURNS double
    NOT DETERMINISTIC
    SQL SECURITY DEFINER
    COMMENT ''
BEGIN


RETURN (
SELECT IFNULL(
(SELECT IFNULL(a.`Importe`,0) Importe
FROM `cpracabecera` c, `cpraarticulo` a
WHERE c.id=a.`CbteId`
AND c.`CbteTipo` IN (1,6,81,82,11,51,83,111,12,991)
AND a.`Codigo`=plu
AND CAST(c.`CbteFecha` AS DATE) <= fecha
ORDER BY c.`CbteFecha` DESC LIMIT 1),0));



END



CREATE FUNCTION `GetExistencia`(plu VARCHAR(15))
    RETURNS double
    NOT DETERMINISTIC
    SQL SECURITY DEFINER
    COMMENT ''
BEGIN



return (SELECT IFNULL(SUM(Cantidad),0) Saldo FROM fichastock WHERE articulo=plu GROUP BY articulo);



END




CREATE FUNCTION `GetIdLocalidad`(cp VARCHAR(10), pcia VARCHAR(15))
    RETURNS int(11)
    NOT DETERMINISTIC
    SQL SECURITY DEFINER
    COMMENT ''
BEGIN



RETURN(SELECT IFNULL(l.`id`,0)

FROM localidad l

WHERE l.`codigopostal` = cp

AND l.`provincia` LIKE CONCAT(pcia,'%')

order by id desc LIMIT 1);





END




CREATE FUNCTION `GetSaldoAcumulado`(importe DOUBLE)
    RETURNS double
    NOT DETERMINISTIC
    SQL SECURITY DEFINER
    COMMENT ''
BEGIN

set @saldo = @saldo + importe;

return @saldo;



END



