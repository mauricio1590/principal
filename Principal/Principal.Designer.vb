<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Principal
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Principal))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnCongelar = New System.Windows.Forms.ToolStripMenuItem()
        Me.CongelarClienteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DescongelarClienteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.HistorialDeClienteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TipoGastoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResgistroDeMedidasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IngresosDeMensualidadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuPersonalzado = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuHorarios = New System.Windows.Forms.ToolStripMenuItem()
        Me.IngresoPorUsuRIO = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistroDeTemperaturaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RepararHuellaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnviarMensajeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TarifasNoConglablesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PruebaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopiaDeSeguridadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VentasDetalladoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InasistenciaDeUsuariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HistorialDeSaldoDeVentasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistrarProductoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteDeASaldosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AjusteDeInventarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ElimineFacturaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfiguracionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RutaDeFotosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DescargarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CajaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ArqueoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ArqueoVentasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ArqueoSpaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TemporalesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompensarDiasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SolucionAProblemasConocidosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProblemaConLaHuellaEnElAccesoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DRAJULIAMENESESToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HIDROXIAPATITADECALCIOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PanelCabecera = New System.Windows.Forms.Panel()
        Me.btnrestaurar = New System.Windows.Forms.Button()
        Me.btnminimizar = New System.Windows.Forms.Button()
        Me.btnmaximizar = New System.Windows.Forms.Button()
        Me.btncerrar = New System.Windows.Forms.Button()
        Me.TimerMostrar = New System.Windows.Forms.Timer(Me.components)
        Me.Panelmenu = New System.Windows.Forms.Panel()
        Me.logosistem = New System.Windows.Forms.PictureBox()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnReporte = New System.Windows.Forms.Button()
        Me.btnCliente = New System.Windows.Forms.Button()
        Me.btnventas = New System.Windows.Forms.Button()
        Me.btnEmpleados = New System.Windows.Forms.Button()
        Me.btnMedidas = New System.Windows.Forms.Button()
        Me.btnPago = New System.Windows.Forms.Button()
        Me.btnGastos = New System.Windows.Forms.Button()
        Me.Bntmenu = New System.Windows.Forms.PictureBox()
        Me.PanelContenedor = New System.Windows.Forms.Panel()
        Me.lblDescongelados = New System.Windows.Forms.Label()
        Me.lblLicencia = New System.Windows.Forms.Label()
        Me.piclogo = New System.Windows.Forms.PictureBox()
        Me.TimerOcultar = New System.Windows.Forms.Timer(Me.components)
        Me.timerLog = New System.Windows.Forms.Timer(Me.components)
        Me.timerCongelados = New System.Windows.Forms.Timer(Me.components)
        Me.timerDescongelados = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.PanelCabecera.SuspendLayout()
        Me.Panelmenu.SuspendLayout()
        CType(Me.logosistem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Bntmenu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelContenedor.SuspendLayout()
        CType(Me.piclogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.HighlightText
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnCongelar, Me.ProductosToolStripMenuItem, Me.ConfiguracionToolStripMenuItem, Me.CajaToolStripMenuItem, Me.TemporalesToolStripMenuItem, Me.AyudaToolStripMenuItem, Me.DRAJULIAMENESESToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1219, 25)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnCongelar
        '
        Me.mnCongelar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CongelarClienteToolStripMenuItem, Me.DescongelarClienteToolStripMenuItem, Me.ToolStripMenuItem2, Me.HistorialDeClienteToolStripMenuItem, Me.ToolStripMenuItem3, Me.TipoGastoToolStripMenuItem, Me.ResgistroDeMedidasToolStripMenuItem, Me.IngresosDeMensualidadToolStripMenuItem, Me.menuPersonalzado, Me.menuHorarios, Me.IngresoPorUsuRIO, Me.RegistroDeTemperaturaToolStripMenuItem, Me.RepararHuellaToolStripMenuItem, Me.EnviarMensajeToolStripMenuItem, Me.TarifasNoConglablesToolStripMenuItem, Me.PruebaToolStripMenuItem, Me.CopiaDeSeguridadToolStripMenuItem, Me.VentasDetalladoToolStripMenuItem, Me.InasistenciaDeUsuariosToolStripMenuItem, Me.HistorialDeSaldoDeVentasToolStripMenuItem})
        Me.mnCongelar.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnCongelar.Name = "mnCongelar"
        Me.mnCongelar.Size = New System.Drawing.Size(75, 21)
        Me.mnCongelar.Text = "Opciones"
        '
        'CongelarClienteToolStripMenuItem
        '
        Me.CongelarClienteToolStripMenuItem.Name = "CongelarClienteToolStripMenuItem"
        Me.CongelarClienteToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
        Me.CongelarClienteToolStripMenuItem.Size = New System.Drawing.Size(323, 22)
        Me.CongelarClienteToolStripMenuItem.Text = "Congelar cliente"
        '
        'DescongelarClienteToolStripMenuItem
        '
        Me.DescongelarClienteToolStripMenuItem.Name = "DescongelarClienteToolStripMenuItem"
        Me.DescongelarClienteToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.DescongelarClienteToolStripMenuItem.Size = New System.Drawing.Size(323, 22)
        Me.DescongelarClienteToolStripMenuItem.Text = "Descongelar cliente"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(323, 22)
        Me.ToolStripMenuItem2.Text = "Cumpleaños"
        '
        'HistorialDeClienteToolStripMenuItem
        '
        Me.HistorialDeClienteToolStripMenuItem.Name = "HistorialDeClienteToolStripMenuItem"
        Me.HistorialDeClienteToolStripMenuItem.Size = New System.Drawing.Size(323, 22)
        Me.HistorialDeClienteToolStripMenuItem.Text = "Historial de Cliente"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(323, 22)
        Me.ToolStripMenuItem3.Text = "Tipo Gasto"
        '
        'TipoGastoToolStripMenuItem
        '
        Me.TipoGastoToolStripMenuItem.Name = "TipoGastoToolStripMenuItem"
        Me.TipoGastoToolStripMenuItem.Size = New System.Drawing.Size(323, 22)
        Me.TipoGastoToolStripMenuItem.Text = "Bancos"
        '
        'ResgistroDeMedidasToolStripMenuItem
        '
        Me.ResgistroDeMedidasToolStripMenuItem.Name = "ResgistroDeMedidasToolStripMenuItem"
        Me.ResgistroDeMedidasToolStripMenuItem.Size = New System.Drawing.Size(323, 22)
        Me.ResgistroDeMedidasToolStripMenuItem.Text = "Resgistro de Medidas"
        '
        'IngresosDeMensualidadToolStripMenuItem
        '
        Me.IngresosDeMensualidadToolStripMenuItem.Name = "IngresosDeMensualidadToolStripMenuItem"
        Me.IngresosDeMensualidadToolStripMenuItem.Size = New System.Drawing.Size(323, 22)
        Me.IngresosDeMensualidadToolStripMenuItem.Text = "Ingresos de Mensualidad"
        '
        'menuPersonalzado
        '
        Me.menuPersonalzado.Name = "menuPersonalzado"
        Me.menuPersonalzado.Size = New System.Drawing.Size(323, 22)
        Me.menuPersonalzado.Text = "Personalilzados"
        '
        'menuHorarios
        '
        Me.menuHorarios.Name = "menuHorarios"
        Me.menuHorarios.Size = New System.Drawing.Size(323, 22)
        Me.menuHorarios.Text = "Horarios"
        '
        'IngresoPorUsuRIO
        '
        Me.IngresoPorUsuRIO.Name = "IngresoPorUsuRIO"
        Me.IngresoPorUsuRIO.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F5), System.Windows.Forms.Keys)
        Me.IngresoPorUsuRIO.Size = New System.Drawing.Size(323, 22)
        Me.IngresoPorUsuRIO.Text = "Detalles de asistencia por usuario"
        '
        'RegistroDeTemperaturaToolStripMenuItem
        '
        Me.RegistroDeTemperaturaToolStripMenuItem.Name = "RegistroDeTemperaturaToolStripMenuItem"
        Me.RegistroDeTemperaturaToolStripMenuItem.Size = New System.Drawing.Size(323, 22)
        Me.RegistroDeTemperaturaToolStripMenuItem.Text = "Registro de temperatura"
        '
        'RepararHuellaToolStripMenuItem
        '
        Me.RepararHuellaToolStripMenuItem.Name = "RepararHuellaToolStripMenuItem"
        Me.RepararHuellaToolStripMenuItem.Size = New System.Drawing.Size(323, 22)
        Me.RepararHuellaToolStripMenuItem.Text = "Reparar Huella"
        '
        'EnviarMensajeToolStripMenuItem
        '
        Me.EnviarMensajeToolStripMenuItem.Enabled = False
        Me.EnviarMensajeToolStripMenuItem.Name = "EnviarMensajeToolStripMenuItem"
        Me.EnviarMensajeToolStripMenuItem.Size = New System.Drawing.Size(323, 22)
        Me.EnviarMensajeToolStripMenuItem.Text = "Enviar Mensaje"
        '
        'TarifasNoConglablesToolStripMenuItem
        '
        Me.TarifasNoConglablesToolStripMenuItem.Name = "TarifasNoConglablesToolStripMenuItem"
        Me.TarifasNoConglablesToolStripMenuItem.Size = New System.Drawing.Size(323, 22)
        Me.TarifasNoConglablesToolStripMenuItem.Text = "Tarifas No Conglables"
        '
        'PruebaToolStripMenuItem
        '
        Me.PruebaToolStripMenuItem.Name = "PruebaToolStripMenuItem"
        Me.PruebaToolStripMenuItem.Size = New System.Drawing.Size(323, 22)
        Me.PruebaToolStripMenuItem.Text = "Proximos a vencer"
        '
        'CopiaDeSeguridadToolStripMenuItem
        '
        Me.CopiaDeSeguridadToolStripMenuItem.Name = "CopiaDeSeguridadToolStripMenuItem"
        Me.CopiaDeSeguridadToolStripMenuItem.Size = New System.Drawing.Size(323, 22)
        Me.CopiaDeSeguridadToolStripMenuItem.Text = "Copia de Seguridad"
        '
        'VentasDetalladoToolStripMenuItem
        '
        Me.VentasDetalladoToolStripMenuItem.Name = "VentasDetalladoToolStripMenuItem"
        Me.VentasDetalladoToolStripMenuItem.Size = New System.Drawing.Size(323, 22)
        Me.VentasDetalladoToolStripMenuItem.Text = "Ventas Detallado"
        '
        'InasistenciaDeUsuariosToolStripMenuItem
        '
        Me.InasistenciaDeUsuariosToolStripMenuItem.Name = "InasistenciaDeUsuariosToolStripMenuItem"
        Me.InasistenciaDeUsuariosToolStripMenuItem.Size = New System.Drawing.Size(323, 22)
        Me.InasistenciaDeUsuariosToolStripMenuItem.Text = "Inasistencia de usuarios"
        '
        'HistorialDeSaldoDeVentasToolStripMenuItem
        '
        Me.HistorialDeSaldoDeVentasToolStripMenuItem.Name = "HistorialDeSaldoDeVentasToolStripMenuItem"
        Me.HistorialDeSaldoDeVentasToolStripMenuItem.Size = New System.Drawing.Size(323, 22)
        Me.HistorialDeSaldoDeVentasToolStripMenuItem.Text = "Historial de saldo de ventas "
        '
        'ProductosToolStripMenuItem
        '
        Me.ProductosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegistrarProductoToolStripMenuItem, Me.ReporteDeASaldosToolStripMenuItem, Me.CompraToolStripMenuItem, Me.AjusteDeInventarioToolStripMenuItem, Me.ElimineFacturaToolStripMenuItem})
        Me.ProductosToolStripMenuItem.Name = "ProductosToolStripMenuItem"
        Me.ProductosToolStripMenuItem.Size = New System.Drawing.Size(122, 21)
        Me.ProductosToolStripMenuItem.Text = "Opciones de Ventas"
        '
        'RegistrarProductoToolStripMenuItem
        '
        Me.RegistrarProductoToolStripMenuItem.Name = "RegistrarProductoToolStripMenuItem"
        Me.RegistrarProductoToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.RegistrarProductoToolStripMenuItem.Text = "Registrar Producto"
        '
        'ReporteDeASaldosToolStripMenuItem
        '
        Me.ReporteDeASaldosToolStripMenuItem.Name = "ReporteDeASaldosToolStripMenuItem"
        Me.ReporteDeASaldosToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.ReporteDeASaldosToolStripMenuItem.Text = "Reporte de Saldos"
        '
        'CompraToolStripMenuItem
        '
        Me.CompraToolStripMenuItem.Name = "CompraToolStripMenuItem"
        Me.CompraToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.CompraToolStripMenuItem.Text = "Compra"
        '
        'AjusteDeInventarioToolStripMenuItem
        '
        Me.AjusteDeInventarioToolStripMenuItem.Name = "AjusteDeInventarioToolStripMenuItem"
        Me.AjusteDeInventarioToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.AjusteDeInventarioToolStripMenuItem.Text = "Ajuste de inventario"
        '
        'ElimineFacturaToolStripMenuItem
        '
        Me.ElimineFacturaToolStripMenuItem.Name = "ElimineFacturaToolStripMenuItem"
        Me.ElimineFacturaToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.ElimineFacturaToolStripMenuItem.Text = "Elimine Factura"
        '
        'ConfiguracionToolStripMenuItem
        '
        Me.ConfiguracionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.RutaDeFotosToolStripMenuItem, Me.DescargarToolStripMenuItem})
        Me.ConfiguracionToolStripMenuItem.Name = "ConfiguracionToolStripMenuItem"
        Me.ConfiguracionToolStripMenuItem.Size = New System.Drawing.Size(95, 21)
        Me.ConfiguracionToolStripMenuItem.Text = "Configuracion"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(212, 22)
        Me.ToolStripMenuItem1.Text = "Configuracion del sistema"
        '
        'RutaDeFotosToolStripMenuItem
        '
        Me.RutaDeFotosToolStripMenuItem.Name = "RutaDeFotosToolStripMenuItem"
        Me.RutaDeFotosToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.RutaDeFotosToolStripMenuItem.Text = "Ruta de fotos"
        '
        'DescargarToolStripMenuItem
        '
        Me.DescargarToolStripMenuItem.Name = "DescargarToolStripMenuItem"
        Me.DescargarToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.DescargarToolStripMenuItem.Text = "Descargar Actualizacion"
        '
        'CajaToolStripMenuItem
        '
        Me.CajaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArqueoToolStripMenuItem, Me.ArqueoVentasToolStripMenuItem, Me.ArqueoSpaToolStripMenuItem})
        Me.CajaToolStripMenuItem.Name = "CajaToolStripMenuItem"
        Me.CajaToolStripMenuItem.Size = New System.Drawing.Size(45, 21)
        Me.CajaToolStripMenuItem.Text = "Caja "
        '
        'ArqueoToolStripMenuItem
        '
        Me.ArqueoToolStripMenuItem.Name = "ArqueoToolStripMenuItem"
        Me.ArqueoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F12), System.Windows.Forms.Keys)
        Me.ArqueoToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.ArqueoToolStripMenuItem.Text = "Arqueo"
        '
        'ArqueoVentasToolStripMenuItem
        '
        Me.ArqueoVentasToolStripMenuItem.Name = "ArqueoVentasToolStripMenuItem"
        Me.ArqueoVentasToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F11), System.Windows.Forms.Keys)
        Me.ArqueoVentasToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.ArqueoVentasToolStripMenuItem.Text = "Arqueo ventas"
        '
        'ArqueoSpaToolStripMenuItem
        '
        Me.ArqueoSpaToolStripMenuItem.Name = "ArqueoSpaToolStripMenuItem"
        Me.ArqueoSpaToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.ArqueoSpaToolStripMenuItem.Text = "Arqueo Spa"
        '
        'TemporalesToolStripMenuItem
        '
        Me.TemporalesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CompensarDiasToolStripMenuItem})
        Me.TemporalesToolStripMenuItem.Name = "TemporalesToolStripMenuItem"
        Me.TemporalesToolStripMenuItem.Size = New System.Drawing.Size(79, 21)
        Me.TemporalesToolStripMenuItem.Text = "Temporales"
        '
        'CompensarDiasToolStripMenuItem
        '
        Me.CompensarDiasToolStripMenuItem.Name = "CompensarDiasToolStripMenuItem"
        Me.CompensarDiasToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.CompensarDiasToolStripMenuItem.Text = "Compensar dias "
        '
        'AyudaToolStripMenuItem
        '
        Me.AyudaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SolucionAProblemasConocidosToolStripMenuItem})
        Me.AyudaToolStripMenuItem.Name = "AyudaToolStripMenuItem"
        Me.AyudaToolStripMenuItem.Size = New System.Drawing.Size(53, 21)
        Me.AyudaToolStripMenuItem.Text = "Ayuda"
        '
        'SolucionAProblemasConocidosToolStripMenuItem
        '
        Me.SolucionAProblemasConocidosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProblemaConLaHuellaEnElAccesoToolStripMenuItem})
        Me.SolucionAProblemasConocidosToolStripMenuItem.Name = "SolucionAProblemasConocidosToolStripMenuItem"
        Me.SolucionAProblemasConocidosToolStripMenuItem.Size = New System.Drawing.Size(246, 22)
        Me.SolucionAProblemasConocidosToolStripMenuItem.Text = "Solucion a Problemas conocidos"
        '
        'ProblemaConLaHuellaEnElAccesoToolStripMenuItem
        '
        Me.ProblemaConLaHuellaEnElAccesoToolStripMenuItem.Name = "ProblemaConLaHuellaEnElAccesoToolStripMenuItem"
        Me.ProblemaConLaHuellaEnElAccesoToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
        Me.ProblemaConLaHuellaEnElAccesoToolStripMenuItem.Text = "Problema con la huella en el acceso"
        '
        'DRAJULIAMENESESToolStripMenuItem
        '
        Me.DRAJULIAMENESESToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HIDROXIAPATITADECALCIOToolStripMenuItem})
        Me.DRAJULIAMENESESToolStripMenuItem.Name = "DRAJULIAMENESESToolStripMenuItem"
        Me.DRAJULIAMENESESToolStripMenuItem.Size = New System.Drawing.Size(127, 21)
        Me.DRAJULIAMENESESToolStripMenuItem.Text = "DRA JULIA MENESES"
        '
        'HIDROXIAPATITADECALCIOToolStripMenuItem
        '
        Me.HIDROXIAPATITADECALCIOToolStripMenuItem.Name = "HIDROXIAPATITADECALCIOToolStripMenuItem"
        Me.HIDROXIAPATITADECALCIOToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.HIDROXIAPATITADECALCIOToolStripMenuItem.Text = "HIDROXIAPATITA DE CALCIO"
        '
        'PanelCabecera
        '
        Me.PanelCabecera.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.PanelCabecera.Controls.Add(Me.btnrestaurar)
        Me.PanelCabecera.Controls.Add(Me.btnminimizar)
        Me.PanelCabecera.Controls.Add(Me.btnmaximizar)
        Me.PanelCabecera.Controls.Add(Me.btncerrar)
        Me.PanelCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelCabecera.Location = New System.Drawing.Point(0, 25)
        Me.PanelCabecera.Name = "PanelCabecera"
        Me.PanelCabecera.Size = New System.Drawing.Size(1219, 40)
        Me.PanelCabecera.TabIndex = 2
        '
        'btnrestaurar
        '
        Me.btnrestaurar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnrestaurar.BackgroundImage = CType(resources.GetObject("btnrestaurar.BackgroundImage"), System.Drawing.Image)
        Me.btnrestaurar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnrestaurar.FlatAppearance.BorderSize = 0
        Me.btnrestaurar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnrestaurar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.btnrestaurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnrestaurar.Location = New System.Drawing.Point(1132, 0)
        Me.btnrestaurar.Name = "btnrestaurar"
        Me.btnrestaurar.Size = New System.Drawing.Size(40, 40)
        Me.btnrestaurar.TabIndex = 3
        Me.btnrestaurar.UseVisualStyleBackColor = True
        Me.btnrestaurar.Visible = False
        '
        'btnminimizar
        '
        Me.btnminimizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnminimizar.BackgroundImage = CType(resources.GetObject("btnminimizar.BackgroundImage"), System.Drawing.Image)
        Me.btnminimizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnminimizar.FlatAppearance.BorderSize = 0
        Me.btnminimizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnminimizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.btnminimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnminimizar.Location = New System.Drawing.Point(1084, 0)
        Me.btnminimizar.Name = "btnminimizar"
        Me.btnminimizar.Size = New System.Drawing.Size(40, 40)
        Me.btnminimizar.TabIndex = 2
        Me.btnminimizar.UseVisualStyleBackColor = True
        '
        'btnmaximizar
        '
        Me.btnmaximizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnmaximizar.BackgroundImage = CType(resources.GetObject("btnmaximizar.BackgroundImage"), System.Drawing.Image)
        Me.btnmaximizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnmaximizar.FlatAppearance.BorderSize = 0
        Me.btnmaximizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnmaximizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.btnmaximizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnmaximizar.Location = New System.Drawing.Point(1128, 0)
        Me.btnmaximizar.Name = "btnmaximizar"
        Me.btnmaximizar.Size = New System.Drawing.Size(40, 40)
        Me.btnmaximizar.TabIndex = 1
        Me.btnmaximizar.UseVisualStyleBackColor = True
        '
        'btncerrar
        '
        Me.btncerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btncerrar.BackgroundImage = CType(resources.GetObject("btncerrar.BackgroundImage"), System.Drawing.Image)
        Me.btncerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btncerrar.FlatAppearance.BorderSize = 0
        Me.btncerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btncerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.btncerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncerrar.Location = New System.Drawing.Point(1174, 0)
        Me.btncerrar.Name = "btncerrar"
        Me.btncerrar.Size = New System.Drawing.Size(40, 40)
        Me.btncerrar.TabIndex = 0
        Me.btncerrar.UseVisualStyleBackColor = True
        '
        'TimerMostrar
        '
        Me.TimerMostrar.Interval = 10
        '
        'Panelmenu
        '
        Me.Panelmenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.Panelmenu.Controls.Add(Me.logosistem)
        Me.Panelmenu.Controls.Add(Me.lblVersion)
        Me.Panelmenu.Controls.Add(Me.GroupBox1)
        Me.Panelmenu.Controls.Add(Me.Bntmenu)
        Me.Panelmenu.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panelmenu.Location = New System.Drawing.Point(0, 65)
        Me.Panelmenu.Name = "Panelmenu"
        Me.Panelmenu.Size = New System.Drawing.Size(220, 668)
        Me.Panelmenu.TabIndex = 3
        '
        'logosistem
        '
        Me.logosistem.Location = New System.Drawing.Point(6, 529)
        Me.logosistem.Name = "logosistem"
        Me.logosistem.Size = New System.Drawing.Size(211, 82)
        Me.logosistem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.logosistem.TabIndex = 19
        Me.logosistem.TabStop = False
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.ForeColor = System.Drawing.SystemColors.Window
        Me.lblVersion.Location = New System.Drawing.Point(0, 655)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(39, 13)
        Me.lblVersion.TabIndex = 1
        Me.lblVersion.Text = "Label1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnReporte)
        Me.GroupBox1.Controls.Add(Me.btnCliente)
        Me.GroupBox1.Controls.Add(Me.btnventas)
        Me.GroupBox1.Controls.Add(Me.btnEmpleados)
        Me.GroupBox1.Controls.Add(Me.btnMedidas)
        Me.GroupBox1.Controls.Add(Me.btnPago)
        Me.GroupBox1.Controls.Add(Me.btnGastos)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 79)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(219, 422)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        '
        'btnReporte
        '
        Me.btnReporte.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnReporte.BackgroundImage = CType(resources.GetObject("btnReporte.BackgroundImage"), System.Drawing.Image)
        Me.btnReporte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnReporte.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReporte.FlatAppearance.BorderSize = 0
        Me.btnReporte.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight
        Me.btnReporte.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.btnReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporte.ForeColor = System.Drawing.Color.White
        Me.btnReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReporte.Location = New System.Drawing.Point(6, 359)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(205, 50)
        Me.btnReporte.TabIndex = 7
        Me.btnReporte.Text = "Reportes"
        Me.btnReporte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnReporte.UseVisualStyleBackColor = True
        '
        'btnCliente
        '
        Me.btnCliente.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnCliente.BackgroundImage = CType(resources.GetObject("btnCliente.BackgroundImage"), System.Drawing.Image)
        Me.btnCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCliente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCliente.FlatAppearance.BorderSize = 0
        Me.btnCliente.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight
        Me.btnCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.btnCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCliente.ForeColor = System.Drawing.Color.White
        Me.btnCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCliente.Location = New System.Drawing.Point(6, 12)
        Me.btnCliente.Name = "btnCliente"
        Me.btnCliente.Size = New System.Drawing.Size(205, 50)
        Me.btnCliente.TabIndex = 1
        Me.btnCliente.Text = "Clientes"
        Me.btnCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCliente.UseVisualStyleBackColor = False
        '
        'btnventas
        '
        Me.btnventas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnventas.BackgroundImage = CType(resources.GetObject("btnventas.BackgroundImage"), System.Drawing.Image)
        Me.btnventas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnventas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnventas.FlatAppearance.BorderSize = 0
        Me.btnventas.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight
        Me.btnventas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.btnventas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnventas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnventas.ForeColor = System.Drawing.Color.White
        Me.btnventas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnventas.Location = New System.Drawing.Point(6, 303)
        Me.btnventas.Name = "btnventas"
        Me.btnventas.Size = New System.Drawing.Size(205, 50)
        Me.btnventas.TabIndex = 16
        Me.btnventas.Text = "Ventas"
        Me.btnventas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnventas.UseVisualStyleBackColor = True
        '
        'btnEmpleados
        '
        Me.btnEmpleados.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnEmpleados.BackgroundImage = CType(resources.GetObject("btnEmpleados.BackgroundImage"), System.Drawing.Image)
        Me.btnEmpleados.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnEmpleados.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEmpleados.FlatAppearance.BorderSize = 0
        Me.btnEmpleados.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight
        Me.btnEmpleados.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.btnEmpleados.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEmpleados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmpleados.ForeColor = System.Drawing.Color.White
        Me.btnEmpleados.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEmpleados.Location = New System.Drawing.Point(6, 194)
        Me.btnEmpleados.Name = "btnEmpleados"
        Me.btnEmpleados.Size = New System.Drawing.Size(205, 50)
        Me.btnEmpleados.TabIndex = 9
        Me.btnEmpleados.Text = "Empleados"
        Me.btnEmpleados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEmpleados.UseVisualStyleBackColor = True
        '
        'btnMedidas
        '
        Me.btnMedidas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnMedidas.BackgroundImage = CType(resources.GetObject("btnMedidas.BackgroundImage"), System.Drawing.Image)
        Me.btnMedidas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnMedidas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMedidas.FlatAppearance.BorderSize = 0
        Me.btnMedidas.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight
        Me.btnMedidas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.btnMedidas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMedidas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMedidas.ForeColor = System.Drawing.Color.White
        Me.btnMedidas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMedidas.Location = New System.Drawing.Point(6, 248)
        Me.btnMedidas.Name = "btnMedidas"
        Me.btnMedidas.Size = New System.Drawing.Size(205, 50)
        Me.btnMedidas.TabIndex = 14
        Me.btnMedidas.Text = "Spa"
        Me.btnMedidas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnMedidas.UseVisualStyleBackColor = True
        '
        'btnPago
        '
        Me.btnPago.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnPago.BackgroundImage = CType(resources.GetObject("btnPago.BackgroundImage"), System.Drawing.Image)
        Me.btnPago.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnPago.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPago.FlatAppearance.BorderSize = 0
        Me.btnPago.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight
        Me.btnPago.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.btnPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPago.ForeColor = System.Drawing.Color.White
        Me.btnPago.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPago.Location = New System.Drawing.Point(6, 69)
        Me.btnPago.Name = "btnPago"
        Me.btnPago.Size = New System.Drawing.Size(205, 50)
        Me.btnPago.TabIndex = 5
        Me.btnPago.Text = "Pagos"
        Me.btnPago.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPago.UseVisualStyleBackColor = True
        '
        'btnGastos
        '
        Me.btnGastos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnGastos.BackgroundImage = CType(resources.GetObject("btnGastos.BackgroundImage"), System.Drawing.Image)
        Me.btnGastos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnGastos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGastos.FlatAppearance.BorderSize = 0
        Me.btnGastos.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight
        Me.btnGastos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.btnGastos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGastos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGastos.ForeColor = System.Drawing.Color.White
        Me.btnGastos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGastos.Location = New System.Drawing.Point(6, 133)
        Me.btnGastos.Name = "btnGastos"
        Me.btnGastos.Size = New System.Drawing.Size(205, 50)
        Me.btnGastos.TabIndex = 11
        Me.btnGastos.Text = "Gastos"
        Me.btnGastos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnGastos.UseVisualStyleBackColor = True
        '
        'Bntmenu
        '
        Me.Bntmenu.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bntmenu.BackgroundImage = CType(resources.GetObject("Bntmenu.BackgroundImage"), System.Drawing.Image)
        Me.Bntmenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Bntmenu.Location = New System.Drawing.Point(173, 20)
        Me.Bntmenu.Name = "Bntmenu"
        Me.Bntmenu.Size = New System.Drawing.Size(41, 35)
        Me.Bntmenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Bntmenu.TabIndex = 0
        Me.Bntmenu.TabStop = False
        '
        'PanelContenedor
        '
        Me.PanelContenedor.Controls.Add(Me.lblDescongelados)
        Me.PanelContenedor.Controls.Add(Me.lblLicencia)
        Me.PanelContenedor.Controls.Add(Me.piclogo)
        Me.PanelContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelContenedor.Location = New System.Drawing.Point(220, 65)
        Me.PanelContenedor.Name = "PanelContenedor"
        Me.PanelContenedor.Size = New System.Drawing.Size(999, 668)
        Me.PanelContenedor.TabIndex = 4
        '
        'lblDescongelados
        '
        Me.lblDescongelados.AutoSize = True
        Me.lblDescongelados.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescongelados.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblDescongelados.Location = New System.Drawing.Point(40, 552)
        Me.lblDescongelados.Name = "lblDescongelados"
        Me.lblDescongelados.Size = New System.Drawing.Size(0, 14)
        Me.lblDescongelados.TabIndex = 20
        '
        'lblLicencia
        '
        Me.lblLicencia.AutoSize = True
        Me.lblLicencia.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLicencia.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblLicencia.Location = New System.Drawing.Point(953, 611)
        Me.lblLicencia.Name = "lblLicencia"
        Me.lblLicencia.Size = New System.Drawing.Size(0, 14)
        Me.lblLicencia.TabIndex = 19
        '
        'piclogo
        '
        Me.piclogo.Location = New System.Drawing.Point(113, 79)
        Me.piclogo.Name = "piclogo"
        Me.piclogo.Size = New System.Drawing.Size(624, 363)
        Me.piclogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.piclogo.TabIndex = 0
        Me.piclogo.TabStop = False
        '
        'TimerOcultar
        '
        Me.TimerOcultar.Interval = 10
        '
        'timerLog
        '
        Me.timerLog.Interval = 500
        '
        'timerCongelados
        '
        Me.timerCongelados.Interval = 10
        '
        'timerDescongelados
        '
        Me.timerDescongelados.Interval = 10000
        '
        'Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.HighlightText
        Me.ClientSize = New System.Drawing.Size(1219, 733)
        Me.Controls.Add(Me.PanelContenedor)
        Me.Controls.Add(Me.Panelmenu)
        Me.Controls.Add(Me.PanelCabecera)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Principal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "29+0"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.PanelCabecera.ResumeLayout(False)
        Me.Panelmenu.ResumeLayout(False)
        Me.Panelmenu.PerformLayout()
        CType(Me.logosistem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.Bntmenu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelContenedor.ResumeLayout(False)
        Me.PanelContenedor.PerformLayout()
        CType(Me.piclogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mnCongelar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PanelCabecera As System.Windows.Forms.Panel
    Friend WithEvents btncerrar As System.Windows.Forms.Button
    Friend WithEvents btnmaximizar As System.Windows.Forms.Button
    Friend WithEvents btnminimizar As System.Windows.Forms.Button
    Friend WithEvents btnrestaurar As System.Windows.Forms.Button
    Friend WithEvents TimerMostrar As System.Windows.Forms.Timer
    Friend WithEvents Panelmenu As System.Windows.Forms.Panel
    Friend WithEvents PanelContenedor As System.Windows.Forms.Panel
    Friend WithEvents TimerOcultar As System.Windows.Forms.Timer
    Friend WithEvents Bntmenu As System.Windows.Forms.PictureBox
    Friend WithEvents btnCliente As System.Windows.Forms.Button
    Friend WithEvents btnPago As System.Windows.Forms.Button
    Friend WithEvents btnEmpleados As System.Windows.Forms.Button
    Friend WithEvents btnReporte As System.Windows.Forms.Button
    Friend WithEvents btnGastos As System.Windows.Forms.Button
    Friend WithEvents piclogo As System.Windows.Forms.PictureBox
    Friend WithEvents CongelarClienteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DescongelarClienteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConfiguracionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RutaDeFotosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnMedidas As System.Windows.Forms.Button
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnventas As System.Windows.Forms.Button
    Friend WithEvents ProductosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RegistrarProductoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReporteDeASaldosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CajaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ArqueoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents ArqueoVentasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents timerLog As System.Windows.Forms.Timer
    Friend WithEvents CompraToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AjusteDeInventarioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TemporalesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CompensarDiasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HistorialDeClienteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SolucionAProblemasConocidosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProblemaConLaHuellaEnElAccesoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TipoGastoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ArqueoSpaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResgistroDeMedidasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblLicencia As System.Windows.Forms.Label
    Friend WithEvents IngresosDeMensualidadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuHorarios As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuPersonalzado As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RegistroDeTemperaturaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IngresoPorUsuRIO As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents timerCongelados As System.Windows.Forms.Timer
    Friend WithEvents lblDescongelados As System.Windows.Forms.Label
    Friend WithEvents timerDescongelados As System.Windows.Forms.Timer
    Friend WithEvents RepararHuellaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnviarMensajeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TarifasNoConglablesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ElimineFacturaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PruebaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopiaDeSeguridadToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VentasDetalladoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InasistenciaDeUsuariosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HistorialDeSaldoDeVentasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DescargarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents logosistem As PictureBox
    Friend WithEvents DRAJULIAMENESESToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HIDROXIAPATITADECALCIOToolStripMenuItem As ToolStripMenuItem
End Class
