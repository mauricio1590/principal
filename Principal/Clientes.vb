Imports Soltec
Imports DPFP
Imports DPFP.Capture
Imports System.Text
Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.IO
Imports System.Runtime.InteropServices

Public Class Clientes
    Implements DPFP.Capture.EventHandler
    Dim intIdPago = 0
    Public intidmodificado As Integer = 0
    Dim intbusqueda As Integer = 1
    Public memoriatemporal As New MemoryStream()
    Public boohuellacambiada As Boolean = False
    Dim validaciones As conexion = New conexion()
    Public boohuella As Boolean = False
    Public strFoto As String = ""

    'NUEVA CAMARA
    Dim strCedulaAntigua As String = ""
    Dim DATOS As IDataObject
    Dim IMAGEN As Image
    Public iDevice As Integer = 0 ' Current device ID
    Public hHwnd As Integer ' Handle to preview window
    Public Const WM_CAP As Short = &H400S
    Public Const WM_CAP_DLG_VIDEOFORMAT As Integer = WM_CAP + 41
    Public Const WM_CAP_DRIVER_CONNECT As Integer = WM_CAP + 10
    Public Const WM_CAP_DRIVER_DISCONNECT As Integer = WM_CAP + 11
    Public Const WM_CAP_EDIT_COPY As Integer = WM_CAP + 30
    Public Const WM_CAP_SEQUENCE As Integer = WM_CAP + 62
    Public Const WM_CAP_FILE_SAVEAS As Integer = WM_CAP + 23
    Public Const WM_CAP_SET_PREVIEW As Integer = WM_CAP + 50
    Public Const WM_CAP_SET_PREVIEWRATE As Integer = WM_CAP + 52
    Public Const WM_CAP_SET_SCALE As Integer = WM_CAP + 53
    Public Const WS_CHILD As Integer = &H40000000
    Public Const WS_VISIBLE As Integer = &H10000000
    Public Const SWP_NOMOVE As Short = &H2S
    Public Const SWP_NOSIZE As Short = 1
    Public Const SWP_NOZORDER As Short = &H4S
    Public Const HWND_BOTTOM As Short = 1
    Public Const WM_CAP_STOP As Integer = WM_CAP + 68

    Public Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
       (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer,
       <MarshalAs(UnmanagedType.AsAny)> ByVal lParam As Object) As Integer

    Public Declare Function SetWindowPos Lib "user32" Alias "SetWindowPos" (ByVal hwnd As Integer,
        ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer,
        ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer

    Public Declare Function capCreateCaptureWindowA Lib "avicap32.dll" _
    (ByVal lpszWindowName As String, ByVal dwStyle As Integer,
    ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer,
    ByVal nHeight As Short, ByVal hWndParent As Integer,
    ByVal nID As Integer) As Integer

    Public Declare Function DestroyWindow Lib "user32" (ByVal hndw As Integer) As Boolean


    'Public template As DPFP.Template
    'Private Captura As DPFP.Capture.Capture
    Private Delegate Sub _delegadoMuestra(ByVal text As String)
    Private Delegate Sub _delegadoControles()
    Dim Gestor1 As New Soltec.Gestor
    Dim con As New conexion
    Public intTipoConsulta As Integer = 1
    Private Sub modificarControles()
        If (btnGuardar.InvokeRequired) Then
            Dim deleg As New _delegadoControles(AddressOf modificarControles)
            Me.Invoke(deleg, New Object() {})
        Else
            'btnGuardar.Enabled = True
        End If
    End Sub
    Private Sub mostrarVeces(ByVal texto As String)
        If (vecesDedo.InvokeRequired) Then
            Dim deleg As New _delegadoMuestra(AddressOf mostrarVeces)
            Me.Invoke(deleg, New Object() {texto})
        Else
            vecesDedo.Text = texto
            ponerhuella(texto.ToString)
        End If
    End Sub

    Protected Overridable Sub Init()
        Try
            Captura = New Capture()
            If Not Captura Is Nothing Then
                Captura.EventHandler = Me
                Select Case intTipoConsulta
                    Case 1
                        Enroller = New DPFP.Processing.Enrollment()
                        Dim texto As New StringBuilder()
                        texto.AppendFormat("{0}", Enroller.FeaturesNeeded)
                        vecesDedo.Text = texto.ToString


                    Case 2
                        verificador = New Verification.Verification()
                End Select

            Else
                MessageBox.Show("NO PUDO INSTANCIAR LA CAPTURA")
            End If

        Catch ex As Exception
            MessageBox.Show("NO PUDO INICIALIZAR LA CAPTURA LA CAPTURA")
        End Try
    End Sub

    Protected Sub iniciarCaptura()
        If Not Captura Is Nothing Then
            Try

                Captura.StartCapture()
                boohuella = True
            Catch ex As Exception
                MessageBox.Show("NO PUDO INICIAR LA CAPTURA")
                Application.Restart()
            End Try
        End If
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
    Public Sub OnComplete(Capture As Object, ReaderSerialNumber As String, Sample As Sample) Implements EventHandler.OnComplete
        Select Case intTipoConsulta
            Case 1
                ponerImagen(ConvertirSamplerAMapadeBits(Sample))
                Procesar(Sample)

            Case 2

        End Select

    End Sub

    Public Sub OnFingerGone(Capture As Object, ReaderSerialNumber As String) Implements EventHandler.OnFingerGone

    End Sub

    Public Sub OnFingerTouch(Capture As Object, ReaderSerialNumber As String) Implements EventHandler.OnFingerTouch

    End Sub

    Public Sub OnReaderConnect(Capture As Object, ReaderSerialNumber As String) Implements EventHandler.OnReaderConnect

    End Sub

    Public Sub OnReaderDisconnect(Capture As Object, ReaderSerialNumber As String) Implements EventHandler.OnReaderDisconnect

    End Sub

    Public Sub OnSampleQuality(Capture As Object, ReaderSerialNumber As String, CaptureFeedback As CaptureFeedback) Implements EventHandler.OnSampleQuality

    End Sub

    Sub ponerhuella(huella As String)
        Dim chexk As String = Principal.strunidad & ":\SISTEMGYM_DATOS\Imagenes\check.png"
        Select Case huella
            Case 0
                If My.Computer.FileSystem.FileExists(chexk) Then
                    Dim Imagen As New Bitmap(chexk)
                    huella4.Image = Imagen
                End If
            Case 1
                If My.Computer.FileSystem.FileExists(chexk) Then
                    Dim Imagen As New Bitmap(chexk)
                    huella3.Image = Imagen
                End If
            Case 2
                If My.Computer.FileSystem.FileExists(chexk) Then
                    Dim Imagen As New Bitmap(chexk)
                    huella2.Image = Imagen
                End If
            Case 3
                If My.Computer.FileSystem.FileExists(chexk) Then
                    Dim Imagen As New Bitmap(chexk)
                    huella1.Image = Imagen
                End If


        End Select
    End Sub
    Sub ponercheck()

        Dim chexk As String = Principal.strunidad & ":\SISTEMGYM_DATOS\Imagenes\checkdes.png"

        If My.Computer.FileSystem.FileExists(chexk) Then
            Dim Imagen As New Bitmap(chexk)
            huella1.Image = Imagen
            huella2.Image = Imagen
            huella3.Image = Imagen
            huella4.Image = Imagen
            huella1.Enabled = False
        End If



    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtcedula.Focus()
        If My.Computer.FileSystem.FileExists(Principal.Logo) Then
            Dim Imagen As New Bitmap(Principal.Logo)
            imagenfoto.Image = Imagen
            imagenHuella.Image = Imagen


        End If
        dtFecha.Text = "01/01/2000"
        colorBarras(PanelCabecera)
    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        pararCaptura()
    End Sub
    Protected Function ConvertirSamplerAMapadeBits(ByRef Sample As DPFP.Sample) As Bitmap
        Dim convertidor As New DPFP.Capture.SampleConversion() 'variable tipo conversor de un DPFP.Sample
        Dim mapaBits As Bitmap = Nothing
        convertidor.ConvertToPicture(Sample, mapaBits)
        Return mapaBits
    End Function
    Public Sub ponerImagen(ByVal bmp)
        imagenHuella.Image = bmp
    End Sub

    Protected Function extraerCaracteristicas(ByVal Sample As DPFP.Sample, ByVal Purpose As DPFP.Processing.DataPurpose) As DPFP.FeatureSet
        Dim extractor As New DPFP.Processing.FeatureExtraction()
        Dim alimentacion As DPFP.Capture.CaptureFeedback = DPFP.Capture.CaptureFeedback.None
        Dim caracteristicas As New DPFP.FeatureSet()
        extractor.CreateFeatureSet(Sample, Purpose, alimentacion, caracteristicas)
        If (alimentacion = DPFP.Capture.CaptureFeedback.Good) Then
            Return caracteristicas
        Else
            Return Nothing
        End If

    End Function
    Protected Sub Procesar(ByVal Sample As DPFP.Sample)
        Dim caracteristicas As DPFP.FeatureSet = extraerCaracteristicas(Sample, DPFP.Processing.DataPurpose.Enrollment)
        If (Not caracteristicas Is Nothing) Then
            Try
                Enroller.AddFeatures(caracteristicas)
            Finally
                Dim texto As New StringBuilder()
                texto.AppendFormat("{0}", Enroller.FeaturesNeeded)
                mostrarVeces(texto.ToString)

                Select Case Enroller.TemplateStatus
                    Case DPFP.Processing.Enrollment.Status.Ready
                        pararCaptura()
                        template = Enroller.Template
                        modificarControles()
                        boohuellacambiada = True
                        boohuella = True
                    Case DPFP.Processing.Enrollment.Status.Failed
                        Enroller.Clear()
                        pararCaptura()
                        iniciarCaptura()
                End Select

            End Try
        End If

    End Sub

    Private Sub reiniciar()
        If My.Computer.FileSystem.FileExists(Principal.Logo) Then
            Dim Imagen As New Bitmap(Principal.Logo)
            intIdPago = 0
            imagenfoto.Image = Nothing
            imagenfoto.Image = Imagen
            imagenHuella.Image = Imagen
            capturada.Image = Nothing
            capturada.Visible = False
            imagenfoto.Visible = True

        End If
        txtcedula.Text = ""
        txtname.Text = ""
        txtEmail.Text = ""
        txtapellido.Text = ""
        txttelefono.Text = ""
        txtdireccion.Text = ""
        txtEps.Text = ""
        txtEmergencia.Text = ""
        txttelefono2.Text = ""
        txtRh.Text = ""
        txtInstructor.Text = ""
        boohuella = False
        boohuellacambiada = False
        dtFecha.Format = DateTimePickerFormat.Custom
        dtFecha.Text = "01/01/2000"

        If Not Enroller Is Nothing Then
            Enroller.Clear()
            Dim texto As New StringBuilder()
            ponercheck()
            texto.AppendFormat("{0}", Enroller.FeaturesNeeded)
            mostrarVeces(texto.ToString)
        End If
        btnModificar.Enabled = False
        btnGuardar.Enabled = True
        'pararCaptura()
        intbusqueda = 1



    End Sub
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If validaciones.saberingreso(txtcedula.Text) Then MessageBox.Show("EL documento ingresado ya fue registrado", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
        If validarCampos() Then
            Dim Builderconex As New MySqlConnectionStringBuilder()
            Builderconex.Server = Principal.servidor
            Builderconex.UserID = Principal.usuario
            Builderconex.Password = Principal.password
            Builderconex.Database = Principal.database
            Dim conexion As New MySqlConnection(Builderconex.ToString())
            conexion.Open()
            Dim cmd As New MySqlCommand()
            cmd = conexion.CreateCommand()
            cmd.CommandText = "INSERT INTO cliente (cedula,nombre,apellido,telefono,direccion,correo,nacimiento,ruta,eps,contacto,telefono2,rh,instructor,huella) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
            cmd.Parameters.AddWithValue("cedula", txtcedula.Text.ToString())
            cmd.Parameters.AddWithValue("nombre", txtname.Text.ToString().ToUpper)
            cmd.Parameters.AddWithValue("apellido", txtapellido.Text.ToString().ToUpper)
            cmd.Parameters.AddWithValue("telefono", txttelefono.Text.ToString())
            cmd.Parameters.AddWithValue("direccion", txtdireccion.Text.ToString())
            cmd.Parameters.AddWithValue("correo", txtEmail.Text.ToString())
            cmd.Parameters.AddWithValue("nacimiento", Format(dtFecha.Value, "yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("ruta", strFoto)
            cmd.Parameters.AddWithValue("eps", txtEps.Text.ToString())
            cmd.Parameters.AddWithValue("contacto", txtEmergencia.Text.ToString())
            cmd.Parameters.AddWithValue("telefono1", txttelefono2.Text.ToString())
            cmd.Parameters.AddWithValue("rh", txtRh.Text.ToString())
            cmd.Parameters.AddWithValue("instructor", txtInstructor.Text.ToString())
            If template.Bytes Is Nothing Then
                cmd.Parameters.AddWithValue("huella", Nothing)
            Else
                Using fm As New MemoryStream(template.Bytes)
                    cmd.Parameters.AddWithValue("huella", fm.ToArray)
                End Using
            End If

            cmd.ExecuteNonQuery()
            cmd.Dispose()
            conexion.Close()
            conexion.Dispose()
            reiniciar()
            MessageBox.Show("El registro se hizo correctamente", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Else : MessageBox.Show("Debe Alimentar Los Campos Minimos", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Clientes_Leave(sender As Object, e As EventArgs) Handles MyBase.Leave
        pararCaptura()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btncapturarhuellas.Click
        If Not Principal.intHuella = 1 Then
            MessageBox.Show("El sistema no esta configurado para hacer el control con huella", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Not Enroller Is Nothing Then
            Enroller.Clear()
            Dim texto As New StringBuilder()
            texto.AppendFormat("Necesitas pasar el dedo {0} veces", Enroller.FeaturesNeeded)
            mostrarVeces(texto.ToString)
        End If
        imagenHuella.Image = Nothing
        Init()
        iniciarCaptura()
        ponercheck()
        'pararCaptura()
        'Dim ventanaPago As New Pago
        'ventanaPago.ShowDialog()
    End Sub

    Function validarCampos() As Boolean
        If Not txtcedula.Text.ToString.Equals("") Then
            If Not txtname.Text.ToString.Equals("") Then
                If Not txtapellido.Text.ToString.Equals("") Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If
        Else : Return False
        End If
    End Function

    Private Sub imagenHuella_Click(sender As Object, e As EventArgs) Handles imagenHuella.Click

    End Sub

    Private Sub Clientes_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated

    End Sub




    Private Sub btnIniciarCam_Click(sender As Object, e As EventArgs) Handles btnIniciarCam.Click
        '  WebCam1.Start()
        '  If WebCam1.Visible = False Then
        '      WebCam1.Visible = True
        '  End If
        capturada.Visible = False
        imagenfoto.Visible = True
        OpenPreviewWindow()
        'INICIAR.Visible = False

    End Sub

    Private Sub btnCapturar_Click(sender As Object, e As EventArgs) Handles btnCapturar.Click
        ' WebCam1.Stop()
        'imagenfoto.Image = WebCam1.Imagen
        ' Dim strHora As String = Now.ToString.Replace(".", "_").Replace("/", "_").Replace(" ", "_").Replace(":", "_")
        'strFoto = Principal.strunidad & ":\SISTEMGYM_DATOS\fotos\" & Now.Day & "_" & txtname.Text & "_" & txtcedula.Text & strHora & ".jpg"
        'imagenfoto.Image.Save(strFoto)



        ' Copy image to clipboard
        '
        SendMessage(hHwnd, WM_CAP_EDIT_COPY, 0, 0)

        ' Get image from clipboard and convert it to a bitmap
        '
        DATOS = Clipboard.GetDataObject()

        IMAGEN = CType(DATOS.GetData(GetType(System.Drawing.Bitmap)), Image)
        capturada.Image = IMAGEN
        imagenfoto.Visible = False
        capturada.Visible = True
        DestroyWindow(hHwnd)
        Dim strHora As String = Now.ToString.Replace(".", "_").Replace("/", "_").Replace(" ", "_").Replace(":", "_")
        strFoto = Principal.strunidad & ":\SISTEMGYM_DATOS\fotos\" & Now.Day & "_" & txtname.Text & "_" & txtcedula.Text & strHora & ".jpg"
        capturada.Image.Save(strFoto)

    End Sub
    Public Sub OpenPreviewWindow()

        ' Open Preview window in picturebox
        '
        hHwnd = capCreateCaptureWindowA(iDevice, WS_VISIBLE Or WS_CHILD, 0, 0, 640,
           480, imagenfoto.Handle.ToInt32, 0)

        ' Connect to device
        '
        Dim CAMARA As Integer = Nothing
        Try
            For I = 0 To 10 'EN ALGUNOS EQUIPOS HAY QUE LANZAR LA FUNCION VARIAS VECES SI NO SE EJECUTA COMO ADMINISTRADOR
                CAMARA = SendMessage(hHwnd, WM_CAP_DRIVER_CONNECT, iDevice, 0)
                If CAMARA > 0 Then
                    'Set the preview scale

                    SendMessage(hHwnd, WM_CAP_SET_SCALE, True, 0)

                    'Set the preview rate in milliseconds
                    '
                    SendMessage(hHwnd, WM_CAP_SET_PREVIEWRATE, 66, 0)

                    'Start previewing the image from the camera
                    '
                    SendMessage(hHwnd, WM_CAP_SET_PREVIEW, True, 0)

                    ' Resize window to fit in picturebox
                    '
                    SetWindowPos(hHwnd, HWND_BOTTOM, 0, 0, imagenfoto.Width, imagenfoto.Height,
                            SWP_NOMOVE Or SWP_NOZORDER)
                    Exit For
                End If
            Next
        Catch ex As Exception
            DestroyWindow(hHwnd)
            btnIniciarCam.Visible = True
            MsgBox("NO PUEDO CONECTAR LA CAMARA")
        End Try

    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs)
        reiniciar()
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)

    End Sub







    Private Sub MenuStrip1_ItemClicked_1(sender As Object, e As ToolStripItemClickedEventArgs)

    End Sub

    Private Sub txtcedula_TextChanged(sender As Object, e As EventArgs) Handles txtcedula.TextChanged

    End Sub

    Private Sub txtcedula_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcedula.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If validaciones.saberingreso(txtcedula.Text) Then
                MessageBox.Show("EL documento ingresado ya fue registrado", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                My.Computer.Clipboard.SetText(txtcedula.Text)
                txtname.Focus()
            End If


        End If
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else : e.Handled = True
        End If
    End Sub

    Private Sub txtname_KeyDown(sender As Object, e As KeyEventArgs) Handles txtname.KeyDown
        Dim intMovimiento As Integer = 0
        If e.KeyCode = Keys.Down Then intMovimiento = 1
        If e.KeyCode = Keys.Up Then intMovimiento = -1
        lstNombres.BringToFront()
        If intMovimiento = 0 Then
            If e.KeyCode = Keys.End Then
                If lstNombres.Visible Then
                    SeñaleItemListView(lstNombres, lstNombres.Items.Count - 1, False)
                    Exit Sub
                End If
            End If
            Exit Sub
        End If
        If lstNombres.Visible Then
            SeñaleItemListView(lstNombres, intMovimiento)
            Exit Sub
        End If
        txtname.Select(txtname.Text.Length + 1, 0)

    End Sub




    Private Sub txtname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtname.KeyPress


        Select Case intbusqueda
            Case 1
                If Asc(e.KeyChar) = 13 Then
                    txtapellido.Focus()
                End If
                If Not Char.IsNumber(e.KeyChar) Then
                    e.Handled = False
                ElseIf Char.IsControl(e.KeyChar) Then
                    e.Handled = False
                Else : e.Handled = True
                End If
            Case 2
                If Asc(e.KeyChar) = 13 Then
                    If lstNombres.SelectedItems.Count = 0 Then Exit Sub
                    Dim intIdDeLaPersona = lstNombres.SelectedItems(0).Tag
                    intbusqueda = 1
                    If validaciones.Alimentar(txtcedula, intIdDeLaPersona.ToString, txtname, txtapellido, txttelefono, txtdireccion, txtEmail, dtFecha, imagenfoto, 1, intidmodificado, intIdPago, strFoto, txtEps, txtEmergencia, txttelefono2, txtRh, txtInstructor) Then
                        extraerhuella(intidmodificado)
                        btnGuardar.Enabled = False
                        btnModificar.Enabled = True
                    Else
                        MessageBox.Show("EL documento ingresado no se encontro en la base de datos", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                    lstNombres.Visible = False

                End If
        End Select
    End Sub

    Private Sub txttelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttelefono.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtdireccion.Focus()
        End If
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else : e.Handled = True
        End If
    End Sub

    Private Sub txtapellido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtapellido.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txttelefono.Focus()
        End If
        If Not Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else : e.Handled = True
        End If
    End Sub

    Private Sub txtdireccion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtdireccion.KeyPress
        If Asc(e.KeyChar) = 13 Then
            dtFecha.Focus()
        End If
    End Sub

    Private Sub Clientes_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing



    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        boohuella = True
        If validarCampos() Then
            Dim Builderconex As New MySqlConnectionStringBuilder()
            Builderconex.Server = Principal.servidor
            Builderconex.UserID = Principal.usuario
            Builderconex.Password = Principal.password
            Builderconex.Database = Principal.database
            Dim conexion As New MySqlConnection(Builderconex.ToString())
            conexion.Open()
            Dim cmd As New MySqlCommand()
            cmd = conexion.CreateCommand()
            cmd.CommandText = "UPDATE CLIENTE set cedula=?,nombre=?,apellido=?,telefono=?,direccion=?,correo=?,nacimiento=?,ruta=?,eps=?,contacto=?,telefono2=?,rh=?,instructor=?,huella=? WHERE id=" & intidmodificado
            cmd.Parameters.AddWithValue("cedula", txtcedula.Text.ToString())
            cmd.Parameters.AddWithValue("nombre", txtname.Text.ToString().ToUpper)
            cmd.Parameters.AddWithValue("apellido", txtapellido.Text.ToString().ToUpper)
            cmd.Parameters.AddWithValue("telefono", txttelefono.Text.ToString())
            cmd.Parameters.AddWithValue("direccion", txtdireccion.Text.ToString())
            cmd.Parameters.AddWithValue("correo", txtEmail.Text.ToString())
            Dim fechan As Date
            fechan = dtFecha.Value.Date
            cmd.Parameters.AddWithValue("nacimiento", fechan)
            cmd.Parameters.AddWithValue("ruta", strFoto)
            cmd.Parameters.AddWithValue("eps", txtEps.Text)
            cmd.Parameters.AddWithValue("contacto", txtEmergencia.Text)
            cmd.Parameters.AddWithValue("telefono2", txttelefono2.Text)
            cmd.Parameters.AddWithValue("rh", txtRh.Text)
            cmd.Parameters.AddWithValue("instructor", txtInstructor.Text)
            If boohuellacambiada Then
                Using fm As New MemoryStream(template.Bytes)
                    cmd.Parameters.AddWithValue("huella", fm.ToArray)
                End Using
            Else
                cmd.Parameters.AddWithValue("huella", memoriatemporal.ToArray)

            End If
            con.registreDatos("UPDATE pago SET cedula='" & txtcedula.Text & "' WHERE id='" & intIdPago & "'")
            If Not txtcedula.Equals(txtcedula.Text) Then
                con.registreDatos("UPDATE abonos set cedula='" & txtcedula.Text & "' where cedula='" & strCedulaAntigua & "'")
                con.registreDatos("UPDATE detalles set cedula='" & txtcedula.Text & "' where cedula='" & strCedulaAntigua & "'")
            End If
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            conexion.Close()
            conexion.Dispose()
            reiniciar()
            MessageBox.Show("El registro se actualizo correctamente", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Else : MessageBox.Show("Debe Alimentar Los Campos Minimos", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnBuscar_Click_1(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim strCedula As String = Nothing
        strCedula = InputBox("Escriba una cedula", "Mensaje del Sistema")
        If Not strCedula.Equals("") Then
            If validaciones.Alimentar(txtcedula, strCedula, txtname, txtapellido, txttelefono, txtdireccion, txtEmail, dtFecha, imagenfoto, 2, intidmodificado, intIdPago, strFoto, txtEps, txtEmergencia, txttelefono2, txtRh, txtInstructor) Then
                extraerhuella(intidmodificado)
                btnModificar.Enabled = True
                btnGuardar.Enabled = False
                strCedulaAntigua = txtcedula.Text

            Else
                MessageBox.Show("EL documento ingresado no se encontro en la base de datos", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

    End Sub

    Public Sub extraerhuella(idcliente As Integer)
        Dim Builderconex As New MySqlConnectionStringBuilder()
        Builderconex.Server = Principal.servidor
        Builderconex.UserID = Principal.usuario
        Builderconex.Password = Principal.password
        Builderconex.Database = Principal.database
        Dim conexion As New MySqlConnection(Builderconex.ToString())
        conexion.Open()
        Dim cmd As New MySqlCommand()
        cmd = conexion.CreateCommand
        cmd.CommandText = "SELECT huella FROM cliente WHERE id=" & idcliente
        Dim read As MySqlDataReader
        read = cmd.ExecuteReader()
        Dim verificado As Boolean = False
        Dim nombre As String = ""
        While (read.Read())
            Try
                Dim memoria As New MemoryStream(CType(read("huella"), Byte()))
                If Not memoria.Length = 0 Then
                    memoriatemporal = memoria
                Else
                    MsgBox("Ocurrió una excepción consultando la huella del registro, esta vacio. Es posible que se requiera que la vuelva a cargar.")
                End If
            Catch ex As Exception
                If ex.Message.Contains("No se puede convertir un objeto de tipo 'System.DBNull' al tipo 'System.Byte[]") Then
                    MsgBox("Ocurrió una excepción consultando la huella del registro, esta nulo. Es posible que se requiera que la vuelva a cargar.")
                End If
            End Try

        End While



    End Sub


    Private Sub txtname_TextChanged(sender As Object, e As EventArgs) Handles txtname.TextChanged
        Select Case intbusqueda
            Case 1

            Case 2
                If txtname.Text = "" Then Exit Sub
                Dim arlCoincidencias = Gestor1.DatosDeConsulta("SELECT id, nombre ,apellido FROM cliente WHERE concat(nombre,' ',apellido) LIKE '%" & txtname.Text & "%' ORDER BY nombre LIMIT 30", , Principal.cadenadeconexion)
                If Not arlCoincidencias.Count = 0 Then lstNombres.Visible = True
                lstNombres.Items.Clear()
                lstNombres.BeginUpdate()
                For Each Encontrado As ArrayList In arlCoincidencias
                    Dim lviEncontrado As New ListViewItem
                    lviEncontrado.Tag = Encontrado(0)
                    lviEncontrado.Text = Encontrado(1)
                    lviEncontrado.SubItems.Add(Encontrado(2))
                    lstNombres.Items.Add(lviEncontrado)
                Next
                lstNombres.EndUpdate()

        End Select
    End Sub



    Private Sub txttelefono_HideSelectionChanged(sender As Object, e As EventArgs) Handles txttelefono.HideSelectionChanged

    End Sub

    Private Sub BuscarClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarClientesToolStripMenuItem.Click
        Me.txtname.Focus()
        intbusqueda = 2
        Me.btnModificar.Enabled = True
        Me.btnGuardar.Enabled = False
    End Sub

    Private Sub vecesDedo_Click(sender As Object, e As EventArgs) Handles vecesDedo.Click


    End Sub

    Private Sub btLimpiar_Click(sender As Object, e As EventArgs) Handles btLimpiar.Click
        reiniciar()
    End Sub



    Private Sub txttelefono_TextChanged(sender As Object, e As EventArgs) Handles txttelefono.TextChanged

    End Sub

    Private Sub txtcedula_KeyDown(sender As Object, e As KeyEventArgs) Handles txtcedula.KeyDown

    End Sub

    Private Sub lstNombres_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstNombres.SelectedIndexChanged

    End Sub

    Private Sub WebCam1_CambioImagen()

    End Sub

    Private Sub imagenfoto_Click(sender As Object, e As EventArgs) Handles imagenfoto.Click

    End Sub

    Private Sub btncerrar_Click(sender As Object, e As EventArgs)
        Me.Dispose()
    End Sub

    Private Sub btncerrar_Click_1(sender As Object, e As EventArgs) Handles btncerrar.Click
        Me.Close()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

    End Sub



    Private Sub RegistreToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim strcedula As String = InputBox("Ingrese la cedula", "Mensaje del Sistema")
        If Not strcedula.Equals("") Then
            If validaciones.saberingreso(strcedula) Then
                Dim cad As String = "DELETE FROM PAGO WHERE CEDULA='" & strcedula & "';DELETE FROM abonos WHERE CEDULA='" & strcedula & "';DELETE FROM cliente WHERE CEDULA='" & strcedula & "'"
                con.registreDatos(cad)
                MessageBox.Show("EL cliente ha sido eliminado correctamente", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                MessageBox.Show("EL documento ingresado no se encontro en la base de datos", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub txtname_MarginChanged(sender As Object, e As EventArgs) Handles txtname.MarginChanged

    End Sub



    Private Sub lstNombres_MouseClick(sender As Object, e As MouseEventArgs) Handles lstNombres.MouseClick
        If lstNombres.SelectedItems.Count = 0 Then Exit Sub
        Dim intIdDeLaPersona = lstNombres.SelectedItems(0).Tag
        intbusqueda = 1
        If validaciones.Alimentar(txtcedula, intIdDeLaPersona.ToString, txtname, txtapellido, txttelefono, txtdireccion, txtEmail, dtFecha, imagenfoto, 1, intidmodificado, intIdPago, strFoto, txtEps, txtEmergencia, txttelefono2, txtRh, txtInstructor) Then
            extraerhuella(intidmodificado)
            btnGuardar.Enabled = False
            btnModificar.Enabled = True
            strCedulaAntigua = txtcedula.Text
        Else
            MessageBox.Show("EL documento ingresado no se encontro en la base de datos", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        lstNombres.Visible = False
    End Sub



    Private Sub EliminarClienteToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub



    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub
    Protected Function extraerCaracteristicas2(ByVal Sample As DPFP.Sample, ByVal Purpose As DPFP.Processing.DataPurpose) As DPFP.FeatureSet
        Dim extractor As New DPFP.Processing.FeatureExtraction()
        Dim alimentacion As DPFP.Capture.CaptureFeedback = DPFP.Capture.CaptureFeedback.None
        Dim caracteristicas = New DPFP.FeatureSet()
        extractor.CreateFeatureSet(Sample, Purpose, alimentacion, caracteristicas)
        If (alimentacion = DPFP.Capture.CaptureFeedback.Good) Then
            Return caracteristicas
        Else
            Return Nothing
        End If
    End Function

    Protected Sub Procesar1(ByVal Sample As DPFP.Sample)
        Dim caracteristicas As DPFP.FeatureSet = extraerCaracteristicas(Sample, DPFP.Processing.DataPurpose.Enrollment)
        If Not caracteristicas Is Nothing Then
            Try
                Enroller.AddFeatures(caracteristicas)
            Finally
                Select Case Enroller.TemplateStatus
                    Case DPFP.Processing.Enrollment.Status.Ready
                        pararCaptura()
                    Case DPFP.Processing.Enrollment.Status.Failed
                        Enroller.Clear()
                        pararCaptura()
                        iniciarCaptura()
                End Select
            End Try
        End If
    End Sub
    Private Sub EliminarToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles descargarUsuario.Click
        Dim strcedula As String = InputBox("Ingrese la cedula", "Mensaje del Sistema")
        If Not strcedula.Equals("") Then
            If Not existelocal(strcedula, "cliente") Then
                descargarDatosDeNube(strcedula)
            End If
            descargarPagoDeNube(strcedula)
            MessageBox.Show("El registro se hizo correctamente", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

        Else
            MessageBox.Show("EL documento ingresado no se encontro en la base de datos", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub ConsentimientoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsentimientoToolStripMenuItem.Click

        Principal.AbrirFormularios(Of leerConsentimiento)()

    End Sub



    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Dim strcedula As String = InputBox("Ingrese la cedula", "Mensaje del Sistema")
        If Not strcedula.Equals("") Then
            If Not existeOline(strcedula, "cliente") Then
                subirDatosANube(strcedula)
            End If

            subirPagoANube(strcedula)


            MessageBox.Show("El registro se hizo correctamente", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Else
            MessageBox.Show("EL documento ingresado no se encontro en la base de datos", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Dim strcedula As String = InputBox("Ingrese la cedula", "Mensaje del Sistema")
        If Not strcedula.Equals("") Then
            If validaciones.saberingreso(strcedula) Then
                Dim cad As String = "DELETE FROM PAGO WHERE CEDULA='" & strcedula & "';DELETE FROM abonos WHERE CEDULA='" & strcedula & "';DELETE FROM cliente WHERE CEDULA='" & strcedula & "'"
                con.registreDatos(cad)
                MessageBox.Show("EL cliente ha sido eliminado correctamente", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                MessageBox.Show("EL documento ingresado no se encontro en la base de datos", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub FichaFacialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FichaFacialToolStripMenuItem.Click
        Principal.AbrirFormularios(Of consentimientofacial)()
    End Sub
End Class
