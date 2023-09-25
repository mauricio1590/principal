<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class horarios
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
        Me.txtnameCliente = New System.Windows.Forms.TextBox()
        Me.lstNombresCliente = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtHora = New System.Windows.Forms.TextBox()
        Me.lstHoras = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstPersonalizados = New System.Windows.Forms.ListView()
        Me.Instructor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Hora = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Cliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtTotales = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PanelCabecera.SuspendLayout()
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
        Me.Label6.Text = "PERSONALIZADOS"
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
        Me.PanelCabecera.TabIndex = 28
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
        'txtnameCliente
        '
        Me.txtnameCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnameCliente.Location = New System.Drawing.Point(32, 69)
        Me.txtnameCliente.Name = "txtnameCliente"
        Me.txtnameCliente.Size = New System.Drawing.Size(212, 22)
        Me.txtnameCliente.TabIndex = 51
        '
        'lstNombresCliente
        '
        Me.lstNombresCliente.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3})
        Me.lstNombresCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstNombresCliente.FullRowSelect = True
        Me.lstNombresCliente.GridLines = True
        Me.lstNombresCliente.HideSelection = False
        Me.lstNombresCliente.Location = New System.Drawing.Point(32, 92)
        Me.lstNombresCliente.Name = "lstNombresCliente"
        Me.lstNombresCliente.Size = New System.Drawing.Size(210, 151)
        Me.lstNombresCliente.TabIndex = 52
        Me.lstNombresCliente.UseCompatibleStateImageBehavior = False
        Me.lstNombresCliente.View = System.Windows.Forms.View.Details
        Me.lstNombresCliente.Visible = False
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Nombre"
        Me.ColumnHeader3.Width = 207
        '
        'txtHora
        '
        Me.txtHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHora.Location = New System.Drawing.Point(298, 67)
        Me.txtHora.Name = "txtHora"
        Me.txtHora.Size = New System.Drawing.Size(212, 22)
        Me.txtHora.TabIndex = 53
        '
        'lstHoras
        '
        Me.lstHoras.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5})
        Me.lstHoras.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstHoras.FullRowSelect = True
        Me.lstHoras.GridLines = True
        Me.lstHoras.HideSelection = False
        Me.lstHoras.Location = New System.Drawing.Point(298, 90)
        Me.lstHoras.Name = "lstHoras"
        Me.lstHoras.Size = New System.Drawing.Size(210, 153)
        Me.lstHoras.TabIndex = 54
        Me.lstHoras.UseCompatibleStateImageBehavior = False
        Me.lstHoras.View = System.Windows.Forms.View.Details
        Me.lstHoras.Visible = False
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Hora"
        Me.ColumnHeader5.Width = 209
        '
        'lstPersonalizados
        '
        Me.lstPersonalizados.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Instructor, Me.Hora, Me.Cliente})
        Me.lstPersonalizados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstPersonalizados.FullRowSelect = True
        Me.lstPersonalizados.GridLines = True
        Me.lstPersonalizados.HideSelection = False
        Me.lstPersonalizados.Location = New System.Drawing.Point(30, 141)
        Me.lstPersonalizados.Name = "lstPersonalizados"
        Me.lstPersonalizados.Size = New System.Drawing.Size(746, 345)
        Me.lstPersonalizados.TabIndex = 55
        Me.lstPersonalizados.UseCompatibleStateImageBehavior = False
        Me.lstPersonalizados.View = System.Windows.Forms.View.Details
        '
        'Instructor
        '
        Me.Instructor.Text = "Instructor"
        Me.Instructor.Width = 323
        '
        'Hora
        '
        Me.Hora.Text = "Hora"
        '
        'Cliente
        '
        Me.Cliente.Text = "Cliente"
        Me.Cliente.Width = 338
        '
        'txtTotales
        '
        Me.txtTotales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotales.Location = New System.Drawing.Point(546, 518)
        Me.txtTotales.Name = "txtTotales"
        Me.txtTotales.Size = New System.Drawing.Size(212, 22)
        Me.txtTotales.TabIndex = 56
        Me.txtTotales.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(29, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 15)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "Usuario"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(295, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 15)
        Me.Label3.TabIndex = 59
        Me.Label3.Text = "Horario"
        '
        'horarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(810, 552)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtTotales)
        Me.Controls.Add(Me.lstPersonalizados)
        Me.Controls.Add(Me.txtHora)
        Me.Controls.Add(Me.lstHoras)
        Me.Controls.Add(Me.txtnameCliente)
        Me.Controls.Add(Me.lstNombresCliente)
        Me.Controls.Add(Me.PanelCabecera)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "horarios"
        Me.Text = "Personalizado"
        Me.PanelCabecera.ResumeLayout(False)
        Me.PanelCabecera.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btncerrar As System.Windows.Forms.Button
    Friend WithEvents PanelCabecera As System.Windows.Forms.Panel
    Friend WithEvents txtnameCliente As System.Windows.Forms.TextBox
    Friend WithEvents lstNombresCliente As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtHora As System.Windows.Forms.TextBox
    Friend WithEvents lstHoras As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstPersonalizados As System.Windows.Forms.ListView
    Friend WithEvents Instructor As System.Windows.Forms.ColumnHeader
    Friend WithEvents Hora As System.Windows.Forms.ColumnHeader
    Friend WithEvents Cliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtTotales As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
