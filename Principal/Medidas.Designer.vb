<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Medidas
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btncerrar = New System.Windows.Forms.Button()
        Me.PanelCabecera = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblEstato = New System.Windows.Forms.Label()
        Me.txtFc = New System.Windows.Forms.TextBox()
        Me.txtGrasa = New System.Windows.Forms.TextBox()
        Me.txtEdad = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtImc = New System.Windows.Forms.TextBox()
        Me.txtTalla = New System.Windows.Forms.TextBox()
        Me.txtPeso = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.rdMasculino = New System.Windows.Forms.RadioButton()
        Me.rdFemenino = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtPiernaizq = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtPiernader = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtBrazoder = New System.Windows.Forms.TextBox()
        Me.txtBrazoizq = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtPechoespalda = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtCuello = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtPectoral = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtEspalda = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtCintura = New System.Windows.Forms.TextBox()
        Me.txtGluteo = New System.Windows.Forms.TextBox()
        Me.txtMuslo = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtpantorrilla = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lstNombres = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.OpcionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarEmpleadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtRestricciones = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.lstEstados = New System.Windows.Forms.ListView()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtTriceps = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtSubescapula = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtSuprailiaca = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtBiceps = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.PanelCabecera.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label5.Location = New System.Drawing.Point(347, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(159, 16)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Registro De Medidas:"
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
        Me.btncerrar.Location = New System.Drawing.Point(835, 0)
        Me.btncerrar.Name = "btncerrar"
        Me.btncerrar.Size = New System.Drawing.Size(30, 30)
        Me.btncerrar.TabIndex = 0
        Me.btncerrar.UseVisualStyleBackColor = True
        '
        'PanelCabecera
        '
        Me.PanelCabecera.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.PanelCabecera.Controls.Add(Me.Label5)
        Me.PanelCabecera.Controls.Add(Me.Label1)
        Me.PanelCabecera.Controls.Add(Me.btncerrar)
        Me.PanelCabecera.Location = New System.Drawing.Point(0, 27)
        Me.PanelCabecera.Name = "PanelCabecera"
        Me.PanelCabecera.Size = New System.Drawing.Size(871, 30)
        Me.PanelCabecera.TabIndex = 33
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(347, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "INGRESO DE GASTOS"
        '
        'Panel1
        '
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.lblEstato)
        Me.Panel1.Controls.Add(Me.txtFc)
        Me.Panel1.Controls.Add(Me.txtGrasa)
        Me.Panel1.Controls.Add(Me.txtEdad)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.txtImc)
        Me.Panel1.Controls.Add(Me.txtTalla)
        Me.Panel1.Controls.Add(Me.txtPeso)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.rdMasculino)
        Me.Panel1.Controls.Add(Me.rdFemenino)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Location = New System.Drawing.Point(38, 125)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(358, 173)
        Me.Panel1.TabIndex = 34
        '
        'lblEstato
        '
        Me.lblEstato.AutoSize = True
        Me.lblEstato.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstato.ForeColor = System.Drawing.Color.Red
        Me.lblEstato.Location = New System.Drawing.Point(192, 14)
        Me.lblEstato.Name = "lblEstato"
        Me.lblEstato.Size = New System.Drawing.Size(0, 15)
        Me.lblEstato.TabIndex = 56
        '
        'txtFc
        '
        Me.txtFc.Location = New System.Drawing.Point(272, 132)
        Me.txtFc.Name = "txtFc"
        Me.txtFc.Size = New System.Drawing.Size(63, 20)
        Me.txtFc.TabIndex = 55
        Me.txtFc.Text = "0"
        '
        'txtGrasa
        '
        Me.txtGrasa.Location = New System.Drawing.Point(272, 87)
        Me.txtGrasa.Name = "txtGrasa"
        Me.txtGrasa.Size = New System.Drawing.Size(63, 20)
        Me.txtGrasa.TabIndex = 54
        Me.txtGrasa.Text = "0"
        '
        'txtEdad
        '
        Me.txtEdad.Location = New System.Drawing.Point(93, 132)
        Me.txtEdad.Name = "txtEdad"
        Me.txtEdad.Size = New System.Drawing.Size(63, 20)
        Me.txtEdad.TabIndex = 53
        Me.txtEdad.Text = "0"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(192, 133)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(61, 15)
        Me.Label10.TabIndex = 52
        Me.Label10.Text = "F.C x Min:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(192, 92)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(57, 15)
        Me.Label11.TabIndex = 51
        Me.Label11.Text = "% Grasa:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(13, 133)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(39, 15)
        Me.Label12.TabIndex = 50
        Me.Label12.Text = "Edad:"
        '
        'txtImc
        '
        Me.txtImc.Enabled = False
        Me.txtImc.Location = New System.Drawing.Point(272, 47)
        Me.txtImc.Name = "txtImc"
        Me.txtImc.Size = New System.Drawing.Size(63, 20)
        Me.txtImc.TabIndex = 49
        Me.txtImc.Text = "0"
        '
        'txtTalla
        '
        Me.txtTalla.Location = New System.Drawing.Point(93, 91)
        Me.txtTalla.Name = "txtTalla"
        Me.txtTalla.Size = New System.Drawing.Size(63, 20)
        Me.txtTalla.TabIndex = 48
        Me.txtTalla.Text = "0"
        '
        'txtPeso
        '
        Me.txtPeso.Location = New System.Drawing.Point(93, 47)
        Me.txtPeso.Name = "txtPeso"
        Me.txtPeso.Size = New System.Drawing.Size(63, 20)
        Me.txtPeso.TabIndex = 47
        Me.txtPeso.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(192, 49)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 15)
        Me.Label9.TabIndex = 46
        Me.Label9.Text = "IMC:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(13, 92)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 15)
        Me.Label8.TabIndex = 45
        Me.Label8.Text = "Talla cm:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(13, 49)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 15)
        Me.Label7.TabIndex = 44
        Me.Label7.Text = "Peso kg:"
        '
        'rdMasculino
        '
        Me.rdMasculino.AutoSize = True
        Me.rdMasculino.Location = New System.Drawing.Point(93, 12)
        Me.rdMasculino.Name = "rdMasculino"
        Me.rdMasculino.Size = New System.Drawing.Size(34, 17)
        Me.rdMasculino.TabIndex = 43
        Me.rdMasculino.TabStop = True
        Me.rdMasculino.Text = "M"
        Me.rdMasculino.UseVisualStyleBackColor = True
        '
        'rdFemenino
        '
        Me.rdFemenino.AutoSize = True
        Me.rdFemenino.Location = New System.Drawing.Point(55, 12)
        Me.rdFemenino.Name = "rdFemenino"
        Me.rdFemenino.Size = New System.Drawing.Size(31, 17)
        Me.rdFemenino.TabIndex = 42
        Me.rdFemenino.TabStop = True
        Me.rdFemenino.Text = "F"
        Me.rdFemenino.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(13, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 15)
        Me.Label6.TabIndex = 41
        Me.Label6.Text = "sexo:"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.txtPiernaizq)
        Me.Panel2.Controls.Add(Me.Label26)
        Me.Panel2.Controls.Add(Me.txtPiernader)
        Me.Panel2.Controls.Add(Me.Label27)
        Me.Panel2.Controls.Add(Me.txtBrazoder)
        Me.Panel2.Controls.Add(Me.txtBrazoizq)
        Me.Panel2.Controls.Add(Me.Label25)
        Me.Panel2.Controls.Add(Me.txtPechoespalda)
        Me.Panel2.Controls.Add(Me.Label18)
        Me.Panel2.Controls.Add(Me.Label24)
        Me.Panel2.Controls.Add(Me.txtCuello)
        Me.Panel2.Controls.Add(Me.Label23)
        Me.Panel2.Controls.Add(Me.txtPectoral)
        Me.Panel2.Controls.Add(Me.Label19)
        Me.Panel2.Controls.Add(Me.txtEspalda)
        Me.Panel2.Controls.Add(Me.Label20)
        Me.Panel2.Controls.Add(Me.txtCintura)
        Me.Panel2.Controls.Add(Me.txtGluteo)
        Me.Panel2.Controls.Add(Me.txtMuslo)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.txtpantorrilla)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Location = New System.Drawing.Point(479, 84)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(370, 225)
        Me.Panel2.TabIndex = 35
        '
        'txtPiernaizq
        '
        Me.txtPiernaizq.Location = New System.Drawing.Point(288, 157)
        Me.txtPiernaizq.Name = "txtPiernaizq"
        Me.txtPiernaizq.Size = New System.Drawing.Size(63, 20)
        Me.txtPiernaizq.TabIndex = 72
        Me.txtPiernaizq.Text = "0"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(190, 160)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(65, 15)
        Me.Label26.TabIndex = 71
        Me.Label26.Text = "Pierna Izq:"
        '
        'txtPiernader
        '
        Me.txtPiernader.Location = New System.Drawing.Point(109, 155)
        Me.txtPiernader.Name = "txtPiernader"
        Me.txtPiernader.Size = New System.Drawing.Size(63, 20)
        Me.txtPiernader.TabIndex = 70
        Me.txtPiernader.Text = "0"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(12, 156)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(69, 15)
        Me.Label27.TabIndex = 69
        Me.Label27.Text = "Pierna Der:"
        '
        'txtBrazoder
        '
        Me.txtBrazoder.Location = New System.Drawing.Point(110, 117)
        Me.txtBrazoder.Name = "txtBrazoder"
        Me.txtBrazoder.Size = New System.Drawing.Size(63, 20)
        Me.txtBrazoder.TabIndex = 68
        Me.txtBrazoder.Text = "0"
        '
        'txtBrazoizq
        '
        Me.txtBrazoizq.Location = New System.Drawing.Point(288, 117)
        Me.txtBrazoizq.Name = "txtBrazoizq"
        Me.txtBrazoizq.Size = New System.Drawing.Size(63, 20)
        Me.txtBrazoizq.TabIndex = 62
        Me.txtBrazoizq.Text = "0"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(12, 118)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(65, 15)
        Me.Label25.TabIndex = 67
        Me.Label25.Text = "Brazo Der:"
        '
        'txtPechoespalda
        '
        Me.txtPechoespalda.Location = New System.Drawing.Point(288, 14)
        Me.txtPechoespalda.Name = "txtPechoespalda"
        Me.txtPechoespalda.Size = New System.Drawing.Size(63, 20)
        Me.txtPechoespalda.TabIndex = 66
        Me.txtPechoespalda.Text = "0"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(194, 118)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(61, 15)
        Me.Label18.TabIndex = 58
        Me.Label18.Text = "Brazo Izq:"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(190, 16)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(94, 15)
        Me.Label24.TabIndex = 65
        Me.Label24.Text = "Pecho-Espalda:"
        '
        'txtCuello
        '
        Me.txtCuello.Location = New System.Drawing.Point(110, 11)
        Me.txtCuello.Name = "txtCuello"
        Me.txtCuello.Size = New System.Drawing.Size(63, 20)
        Me.txtCuello.TabIndex = 64
        Me.txtCuello.Text = "0"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(12, 13)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(45, 15)
        Me.Label23.TabIndex = 63
        Me.Label23.Text = "Cuello:"
        '
        'txtPectoral
        '
        Me.txtPectoral.Location = New System.Drawing.Point(288, 45)
        Me.txtPectoral.Name = "txtPectoral"
        Me.txtPectoral.Size = New System.Drawing.Size(63, 20)
        Me.txtPectoral.TabIndex = 60
        Me.txtPectoral.Text = "0"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(190, 50)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(55, 15)
        Me.Label19.TabIndex = 57
        Me.Label19.Text = "Pectoral:"
        '
        'txtEspalda
        '
        Me.txtEspalda.Location = New System.Drawing.Point(111, 45)
        Me.txtEspalda.Name = "txtEspalda"
        Me.txtEspalda.Size = New System.Drawing.Size(63, 20)
        Me.txtEspalda.TabIndex = 56
        Me.txtEspalda.Text = "0"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(13, 47)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(55, 15)
        Me.Label20.TabIndex = 55
        Me.Label20.Text = "Espalda:"
        '
        'txtCintura
        '
        Me.txtCintura.Location = New System.Drawing.Point(110, 80)
        Me.txtCintura.Name = "txtCintura"
        Me.txtCintura.Size = New System.Drawing.Size(63, 20)
        Me.txtCintura.TabIndex = 54
        Me.txtCintura.Text = "0"
        '
        'txtGluteo
        '
        Me.txtGluteo.Location = New System.Drawing.Point(288, 80)
        Me.txtGluteo.Name = "txtGluteo"
        Me.txtGluteo.Size = New System.Drawing.Size(63, 20)
        Me.txtGluteo.TabIndex = 54
        Me.txtGluteo.Text = "0"
        '
        'txtMuslo
        '
        Me.txtMuslo.Location = New System.Drawing.Point(288, 191)
        Me.txtMuslo.Name = "txtMuslo"
        Me.txtMuslo.Size = New System.Drawing.Size(63, 20)
        Me.txtMuslo.TabIndex = 53
        Me.txtMuslo.Text = "0"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(13, 81)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(49, 15)
        Me.Label16.TabIndex = 52
        Me.Label16.Text = "Cintura:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(193, 81)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(46, 15)
        Me.Label15.TabIndex = 51
        Me.Label15.Text = "Gluteo:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(193, 192)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(82, 15)
        Me.Label14.TabIndex = 50
        Me.Label14.Text = "Muslo medio:"
        '
        'txtpantorrilla
        '
        Me.txtpantorrilla.Location = New System.Drawing.Point(111, 192)
        Me.txtpantorrilla.Name = "txtpantorrilla"
        Me.txtpantorrilla.Size = New System.Drawing.Size(63, 20)
        Me.txtpantorrilla.TabIndex = 49
        Me.txtpantorrilla.Text = "0"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(12, 192)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(66, 15)
        Me.Label13.TabIndex = 48
        Me.Label13.Text = "Pantorrilla:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(35, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 16)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Cliente:"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(121, 62)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(275, 20)
        Me.txtName.TabIndex = 37
        '
        'lstNombres
        '
        Me.lstNombres.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lstNombres.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstNombres.FullRowSelect = True
        Me.lstNombres.GridLines = True
        Me.lstNombres.HideSelection = False
        Me.lstNombres.Location = New System.Drawing.Point(121, 84)
        Me.lstNombres.Name = "lstNombres"
        Me.lstNombres.Size = New System.Drawing.Size(275, 97)
        Me.lstNombres.TabIndex = 38
        Me.lstNombres.UseCompatibleStateImageBehavior = False
        Me.lstNombres.View = System.Windows.Forms.View.Details
        Me.lstNombres.Visible = False
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Nombre"
        Me.ColumnHeader1.Width = 127
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Apellido"
        Me.ColumnHeader2.Width = 154
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(35, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 16)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "Medidas principales"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(475, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(161, 16)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "Medidas antropometricas"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpcionesToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(871, 24)
        Me.MenuStrip1.TabIndex = 50
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
        'txtRestricciones
        '
        Me.txtRestricciones.Location = New System.Drawing.Point(33, 406)
        Me.txtRestricciones.Multiline = True
        Me.txtRestricciones.Name = "txtRestricciones"
        Me.txtRestricciones.Size = New System.Drawing.Size(358, 45)
        Me.txtRestricciones.TabIndex = 63
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(30, 388)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(60, 15)
        Me.Label21.TabIndex = 63
        Me.Label21.Text = "Objetivos:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(471, 388)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(88, 15)
        Me.Label22.TabIndex = 64
        Me.Label22.Text = "Observaciones"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(474, 406)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(358, 45)
        Me.txtObservaciones.TabIndex = 65
        '
        'lstEstados
        '
        Me.lstEstados.Location = New System.Drawing.Point(0, 496)
        Me.lstEstados.Name = "lstEstados"
        Me.lstEstados.Size = New System.Drawing.Size(871, 93)
        Me.lstEstados.TabIndex = 66
        Me.lstEstados.UseCompatibleStateImageBehavior = False
        Me.lstEstados.View = System.Windows.Forms.View.Details
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(385, 459)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(85, 22)
        Me.btnGuardar.TabIndex = 67
        Me.btnGuardar.Text = "Registrar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.txtTriceps)
        Me.Panel3.Controls.Add(Me.Label31)
        Me.Panel3.Controls.Add(Me.txtSubescapula)
        Me.Panel3.Controls.Add(Me.Label30)
        Me.Panel3.Controls.Add(Me.txtSuprailiaca)
        Me.Panel3.Controls.Add(Me.Label29)
        Me.Panel3.Controls.Add(Me.Label28)
        Me.Panel3.Controls.Add(Me.txtBiceps)
        Me.Panel3.Controls.Add(Me.Label34)
        Me.Panel3.Location = New System.Drawing.Point(38, 332)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(811, 53)
        Me.Panel3.TabIndex = 57
        '
        'txtTriceps
        '
        Me.txtTriceps.Location = New System.Drawing.Point(281, 13)
        Me.txtTriceps.Name = "txtTriceps"
        Me.txtTriceps.Size = New System.Drawing.Size(36, 20)
        Me.txtTriceps.TabIndex = 62
        Me.txtTriceps.Text = "0"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(221, 13)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(50, 15)
        Me.Label31.TabIndex = 61
        Me.Label31.Text = "Triceps:"
        '
        'txtSubescapula
        '
        Me.txtSubescapula.Location = New System.Drawing.Point(528, 14)
        Me.txtSubescapula.Name = "txtSubescapula"
        Me.txtSubescapula.Size = New System.Drawing.Size(36, 20)
        Me.txtSubescapula.TabIndex = 60
        Me.txtSubescapula.Text = "0"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(431, 13)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(82, 15)
        Me.Label30.TabIndex = 59
        Me.Label30.Text = "Subescapula:"
        '
        'txtSuprailiaca
        '
        Me.txtSuprailiaca.Location = New System.Drawing.Point(720, 12)
        Me.txtSuprailiaca.Name = "txtSuprailiaca"
        Me.txtSuprailiaca.Size = New System.Drawing.Size(36, 20)
        Me.txtSuprailiaca.TabIndex = 58
        Me.txtSuprailiaca.Text = "0"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(642, 13)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(72, 15)
        Me.Label29.TabIndex = 57
        Me.Label29.Text = "Suprailiaca:"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Red
        Me.Label28.Location = New System.Drawing.Point(192, 14)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(0, 15)
        Me.Label28.TabIndex = 56
        '
        'txtBiceps
        '
        Me.txtBiceps.Location = New System.Drawing.Point(93, 12)
        Me.txtBiceps.Name = "txtBiceps"
        Me.txtBiceps.Size = New System.Drawing.Size(36, 20)
        Me.txtBiceps.TabIndex = 47
        Me.txtBiceps.Text = "0"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(13, 13)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(47, 15)
        Me.Label34.TabIndex = 44
        Me.Label34.Text = "Biceps:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(37, 313)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(104, 16)
        Me.Label17.TabIndex = 68
        Me.Label17.Text = "Tejido Adiposo:"
        '
        'Medidas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.HighlightText
        Me.ClientSize = New System.Drawing.Size(871, 631)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.lstEstados)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.txtObservaciones)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.txtRestricciones)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PanelCabecera)
        Me.Controls.Add(Me.lstNombres)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Medidas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.PanelCabecera.ResumeLayout(False)
        Me.PanelCabecera.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btncerrar As System.Windows.Forms.Button
    Friend WithEvents PanelCabecera As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lstNombres As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents rdMasculino As System.Windows.Forms.RadioButton
    Friend WithEvents rdFemenino As System.Windows.Forms.RadioButton
    Friend WithEvents txtFc As System.Windows.Forms.TextBox
    Friend WithEvents txtGrasa As System.Windows.Forms.TextBox
    Friend WithEvents txtEdad As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtImc As System.Windows.Forms.TextBox
    Friend WithEvents txtTalla As System.Windows.Forms.TextBox
    Friend WithEvents txtPeso As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblEstato As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents OpcionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarEmpleadoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtBrazoizq As System.Windows.Forms.TextBox
    Friend WithEvents txtPectoral As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtEspalda As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtCintura As System.Windows.Forms.TextBox
    Friend WithEvents txtGluteo As System.Windows.Forms.TextBox
    Friend WithEvents txtMuslo As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtpantorrilla As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtRestricciones As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents lstEstados As System.Windows.Forms.ListView
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents txtBrazoder As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtPechoespalda As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtCuello As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtPiernaizq As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtPiernader As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtBiceps As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txtTriceps As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtSubescapula As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtSuprailiaca As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
End Class
