create table Arqueos(idCaja int,idDenominacion int,cantidad int, fechaCreacion date, creadoPor varchar(80),moneda int);
create table Bitacora(tabla varchar(35),usuario varchar(35),maquina varchar(35),fecha date,tipo char(1),registro varchar(300));
create table Cajas(id int,responsable varchar(80),montoApertura number,estado char(1),fechaApertura date,cocineroTurno varchar(100),fechaCierre date,montoCierre number,montoCierreDolares number,montoTarjetaBn number,montoTarjetaBac number);
create table CierresInventarios(responsable varchar(80),fecha date,revisadoPor varchar(80),fechaRevisado date,fechaAnulacion date, anuladoPor varchar(80),fechaCreacion date,estado char(1),realizacionPor varchar(80),observacion varchar(360),id int);
create table ClavesAutorizacion(idAutorizacion int,clave int,fechaEmision date,estado char(1),documento varchar(10),email varchar(50));
create table Clientes(id int,tipoCedula char(1),cedulaLegal varchar(12),nombreLegal varchar(200),direccion varchar(300),telefono varchar(20),email varchar(100),fechaCreacion date,creadoPor varchar(80),estado char(1));
create table CombosFacturados(numFactura varchar(10),idCombo int, idProducto int, producto varchar(180),cantidadVenta number,registradoPor varchar(80),fechaRegistro date);
create table Denominaciones(id int,denominacion varchar(100),idMoneda int,valor number,creadoPor varchar(80),estado char(1),tipo char(1),fechaCreacion date);
create table DetalleFacturas(numLinea int,numFactura varchar(10),idProducto int, descripcion varchar(180),precioVenta number,imp number,cantidad number,subtotal number,esCombo char(1));
--------------------------------------------------------------------------------------------------------------------------------
create table DetalleMovimiento(idMov int not null,idProducto int not null,producto varchar(180) not null,cantidad number not null);
create table DetalleCierreInventarios(idCierre int not null,idProducto int not null,descripcion varchar(180) not null,inicial number not null,increso number not null,observacionIngreso varchar(200) not null,salida number not null,observacionSalida varchar(200)not null,Conteo number not null,Gasto number not null,Facturado number not null,diferencia number not null,fechaCreacion date not null);
CREATE TABLE Facturas(Numero varchar(10) NOT NULL,Fecha date NOT NULL,TerminoPago char(1) NOT NULL, MedioPago char(1) NOT NULL,Responsable varchar(80) NOT NULL,IdCliente int NOT NULL,IdCaja int NOT NULL,Subtotal number NOT NULL,Impuesto number NOT NULL,Total number NOT NULL,estado char(1) NOT NULL,AnuladoPor varchar(80) NULL,FechaAnulacion date NULL,MontoEfectivo number NOT NULL,MontoTarjeta number NOT NULL,MontoDolares number NOT NULl,numTarjeta varchar(30) NULL,montoDescuento number NOT NULL,ConsumoAdministrativo char(1) NOT NULL,TipoCambio number NOT NULL);
CREATE TABLE Monedas(Id int NOT NULL,Descripcion varchar(100) NOT NULL,FechaCreacion date NOT NULL,CreadoPor varchar(80) NOT NULL,estado char(1) NOT NULL);
CREATE TABLE Movimiento(Id int NOT NULL,Responsable varchar(80) NOT NULL,Fecha date NOT NULL,Observacion varchar(350) NOT NULL,Tipo char(1) NOT NULL,Motivo char(1) NOT NULL,Estado char(1) NULL,IDCierreInventario int NOT NULL);
CREATE TABLE MovimientosCaja(Id int NOT NULL,IDCaja int NOT NULL,Concepto varchar(200) NOT NULL,Monto number NOT NULL,Tipo char(1) NOT NULL,fechaRegistro date NOT NULL,CreadoPor varchar(80) NOT NULL);
CREATE TABLE Perfiles(Login varchar(80) NOT NULL,NombreCompleto varchar(200) NOT NULL,Contrasena varchar(30) NOT NULL,FechaCreacion date NOT NULL,Roll char(1) NOT NULL,Estado char(1) NOT NULL);
CREATE TABLE Productos(
	Id int NOT NULL,
	Descripcion varchar(180) NOT NULL,
	UnidadMedida varchar(80) NOT NULL,
	PrecioCompra number NOT NULL,
	PrecioVenta number NOT NULL,
	ImpVenta number NOT NULL,
	ControladoCierre char(1) NOT NULL,
	CodBarra varchar(100) NOT NULL,
	Existencia number NOT NULL,
	FechaCreacion date NOT NULL,
	CreadoPor varchar(80) NOT NULL,
	foto clob NOT NULL,
	combo char(1) NOT NULL,
	Estado char(1) NOT NULL,
	Clasificacion int NOT NULL,
	ProductosCombo varchar(200) NULL,
	IdCierreUltimAfectado int NULL);
    drop table productos;
