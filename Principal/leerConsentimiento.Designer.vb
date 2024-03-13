<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class leerConsentimiento
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
    '<System.Diagnostics.DebuggerStepThrough()> _
    'Private Sub InitializeComponent()
    '    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(leerConsentimiento))
    '    Me.btncerrar = New System.Windows.Forms.Button()
    '    Me.PanelCabecera = New System.Windows.Forms.Panel()
    '    Me.verPdf = New AxAcroPDFLib.AxAcroPDF()
    '    Me.PanelCabecera.SuspendLayout()
    '    CType(Me.verPdf, System.ComponentModel.ISupportInitialize).BeginInit()
    '    Me.SuspendLayout()
    '    '
    '    'btncerrar
    '    '
    '    Me.btncerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    '    Me.btncerrar.BackgroundImage = Global.Principal.My.Resources.Resources.cerrar
    '    Me.btncerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    '    Me.btncerrar.FlatAppearance.BorderSize = 0
    '    Me.btncerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
    '    Me.btncerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
    '    Me.btncerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    '    Me.btncerrar.Location = New System.Drawing.Point(761, 0)
    '    Me.btncerrar.Name = "btncerrar"
    '    Me.btncerrar.Size = New System.Drawing.Size(30, 30)
    '    Me.btncerrar.TabIndex = 0
    '    Me.btncerrar.UseVisualStyleBackColor = True
    '    '
    '    'PanelCabecera
    '    '
    '    Me.PanelCabecera.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(70, Byte), Integer))
    '    Me.PanelCabecera.Controls.Add(Me.btncerrar)
    '    Me.PanelCabecera.Dock = System.Windows.Forms.DockStyle.Top
    '    Me.PanelCabecera.Location = New System.Drawing.Point(0, 0)
    '    Me.PanelCabecera.Name = "PanelCabecera"
    '    Me.PanelCabecera.Size = New System.Drawing.Size(806, 30)
    '    Me.PanelCabecera.TabIndex = 35
    '    '
    '    'verPdf
    '    '
    '    Me.verPdf.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
    '        Or System.Windows.Forms.AnchorStyles.Left) _
    '        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    '    Me.verPdf.Enabled = True
    '    Me.verPdf.Location = New System.Drawing.Point(3, 27)
    '    Me.verPdf.Name = "verPdf"
    '    Me.verPdf.OcxState = CType(resources.GetObject("verPdf.OcxState"), System.Windows.Forms.AxHost.State)
    '    Me.verPdf.Size = New System.Drawing.Size(803, 514)
    '    Me.verPdf.TabIndex = 36
    '    '
    '    'leerConsentimiento
    '    '
    '    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    '    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    '    Me.ClientSize = New System.Drawing.Size(806, 544)
    '    Me.Controls.Add(Me.verPdf)
    '    Me.Controls.Add(Me.PanelCabecera)
    '    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
    '    Me.Name = "leerConsentimiento"
    '    Me.Text = "leerConsentimiento"
    '    Me.PanelCabecera.ResumeLayout(False)
    '    CType(Me.verPdf, System.ComponentModel.ISupportInitialize).EndInit()
    '    Me.ResumeLayout(False)

    'End Sub
    'Friend WithEvents btncerrar As System.Windows.Forms.Button
    'Friend WithEvents PanelCabecera As System.Windows.Forms.Panel
    'Friend WithEvents verPdf As AxAcroPDFLib.AxAcroPDF
End Class
