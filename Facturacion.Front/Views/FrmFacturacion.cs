using System;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Windows.Forms;
using Facturacion.Front.Controllers;
using Facturacion.Front.Data;

namespace Facturacion.Front.Views
{
    public partial class FrmFacturacion : Form
    {
        FactConexion Conx;
        public FrmFacturacion()
        {
            InitializeComponent();
        }

        private void btnActualizaNoEnviados_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                Conx = new FactConexion();
                grdNoEnviados.DataSource = Conx.Documentos
                                           .Where(x => x.Estado == "GENERADO")
                                           .Select(x => new
                                           {
                                               x.IdDocumento,
                                               x.Documento,
                                               x.TipoDocumento,
                                               x.Caja,
                                               x.FechaRegistro,
                                               x.Estado,
                                               x.Documentos_Tramas.xml
                                           }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Facturacion",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }

        private void menuPrueba_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            
            try
            {
                Conx = new FactConexion();
                var Documento = Conx.Documentos
                                           .Where(x => x.Estado == "GENERADO")
                                           .Select(x => new
                                           {
                                               x.Ruc,
                                               x.Documento,
                                               x.TipoDocumento,
                                               x.Caja,
                                               x.FechaRegistro,
                                               x.Estado,
                                               x.Documentos_Tramas.xml,
                                               x.Documentos_Tramas.xmlzip,
                                               x.Documentos_Tramas.Firmaxml
                                           }).ToList();
                foreach (var item in Documento)
                {
                    SunatController Sun = new SunatController(item.Ruc);
                    var res = Sun.EnvioSunatDocumento(item.xmlzip, item.TipoDocumento, item.Documento);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }
    }
}
