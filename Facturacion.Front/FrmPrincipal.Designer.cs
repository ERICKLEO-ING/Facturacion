namespace Facturacion.Front
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.tabFacturas = new System.Windows.Forms.TabControl();
            this.tabDocNoEnv = new System.Windows.Forms.TabPage();
            this.btnActualizaNoEnviados = new System.Windows.Forms.Button();
            this.chkFiltrarDocNoEnv = new System.Windows.Forms.CheckBox();
            this.dtpDocNoEnvFecFin = new System.Windows.Forms.DateTimePicker();
            this.dtpDocNoEnvFecIni = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvDocFalt = new System.Windows.Forms.DataGridView();
            this.tabDocNoProc = new System.Windows.Forms.TabPage();
            this.btnNoProcesados = new System.Windows.Forms.Button();
            this.chkFiltrarDocNoProc = new System.Windows.Forms.CheckBox();
            this.dtpDocNoProcFecFin = new System.Windows.Forms.DateTimePicker();
            this.dtpDocNoProcFecIni = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvDocNoProc = new System.Windows.Forms.DataGridView();
            this.tabDocAuto = new System.Windows.Forms.TabPage();
            this.btnAutorizados = new System.Windows.Forms.Button();
            this.chkFiltrarDocAut = new System.Windows.Forms.CheckBox();
            this.dtpDocAutFecFin = new System.Windows.Forms.DateTimePicker();
            this.dtpDocAutFecIni = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvDocAut = new System.Windows.Forms.DataGridView();
            this.tabDocNoAuto = new System.Windows.Forms.TabPage();
            this.btnNoAutorizado = new System.Windows.Forms.Button();
            this.chkFiltrarDocNoAut = new System.Windows.Forms.CheckBox();
            this.dtpDocNoAutFecFin = new System.Windows.Forms.DateTimePicker();
            this.dtpDocNoAutFecIni = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvDocNoAut = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.GenerarXmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.mnuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuMostrarAplicacion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCerrarAplicacion = new System.Windows.Forms.ToolStripMenuItem();
            this.IconizarApp = new System.Windows.Forms.NotifyIcon(this.components);
            this.tabFacturas.SuspendLayout();
            this.tabDocNoEnv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocFalt)).BeginInit();
            this.tabDocNoProc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocNoProc)).BeginInit();
            this.tabDocAuto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocAut)).BeginInit();
            this.tabDocNoAuto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocNoAut)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.mnuContextual.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabFacturas
            // 
            this.tabFacturas.Controls.Add(this.tabDocNoEnv);
            this.tabFacturas.Controls.Add(this.tabDocNoProc);
            this.tabFacturas.Controls.Add(this.tabDocAuto);
            this.tabFacturas.Controls.Add(this.tabDocNoAuto);
            this.tabFacturas.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabFacturas.Location = new System.Drawing.Point(12, 27);
            this.tabFacturas.Name = "tabFacturas";
            this.tabFacturas.SelectedIndex = 0;
            this.tabFacturas.Size = new System.Drawing.Size(867, 545);
            this.tabFacturas.TabIndex = 9;
            this.tabFacturas.SelectedIndexChanged += new System.EventHandler(this.tabFacturas_SelectedIndexChanged);
            // 
            // tabDocNoEnv
            // 
            this.tabDocNoEnv.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tabDocNoEnv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabDocNoEnv.Controls.Add(this.btnActualizaNoEnviados);
            this.tabDocNoEnv.Controls.Add(this.chkFiltrarDocNoEnv);
            this.tabDocNoEnv.Controls.Add(this.dtpDocNoEnvFecFin);
            this.tabDocNoEnv.Controls.Add(this.dtpDocNoEnvFecIni);
            this.tabDocNoEnv.Controls.Add(this.label4);
            this.tabDocNoEnv.Controls.Add(this.label3);
            this.tabDocNoEnv.Controls.Add(this.dgvDocFalt);
            this.tabDocNoEnv.Location = new System.Drawing.Point(4, 22);
            this.tabDocNoEnv.Name = "tabDocNoEnv";
            this.tabDocNoEnv.Padding = new System.Windows.Forms.Padding(3);
            this.tabDocNoEnv.Size = new System.Drawing.Size(859, 519);
            this.tabDocNoEnv.TabIndex = 0;
            this.tabDocNoEnv.Text = "Documentos - No Enviados";
            // 
            // btnActualizaNoEnviados
            // 
            this.btnActualizaNoEnviados.BackColor = System.Drawing.Color.LimeGreen;
            this.btnActualizaNoEnviados.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnActualizaNoEnviados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizaNoEnviados.Location = new System.Drawing.Point(737, 2);
            this.btnActualizaNoEnviados.Name = "btnActualizaNoEnviados";
            this.btnActualizaNoEnviados.Size = new System.Drawing.Size(114, 29);
            this.btnActualizaNoEnviados.TabIndex = 19;
            this.btnActualizaNoEnviados.Text = "Actualizar";
            this.btnActualizaNoEnviados.UseVisualStyleBackColor = false;
            // 
            // chkFiltrarDocNoEnv
            // 
            this.chkFiltrarDocNoEnv.AutoSize = true;
            this.chkFiltrarDocNoEnv.Location = new System.Drawing.Point(19, 9);
            this.chkFiltrarDocNoEnv.Name = "chkFiltrarDocNoEnv";
            this.chkFiltrarDocNoEnv.Size = new System.Drawing.Size(51, 17);
            this.chkFiltrarDocNoEnv.TabIndex = 18;
            this.chkFiltrarDocNoEnv.Text = "Filtrar";
            this.chkFiltrarDocNoEnv.UseVisualStyleBackColor = true;
            // 
            // dtpDocNoEnvFecFin
            // 
            this.dtpDocNoEnvFecFin.Enabled = false;
            this.dtpDocNoEnvFecFin.Location = new System.Drawing.Point(507, 7);
            this.dtpDocNoEnvFecFin.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpDocNoEnvFecFin.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpDocNoEnvFecFin.Name = "dtpDocNoEnvFecFin";
            this.dtpDocNoEnvFecFin.Size = new System.Drawing.Size(200, 20);
            this.dtpDocNoEnvFecFin.TabIndex = 17;
            // 
            // dtpDocNoEnvFecIni
            // 
            this.dtpDocNoEnvFecIni.Enabled = false;
            this.dtpDocNoEnvFecIni.Location = new System.Drawing.Point(209, 7);
            this.dtpDocNoEnvFecIni.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpDocNoEnvFecIni.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpDocNoEnvFecIni.Name = "dtpDocNoEnvFecIni";
            this.dtpDocNoEnvFecIni.Size = new System.Drawing.Size(200, 20);
            this.dtpDocNoEnvFecIni.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(439, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Fecha Final";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(138, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Fecha Inicio";
            // 
            // dgvDocFalt
            // 
            this.dgvDocFalt.AllowUserToAddRows = false;
            this.dgvDocFalt.AllowUserToDeleteRows = false;
            this.dgvDocFalt.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocFalt.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDocFalt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDocFalt.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDocFalt.Location = new System.Drawing.Point(6, 33);
            this.dgvDocFalt.Name = "dgvDocFalt";
            this.dgvDocFalt.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocFalt.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDocFalt.RowHeadersVisible = false;
            this.dgvDocFalt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocFalt.Size = new System.Drawing.Size(845, 480);
            this.dgvDocFalt.TabIndex = 4;
            // 
            // tabDocNoProc
            // 
            this.tabDocNoProc.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tabDocNoProc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabDocNoProc.Controls.Add(this.btnNoProcesados);
            this.tabDocNoProc.Controls.Add(this.chkFiltrarDocNoProc);
            this.tabDocNoProc.Controls.Add(this.dtpDocNoProcFecFin);
            this.tabDocNoProc.Controls.Add(this.dtpDocNoProcFecIni);
            this.tabDocNoProc.Controls.Add(this.label5);
            this.tabDocNoProc.Controls.Add(this.label6);
            this.tabDocNoProc.Controls.Add(this.dgvDocNoProc);
            this.tabDocNoProc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabDocNoProc.Location = new System.Drawing.Point(4, 22);
            this.tabDocNoProc.Name = "tabDocNoProc";
            this.tabDocNoProc.Size = new System.Drawing.Size(859, 519);
            this.tabDocNoProc.TabIndex = 3;
            this.tabDocNoProc.Text = "Documentos - No Procesados";
            // 
            // btnNoProcesados
            // 
            this.btnNoProcesados.BackColor = System.Drawing.Color.LimeGreen;
            this.btnNoProcesados.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNoProcesados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNoProcesados.Location = new System.Drawing.Point(737, 2);
            this.btnNoProcesados.Name = "btnNoProcesados";
            this.btnNoProcesados.Size = new System.Drawing.Size(114, 29);
            this.btnNoProcesados.TabIndex = 21;
            this.btnNoProcesados.Text = "Actualizar";
            this.btnNoProcesados.UseVisualStyleBackColor = false;
            // 
            // chkFiltrarDocNoProc
            // 
            this.chkFiltrarDocNoProc.AutoSize = true;
            this.chkFiltrarDocNoProc.Location = new System.Drawing.Point(19, 9);
            this.chkFiltrarDocNoProc.Name = "chkFiltrarDocNoProc";
            this.chkFiltrarDocNoProc.Size = new System.Drawing.Size(51, 17);
            this.chkFiltrarDocNoProc.TabIndex = 20;
            this.chkFiltrarDocNoProc.Text = "Filtrar";
            this.chkFiltrarDocNoProc.UseVisualStyleBackColor = true;
            // 
            // dtpDocNoProcFecFin
            // 
            this.dtpDocNoProcFecFin.Enabled = false;
            this.dtpDocNoProcFecFin.Location = new System.Drawing.Point(507, 7);
            this.dtpDocNoProcFecFin.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpDocNoProcFecFin.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpDocNoProcFecFin.Name = "dtpDocNoProcFecFin";
            this.dtpDocNoProcFecFin.Size = new System.Drawing.Size(200, 20);
            this.dtpDocNoProcFecFin.TabIndex = 19;
            // 
            // dtpDocNoProcFecIni
            // 
            this.dtpDocNoProcFecIni.Enabled = false;
            this.dtpDocNoProcFecIni.Location = new System.Drawing.Point(209, 7);
            this.dtpDocNoProcFecIni.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpDocNoProcFecIni.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpDocNoProcFecIni.Name = "dtpDocNoProcFecIni";
            this.dtpDocNoProcFecIni.Size = new System.Drawing.Size(200, 20);
            this.dtpDocNoProcFecIni.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(439, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Fecha Final";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(138, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Fecha Inicio";
            // 
            // dgvDocNoProc
            // 
            this.dgvDocNoProc.AllowUserToAddRows = false;
            this.dgvDocNoProc.AllowUserToDeleteRows = false;
            this.dgvDocNoProc.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocNoProc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDocNoProc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDocNoProc.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDocNoProc.Location = new System.Drawing.Point(6, 33);
            this.dgvDocNoProc.Name = "dgvDocNoProc";
            this.dgvDocNoProc.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocNoProc.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDocNoProc.RowHeadersVisible = false;
            this.dgvDocNoProc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocNoProc.Size = new System.Drawing.Size(845, 480);
            this.dgvDocNoProc.TabIndex = 5;
            // 
            // tabDocAuto
            // 
            this.tabDocAuto.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tabDocAuto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabDocAuto.Controls.Add(this.btnAutorizados);
            this.tabDocAuto.Controls.Add(this.chkFiltrarDocAut);
            this.tabDocAuto.Controls.Add(this.dtpDocAutFecFin);
            this.tabDocAuto.Controls.Add(this.dtpDocAutFecIni);
            this.tabDocAuto.Controls.Add(this.label7);
            this.tabDocAuto.Controls.Add(this.label8);
            this.tabDocAuto.Controls.Add(this.dgvDocAut);
            this.tabDocAuto.Location = new System.Drawing.Point(4, 22);
            this.tabDocAuto.Name = "tabDocAuto";
            this.tabDocAuto.Padding = new System.Windows.Forms.Padding(3);
            this.tabDocAuto.Size = new System.Drawing.Size(859, 519);
            this.tabDocAuto.TabIndex = 1;
            this.tabDocAuto.Text = "Documentos - Autorizados";
            // 
            // btnAutorizados
            // 
            this.btnAutorizados.BackColor = System.Drawing.Color.LimeGreen;
            this.btnAutorizados.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAutorizados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutorizados.Location = new System.Drawing.Point(737, 2);
            this.btnAutorizados.Name = "btnAutorizados";
            this.btnAutorizados.Size = new System.Drawing.Size(114, 29);
            this.btnAutorizados.TabIndex = 21;
            this.btnAutorizados.Text = "Actualizar";
            this.btnAutorizados.UseVisualStyleBackColor = false;
            // 
            // chkFiltrarDocAut
            // 
            this.chkFiltrarDocAut.AutoSize = true;
            this.chkFiltrarDocAut.Location = new System.Drawing.Point(19, 9);
            this.chkFiltrarDocAut.Name = "chkFiltrarDocAut";
            this.chkFiltrarDocAut.Size = new System.Drawing.Size(51, 17);
            this.chkFiltrarDocAut.TabIndex = 20;
            this.chkFiltrarDocAut.Text = "Filtrar";
            this.chkFiltrarDocAut.UseVisualStyleBackColor = true;
            // 
            // dtpDocAutFecFin
            // 
            this.dtpDocAutFecFin.Enabled = false;
            this.dtpDocAutFecFin.Location = new System.Drawing.Point(503, 7);
            this.dtpDocAutFecFin.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpDocAutFecFin.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpDocAutFecFin.Name = "dtpDocAutFecFin";
            this.dtpDocAutFecFin.Size = new System.Drawing.Size(200, 20);
            this.dtpDocAutFecFin.TabIndex = 19;
            // 
            // dtpDocAutFecIni
            // 
            this.dtpDocAutFecIni.Enabled = false;
            this.dtpDocAutFecIni.Location = new System.Drawing.Point(209, 7);
            this.dtpDocAutFecIni.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpDocAutFecIni.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpDocAutFecIni.Name = "dtpDocAutFecIni";
            this.dtpDocAutFecIni.Size = new System.Drawing.Size(200, 20);
            this.dtpDocAutFecIni.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(435, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Fecha Final";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(138, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Fecha Inicio";
            // 
            // dgvDocAut
            // 
            this.dgvDocAut.AllowUserToAddRows = false;
            this.dgvDocAut.AllowUserToDeleteRows = false;
            this.dgvDocAut.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocAut.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDocAut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDocAut.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDocAut.Location = new System.Drawing.Point(6, 33);
            this.dgvDocAut.Name = "dgvDocAut";
            this.dgvDocAut.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocAut.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvDocAut.RowHeadersVisible = false;
            this.dgvDocAut.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocAut.Size = new System.Drawing.Size(845, 480);
            this.dgvDocAut.TabIndex = 5;
            // 
            // tabDocNoAuto
            // 
            this.tabDocNoAuto.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tabDocNoAuto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabDocNoAuto.Controls.Add(this.btnNoAutorizado);
            this.tabDocNoAuto.Controls.Add(this.chkFiltrarDocNoAut);
            this.tabDocNoAuto.Controls.Add(this.dtpDocNoAutFecFin);
            this.tabDocNoAuto.Controls.Add(this.dtpDocNoAutFecIni);
            this.tabDocNoAuto.Controls.Add(this.label1);
            this.tabDocNoAuto.Controls.Add(this.label2);
            this.tabDocNoAuto.Controls.Add(this.dgvDocNoAut);
            this.tabDocNoAuto.Location = new System.Drawing.Point(4, 22);
            this.tabDocNoAuto.Name = "tabDocNoAuto";
            this.tabDocNoAuto.Padding = new System.Windows.Forms.Padding(3);
            this.tabDocNoAuto.Size = new System.Drawing.Size(859, 519);
            this.tabDocNoAuto.TabIndex = 2;
            this.tabDocNoAuto.Text = "Documentos - No Autorizadas";
            // 
            // btnNoAutorizado
            // 
            this.btnNoAutorizado.BackColor = System.Drawing.Color.LimeGreen;
            this.btnNoAutorizado.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNoAutorizado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNoAutorizado.Location = new System.Drawing.Point(737, 2);
            this.btnNoAutorizado.Name = "btnNoAutorizado";
            this.btnNoAutorizado.Size = new System.Drawing.Size(114, 29);
            this.btnNoAutorizado.TabIndex = 22;
            this.btnNoAutorizado.Text = "Actualizar";
            this.btnNoAutorizado.UseVisualStyleBackColor = false;
            // 
            // chkFiltrarDocNoAut
            // 
            this.chkFiltrarDocNoAut.AutoSize = true;
            this.chkFiltrarDocNoAut.Location = new System.Drawing.Point(19, 9);
            this.chkFiltrarDocNoAut.Name = "chkFiltrarDocNoAut";
            this.chkFiltrarDocNoAut.Size = new System.Drawing.Size(51, 17);
            this.chkFiltrarDocNoAut.TabIndex = 20;
            this.chkFiltrarDocNoAut.Text = "Filtrar";
            this.chkFiltrarDocNoAut.UseVisualStyleBackColor = true;
            // 
            // dtpDocNoAutFecFin
            // 
            this.dtpDocNoAutFecFin.Enabled = false;
            this.dtpDocNoAutFecFin.Location = new System.Drawing.Point(504, 7);
            this.dtpDocNoAutFecFin.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpDocNoAutFecFin.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpDocNoAutFecFin.Name = "dtpDocNoAutFecFin";
            this.dtpDocNoAutFecFin.Size = new System.Drawing.Size(200, 20);
            this.dtpDocNoAutFecFin.TabIndex = 19;
            // 
            // dtpDocNoAutFecIni
            // 
            this.dtpDocNoAutFecIni.Enabled = false;
            this.dtpDocNoAutFecIni.Location = new System.Drawing.Point(209, 7);
            this.dtpDocNoAutFecIni.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpDocNoAutFecIni.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpDocNoAutFecIni.Name = "dtpDocNoAutFecIni";
            this.dtpDocNoAutFecIni.Size = new System.Drawing.Size(200, 20);
            this.dtpDocNoAutFecIni.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(436, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Fecha Final";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Fecha Inicio";
            // 
            // dgvDocNoAut
            // 
            this.dgvDocNoAut.AllowUserToAddRows = false;
            this.dgvDocNoAut.AllowUserToDeleteRows = false;
            this.dgvDocNoAut.AllowUserToResizeRows = false;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocNoAut.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvDocNoAut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDocNoAut.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvDocNoAut.Location = new System.Drawing.Point(6, 33);
            this.dgvDocNoAut.Name = "dgvDocNoAut";
            this.dgvDocNoAut.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocNoAut.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvDocNoAut.RowHeadersVisible = false;
            this.dgvDocNoAut.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocNoAut.Size = new System.Drawing.Size(845, 480);
            this.dgvDocNoAut.TabIndex = 8;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightBlue;
            this.menuStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GenerarXmlToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(891, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // GenerarXmlToolStripMenuItem
            // 
            this.GenerarXmlToolStripMenuItem.Enabled = false;
            this.GenerarXmlToolStripMenuItem.Name = "GenerarXmlToolStripMenuItem";
            this.GenerarXmlToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.GenerarXmlToolStripMenuItem.Text = "Generar Xml";
            this.GenerarXmlToolStripMenuItem.Visible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightBlue;
            this.statusStrip1.Location = new System.Drawing.Point(0, 574);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(891, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.Resize += new System.EventHandler(this.formTwitter_Resize);
            // 
            // mnuContextual
            // 
            this.mnuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMostrarAplicacion,
            this.mnuCerrarAplicacion});
            this.mnuContextual.Name = "mnuContextual";
            this.mnuContextual.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuContextual.Size = new System.Drawing.Size(116, 48);
            // 
            // mnuMostrarAplicacion
            // 
            this.mnuMostrarAplicacion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mnuMostrarAplicacion.Name = "mnuMostrarAplicacion";
            this.mnuMostrarAplicacion.Size = new System.Drawing.Size(115, 22);
            this.mnuMostrarAplicacion.Text = "Mostrar";
            this.mnuMostrarAplicacion.Click += new System.EventHandler(this.mnuMostrarAplicacion_Click_1);
            // 
            // mnuCerrarAplicacion
            // 
            this.mnuCerrarAplicacion.Name = "mnuCerrarAplicacion";
            this.mnuCerrarAplicacion.Size = new System.Drawing.Size(115, 22);
            this.mnuCerrarAplicacion.Text = "Cerrar";
            this.mnuCerrarAplicacion.Click += new System.EventHandler(this.mnuCerrarAplicacion_Click_1);
            // 
            // IconizarApp
            // 
            this.IconizarApp.ContextMenuStrip = this.mnuContextual;
            this.IconizarApp.Icon = ((System.Drawing.Icon)(resources.GetObject("IconizarApp.Icon")));
            this.IconizarApp.Text = "notifyIcon1";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(891, 596);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabFacturas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facturacion Electronica";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrincipal_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.Resize += new System.EventHandler(this.formTwitter_Resize);
            this.tabFacturas.ResumeLayout(false);
            this.tabDocNoEnv.ResumeLayout(false);
            this.tabDocNoEnv.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocFalt)).EndInit();
            this.tabDocNoProc.ResumeLayout(false);
            this.tabDocNoProc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocNoProc)).EndInit();
            this.tabDocAuto.ResumeLayout(false);
            this.tabDocAuto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocAut)).EndInit();
            this.tabDocNoAuto.ResumeLayout(false);
            this.tabDocNoAuto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocNoAut)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.mnuContextual.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabFacturas;
        private System.Windows.Forms.TabPage tabDocNoEnv;
        private System.Windows.Forms.DataGridView dgvDocFalt;
        private System.Windows.Forms.TabPage tabDocAuto;
        private System.Windows.Forms.DataGridView dgvDocAut;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ContextMenuStrip mnuContextual;
        private System.Windows.Forms.ToolStripMenuItem mnuMostrarAplicacion;
        private System.Windows.Forms.ToolStripMenuItem mnuCerrarAplicacion;
        private System.Windows.Forms.NotifyIcon IconizarApp;
        private System.Windows.Forms.TabPage tabDocNoAuto;
        private System.Windows.Forms.DataGridView dgvDocNoAut;
        private System.Windows.Forms.TabPage tabDocNoProc;
        private System.Windows.Forms.DataGridView dgvDocNoProc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDocNoEnvFecIni;
        private System.Windows.Forms.DateTimePicker dtpDocNoEnvFecFin;
        private System.Windows.Forms.DateTimePicker dtpDocNoProcFecFin;
        private System.Windows.Forms.DateTimePicker dtpDocNoProcFecIni;
        private System.Windows.Forms.DateTimePicker dtpDocAutFecFin;
        private System.Windows.Forms.DateTimePicker dtpDocAutFecIni;
        private System.Windows.Forms.DateTimePicker dtpDocNoAutFecFin;
        private System.Windows.Forms.DateTimePicker dtpDocNoAutFecIni;
        private System.Windows.Forms.CheckBox chkFiltrarDocNoEnv;
        private System.Windows.Forms.CheckBox chkFiltrarDocNoProc;
        private System.Windows.Forms.CheckBox chkFiltrarDocAut;
        private System.Windows.Forms.CheckBox chkFiltrarDocNoAut;
        private System.Windows.Forms.ToolStripMenuItem GenerarXmlToolStripMenuItem;
        private System.Windows.Forms.Button btnActualizaNoEnviados;
        private System.Windows.Forms.Button btnAutorizados;
        private System.Windows.Forms.Button btnNoAutorizado;
        private System.Windows.Forms.Button btnNoProcesados;
    }
}