CREATE TABLE ProductosCombos(
	IDCombo int NOT NULL,
	IDProducto int NOT NULL,
	PrecioVenta number NOT NULL,
	Cantidad number NOT NULL,
	FechaCreacion date NOT NULL,
	CreadoPor varchar(80) NOT NULL,
	interCambiar char(1) NOT NULL,
	ProductosIntercambiables varchar(200) NULL);
CREATE TABLE ProductosInterCambiables(
	IDCombo int NOT NULL,
	IDProducto int NOT NULL,
	IDProductoInterCambiable int NOT NULL,
	fechaRegistro date NOT NULL,
	RegistradoPor varchar(80) NOT NULL);
--------------------------------------------------------------------------------------------------------------------------------
select count(*) from productos;
delete from arqueos;
delete from bitacora;
delete from cajas;
delete from cierresinventarios;
delete from clavesautorizacion;
delete from clientes;
delete from combosfacturados;
delete from denominaciones;
delete from detallefacturas;
delete from DetalleMovimiento;
delete from detallecierreinventarios;
delete from movimiento;
delete from movimientoscaja;
delete from perfiles;
delete from facturas;
delete from monedas;
delete from productoscombos;
delete from productosintercambiables;
delete from productos;


alter session set "_ORACLE_SCRIPT"=TRUE;
create user GESTION identified by ucr2020
default tablespace users
temporary tablespace temp;

GRANT ALL PRIVILEGES to GESTION;
ALTER TABLE arqueos add primary key(idCaja,idDenominacion,moneda);
ALTER TABLE arqueos add constraint FK_CreadoPor foreign key(creadoPor) references perfiles(login);
ALTER TABLE Cajas add primary key(id);
ALTER TABLE Cajas add constraint FK_Responsable foreign key(responsable) references perfiles(login);
ALTER TABLE perfiles add primary key(login);
ALTER TABLE CierresInventarios add primary key(id);
ALTER TABLE CierresInventarios add constraint FK_ResponsableC foreign key(responsable) references perfiles(login);
ALTER TABLE Clientes add primary key(id);
ALTER TABLE Clientes add constraint FK_ResponsableCl foreign key(creadoPor) references perfiles(login);

ALTER TABLE CombosFacturados add constraint FK_ResponsableNF foreign key(numFactura) references facturas(numero);
--ALTER TABLE CombosFacturados add constraint FK_ResponsableIDC foreign key(idCombo) references ProductosCombos(idCombo);
ALTER TABLE CombosFacturados add constraint FK_ResponsableIDP foreign key(idProducto) references productos(id);
ALTER TABLE CombosFacturados add constraint FK_ResponsableCF foreign key(registradoPor) references perfiles(login);


ALTER TABLE Denominaciones add constraint FK_ResponsableDe foreign key(idMoneda) references monedas(id);
ALTER TABLE Denominaciones add constraint FK_ResponsableDen foreign key(creadoPor) references perfiles(login);
ALTER TABLE Facturas add primary key(numero);
ALTER TABLE DetalleMovimiento add constraint FK_ResponsableDm foreign key(idMov) references movimiento(id);
ALTER TABLE Monedas add primary key(id);
ALTER TABLE Monedas add constraint FK_ResponsableM foreign key(creadoPor) references perfiles(login);
ALTER TABLE Movimiento add primary key(id);
ALTER TABLE MovimientosCaja add primary key(id);
ALTER TABLE MovimientosCaja add constraint FK_ResponsableMo foreign key(creadoPor) references perfiles(login);
ALTER TABLE Productos add primary key(id);
ALTER TABLE Productos add constraint FK_ResponsableP foreign key(creadoPor) references perfiles(login);
ALTER TABLE ProductosCombos add primary key(idCombo,idProducto);
ALTER TABLE ProductosCombos add constraint FK_ResponsablePr foreign key(creadoPor) references perfiles(login);
ALTER TABLE ProductosInterCambiables add primary key(idCombo,idProducto,IDProductoInterCambiable);
ALTER TABLE ProductosInterCambiables add constraint FK_ResponsablePro foreign key(registradoPor) references perfiles(login);
