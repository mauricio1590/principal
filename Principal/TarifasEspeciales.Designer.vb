<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TarifasEspeciales
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
        Me.lblTarifa = New System.Windows.Forms.Label()
        Me.txtTarifa = New System.Windows.Forms.TextBox()
        Me.txtHora1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtHora2 = New System.Windows.Forms.TextBox()
        Me.lstTarifas = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.lstGuardadas = New System.Windows.Forms.ListView()
        Me.Tarifa = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.hInicio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.hFinal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblTarifa
        '
        Me.lblTarifa.AutoSize = True
        Me.lblTarifa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTarifa.Location = New System.Drawing.Point(12, 37)
        Me.lblTarifa.Name = "lblTarifa"
        Me.lblTarifa.Size = New System.Drawing.Size(117, 16)
        Me.lblTarifa.TabIndex = 0
        Me.lblTarifa.Text = "Seleccione Tarifa:"
        '
        'txtTarifa
        '
        Me.txtTarifa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTarifa.Location = New System.Drawing.Point(169, 36)
        Me.txtTarifa.Name = "txtTarifa"
        Me.txtTarifa.Size = New System.Drawing.Size(210, 21)
        Me.txtTarifa.TabIndex = 1
        '
        'txtHora1
        '
        Me.txtHora1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHora1.Location = New System.Drawing.Point(309, 76)
        Me.txtHora1.Name = "txtHora1"
        Me.txtHora1.Size = New System.Drawing.Size(70, 21)
        Me.txtHora1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(147, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Hora minima Permitida:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(151, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Hora maxima Permitida:"
        '
        'txtHora2
        '
        Me.txtHora2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHora2.Location = New System.Drawing.Point(309, 117)
        Me.txtHora2.Name = "txtHora2"
        Me.txtHora2.Size = New System.Drawing.Size(70, 21)
        Me.txtHora2.TabIndex = 5
        '
        'lstTarifas
        '
        Me.lstTarifas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.lstTarifas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstTarifas.FullRowSelect = True
        Me.lstTarifas.GridLines = True
        Me.lstTarifas.HideSelection = False
        Me.lstTarifas.Location = New System.Drawing.Point(169, 59)
        Me.lstTarifas.Name = "lstTarifas"
        Me.lstTarifas.Size = New System.Drawing.Size(210, 99)
        Me.lstTarifas.TabIndex = 31
        Me.lstTarifas.UseCompatibleStateImageBehavior = False
        Me.lstTarifas.View = System.Windows.Forms.View.Details
        Me.lstTarifas.Visible = False
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Nombre"
        Me.ColumnHeader1.Width = 202
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(169, 164)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 32
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'lstGuardadas
        '
        Me.lstGuardadas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Tarifa, Me.hInicio, Me.hFinal})
        Me.lstGuardadas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstGuardadas.FullRowSelect = True
        Me.lstGuardadas.GridLines = True
        Me.lstGuardadas.Location = New System.Drawing.Point(16, 212)
        Me.lstGuardadas.Name = "lstGuardadas"
        Me.lstGuardadas.Size = New System.Drawing.Size(398, 157)
        Me.lstGuardadas.TabIndex = 33
        Me.lstGuardadas.UseCompatibleStateImageBehavior = False
        Me.lstGuardadas.View = System.Windows.Forms.View.Details
        '
        'Tarifa
        '
        Me.Tarifa.Text = "Tarifa"
        Me.Tarifa.Width = 233
        '
        'hInicio
        '
        Me.hInicio.Text = "Hora Inicio"
        Me.hInicio.Width = 80
        '
        'hFinal
        '
        Me.hFinal.Text = "Hora Final"
        Me.hFinal.Width = 78
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(250, 164)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(75, 23)
        Me.btnModificar.TabIndex = 34
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'TarifasEspeciales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(426, 416)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.lstGuardadas)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.txtHora2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtHora1)
        Me.Controls.Add(Me.txtTarifa)
        Me.Controls.Add(Me.lblTarifa)
        Me.Controls.Add(Me.lstTarifas)
        Me.Name = "TarifasEspeciales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TarifasEspeciales"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTarifa As System.Windows.Forms.Label
    Friend WithEvents txtTarifa As System.Windows.Forms.TextBox
    Friend WithEvents txtHora1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtHora2 As System.Windows.Forms.TextBox
    Friend WithEvents lstTarifas As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents lstGuardadas As System.Windows.Forms.ListView
    Friend WithEvents Tarifa As System.Windows.Forms.ColumnHeader
    Friend WithEvents hInicio As System.Windows.Forms.ColumnHeader
    Friend WithEvents hFinal As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnModificar As System.Windows.Forms.Button
End Class
