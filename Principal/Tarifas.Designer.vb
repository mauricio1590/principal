<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tarifas
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtnombre = New System.Windows.Forms.TextBox()
        Me.txtvalor = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtdias = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lstTarifas = New System.Windows.Forms.ListView()
        Me.Tarifa = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Valor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Dias = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Detalle = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtguardar = New System.Windows.Forms.Button()
        Me.txtModificar = New System.Windows.Forms.Button()
        Me.txtLimpiar = New System.Windows.Forms.Button()
        Me.chkDetalle = New System.Windows.Forms.CheckBox()
        Me.txtEliminar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(114, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre:"
        '
        'txtnombre
        '
        Me.txtnombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnombre.Location = New System.Drawing.Point(232, 36)
        Me.txtnombre.Name = "txtnombre"
        Me.txtnombre.Size = New System.Drawing.Size(174, 24)
        Me.txtnombre.TabIndex = 1
        '
        'txtvalor
        '
        Me.txtvalor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtvalor.Location = New System.Drawing.Point(232, 86)
        Me.txtvalor.Name = "txtvalor"
        Me.txtvalor.Size = New System.Drawing.Size(174, 24)
        Me.txtvalor.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(114, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Valor:"
        '
        'txtdias
        '
        Me.txtdias.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdias.Location = New System.Drawing.Point(232, 135)
        Me.txtdias.Name = "txtdias"
        Me.txtdias.Size = New System.Drawing.Size(174, 24)
        Me.txtdias.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(119, 141)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Dias:"
        '
        'lstTarifas
        '
        Me.lstTarifas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Tarifa, Me.Valor, Me.Dias, Me.Detalle})
        Me.lstTarifas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstTarifas.FullRowSelect = True
        Me.lstTarifas.GridLines = True
        Me.lstTarifas.HideSelection = False
        Me.lstTarifas.Location = New System.Drawing.Point(58, 249)
        Me.lstTarifas.Name = "lstTarifas"
        Me.lstTarifas.Size = New System.Drawing.Size(445, 244)
        Me.lstTarifas.TabIndex = 6
        Me.lstTarifas.UseCompatibleStateImageBehavior = False
        Me.lstTarifas.View = System.Windows.Forms.View.Details
        '
        'Tarifa
        '
        Me.Tarifa.Text = "Tarifa"
        Me.Tarifa.Width = 119
        '
        'Valor
        '
        Me.Valor.Text = "Valor"
        Me.Valor.Width = 131
        '
        'Dias
        '
        Me.Dias.Text = "Dias"
        Me.Dias.Width = 44
        '
        'Detalle
        '
        Me.Detalle.Text = "Detalle"
        Me.Detalle.Width = 144
        '
        'txtguardar
        '
        Me.txtguardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtguardar.Location = New System.Drawing.Point(62, 215)
        Me.txtguardar.Name = "txtguardar"
        Me.txtguardar.Size = New System.Drawing.Size(75, 23)
        Me.txtguardar.TabIndex = 7
        Me.txtguardar.Text = "Guardar"
        Me.txtguardar.UseVisualStyleBackColor = True
        '
        'txtModificar
        '
        Me.txtModificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtModificar.Location = New System.Drawing.Point(165, 215)
        Me.txtModificar.Name = "txtModificar"
        Me.txtModificar.Size = New System.Drawing.Size(75, 23)
        Me.txtModificar.TabIndex = 8
        Me.txtModificar.Text = "Modificar"
        Me.txtModificar.UseVisualStyleBackColor = True
        '
        'txtLimpiar
        '
        Me.txtLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLimpiar.Location = New System.Drawing.Point(278, 215)
        Me.txtLimpiar.Name = "txtLimpiar"
        Me.txtLimpiar.Size = New System.Drawing.Size(75, 23)
        Me.txtLimpiar.TabIndex = 9
        Me.txtLimpiar.Text = "Limpiar"
        Me.txtLimpiar.UseVisualStyleBackColor = True
        '
        'chkDetalle
        '
        Me.chkDetalle.AutoSize = True
        Me.chkDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDetalle.Location = New System.Drawing.Point(232, 182)
        Me.chkDetalle.Name = "chkDetalle"
        Me.chkDetalle.Size = New System.Drawing.Size(178, 20)
        Me.chkDetalle.TabIndex = 10
        Me.chkDetalle.Text = "Control por Asistencia"
        Me.chkDetalle.UseVisualStyleBackColor = True
        '
        'txtEliminar
        '
        Me.txtEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEliminar.Location = New System.Drawing.Point(381, 215)
        Me.txtEliminar.Name = "txtEliminar"
        Me.txtEliminar.Size = New System.Drawing.Size(75, 23)
        Me.txtEliminar.TabIndex = 11
        Me.txtEliminar.Text = "Eliminar"
        Me.txtEliminar.UseVisualStyleBackColor = True
        '
        'Tarifas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.HighlightText
        Me.ClientSize = New System.Drawing.Size(564, 505)
        Me.Controls.Add(Me.txtEliminar)
        Me.Controls.Add(Me.chkDetalle)
        Me.Controls.Add(Me.txtLimpiar)
        Me.Controls.Add(Me.txtModificar)
        Me.Controls.Add(Me.txtguardar)
        Me.Controls.Add(Me.lstTarifas)
        Me.Controls.Add(Me.txtdias)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtvalor)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtnombre)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Tarifas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tarifas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtnombre As System.Windows.Forms.TextBox
    Friend WithEvents txtvalor As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtdias As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lstTarifas As System.Windows.Forms.ListView
    Friend WithEvents Tarifa As System.Windows.Forms.ColumnHeader
    Friend WithEvents Valor As System.Windows.Forms.ColumnHeader
    Friend WithEvents Dias As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtguardar As System.Windows.Forms.Button
    Friend WithEvents txtModificar As System.Windows.Forms.Button
    Friend WithEvents txtLimpiar As System.Windows.Forms.Button
    Friend WithEvents chkDetalle As System.Windows.Forms.CheckBox
    Friend WithEvents Detalle As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtEliminar As System.Windows.Forms.Button
End Class
