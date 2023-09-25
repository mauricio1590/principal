
Imports MySql.Data.MySqlClient
Imports System.Runtime.InteropServices

Public Class Principal
    Public intNivelUsuario As Integer = 0
    Public intidusuario As Integer
    Public strUsuario As String = ""
    Public booReporte As Boolean = False
    Public servidor As String = "localhost"
    Public usuario As String = "root"
    Public password As String = "bandband"
    Public database As String = "gym"
    Public strCedulaGeneral As String = ""
    Public strNombreAplicacion As String = "PROGYM 5.1"
    Public validado As Boolean = False
    Public strunidad As String = ""
    Public intEnviarEmail As Integer = 0
    Public intIngresoEmpleado As Integer = 0
    Public intIngresoClientes As Integer = 0
    Public booEliminarDetalle As Boolean = False
    Public intValidarEntradas As Integer = 0
    Public intNumeroEntradas As Integer = 0
    Public intPagoAbono As Integer = 0
    Public intTipopc As Integer = 0
    Public intVariosAbonos As Integer = 0
    Public intCongelarCliente As Integer = 0
    Public intNumeroDiasMinimos As Integer = 0
    Public intCongelarpormes As Integer = 0
    Public intTipoImpresion As Integer = 0
    Public intRestringirDiasCongelado As Integer = 0
    Public intDiasRestringidos As Integer = 0
    Public intValideLicenciaOnline As Integer = 0
    Public intAbonosPorCalendario As Integer = 2
    Public intHorarioFormularioIngreso As Integer = 0
    Public intValidarHorarioEntrada As Integer = 2

    'INFORMACION DEL ESTABLECIMIENTO 
    Public strNit As String = ""
    Public strNombre As String = ""
    Public intidOnline As Integer = 0
    Public strRegimen As String = ""
    Public strPropietario As String = ""
    Public strTelefono As String = ""
    Public strDireccion As String = ""

    'manejo de los colores de la interfaz
    Public botonlow1 As Integer = 46
    Public botonlow2 As Integer = 59
    Public botonlow3 As Integer = 104
    Public botonup1 As Integer = 128
    Public botonup2 As Integer = 128
    Public botonup3 As Integer = 128
    Public barra1 As Integer = 30
    Public barra2 As Integer = 37
    Public barra3 As Integer = 73
    Public cpanel1 As Integer = 44
    Public cpanel2 As Integer = 59
    Public cpanel3 As Integer = 107

    Public intHuella As Integer = 2
    Public intEntradasCliente As Integer = 2
    Public strPuerto As String = ""
    Dim gestor1 As New Soltec.Gestor
    Public cadenadeconexion As String = "Server=localhost;Uid=root;Pwd=bandband;Database=gym"
    Public cadenadeconexionOnline As String = "Server=162.241.60.183;Uid=barbersa_mvaron;Pwd= fGhvby7ZqEyiPVK;Database=barbersa_gim"
    Public Logo As String = ""
    Public intValidar As Integer = 0
    Dim con As conexion = New conexion()
    Public intdiascngelados As Integer = 0
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub

    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim pg As New Pago()
        pg.ShowDialog()

        'Pago.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Dim cliente As New Clientes()
        cliente.ShowDialog()


    End Sub

    Private Sub Principal_Activated(sender As Object, e As EventArgs) Handles Me.Activated

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        examinarBase()
        btnventas.Visible = True
        Cargarconfiguracion(strunidad, intEnviarEmail, intIngresoEmpleado, intIngresoClientes, intValidarEntradas, intNumeroEntradas, intPagoAbono,
                            intCongelarCliente, intNumeroDiasMinimos, intCongelarpormes, intHuella, intTipoImpresion, intEntradasCliente, strPuerto,
                            intVariosAbonos, intTipopc, intRestringirDiasCongelado, intDiasRestringidos, intValideLicenciaOnline, intHorarioFormularioIngreso, intValidarHorarioEntrada)
        controlDeInformes()
        ExamineVersion()
        If intValideLicenciaOnline = 1 Then
            If Not con.valideLicencia() Then
                MessageBox.Show("Su licencia a Expirado " & vbCrLf & "Comuniquese con su proveedor de servivio", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Close()
                Exit Sub
            End If
        End If
        lblVersion.Text = "PROGYM " & My.Application.Info.Version.ToString
        Logo = strunidad & ":\PROGYM_DATOS\Imagenes\logo.jpg"
        con.ponerFoto(Logo, piclogo)
        If intCongelarCliente = 2 Then
            mnCongelar.Visible = False
        End If
        intValidar = 3
        colorBarras(PanelCabecera)
        colorPanel(Panelmenu)
        timerLog.Start()


    End Sub

    Dim lx As Integer
    Dim ly As Integer
    Dim sw As Integer
    Dim sh As Integer
    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles btnmaximizar.Click

        lx = Location.X
        ly = Location.Y
        sw = Size.Width
        sh = Size.Height
        btnmaximizar.Visible = False
        btnrestaurar.Visible = True
        Size = Screen.PrimaryScreen.WorkingArea.Size
        Location = Screen.PrimaryScreen.WorkingArea.Location

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btncerrar.Click
        Application.Exit()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnminimizar.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnrestaurar_Click(sender As Object, e As EventArgs) Handles btnrestaurar.Click
        Size = New Size(sw, sh)
        Location = New Point(lx, ly)
        btnrestaurar.Visible = False
        btnmaximizar.Visible = True
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub PanelCabecera_MouseMove(sender As Object, e As MouseEventArgs) Handles PanelCabecera.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub TimerMostrar_Tick(sender As Object, e As EventArgs)
        If Panelmenu.Width >= 200 Then

            Me.TimerMostrar.Enabled = False
        Else
            Me.Panelmenu.Width = Panelmenu.Width + 20
        End If
    End Sub

    Private Sub TimerOcultar_Tick(sender As Object, e As EventArgs)
        If Panelmenu.Width <= 60 Then
            Me.TimerOcultar.Enabled = False
        Else
            Me.Panelmenu.Width = Panelmenu.Width - 20
        End If


    End Sub

    Private Sub Bntmenu_Click(sender As Object, e As EventArgs) Handles Bntmenu.Click
        If Panelmenu.Width = 220 Then
            TimerOcultar.Enabled = True
        ElseIf Panelmenu.Width = 60 Then
            TimerMostrar.Enabled = True
        End If



    End Sub

    Private Sub TimerMostrar_Tick_1(sender As Object, e As EventArgs) Handles TimerMostrar.Tick
        If Panelmenu.Width >= 220 Then
            Me.TimerMostrar.Enabled = False
        Else
            Me.Panelmenu.Width = Panelmenu.Width + 20
        End If
    End Sub

    Private Sub TimerOcultar_Tick_1(sender As Object, e As EventArgs) Handles TimerOcultar.Tick
        If Panelmenu.Width <= 60 Then
            Me.TimerOcultar.Enabled = False
        Else
            Me.Panelmenu.Width = Panelmenu.Width - 20
        End If
    End Sub



    Private Sub Button2_Click_2(sender As Object, e As EventArgs) Handles btnEmpleados.Click
        AbrirFormularios(Of Empleados)()
        btnEmpleados.BackColor = Color.FromArgb(botonup1, botonup2, botonup3)
    End Sub

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Panel2_Paint_1(sender As Object, e As PaintEventArgs)

    End Sub
    Public Sub AbrirFormularios(Of Miform As {Form, New})()
        Dim Formulario As Form
        Formulario = PanelContenedor.Controls.OfType(Of Miform)().FirstOrDefault() 'Busca el formulario en la coleccion
        'Si form no fue econtrado/ no existe
        If Formulario Is Nothing Then
            Formulario = New Miform()
            Formulario.TopLevel = False
            Formulario.FormBorderStyle = FormBorderStyle.None
            Formulario.Dock = DockStyle.Fill
            PanelContenedor.Controls.Add(Formulario)
            PanelContenedor.Tag = Formulario
            AddHandler Formulario.FormClosed, AddressOf Me.cerrarFormulario
            Formulario.Show()
            Formulario.BringToFront()
        Else
            Formulario.BringToFront()
        End If


    End Sub

    Private Sub btnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        If intHuella = 1 Then
            pararCaptura()
        End If

        AbrirFormularios(Of Clientes)()
        btnCliente.BackColor = Color.FromArgb(botonup1, botonup2, botonup3)
        Clientes.Focus()
        Clientes.BringToFront()

    End Sub

    Private Sub btnPago_Click(sender As Object, e As EventArgs) Handles btnPago.Click
        pararCaptura()
        AbrirFormularios(Of Pago)()
        btnPago.BackColor = Color.FromArgb(botonup1, botonup2, botonup3)
        Clientes.txtcedula.Focus()

    End Sub
    Protected Sub pararCaptura()
        If Not Captura Is Nothing Then
            Try
                Captura.StopCapture()
            Catch ex As Exception
                MessageBox.Show("NO PUDO DETENER LA CAPTURA")
            End Try
        End If
    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles btnReporte.Click
        AbrirFormularios(Of reportes)()
        btnReporte.BackColor = Color.FromArgb(botonup1, botonup2, botonup3)
    End Sub

    Private Sub cerrarFormulario(ByVal sender As Object, ByVal a As FormClosedEventArgs)


        If (Application.OpenForms("Clientes") Is Nothing) Then
            btnCliente.BackColor = System.Drawing.Color.FromArgb(botonlow1, botonlow2, botonlow3)
        End If
        If (Application.OpenForms("Pago") Is Nothing) Then
            btnPago.BackColor = System.Drawing.Color.FromArgb(botonlow1, botonlow2, botonlow3)
        End If
        If (Application.OpenForms("reportes") Is Nothing) Then
            btnReporte.BackColor = System.Drawing.Color.FromArgb(botonlow1, botonlow2, botonlow3)
        End If
        If (Application.OpenForms("Gastos") Is Nothing) Then
            btnGastos.BackColor = System.Drawing.Color.FromArgb(botonlow1, botonlow2, botonlow3)
        End If
        If (Application.OpenForms("Empleados") Is Nothing) Then
            btnEmpleados.BackColor = System.Drawing.Color.FromArgb(botonlow1, botonlow2, botonlow3)
        End If
        If (Application.OpenForms("Medidas") Is Nothing) Then
            btnMedidas.BackColor = System.Drawing.Color.FromArgb(botonlow1, botonlow2, botonlow3)
        End If
        If (Application.OpenForms("ventas") Is Nothing) Then
            btnventas.BackColor = System.Drawing.Color.FromArgb(botonlow1, botonlow2, botonlow3)
        End If

    End Sub

    Private Sub CongelarClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CongelarClienteToolStripMenuItem.Click

        If Not Now.DayOfWeek = 6 Then
            Dim cong As New Congelar()
            cong.ShowDialog()
        Else
            MessageBox.Show("El sistema esta restringido para congelar los sabados", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If


    End Sub

    Private Sub Form1_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        pararCaptura()
    End Sub

    Private Sub ReiniciarAppToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Application.Restart()
    End Sub

    Private Sub DescongelarClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DescongelarClienteToolStripMenuItem.Click
        Dim strCedula As String = InputBox("Escriba la cedula del cliente", "Mensaje del Sistema")
        If Estacongelado(strCedula) Then
            Dim res = MessageBox.Show("este cliente tiene " & intdiascngelados & " congelados " & vbCrLf & "Desea descongelarlo ", "Informacion Del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If res = Windows.Forms.DialogResult.Yes Then
                Dim fecha As Date = Now.AddDays(intdiascngelados)
                If con.registreDatos("UPDATE pago set fecha_corte=STR_TO_DATE('" & fecha.Date & "','%d/%m/%Y') WHERE cedula='" & strCedula & "'") Then
                    con.registreDatos("UPDATE congelado set estado=2 WHERE cedula='" & strCedula & "'")
                    MessageBox.Show("El cliente fue descongelado, " & vbCrLf & " la nueva fechae es: " & fecha.ToString & " ", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            Else : Exit Sub
            End If
        Else : MessageBox.Show("Este cliente no  esta congelado", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles btnGastos.Click
        AbrirFormularios(Of Gastos)()
        btnGastos.BackColor = Color.FromArgb(botonup1, botonup2, botonup3)
    End Sub

    Private Sub ReiniciarAppToolStripMenuItem1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub RutaDeFotosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RutaDeFotosToolStripMenuItem.Click
        Dim buscar = New OpenFileDialog()
        If buscar.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim strnuevaruta As String = (buscar.FileName)
            Dim array As Array = strnuevaruta.ToString.Split("\")
            Dim pos = InputBox("Escriba final de la ruta")
            Dim nuevaruta As String = ""
            For i As Integer = 0 To pos
                nuevaruta += array(i) & "\\"
            Next
            actualiceruta(nuevaruta)
        End If

    End Sub

    Private Sub VersionToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim c1 As String = "e:\PROGYM.DATOS\Actualizaciones\Application Files\PROGYM 5.1.5.1.0.25"
        Dim c2 As String = "e:\PROGYM.DATOS\Actualizaciones\Application Files\PROGYM 5.1.5.0.0.26"
        MsgBox(c1.Length & " c2 = " & c2.Length)
        If c1 < c2 Then
            MsgBox("es menor la actual")
        End If

    End Sub

    Private Sub ExamineVersion()
        Dim strVersion As String = My.Application.Info.Version.ToString
        If Not gestor1.SiExiste("SELECT id FROM versiones WHERE ve='" & strVersion & "'", cadenadeconexion) Then con.registreDatos("INSERT INTO versiones (ac, ve) VALUES (0, '" & strVersion & "')")
        If Not My.Computer.FileSystem.DirectoryExists(strunidad & ":\PROGYM_DATOS\Actualizaciones\Application Files") Then Exit Sub
        For Each Carpeta As String In My.Computer.FileSystem.GetDirectories(strunidad & ":\PROGYM_DATOS\Actualizaciones\Application Files")
            Dim strEstaVersion As String = strunidad & ":\PROGYM_DATOS\Actualizaciones\Application Files\" & strNombreAplicacion & "_" & Replace(strVersion, ".", "_")

            strEstaVersion = strEstaVersion.Replace("_", ".")
            Carpeta = Carpeta.Replace("_", ".")
            If strEstaVersion < Carpeta Then
                If My.Computer.FileSystem.FileExists(strunidad & ":\PROGYM_DATOS\Actualizaciones\setup.exe") Then
                    'Shell()
                    Process.Start(strunidad & ":\PROGYM_DATOS\Actualizaciones\setup.exe")
                    Me.Close()
                    End
                End If

            End If
        Next

    End Sub

    Private Sub Button3_Click_2(sender As Object, e As EventArgs) Handles btnMedidas.Click
        AbrirFormularios(Of pagoSpa)()
        btnMedidas.BackColor = Color.FromArgb(botonup1, botonup2, botonup3)
    End Sub


    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        intValidar = 4
        Dim validar As New VALIDAR
        validar.ShowDialog()
    End Sub

    Private Sub btnventas_Click(sender As Object, e As EventArgs) Handles btnventas.Click
        AbrirFormularios(Of Ventas)()
        btnventas.BackColor = Color.FromArgb(botonup1, botonup2, botonup3)
    End Sub

    Private Sub RegistrarProductoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarProductoToolStripMenuItem.Click
        AbrirFormularios(Of Productos)()

    End Sub

    Private Sub ReporteDeASaldosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeASaldosToolStripMenuItem.Click
        AbrirFormularios(Of SaldoVentas)()
    End Sub

    Private Sub CompensarDiasToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim intdias As Integer = InputBox("Escriba los dias a reponer", "Mensaje del sistema")
        If Not IsNumeric(intdias) Then Exit Sub
        adicioneDias(intdias)


    End Sub

    Private Sub Panel7_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub ArqueoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArqueoToolStripMenuItem.Click
        AbrirFormularios(Of Arqueo)()
    End Sub

    Private Sub ObsequiarCortesiasToolStripMenuItem_Click(sender As Object, e As EventArgs)

        Dim strcedula As String = InputBox("Ingrese la cedula", "Mensaje del Sistema")
        If Not strcedula.Equals("") Then
            If con.saberingreso(strcedula) Then
                Dim cad As String = "DELETE FROM PAGO WHERE CEDULA='" & strcedula & "';DELETE FROM abonos WHERE CEDULA='" & strcedula & "';DELETE FROM cliente WHERE CEDULA='" & strcedula & "'"
                con.registreDatos(cad)
                MessageBox.Show("EL cliente ha sido eliminado correctamente", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                MessageBox.Show("EL documento ingresado no se encontro en la base de datos", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub PanelCabecera_Paint(sender As Object, e As PaintEventArgs) Handles PanelCabecera.Paint

    End Sub

    Private Sub ArqueoVentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArqueoVentasToolStripMenuItem.Click
        AbrirFormularios(Of Arqueoventa)()
    End Sub

    Private Sub Panelmenu_Paint(sender As Object, e As PaintEventArgs) Handles Panelmenu.Paint

    End Sub

    Private Sub timerLog_Tick(sender As Object, e As EventArgs) Handles timerLog.Tick
        timerLog.Stop()
        Dim log As New InicioSecion
        log.ShowDialog()
        If intNivelUsuario < 4 Then
            btnReporte.Visible = False
            AjusteDeInventarioToolStripMenuItem.Visible = False
        End If
        If Not validado Then
            Application.Exit()
        End If

    End Sub

    Private Sub CompraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompraToolStripMenuItem.Click
        AbrirFormularios(Of Compras)()
    End Sub

    Private Sub PanelContenedor_Paint(sender As Object, e As PaintEventArgs) Handles PanelContenedor.Paint

    End Sub

    Private Sub TemporalArticulosAKardexToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim arlCoincidencias As ArrayList = gestor1.DatosDeConsulta("SELECT id,pro_cantidad,pro_precioventa FROM PRODUCTO", , cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then
            For Each articulo As ArrayList In arlCoincidencias
                Dim cadena As String = "INSERT INTO kardex (idproducto,idfactura,cantidad,valor,scantidad,costo,mov) VALUES " & vbCrLf &
                     "('" & articulo(0) & "',1,'" & articulo(1) & "','" & articulo(2) & "','" & articulo(1) & "','" & articulo(2) & "',2)"
                con.registreDatos(cadena)
            Next
        End If
    End Sub

    Private Sub AjusteDeInventarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AjusteDeInventarioToolStripMenuItem.Click
        AbrirFormularios(Of AjusteDeInventario)()
    End Sub

    Private Sub CompensarDiasToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles CompensarDiasToolStripMenuItem.Click
        Dim strDias As String = InputBox("Ingrese dias a reponer", "Mensaje del Sistema")
        If Not strDias.Equals("") AndAlso IsNumeric(strDias) Then
            adicioneDias(strDias)

        Else : MessageBox.Show("Error en los dias ingresados", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If
    End Sub

    Private Sub HistorialDeClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HistorialDeClienteToolStripMenuItem.Click
        AbrirFormularios(Of historialCliente)()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click

    End Sub

    Private Sub ProblemaConLaHuellaEnElAccesoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProblemaConLaHuellaEnElAccesoToolStripMenuItem.Click
        Dim arlCoincidencias As ArrayList = gestor1.DatosDeConsulta("SELECT id FROM cliente WHERE huella IS NOT NULL ORDER BY huella limit 1", , cadenadeconexion)
        If arlCoincidencias.Count > 0 Then
            Dim id As Integer = arlCoincidencias(0)(0)
            con.registreDatos("UPDATE cliente SET huella=null WHERE id='" & id & "'")
            MessageBox.Show("Reinicie el modulo del acceso y pruebe una huella", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

        End If
    End Sub


    Private Sub CrearCopiaDeSeguridad()
        Dim cnConexion As New MySqlConnection(cadenadeconexion)
        Dim coCopiador As New MySqlCommand
        Dim baCopiador As New MySqlBackup(coCopiador)
        'baCopiador.Command = coCopiador
        coCopiador.Connection = cnConexion
        cnConexion.Open()
        Dim strNombreCopia As String = Now.ToString
        baCopiador.ExportToFile("d:/copiadeseguridad " & strNombreCopia & ".sql")
        baCopiador.Dispose()
        coCopiador.Dispose()
        cnConexion.Dispose()

    End Sub

    Private Sub TipoGastoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TipoGastoToolStripMenuItem.Click
        Dim tp As New Tipogasto
        tp.ShowDialog()
    End Sub

    Private Sub ArqueoSpaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArqueoSpaToolStripMenuItem.Click
        AbrirFormularios(Of ArquepSpa)()
    End Sub

    Private Sub ResgistroDeMedidasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResgistroDeMedidasToolStripMenuItem.Click
        AbrirFormularios(Of Medidas)()
    End Sub

    Private Sub IngresosDeMensualidadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresosDeMensualidadToolStripMenuItem.Click
        AbrirFormularios(Of ReportesMes)()
    End Sub

    Private Sub CopiaDeSeguridadToolStripMenuItem_Click(sender As Object, e As EventArgs)
        CrearCopiaDeSeguridad()
        MsgBox("Termino la copia de seguridad")
    End Sub

    Private Sub PersonalilzadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles menuHorarios.Click
        AbrirFormularios(Of horarios)()
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles menuPersonalzado.Click
        AbrirFormularios(Of Personalizado)()
    End Sub

    Private Sub RegistroDeTemperaturaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistroDeTemperaturaToolStripMenuItem.Click
        Dim strCedula As String = InputBox("Escriba la cedula del cliente", "Mensaje del Sistema")
        Dim strTemperatura As String = "0"
        Dim strObservaciones As String = ""
        Dim strIdPersona = esCliente(strCedula)
        If Not strIdPersona = 0 Then

            While (True)
                strTemperatura = InputBox("Temperatura", "Temperatura del Cliente")
                If strTemperatura = "" Then
                    MessageBox.Show("Debe Ingresar La Temperatura", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    Exit While
                End If
            End While


            strObservaciones = InputBox("Observaciones", "Observaciones del Cliente")
            If con.registreDatos("INSERT INTO temperatura (persona_id,tem,obs) values ('" & strIdPersona & "', '" & strTemperatura & "', '" & strObservaciones & "')") Then
                MessageBox.Show("Registro Correcto ", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If

        Else : MessageBox.Show("Este cliente no  esta Registrado", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub mnCongelar_Click(sender As Object, e As EventArgs) Handles mnCongelar.Click

    End Sub

    Private Sub HistorialDeIngresoPorClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HistorialDeIngresoPorClienteToolStripMenuItem.Click
        AbrirFormularios(Of HistorialIngreso)()
    End Sub
End Class
