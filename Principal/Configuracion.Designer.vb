<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Configuracion
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
        Me.txtUnidad = New System.Windows.Forms.TextBox()
        Me.chkInforme = New System.Windows.Forms.CheckBox()
        Me.chkEmpleados = New System.Windows.Forms.CheckBox()
        Me.chkIngresoClientes = New System.Windows.Forms.CheckBox()
        Me.chkbloquearDeuda = New System.Windows.Forms.CheckBox()
        Me.txtEntradas = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkAbonos = New System.Windows.Forms.CheckBox()
        Me.chkCongelar = New System.Windows.Forms.CheckBox()
        Me.txtdiascongelados = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chControlHuella = New System.Windows.Forms.CheckBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.cbcImpresion = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtentradascliente = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPuerto = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.OpcionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InsertarReporteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.chkVecesXMes = New System.Windows.Forms.CheckBox()
        Me.chkVariosAbonos = New System.Windows.Forms.CheckBox()
        Me.txtTipopc = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ChkCongeladoFuera = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCondeladoFuera = New System.Windows.Forms.TextBox()
        Me.chkValideConexionOnline = New System.Windows.Forms.CheckBox()
        Me.chkAbonosCalendario = New System.Windows.Forms.CheckBox()
        Me.chkHorarioFormularioIngreso = New System.Windows.Forms.CheckBox()
        Me.chkValidarHorarioIngreso = New System.Windows.Forms.CheckBox()
        Me.chkOcultarDiasAcceso = New System.Windows.Forms.CheckBox()
        Me.chkFormatoDias = New System.Windows.Forms.CheckBox()
        Me.chkFormularioClientespa = New System.Windows.Forms.CheckBox()
        Me.chkCongelarconAdmin = New System.Windows.Forms.CheckBox()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(247, 236)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Unidad:"
        '
        'txtUnidad
        '
        Me.txtUnidad.Location = New System.Drawing.Point(303, 236)
        Me.txtUnidad.Name = "txtUnidad"
        Me.txtUnidad.Size = New System.Drawing.Size(121, 20)
        Me.txtUnidad.TabIndex = 1
        '
        'chkInforme
        '
        Me.chkInforme.AutoSize = True
        Me.chkInforme.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkInforme.Location = New System.Drawing.Point(38, 237)
        Me.chkInforme.Name = "chkInforme"
        Me.chkInforme.Size = New System.Drawing.Size(170, 19)
        Me.chkInforme.TabIndex = 2
        Me.chkInforme.Text = "Enviar informe de reportes"
        Me.chkInforme.UseVisualStyleBackColor = True
        '
        'chkEmpleados
        '
        Me.chkEmpleados.AutoSize = True
        Me.chkEmpleados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEmpleados.Location = New System.Drawing.Point(38, 132)
        Me.chkEmpleados.Name = "chkEmpleados"
        Me.chkEmpleados.Size = New System.Drawing.Size(149, 19)
        Me.chkEmpleados.TabIndex = 3
        Me.chkEmpleados.Text = "Ingreso de empleados"
        Me.chkEmpleados.UseVisualStyleBackColor = True
        '
        'chkIngresoClientes
        '
        Me.chkIngresoClientes.AutoSize = True
        Me.chkIngresoClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIngresoClientes.Location = New System.Drawing.Point(38, 168)
        Me.chkIngresoClientes.Name = "chkIngresoClientes"
        Me.chkIngresoClientes.Size = New System.Drawing.Size(129, 19)
        Me.chkIngresoClientes.TabIndex = 4
        Me.chkIngresoClientes.Text = "Ingreso de clientes"
        Me.chkIngresoClientes.UseVisualStyleBackColor = True
        '
        'chkbloquearDeuda
        '
        Me.chkbloquearDeuda.AutoSize = True
        Me.chkbloquearDeuda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkbloquearDeuda.Location = New System.Drawing.Point(38, 95)
        Me.chkbloquearDeuda.Name = "chkbloquearDeuda"
        Me.chkbloquearDeuda.Size = New System.Drawing.Size(184, 19)
        Me.chkbloquearDeuda.TabIndex = 5
        Me.chkbloquearDeuda.Text = "Bloquear Clientes con deuda"
        Me.chkbloquearDeuda.UseVisualStyleBackColor = True
        '
        'txtEntradas
        '
        Me.txtEntradas.Location = New System.Drawing.Point(391, 95)
        Me.txtEntradas.Name = "txtEntradas"
        Me.txtEntradas.Size = New System.Drawing.Size(33, 20)
        Me.txtEntradas.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(247, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 15)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Entradas:"
        '
        'chkAbonos
        '
        Me.chkAbonos.AutoSize = True
        Me.chkAbonos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAbonos.Location = New System.Drawing.Point(38, 203)
        Me.chkAbonos.Name = "chkAbonos"
        Me.chkAbonos.Size = New System.Drawing.Size(125, 19)
        Me.chkAbonos.TabIndex = 8
        Me.chkAbonos.Text = "Pago con abonos:"
        Me.chkAbonos.UseVisualStyleBackColor = True
        '
        'chkCongelar
        '
        Me.chkCongelar.AutoSize = True
        Me.chkCongelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCongelar.Location = New System.Drawing.Point(38, 34)
        Me.chkCongelar.Name = "chkCongelar"
        Me.chkCongelar.Size = New System.Drawing.Size(121, 19)
        Me.chkCongelar.TabIndex = 9
        Me.chkCongelar.Text = "Congelar clientes"
        Me.chkCongelar.UseVisualStyleBackColor = True
        '
        'txtdiascongelados
        '
        Me.txtdiascongelados.Location = New System.Drawing.Point(391, 33)
        Me.txtdiascongelados.Name = "txtdiascongelados"
        Me.txtdiascongelados.Size = New System.Drawing.Size(33, 20)
        Me.txtdiascongelados.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(247, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(138, 15)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Dias min para congelar:"
        '
        'chControlHuella
        '
        Me.chControlHuella.AutoSize = True
        Me.chControlHuella.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chControlHuella.Location = New System.Drawing.Point(38, 271)
        Me.chControlHuella.Name = "chControlHuella"
        Me.chControlHuella.Size = New System.Drawing.Size(148, 19)
        Me.chControlHuella.TabIndex = 14
        Me.chControlHuella.Text = "Usar control de Huella"
        Me.chControlHuella.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.ForeColor = System.Drawing.Color.Blue
        Me.btnGuardar.Location = New System.Drawing.Point(502, 342)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(124, 23)
        Me.btnGuardar.TabIndex = 15
        Me.btnGuardar.Text = "Guardar Cambios"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'cbcImpresion
        '
        Me.cbcImpresion.FormattingEnabled = True
        Me.cbcImpresion.Items.AddRange(New Object() {"No Imprimir", "Preguntar Para Imprimir", "Imprimir Siempre"})
        Me.cbcImpresion.Location = New System.Drawing.Point(303, 201)
        Me.cbcImpresion.Name = "cbcImpresion"
        Me.cbcImpresion.Size = New System.Drawing.Size(121, 21)
        Me.cbcImpresion.TabIndex = 16
        Me.cbcImpresion.Text = "Seleccione:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(238, 204)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 15)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Impresion:"
        '
        'txtentradascliente
        '
        Me.txtentradascliente.Location = New System.Drawing.Point(391, 167)
        Me.txtentradascliente.Name = "txtentradascliente"
        Me.txtentradascliente.Size = New System.Drawing.Size(33, 20)
        Me.txtentradascliente.TabIndex = 19
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(244, 172)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 15)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Entradas:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(247, 133)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 15)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Puerto:"
        '
        'txtPuerto
        '
        Me.txtPuerto.Location = New System.Drawing.Point(391, 132)
        Me.txtPuerto.Name = "txtPuerto"
        Me.txtPuerto.Size = New System.Drawing.Size(33, 20)
        Me.txtPuerto.TabIndex = 21
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpcionesToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(672, 24)
        Me.MenuStrip1.TabIndex = 22
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'OpcionesToolStripMenuItem
        '
        Me.OpcionesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InsertarReporteToolStripMenuItem})
        Me.OpcionesToolStripMenuItem.Name = "OpcionesToolStripMenuItem"
        Me.OpcionesToolStripMenuItem.Size = New System.Drawing.Size(69, 20)
        Me.OpcionesToolStripMenuItem.Text = "Opciones"
        '
        'InsertarReporteToolStripMenuItem
        '
        Me.InsertarReporteToolStripMenuItem.Name = "InsertarReporteToolStripMenuItem"
        Me.InsertarReporteToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.InsertarReporteToolStripMenuItem.Text = "Insertar Reporte"
        '
        'chkVecesXMes
        '
        Me.chkVecesXMes.AutoSize = True
        Me.chkVecesXMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkVecesXMes.Location = New System.Drawing.Point(454, 34)
        Me.chkVecesXMes.Name = "chkVecesXMes"
        Me.chkVecesXMes.Size = New System.Drawing.Size(169, 19)
        Me.chkVecesXMes.TabIndex = 23
        Me.chkVecesXMes.Text = "Congelar una vez por mes"
        Me.chkVecesXMes.UseVisualStyleBackColor = True
        '
        'chkVariosAbonos
        '
        Me.chkVariosAbonos.AutoSize = True
        Me.chkVariosAbonos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkVariosAbonos.Location = New System.Drawing.Point(38, 308)
        Me.chkVariosAbonos.Name = "chkVariosAbonos"
        Me.chkVariosAbonos.Size = New System.Drawing.Size(148, 19)
        Me.chkVariosAbonos.TabIndex = 24
        Me.chkVariosAbonos.Text = "Permitir varios abonos"
        Me.chkVariosAbonos.UseVisualStyleBackColor = True
        '
        'txtTipopc
        '
        Me.txtTipopc.Location = New System.Drawing.Point(303, 271)
        Me.txtTipopc.Name = "txtTipopc"
        Me.txtTipopc.Size = New System.Drawing.Size(121, 20)
        Me.txtTipopc.TabIndex = 26
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(247, 271)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 15)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Tipo pc:"
        '
        'ChkCongeladoFuera
        '
        Me.ChkCongeladoFuera.AutoSize = True
        Me.ChkCongeladoFuera.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkCongeladoFuera.Location = New System.Drawing.Point(38, 63)
        Me.ChkCongeladoFuera.Name = "ChkCongeladoFuera"
        Me.ChkCongeladoFuera.Size = New System.Drawing.Size(172, 19)
        Me.ChkCongeladoFuera.TabIndex = 27
        Me.ChkCongeladoFuera.Text = "Restringir dias congelados"
        Me.ChkCongeladoFuera.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(247, 64)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(124, 15)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "Dias max para volver:"
        '
        'txtCondeladoFuera
        '
        Me.txtCondeladoFuera.Location = New System.Drawing.Point(391, 62)
        Me.txtCondeladoFuera.Name = "txtCondeladoFuera"
        Me.txtCondeladoFuera.Size = New System.Drawing.Size(33, 20)
        Me.txtCondeladoFuera.TabIndex = 29
        '
        'chkValideConexionOnline
        '
        Me.chkValideConexionOnline.AutoSize = True
        Me.chkValideConexionOnline.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkValideConexionOnline.Location = New System.Drawing.Point(38, 342)
        Me.chkValideConexionOnline.Name = "chkValideConexionOnline"
        Me.chkValideConexionOnline.Size = New System.Drawing.Size(158, 19)
        Me.chkValideConexionOnline.TabIndex = 30
        Me.chkValideConexionOnline.Text = "Validar Conexion Online"
        Me.chkValideConexionOnline.UseVisualStyleBackColor = True
        '
        'chkAbonosCalendario
        '
        Me.chkAbonosCalendario.AutoSize = True
        Me.chkAbonosCalendario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAbonosCalendario.Location = New System.Drawing.Point(250, 308)
        Me.chkAbonosCalendario.Name = "chkAbonosCalendario"
        Me.chkAbonosCalendario.Size = New System.Drawing.Size(152, 19)
        Me.chkAbonosCalendario.TabIndex = 31
        Me.chkAbonosCalendario.Text = "Abonos Por Calendario"
        Me.chkAbonosCalendario.UseVisualStyleBackColor = True
        '
        'chkHorarioFormularioIngreso
        '
        Me.chkHorarioFormularioIngreso.AutoSize = True
        Me.chkHorarioFormularioIngreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkHorarioFormularioIngreso.Location = New System.Drawing.Point(250, 342)
        Me.chkHorarioFormularioIngreso.Name = "chkHorarioFormularioIngreso"
        Me.chkHorarioFormularioIngreso.Size = New System.Drawing.Size(208, 19)
        Me.chkHorarioFormularioIngreso.TabIndex = 32
        Me.chkHorarioFormularioIngreso.Text = "Horario en Formulario de Ingreso"
        Me.chkHorarioFormularioIngreso.UseVisualStyleBackColor = True
        '
        'chkValidarHorarioIngreso
        '
        Me.chkValidarHorarioIngreso.AutoSize = True
        Me.chkValidarHorarioIngreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkValidarHorarioIngreso.Location = New System.Drawing.Point(454, 63)
        Me.chkValidarHorarioIngreso.Name = "chkValidarHorarioIngreso"
        Me.chkValidarHorarioIngreso.Size = New System.Drawing.Size(172, 19)
        Me.chkValidarHorarioIngreso.TabIndex = 33
        Me.chkValidarHorarioIngreso.Text = "Validar Horario de Ingreso "
        Me.chkValidarHorarioIngreso.UseVisualStyleBackColor = True
        '
        'chkOcultarDiasAcceso
        '
        Me.chkOcultarDiasAcceso.AutoSize = True
        Me.chkOcultarDiasAcceso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkOcultarDiasAcceso.Location = New System.Drawing.Point(38, 373)
        Me.chkOcultarDiasAcceso.Name = "chkOcultarDiasAcceso"
        Me.chkOcultarDiasAcceso.Size = New System.Drawing.Size(163, 19)
        Me.chkOcultarDiasAcceso.TabIndex = 34
        Me.chkOcultarDiasAcceso.Text = "Ocultar Dias form Acceso"
        Me.chkOcultarDiasAcceso.UseVisualStyleBackColor = True
        '
        'chkFormatoDias
        '
        Me.chkFormatoDias.AutoSize = True
        Me.chkFormatoDias.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFormatoDias.Location = New System.Drawing.Point(250, 373)
        Me.chkFormatoDias.Name = "chkFormatoDias"
        Me.chkFormatoDias.Size = New System.Drawing.Size(162, 19)
        Me.chkFormatoDias.TabIndex = 35
        Me.chkFormatoDias.Text = "Controlar Dias por Fecha"
        Me.chkFormatoDias.UseVisualStyleBackColor = True
        '
        'chkFormularioClientespa
        '
        Me.chkFormularioClientespa.AutoSize = True
        Me.chkFormularioClientespa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFormularioClientespa.Location = New System.Drawing.Point(454, 95)
        Me.chkFormularioClientespa.Name = "chkFormularioClientespa"
        Me.chkFormularioClientespa.Size = New System.Drawing.Size(167, 19)
        Me.chkFormularioClientespa.TabIndex = 36
        Me.chkFormularioClientespa.Text = "Formulario de cliente Spa"
        Me.chkFormularioClientespa.UseVisualStyleBackColor = True
        '
        'chkCongelarconAdmin
        '
        Me.chkCongelarconAdmin.AutoSize = True
        Me.chkCongelarconAdmin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCongelarconAdmin.Location = New System.Drawing.Point(454, 133)
        Me.chkCongelarconAdmin.Name = "chkCongelarconAdmin"
        Me.chkCongelarconAdmin.Size = New System.Drawing.Size(168, 19)
        Me.chkCongelarconAdmin.TabIndex = 37
        Me.chkCongelarconAdmin.Text = "Congelar con clave admin"
        Me.chkCongelarconAdmin.UseVisualStyleBackColor = True
        '
        'Configuracion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(672, 416)
        Me.Controls.Add(Me.chkCongelarconAdmin)
        Me.Controls.Add(Me.chkFormularioClientespa)
        Me.Controls.Add(Me.chkFormatoDias)
        Me.Controls.Add(Me.chkOcultarDiasAcceso)
        Me.Controls.Add(Me.chkValidarHorarioIngreso)
        Me.Controls.Add(Me.chkHorarioFormularioIngreso)
        Me.Controls.Add(Me.chkAbonosCalendario)
        Me.Controls.Add(Me.chkValideConexionOnline)
        Me.Controls.Add(Me.txtCondeladoFuera)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.ChkCongeladoFuera)
        Me.Controls.Add(Me.txtTipopc)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.chkVariosAbonos)
        Me.Controls.Add(Me.chkVecesXMes)
        Me.Controls.Add(Me.txtPuerto)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtentradascliente)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cbcImpresion)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.chControlHuella)
        Me.Controls.Add(Me.txtdiascongelados)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.chkCongelar)
        Me.Controls.Add(Me.chkAbonos)
        Me.Controls.Add(Me.txtEntradas)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.chkbloquearDeuda)
        Me.Controls.Add(Me.chkIngresoClientes)
        Me.Controls.Add(Me.chkEmpleados)
        Me.Controls.Add(Me.chkInforme)
        Me.Controls.Add(Me.txtUnidad)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Configuracion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuracion"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtUnidad As System.Windows.Forms.TextBox
    Friend WithEvents chkInforme As System.Windows.Forms.CheckBox
    Friend WithEvents chkEmpleados As System.Windows.Forms.CheckBox
    Friend WithEvents chkIngresoClientes As System.Windows.Forms.CheckBox
    Friend WithEvents chkbloquearDeuda As System.Windows.Forms.CheckBox
    Friend WithEvents txtEntradas As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkAbonos As System.Windows.Forms.CheckBox
    Friend WithEvents chkCongelar As System.Windows.Forms.CheckBox
    Friend WithEvents txtdiascongelados As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chControlHuella As System.Windows.Forms.CheckBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents cbcImpresion As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtentradascliente As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPuerto As System.Windows.Forms.TextBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents OpcionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InsertarReporteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkVecesXMes As System.Windows.Forms.CheckBox
    Friend WithEvents chkVariosAbonos As System.Windows.Forms.CheckBox
    Friend WithEvents txtTipopc As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ChkCongeladoFuera As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCondeladoFuera As System.Windows.Forms.TextBox
    Friend WithEvents chkValideConexionOnline As System.Windows.Forms.CheckBox
    Friend WithEvents chkAbonosCalendario As System.Windows.Forms.CheckBox
    Friend WithEvents chkHorarioFormularioIngreso As System.Windows.Forms.CheckBox
    Friend WithEvents chkValidarHorarioIngreso As System.Windows.Forms.CheckBox
    Friend WithEvents chkOcultarDiasAcceso As System.Windows.Forms.CheckBox
    Friend WithEvents chkFormatoDias As System.Windows.Forms.CheckBox
    Friend WithEvents chkFormularioClientespa As CheckBox
    Friend WithEvents chkCongelarconAdmin As CheckBox
End Class
