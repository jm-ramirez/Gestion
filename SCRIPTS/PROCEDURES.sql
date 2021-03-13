CREATE PROCEDURE `REGINFO_CV_COMPRAS_ALICUOTAS`(periodo VARCHAR(6))
    NOT DETERMINISTIC
    SQL SECURITY DEFINER
    COMMENT ''
BEGIN
SELECT LPAD(CAST(c.`CbteTipo` AS CHAR),3,'0') TipoComprobante,
       LPAD(CAST(c.`CbtePtoVta` AS CHAR),5,'0') PuntoVenta,
       LPAD(CAST(c.`CbteNumero` AS CHAR),20,'0') NumeroComprobante,
	   CAST(c.`DocumentoTipo` AS CHAR) CodigoDocumentoVendedor,
       LPAD(REPLACE(CAST(c.`DocumentoNro` AS CHAR),'-',''),20,'0') NumeroIdentificacionVendedor,
       LPAD(CAST(TRUNCATE(ABS(IFNULL(d.`BaseImponible`,0))*100,0) AS CHAR),15,'0') ImporteNetoGravado,
       LPAD(CAST(IFNULL(d.`Codigo`,3) AS CHAR),4,'0') AlicuotaIVA,
       LPAD(CAST(TRUNCATE(ABS(IFNULL(d.`Importe`,0))*100,0) AS CHAR),15,'0') ImpuestoLiquidado
FROM cpracabecera c LEFT JOIN cpraalicuota d
ON d.`CbteId` = c.`Id`
WHERE c.`CbteTipo` NOT IN (991,992,993,994,995,996,91)
AND DATE_FORMAT(c.`FechaServicioDesde`,'%Y%m')=periodo;
END


CREATE PROCEDURE `REGINFO_CV_COMPRAS_CBTE`(periodo VARCHAR(6))
    NOT DETERMINISTIC
    SQL SECURITY DEFINER
    COMMENT ''
BEGIN
SELECT d.`CbteFecha` FechaComprobante,
       LPAD(CAST(d.`CbteTipo` AS CHAR),3,'0') TipoComprobante,
       LPAD(CAST(d.`CbtePtoVta` AS CHAR),5,'0') PuntoVenta,
       LPAD(CAST(d.`CbteNumero` AS CHAR),20,'0') NumeroComprobante,
       LPAD(' ',16,' ') DespachoImportacion,
       CAST(d.`DocumentoTipo` AS CHAR) CodigoDocumentoVendedor,
       LPAD(REPLACE(CAST(d.`DocumentoNro` AS CHAR),'-',''),20,'0') NumeroIdentificacionVendedor,
       RPAD(LEFT(d.`RazonSocial`,30),30,' ') DenominacionVendedor,
       LPAD(CAST(TRUNCATE(ABS(d.`ImporteTotal`)*100,0) AS CHAR),15,'0') ImporteTotalOperacion,
       LPAD(CAST(TRUNCATE(ABS(d.ImporteTotalConceptos)*100,0) AS CHAR),15,'0') ImporteTotalNoGravado,
       LPAD(CAST(TRUNCATE(ABS(d.`ImporteOpExentas`)*100,0) AS CHAR),15,'0') ImporteOperacionesExentas,
       LPAD(CAST(TRUNCATE(ABS(0)*100,0) AS CHAR),15,'0') ImportePagosCuentaIva,
       LPAD(CAST(TRUNCATE(ABS(impnacional)*100,0) AS CHAR),15,'0') ImportePercepcionesOtrosImpuestos,
       LPAD(CAST(TRUNCATE(ABS(d.`impprovincial`)*100,0) AS CHAR),15,'0') ImportePercepcionesIngresosBrutos,
       LPAD(CAST(TRUNCATE(ABS(d.impmunicipal)*100,0) AS CHAR),15,'0') ImportePercepcionesImpuestosMunicipales,
       LPAD(CAST(TRUNCATE(ABS(d.`impimpint`)*100,0) AS CHAR),15,'0') ImporteImpuestosInternos,
       'PES' CodigoMoneda,
       CONCAT(LPAD('1',4,'0'),LPAD('0',6,'0')) TipoCambio,
       IF(d.alicuotas=0 AND d.Letra='A',1,d.alicuotas) CantidadAlicuotasIVA,
       CASE
           WHEN d.alicuotas = 0 AND d.Letra='A' THEN 'E'
           ELSE ' '
       END AS CodigoOperacion,
       LPAD(CAST(TRUNCATE(d.credito*100,0) AS CHAR),15,'0') CreditoFiscalComputable,
       LPAD(CAST(TRUNCATE(ABS(d.impotros)*100,0) AS CHAR),15,'0') OtrosTributos,
       LPAD('0',11,'0') CUITEmisorCorredor,
       LPAD(' ',30,' ') DenominacionEmisorCorredor,
       LPAD('0',15,'0') IVAComision
