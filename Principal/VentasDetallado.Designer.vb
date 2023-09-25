<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VentasDetallado
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
        Me.fhasta = New System.Windows.Forms.DateTimePicker()
        Me.fdesde = New System.Windows.Forms.DateTimePicker()
        Me.PanelCabecera = New System.Windows.Forms.Panel()
        Me.btncerrar = New System.Windows.Forms.Button()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.lstreportes = New System.Windows.Forms.ListView()
        Me.Cliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Descripcion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Valor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Fechadepago = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtname = New System.Windows.Forms.TextBox()
        Me.lstNombres = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PanelCabecera.SuspendLayout()
        Me.SuspendLayout()
        '
        'fhasta
        '
        Me.fhasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fhasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fhasta.Location = New System.Drawing.Point(272, 36)
        Me.fhasta.Margin = New System.Windows.Forms.Padding(4)
        Me.fhasta.Name = "fhasta"
        Me.fhasta.Size = New System.Drawing.Size(136, 22)
        Me.fhasta.TabIndex = 46
        '
        'fdesde
        '
        Me.fdesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fdesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fdesde.Location = New System.Drawing.Point(110, 36)
        Me.fdesde.Margin = New System.Windows.Forms.Padding(4)
        Me.fdesde.Name = "fdesde"
        Me.fdesde.Size = New System.Drawing.Size(136, 22)
        Me.fdesde.TabIndex = 45
        '
        'PanelCabecera
        '
        Me.PanelCabecera.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.PanelCabecera.Controls.Add(Me.btncerrar)
        Me.PanelCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelCabecera.Location = New System.Drawing.Point(0, 0)
        Me.PanelCabecera.Name = "PanelCabecera"
        Me.PanelCabecera.Size = New System.Drawing.Size(909, 30)
        Me.PanelCabecera.TabIndex = 43
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
        Me.btncerrar.Location = New System.Drawing.Point(864, 0)
        Me.btncerrar.Name = "btncerrar"
        Me.btncerrar.Size = New System.Drawing.Size(30, 30)
        Me.btncerrar.TabIndex = 0
        Me.btncerrar.UseVisualStyleBackColor = True
        '
        'txtTotal
        '
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(677, 539)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(208, 22)
        Me.txtTotal.TabIndex = 44
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lstreportes
        '
        Me.lstreportes.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lstreportes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Cliente, Me.Descripcion, Me.Valor, Me.Fechadepago})
        Me.lstreportes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstreportes.FullRowSelect = True
        Me.lstreportes.GridLines = True
        Me.lstreportes.HideSelection = False
        Me.lstreportes.HoverSelection = True
        Me.lstreportes.Location = New System.Drawing.Point(28, 75)
        Me.lstreportes.Margin = New System.Windows.Forms.Padding(4)
        Me.lstreportes.Name = "lstreportes"
        Me.lstreportes.Size = New System.Drawing.Size(866, 457)
        Me.lstreportes.TabIndex = 42
        Me.lstreportes.UseCompatibleStateImageBehavior = False
        Me.lstreportes.View = System.Windows.Forms.View.Details
        '
        'Cliente
        '
        Me.Cliente.Text = "Cliente"
        Me.Cliente.Width = 185
        '
        'Descripcion
        '
        Me.Descripcion.Text = "Descripcion"
        Me.Descripcion.Width = 141
        '
        'Valor
        '
        Me.Valor.Text = "Valor"
        Me.Valor.Width = 161
        '
        'Fechadepago
        '
        Me.Fechadepago.Text = "Fecha  de pago"
        Me.Fechadepago.Width = 365
        '
        'txtname
        '
        Me.txtname.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtname.Location = New System.Drawing.Point(461, 38)
        Me.txtname.Name = "txtname"
        Me.txtname.Size = New System.Drawing.Size(212, 22)
        Me.txtname.TabIndex = 47
        '
        'lstNombres
        '
        Me.lstNombres.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lstNombres.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstNombres.FullRowSelect = True
        Me.lstNombres.GridLines = True
        Me.lstNombres.HideSelection = False
        Me.lstNombres.Location = New System.Drawing.Point(463, 61)
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
        'VentasDetallado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(909, 573)
        Me.Controls.Add(Me.txtname)
        Me.Controls.Add(Me.lstNombres)
        Me.Controls.Add(Me.fhasta)
        Me.Controls.Add(Me.fdesde)
        Me.Controls.Add(Me.PanelCabecera)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.lstreportes)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "VentasDetallado"
        Me.Text = "Form1"
        Me.PanelCabecera.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fhasta As DateTimePicker
    Friend WithEvents fdesde As DateTimePicker
    Friend WithEvents PanelCabecera As Panel
    Friend WithEvents btncerrar As Button
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents lstreportes As ListView
    Private WithEvents Cliente As ColumnHeader
    Friend WithEvents Descripcion As ColumnHeader
    Friend WithEvents Valor As ColumnHeader
    Friend WithEvents Fechadepago As ColumnHeader
    Friend WithEvents txtname As TextBox
    Friend WithEvents lstNombres As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
End Class
