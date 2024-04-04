<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsentimientosCPO
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsentimientosCPO))
        Me.PanelCabecera = New System.Windows.Forms.Panel()
        Me.btncerrar = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtDocumento = New System.Windows.Forms.TextBox()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btn_acidoReticulado = New System.Windows.Forms.Button()
        Me.btn_espiculados = New System.Windows.Forms.Button()
        Me.btn_hilosLisos = New System.Windows.Forms.Button()
        Me.btn_toxinaBotulinica = New System.Windows.Forms.Button()
        Me.btn_hialuronidasa = New System.Windows.Forms.Button()
        Me.btn_acidoL = New System.Windows.Forms.Button()
        Me.btn_hidroxiapatita = New System.Windows.Forms.Button()
        Me.PanelCabecera.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelCabecera
        '
        Me.PanelCabecera.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.PanelCabecera.Controls.Add(Me.btncerrar)
        Me.PanelCabecera.Controls.Add(Me.Label6)
        Me.PanelCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelCabecera.Location = New System.Drawing.Point(0, 0)
        Me.PanelCabecera.Name = "PanelCabecera"
        Me.PanelCabecera.Size = New System.Drawing.Size(935, 30)
        Me.PanelCabecera.TabIndex = 53
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
        Me.btncerrar.Location = New System.Drawing.Point(905, 0)
        Me.btncerrar.Name = "btncerrar"
        Me.btncerrar.Size = New System.Drawing.Size(30, 30)
        Me.btncerrar.TabIndex = 3
        Me.btncerrar.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label6.Location = New System.Drawing.Point(381, 2)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(144, 23)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Consentimientos"
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.txtDocumento)
        Me.Panel1.Controls.Add(Me.lblCliente)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.btn_acidoReticulado)
        Me.Panel1.Controls.Add(Me.btn_espiculados)
        Me.Panel1.Controls.Add(Me.btn_hilosLisos)
        Me.Panel1.Controls.Add(Me.btn_toxinaBotulinica)
        Me.Panel1.Controls.Add(Me.btn_hialuronidasa)
        Me.Panel1.Controls.Add(Me.btn_acidoL)
        Me.Panel1.Controls.Add(Me.btn_hidroxiapatita)
        Me.Panel1.Location = New System.Drawing.Point(12, 36)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(911, 453)
        Me.Panel1.TabIndex = 54
        '
        'txtDocumento
        '
        Me.txtDocumento.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDocumento.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDocumento.Location = New System.Drawing.Point(102, 29)
        Me.txtDocumento.Name = "txtDocumento"
        Me.txtDocumento.Size = New System.Drawing.Size(248, 26)
        Me.txtDocumento.TabIndex = 50
        Me.txtDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblCliente
        '
        Me.lblCliente.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.Location = New System.Drawing.Point(456, 29)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(429, 23)
        Me.lblCliente.TabIndex = 51
        Me.lblCliente.Text = "Usuario"
        Me.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(24, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(360, 54)
        Me.PictureBox1.TabIndex = 52
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(404, 16)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(500, 50)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 53
        Me.PictureBox2.TabStop = False
        '
        'btn_acidoReticulado
        '
        Me.btn_acidoReticulado.BackColor = System.Drawing.Color.White
        Me.btn_acidoReticulado.FlatAppearance.BorderSize = 0
        Me.btn_acidoReticulado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btn_acidoReticulado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_acidoReticulado.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_acidoReticulado.Image = CType(resources.GetObject("btn_acidoReticulado.Image"), System.Drawing.Image)
        Me.btn_acidoReticulado.Location = New System.Drawing.Point(289, 342)
        Me.btn_acidoReticulado.Name = "btn_acidoReticulado"
        Me.btn_acidoReticulado.Size = New System.Drawing.Size(329, 75)
        Me.btn_acidoReticulado.TabIndex = 6
        Me.btn_acidoReticulado.Text = "ACIDO HIALURONICO RETICULADO"
        Me.btn_acidoReticulado.UseVisualStyleBackColor = False
        '
        'btn_espiculados
        '
        Me.btn_espiculados.BackColor = System.Drawing.Color.White
        Me.btn_espiculados.FlatAppearance.BorderSize = 0
        Me.btn_espiculados.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btn_espiculados.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_espiculados.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_espiculados.Image = CType(resources.GetObject("btn_espiculados.Image"), System.Drawing.Image)
        Me.btn_espiculados.Location = New System.Drawing.Point(461, 261)
        Me.btn_espiculados.Name = "btn_espiculados"
        Me.btn_espiculados.Size = New System.Drawing.Size(329, 75)
        Me.btn_espiculados.TabIndex = 5
        Me.btn_espiculados.Text = "HILOS ESPICULADOS DE POLIDIOXANONA"
        Me.btn_espiculados.UseVisualStyleBackColor = False
        '
        'btn_hilosLisos
        '
        Me.btn_hilosLisos.BackColor = System.Drawing.Color.White
        Me.btn_hilosLisos.FlatAppearance.BorderSize = 0
        Me.btn_hilosLisos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btn_hilosLisos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_hilosLisos.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_hilosLisos.Image = CType(resources.GetObject("btn_hilosLisos.Image"), System.Drawing.Image)
        Me.btn_hilosLisos.Location = New System.Drawing.Point(461, 180)
        Me.btn_hilosLisos.Name = "btn_hilosLisos"
        Me.btn_hilosLisos.Size = New System.Drawing.Size(329, 75)
        Me.btn_hilosLisos.TabIndex = 4
        Me.btn_hilosLisos.Text = "HILOS LISOS DE POLIDIOZANONA"
        Me.btn_hilosLisos.UseVisualStyleBackColor = False
        '
        'btn_toxinaBotulinica
        '
        Me.btn_toxinaBotulinica.BackColor = System.Drawing.Color.White
        Me.btn_toxinaBotulinica.FlatAppearance.BorderSize = 0
        Me.btn_toxinaBotulinica.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btn_toxinaBotulinica.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_toxinaBotulinica.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_toxinaBotulinica.Image = CType(resources.GetObject("btn_toxinaBotulinica.Image"), System.Drawing.Image)
        Me.btn_toxinaBotulinica.Location = New System.Drawing.Point(461, 99)
        Me.btn_toxinaBotulinica.Name = "btn_toxinaBotulinica"
        Me.btn_toxinaBotulinica.Size = New System.Drawing.Size(329, 75)
        Me.btn_toxinaBotulinica.TabIndex = 3
        Me.btn_toxinaBotulinica.Text = "TOXINA BOTULÍNICA TIPO A"
        Me.btn_toxinaBotulinica.UseVisualStyleBackColor = False
        '
        'btn_hialuronidasa
        '
        Me.btn_hialuronidasa.BackColor = System.Drawing.Color.White
        Me.btn_hialuronidasa.FlatAppearance.BorderSize = 0
        Me.btn_hialuronidasa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btn_hialuronidasa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_hialuronidasa.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_hialuronidasa.Image = CType(resources.GetObject("btn_hialuronidasa.Image"), System.Drawing.Image)
        Me.btn_hialuronidasa.Location = New System.Drawing.Point(84, 261)
        Me.btn_hialuronidasa.Name = "btn_hialuronidasa"
        Me.btn_hialuronidasa.Size = New System.Drawing.Size(329, 75)
        Me.btn_hialuronidasa.TabIndex = 2
        Me.btn_hialuronidasa.Text = "HIALURONIDASA PARA DEGRADACIÓN"
        Me.btn_hialuronidasa.UseVisualStyleBackColor = False
        '
        'btn_acidoL
        '
        Me.btn_acidoL.BackColor = System.Drawing.Color.White
        Me.btn_acidoL.FlatAppearance.BorderSize = 0
        Me.btn_acidoL.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btn_acidoL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_acidoL.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_acidoL.Image = CType(resources.GetObject("btn_acidoL.Image"), System.Drawing.Image)
        Me.btn_acidoL.Location = New System.Drawing.Point(84, 180)
        Me.btn_acidoL.Name = "btn_acidoL"
        Me.btn_acidoL.Size = New System.Drawing.Size(329, 75)
        Me.btn_acidoL.TabIndex = 1
        Me.btn_acidoL.Text = "ACIDO L-POLILÁCTICO"
        Me.btn_acidoL.UseVisualStyleBackColor = False
        '
        'btn_hidroxiapatita
        '
        Me.btn_hidroxiapatita.BackColor = System.Drawing.Color.White
        Me.btn_hidroxiapatita.FlatAppearance.BorderSize = 0
        Me.btn_hidroxiapatita.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btn_hidroxiapatita.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_hidroxiapatita.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_hidroxiapatita.Image = CType(resources.GetObject("btn_hidroxiapatita.Image"), System.Drawing.Image)
        Me.btn_hidroxiapatita.Location = New System.Drawing.Point(84, 99)
        Me.btn_hidroxiapatita.Name = "btn_hidroxiapatita"
        Me.btn_hidroxiapatita.Size = New System.Drawing.Size(329, 75)
        Me.btn_hidroxiapatita.TabIndex = 0
        Me.btn_hidroxiapatita.Text = "HIDROXIAPATITA DE CALCIO"
        Me.btn_hidroxiapatita.UseVisualStyleBackColor = False
        '
        'ConsentimientosCPO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(935, 503)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PanelCabecera)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ConsentimientosCPO"
        Me.Text = "ConsentimientosCPO"
        Me.PanelCabecera.ResumeLayout(False)
        Me.PanelCabecera.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelCabecera As Panel
    Friend WithEvents btncerrar As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btn_hidroxiapatita As Button
    Friend WithEvents btn_acidoReticulado As Button
    Friend WithEvents btn_espiculados As Button
    Friend WithEvents btn_hilosLisos As Button
    Friend WithEvents btn_toxinaBotulinica As Button
    Friend WithEvents btn_hialuronidasa As Button
    Friend WithEvents btn_acidoL As Button
    Friend WithEvents lblCliente As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents txtDocumento As TextBox
    Friend WithEvents PictureBox2 As PictureBox
End Class