FROM (
SELECT c.*,
IFNULL(tribnac.importe ,0) impnacional,
IFNULL(tribpro.importe ,0) impprovincial,
IFNULL(tribmun.importe ,0) impmunicipal,
IFNULL(tribint.importe ,0) impimpint,
IFNULL(tribotro.importe ,0) impotros,
IFNULL(alic.alicuotas ,0) alicuotas,
IFNULL(alic.credito ,0) credito
FROM `cpracabecera` c
LEFT JOIN
(SELECT cpratributo.`CbteId`,SUM(`cpratributo`.`Importe`) importe FROM `cpratributo` WHERE `cpratributo`.`Codigo`=1 GROUP BY cpratributo.`CbteId`,`cpratributo`.`Codigo`) tribnac ON c.`Id` = tribnac.cbteid
LEFT JOIN
(SELECT cpratributo.`CbteId`,SUM(`cpratributo`.`Importe`) importe FROM `cpratributo` WHERE `cpratributo`.`Codigo`=2 GROUP BY cpratributo.`CbteId`,`cpratributo`.`Codigo`) tribpro ON c.`Id` = tribpro.cbteid
LEFT JOIN
(SELECT cpratributo.`CbteId`,SUM(`cpratributo`.`Importe`) importe FROM `cpratributo` WHERE `cpratributo`.`Codigo`=3 GROUP BY cpratributo.`CbteId`,`cpratributo`.`Codigo`) tribmun ON c.`Id` = tribmun.cbteid
LEFT JOIN
(SELECT cpratributo.`CbteId`,SUM(`cpratributo`.`Importe`) importe FROM `cpratributo` WHERE `cpratributo`.`Codigo`=4 GROUP BY cpratributo.`CbteId`,`cpratributo`.`Codigo`) tribint ON c.`Id` = tribint.cbteid
LEFT JOIN
(SELECT cpratributo.`CbteId`,SUM(`cpratributo`.`Importe`) importe FROM `cpratributo` WHERE `cpratributo`.`Codigo`=99 GROUP BY cpratributo.`CbteId`,`cpratributo`.`Codigo`) tribotro ON c.`Id` = tribotro.cbteid
LEFT JOIN
(SELECT `cpraalicuota`.`CbteId`,COUNT(*) alicuotas,SUM(cpraalicuota.`Importe`) credito FROM `cpraalicuota` GROUP BY cpraalicuota.`CbteId`) alic ON c.`Id` = alic.cbteid
WHERE c.`CbteTipo` not in (991,992,993,994,995,996,91) ) d
WHERE DATE_FORMAT(d.`FechaServicioDesde`,'%Y%m')=periodo;
END


CREATE PROCEDURE `REGINFO_CV_VENTAS_ALICUOTAS`(periodo VARCHAR(6))
    NOT DETERMINISTIC
    SQL SECURITY DEFINER
    COMMENT ''
BEGIN
SELECT LPAD(CAST(c.`CbteTipo` AS CHAR),3,'0') TipoComprobante,
       LPAD(CAST(c.`CbtePtoVta` AS CHAR),5,'0') PuntoVenta,
       LPAD(CAST(c.`CbteNumero` AS CHAR),20,'0') NumeroComprobante,
       LPAD(CAST(TRUNCATE(ABS(IFNULL(d.`BaseImponible`,0))*100,0) AS CHAR),15,'0') ImporteNetoGravado,
       LPAD(CAST(IFNULL(d.`Codigo`,3) AS CHAR),4,'0') AlicuotaIVA,
       LPAD(CAST(TRUNCATE(ABS(IFNULL(d.`Importe`,0))*100,0) AS CHAR),15,'0') ImpuestoLiquidado
FROM cbtecabecera c LEFT JOIN cbtealicuota d
ON d.`CbteId` = c.`Id`
WHERE c.`CbteTipo` NOT IN (991,992,993,994,995,996,91)
AND DATE_FORMAT(c.`CbteFecha`,'%Y%m')=periodo;

END



CREATE PROCEDURE `REGINFO_CV_VENTAS_CBTE`(periodo VARCHAR(6))
    NOT DETERMINISTIC
    SQL SECURITY DEFINER
    COMMENT ''
