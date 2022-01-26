using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace DAL
{
    public class Conexion
    {
        public int contador;
        public int transferencias;
        string conexionstring = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader lector;

        private string stringConexion;

        public Conexion(string str)
        {
            this.stringConexion = str;
            this.contador = 0;
            this.transferencias = 0;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public List<Arqueos> traerArqueos()
        {
            try
            {
                List < Arqueos > arqueos = new List<Arqueos>();
                this.connection = new SqlConnection(this.stringConexion);
                this.connection.Open();
                this.command = new SqlCommand();
                this.command.Connection = this.connection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_Cns_Arqueos]";

                this.lector = this.command.ExecuteReader();
                while (this.lector.Read())
                {
                    try
                    {
                        Arqueos arq = new Arqueos();
                        arq.idCaja = Convert.ToInt32(this.lector.GetValue(0));
                        arq.idDenominacion = Convert.ToInt32(this.lector.GetValue(1));
                        if (this.lector.GetValue(2) == DBNull.Value)
                        {
                            arq.cantidad = 0;
                            this.contador = contador + 1;
                        }
                        else
                        {
                            arq.cantidad = Convert.ToInt32(this.lector.GetValue(2));
                        }
                        if (this.lector.GetValue(3) == DBNull.Value)
                        {
                            arq.fechaCreacion = Convert.ToDateTime("01/01/01");
                            this.contador = contador + 1;
                        }
                        else
                        {
                            arq.fechaCreacion = Convert.ToDateTime(this.lector.GetValue(3));
                        }
                        arq.creadoPor = Convert.ToString(this.lector.GetValue(4)); ;
                        arq.moneda = Convert.ToInt32(this.lector.GetValue(5)); ;
                        arqueos.Add(arq);
                    }
                    catch (Exception)
                    {

                        this.contador = contador + 1;
                    }
                }
                this.connection.Close();
                this.command.Dispose();
                this.lector = null;
                return arqueos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//fin traer arqueos
        public List<Bitacora> traerBitacora()
        {
            try
            {
                List<Bitacora> bitacora = new List<Bitacora>();
                this.connection = new SqlConnection(this.stringConexion);
                this.connection.Open();
                this.command = new SqlCommand();
                this.command.Connection = this.connection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_Cns_Bitacora]";

                this.lector = this.command.ExecuteReader();
                while (this.lector.Read())
                {
                    try
                    {
                        Bitacora bit = new Bitacora();
                        if (this.lector.GetValue(0) == DBNull.Value)
                        {
                            bit.tabla = "";
                            this.contador = contador + 1;
                        }
                        else
                        {
                            bit.tabla = Convert.ToString(this.lector.GetValue(0));
                        }
                        if (this.lector.GetValue(1) == DBNull.Value)
                        {
                            bit.usuario = "";
                            this.contador = contador + 1;
                        }
                        else
                        {
                            bit.usuario = Convert.ToString(this.lector.GetValue(1));
                        }
                        if (this.lector.GetValue(2) == DBNull.Value)
                        {
                            bit.maquina = "";
                            this.contador = contador + 1;
                        }
                        else
                        {
                            bit.maquina = Convert.ToString(this.lector.GetValue(2));
                        }
                        if (this.lector.GetValue(3) == DBNull.Value)
                        {
                            bit.fecha = Convert.ToDateTime("01/01/01");
                            this.contador = contador + 1;
                        }
                        else
                        {
                            bit.fecha = Convert.ToDateTime(this.lector.GetValue(3));
                        }
                        if (this.lector.GetValue(4) == DBNull.Value)
                        {
                            bit.tipo = 'N' ;
                            this.contador = contador + 1;
                        }
                        else
                        {
                            bit.tipo = Convert.ToChar(this.lector.GetValue(4));
                        }
                        if (this.lector.GetValue(5) == DBNull.Value)
                        {
                            bit.registro = "";
                            this.contador = contador + 1;
                        }
                        else
                        {
                            bit.registro = Convert.ToString(this.lector.GetValue(5));
                        }
                        bitacora.Add(bit);
                    }
                    catch (Exception)
                    {

                        this.contador = contador + 1;
                    }
                }
                this.connection.Close();
                this.command.Dispose();
                this.lector = null;
                return bitacora;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//fin traer bitacora
        public List<Cajas> traerCajas()
        {
            try
            {
                List<Cajas> cajas = new List<Cajas>();
                this.connection = new SqlConnection(this.stringConexion);
                this.connection.Open();
                this.command = new SqlCommand();
                this.command.Connection = this.connection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_Cns_CajasB]";

                this.lector = this.command.ExecuteReader();
                while (this.lector.Read())
                {
                    try
                    {
                        Cajas caja = new Cajas();
                        caja.id = Convert.ToInt32(this.lector.GetValue(0));
                        caja.responsabe = Convert.ToString(this.lector.GetValue(1));
                        if (this.lector.GetValue(2) == DBNull.Value)
                        {
                            caja.montoApertura = 0;
                            this.contador = contador + 1;
                        }
                        else
                        {
                            caja.montoApertura = Convert.ToInt32(this.lector.GetValue(2));
                        }
                        if (this.lector.GetValue(3) == DBNull.Value)
                        {
                            caja.estado = 'N';
                            this.contador = contador + 1;
                        }
                        else
                        {
                            caja.estado = Convert.ToChar(this.lector.GetValue(3));
                        }
                        if (this.lector.GetValue(4) == DBNull.Value)
                        {
                            caja.fechaApertura = Convert.ToDateTime("01/01/01");
                            this.contador = contador + 1;
                        }
                        else
                        {
                            caja.fechaApertura = Convert.ToDateTime(this.lector.GetValue(4));
                        }
                        if (this.lector.GetValue(5) == DBNull.Value)
                        {
                            caja.cocineroTurno = "";
                            this.contador = contador + 1;
                        }
                        else
                        {
                            caja.cocineroTurno = Convert.ToString(this.lector.GetValue(5));
                        }
                        if (this.lector.GetValue(6) == DBNull.Value)
                        {
                            caja.fechaCierre = Convert.ToDateTime("01/01/01");
                            this.contador = contador + 1;
                        }
                        else
                        {
                            caja.fechaCierre = Convert.ToDateTime(this.lector.GetValue(6));
                        }
                        if (this.lector.GetValue(7) == DBNull.Value)
                        {
                            caja.montoCierre = 0;
                            this.contador = contador + 1;
                        }
                        else
                        {
                            caja.montoCierre = Convert.ToInt32(this.lector.GetValue(7));
                        }
                        if (this.lector.GetValue(8) == DBNull.Value)
                        {
                            caja.montoCierreDolares = 0;
                            this.contador = contador + 1;
                        }
                        else
                        {
                            caja.montoCierreDolares = Convert.ToInt32(this.lector.GetValue(8));
                        }
                        if (this.lector.GetValue(9) == DBNull.Value)
                        {
                            caja.montoTarjetaBn = 0;
                            this.contador = contador + 1;
                        }
                        else
                        {
                            caja.montoTarjetaBn = Convert.ToInt32(this.lector.GetValue(9));
                        }
                        if (this.lector.GetValue(10) == DBNull.Value)
                        {
                            caja.montoTarjetaBac = 0;
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            caja.montoTarjetaBac = Convert.ToInt32(this.lector.GetValue(10));
                        }
                        cajas.Add(caja);
                    }
                    catch (Exception)
                    {
                        this.contador = this.contador + 1;
                    }
                }
                this.connection.Close();
                this.command.Dispose();
                this.lector = null;
                return cajas;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//fin traer cajas
        public List<CierreInventarios> traerCierreInventarios()
        {
            try
            {
                List<CierreInventarios> cierreInventarios = new List<CierreInventarios>();
                this.connection = new SqlConnection(this.stringConexion);
                this.connection.Open();
                this.command = new SqlCommand();
                this.command.Connection = this.connection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_Cns_CierresInventarios]";

                this.lector = this.command.ExecuteReader();
                while (this.lector.Read())
                {
                    try
                    {
                        CierreInventarios cierre = new CierreInventarios();
                        if (this.lector.GetValue(0) == DBNull.Value)
                        {
                            cierre.responsable = "";
                            this.contador = contador + 1;
                        }
                        else
                        {
                            cierre.responsable = Convert.ToString(this.lector.GetValue(0));
                        }
                        if (this.lector.GetValue(1) == DBNull.Value)
                        {
                            cierre.fecha = Convert.ToDateTime("01/01/01");
                            this.contador = contador + 1;
                        }
                        else
                        {
                            cierre.fecha = Convert.ToDateTime(this.lector.GetValue(1));
                        }
                        if (this.lector.GetValue(2) == DBNull.Value)
                        {
                            cierre.RevisadoPor = "";
                            this.contador = contador + 1;
                        }
                        else
                        {
                            cierre.RevisadoPor = Convert.ToString(this.lector.GetValue(2));
                        }
                        if (this.lector.GetValue(3) == DBNull.Value)
                        {
                            cierre.fechaRevisado = Convert.ToDateTime("01/01/01");
                            this.contador = contador + 1;
                        }
                        else
                        {
                            cierre.fechaRevisado = Convert.ToDateTime(this.lector.GetValue(3));
                        }
                        if (this.lector.GetValue(4) == DBNull.Value)
                        {
                            cierre.fechaAnulacion = Convert.ToDateTime("01/01/01");
                            this.contador = contador + 1;
                        }
                        else
                        {
                            cierre.fechaAnulacion = Convert.ToDateTime(this.lector.GetValue(4));
                        }
                        if (this.lector.GetValue(5) == DBNull.Value)
                        {
                            cierre.anuladoPor = "";
                            this.contador = contador + 1;
                        }
                        else
                        {
                            cierre.anuladoPor = Convert.ToString(this.lector.GetValue(5));
                        }
                        if (this.lector.GetValue(6) == DBNull.Value)
                        {
                            cierre.fechaCreacion = Convert.ToDateTime("01/01/01");
                            this.contador = contador + 1;
                        }
                        else
                        {
                            cierre.fechaCreacion = Convert.ToDateTime(this.lector.GetValue(6));
                        }
                        if (this.lector.GetValue(7) == DBNull.Value)
                        {
                            cierre.estado = 'N';
                            this.contador = contador + 1;
                        }
                        else
                        {
                            cierre.estado = Convert.ToChar(this.lector.GetValue(7));
                        }
                        if (this.lector.GetValue(8) == DBNull.Value)
                        {
                            cierre.realizadoPor = "";
                            this.contador = contador + 1;
                        }
                        else
                        {
                            cierre.realizadoPor = Convert.ToString(this.lector.GetValue(8));
                        }
                        if (this.lector.GetValue(9) == DBNull.Value)
                        {
                            cierre.observacion = "";
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            cierre.observacion = Convert.ToString(this.lector.GetValue(9));
                        }
                        cierreInventarios.Add(cierre);
                    }
                    catch (Exception)
                    {
                        this.contador = this.contador + 1;
                    }
                }
                this.connection.Close();
                this.command.Dispose();
                this.lector = null;
                return cierreInventarios;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//fin traer cierreInventario
        public List<ClavesAutorizacion> traerClavesAutorizacion()
        {
            try
            {
                List<ClavesAutorizacion> clavesAutorizacion = new List<ClavesAutorizacion>();
                this.connection = new SqlConnection(this.stringConexion);
                this.connection.Open();
                this.command = new SqlCommand();
                this.command.Connection = this.connection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_Cns_ClavesAutorizacion]";

                this.lector = this.command.ExecuteReader();
                while (this.lector.Read())
                {
                    try
                    {
                        ClavesAutorizacion claves = new ClavesAutorizacion();
                        if (this.lector.GetValue(0) == DBNull.Value)
                        {
                            claves.idAutorizacion = 0;
                            this.contador = contador + 1;
                        }
                        else
                        {
                            claves.idAutorizacion = Convert.ToInt32(this.lector.GetValue(0));
                        }
                        if (this.lector.GetValue(1) == DBNull.Value)
                        {
                            claves.clave = 0;
                            this.contador = contador + 1;
                        }
                        else
                        {
                            claves.clave = Convert.ToInt32(this.lector.GetValue(1));
                        }
                        if (this.lector.GetValue(2) == DBNull.Value)
                        {
                            claves.fechaEmision = Convert.ToDateTime("01/01/01");
                            this.contador = contador + 1;
                        }
                        else
                        {
                            claves.fechaEmision = Convert.ToDateTime(this.lector.GetValue(2));
                        }
                        if (this.lector.GetValue(3) == DBNull.Value)
                        {
                            claves.estado = 'N';
                            this.contador = contador + 1;
                        }
                        else
                        {
                            claves.estado = Convert.ToChar(this.lector.GetValue(3));
                        }
                        if (this.lector.GetValue(4) == DBNull.Value)
                        {
                            claves.documento = Convert.ToString("");
                            this.contador = contador + 1;
                        }
                        else
                        {
                            claves.documento = Convert.ToString(this.lector.GetValue(4));
                        }
                        if (this.lector.GetValue(5) == DBNull.Value)
                        {
                            claves.email = "";
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            claves.email = Convert.ToString(this.lector.GetValue(5));
                        }
                        
                        clavesAutorizacion.Add(claves);
                    }
                    catch (Exception)
                    {
                        this.contador = this.contador + 1;
                    }
                }
                this.connection.Close();
                this.command.Dispose();
                this.lector = null;
                return clavesAutorizacion;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//fin traer clavesAutorizacion
        public List<Clientes> traerClientes()
        {
            try
            {
                List<Clientes> clientes = new List<Clientes>();
                this.connection = new SqlConnection(this.stringConexion);
                this.connection.Open();
                this.command = new SqlCommand();
                this.command.Connection = this.connection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_Cns_ClientesO]";

                this.lector = this.command.ExecuteReader();
                while (this.lector.Read())
                {
                    try
                    {
                        Clientes cli = new Clientes();
                        cli.id = Convert.ToInt32(this.lector.GetValue(0));
                        if (this.lector.GetValue(1) == DBNull.Value)
                        {
                            cli.tipoCedula = 'N';
                            this.contador = contador + 1;
                        }
                        else
                        {
                            cli.tipoCedula = Convert.ToChar(this.lector.GetValue(1));
                        }
                        if (this.lector.GetValue(2) == DBNull.Value)
                        {
                            cli.cedulaLegal = "";
                            this.contador = contador + 1;
                        }
                        else
                        {
                            cli.cedulaLegal = Convert.ToString(this.lector.GetValue(2));
                        }
                        if (this.lector.GetValue(3) == DBNull.Value)
                        {
                            cli.nombreLegal = "";
                            this.contador = contador + 1;
                        }
                        else
                        {
                            cli.nombreLegal = Convert.ToString(this.lector.GetValue(3));
                        }
                        if (this.lector.GetValue(4) == DBNull.Value)
                        {
                            cli.direccion = "";
                            this.contador = contador + 1;
                        }
                        else
                        {
                            cli.direccion = Convert.ToString(this.lector.GetValue(4));
                        }
                        if (this.lector.GetValue(5) == DBNull.Value)
                        {
                            cli.telefono = "";
                            this.contador = contador + 1;
                        }
                        else
                        {
                            cli.telefono = Convert.ToString(this.lector.GetValue(5));
                        }
                        if (this.lector.GetValue(6) == DBNull.Value)
                        {
                            cli.email = "";
                            this.contador = contador + 1;
                        }
                        else
                        {
                            cli.email = Convert.ToString(this.lector.GetValue(6));
                        }
                        if (this.lector.GetValue(7) == DBNull.Value)
                        {
                            cli.fechaCreacion = Convert.ToDateTime("01/01/01");
                            this.contador = contador + 1;
                        }
                        else
                        {
                            cli.fechaCreacion = Convert.ToDateTime(this.lector.GetValue(7));
                        }
                        cli.creadoPor = Convert.ToString(this.lector.GetValue(8));
                        if (this.lector.GetValue(9) == DBNull.Value)
                        {
                            cli.estado = 'N';
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            cli.estado = Convert.ToChar(this.lector.GetValue(9));
                        }
                        clientes.Add(cli);
                    }
                    catch (Exception)
                    {
                        this.contador = this.contador + 1;
                    }
                }
                this.connection.Close();
                this.command.Dispose();
                this.lector = null;
                return clientes;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//fin traer clientes
        public List<CombosFacturados> traerCombosFacturados()
        {
            try
            {
                List<CombosFacturados> combosFacturados = new List<CombosFacturados>();
                this.connection = new SqlConnection(this.stringConexion);
                this.connection.Open();
                this.command = new SqlCommand();
                this.command.Connection = this.connection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_Cns_CombosFacturados]";

                this.lector = this.command.ExecuteReader();
                while (this.lector.Read())
                {
                    try
                    {
                        CombosFacturados combos = new CombosFacturados();
                        combos.numFactura = Convert.ToString(this.lector.GetValue(0));
                        combos.idCombo = Convert.ToChar(this.lector.GetValue(1));
                        combos.idProducto = Convert.ToInt32(this.lector.GetValue(2));
                        if (this.lector.GetValue(3) == DBNull.Value)
                        {
                            combos.producto = "";
                            this.contador = contador + 1;
                        }
                        else
                        {
                            combos.producto = Convert.ToString(this.lector.GetValue(3));
                        }
                        if (this.lector.GetValue(4) == DBNull.Value)
                        {
                            combos.cantidadVenta = 0;
                            this.contador = contador + 1;
                        }
                        else
                        {
                            combos.cantidadVenta = Convert.ToInt32(this.lector.GetValue(4));
                        }
                        combos.registradoPor = Convert.ToString(this.lector.GetValue(5));
                        if (this.lector.GetValue(6) == DBNull.Value)
                        {
                            combos.fechaRegistro = Convert.ToDateTime("01/01/01");
                            this.contador = contador + 1;
                        }
                        else
                        {
                            combos.fechaRegistro = Convert.ToDateTime(this.lector.GetValue(6));
                        }
                        combosFacturados.Add(combos);
                    }
                    catch (Exception)
                    {
                        this.contador = this.contador + 1;
                    }
                }
                this.connection.Close();
                this.command.Dispose();
                this.lector = null;
                return combosFacturados;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//fin traer combosFacturados
        public List<Denominaciones> traerDenominaciones()
        {
            try
            {
                List<Denominaciones> denominaciones = new List<Denominaciones>();
                this.connection = new SqlConnection(this.stringConexion);
                this.connection.Open();
                this.command = new SqlCommand();
                this.command.Connection = this.connection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_Cns_Denominaciones]";

                this.lector = this.command.ExecuteReader();
                while (this.lector.Read())
                {
                    try
                    {
                        Denominaciones deno = new Denominaciones();
                        if (this.lector.GetValue(0) == DBNull.Value)
                        {
                            deno.id = 0;
                            this.contador = contador + 1;
                        }
                        else
                        {
                            deno.id = Convert.ToInt32(this.lector.GetValue(0));
                        }
                        if (this.lector.GetValue(1) == DBNull.Value)
                        {
                            deno.denominacion = "";
                            this.contador = contador + 1;
                        }
                        else
                        {
                            deno.denominacion = Convert.ToString(this.lector.GetValue(1));
                        }
                            deno.idMoneda = Convert.ToInt32(this.lector.GetValue(2));
                        if (this.lector.GetValue(3) == DBNull.Value)
                        {
                            deno.valor = 0;
                            this.contador = contador + 1;
                        }
                        else
                        {
                            deno.valor = Convert.ToInt32(this.lector.GetValue(3));
                        }
                            deno.creadoPor = Convert.ToString(this.lector.GetValue(4));
                        if (this.lector.GetValue(5) == DBNull.Value)
                        {
                            deno.estado = 'N';
                            this.contador = contador + 1;
                        }
                        else
                        {
                            deno.estado = Convert.ToChar(this.lector.GetValue(5));
                        }
                        if (this.lector.GetValue(6) == DBNull.Value)
                        {
                            deno.tipo = 'N';
                            this.contador = contador + 1;
                        }
                        else
                        {
                            deno.tipo = Convert.ToChar(this.lector.GetValue(6));
                        }
                        if (this.lector.GetValue(7) == DBNull.Value)
                        {
                            deno.fechaCreacion = Convert.ToDateTime("01/01/01");
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            deno.fechaCreacion = Convert.ToDateTime(this.lector.GetValue(7));
                        }

                        denominaciones.Add(deno);
                    }
                    catch (Exception)
                    {
                        this.contador = this.contador + 1;
                    }
                }
                this.connection.Close();
                this.command.Dispose();
                this.lector = null;
                return denominaciones;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//fin traer denominaciones
        public List<DetalleFacturas> traerDetalleFacturas()
        {
            try
            {
                List<DetalleFacturas> detalleFacturas = new List<DetalleFacturas>();
                this.connection = new SqlConnection(this.stringConexion);
                this.connection.Open();
                this.command = new SqlCommand();
                this.command.Connection = this.connection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_Cns_DetalleFacturas]";

                this.lector = this.command.ExecuteReader();
                while (this.lector.Read())
                {
                    try
                    {
                        DetalleFacturas detalle = new DetalleFacturas();
                        if (this.lector.GetValue(0) == DBNull.Value)
                        {
                            detalle.numLinea = 0;
                            this.contador = contador + 1;
                        }
                        else
                        {
                            detalle.numLinea = Convert.ToInt32(this.lector.GetValue(0));
                        }
                        if (this.lector.GetValue(1) == DBNull.Value)
                        {
                            detalle.numFactura = "";
                            this.contador = contador + 1;
                        }
                        else
                        {
                            detalle.numFactura = Convert.ToString(this.lector.GetValue(1));
                        }
                        if (this.lector.GetValue(2) == DBNull.Value)
                        {
                            detalle.idProducto = 0;
                            this.contador = contador + 1;
                        }
                        else
                        {
                            detalle.idProducto = Convert.ToInt32(this.lector.GetValue(2));
                        }
                        if (this.lector.GetValue(3) == DBNull.Value)
                        {
                            detalle.descripcion = "";
                            this.contador = contador + 1;
                        }
                        else
                        {
                            detalle.descripcion = Convert.ToString(this.lector.GetValue(3));
                        }
                        if (this.lector.GetValue(4) == DBNull.Value)
                        {
                            detalle.precioVenta = 0;
                            this.contador = contador + 1;
                        }
                        else
                        {
                            detalle.precioVenta = Convert.ToInt32(this.lector.GetValue(4));
                        }
                        if (this.lector.GetValue(5) == DBNull.Value)
                        {
                            detalle.imp = 0;
                            this.contador = contador + 1;
                        }
                        else
                        {
                            detalle.imp = Convert.ToInt32(this.lector.GetValue(5));
                        }
                        if (this.lector.GetValue(6) == DBNull.Value)
                        {
                            detalle.cantidad = 0;
                            this.contador = contador + 1;
                        }
                        else
                        {
                            detalle.cantidad = Convert.ToInt32(this.lector.GetValue(6));
                        }
                        if (this.lector.GetValue(7) == DBNull.Value)
                        {
                            detalle.subTotal = 0;
                            this.contador = contador + 1;
                        }
                        else
                        {
                            detalle.subTotal = Convert.ToInt32(this.lector.GetValue(7));
                        }
                        if (this.lector.GetValue(8) == DBNull.Value)
                        {
                            detalle.esCombo = 'N';
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            detalle.subTotal = Convert.ToChar(this.lector.GetValue(8));
                        }

                        detalleFacturas.Add(detalle);
                    }
                    catch (Exception)
                    {
                        this.contador = this.contador + 1;
                    }
                }
                this.connection.Close();
                this.command.Dispose();
                this.lector = null;
                return detalleFacturas;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//fin traer DetalleFacturas
        public List<DetalleMovimiento> traerDetalleMovimiento()
        {
            try
            {
                List<DetalleMovimiento> detalleMovimientos = new List<DetalleMovimiento>();
                this.connection = new SqlConnection(this.stringConexion);
                this.connection.Open();
                this.command = new SqlCommand();
                this.command.Connection = this.connection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_Cns_DetalleMovimiento]";

                this.lector = this.command.ExecuteReader();
                while (this.lector.Read())
                {
                    try
                    {
                        DetalleMovimiento detalle = new DetalleMovimiento();
                        detalle.idMov = Convert.ToInt32(this.lector.GetValue(0));
                        if (this.lector.GetValue(1) == DBNull.Value)
                        {
                            detalle.idProducto = 0;
                            this.contador = contador + 1;
                        }
                        else
                        {
                            detalle.idProducto = Convert.ToInt32(this.lector.GetValue(1));
                        }
                        if (this.lector.GetValue(2) == DBNull.Value)
                        {
                            detalle.producto = "";
                            this.contador = contador + 1;
                        }
                        else
                        {
                            detalle.producto = Convert.ToString(this.lector.GetValue(2));
                        }
                        if (this.lector.GetValue(3) == DBNull.Value)
                        {
                            detalle.cantidad = 0;
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            detalle.cantidad = Convert.ToInt32(this.lector.GetValue(3));
                        }

                        detalleMovimientos.Add(detalle);
                    }
                    catch (Exception)
                    {
                        this.contador = this.contador + 1;
                    }
                }
                this.connection.Close();
                this.command.Dispose();
                this.lector = null;
                return detalleMovimientos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//fin traer DetalleMovimiento
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public List<DetalleCierreInventarios> TraerDetalleCierreInventarios()
        {
            try
            {
                List<DetalleCierreInventarios> detalleCierreInventarios = new List<DetalleCierreInventarios>();
                this.connection = new SqlConnection(this.stringConexion);
                this.connection.Open();
                this.command = new SqlCommand();
                this.command.Connection = this.connection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_Cns_DetalleCierreInventarios]";

                this.lector = this.command.ExecuteReader();
                while (this.lector.Read())
                {
                    try
                    {
                        DetalleCierreInventarios detalle = new DetalleCierreInventarios();
                        if (this.lector.GetValue(0) == DBNull.Value)
                        {
                            detalle.idCierre = 0;
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            detalle.idCierre = Convert.ToInt32(this.lector.GetValue(0));
                        }
                        if (this.lector.GetValue(1) == DBNull.Value)
                        {
                            detalle.idProducto = 0;
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            detalle.idProducto = Convert.ToInt32(this.lector.GetValue(1));
                        }
                        if (this.lector.GetValue(2) == DBNull.Value)
                        {
                            detalle.descripcion = "";
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            detalle.descripcion = Convert.ToString(this.lector.GetValue(2));
                        }
                        if (this.lector.GetValue(3) == DBNull.Value)
                        {
                            detalle.inicial = 0;
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            detalle.inicial = Convert.ToInt32(this.lector.GetValue(3));
                        }
                        if (this.lector.GetValue(4) == DBNull.Value)
                        {
                            detalle.ingreso = 0;
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            detalle.ingreso = Convert.ToDecimal(this.lector.GetValue(4));
                        }
                        if (this.lector.GetValue(5) == DBNull.Value)
                        {
                            detalle.observacionIngreso = "";
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            detalle.observacionIngreso = Convert.ToString(this.lector.GetValue(5));
                        }
                        if (this.lector.GetValue(6) == DBNull.Value)
                        {
                            detalle.salida = 0;
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            detalle.salida = Convert.ToDecimal(this.lector.GetValue(6));
                        }
                        if (this.lector.GetValue(7) == DBNull.Value)
                        {
                            detalle.observacionSalida = "";
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            detalle.observacionSalida = Convert.ToString(this.lector.GetValue(7));
                        }
                        if (this.lector.GetValue(8) == DBNull.Value)
                        {
                            detalle.conteo = 0;
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            detalle.conteo = Convert.ToDecimal(this.lector.GetValue(8));
                        }
                        if (this.lector.GetValue(9) == DBNull.Value)
                        {
                            detalle.gasto = 0;
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            detalle.gasto = Convert.ToDecimal(this.lector.GetValue(9));
                        }
                        if (this.lector.GetValue(10) == DBNull.Value)
                        {
                            detalle.facturado = 0;
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            detalle.facturado = Convert.ToDecimal(this.lector.GetValue(10));
                        }
                        if (this.lector.GetValue(11) == DBNull.Value)
                        {
                            detalle.diferencia = 0;
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            detalle.diferencia = Convert.ToDecimal(this.lector.GetValue(11));
                        }
                        if (this.lector.GetValue(12) == DBNull.Value)
                        {
                            detalle.fechaCreacion = Convert.ToDateTime("01/01/01");
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            detalle.fechaCreacion = Convert.ToDateTime(this.lector.GetValue(12));
                        }
                        detalleCierreInventarios.Add(detalle);
                    }
                    catch (Exception)
                    {
                        this.contador = this.contador + 1;
                    }
                }
                this.connection.Close();
                this.command.Dispose();
                this.lector = null;
                return detalleCierreInventarios;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//fin traer DetalleCierreInventarios
        public List<Factura> TraerFactura()
        {
            try
            {
                List<Factura> facturas = new List<Factura>();
                this.connection = new SqlConnection(this.stringConexion);
                this.connection.Open();
                this.command = new SqlCommand();
                this.command.Connection = this.connection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_Cns_Facturas]";

                this.lector = this.command.ExecuteReader();
                while (this.lector.Read())
                {
                    try
                    {
                        Factura factura = new Factura();
                        factura.numero = Convert.ToString(this.lector.GetValue(0));
                        if (this.lector.GetValue(1) == DBNull.Value)
                        {
                            factura.fecha = Convert.ToDateTime("01/01/01");
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            factura.fecha = Convert.ToDateTime(this.lector.GetValue(1));
                        }
                        if (this.lector.GetValue(2) == DBNull.Value)
                        {
                            factura.terminoPago = 'N';
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            factura.terminoPago = Convert.ToChar(this.lector.GetValue(2));
                        }
                        if (this.lector.GetValue(3) == DBNull.Value)
                        {
                            factura.medioPago = 'N';
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            factura.medioPago = Convert.ToChar(this.lector.GetValue(3));
                        }
                        if (this.lector.GetValue(4) == DBNull.Value)
                        {
                            factura.responsable = "";
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            factura.responsable = Convert.ToString(this.lector.GetValue(4));
                        }
                        if (this.lector.GetValue(5) == DBNull.Value)
                        {
                            factura.idCliente = 0;
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            factura.idCliente = Convert.ToInt32(this.lector.GetValue(5));
                        }
                        if (this.lector.GetValue(6) == DBNull.Value)
                        {
                            factura.idCaja = 0;
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            factura.idCaja = Convert.ToInt32(this.lector.GetValue(6));
                        }
                        if (this.lector.GetValue(7) == DBNull.Value)
                        {
                            factura.subTotal = 0;
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            factura.subTotal = Convert.ToDecimal(this.lector.GetValue(7));
                        }
                        if (this.lector.GetValue(8) == DBNull.Value)
                        {
                            factura.impuesto = 0;
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            factura.impuesto = Convert.ToDecimal(this.lector.GetValue(8));
                        }
                        if (this.lector.GetValue(9) == DBNull.Value)
                        {
                            factura.total = 0;
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            factura.total = Convert.ToDecimal(this.lector.GetValue(9));
                        }
                        if (this.lector.GetValue(10) == DBNull.Value)
                        {
                            factura.estado = 'N';
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            factura.estado = Convert.ToChar(this.lector.GetValue(10));
                        }
                        if (this.lector.GetValue(11) == DBNull.Value)
                        {
                            factura.anuladoPor = "";
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            factura.anuladoPor = Convert.ToString(this.lector.GetValue(11));
                        }
                        if (this.lector.GetValue(12) == DBNull.Value)
                        {
                            factura.fechaAnulacion = Convert.ToDateTime("01/01/01");
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            factura.fechaAnulacion = Convert.ToDateTime(this.lector.GetValue(12));
                        }
                        if (this.lector.GetValue(13) == DBNull.Value)
                        {
                            factura.montoEfectivo = 0;
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            factura.montoEfectivo = Convert.ToDecimal(this.lector.GetValue(13));
                        }
                        if (this.lector.GetValue(14) == DBNull.Value)
                        {
                            factura.montoTarjeta = 0;
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            factura.montoTarjeta = Convert.ToDecimal(this.lector.GetValue(14));
                        }
                        if (this.lector.GetValue(15) == DBNull.Value)
                        {
                            factura.montoDolares = 0;
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            factura.montoDolares = Convert.ToDecimal(this.lector.GetValue(15));
                        }
                        if (this.lector.GetValue(16) == DBNull.Value)
                        {
                            factura.numTarjeta = "";
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            factura.numTarjeta = Convert.ToString(this.lector.GetValue(16));
                        }
                        if (this.lector.GetValue(17) == DBNull.Value)
                        {
                            factura.montoDescuento = 0;
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            factura.montoDescuento = Convert.ToDecimal(this.lector.GetValue(17));
                        }
                        if (this.lector.GetValue(18) == DBNull.Value)
                        {
                            factura.consumoAdministrativo = 'N';
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            factura.consumoAdministrativo = Convert.ToChar(this.lector.GetValue(18));
                        }
                        if (this.lector.GetValue(19) == DBNull.Value)
                        {
                            factura.tipoCambio = 0;
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            factura.tipoCambio = Convert.ToDecimal(this.lector.GetValue(19));
                        }
                        facturas.Add(factura);
                    }
                    catch (Exception)
                    {
                        this.contador = this.contador + 1;
                    }
                }
                this.connection.Close();
                this.command.Dispose();
                this.lector = null;
                return facturas;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//fin traer Factura

        public List<Monedas> traerMonedas()
        {
            try
            {
                List<Monedas> monedas = new List<Monedas>();
                this.connection = new SqlConnection(this.stringConexion);
                this.connection.Open();
                this.command = new SqlCommand();
                this.command.Connection = this.connection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_Cns_Monedas]";

                this.lector = this.command.ExecuteReader();
                while (this.lector.Read())
                {
                    try
                    {
                        Monedas moneda = new Monedas();
                        moneda.id = Convert.ToInt32(this.lector.GetValue(0));
                        if (this.lector.GetValue(1) == DBNull.Value)
                        {
                            moneda.descripcion = "";
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            moneda.descripcion = Convert.ToString(this.lector.GetValue(1));
                        }
                        if (this.lector.GetValue(2) == DBNull.Value)
                        {
                            moneda.fechaCreacion = Convert.ToDateTime("01/01/01");
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            moneda.fechaCreacion = Convert.ToDateTime(this.lector.GetValue(2));
                        }
                        moneda.creadoPor = Convert.ToString(this.lector.GetValue(3));
                        if (this.lector.GetValue(4) == DBNull.Value)
                        {
                            moneda.estado = 'N';
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            moneda.estado = Convert.ToChar(this.lector.GetValue(4));
                        }
                        monedas.Add(moneda);
                    }
                    catch (Exception)
                    {
                        this.contador = this.contador + 1;
                    }
                }
                this.connection.Close();
                this.command.Dispose();
                this.lector = null;
                return monedas;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//fin traer Monedas

        public List<Movimiento> traerMovimiento()
        {
            try
            {
                List<Movimiento> movimientos = new List<Movimiento>();
                this.connection = new SqlConnection(this.stringConexion);
                this.connection.Open();
                this.command = new SqlCommand();
                this.command.Connection = this.connection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_Cns_Movimiento]";

                this.lector = this.command.ExecuteReader();
                while (this.lector.Read())
                {
                    try
                    {
                        Movimiento movimiento = new Movimiento();
                        movimiento.id = Convert.ToInt32(this.lector.GetValue(0));
                        if (this.lector.GetValue(1) == DBNull.Value)
                        {
                            movimiento.responsable = "";
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            movimiento.responsable = Convert.ToString(this.lector.GetValue(1));
                        }
                        if (this.lector.GetValue(2) == DBNull.Value)
                        {
                            movimiento.fecha = Convert.ToDateTime("01/01/01");
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            movimiento.fecha = Convert.ToDateTime(this.lector.GetValue(2));
                        }
                        if (this.lector.GetValue(3) == DBNull.Value)
                        {
                            movimiento.observacion = "";
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            movimiento.observacion = Convert.ToString(this.lector.GetValue(3));
                        }
                        if (this.lector.GetValue(4) == DBNull.Value)
                        {
                            movimiento.tipo = 'N';
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            movimiento.tipo = Convert.ToChar(this.lector.GetValue(4));
                        }
                        if (this.lector.GetValue(5) == DBNull.Value)
                        {
                            movimiento.motivo = 'N';
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            movimiento.motivo = Convert.ToChar(this.lector.GetValue(5));
                        }
                        if (this.lector.GetValue(6) == DBNull.Value)
                        {
                            movimiento.estado = 'N';
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            movimiento.estado = Convert.ToChar(this.lector.GetValue(6));
                        }
                        if (this.lector.GetValue(7) == DBNull.Value)
                        {
                            movimiento.idCierreInventario = 0;
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            movimiento.idCierreInventario = Convert.ToInt32(this.lector.GetValue(7));
                        }
                        movimientos.Add(movimiento);
                    }
                    catch (Exception)
                    {
                        this.contador = this.contador + 1;
                    }
                }
                this.connection.Close();
                this.command.Dispose();
                this.lector = null;
                return movimientos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//fin traer Movimiento

        public List<MovimientosCaja> traerMovimientosCaja()
        {
            try
            {
                List<MovimientosCaja> movimientos = new List<MovimientosCaja>();
                this.connection = new SqlConnection(this.stringConexion);
                this.connection.Open();
                this.command = new SqlCommand();
                this.command.Connection = this.connection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_Cns_MovimientosCaja]";

                this.lector = this.command.ExecuteReader();
                while (this.lector.Read())
                {
                    try
                    {
                        MovimientosCaja movimiento = new MovimientosCaja();
                        movimiento.id = Convert.ToInt32(this.lector.GetValue(0));
                        movimiento.idCaja = Convert.ToInt32(this.lector.GetValue(1));
                        if (this.lector.GetValue(2) == DBNull.Value)
                        {
                            movimiento.concepto = "";
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            movimiento.concepto = Convert.ToString(this.lector.GetValue(2));
                        }
                        if (this.lector.GetValue(3) == DBNull.Value)
                        {
                            movimiento.monto = 0;
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            movimiento.monto = Convert.ToDecimal(this.lector.GetValue(3));
                        }
                        if (this.lector.GetValue(4) == DBNull.Value)
                        {
                            movimiento.tipo = 'N';
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            movimiento.tipo = Convert.ToChar(this.lector.GetValue(4));
                        }
                        if (this.lector.GetValue(5) == DBNull.Value)
                        {
                            movimiento.fechaRegistro = Convert.ToDateTime("01/01/01");
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            movimiento.fechaRegistro = Convert.ToDateTime(this.lector.GetValue(5));
                        }
                        movimiento.creadoPor = Convert.ToString(this.lector.GetValue(6));
                        movimientos.Add(movimiento);
                    }
                    catch (Exception)
                    {
                        this.contador = this.contador + 1;
                    }
                }
                this.connection.Close();
                this.command.Dispose();
                this.lector = null;
                return movimientos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//fin traer MovimientosCaja
        public List<Perfiles> traerPerfiles()
        {
            try
            {
                List<Perfiles> perfiles = new List<Perfiles>();
                this.connection = new SqlConnection(this.stringConexion);
                this.connection.Open();
                this.command = new SqlCommand();
                this.command.Connection = this.connection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_Cns_PerfilesO]";

                this.lector = this.command.ExecuteReader();
                while (this.lector.Read())
                {
                    try
                    {
                        Perfiles perfil = new Perfiles();
                        perfil.login = Convert.ToString(this.lector.GetValue(0));
                        if (this.lector.GetValue(1) == DBNull.Value)
                        {
                            perfil.nombreCompleto = "";
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            perfil.nombreCompleto = Convert.ToString(this.lector.GetValue(1));
                        }
                        if (this.lector.GetValue(2) == DBNull.Value)
                        {
                            perfil.contraseña = "";
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            perfil.contraseña = Convert.ToString(this.lector.GetValue(2));
                        }
                        if (this.lector.GetValue(3) == DBNull.Value)
                        {
                            perfil.fechaCreacion = Convert.ToDateTime("01/01/01");
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            perfil.fechaCreacion = Convert.ToDateTime(this.lector.GetValue(3));
                        }
                        if (this.lector.GetValue(4) == DBNull.Value)
                        {
                            perfil.roll = 'N';
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            perfil.roll = Convert.ToChar(this.lector.GetValue(4));
                        }
                        if (this.lector.GetValue(5) == DBNull.Value)
                        {
                            perfil.estado = 'N';
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            perfil.estado = Convert.ToChar(this.lector.GetValue(5));
                        }
                        perfiles.Add(perfil);
                    }
                    catch (Exception)
                    {
                        this.contador = this.contador + 1;
                    }
                }
                this.connection.Close();
                this.command.Dispose();
                this.lector = null;
                return perfiles;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//fin traer Perfiles

        public List<Productos> TraerProductos()
        {
            try
            {
                List<Productos> productos = new List<Productos>();
                this.connection = new SqlConnection(this.stringConexion);
                this.connection.Open();
                this.command = new SqlCommand();
                this.command.Connection = this.connection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_Cns_Productos]";

                this.lector = this.command.ExecuteReader();
                while (this.lector.Read())
                {
                    try
                    {
                        Productos producto = new Productos();
                        producto.id = Convert.ToInt32(this.lector.GetValue(0));
                        if (this.lector.GetValue(1) == DBNull.Value)
                        {
                            producto.descripcion = "";
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            producto.descripcion = Convert.ToString(this.lector.GetValue(1));
                        }
                        if (this.lector.GetValue(2) == DBNull.Value)
                        {
                            producto.unidadMedida = "";
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            producto.unidadMedida = Convert.ToString(this.lector.GetValue(2));
                        }
                        if (this.lector.GetValue(3) == DBNull.Value)
                        {
                            producto.precioCompra = 0;
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            producto.precioCompra = Convert.ToDecimal(this.lector.GetValue(3));
                        }
                        if (this.lector.GetValue(4) == DBNull.Value)
                        {
                            producto.precioVenta = 0;
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            producto.precioVenta = Convert.ToDecimal(this.lector.GetValue(4));
                        }
                        if (this.lector.GetValue(5) == DBNull.Value)
                        {
                            producto.impVenta = 0;
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            producto.impVenta = Convert.ToDecimal(this.lector.GetValue(5));
                        }
                        if (this.lector.GetValue(6) == DBNull.Value)
                        {
                            producto.controladoCierre = 'N';
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            producto.controladoCierre = Convert.ToChar(this.lector.GetValue(6));
                        }
                        if (this.lector.GetValue(7) == DBNull.Value)
                        {
                            producto.codBarra = "";
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            producto.codBarra = Convert.ToString(this.lector.GetValue(7));
                        }
                        if (this.lector.GetValue(8) == DBNull.Value)
                        {
                            producto.existencia = 0;
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            producto.existencia = Convert.ToDecimal(this.lector.GetValue(8));
                        }
                        if (this.lector.GetValue(9) == DBNull.Value)
                        {
                            producto.fechaCreacion = Convert.ToDateTime("01/01/01");
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            producto.fechaCreacion = Convert.ToDateTime(this.lector.GetValue(9));
                        }
                        producto.creadoPor = Convert.ToString(this.lector.GetValue(10));
                        producto.foto = (byte[])this.lector.GetValue(11);
                        if (this.lector.GetValue(12) == DBNull.Value)
                        {
                            producto.combo = 'N';
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            producto.combo = Convert.ToChar(this.lector.GetValue(12));
                        }
                        if (this.lector.GetValue(13) == DBNull.Value)
                        {
                            producto.estado = 'N';
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            producto.estado = Convert.ToChar(this.lector.GetValue(13));
                        }
                        if (this.lector.GetValue(14) == DBNull.Value)
                        {
                            producto.clasificacion = 0;
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            producto.clasificacion = Convert.ToInt32(this.lector.GetValue(14));
                        }
                        if (this.lector.GetValue(15) == DBNull.Value)
                        {
                            producto.productosCombo = "";
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            producto.productosCombo = Convert.ToString(this.lector.GetValue(15));
                        }
                        if (this.lector.GetValue(16) == DBNull.Value)
                        {
                            producto.idCierreUltimAfectado = 0;
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            producto.idCierreUltimAfectado = Convert.ToInt32(this.lector.GetValue(16));
                        }
                        productos.Add(producto);
                    }
                    catch (Exception)
                    {
                        this.contador = this.contador + 1;
                    }
                }
                this.connection.Close();
                this.command.Dispose();
                this.lector = null;
                return productos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//fin traer Productos************

        public List<ProductosCombos> TraerProductosCombos()
        {
            try
            {
                List<ProductosCombos> productos = new List<ProductosCombos>();
                this.connection = new SqlConnection(this.stringConexion);
                this.connection.Open();
                this.command = new SqlCommand();
                this.command.Connection = this.connection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_Cns_ProductosCombos]";

                this.lector = this.command.ExecuteReader();
                while (this.lector.Read())
                {
                    try
                    {
                        ProductosCombos producto = new ProductosCombos();
                        producto.idCombo = Convert.ToInt32(this.lector.GetValue(0));
                        producto.idProducto = Convert.ToInt32(this.lector.GetValue(1));
                        if (this.lector.GetValue(2) == DBNull.Value)
                        {
                            producto.precioVenta = 0;
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            producto.precioVenta = Convert.ToDecimal(this.lector.GetValue(2));
                        }
                        if (this.lector.GetValue(3) == DBNull.Value)
                        {
                            producto.cantidad = 0;
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            producto.cantidad = Convert.ToDecimal(this.lector.GetValue(3));
                        }
                        if (this.lector.GetValue(4) == DBNull.Value)
                        {
                            producto.fechaCreacion = Convert.ToDateTime("01/01/01");
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            producto.fechaCreacion = Convert.ToDateTime(this.lector.GetValue(4));
                        }
                        producto.creadoPor = Convert.ToString(this.lector.GetValue(5));
                        if (this.lector.GetValue(6) == DBNull.Value)
                        {
                            producto.interCambiar = 'N';
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            producto.interCambiar = Convert.ToChar(this.lector.GetValue(6));
                        }
                        if (this.lector.GetValue(7) == DBNull.Value)
                        {
                            producto.productosIntercambiables = "";
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            producto.productosIntercambiables = Convert.ToString(this.lector.GetValue(7));
                        }
                        productos.Add(producto);
                    }
                    catch (Exception)
                    {
                        this.contador = this.contador + 1;
                    }
                }
                this.connection.Close();
                this.command.Dispose();
                this.lector = null;
                return productos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//fin traer ProductosCombos

        public List<ProductosInterCambiables> TraerProductosIntercambiables()
        {
            try
            {
                List<ProductosInterCambiables> productos = new List<ProductosInterCambiables>();
                this.connection = new SqlConnection(this.stringConexion);
                this.connection.Open();
                this.command = new SqlCommand();
                this.command.Connection = this.connection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_Cns_ProductosInterCambiablesO]";

                this.lector = this.command.ExecuteReader();
                while (this.lector.Read())
                {
                    try
                    {
                        ProductosInterCambiables producto = new ProductosInterCambiables();
                        producto.idCombo = Convert.ToInt32(this.lector.GetValue(0));
                        producto.idProducto = Convert.ToInt32(this.lector.GetValue(1));
                        producto.idProductoInterCambiable = Convert.ToInt32(this.lector.GetValue(2));
                        if (this.lector.GetValue(3) == DBNull.Value)
                        {
                            producto.fechaRegistro = Convert.ToDateTime("01/01/01");
                            this.contador = this.contador + 1;
                        }
                        else
                        {
                            producto.fechaRegistro = Convert.ToDateTime(this.lector.GetValue(3));
                        }
                        producto.registradoPor = Convert.ToString(this.lector.GetValue(4));
                        productos.Add(producto);
                    }
                    catch (Exception)
                    {
                        this.contador = this.contador + 1;
                    }
                }
                this.connection.Close();
                this.command.Dispose();
                this.lector = null;
                return productos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//fin traer ProductosIntercambiables

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public string devCont()
        {
            return this.contador.ToString();
        }
        public string devTransferencias()
        {
            return this.transferencias.ToString();
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void insertarArqueos(Arqueos arqueos)
        {

            try
            {
                OracleConnection conexion = new OracleConnection(conexionstring);
                conexion.Open();
                OracleCommand command = conexion.CreateCommand();

                command.CommandText = "INSERT INTO Arqueos VALUES('" + arqueos.idCaja + "','" + arqueos.idDenominacion + "','" + arqueos.cantidad + "','" + arqueos.fechaCreacion.ToShortDateString() + "','" + arqueos.creadoPor + "','" + arqueos.moneda + "')";
                command.ExecuteNonQuery();
                conexion.Close();
                conexion.Dispose();
                command.Dispose();
                this.transferencias = transferencias + 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//fin del insertarArqueos
        public void insertarBitacora(Bitacora bitacora)
        {

            try
            {
                OracleConnection conexion = new OracleConnection(conexionstring);
                conexion.Open();
                OracleCommand command = conexion.CreateCommand();

                command.CommandText = "INSERT INTO Bitacora VALUES('" + bitacora.tabla + "','" + bitacora.usuario + "','" + bitacora.maquina + "','" + bitacora.fecha.ToShortDateString() + "','" + bitacora.tipo + "','" + bitacora.registro + "')";
                command.ExecuteNonQuery();
                conexion.Close();
                conexion.Dispose();
                command.Dispose();
                this.transferencias = transferencias + 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//fin del insertarBitacora
        public void insertarCajas(Cajas cajas)
        {

            try
            {
                OracleConnection conexion = new OracleConnection(conexionstring);
                conexion.Open();
                OracleCommand command = conexion.CreateCommand();

                command.CommandText = "INSERT INTO Cajas VALUES('"+cajas.id+"','"+cajas.responsabe+"','"+cajas.montoApertura+"','"+cajas.estado+"','"+cajas.fechaApertura.ToShortDateString() + "','"+cajas.cocineroTurno+"','"+cajas.fechaCierre.ToShortDateString()+"','"+cajas.montoCierre+"','"+cajas.montoCierreDolares+"','"+cajas.montoTarjetaBn+"','"+cajas.montoTarjetaBac+"')";
                command.ExecuteNonQuery();
                conexion.Close();
                conexion.Dispose();
                command.Dispose();
                this.transferencias = transferencias + 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//fin del insertarCajas
        public void insertarCierresInventarios(CierreInventarios cierres)
        {

            try
            {
                OracleConnection conexion = new OracleConnection(conexionstring);
                conexion.Open();
                OracleCommand command = conexion.CreateCommand();

                command.CommandText = "INSERT INTO CierresInventarios VALUES('" + cierres.responsable + "','" + cierres.fecha.ToShortDateString() + "','" + cierres.RevisadoPor + "','" + cierres.fechaRevisado.ToShortDateString() + "','" + cierres.fechaAnulacion.ToShortDateString() + "','" + cierres.anuladoPor + "','" + cierres.fechaCreacion.ToShortDateString() + "','" + cierres.estado + "','" + cierres.realizadoPor + "','" + cierres.observacion + "','" + cierres.id + "')";
                command.ExecuteNonQuery();
                conexion.Close();
                conexion.Dispose();
                command.Dispose();
                this.transferencias = transferencias + 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//fin del insertarCierresInventarios
        public void insertarClavesAutorizacion(ClavesAutorizacion claves)
        {

            try
            {
                OracleConnection conexion = new OracleConnection(conexionstring);
                conexion.Open();
                OracleCommand command = conexion.CreateCommand();

                command.CommandText = "INSERT INTO ClavesAutorizacion VALUES('" + claves.idAutorizacion + "','" + claves.clave + "','" + claves.fechaEmision.ToShortDateString() + "','" + claves.estado + "','" + claves.documento + "','" + claves.email + "')";
                command.ExecuteNonQuery();
                conexion.Close();
                conexion.Dispose();
                command.Dispose();
                this.transferencias = transferencias + 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//fin del insertarClavesAutorizacion
        public void insertarClientes(Clientes clientes)
        {

            try
            {
                OracleConnection conexion = new OracleConnection(conexionstring);
                conexion.Open();
                OracleCommand command = conexion.CreateCommand();

                command.CommandText = "INSERT INTO Clientes VALUES('" + clientes.id + "','" + clientes.tipoCedula + "','" + clientes.cedulaLegal + "','" + clientes.nombreLegal + "','" + clientes.direccion + "','" + clientes.telefono + "','" + clientes.email + "','" + clientes.fechaCreacion.ToShortDateString() + "','" + clientes.creadoPor + "','" + clientes.estado + "')";
                command.ExecuteNonQuery();
                conexion.Close();
                conexion.Dispose();
                command.Dispose();
                this.transferencias = transferencias + 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//fin del insertarClientes
        public void insertarCombosFacturados(CombosFacturados combos)
        {

            try
            {
                OracleConnection conexion = new OracleConnection(conexionstring);
                conexion.Open();
                OracleCommand command = conexion.CreateCommand();

                command.CommandText = "INSERT INTO CombosFacturados VALUES('" + combos.numFactura + "','" + combos.idCombo + "','" + combos.idProducto + "','" + combos.producto + "','" + combos.cantidadVenta + "','" + combos.registradoPor + "','" + combos.fechaRegistro.ToShortDateString() + "')";
                command.ExecuteNonQuery();
                conexion.Close();
                conexion.Dispose();
                command.Dispose();
                this.transferencias = transferencias + 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//fin del combosFacturados
        public void insertarDenominaciones(Denominaciones denominaciones)
        {

            try
            {
                OracleConnection conexion = new OracleConnection(conexionstring);
                conexion.Open();
                OracleCommand command = conexion.CreateCommand();

                command.CommandText = "INSERT INTO Denominaciones VALUES('" + denominaciones.id + "','" + denominaciones.denominacion + "','" + denominaciones.idMoneda + "','" + denominaciones.valor + "','" + denominaciones.creadoPor + "','" + denominaciones.estado + "','" + denominaciones.tipo + "','" + denominaciones.fechaCreacion.ToShortDateString() + "')";
                command.ExecuteNonQuery();
                conexion.Close();
                conexion.Dispose();
                command.Dispose();
                this.transferencias = transferencias + 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//fin del insertarDenominaciones
        public void insertarDetalleFacturas(DetalleFacturas detalle)
        {

            try
            {
                OracleConnection conexion = new OracleConnection(conexionstring);
                conexion.Open();
                OracleCommand command = conexion.CreateCommand();

                command.CommandText = "INSERT INTO DetalleFacturas VALUES('" + detalle.numFactura + "','" + detalle.numLinea + "','" + detalle.idProducto + "','" + detalle.descripcion + "','" + detalle.precioVenta + "','" + detalle.imp + "','" + detalle.cantidad + "','" + detalle.subTotal + "','" + detalle.esCombo + "')";
                command.ExecuteNonQuery();
                conexion.Close();
                conexion.Dispose();
                command.Dispose();
                this.transferencias = transferencias + 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//fin del insertarDetalleFacturas
        public void insertarDetalleMovimiento(DetalleMovimiento detalle)
        {

            try
            {
                OracleConnection conexion = new OracleConnection(conexionstring);
                conexion.Open();
                OracleCommand command = conexion.CreateCommand();

                command.CommandText = "INSERT INTO DetalleMovimiento VALUES('" + detalle.idMov + "','" + detalle.idProducto + "','" + detalle.producto + "','" + detalle.cantidad + "')";
                command.ExecuteNonQuery();
                conexion.Close();
                conexion.Dispose();
                command.Dispose();
                this.transferencias = transferencias + 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//fin del insertarDetalleMovimiento
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void insertarDetalleCierreInventarios(DetalleCierreInventarios detalle)
        {

            try
            {
                OracleConnection conexion = new OracleConnection(conexionstring);
                conexion.Open();
                OracleCommand command = conexion.CreateCommand();

                command.CommandText = "INSERT INTO DetalleCierreInventarios VALUES('" + detalle.idCierre + "','" + detalle.idProducto + "','" + detalle.descripcion + "','" + detalle.inicial + "','" + detalle.ingreso + "','" + detalle.observacionIngreso + "','" + detalle.salida + "','" + detalle.observacionSalida + "','" + detalle.conteo + "','" + detalle.gasto + "','" + detalle.facturado + "','" + detalle.diferencia + "','" + detalle.fechaCreacion.ToShortDateString() + "')";
                command.ExecuteNonQuery();
                conexion.Close();
                conexion.Dispose();
                command.Dispose();
                this.transferencias = transferencias + 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void insertarFacturas(Factura factura)
        {

            try
            {
                OracleConnection conexion = new OracleConnection(conexionstring);
                conexion.Open();
                OracleCommand command = conexion.CreateCommand();

                command.CommandText = "INSERT INTO Facturas VALUES('" + factura.numero + "','" + factura.fecha.ToShortDateString() + "','" + factura.terminoPago + "','" + factura.medioPago + "','" + factura.responsable + "','" + factura.idCliente + "','" + factura.idCaja + "','" + factura.subTotal + "','" + factura.impuesto + "','" + factura.total + "','" + factura.estado + "','" + factura.anuladoPor + "','" + factura.fechaAnulacion.ToShortDateString() + "','" + factura.montoEfectivo + "','" + factura.montoTarjeta + "','" + factura.montoDolares + "','" + factura.numTarjeta + "','" + factura.montoDescuento + "','" + factura.consumoAdministrativo + "','" + factura.tipoCambio + "')";
                command.ExecuteNonQuery();
                conexion.Close();
                conexion.Dispose();
                command.Dispose();
                this.transferencias = transferencias + 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void insertarMonedas(Monedas moneda)
        {

            try
            {
                OracleConnection conexion = new OracleConnection(conexionstring);
                conexion.Open();
                OracleCommand command = conexion.CreateCommand();

                command.CommandText = "INSERT INTO Monedas VALUES('" + moneda.id + "','" + moneda.descripcion + "','" + moneda.fechaCreacion.ToShortDateString() + "','" + moneda.creadoPor + "','" + moneda.estado + "')";
                command.ExecuteNonQuery();
                conexion.Close();
                conexion.Dispose();
                command.Dispose();
                this.transferencias = transferencias + 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void insertarMovimientos(Movimiento movimiento)
        {

            try
            {
                OracleConnection conexion = new OracleConnection(conexionstring);
                conexion.Open();
                OracleCommand command = conexion.CreateCommand();

                command.CommandText = "INSERT INTO Movimiento VALUES('" + movimiento.id + "','" + movimiento.responsable + "','" + movimiento.fecha.ToShortDateString() + "','" + movimiento.observacion + "','" + movimiento.tipo + "','" + movimiento.motivo + "','" + movimiento.estado + "','" + movimiento.idCierreInventario + "')";
                command.ExecuteNonQuery();
                conexion.Close();
                conexion.Dispose();
                command.Dispose();
                this.transferencias = transferencias + 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void insertarMovientosCaja(MovimientosCaja movimientosCaja)
        {

            try
            {
                OracleConnection conexion = new OracleConnection(conexionstring);
                conexion.Open();
                OracleCommand command = conexion.CreateCommand();

                command.CommandText = "INSERT INTO MovimientosCaja VALUES('" + movimientosCaja.id + "','" + movimientosCaja.idCaja + "','" + movimientosCaja.concepto + "','" + movimientosCaja.monto + "','" + movimientosCaja.tipo + "','" + movimientosCaja.fechaRegistro.ToShortDateString() + "','" + movimientosCaja.creadoPor + "')";
                command.ExecuteNonQuery();
                conexion.Close();
                conexion.Dispose();
                command.Dispose();
                this.transferencias = transferencias + 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void insertarPerfiles(Perfiles perfiles)
        {

            try
            {
                OracleConnection conexion = new OracleConnection(conexionstring);
                conexion.Open();
                OracleCommand command = conexion.CreateCommand();

                command.CommandText = "INSERT INTO Perfiles VALUES('" + perfiles.login + "','" + perfiles.nombreCompleto + "','" + perfiles.contraseña + "','" + perfiles.fechaCreacion.ToShortDateString() + "','" + perfiles.roll + "','" + perfiles.estado + "')";
                command.ExecuteNonQuery();
                conexion.Close();
                conexion.Dispose();
                command.Dispose();
                this.transferencias = transferencias + 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void insertarProductos(Productos productos)
        {

            try
            {
                OracleConnection conexion = new OracleConnection(conexionstring);
                conexion.Open();
                OracleCommand command = conexion.CreateCommand();

                command.CommandText = "INSERT INTO Productos VALUES('" + productos.id + "','" + productos.descripcion + "','" + productos.unidadMedida + "','" + productos.precioCompra + "','" + productos.precioVenta + "','" + productos.impVenta + "','" + productos.controladoCierre + "','" + productos.codBarra + "','" + productos.existencia + "','" + productos.fechaCreacion.ToShortDateString() + "','" + productos.creadoPor + "','" + productos.foto + "','" + productos.combo + "','" + productos.estado + "','" + productos.clasificacion + "','" + productos.productosCombo + "','" + productos.idCierreUltimAfectado + "')";
                command.ExecuteNonQuery();
                conexion.Close();
                conexion.Dispose();
                command.Dispose();
                this.transferencias = transferencias + 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void insertarProductosCombos(ProductosCombos productos)
        {

            try
            {
                OracleConnection conexion = new OracleConnection(conexionstring);
                conexion.Open();
                OracleCommand command = conexion.CreateCommand();

                command.CommandText = "INSERT INTO ProductosCombos VALUES('" + productos.idCombo + "','" + productos.idProducto + "','" + productos.precioVenta + "','" + productos.cantidad + "','" + productos.fechaCreacion.ToShortDateString() + "','" + productos.creadoPor + "','" + productos.interCambiar + "','" + productos.productosIntercambiables + "')";
                command.ExecuteNonQuery();
                conexion.Close();
                conexion.Dispose();
                command.Dispose();
                this.transferencias = transferencias + 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void insertarProductosInterCambiables(ProductosInterCambiables productos)
        {

            try
            {
                OracleConnection conexion = new OracleConnection(conexionstring);
                conexion.Open();
                OracleCommand command = conexion.CreateCommand();

                command.CommandText = "INSERT INTO ProductosInterCambiables VALUES('" + productos.idCombo + "','" + productos.idProducto + "','" + productos.idProductoInterCambiable + "','" + productos.fechaRegistro.ToShortDateString() + "','" + productos.registradoPor + "')";
                command.ExecuteNonQuery();
                conexion.Close();
                conexion.Dispose();
                command.Dispose();
                this.transferencias = transferencias + 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }//
}//
