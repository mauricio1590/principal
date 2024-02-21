<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Empleados
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
        Me.btLimpiar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btncapturarhuellas = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.imagenHuella = New System.Windows.Forms.PictureBox()
        Me.vecesDedo = New System.Windows.Forms.Label()
        Me.WebCam1 = New WebCAM.WebCam()
        Me.imagenfoto = New System.Windows.Forms.PictureBox()
        Me.btnCapturar = New System.Windows.Forms.Button()
        Me.btnIniciarCam = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txttelefono = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtapellido = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtcedula = New System.Windows.Forms.TextBox()
        Me.txtname = New System.Windows.Forms.TextBox()
        Me.lstNombres = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.OpcionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarEmpleadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btncerrar = New System.Windows.Forms.Button()
        Me.PanelCabecera = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.huella4 = New System.Windows.Forms.PictureBox()
        Me.huella3 = New System.Windows.Forms.PictureBox()
        Me.huella2 = New System.Windows.Forms.PictureBox()
        Me.huella1 = New System.Windows.Forms.PictureBox()
        CType(Me.imagenHuella, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imagenfoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.PanelCabecera.SuspendLayout()
        CType(Me.huella4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.huella3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.huella2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.huella1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btLimpiar
        '
        Me.btLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btLimpiar.Location = New System.Drawing.Point(401, 361)
        Me.btLimpiar.Name = "btLimpiar"
        Me.btLimpiar.Size = New System.Drawing.Size(95, 23)
        Me.btLimpiar.TabIndex = 34
        Me.btLimpiar.Tag = "btnLimpiar"
        Me.btLimpiar.Text = "Limpiar"
        Me.btLimpiar.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Enabled = False
        Me.btnModificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnModificar.Location = New System.Drawing.Point(267, 361)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(95, 23)
        Me.btnModificar.TabIndex = 33
        Me.btnModificar.Tag = "btnModificar"
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Location = New System.Drawing.Point(134, 361)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(95, 23)
        Me.btnBuscar.TabIndex = 32
        Me.btnBuscar.Tag = "btnGuardar"
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btncapturarhuellas
        '
        Me.btncapturarhuellas.Location = New System.Drawing.Point(523, 55)
        Me.btncapturarhuellas.Name = "btncapturarhuellas"
        Me.btncapturarhuellas.Size = New System.Drawing.Size(76, 23)
        Me.btncapturarhuellas.TabIndex = 30
        Me.btncapturarhuellas.Tag = "btnGuardar"
        Me.btncapturarhuellas.Text = "Huella"
        Me.btncapturarhuellas.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Location = New System.Drawing.Point(6, 361)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(95, 23)
        Me.btnGuardar.TabIndex = 31
        Me.btnGuardar.Tag = "btnGuardar"
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'imagenHuella
        '
        Me.imagenHuella.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.imagenHuella.Location = New System.Drawing.Point(525, 82)
        Me.imagenHuella.Name = "imagenHuella"
        Me.imagenHuella.Size = New System.Drawing.Size(235, 197)
        Me.imagenHuella.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imagenHuella.TabIndex = 29
        Me.imagenHuella.TabStop = False
        '
        'vecesDedo
        '
        Me.vecesDedo.AutoSize = True
        Me.vecesDedo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vecesDedo.Location = New System.Drawing.Point(604, 59)
        Me.vecesDedo.Name = "vecesDedo"
        Me.vecesDedo.Size = New System.Drawing.Size(0, 16)
        Me.vecesDedo.TabIndex = 35
        Me.vecesDedo.Visible = False
        '
        'WebCam1
        '
        Me.WebCam1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.WebCam1.Imagen = Nothing
        Me.WebCam1.Location = New System.Drawing.Point(523, 307)
        Me.WebCam1.MilisegundosCaptura = 100
        Me.WebCam1.Name = "WebCam1"
        Me.WebCam1.Size = New System.Drawing.Size(237, 194)
        Me.WebCam1.TabIndex = 36
        '
        'imagenfoto
        '
        Me.imagenfoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.imagenfoto.Location = New System.Drawing.Point(522, 307)
        Me.imagenfoto.Name = "imagenfoto"
        Me.imagenfoto.Size = New System.Drawing.Size(221, 175)
        Me.imagenfoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imagenfoto.TabIndex = 37
        Me.imagenfoto.TabStop = False
        '
        'btnCapturar
        '
        Me.btnCapturar.Location = New System.Drawing.Point(613, 282)
        Me.btnCapturar.Name = "btnCapturar"
        Me.btnCapturar.Size = New System.Drawing.Size(75, 23)
        Me.btnCapturar.TabIndex = 39
        Me.btnCapturar.Text = "Capturar"
        Me.btnCapturar.UseVisualStyleBackColor = True
        '
        'btnIniciarCam
        '
        Me.btnIniciarCam.Location = New System.Drawing.Point(523, 282)
        Me.btnIniciarCam.Name = "btnIniciarCam"
        Me.btnIniciarCam.Size = New System.Drawing.Size(75, 23)
        Me.btnIniciarCam.TabIndex = 38
        Me.btnIniciarCam.Text = "Iniciar Cam"
        Me.btnIniciarCam.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(25, 230)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 16)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "Telefono:"
        '
        'txttelefono
        '
        Me.txttelefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttelefono.Location = New System.Drawing.Point(150, 227)
        Me.txttelefono.Name = "txttelefono"
        Me.txttelefono.Size = New System.Drawing.Size(212, 22)
        Me.txttelefono.TabIndex = 43
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(25, 176)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 16)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Apellidos:"
        '
        'txtapellido
        '
        Me.txtapellido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtapellido.Location = New System.Drawing.Point(150, 170)
        Me.txtapellido.Name = "txtapellido"
        Me.txtapellido.Size = New System.Drawing.Size(212, 22)
        Me.txtapellido.TabIndex = 42
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(25, 127)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 16)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "Nombres:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(29, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 16)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Cedula:"
        '
        'txtcedula
        '
        Me.txtcedula.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcedula.Location = New System.Drawing.Point(148, 85)
        Me.txtcedula.Name = "txtcedula"
        Me.txtcedula.Size = New System.Drawing.Size(212, 22)
        Me.txtcedula.TabIndex = 40
        '
        'txtname
        '
        Me.txtname.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtname.Location = New System.Drawing.Point(150, 124)
        Me.txtname.Name = "txtname"
        Me.txtname.Size = New System.Drawing.Size(212, 22)
        Me.txtname.TabIndex = 41
        '
        'lstNombres
        '
        Me.lstNombres.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lstNombres.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstNombres.FullRowSelect = True
        Me.lstNombres.GridLines = True
        Me.lstNombres.HideSelection = False
        Me.lstNombres.Location = New System.Drawing.Point(150, 147)
        Me.lstNombres.Name = "lstNombres"
        Me.lstNombres.Size = New System.Drawing.Size(210, 97)
        Me.lstNombres.TabIndex = 48
        Me.lstNombres.UseCompatibleStateImageBehavior = False
        Me.lstNombres.View = System.Windows.Forms.View.Details
        Me.lstNombres.Visible = False
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Nombre"
        Me.ColumnHeader1.Width = 90
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Apellido"
        Me.ColumnHeader2.Width = 90
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpcionesToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(841, 24)
        Me.MenuStrip1.TabIndex = 49
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'OpcionesToolStripMenuItem
        '
        Me.OpcionesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BuscarEmpleadoToolStripMenuItem})
        Me.OpcionesToolStripMenuItem.Name = "OpcionesToolStripMenuItem"
        Me.OpcionesToolStripMenuItem.Size = New System.Drawing.Size(69, 20)
        Me.OpcionesToolStripMenuItem.Text = "Opciones"
        '
        'BuscarEmpleadoToolStripMenuItem
        '
        Me.BuscarEmpleadoToolStripMenuItem.Name = "BuscarEmpleadoToolStripMenuItem"
        Me.BuscarEmpleadoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.BuscarEmpleadoToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.BuscarEmpleadoToolStripMenuItem.Text = "Buscar Empleado"
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
        Me.btncerrar.Location = New System.Drawing.Point(796, 0)
        Me.btncerrar.Name = "btncerrar"
        Me.btncerrar.Size = New System.Drawing.Size(30, 30)
        Me.btncerrar.TabIndex = 0
        Me.btncerrar.UseVisualStyleBackColor = True
        '
        'PanelCabecera
        '
        Me.PanelCabecera.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.PanelCabecera.Controls.Add(Me.Label5)
        Me.PanelCabecera.Controls.Add(Me.btncerrar)
        Me.PanelCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelCabecera.Location = New System.Drawing.Point(0, 24)
        Me.PanelCabecera.Name = "PanelCabecera"
        Me.PanelCabecera.Size = New System.Drawing.Size(841, 30)
        Me.PanelCabecera.TabIndex = 50
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label5.Location = New System.Drawing.Point(330, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(171, 16)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Registro de Empleados"
        '
        'huella4
        '
        Me.huella4.Location = New System.Drawing.Point(762, 240)
        Me.huella4.Name = "huella4"
        Me.huella4.Size = New System.Drawing.Size(33, 31)
        Me.huella4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.huella4.TabIndex = 51
        Me.huella4.TabStop = False
        '
        'huella3
        '
        Me.huella3.Location = New System.Drawing.Point(762, 178)
        Me.huella3.Name = "huella3"
        Me.huella3.Size = New System.Drawing.Size(33, 31)
        Me.huella3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.huella3.TabIndex = 52
        Me.huella3.TabStop = False
        '
        'huella2
        '
        Me.huella2.Location = New System.Drawing.Point(762, 118)
        Me.huella2.Name = "huella2"
        Me.huella2.Size = New System.Drawing.Size(33, 31)
        Me.huella2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.huella2.TabIndex = 53
        Me.huella2.TabStop = False
        '
        'huella1
        '
        Me.huella1.Location = New System.Drawing.Point(762, 60)
        Me.huella1.Name = "huella1"
        Me.huella1.Size = New System.Drawing.Size(33, 31)
        Me.huella1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.huella1.TabIndex = 54
        Me.huella1.TabStop = False
        '
        'Empleados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(841, 522)
        Me.Controls.Add(Me.huella4)
        Me.Controls.Add(Me.huella3)
        Me.Controls.Add(Me.huella2)
        Me.Controls.Add(Me.huella1)
        Me.Controls.Add(Me.PanelCabecera)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txttelefono)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtapellido)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtcedula)
        Me.Controls.Add(Me.txtname)
        Me.Controls.Add(Me.btnCapturar)
        Me.Controls.Add(Me.btnIniciarCam)
        Me.Controls.Add(Me.WebCam1)
        Me.Controls.Add(Me.imagenfoto)
        Me.Controls.Add(Me.vecesDedo)
        Me.Controls.Add(Me.btLimpiar)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.btncapturarhuellas)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.imagenHuella)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.lstNombres)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Empleados"
        Me.Text = "Empleados"
        CType(Me.imagenHuella, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imagenfoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.PanelCabecera.ResumeLayout(False)
        Me.PanelCabecera.PerformLayout()
        CType(Me.huella4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.huella3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.huella2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.huella1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btncapturarhuellas As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents imagenHuella As System.Windows.Forms.PictureBox
    Friend WithEvents vecesDedo As System.Windows.Forms.Label
    Friend WithEvents WebCam1 As WebCAM.WebCam
    Friend WithEvents imagenfoto As System.Windows.Forms.PictureBox
    Friend WithEvents btnCapturar As System.Windows.Forms.Button
    Friend WithEvents btnIniciarCam As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txttelefono As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtapellido As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtcedula As System.Windows.Forms.TextBox
    Friend WithEvents txtname As System.Windows.Forms.TextBox
    Friend WithEvents lstNombres As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents OpcionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarEmpleadoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btncerrar As System.Windows.Forms.Button
    Friend WithEvents PanelCabecera As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents huella4 As PictureBox
    Friend WithEvents huella3 As PictureBox
    Friend WithEvents huella2 As PictureBox
    Friend WithEvents huella1 As PictureBox
End Class
