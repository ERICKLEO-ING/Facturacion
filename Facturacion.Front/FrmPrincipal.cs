namespace Facturacion.Front
{
    using System;
    using System.Windows.Forms;
    using System.Configuration;
    using System.Diagnostics;
    using Facturacion.Front.Data;

    public partial class FrmPrincipal : Form
    {
        #region Variables
        volatile bool IsRunning;
        bool Cerrar;
        static Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        DateTime FechaInicial;
        DateTime FechaFinal;
        Timer Timer1 = new Timer();
        #endregion
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void Habilitar_Timer_Procesos()
        {
            //Timer1.Tick += new EventHandler(timer1_Tick); // Every time timer ticks, timer_Tick will be called
            //int Minutos = Convert.ToInt16(config.AppSettings.Settings["Timer"].Value);
            //if (Minutos >= 5) { Minutos = 5; }
            //Timer1.Interval = (Minutos)*(60) * (1000);  // Timer will tick every 10 seconds
            //Timer1.Enabled = true;                        // Enable the timer
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    if (Process.GetProcessesByName("Facturacion Electronica").Length > 1)
            //    {
            //        MessageBox.Show("Ya se esta ejecutando el aplicativo de facturacion electronica!");
            //        Cerrar = true;
            //        Application.Exit();
            //        return;
            //    }                    
            //    DocumentoData Data = new DocumentoData();
            //    dgvDocFalt.DataSource = Data.SeleccionarDocumentosNoEnviados(DateTime.Now.Date, DateTime.Now.Date);
            //    dgvDocNoProc.DataSource = Data.SeleccionarDocumentosNoProcesados(DateTime.Now.Date, DateTime.Now.Date);
            //    dgvDocAut.DataSource = Data.SeleccionarDocumentosAutorizados(DateTime.Now.Date, DateTime.Now.Date);
            //    dgvDocNoAut.DataSource = Data.SeleccionarDocumentosNoAutorizados(DateTime.Now.Date, DateTime.Now.Date);
            //    Habilitar_Timer_Procesos();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (IsRunning)
            //    return;
            //try
            //{
            //    IsRunning = true;
            //    DocumentoController Documento = new DocumentoController();
            //    Documento.EnviarDocumentosElectronicos();
            //    Documento.ConsultaEstadoDocumentosElectronicos();
            //}
            //finally
            //{
            //    IsRunning = false;
            //}
        }

        public void Formato_DGV(int Cantidad, DataGridView DGV, string[] Parametros)
        {
            //try
            //{
            //    int Nparametro;
            //    Nparametro = 0;
            //    for (int i = 0; i < Cantidad; i++)
            //    {
            //        DGV.Columns.Add(Parametros[Nparametro].ToString(), Parametros[Nparametro].ToString());
            //        DGV.Columns[i].DataPropertyName = Parametros[Nparametro + 1].ToString();
            //        DGV.Columns[i].Width = Convert.ToInt32(Parametros[Nparametro + 2].ToString());
            //        if (Parametros[Nparametro + 3].ToString().Equals("1"))
            //        {
            //            DGV.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //        }
            //        else if (Parametros[Nparametro + 3].ToString().Equals("2"))
            //        {
            //            DGV.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //        }
            //        else if (Parametros[Nparametro + 3].ToString().Equals("3"))
            //        {
            //            DGV.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //        }
            //        if (Parametros[Nparametro + 4].ToString().Equals("1"))
            //        {
            //            DGV.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //        }
            //        else if (Parametros[Nparametro + 4].ToString().Equals("2"))
            //        {
            //            DGV.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //        }
            //        else if (Parametros[Nparametro + 4].ToString().Equals("3"))
            //        {
            //            DGV.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            //        }
            //        Nparametro = Nparametro + 5;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Formato_DGV: " + ex.Message.ToString());
            //}

        }

        private void formTwitter_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                IconizarApp.Icon = this.Icon;
                IconizarApp.ContextMenuStrip = this.mnuContextual;
                IconizarApp.Text = Application.ProductName;
                IconizarApp.Visible = true;
                this.Visible = false;
                IconizarApp.BalloonTipIcon = ToolTipIcon.Info;
                IconizarApp.BalloonTipTitle = "Facturacion Electronica";
                IconizarApp.BalloonTipText = "La aplicación ha quedado ocultada " +
                    "en el área de notificación.";
                IconizarApp.ShowBalloonTip(1000);
            }
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Cerrar)
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void FrmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (var process in Process.GetProcessesByName("Facturacion Electronica.exe"))
            {
                process.Kill();
            }
        }

        private void mnuMostrarAplicacion_Click_1(object sender, EventArgs e)
        {
            this.Show();
        }
        private void mnuCerrarAplicacion_Click_1(object sender, EventArgs e)
        {
            Cerrar = true;
            Application.Exit();
        }

        #region GrillaDocumentosNoEnviados
        //private void btnActualizaNoEnviados_Click(object sender, EventArgs e)
        //{
        //    Cursor.Current = Cursors.WaitCursor;
        //    try
        //    {
        //        DocumentoData Data = new DocumentoData();
        //        FechaInicial = Convert.ToDateTime(dtpDocNoEnvFecIni.Text);
        //        FechaFinal = Convert.ToDateTime(dtpDocNoEnvFecFin.Text);

        //        if (FechaInicial > FechaFinal)
        //        {
        //            MessageBox.Show("Rango de fechas para busqueda incorrecta!!!");
        //        }
        //        else if ((FechaFinal - FechaInicial).TotalDays > 31)
        //        {
        //            MessageBox.Show("La consulta no puede ser mayor a 1 mes.");
        //            dtpDocNoEnvFecIni.Text = dtpDocNoEnvFecFin.Text;
        //        }
        //        else
        //        {
        //            dgvDocFalt.DataSource = Data.SeleccionarDocumentosNoEnviados(dtpDocNoEnvFecIni.Value.Date, dtpDocNoEnvFecFin.Value.Date);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        Cursor.Current = Cursors.Default;
        //    }

        //}
        //private void chkFiltrarDocNoEnv_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkFiltrarDocNoEnv.Checked)
        //    {
        //        dtpDocNoEnvFecIni.Enabled = true;
        //        dtpDocNoEnvFecFin.Enabled = true;
        //    }
        //    else
        //    {
        //        dtpDocNoEnvFecIni.Text = DateTime.Today.ToLongDateString();
        //        dtpDocNoEnvFecFin.Text = DateTime.Today.ToLongDateString();
        //        dtpDocNoEnvFecIni.Enabled = false;
        //        dtpDocNoEnvFecFin.Enabled = false;
        //    }
        //}

        #endregion

        #region GrillaDocumentosNoProcesados
        //private void btnNoProcesados_Click(object sender, EventArgs e)
        //{
        //    Cursor.Current = Cursors.WaitCursor;
        //    try
        //    {
        //        DocumentoData Data = new DocumentoData();
        //        FechaInicial = Convert.ToDateTime(dtpDocNoProcFecIni.Text);
        //        FechaFinal = Convert.ToDateTime(dtpDocNoProcFecFin.Text);

        //        if (FechaInicial > FechaFinal)
        //        {
        //            MessageBox.Show("Rango de fechas para busqueda incorrecta!!!");
        //        }
        //        else if ((FechaFinal - FechaInicial).TotalDays > 31)
        //        {
        //            MessageBox.Show("La consulta no puede ser mayor a 1 mes.");
        //            dtpDocNoProcFecIni.Text = dtpDocNoProcFecFin.Text;
        //        }
        //        else
        //        {
        //            dgvDocNoProc.DataSource = Data.SeleccionarDocumentosNoProcesados(dtpDocNoProcFecIni.Value.Date, dtpDocNoProcFecFin.Value.Date);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        Cursor.Current = Cursors.Default;
        //    }

        //}
        //private void chkFiltrarDocNoProc_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkFiltrarDocNoProc.Checked)
        //    {
        //        dtpDocNoProcFecIni.Enabled = true;
        //        dtpDocNoProcFecFin.Enabled = true;
        //    }
        //    else
        //    {
        //        dtpDocNoProcFecIni.Text = DateTime.Today.ToLongDateString();
        //        dtpDocNoProcFecFin.Text = DateTime.Today.ToLongDateString();
        //        dtpDocNoProcFecIni.Enabled = false;
        //        dtpDocNoProcFecFin.Enabled = false;
        //    }
        //}
        #endregion

        #region GrillaDocumentosAutorizados
        //private void btnAutorizados_Click(object sender, EventArgs e)
        //{
        //    Cursor.Current = Cursors.WaitCursor;
        //    try
        //    {
        //        DocumentoData Data = new DocumentoData();
        //        FechaInicial = Convert.ToDateTime(dtpDocAutFecIni.Text);
        //        FechaFinal = Convert.ToDateTime(dtpDocAutFecFin.Text);

        //        if (FechaInicial > FechaFinal)
        //        {
        //            MessageBox.Show("Rango de fechas para busqueda incorrecta!!!");
        //        }
        //        else if ((FechaFinal - FechaInicial).TotalDays > 31)
        //        {
        //            MessageBox.Show("La consulta no puede ser mayor a 1 mes.");
        //            dtpDocAutFecIni.Text = dtpDocAutFecFin.Text;
        //        }
        //        else
        //        {
        //            dgvDocAut.DataSource = Data.SeleccionarDocumentosAutorizados(dtpDocAutFecIni.Value.Date, dtpDocAutFecFin.Value.Date);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        Cursor.Current = Cursors.Default;
        //    }

        //}
        //private void chkFiltrarDocAut_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkFiltrarDocAut.Checked)
        //    {
        //        dtpDocAutFecIni.Enabled = true;
        //        dtpDocAutFecFin.Enabled = true;
        //    }
        //    else
        //    {
        //        dtpDocAutFecIni.Text = DateTime.Today.ToLongDateString();
        //        dtpDocAutFecFin.Text = DateTime.Today.ToLongDateString();
        //        dtpDocAutFecIni.Enabled = false;
        //        dtpDocAutFecFin.Enabled = false;
        //    }
        //}
        #endregion

        #region GrillaDocumentosNoAutorizados
        //private void btnNoAutorizado_Click(object sender, EventArgs e)
        //{
        //    //Cursor.Current = Cursors.WaitCursor;
        //    //try
        //    //{
        //    //    DocumentoData Data = new DocumentoData();
        //    //    FechaInicial = Convert.ToDateTime(dtpDocNoAutFecIni.Text);
        //    //    FechaFinal = Convert.ToDateTime(dtpDocNoAutFecFin.Text);

        //    //    if (FechaInicial > FechaFinal)
        //    //    {
        //    //        MessageBox.Show("Rango de fechas para busqueda incorrecta!!!");
        //    //    }
        //    //    else if ((FechaFinal - FechaInicial).TotalDays > 31)
        //    //    {
        //    //        MessageBox.Show("La consulta no puede ser mayor a 1 mes.");
        //    //        dtpDocNoAutFecIni.Text = dtpDocNoAutFecFin.Text;
        //    //    }
        //    //    else
        //    //    {
        //    //        dgvDocNoAut.DataSource = Data.SeleccionarDocumentosNoAutorizados(dtpDocNoAutFecIni.Value.Date, dtpDocNoAutFecFin.Value.Date);
        //    //    }
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    MessageBox.Show(ex.Message);
        //    //}
        //    //finally
        //    //{
        //    //    Cursor.Current = Cursors.Default;
        //    //}
        //}
        //private void chkFiltrarDocNoAut_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkFiltrarDocNoAut.Checked)
        //    {
        //        dtpDocNoAutFecIni.Enabled = true;
        //        dtpDocNoAutFecFin.Enabled = true;
        //    }
        //    else
        //    {
        //        dtpDocNoAutFecIni.Text = DateTime.Today.ToLongDateString();
        //        dtpDocNoAutFecFin.Text = DateTime.Today.ToLongDateString();
        //        dtpDocNoAutFecIni.Enabled = false;
        //        dtpDocNoAutFecFin.Enabled = false;
        //    }
        //}

        #endregion


        private void tabFacturas_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (tabFacturas.SelectedIndex == 0)
            //{
            //    GenerarXmlToolStripMenuItem.Enabled = false;
            //}
            //else if (tabFacturas.SelectedIndex == 1)
            //{
            //    GenerarXmlToolStripMenuItem.Enabled = false;
            //}
            //else if (tabFacturas.SelectedIndex == 2)
            //{
            //    GenerarXmlToolStripMenuItem.Enabled = false;
            //}
            //else if (tabFacturas.SelectedIndex == 3)
            //{
            //    GenerarXmlToolStripMenuItem.Enabled = true;
            //}
        }


    }
}



