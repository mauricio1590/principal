<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class reportes
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lstreportes = New System.Windows.Forms.ListView()
        Me.Cliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Descripcion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Valor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Fechadepago = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtReporte = New System.Windows.Forms.TextBox()
        Me.fdesde = New System.Windows.Forms.DateTimePicker()
        Me.fhasta = New System.Windows.Forms.DateTimePicker()
        Me.lstreporte = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.OpcionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PanelCabecera = New System.Windows.Forms.Panel()
        Me.btncerrar = New System.Windows.Forms.Button()
        Me.txtExportar = New System.Windows.Forms.Button()
        Me.chkTarjeta = New System.Windows.Forms.CheckBox()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.chkGrupo = New System.Windows.Forms.GroupBox()
        Me.chkM = New System.Windows.Forms.RadioButton()
        Me.chkPm = New System.Windows.Forms.RadioButton()
        Me.chkAm = New System.Windows.Forms.RadioButton()
        Me.MenuStrip1.SuspendLayout()
        Me.PanelCabecera.SuspendLayout()
        Me.chkGrupo.SuspendLayout()
        Me.SuspendLayout()
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
        Me.lstreportes.Location = New System.Drawing.Point(3, 148)
        Me.lstreportes.Margin = New System.Windows.Forms.Padding(4)
        Me.lstreportes.Name = "lstreportes"
        Me.lstreportes.Size = New System.Drawing.Size(845, 364)
        Me.lstreportes.TabIndex = 0
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 86)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(122, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Selccione Reporte:"
        '
        'txtReporte
        '
        Me.txtReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReporte.Location = New System.Drawing.Point(55, 107)
        Me.txtReporte.Margin = New System.Windows.Forms.Padding(4)
        Me.txtReporte.Name = "txtReporte"
        Me.txtReporte.Size = New System.Drawing.Size(272, 22)
        Me.txtReporte.TabIndex = 2
        '
        'fdesde
        '
        Me.fdesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fdesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fdesde.Location = New System.Drawing.Point(335, 107)
        Me.fdesde.Margin = New System.Windows.Forms.Padding(4)
        Me.fdesde.Name = "fdesde"
        Me.fdesde.Size = New System.Drawing.Size(136, 22)
        Me.fdesde.TabIndex = 6
        '
        'fhasta
        '
        Me.fhasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fhasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fhasta.Location = New System.Drawing.Point(497, 107)
        Me.fhasta.Margin = New System.Windows.Forms.Padding(4)
        Me.fhasta.Name = "fhasta"
        Me.fhasta.Size = New System.Drawing.Size(136, 22)
        Me.fhasta.TabIndex = 7
        '
        'lstreporte
        '
        Me.lstreporte.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.lstreporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstreporte.FullRowSelect = True
        Me.lstreporte.GridLines = True
        Me.lstreporte.HideSelection = False
        Me.lstreporte.Location = New System.Drawing.Point(55, 133)
        Me.lstreporte.Margin = New System.Windows.Forms.Padding(4)
        Me.lstreporte.Name = "lstreporte"
        Me.lstreporte.Size = New System.Drawing.Size(272, 185)
        Me.lstreporte.TabIndex = 31
        Me.lstreporte.UseCompatibleStateImageBehavior = False
        Me.lstreporte.View = System.Windows.Forms.View.Details
        Me.lstreporte.Visible = False
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Nombre"
        Me.ColumnHeader1.Width = 267
        '
        'txtTotal
        '
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(643, 519)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(208, 22)
        Me.txtTotal.TabIndex = 32
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpcionesToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(863, 24)
        Me.MenuStrip1.TabIndex = 33
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'OpcionesToolStripMenuItem
        '
        Me.OpcionesToolStripMenuItem.Name = "OpcionesToolStripMenuItem"
        Me.OpcionesToolStripMenuItem.Size = New System.Drawing.Size(69, 20)
        Me.OpcionesToolStripMenuItem.Text = "Opciones"
        '
        'PanelCabecera
        '
        Me.PanelCabecera.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.PanelCabecera.Controls.Add(Me.btncerrar)
        Me.PanelCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelCabecera.Location = New System.Drawing.Point(0, 24)
        Me.PanelCabecera.Name = "PanelCabecera"
        Me.PanelCabecera.Size = New System.Drawing.Size(863, 30)
        Me.PanelCabecera.TabIndex = 34
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
        Me.btncerrar.Location = New System.Drawing.Point(818, 0)
        Me.btncerrar.Name = "btncerrar"
        Me.btncerrar.Size = New System.Drawing.Size(30, 30)
        Me.btncerrar.TabIndex = 0
        Me.btncerrar.UseVisualStyleBackColor = True
        '
        'txtExportar
        '
        Me.txtExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.txtExportar.Image = Global.Principal.My.Resources.Resources.Download
        Me.txtExportar.Location = New System.Drawing.Point(789, 106)
        Me.txtExportar.Name = "txtExportar"
        Me.txtExportar.Size = New System.Drawing.Size(28, 23)
        Me.txtExportar.TabIndex = 35
        Me.txtExportar.UseVisualStyleBackColor = True
        '
        'chkTarjeta
        '
        Me.chkTarjeta.AutoSize = True
        Me.chkTarjeta.Location = New System.Drawing.Point(643, 111)
        Me.chkTarjeta.Name = "chkTarjeta"
        Me.chkTarjeta.Size = New System.Drawing.Size(139, 20)
        Me.chkTarjeta.TabIndex = 36
        Me.chkTarjeta.Text = "Pagos Con Tarjeta"
        Me.chkTarjeta.UseVisualStyleBackColor = True
        '
        'chkGrupo
        '
        Me.chkGrupo.Controls.Add(Me.chkM)
        Me.chkGrupo.Controls.Add(Me.chkPm)
        Me.chkGrupo.Controls.Add(Me.chkAm)
        Me.chkGrupo.Location = New System.Drawing.Point(621, 60)
        Me.chkGrupo.Name = "chkGrupo"
        Me.chkGrupo.Size = New System.Drawing.Size(184, 45)
        Me.chkGrupo.TabIndex = 39
        Me.chkGrupo.TabStop = False
        '
        'chkM
        '
        Me.chkM.AutoSize = True
        Me.chkM.Location = New System.Drawing.Point(123, 14)
        Me.chkM.Name = "chkM"
        Me.chkM.Size = New System.Drawing.Size(36, 20)
        Me.chkM.TabIndex = 2
        Me.chkM.TabStop = True
        Me.chkM.Text = "M"
        Me.chkM.UseVisualStyleBackColor = True
        '
        'chkPm
        '
        Me.chkPm.AutoSize = True
        Me.chkPm.Location = New System.Drawing.Point(72, 14)
        Me.chkPm.Name = "chkPm"
        Me.chkPm.Size = New System.Drawing.Size(45, 20)
        Me.chkPm.TabIndex = 1
        Me.chkPm.TabStop = True
        Me.chkPm.Text = "PM"
        Me.chkPm.UseVisualStyleBackColor = True
        '
        'chkAm
        '
        Me.chkAm.AutoSize = True
        Me.chkAm.Location = New System.Drawing.Point(21, 14)
        Me.chkAm.Name = "chkAm"
        Me.chkAm.Size = New System.Drawing.Size(45, 20)
        Me.chkAm.TabIndex = 0
        Me.chkAm.TabStop = True
        Me.chkAm.Text = "AM"
        Me.chkAm.UseVisualStyleBackColor = True
        '
        'reportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.HighlightText
        Me.ClientSize = New System.Drawing.Size(863, 559)
        Me.Controls.Add(Me.chkGrupo)
        Me.Controls.Add(Me.chkTarjeta)
        Me.Controls.Add(Me.txtExportar)
        Me.Controls.Add(Me.PanelCabecera)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.lstreporte)
        Me.Controls.Add(Me.fhasta)
        Me.Controls.Add(Me.fdesde)
        Me.Controls.Add(Me.txtReporte)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lstreportes)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "reportes"
        Me.Text = "reportes"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.PanelCabecera.ResumeLayout(False)
        Me.chkGrupo.ResumeLayout(False)
        Me.chkGrupo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstreportes As System.Windows.Forms.ListView
    Private WithEvents Cliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents Descripcion As System.Windows.Forms.ColumnHeader
    Friend WithEvents Valor As System.Windows.Forms.ColumnHeader
    Friend WithEvents Fechadepago As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtReporte As System.Windows.Forms.TextBox
    Friend WithEvents fdesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents fhasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents lstreporte As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents OpcionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PanelCabecera As System.Windows.Forms.Panel
    Friend WithEvents btncerrar As System.Windows.Forms.Button
    Friend WithEvents txtExportar As System.Windows.Forms.Button
    Friend WithEvents chkTarjeta As System.Windows.Forms.CheckBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents chkGrupo As GroupBox
    Friend WithEvents chkPm As RadioButton
    Friend WithEvents chkAm As RadioButton
    Friend WithEvents chkM As RadioButton
End Class
