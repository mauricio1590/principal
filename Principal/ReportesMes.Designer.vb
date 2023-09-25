<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportesMes
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
        Me.PanelCabecera = New System.Windows.Forms.Panel()
        Me.btncerrar = New System.Windows.Forms.Button()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.lstreportes = New System.Windows.Forms.ListView()
        Me.Cliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Descripcion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Valor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Fechadepago = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.fhasta = New System.Windows.Forms.DateTimePicker()
        Me.fdesde = New System.Windows.Forms.DateTimePicker()
        Me.chkTarjeta = New System.Windows.Forms.CheckBox()
        Me.PanelCabecera.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelCabecera
        '
        Me.PanelCabecera.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.PanelCabecera.Controls.Add(Me.btncerrar)
        Me.PanelCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelCabecera.Location = New System.Drawing.Point(0, 0)
        Me.PanelCabecera.Name = "PanelCabecera"
        Me.PanelCabecera.Size = New System.Drawing.Size(836, 30)
        Me.PanelCabecera.TabIndex = 38
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
        Me.btncerrar.Location = New System.Drawing.Point(791, 0)
        Me.btncerrar.Name = "btncerrar"
        Me.btncerrar.Size = New System.Drawing.Size(30, 30)
        Me.btncerrar.TabIndex = 0
        Me.btncerrar.UseVisualStyleBackColor = True
        '
        'txtTotal
        '
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(613, 474)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(208, 22)
        Me.txtTotal.TabIndex = 39
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
        Me.lstreportes.Location = New System.Drawing.Point(-3, 89)
        Me.lstreportes.Margin = New System.Windows.Forms.Padding(4)
        Me.lstreportes.Name = "lstreportes"
        Me.lstreportes.Size = New System.Drawing.Size(839, 364)
        Me.lstreportes.TabIndex = 37
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
        'fhasta
        '
        Me.fhasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fhasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fhasta.Location = New System.Drawing.Point(288, 59)
        Me.fhasta.Margin = New System.Windows.Forms.Padding(4)
        Me.fhasta.Name = "fhasta"
        Me.fhasta.Size = New System.Drawing.Size(136, 22)
        Me.fhasta.TabIndex = 41
        '
        'fdesde
        '
        Me.fdesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fdesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fdesde.Location = New System.Drawing.Point(126, 59)
        Me.fdesde.Margin = New System.Windows.Forms.Padding(4)
        Me.fdesde.Name = "fdesde"
        Me.fdesde.Size = New System.Drawing.Size(136, 22)
        Me.fdesde.TabIndex = 40
        '
        'chkTarjeta
        '
        Me.chkTarjeta.AutoSize = True
        Me.chkTarjeta.Location = New System.Drawing.Point(475, 65)
        Me.chkTarjeta.Name = "chkTarjeta"
        Me.chkTarjeta.Size = New System.Drawing.Size(114, 17)
        Me.chkTarjeta.TabIndex = 42
        Me.chkTarjeta.Text = "Pagos Con Tarjeta"
        Me.chkTarjeta.UseVisualStyleBackColor = True
        '
        'ReportesMes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(836, 530)
        Me.Controls.Add(Me.chkTarjeta)
        Me.Controls.Add(Me.fhasta)
        Me.Controls.Add(Me.fdesde)
        Me.Controls.Add(Me.PanelCabecera)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.lstreportes)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ReportesMes"
        Me.Text = " "
        Me.PanelCabecera.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PanelCabecera As System.Windows.Forms.Panel
    Friend WithEvents btncerrar As System.Windows.Forms.Button
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents lstreportes As System.Windows.Forms.ListView
    Private WithEvents Cliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents Descripcion As System.Windows.Forms.ColumnHeader
    Friend WithEvents Valor As System.Windows.Forms.ColumnHeader
    Friend WithEvents Fechadepago As System.Windows.Forms.ColumnHeader
    Friend WithEvents fhasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents fdesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkTarjeta As CheckBox
End Class