BEGIN
SELECT d.`CbteFecha` FechaComprobante,
       LPAD(CAST(d.`CbteTipo` AS CHAR),3,'0') TipoComprobante,
       LPAD(CAST(d.`CbtePtoVta` AS CHAR),5,'0') PuntoVenta,
       LPAD(CAST(d.`CbteNumero` AS CHAR),20,'0') NumeroComprobante,
       LPAD(CAST(d.`CbteNumero` AS CHAR),20,'0') NumeroComprobanteHasta,
       d.`DocumentoTipo` CodigoDocumentoComprador,
       LPAD(CAST(d.`DocumentoNro` AS CHAR),20,'0') NumeroIdentificacionComprador,
       RPAD(LEFT(d.`RazonSocial`,30),30,' ') DenominacionComprador,
       LPAD(CAST(TRUNCATE(ABS(d.`ImporteTotal`)*100,0) AS CHAR),15,'0') ImporteTotalOperacion,
       LPAD(CAST(TRUNCATE(ABS(d.`ImporteTotalConceptos`)*100,0) AS CHAR),15,'0') ImporteTotalNoGravado,
       LPAD('0',15,'0') PercepcionNoCategorizados,
       LPAD(CAST(TRUNCATE(ABS(d.`ImporteOpExentas`)*100,0) AS CHAR),15,'0') ImporteOperacionesExentas,
       LPAD(CAST(TRUNCATE(ABS(d.impnacional)*100,0) AS CHAR),15,'0') ImporteImpuestosNacionales,
       LPAD(CAST(TRUNCATE(ABS(d.impprovincial)*100,0) AS CHAR),15,'0') ImportePercepcionesIngresosBrutos,
       LPAD(CAST(TRUNCATE(ABS(d.impmunicipal)*100,0) AS CHAR),15,'0') ImportePercepcionesImpuestosMunicipales,
       LPAD(CAST(TRUNCATE(ABS(d.impimpint)*100,0) AS CHAR),15,'0') ImporteImpuestosInternos,
       'PES' CodigoMoneda,
       CONCAT(LPAD('1',4,'0'),LPAD('0',6,'0')) TipoCambio,
       IF(d.alicuotas=0,1,d.alicuotas) CantidadAlicuotasIVA,
       CASE d.alicuotas
            WHEN 0 THEN 'E'
            ELSE ' '
       END AS CodigoOperacion,
       LPAD(CAST(TRUNCATE(ABS(d.impotros)*100,0) AS CHAR),15,'0') OtrosTributos,
       '00000000' FechaVtoPago
FROM (
SELECT c.*,
IFNULL(tribnac.importe ,0) impnacional,
IFNULL(tribpro.importe ,0) impprovincial,
IFNULL(tribmun.importe ,0) impmunicipal,
IFNULL(tribint.importe ,0) impimpint,
IFNULL(tribotro.importe ,0) impotros,
IFNULL(alic.alicuotas ,0) alicuotas
FROM `cbtecabecera` c
LEFT JOIN
(SELECT cbtetributo.`CbteId`,SUM(`cbtetributo`.`Importe`) importe FROM `cbtetributo` WHERE `cbtetributo`.`Codigo`=1 GROUP BY cbtetributo.`CbteId`,`cbtetributo`.`Codigo`) tribnac ON c.`Id` = tribnac.cbteid
LEFT JOIN
(SELECT cbtetributo.`CbteId`,SUM(`cbtetributo`.`Importe`) importe FROM `cbtetributo` WHERE `cbtetributo`.`Codigo`=2 GROUP BY cbtetributo.`CbteId`,`cbtetributo`.`Codigo`) tribpro ON c.`Id` = tribpro.cbteid
LEFT JOIN
(SELECT cbtetributo.`CbteId`,SUM(`cbtetributo`.`Importe`) importe FROM `cbtetributo` WHERE `cbtetributo`.`Codigo`=3 GROUP BY cbtetributo.`CbteId`,`cbtetributo`.`Codigo`) tribmun ON c.`Id` = tribmun.cbteid
LEFT JOIN
(SELECT cbtetributo.`CbteId`,SUM(`cbtetributo`.`Importe`) importe FROM `cbtetributo` WHERE `cbtetributo`.`Codigo`=4 GROUP BY cbtetributo.`CbteId`,`cbtetributo`.`Codigo`) tribint ON c.`Id` = tribint.cbteid
LEFT JOIN
(SELECT cbtetributo.`CbteId`,SUM(`cbtetributo`.`Importe`) importe FROM `cbtetributo` WHERE `cbtetributo`.`Codigo`=99 GROUP BY cbtetributo.`CbteId`,`cbtetributo`.`Codigo`) tribotro ON c.`Id` = tribotro.cbteid
LEFT JOIN
(SELECT `cbtealicuota`.`CbteId`,COUNT(*) alicuotas FROM `cbtealicuota` GROUP BY cbtealicuota.`CbteId`) alic ON c.`Id` = alic.cbteid
WHERE c.`CbteTipo` not in (991,992,993,994,995,996,91) ) d
WHERE DATE_FORMAT(d.`CbteFecha`,'%Y%m')=periodo;

END