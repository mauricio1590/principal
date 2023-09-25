<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AjusteDeInventario
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2213:DisposableFieldsShouldBeDisposed", MessageId:="gestor1")> <System.Diagnostics.DebuggerNonUserCode()> _
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
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.lstEncontrados = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtProducto = New System.Windows.Forms.TextBox()
        Me.lstArticulos = New System.Windows.Forms.ListView()
        Me.Cantidad = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Articulo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Valor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Total = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PanelCabecera = New System.Windows.Forms.Panel()
        Me.btncerrar = New System.Windows.Forms.Button()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.chkReferencia = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkNombre = New System.Windows.Forms.CheckBox()
        Me.txtRegistrar = New System.Windows.Forms.Button()
        Me.PanelCabecera.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(327, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 16)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "Cantidad:"
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(330, 100)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(92, 20)
        Me.txtCantidad.TabIndex = 50
        '
        'lstEncontrados
        '
        Me.lstEncontrados.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.lstEncontrados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstEncontrados.FullRowSelect = True
        Me.lstEncontrados.GridLines = True
        Me.lstEncontrados.HideSelection = False
        Me.lstEncontrados.Location = New System.Drawing.Point(6, 122)
        Me.lstEncontrados.Name = "lstEncontrados"
        Me.lstEncontrados.Size = New System.Drawing.Size(211, 97)
        Me.lstEncontrados.TabIndex = 49
        Me.lstEncontrados.UseCompatibleStateImageBehavior = False
        Me.lstEncontrados.View = System.Windows.Forms.View.Details
        Me.lstEncontrados.Visible = False
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Articulo"
        Me.ColumnHeader1.Width = 109
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Precio"
        Me.ColumnHeader2.Width = 187
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Existencia"
        Me.ColumnHeader3.Width = 112
        '
        'txtProducto
        '
        Me.txtProducto.Location = New System.Drawing.Point(6, 100)
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.Size = New System.Drawing.Size(211, 20)
        Me.txtProducto.TabIndex = 48
        '
        'lstArticulos
        '
        Me.lstArticulos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Cantidad, Me.Articulo, Me.Valor, Me.Total})
        Me.lstArticulos.FullRowSelect = True
        Me.lstArticulos.GridLines = True
        Me.lstArticulos.HideSelection = False
        Me.lstArticulos.Location = New System.Drawing.Point(2, 189)
        Me.lstArticulos.Name = "lstArticulos"
        Me.lstArticulos.Size = New System.Drawing.Size(688, 151)
        Me.lstArticulos.TabIndex = 47
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
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label6.Location = New System.Drawing.Point(295, 7)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(147, 16)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Ajuste De Inventario"
        '
        'PanelCabecera
        '
        Me.PanelCabecera.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.PanelCabecera.Controls.Add(Me.Label6)
        Me.PanelCabecera.Controls.Add(Me.btncerrar)
        Me.PanelCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelCabecera.Location = New System.Drawing.Point(0, 0)
        Me.PanelCabecera.Name = "PanelCabecera"
        Me.PanelCabecera.Size = New System.Drawing.Size(690, 30)
        Me.PanelCabecera.TabIndex = 52
        '
        'btncerrar
        '
        Me.btncerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '  Me.btncerrar.BackgroundImage = Global.Principal.My.Resources.Resources.cerrar
        Me.btncerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btncerrar.FlatAppearance.BorderSize = 0
        Me.btncerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btncerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.btncerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncerrar.Location = New System.Drawing.Point(645, 0)
        Me.btncerrar.Name = "btncerrar"
        Me.btncerrar.Size = New System.Drawing.Size(30, 30)
        Me.btncerrar.TabIndex = 0
        Me.btncerrar.UseVisualStyleBackColor = True
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(586, 346)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(92, 20)
        Me.txtTotal.TabIndex = 53
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
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.chkNombre)
        Me.Panel1.Controls.Add(Me.chkReferencia)
        Me.Panel1.Location = New System.Drawing.Point(12, 36)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(176, 36)
        Me.Panel1.TabIndex = 54
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
        'txtRegistrar
        '
        Me.txtRegistrar.Location = New System.Drawing.Point(491, 344)
        Me.txtRegistrar.Name = "txtRegistrar"
        Me.txtRegistrar.Size = New System.Drawing.Size(75, 23)
        Me.txtRegistrar.TabIndex = 55
        Me.txtRegistrar.Text = "Registrar"
        Me.txtRegistrar.UseVisualStyleBackColor = True
        '
        'AjusteDeInventario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(690, 420)
        Me.Controls.Add(Me.txtRegistrar)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.PanelCabecera)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.lstEncontrados)
        Me.Controls.Add(Me.txtProducto)
        Me.Controls.Add(Me.lstArticulos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "AjusteDeInventario"
        Me.Text = "AjusteDeiiNVENTARIO"
        Me.PanelCabecera.ResumeLayout(False)
        Me.PanelCabecera.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents lstEncontrados As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtProducto As System.Windows.Forms.TextBox
    Friend WithEvents lstArticulos As System.Windows.Forms.ListView
    Friend WithEvents Cantidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents Articulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents Valor As System.Windows.Forms.ColumnHeader
    Friend WithEvents Total As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btncerrar As System.Windows.Forms.Button
    Friend WithEvents PanelCabecera As System.Windows.Forms.Panel
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents chkReferencia As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents chkNombre As System.Windows.Forms.CheckBox
    Friend WithEvents txtRegistrar As System.Windows.Forms.Button
End Class
