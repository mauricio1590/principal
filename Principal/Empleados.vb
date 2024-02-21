Imports Soltec
Imports DPFP
Imports DPFP.Capture
Imports System.Text
Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.IO
Public Class Empleados
    Implements DPFP.Capture.EventHandler
    Dim intIdPago = 0
    Public intidmodificado As Integer = 0
    Dim intbusqueda As Integer = 1
    Public memoriatemporal As New MemoryStream()
    Public boohuellacambiada As Boolean = False
    Dim validaciones As conexion = New conexion()
    Public boohuella As Boolean = False
    Public strFoto As String = ""
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
            btnGuardar.Enabled = True
        End If
    End Sub
    Private Sub mostrarVeces(ByVal texto As String)
        If (vecesDedo.InvokeRequired) Then
            Dim deleg As New _delegadoMuestra(AddressOf mostrarVeces)
            Me.Invoke(deleg, New Object() {texto})
        Else
            vecesDedo.Text = texto
            ponerhuella(texto.ToString, huella1, huella2, huella3, huella4)
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
    Protected Function ConvertirSamplerAMapadeBits(ByRef Sample As DPFP.Sample) As Bitmap
        Dim convertidor As New DPFP.Capture.SampleConversion() 'variable tipo conversor de un DPFP.Sample
        Dim mapaBits As Bitmap = Nothing
        convertidor.ConvertToPicture(Sample, mapaBits)
        Return mapaBits
    End Function
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

    Private Sub Empleados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Computer.FileSystem.FileExists(Principal.Logo) Then
            Dim Imagen As New Bitmap(Principal.Logo)
            imagenfoto.Image = Imagen
            imagenHuella.Image = Imagen
            WebCam1.Visible = False
        End If
        colorBarras(PanelCabecera)
    End Sub


    Private Sub btncapturarhuellas_Click(sender As Object, e As EventArgs) Handles btncapturarhuellas.Click
        If Not Principal.intHuella = 1 Then
            MessageBox.Show("El sistema no esta confurado para hacer el control con huella", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        ponercheck(huella1, huella2, huella3, huella4)
    End Sub

    Private Sub txtcedula_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcedula.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If validaciones.saberingreso(txtcedula.Text, "EMPLEADO") Then
                MessageBox.Show("EL documento ingresado ya fue registrado", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
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

    Private Sub txtcedula_TextChanged(sender As Object, e As EventArgs) Handles txtcedula.TextChanged
        If txtname.Text = "" Then Exit Sub
        Dim arlCoincidencias = Gestor1.DatosDeConsulta("SELECT id, usuario FROM login WHERE usuario LIKE '%" & txtname.Text & "%' ORDER BY usuario LIMIT 30", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then lstNombres.Visible = True
        lstNombres.Items.Clear()
        lstNombres.BeginUpdate()
        For Each Encontrado As ArrayList In arlCoincidencias
            Dim lviEncontrado As New ListViewItem
            lviEncontrado.Tag = Encontrado(0)
            lviEncontrado.Text = Encontrado(1)
            lstNombres.Items.Add(lviEncontrado)
        Next
        lstNombres.EndUpdate()

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

    Public Sub SeñaleItemListView(Lista As ListView, Indice As Integer, Optional EsMovimiento As Boolean = True, Optional EsUnicoSeñalado As Boolean = True)
        If Lista.Items.Count = 0 Then Exit Sub
        Dim intIndiceSeñaladoAnterior As Integer = 0
        If Not Lista.SelectedItems.Count = 0 Then
            intIndiceSeñaladoAnterior = Lista.SelectedItems(0).Index
        Else
            Lista.Items(0).Selected = True
            Lista.Items(0).EnsureVisible()
            If EsUnicoSeñalado Then Exit Sub
        End If
        If EsUnicoSeñalado Then
            For Each Item As ListViewItem In Lista.Items
                Item.Selected = False
            Next
        End If
        If Not EsMovimiento Then
            If Indice < 0 Or Indice > Lista.Items.Count - 1 Then Exit Sub
            Lista.Items(Indice).Selected = True
            Lista.Items(Indice).EnsureVisible()
        Else
            If Indice < 0 Then
                If Not intIndiceSeñaladoAnterior + Indice < 0 Then
                    Lista.Items(intIndiceSeñaladoAnterior + Indice).Selected = True
                    Lista.Items(intIndiceSeñaladoAnterior + Indice).EnsureVisible()
                End If
            End If
            If Indice > 0 Then
                If Not intIndiceSeñaladoAnterior + Indice > Lista.Items.Count - 1 Then
                    Lista.Items(intIndiceSeñaladoAnterior + Indice).Selected = True
                    Lista.Items(intIndiceSeñaladoAnterior + Indice).EnsureVisible()
                End If
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
        cmd.CommandText = "SELECT huella FROM EMPLEADO WHERE id=" & idcliente
        Dim read As MySqlDataReader
        read = cmd.ExecuteReader()
        Dim verificado As Boolean = False
        Dim nombre As String = ""
        While (read.Read())
            Try
                Dim memoria As New MemoryStream(CType(read("huella"), Byte()))
                memoriatemporal = memoria
            Catch ex As Exception

            End Try

        End While



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
                    If validaciones.datosempleado(txtcedula, intIdDeLaPersona.ToString, txtname, txtapellido, txttelefono, imagenfoto, 1, strFoto, intidmodificado) Then
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


    Private Sub txtname_TextChanged(sender As Object, e As EventArgs) Handles txtname.TextChanged
        Select Case intbusqueda
            Case 1

            Case 2
                If txtname.Text = "" Then Exit Sub
                Dim arlCoincidencias = Gestor1.DatosDeConsulta("SELECT id, nombre ,apellido FROM EMPLEADO WHERE nombre LIKE '%" & txtname.Text & "%' ORDER BY nombre LIMIT 30", , Principal.cadenadeconexion)
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

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim strCedula As String = Nothing
        strCedula = InputBox("Escriba una cedula", "Mensaje del Sistema")
        If Not strCedula.Equals("") Then
            If validaciones.datosempleado(txtcedula, strCedula, txtname, txtapellido, txttelefono, imagenfoto, 2, strFoto, intidmodificado) Then
                extraerhuella(intidmodificado)
                btnModificar.Enabled = True
                btnGuardar.Enabled = False
            Else
                MessageBox.Show("EL documento ingresado no se encontro en la base de datos", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub BuscarClientesToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BuscarEmpleadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarEmpleadoToolStripMenuItem.Click
        txtname.Focus()
        intbusqueda = 2
        btnModificar.Enabled = True
        btnGuardar.Enabled = False
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
   
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
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
            cmd.CommandText = "INSERT INTO empleado (cedula,nombre,apellido,cell,ruta,huella) VALUES (?,?,?,?,?,?)"
            cmd.Parameters.AddWithValue("cedula", txtcedula.Text.ToString())
            cmd.Parameters.AddWithValue("nombre", txtname.Text.ToString().ToUpper)
            cmd.Parameters.AddWithValue("apellido", txtapellido.Text.ToString().ToUpper)
            cmd.Parameters.AddWithValue("cell", txttelefono.Text.ToString())
            cmd.Parameters.AddWithValue("ruta", strFoto)
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
    Private Sub reiniciar()
        If My.Computer.FileSystem.FileExists(Principal.Logo) Then
            Dim Imagen As New Bitmap(Principal.Logo)
            intIdPago = 0
            WebCam1.Visible = False
            imagenfoto.Image = Nothing
            imagenfoto.Image = Imagen
            imagenHuella.Image = Imagen
        End If
        txtcedula.Text = ""
        txtname.Text = ""
        txtapellido.Text = ""
        txttelefono.Text = ""

        boohuella = False
        boohuellacambiada = False
        If Not Enroller Is Nothing Then
            Enroller.Clear()
            Dim texto As New StringBuilder()
            texto.AppendFormat("Necesitas pasar el dedo {0} veces", Enroller.FeaturesNeeded)
            mostrarVeces(texto.ToString)
        End If
        btnModificar.Enabled = False
        btnGuardar.Enabled = True
        'pararCaptura()
        intbusqueda = 1


    End Sub
    Private Sub btLimpiar_Click(sender As Object, e As EventArgs) Handles btLimpiar.Click
        reiniciar()
    End Sub

    Private Sub txttelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttelefono.KeyPress
        If Asc(e.KeyChar) = 13 Then
        End If
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else : e.Handled = True
        End If
    End Sub

    Private Sub txttelefono_TextChanged(sender As Object, e As EventArgs) Handles txttelefono.TextChanged

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

 

    Private Sub btnIniciarCam_Click(sender As Object, e As EventArgs) Handles btnIniciarCam.Click
        WebCam1.Start()
        If WebCam1.Visible = False Then
            WebCam1.Visible = True
        End If
    End Sub

    Private Sub btnCapturar_Click(sender As Object, e As EventArgs) Handles btnCapturar.Click
        WebCam1.Stop()
        imagenfoto.Image = WebCam1.Imagen
        Dim strHora As String = Now.ToString.Replace(".", "_").Replace("/", "_").Replace(" ", "_").Replace(":", "_")
        strFoto = Principal.strunidad & ":\SISTEMGYM_DATOS\fotos\" & Now.Day & "_" & txtname.Text & "_" & txtcedula.Text & strHora & ".jpg"
        imagenfoto.Image.Save(strFoto)

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
            cmd.CommandText = "UPDATE EMPLEADO set cedula=?,nombre=?,apellido=?,cell=?,ruta=?,huella=? WHERE id=" & intidmodificado
            cmd.Parameters.AddWithValue("cedula", txtcedula.Text.ToString())
            cmd.Parameters.AddWithValue("nombre", txtname.Text.ToString().ToUpper)
            cmd.Parameters.AddWithValue("apellido", txtapellido.Text.ToString().ToUpper)
            cmd.Parameters.AddWithValue("cell", txttelefono.Text.ToString())
            cmd.Parameters.AddWithValue("ruta", strFoto)
            If boohuellacambiada Then
                Using fm As New MemoryStream(template.Bytes)
                    cmd.Parameters.AddWithValue("huella", fm.ToArray)
                End Using
            Else
                cmd.Parameters.AddWithValue("huella", memoriatemporal.ToArray)

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

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Me.Close()
    End Sub

    Private Sub PanelCabecera_Paint(sender As Object, e As PaintEventArgs) Handles PanelCabecera.Paint

    End Sub

    Private Sub lstNombres_MouseClick(sender As Object, e As MouseEventArgs) Handles lstNombres.MouseClick
        If lstNombres.SelectedItems.Count = 0 Then Exit Sub
        Dim intIdDeLaPersona = lstNombres.SelectedItems(0).Tag
        If validaciones.datosempleado(txtcedula, intIdDeLaPersona.ToString, txtname, txtapellido, txttelefono, imagenfoto, 1, strFoto, intidmodificado) Then
            extraerhuella(intidmodificado)
            btnGuardar.Enabled = False
            btnModificar.Enabled = True
        Else
            MessageBox.Show("EL documento ingresado no se encontro en la base de datos", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        lstNombres.Visible = False

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub lstNombres_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstNombres.SelectedIndexChanged

    End Sub
End Class