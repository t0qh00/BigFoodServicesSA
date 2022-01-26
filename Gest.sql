---------------------------------------------------------------------------------------------------------------------------------
create procedure [Sp_Cns_Arqueos]
as
select a.IdCaja, a.IdDenominacion,a.Cantidad,a.FechaCreacion,a.CreadoPor,a.Moneda
from Arqueos a with(nolock)
go
create procedure [Sp_Cns_Bitacora]
as
select a.Tabla, a.Usuario,a.Maquina,a.Fecha,a.Tipo,a.Registro
from Bitacora a with(nolock)
go
create procedure [Sp_Cns_CajasB]
as
select a.Id, a.Responsable,a.MontoApertura,a.estado,a.FechaApertura,a.cocineroTurno,a.FechaCierre,a.MontoCierre,a.MontoCierreDolares,a.MontoTarjetaBN,a.MontoTarjetaBAC
from Cajas a with(nolock)
go
create procedure [Sp_Cns_CierresInventarios]
as
select a.Responsable, a.Fecha,a.RealizadoPor,a.FechaRevisado,a.FechaAnulacion,a.AnuladoPor,a.FechaCreacion,a.Estado,a.RealizadoPor,a.Observacion,a.Id
from CierresInventarios a with(nolock)
go
create procedure [Sp_Cns_ClavesAutorizacion]
as
select a.IDAutorizador, a.Clave,a.FechaEmision,a.Estado,a.Documento,a.Email
from ClavesAutorizacion a with(nolock)
go
create procedure [Sp_Cns_ClientesO]
as
select a.Id, a.TipoCedula,a.CedulaLegal,a.NombreLegal,a.Direccion,a.Telefono,a.Email,a.FechaCreacion,a.CreadoPor,a.Estado
from Clientes a with(nolock)
go
create procedure [Sp_Cns_CombosFacturados]
as
select a.NumFactura, a.IDCombo,a.IDProducto,a.Producto,a.CantidadVenta,a.RegistradoPor,a.FechaRegistro
from CombosFacturados a with(nolock)
go
create procedure [Sp_Cns_Denominaciones]
as
select a.Id, a.Denominacion,a.IdMoneda,a.Valor,a.CreadoPor,a.Estado,a.tipo,a.FechaCreacion
from Denominaciones a with(nolock)
go
create procedure [Sp_Cns_DetalleFacturas]
as
select a.NumLinea, a.NumFactura,a.IDProducto,a.Descripcion,a.Precioventa,a.Imp,a.Cantidad,a.Subtotal,a.EsCombo
from DetalleFacturas a with(nolock)
go
---------------------------------------------------------------------------------------------------------------------------------
create procedure [Sp_Cns_DetalleMovimiento]
as
select a.idMov,a.idProducto,a.producto,a.cantidad
from DetalleMovimiento a with(nolock)
go

create procedure [Sp_Cns_DetalleCierreInventarios]
as
select a.idCierre,a.idProducto,a.descripcion,a.inicial,a.Ingreso,a.observacionIngreso,a.salida,a.observacionSalida,a.Conteo,a.Gasto,a.Facturado,a.diferencia,a.fechaCreacion
from DetallesCierreInventarios a with(nolock)
go

create procedure [Sp_Cns_Facturas]
as
select a.Numero,a.Fecha,a.TerminoPago,a.MedioPago,a.Responsable,a.IdCliente,a.IdCaja,a.Subtotal,a.Impuesto,a.Total,a.estado,a.AnuladoPor,a.FechaAnulacion,a.MontoEfectivo,a.MontoTarjeta,a.MontoDolares,a.numTarjeta,a.montoDescuento,a.ConsumoAdministrativo,a.TipoCambio
from Facturas a with(nolock)
go

create procedure [Sp_Cns_Monedas]
as
select a.Id,a.Descripcion,a.FechaCreacion,a.CreadoPor,a.estado
from Monedas a with(nolock)
go

drop procedure [Sp_Cns_Monedas]
go

create procedure [Sp_Cns_Movimiento]
as
select a.Id,a.Responsable,a.Fecha,a.Observacion,a.Tipo,a.Motivo,a.Estado,a.IDCierreInventario
from Movimiento a with(nolock)
go

create procedure [Sp_Cns_MovimientosCaja]
as
select a.Id,a.IDCaja,a.Concepto,a.Monto,a.Tipo,a.fechaRegistro,a.CreadoPor
from MovimientosCaja a with(nolock)
go

create procedure [Sp_Cns_PerfilesO]
as
select a.Login,a.NombreCompleto,a.Contrasena,a.FechaCreacion,a.Roll,a.Estado
from Perfiles a with(nolock)
go

create procedure [Sp_Cns_Productos]
as
select a.Id,a.Descripcion,a.UnidadMedida,a.PrecioCompra,a.PrecioVenta,a.ImpVenta,a.ControladoCierre,a.CodBarra,a.Existencia,a.FechaCreacion,a.CreadoPor,a.foto,a.combo,a.Estado,a.Clasificacion,a.ProductosCombo,a.IdCierreUltimAfectado
from Productos a with(nolock)
go

create procedure [Sp_Cns_ProductosCombos]
as
select a.IDCombo,a.IDProducto,a.PrecioVenta,a.Cantidad,a.FechaCreacion,a.CreadoPor,a.interCambiar,a.ProductosIntercambiables
from ProductosCombos a with(nolock)
go

create procedure [Sp_Cns_ProductosInterCambiablesO]
as
select a.IDCombo,a.IDProducto,a.IDProductoInterCambiable,a.fechaRegistro,a.RegistradoPor
from ProductosInterCambiables a with(nolock)
go
---------------------------------------------------------------------------------------------------------------------------------
select count(*) from Arqueos
select count(*) from Bitacora
select count(*) from Cajas
select count(*) from CierresInventarios
select count(*) from ClavesAutorizacion
select count(*) from Clientes
select count(*) from CombosFacturados
select count(*) from Denominaciones
select count(*) from DetalleFacturas
select count(*) from DetalleMovimiento
select count(*) from DetallesCierreInventarios
select count(*) from Facturas
select count(*) from Monedas
select count(*) from Monedas