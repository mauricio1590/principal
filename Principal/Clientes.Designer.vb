<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Clientes
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtname = New System.Windows.Forms.TextBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.vecesDedo = New System.Windows.Forms.Label()
        Me.btncapturarhuellas = New System.Windows.Forms.Button()
        Me.btnIniciarCam = New System.Windows.Forms.Button()
        Me.btnCapturar = New System.Windows.Forms.Button()
        Me.txtcedula = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtapellido = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txttelefono = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtdireccion = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtFecha = New System.Windows.Forms.DateTimePicker()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btLimpiar = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.OpcionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarClientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsentimientoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.descargarUsuario = New System.Windows.Forms.ToolStripMenuItem()
        Me.FichaFacialToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FichaCorporalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FirmarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FirmaDelAcompañanteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lstNombres = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.PanelCabecera = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btncerrar = New System.Windows.Forms.Button()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtEps = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtEmergencia = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txttelefono2 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtRh = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtInstructor = New System.Windows.Forms.TextBox()
        Me.huella4 = New System.Windows.Forms.PictureBox()
        Me.huella3 = New System.Windows.Forms.PictureBox()
        Me.huella2 = New System.Windows.Forms.PictureBox()
        Me.huella1 = New System.Windows.Forms.PictureBox()
        Me.imagenHuella = New System.Windows.Forms.PictureBox()
        Me.imagenfoto = New System.Windows.Forms.PictureBox()
        Me.capturada = New System.Windows.Forms.PictureBox()
        Me.DRAJULIANAMENESESToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HIDROXIAPATITADECALCIOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.PanelCabecera.SuspendLayout()
        CType(Me.huella4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.huella3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.huella2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.huella1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imagenHuella, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imagenfoto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.capturada, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtname
        '
        Me.txtname.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtname.Location = New System.Drawing.Point(182, 101)
        Me.txtname.Name = "txtname"
        Me.txtname.Size = New System.Drawing.Size(212, 22)
        Me.txtname.TabIndex = 2
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Location = New System.Drawing.Point(38, 548)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(95, 23)
        Me.btnGuardar.TabIndex = 10
        Me.btnGuardar.Tag = "btnGuardar"
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'vecesDedo
        '
        Me.vecesDedo.AutoSize = True
        Me.vecesDedo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vecesDedo.Location = New System.Drawing.Point(645, 62)
        Me.vecesDedo.Name = "vecesDedo"
        Me.vecesDedo.Size = New System.Drawing.Size(0, 16)
        Me.vecesDedo.TabIndex = 5
        Me.vecesDedo.Visible = False
        '
        'btncapturarhuellas
        '
        Me.btncapturarhuellas.Location = New System.Drawing.Point(563, 57)
        Me.btncapturarhuellas.Name = "btncapturarhuellas"
        Me.btncapturarhuellas.Size = New System.Drawing.Size(76, 23)
        Me.btncapturarhuellas.TabIndex = 7
        Me.btncapturarhuellas.Tag = "btnGuardar"
        Me.btncapturarhuellas.Text = "Huella"
        Me.btncapturarhuellas.UseVisualStyleBackColor = True
        '
        'btnIniciarCam
        '
        Me.btnIniciarCam.Location = New System.Drawing.Point(564, 307)
        Me.btnIniciarCam.Name = "btnIniciarCam"
        Me.btnIniciarCam.Size = New System.Drawing.Size(75, 23)
        Me.btnIniciarCam.TabIndex = 8
        Me.btnIniciarCam.Text = "Iniciar Cam"
        Me.btnIniciarCam.UseVisualStyleBackColor = True
        '
        'btnCapturar
        '
        Me.btnCapturar.Location = New System.Drawing.Point(655, 307)
        Me.btnCapturar.Name = "btnCapturar"
        Me.btnCapturar.Size = New System.Drawing.Size(75, 23)
        Me.btnCapturar.TabIndex = 9
        Me.btnCapturar.Text = "Capturar"
        Me.btnCapturar.UseVisualStyleBackColor = True
        '
        'txtcedula
        '
        Me.txtcedula.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcedula.Location = New System.Drawing.Point(182, 66)
        Me.txtcedula.Name = "txtcedula"
        Me.txtcedula.Size = New System.Drawing.Size(212, 22)
        Me.txtcedula.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(53, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 16)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Cedula:"
        '
        'txtapellido
        '
        Me.txtapellido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtapellido.Location = New System.Drawing.Point(182, 147)
        Me.txtapellido.Name = "txtapellido"
        Me.txtapellido.Size = New System.Drawing.Size(212, 22)
        Me.txtapellido.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(53, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 16)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Nombres:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(53, 147)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 16)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Apellidos:"
        '
        'txttelefono
        '
        Me.txttelefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttelefono.Location = New System.Drawing.Point(182, 191)
        Me.txttelefono.Name = "txttelefono"
        Me.txttelefono.Size = New System.Drawing.Size(212, 22)
        Me.txttelefono.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(53, 191)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 16)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Telefono:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(53, 282)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 16)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Direccion:"
        '
        'txtdireccion
        '
        Me.txtdireccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdireccion.Location = New System.Drawing.Point(180, 276)
        Me.txtdireccion.Name = "txtdireccion"
        Me.txtdireccion.Size = New System.Drawing.Size(348, 22)
        Me.txtdireccion.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(53, 242)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 16)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "F Nacimiento:"
        '
        'dtFecha
        '
        Me.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFecha.Location = New System.Drawing.Point(182, 238)
        Me.dtFecha.Name = "dtFecha"
        Me.dtFecha.Size = New System.Drawing.Size(212, 20)
        Me.dtFecha.TabIndex = 5
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Location = New System.Drawing.Point(166, 548)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(95, 23)
        Me.btnBuscar.TabIndex = 26
        Me.btnBuscar.Tag = "btnGuardar"
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Enabled = False
        Me.btnModificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnModificar.Location = New System.Drawing.Point(299, 548)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(95, 23)
        Me.btnModificar.TabIndex = 0
        Me.btnModificar.Tag = "btnModificar"
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btLimpiar
        '
        Me.btLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btLimpiar.Location = New System.Drawing.Point(433, 548)
        Me.btLimpiar.Name = "btLimpiar"
        Me.btLimpiar.Size = New System.Drawing.Size(95, 23)
        Me.btLimpiar.TabIndex = 28
        Me.btLimpiar.Tag = "btnLimpiar"
        Me.btLimpiar.Text = "Limpiar"
        Me.btLimpiar.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpcionesToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(920, 24)
        Me.MenuStrip1.TabIndex = 29
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'OpcionesToolStripMenuItem
        '
        Me.OpcionesToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.OpcionesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BuscarClientesToolStripMenuItem, Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ConsentimientoToolStripMenuItem, Me.ToolStripMenuItem3, Me.descargarUsuario, Me.FichaFacialToolStripMenuItem, Me.FichaCorporalToolStripMenuItem, Me.FirmarToolStripMenuItem, Me.FirmaDelAcompañanteToolStripMenuItem, Me.DRAJULIANAMENESESToolStripMenuItem})
        Me.OpcionesToolStripMenuItem.Name = "OpcionesToolStripMenuItem"
        Me.OpcionesToolStripMenuItem.Size = New System.Drawing.Size(69, 20)
        Me.OpcionesToolStripMenuItem.Text = "Opciones"
        '
        'BuscarClientesToolStripMenuItem
        '
        Me.BuscarClientesToolStripMenuItem.Name = "BuscarClientesToolStripMenuItem"
        Me.BuscarClientesToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F3), System.Windows.Forms.Keys)
        Me.BuscarClientesToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.BuscarClientesToolStripMenuItem.Text = "Buscar clientes por nombre"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(260, 22)
        Me.ToolStripMenuItem1.Text = "Registre"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(260, 22)
        Me.ToolStripMenuItem2.Text = "Eliminar"
        '
        'ConsentimientoToolStripMenuItem
        '
        Me.ConsentimientoToolStripMenuItem.Name = "ConsentimientoToolStripMenuItem"
        Me.ConsentimientoToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.ConsentimientoToolStripMenuItem.Text = "Consentimiento"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(260, 22)
        Me.ToolStripMenuItem3.Text = "Sublir Usuario a la Nube"
        '
        'descargarUsuario
        '
        Me.descargarUsuario.Name = "descargarUsuario"
        Me.descargarUsuario.Size = New System.Drawing.Size(260, 22)
        Me.descargarUsuario.Text = "Descargar Usuario de la Nube"
        '
        'FichaFacialToolStripMenuItem
        '
        Me.FichaFacialToolStripMenuItem.Name = "FichaFacialToolStripMenuItem"
        Me.FichaFacialToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.FichaFacialToolStripMenuItem.Text = "Ficha Facial"
        '
        'FichaCorporalToolStripMenuItem
        '
        Me.FichaCorporalToolStripMenuItem.Name = "FichaCorporalToolStripMenuItem"
        Me.FichaCorporalToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.FichaCorporalToolStripMenuItem.Text = "Ficha Corporal"
        '
        'FirmarToolStripMenuItem
        '
        Me.FirmarToolStripMenuItem.Name = "FirmarToolStripMenuItem"
        Me.FirmarToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.FirmarToolStripMenuItem.Text = "Firma del Paciente "
        '
        'FirmaDelAcompañanteToolStripMenuItem
        '
        Me.FirmaDelAcompañanteToolStripMenuItem.Name = "FirmaDelAcompañanteToolStripMenuItem"
        Me.FirmaDelAcompañanteToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.FirmaDelAcompañanteToolStripMenuItem.Text = "Firma del Acompañante"
        '
        'lstNombres
        '
        Me.lstNombres.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lstNombres.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstNombres.FullRowSelect = True
        Me.lstNombres.GridLines = True
        Me.lstNombres.HideSelection = False
        Me.lstNombres.Location = New System.Drawing.Point(184, 123)
        Me.lstNombres.Name = "lstNombres"
        Me.lstNombres.Size = New System.Drawing.Size(346, 92)
        Me.lstNombres.TabIndex = 30
        Me.lstNombres.UseCompatibleStateImageBehavior = False
        Me.lstNombres.View = System.Windows.Forms.View.Details
        Me.lstNombres.Visible = False
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Nombre"
        Me.ColumnHeader1.Width = 203
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Apellido"
        Me.ColumnHeader2.Width = 254
        '
        'BackgroundWorker1
        '
        '
        'PanelCabecera
        '
        Me.PanelCabecera.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.PanelCabecera.Controls.Add(Me.Label7)
        Me.PanelCabecera.Controls.Add(Me.btncerrar)
        Me.PanelCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelCabecera.Location = New System.Drawing.Point(0, 24)
        Me.PanelCabecera.Name = "PanelCabecera"
        Me.PanelCabecera.Size = New System.Drawing.Size(920, 30)
        Me.PanelCabecera.TabIndex = 31
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label7.Location = New System.Drawing.Point(374, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(148, 16)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Registro de Clientes"
        '
        'btncerrar
        '
        Me.btncerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btncerrar.BackgroundImage = Global.Principal.My.Resources.Resources.cerrar
        Me.btncerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btncerrar.FlatAppearance.BorderSize = 0
        Me.btncerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btncerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.btncerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncerrar.Location = New System.Drawing.Point(875, 0)
        Me.btncerrar.Name = "btncerrar"
        Me.btncerrar.Size = New System.Drawing.Size(30, 30)
        Me.btncerrar.TabIndex = 0
        Me.btncerrar.UseVisualStyleBackColor = True
        '
        'txtEmail
        '
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(180, 307)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(348, 22)
        Me.txtEmail.TabIndex = 33
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(53, 311)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 16)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "Email:"
        '
        'txtEps
        '
        Me.txtEps.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEps.Location = New System.Drawing.Point(180, 350)
        Me.txtEps.Name = "txtEps"
        Me.txtEps.Size = New System.Drawing.Size(348, 22)
        Me.txtEps.TabIndex = 35
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(53, 353)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 16)
        Me.Label9.TabIndex = 36
        Me.Label9.Text = "EPS:"
        '
        'txtEmergencia
        '
        Me.txtEmergencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmergencia.Location = New System.Drawing.Point(180, 385)
        Me.txtEmergencia.Name = "txtEmergencia"
        Me.txtEmergencia.Size = New System.Drawing.Size(348, 22)
        Me.txtEmergencia.TabIndex = 37
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(48, 391)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(107, 16)
        Me.Label10.TabIndex = 38
        Me.Label10.Text = "C. emergencia"
        '
        'txttelefono2
        '
        Me.txttelefono2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttelefono2.Location = New System.Drawing.Point(180, 427)
        Me.txttelefono2.Name = "txttelefono2"
        Me.txttelefono2.Size = New System.Drawing.Size(348, 22)
        Me.txttelefono2.TabIndex = 39
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(49, 433)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(106, 16)
        Me.Label11.TabIndex = 40
        Me.Label11.Text = "Telefono cont:"
        '
        'txtRh
        '
        Me.txtRh.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRh.Location = New System.Drawing.Point(180, 466)
        Me.txtRh.Name = "txtRh"
        Me.txtRh.Size = New System.Drawing.Size(348, 22)
        Me.txtRh.TabIndex = 41
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(53, 472)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(33, 16)
        Me.Label12.TabIndex = 42
        Me.Label12.Text = "RH:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(53, 510)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(66, 16)
        Me.Label13.TabIndex = 42
        Me.Label13.Text = "Intructor:"
        '
        'txtInstructor
        '
        Me.txtInstructor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInstructor.Location = New System.Drawing.Point(180, 504)
        Me.txtInstructor.Name = "txtInstructor"
        Me.txtInstructor.Size = New System.Drawing.Size(348, 22)
        Me.txtInstructor.TabIndex = 41
        '
        'huella4
        '
        Me.huella4.Location = New System.Drawing.Point(836, 267)
        Me.huella4.Name = "huella4"
        Me.huella4.Size = New System.Drawing.Size(33, 31)
        Me.huella4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.huella4.TabIndex = 43
        Me.huella4.TabStop = False
        '
        'huella3
        '
        Me.huella3.Location = New System.Drawing.Point(836, 205)
        Me.huella3.Name = "huella3"
        Me.huella3.Size = New System.Drawing.Size(33, 31)
        Me.huella3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.huella3.TabIndex = 43
        Me.huella3.TabStop = False
        '
        'huella2
        '
        Me.huella2.Location = New System.Drawing.Point(836, 145)
        Me.huella2.Name = "huella2"
        Me.huella2.Size = New System.Drawing.Size(33, 31)
        Me.huella2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.huella2.TabIndex = 43
        Me.huella2.TabStop = False
        '
        'huella1
        '
        Me.huella1.Location = New System.Drawing.Point(836, 87)
        Me.huella1.Name = "huella1"
        Me.huella1.Size = New System.Drawing.Size(33, 31)
        Me.huella1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.huella1.TabIndex = 43
        Me.huella1.TabStop = False
        '
        'imagenHuella
        '
        Me.imagenHuella.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.imagenHuella.Location = New System.Drawing.Point(564, 87)
        Me.imagenHuella.Name = "imagenHuella"
        Me.imagenHuella.Size = New System.Drawing.Size(266, 211)
        Me.imagenHuella.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imagenHuella.TabIndex = 4
        Me.imagenHuella.TabStop = False
        '
        'imagenfoto
        '
        Me.imagenfoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.imagenfoto.Location = New System.Drawing.Point(563, 330)
        Me.imagenfoto.Name = "imagenfoto"
        Me.imagenfoto.Size = New System.Drawing.Size(267, 205)
        Me.imagenfoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imagenfoto.TabIndex = 13
        Me.imagenfoto.TabStop = False
        '
        'capturada
        '
        Me.capturada.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.capturada.Location = New System.Drawing.Point(563, 329)
        Me.capturada.Name = "capturada"
        Me.capturada.Size = New System.Drawing.Size(267, 205)
        Me.capturada.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.capturada.TabIndex = 32
        Me.capturada.TabStop = False
        '
        'DRAJULIANAMENESESToolStripMenuItem
        '
        Me.DRAJULIANAMENESESToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HIDROXIAPATITADECALCIOToolStripMenuItem})
        Me.DRAJULIANAMENESESToolStripMenuItem.Name = "DRAJULIANAMENESESToolStripMenuItem"
        Me.DRAJULIANAMENESESToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.DRAJULIANAMENESESToolStripMenuItem.Text = "DRA JULIANA MENESES"
        '
        'HIDROXIAPATITADECALCIOToolStripMenuItem
        '
        Me.HIDROXIAPATITADECALCIOToolStripMenuItem.Name = "HIDROXIAPATITADECALCIOToolStripMenuItem"
        Me.HIDROXIAPATITADECALCIOToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.HIDROXIAPATITADECALCIOToolStripMenuItem.Text = "HIDROXIAPATITA DE CALCIO"
        '
        'Clientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.HighlightText
        Me.ClientSize = New System.Drawing.Size(920, 603)
        Me.Controls.Add(Me.huella4)
        Me.Controls.Add(Me.huella3)
        Me.Controls.Add(Me.huella2)
        Me.Controls.Add(Me.huella1)
        Me.Controls.Add(Me.txtInstructor)
        Me.Controls.Add(Me.txtRh)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txttelefono2)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtEmergencia)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtEps)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.PanelCabecera)
        Me.Controls.Add(Me.btLimpiar)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.dtFecha)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtdireccion)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txttelefono)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtapellido)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtcedula)
        Me.Controls.Add(Me.btnCapturar)
        Me.Controls.Add(Me.btnIniciarCam)
        Me.Controls.Add(Me.btncapturarhuellas)
        Me.Controls.Add(Me.txtname)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.vecesDedo)
        Me.Controls.Add(Me.imagenHuella)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.lstNombres)
        Me.Controls.Add(Me.imagenfoto)
        Me.Controls.Add(Me.capturada)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Clientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clientes"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.PanelCabecera.ResumeLayout(False)
        Me.PanelCabecera.PerformLayout()
        CType(Me.huella4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.huella3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.huella2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.huella1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imagenHuella, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imagenfoto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.capturada, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtname As System.Windows.Forms.TextBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents vecesDedo As System.Windows.Forms.Label
    Friend WithEvents btncapturarhuellas As System.Windows.Forms.Button
    Friend WithEvents btnIniciarCam As System.Windows.Forms.Button
    Friend WithEvents btnCapturar As System.Windows.Forms.Button
    Friend WithEvents imagenHuella As System.Windows.Forms.PictureBox
    Friend WithEvents imagenfoto As System.Windows.Forms.PictureBox
    Friend WithEvents txtcedula As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtapellido As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txttelefono As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtdireccion As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents btLimpiar As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents OpcionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarClientesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lstNombres As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents PanelCabecera As System.Windows.Forms.Panel
    Friend WithEvents btncerrar As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents descargarUsuario As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents capturada As System.Windows.Forms.PictureBox
    Friend WithEvents ConsentimientoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtEps As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtEmergencia As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txttelefono2 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtRh As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As Label
    Friend WithEvents txtInstructor As TextBox
    Friend WithEvents huella1 As PictureBox
    Friend WithEvents huella2 As PictureBox
    Friend WithEvents huella3 As PictureBox
    Friend WithEvents huella4 As PictureBox
    Friend WithEvents FichaFacialToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FichaCorporalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FirmarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FirmaDelAcompañanteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DRAJULIANAMENESESToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HIDROXIAPATITADECALCIOToolStripMenuItem As ToolStripMenuItem
End Class
