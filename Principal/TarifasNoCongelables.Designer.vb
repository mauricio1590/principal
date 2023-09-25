<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TarifasNoCongelables
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
        Me.txtTarifa = New System.Windows.Forms.TextBox()
        Me.lblTarifa = New System.Windows.Forms.Label()
        Me.lstTarifas = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstGuardadas = New System.Windows.Forms.ListView()
        Me.Tarifa = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtTarifa
        '
        Me.txtTarifa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTarifa.Location = New System.Drawing.Point(169, 26)
        Me.txtTarifa.Name = "txtTarifa"
        Me.txtTarifa.Size = New System.Drawing.Size(210, 21)
        Me.txtTarifa.TabIndex = 33
        '
        'lblTarifa
        '
        Me.lblTarifa.AutoSize = True
        Me.lblTarifa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTarifa.Location = New System.Drawing.Point(12, 27)
        Me.lblTarifa.Name = "lblTarifa"
        Me.lblTarifa.Size = New System.Drawing.Size(116, 16)
        Me.lblTarifa.TabIndex = 32
        Me.lblTarifa.Text = "Seleccione Tarifa:"
        '
        'lstTarifas
        '
        Me.lstTarifas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.lstTarifas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstTarifas.FullRowSelect = True
        Me.lstTarifas.GridLines = True
        Me.lstTarifas.HideSelection = False
        Me.lstTarifas.Location = New System.Drawing.Point(169, 49)
        Me.lstTarifas.Name = "lstTarifas"
        Me.lstTarifas.Size = New System.Drawing.Size(210, 70)
        Me.lstTarifas.TabIndex = 34
        Me.lstTarifas.UseCompatibleStateImageBehavior = False
        Me.lstTarifas.View = System.Windows.Forms.View.Details
        Me.lstTarifas.Visible = False
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Nombre"
        Me.ColumnHeader1.Width = 202
        '
        'lstGuardadas
        '
        Me.lstGuardadas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Tarifa})
        Me.lstGuardadas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstGuardadas.FullRowSelect = True
        Me.lstGuardadas.GridLines = True
        Me.lstGuardadas.HideSelection = False
        Me.lstGuardadas.Location = New System.Drawing.Point(16, 173)
        Me.lstGuardadas.Name = "lstGuardadas"
        Me.lstGuardadas.Size = New System.Drawing.Size(383, 157)
        Me.lstGuardadas.TabIndex = 36
        Me.lstGuardadas.UseCompatibleStateImageBehavior = False
        Me.lstGuardadas.View = System.Windows.Forms.View.Details
        '
        'Tarifa
        '
        Me.Tarifa.Text = "Tarifa"
        Me.Tarifa.Width = 345
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(53, 96)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 35
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'TarifasNoCongelables
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(411, 355)
        Me.Controls.Add(Me.txtTarifa)
        Me.Controls.Add(Me.lblTarifa)
        Me.Controls.Add(Me.lstTarifas)
        Me.Controls.Add(Me.lstGuardadas)
        Me.Controls.Add(Me.btnAceptar)
        Me.Name = "TarifasNoCongelables"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TarifasNoCongelables"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtTarifa As TextBox
    Friend WithEvents lblTarifa As Label
    Friend WithEvents lstTarifas As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents lstGuardadas As ListView
    Friend WithEvents Tarifa As ColumnHeader
    Friend WithEvents btnAceptar As Button
End Class
