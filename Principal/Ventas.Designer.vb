<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ventas
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
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PanelCabecera = New System.Windows.Forms.Panel()
        Me.btncerrar = New System.Windows.Forms.Button()
        Me.lstArticulos = New System.Windows.Forms.ListView()
        Me.Cantidad = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Articulo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Valor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Total = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chkNombre = New System.Windows.Forms.CheckBox()
        Me.chkReferencia = New System.Windows.Forms.CheckBox()
        Me.txtProducto = New System.Windows.Forms.TextBox()
        Me.lstEncontrados = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lstNombres = New System.Windows.Forms.ListView()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtRegistrar = New System.Windows.Forms.Button()
        Me.txtAbono = New System.Windows.Forms.TextBox()
        Me.lblAbono = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkAbono = New System.Windows.Forms.CheckBox()
        Me.PanelCabecera.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label6.Location = New System.Drawing.Point(355, 7)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(144, 16)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Venta de Productos"
        '
        'PanelCabecera
        '
        Me.PanelCabecera.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.PanelCabecera.Controls.Add(Me.Label6)
        Me.PanelCabecera.Controls.Add(Me.btncerrar)
        Me.PanelCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelCabecera.Location = New System.Drawing.Point(0, 0)
        Me.PanelCabecera.Name = "PanelCabecera"
        Me.PanelCabecera.Size = New System.Drawing.Size(810, 30)
        Me.PanelCabecera.TabIndex = 29
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
        Me.btncerrar.Location = New System.Drawing.Point(765, 0)
        Me.btncerrar.Name = "btncerrar"
        Me.btncerrar.Size = New System.Drawing.Size(30, 30)
        Me.btncerrar.TabIndex = 0
        Me.btncerrar.UseVisualStyleBackColor = True
        '
        'lstArticulos
        '
        Me.lstArticulos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Cantidad, Me.Articulo, Me.Valor, Me.Total})
        Me.lstArticulos.FullRowSelect = True
        Me.lstArticulos.GridLines = True
        Me.lstArticulos.HideSelection = False
        Me.lstArticulos.Location = New System.Drawing.Point(12, 152)
        Me.lstArticulos.Name = "lstArticulos"
        Me.lstArticulos.Size = New System.Drawing.Size(780, 151)
        Me.lstArticulos.TabIndex = 40
        Me.lstArticulos.UseCompatibleStateImageBehavior = False
        Me.lstArticulos.View = System.Windows.Forms.View.Details
        '
        'Cantidad
        '
        Me.Cantidad.Text = "Cantidad"
        Me.Cantidad.Width = 77
        '
        'Articulo
        '
        Me.Articulo.Text = "Articulo"
        Me.Articulo.Width = 297
        '
        'Valor
        '
        Me.Valor.Text = "Valor"
        Me.Valor.Width = 102
        '
        'Total
        '
        Me.Total.Text = "Total"
        '
        'chkNombre
        '
        Me.chkNombre.AutoSize = True
        Me.chkNombre.Location = New System.Drawing.Point(3, 6)
        Me.chkNombre.Name = "chkNombre"
        Me.chkNombre.Size = New System.Drawing.Size(63, 17)
        Me.chkNombre.TabIndex = 41
        Me.chkNombre.Text = "Nombre"
        Me.chkNombre.UseVisualStyleBackColor = True
        '
        'chkReferencia
        '
        Me.chkReferencia.AutoSize = True
        Me.chkReferencia.Location = New System.Drawing.Point(94, 6)
        Me.chkReferencia.Name = "chkReferencia"
        Me.chkReferencia.Size = New System.Drawing.Size(78, 17)
        Me.chkReferencia.TabIndex = 42
        Me.chkReferencia.Text = "Referencia"
        Me.chkReferencia.UseVisualStyleBackColor = True
        '
        'txtProducto
        '
        Me.txtProducto.Location = New System.Drawing.Point(376, 103)
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.Size = New System.Drawing.Size(211, 20)
        Me.txtProducto.TabIndex = 43
        '
        'lstEncontrados
        '
        Me.lstEncontrados.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.lstEncontrados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstEncontrados.FullRowSelect = True
        Me.lstEncontrados.GridLines = True
        Me.lstEncontrados.HideSelection = False
        Me.lstEncontrados.Location = New System.Drawing.Point(376, 125)
        Me.lstEncontrados.Name = "lstEncontrados"
        Me.lstEncontrados.Size = New System.Drawing.Size(317, 97)
        Me.lstEncontrados.TabIndex = 44
        Me.lstEncontrados.UseCompatibleStateImageBehavior = False
        Me.lstEncontrados.View = System.Windows.Forms.View.Details
        Me.lstEncontrados.Visible = False
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Articulo"
        Me.ColumnHeader1.Width = 165
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Precio"
        Me.ColumnHeader2.Width = 76
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Existencia"
        Me.ColumnHeader3.Width = 61
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(700, 103)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(92, 20)
        Me.txtCantidad.TabIndex = 45
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(697, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 16)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "Cantidad:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(373, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(137, 16)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "Selecione articulo:"
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(700, 309)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(92, 20)
        Me.txtTotal.TabIndex = 48
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.chkNombre)
        Me.Panel1.Controls.Add(Me.chkReferencia)
        Me.Panel1.Location = New System.Drawing.Point(12, 38)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(176, 36)
        Me.Panel1.TabIndex = 49
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(147, 103)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(211, 20)
        Me.txtCliente.TabIndex = 50
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(144, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(130, 16)
        Me.Label4.TabIndex = 52
        Me.Label4.Text = "Selecione Cliente"
        '
        'lstNombres
        '
        Me.lstNombres.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader5})
        Me.lstNombres.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstNombres.FullRowSelect = True
        Me.lstNombres.GridLines = True
        Me.lstNombres.HideSelection = False
        Me.lstNombres.Location = New System.Drawing.Point(147, 125)
        Me.lstNombres.Name = "lstNombres"
        Me.lstNombres.Size = New System.Drawing.Size(210, 97)
        Me.lstNombres.TabIndex = 53
        Me.lstNombres.UseCompatibleStateImageBehavior = False
        Me.lstNombres.View = System.Windows.Forms.View.Details
        Me.lstNombres.Visible = False
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Nombre"
        Me.ColumnHeader4.Width = 90
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Apellido"
        Me.ColumnHeader5.Width = 90
        '
        'txtRegistrar
        '
        Me.txtRegistrar.Location = New System.Drawing.Point(717, 375)
        Me.txtRegistrar.Name = "txtRegistrar"
        Me.txtRegistrar.Size = New System.Drawing.Size(75, 23)
        Me.txtRegistrar.TabIndex = 54
        Me.txtRegistrar.Text = "Registrar"
        Me.txtRegistrar.UseVisualStyleBackColor = True
        '
        'txtAbono
        '
        Me.txtAbono.Location = New System.Drawing.Point(700, 335)
        Me.txtAbono.Name = "txtAbono"
        Me.txtAbono.Size = New System.Drawing.Size(92, 20)
        Me.txtAbono.TabIndex = 55
        '
        'lblAbono
        '
        Me.lblAbono.AutoSize = True
        Me.lblAbono.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAbono.Location = New System.Drawing.Point(611, 336)
        Me.lblAbono.Name = "lblAbono"
        Me.lblAbono.Size = New System.Drawing.Size(57, 16)
        Me.lblAbono.TabIndex = 56
        Me.lblAbono.Text = "Abono:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(611, 310)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 16)
        Me.Label5.TabIndex = 57
        Me.Label5.Text = "Total:"
        '
        'chkAbono
        '
        Me.chkAbono.AutoSize = True
        Me.chkAbono.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAbono.Location = New System.Drawing.Point(488, 309)
        Me.chkAbono.Name = "chkAbono"
        Me.chkAbono.Size = New System.Drawing.Size(99, 20)
        Me.chkAbono.TabIndex = 43
        Me.chkAbono.Text = "Es Credito"
        Me.chkAbono.UseVisualStyleBackColor = True
        '
        'Ventas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.HighlightText
        Me.ClientSize = New System.Drawing.Size(810, 432)
        Me.Controls.Add(Me.chkAbono)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblAbono)
        Me.Controls.Add(Me.txtAbono)
        Me.Controls.Add(Me.txtRegistrar)
        Me.Controls.Add(Me.lstNombres)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.lstEncontrados)
        Me.Controls.Add(Me.txtProducto)
        Me.Controls.Add(Me.lstArticulos)
        Me.Controls.Add(Me.PanelCabecera)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Ventas"
        Me.Text = "Ventas"
        Me.PanelCabecera.ResumeLayout(False)
        Me.PanelCabecera.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btncerrar As System.Windows.Forms.Button
    Friend WithEvents PanelCabecera As System.Windows.Forms.Panel
    Friend WithEvents lstArticulos As System.Windows.Forms.ListView
    Friend WithEvents Cantidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents Articulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents Valor As System.Windows.Forms.ColumnHeader
    Friend WithEvents Total As System.Windows.Forms.ColumnHeader
    Friend WithEvents chkNombre As System.Windows.Forms.CheckBox
    Friend WithEvents chkReferencia As System.Windows.Forms.CheckBox
    Friend WithEvents txtProducto As System.Windows.Forms.TextBox
    Friend WithEvents lstEncontrados As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lstNombres As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtRegistrar As System.Windows.Forms.Button
    Friend WithEvents txtAbono As System.Windows.Forms.TextBox
    Friend WithEvents lblAbono As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkAbono As System.Windows.Forms.CheckBox
End Class
