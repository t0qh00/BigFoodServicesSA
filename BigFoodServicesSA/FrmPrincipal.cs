using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BigFoodServicesSA.Properties;
using BLL;

namespace BigFoodServicesSA
{
    public partial class FrmPrincipal : Form
    {
        Conexion conexion;
        public FrmPrincipal()
        {
            InitializeComponent();
            this.conexion = new Conexion(obtenerStringConexion());
        }

        private void btnNum_Click(object sender, EventArgs e)
        {
            try
            {
                this.lblNumero.Text = "En Proceso";
                this.lblNumero.Text = this.transferirDatos();
                lblContadorErrores.Text = this.conexion.devCont();
                lblErrorM.Text = "Errores existentes y solucionados con datos por defecto:";
                lblTransferencias.Text = this.conexion.devTransferencias();
            }
            catch (Exception ex)
            {

                mensajeError(ex.Message);
            }
        }
        private void mensajeError(string texto)
        {
            MessageBox.Show(texto, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static string obtenerStringConexion()
        {
            return Settings.Default.GESTIONConnectionString;
        }
        public string transferirDatos()
        {
            List<Arqueos> arqueos = new List<Arqueos>();
            List<Bitacora> bitacora = new List<Bitacora>();
            List<Cajas> cajas = new List<Cajas>();
            List<CierreInventarios> cierresI = new List<CierreInventarios>();
            List<ClavesAutorizacion> claves = new List<ClavesAutorizacion>();
            List<Clientes> clientes = new List<Clientes>();
            List<CombosFacturados> combos = new List<CombosFacturados>();
            List<Denominaciones> denominaciones = new List<Denominaciones>();
            List<DetalleFacturas> detallesF = new List<DetalleFacturas>();
            List<DetalleMovimiento> detallesM = new List<DetalleMovimiento>();
            List<DetalleCierreInventarios> detalleC = new List<DetalleCierreInventarios>();
            List<Factura> facturas = new List<Factura>();
            List<Monedas> monedas = new List<Monedas>();
            List<Movimiento> movimientos = new List<Movimiento>();
            List<MovimientosCaja> movimientosCajas = new List<MovimientosCaja>();
            List<Perfiles> perfiles = new List<Perfiles>();
            List<Productos> productos = new List<Productos>();
            List<ProductosCombos> productosCombos = new List<ProductosCombos>();
            List<ProductosInterCambiables> productosInterCambiables = new List<ProductosInterCambiables>();

            try
            {
                //////////////////////////////////////////////////////////////////
                arqueos = this.conexion.traerArqueos();
                bitacora = this.conexion.traerBitacora();
                cajas = this.conexion.traerCajas();
                cierresI = this.conexion.traerCierreInventarios();
                claves = this.conexion.traerClavesAutorizacion();
                clientes = this.conexion.traerClientes();
                combos = this.conexion.traerCombosFacturados();
                denominaciones = this.conexion.traerDenominaciones();
                detallesF = this.conexion.traerDetalleFacturas();
                detallesM = this.conexion.traerDetalleMovimiento();
                //////////////////////////////////////////////////////////////////
                detalleC = this.conexion.TraerDetalleCierreInventarios();
                facturas = this.conexion.TraerFactura();
                monedas = this.conexion.traerMonedas();
                movimientos = this.conexion.traerMovimiento();
                movimientosCajas = this.conexion.traerMovimientosCaja();
                perfiles = this.conexion.traerPerfiles();
                productos = this.conexion.TraerProductos();
                productosCombos = this.conexion.TraerProductosCombos();
                productosInterCambiables = this.conexion.TraerProductosIntercambiables();
                //////////////////////////////////////////////////////////////////
                this.insertarBitacora(bitacora);
                this.insertarPerfiles(perfiles);
                this.insertarMonedas(monedas);
                this.insertarDenominaciones(denominaciones);
                this.insertarArqueos(arqueos);
                this.insertarCajas(cajas);
                this.insertarCierresI(cierresI);
                this.insertarClaves(claves);
                this.insertarClientes(clientes);
                this.insertarDetallesF(detallesF);
                /////////////////////////////////////////////////////////////////
                this.insertarDetallesC(detalleC);
                this.insertarFacturas(facturas);
                this.insertarMovimiento(movimientos);
                this.insertarMovimientosCaja(movimientosCajas);
                this.insertarDetallesM(detallesM);
                this.insertarProductos(productos);
                this.insertarProductosCombos(productosCombos);
                this.insertarProductosIntercambiables(productosInterCambiables);
                this.insertarCombos(combos);
            }
            catch (Exception ex)
            {

                this.mensajeError(ex.Message);
            }
            return "Finalizado";
        }//Fin de transferirDatos
        public void insertarArqueos(List<Arqueos> list)
        {
            try
            {
                foreach (var item in list)
                {
                    this.conexion.insertarArqueos(item);
                }
            }
            catch (Exception ex)
            {

                this.mensajeError(ex.Message);
            }
        }//
        public void insertarBitacora(List<Bitacora> list)
        {
            try
            {
                foreach (var item in list)
                {
                    this.conexion.insertarBitacora(item);
                }
            }
            catch (Exception ex)
            {

                this.mensajeError(ex.Message);
            }
        }//
        public void insertarCajas(List<Cajas> list)
        {
            try
            {
                foreach (var item in list)
                {
                    this.conexion.insertarCajas(item);
                }
            }
            catch (Exception ex)
            {

                this.mensajeError(ex.Message);
            }
        }//
        public void insertarCierresI(List<CierreInventarios> list)
        {
            try
            {
                foreach (var item in list)
                {
                    this.conexion.insertarCierresInventarios(item);
                }
            }
            catch (Exception ex)
            {

                this.mensajeError(ex.Message);
            }
        }//
        public void insertarClaves(List<ClavesAutorizacion> list)
        {
            try
            {
                foreach (var item in list)
                {
                    this.conexion.insertarClavesAutorizacion(item);
                }
            }
            catch (Exception ex)
            {

                this.mensajeError(ex.Message);
            }
        }//
        public void insertarClientes(List<Clientes> list)
        {
            try
            {
                foreach (var item in list)
                {
                    this.conexion.insertarClientes(item);
                }
            }
            catch (Exception ex)
            {

                this.mensajeError(ex.Message);
            }
        }//
        public void insertarCombos(List<CombosFacturados> list)
        {
            try
            {
                foreach (var item in list)
                {
                    this.conexion.insertarCombosFacturados(item);
                }
            }
            catch (Exception ex)
            {

                this.mensajeError(ex.Message);
            }
        }//
        public void insertarDenominaciones(List<Denominaciones> list)
        {
            try
            {
                foreach (var item in list)
                {
                    this.conexion.insertarDenominaciones(item);
                }
            }
            catch (Exception ex)
            {

                this.mensajeError(ex.Message);
            }
        }//
        public void insertarDetallesF(List<DetalleFacturas> list)
        {
            try
            {
                foreach (var item in list)
                {
                    this.conexion.insertarDetalleFacturas(item);
                }
            }
            catch (Exception ex)
            {

                this.mensajeError(ex.Message);
            }
        }//
        public void insertarDetallesM(List<DetalleMovimiento> list)
        {
            try
            {
                foreach (var item in list)
                {
                    this.conexion.insertarDetalleMovimiento(item);
                }
            }
            catch (Exception ex)
            {

                this.mensajeError(ex.Message);
            }
        }//
        public void insertarDetallesC(List<DetalleCierreInventarios> list)
        {
            try
            {
                foreach (var item in list)
                {
                    this.conexion.insertarDetalleCierreInventarios(item);
                }
            }
            catch (Exception ex)
            {

                this.mensajeError(ex.Message);
            }
        }//
        public void insertarFacturas(List<Factura> list)
        {
            try
            {
                foreach (var item in list)
                {
                    this.conexion.insertarFacturas(item);
                }
            }
            catch (Exception ex)
            {

                this.mensajeError(ex.Message);
            }
        }//
        public void insertarMonedas(List<Monedas> list)
        {
            try
            {
                foreach (var item in list)
                {
                    this.conexion.insertarMonedas(item);
                }
            }
            catch (Exception ex)
            {

                this.mensajeError(ex.Message);
            }
        }//
        public void insertarMovimiento(List<Movimiento> list)
        {
            try
            {
                foreach (var item in list)
                {
                    this.conexion.insertarMovimientos(item);
                }
            }
            catch (Exception ex)
            {

                this.mensajeError(ex.Message);
            }
        }//
        public void insertarMovimientosCaja(List<MovimientosCaja> list)
        {
            try
            {
                foreach (var item in list)
                {
                    this.conexion.insertarMovientosCaja(item);
                }
            }
            catch (Exception ex)
            {

                this.mensajeError(ex.Message);
            }
        }//
        public void insertarPerfiles(List<Perfiles> list)
        {
            try
            {
                foreach (var item in list)
                {
                    this.conexion.insertarPerfiles(item);
                }
            }
            catch (Exception ex)
            {

                this.mensajeError(ex.Message);
            }
        }//
        public void insertarProductos(List<Productos> list)
        {
            try
            {
                foreach (var item in list)
                {
                    this.conexion.insertarProductos(item);
                }
            }
            catch (Exception ex)
            {

                this.mensajeError(ex.Message);
            }
        }//
        public void insertarProductosCombos(List<ProductosCombos> list)
        {
            try
            {
                foreach (var item in list)
                {
                    this.conexion.insertarProductosCombos(item);
                }
            }
            catch (Exception ex)
            {

                this.mensajeError(ex.Message);
            }
        }//
        public void insertarProductosIntercambiables(List<ProductosInterCambiables> list)
        {
            try
            {
                foreach (var item in list)
                {
                    this.conexion.insertarProductosInterCambiables(item);
                }
            }
            catch (Exception ex)
            {

                this.mensajeError(ex.Message);
            }
        }//
    }//
}//
