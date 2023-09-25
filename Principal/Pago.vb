Imports DPFP
Imports DPFP.Capture
Imports System.Text
Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.IO
Imports System.Globalization

Public Class Pago
    Implements DPFP.Capture.EventHandler
    Dim con As New conexion()
    Dim intIdCliente As Integer = 0
    Dim intdiasRestantes As Integer = 0
    Dim intextraer As Integer = 0
    Dim booabono As Boolean = False
    Dim strValorAbono As String = "0"
    Dim intAbono As Integer = 0
    Dim intPagoTarjeta As Integer = 2
    Dim intSaldo As Integer = 0
    Dim strcedula As String = ""
    Public strCedulaSaldo As String = ""
    Dim strruta As String = ""
    Dim strnombre As String = ""
    Dim strfechacorte As String = ""
    Dim intTiempo As Double = 0
    Dim booEstadoHuellero As Boolean = False
    Dim strNombreDetectado = "Ninguno"
    Dim intBanco As Integer = 0
    Dim dsSoltec As New DataSet
    Dim Gestor1 As New Soltec.Gestor
    Dim dwCliente As DataView
    Dim dwPago As DataView
    Dim imp As New Imprimir()

    Dim diastotal As Integer = 0


    Protected Overridable Sub Init()
        Try
            Captura = New Capture()
            If Not Captura Is Nothing Then
                Captura.EventHandler = Me

            Else
                MessageBox.Show("NO PUDO INSTANCIAR LA CAPTURA")
            End If

        Catch ex As Exception
            MessageBox.Show("NO PUDO INICIALIZAR  LA CAPTURA")
        End Try
    End Sub
    Protected Sub iniciarCaptura()
        If Not Captura Is Nothing Then
            Try
                Captura.StartCapture()
                booEstadoHuellero = True
            Catch ex As Exception
                MessageBox.Show("NO PUDO INICIAR LA CAPTURA")
                ' Form1.PanelContenedor.Controls.RemoveAt(0)
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
    Protected Function ConvertirSamplerAMapadeBits(ByRef Sample As DPFP.Sample) As Bitmap
        Dim convertidor As New DPFP.Capture.SampleConversion() 'variable tipo conversor de un DPFP.Sample
        Dim mapaBits As Bitmap = Nothing
        convertidor.ConvertToPicture(Sample, mapaBits)
        Return mapaBits
    End Function
    Public Sub ponerImagen(ByVal bmp)
        imagenHuella.Image = bmp
    End Sub
    Public Function convertirfecha(fechastring As String) As String

        Dim date1 As DateTime = DateTime.ParseExact(fechastring, "dd/MM/yyyy", CultureInfo.InvariantCulture)

        Dim reformatted As String = date1.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)

        Return reformatted

    End Function

    Private Sub Pago_CursorChanged(sender As Object, e As EventArgs) Handles Me.CursorChanged

    End Sub
    Private Sub Pago_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ponerFoto()
        CreeTabla("cliente", "SELECT * FROM cliente where huella is not null and cedula not in (select cedula from pago) order by huella")
        dwCliente = dsSoltec.Tables("cliente").DefaultView
        dwCliente.Sort = "huella"
        CreeTabla("pago", "SELECT c.cedula,c.nombre,c.apellido,c.huella,c.ruta,p.fecha_corte,p.id " & vbCrLf &
                   "FROM cliente c,pago p where c.cedula=p.cedula AND c.huella IS NOT  null order by huella")
        dwPago = dsSoltec.Tables("pago").DefaultView
        dwPago.Sort = "huella"
        btnModificar.Enabled = False
        If Principal.intPagoAbono = 2 Then
            mnabonos.Visible = False
        End If
        If Not Principal.intHuella = 1 Then
            BuscarPorHuellla.Visible = False
        End If
        If Principal.intVariosAbonos = 2 Then
            variosAbonos.Visible = False
            variosAbonos.Enabled = False
        End If
        txtCedula.Focus()
        colorBarras(PanelCabecera)
    End Sub

    Public Sub CreeTabla(TablaReal As String, Optional ByVal ConsultaCompleta As String = "", Optional ByVal TablaVirtual As String = "")
        Dim cnLocal As New MySqlConnection(Principal.cadenadeconexion)
        cnLocal.Open()
        If TablaVirtual = "" Then TablaVirtual = TablaReal
        If ConsultaCompleta = "" Then ConsultaCompleta = "SELECT * FROM " & TablaVirtual
        Try
            ' dsSoltec.Tables(TablaVirtual).Clear()
        Catch ex As Exception
        End Try
        Dim daTabla As New MySqlDataAdapter(ConsultaCompleta, cnLocal)
        daTabla.Fill(dsSoltec, TablaVirtual)
        cnLocal.Close()
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
    Public Sub OnComplete(Capture As Object, ReaderSerialNumber As String, Sample As Sample) Implements EventHandler.OnComplete
        'Me.Text = "VERIFICANDO LA HUELLA"
        '  ponerImagen(ConvertirSamplerAMapadeBits(Sample))
        Dim caracteristicas As DPFP.FeatureSet = extraerCaracteristicas(Sample, DPFP.Processing.DataPurpose.Verification)
        If Not caracteristicas Is Nothing Then
            Dim result As New DPFP.Verification.Verification.Result()
            Dim arlCoincidencias As ArrayList = Gestor1.DatosDeConsulta("SELECT c.cedula,c.nombre,c.apellido,c.huella,c.ruta,p.fecha_corte,p.id " & vbCrLf &
                   "FROM cliente c,pago p where c.cedula=p.cedula AND c.huella IS NOT  null order by huella", , Principal.cadenadeconexion)
            For Each Pago In arlCoincidencias
                Dim memoria As New MemoryStream(CType(Pago(3), Byte()))
                template.DeSerialize(memoria.ToArray)
                verificador.Verify(caracteristicas, template, result)
                If (result.Verified) Then
                    strNombreDetectado = "ESTA EN PAGO"
                    intextraer = 1
                    strcedula = Pago(0)
                    Exit For
                End If
            Next
            If intextraer = 0 Then
                For Each cliente In dwCliente
                    Dim memoria As New MemoryStream(CType(cliente("huella"), Byte()))
                    template.DeSerialize(memoria.ToArray)
                    verificador.Verify(caracteristicas, template, result)
                    If (result.Verified) Then
                        strNombreDetectado = "ESTA EN cliente"
                        strcedula = cliente("cedula")
                        intextraer = 2
                        Exit For
                    End If
                Next
            End If
            If intextraer = 0 Then
                intextraer = 3
                strNombreDetectado = "no existe"

            End If

        End If


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

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        'Captura.StopCapture()
        'Captura.Dispose()
        If Not validarCampos() AndAlso cedulaEnCliente(txtCedula.Text) Then Exit Sub
        Dim fecha As Date = CDate(txtFecha.Text)
        If Not lstBancos.SelectedItems.Count = 0 Then
            intBanco = lstBancos.SelectedItems(0).Tag
        End If
        If Not ValideCedulaExistente(txtCedula.Text.ToString, "cliente") Then
            MessageBox.Show("La cedula no corresponde a un Usuario Inscrito", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If tarifaRestringida(lstTarifas.SelectedItems(0).Tag, 4) Then
            Dim strDiferido As String = InputBox("Escriba la cedula del cliente referido", "Mensaje del Sistema")
            If strDiferido = "" Then : MessageBox.Show("registre una cedula", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub : End If
            If Not validarReferido(strDiferido) Then MessageBox.Show("el usuario suministrado es invalido o ya tiene un referido", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            con.registreDatos("update  pago set referido ='" & txtCedula.Text & "' where cedula ='" & strDiferido & "'")
        End If

        If con.registreDatos("INSERT INTO PAGO (cedula,fecha_corte,fecha_pago,idprecio)" & vbCrLf &
                                "VALUES ('" & txtCedula.Text & "', '" & Format(fecha, "yyyy-MM-dd") & "', CURDATE()," & vbCrLf &
                                " '" & lstTarifas.SelectedItems(0).Tag & "') ") Then

                If Not ValideCedulaExistente(txtCedula.Text.ToString, "pago") Then
                    MessageBox.Show("La cedula no corresponde a un Usuario Inscrito en Pagos", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                con.registreDatos("INSERT INTO detalles (cedula,fecha_pago,fecha_fin,tiempo,valor,tarjeta,banco) VALUES " & vbCrLf &
                              "('" & txtCedula.Text & "',current_date,'" & txtFecha.Text & "','" & txttarifa.Text & "','" & txtValor.Text & "','" & intPagoTarjeta & "','" & intBanco & "')")
                If booabono Then
                    con.registreDatos("INSERT INTO abonos (cedula,abono,saldo,estado,dia)VALUES" & vbCrLf &
                                    "('" & txtCedula.Text & "','" & intAbono & "','" & intSaldo & "',1,0)")
                End If
                registreMovimiento(1, 0, txtValor.Text, Principal.intidusuario)
                Select Case (Principal.intTipoImpresion)
                    Case 0

                    Case 1
                        Dim res = MessageBox.Show("Desea Imprimir la factura ", "Informacion Del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                        If res = Windows.Forms.DialogResult.Yes Then
                            imp.GenereImpresion(txtNombre.Text, txtCedula.Text, txttarifa.Text, txtValor.Text)
                        End If
                    Case 2
                        imp.GenereImpresion(txtNombre.Text, txtCedula.Text, txttarifa.Text, txtValor.Text)
                End Select



                limipar()
                MessageBox.Show("El pago se Registro Exitosamente", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If
            End Sub

    Private Sub Pago_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Timer2.Enabled = True
    End Sub

    Private Sub Pago_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        pararCaptura()
        Clientes.txtcedula.Focus()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If intextraer = 1 Then
            If Not con.saberSaldo(strcedula) Then
                btnGuardar.Enabled = False
                btnModificar.Enabled = True
                con.ExtraerUltimoPago(txtNombre, imagenHuella, txtFecha, strcedula, intdiasRestantes, intIdCliente, txttarifa)
                txtCedula.Text = strcedula
                txttarifa.Focus()
                traerTarias()
                intextraer = 0
            Else
                intextraer = 0
                Principal.strCedulaGeneral = strcedula
                Dim pg As New PagarSaldo()
                pg.ShowDialog()
            End If

        ElseIf intextraer = 2 Then
            con.ExtrarCliente(txtNombre, imagenHuella, strcedula) : txttarifa.Focus() : traerTarias() : txtCedula.Text = strcedula
            intextraer = 0
            'ElseIf intextraer = 3 Then
            '    intextraer = 0
            '    MessageBox.Show("Esta huella no tiene registros", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    limipar()
            '    iniciarCaptura()
        End If

    End Sub

    Private Sub imagenHuella_Click(sender As Object, e As EventArgs) Handles imagenHuella.Click

    End Sub

    Private Sub RegistrarTarifaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarTarifaToolStripMenuItem.Click
        Principal.intValidar = 1
        Dim validar As New VALIDAR()
        validar.ShowDialog()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles txttarifa.TextChanged


    End Sub

    Public Sub traerTarias()
        Dim arlCoincidencias = Gestor1.DatosDeConsulta("SELECT serial,tipo,valor,dias FROM precio  order by ord", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then lstTarifas.Visible = True
        lstTarifas.Items.Clear()
        lstTarifas.BeginUpdate()
        For Each Encontrado As ArrayList In arlCoincidencias
            Dim lviEncontrado As New ListViewItem
            lviEncontrado.Tag = Encontrado(0)
            lviEncontrado.Text = Encontrado(1)
            lviEncontrado.SubItems.Add(Encontrado(2))
            lviEncontrado.SubItems.Add(Encontrado(3))
            lstTarifas.Items.Add(lviEncontrado)
        Next
        lstTarifas.EndUpdate()
        intextraer = 0
    End Sub

    Private Sub txtCedula_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCedula.KeyPress
        If Asc(e.KeyChar) = 13 Then
            intdiasRestantes = 0
            If con.ExtraerUltimoPago(txtNombre, imagenHuella, txtFecha, txtCedula.Text, intdiasRestantes, intIdCliente, txttarifa) Then
                txttarifa.Focus() : traerTarias() : btnGuardar.Enabled = False : btnModificar.Enabled = True
            ElseIf con.ExtrarCliente(txtNombre, imagenHuella, txtCedula.Text) Then : txttarifa.Focus() : traerTarias()
            Else : MessageBox.Show("Cliente No Registrado", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtCedula.Focus()
            End If
            If con.saberSaldo(txtCedula.Text) Then
                Principal.strCedulaGeneral = txtCedula.Text
                Dim pg As New PagarSaldo()
                pg.ShowDialog()
            End If
        End If
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else : e.Handled = True
        End If


    End Sub



    Private Sub txttarifa_KeyDown(sender As Object, e As KeyEventArgs) Handles txttarifa.KeyDown
        lstTarifas.Visible = True
        Dim intMovimiento As Integer = 0
        If e.KeyCode = Keys.Down Then intMovimiento = 1
        If e.KeyCode = Keys.Up Then intMovimiento = -1
        lstTarifas.BringToFront()
        If intMovimiento = 0 Then
            If e.KeyCode = Keys.End Then
                If lstTarifas.Visible Then
                    SeñaleItemListView(lstTarifas, lstTarifas.Items.Count - 1, False)
                    Exit Sub
                End If
            End If
            Exit Sub
        End If
        If lstTarifas.Visible Then
            SeñaleItemListView(lstTarifas, intMovimiento)
            Exit Sub
        End If
        txttarifa.Select(txttarifa.Text.Length + 1, 0)

    End Sub



    Private Sub txttarifa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttarifa.KeyPress
        If Asc(e.KeyChar) = 13 Then
            adicionefecha()

        End If
    End Sub
    Function cedulaEnCliente(ced As String) As Boolean
        Dim boosaber As Boolean = False
        Dim arlCoincidencias As ArrayList = Gestor1.DatosDeConsulta("select count(*) from cliente where cedula=" & ced & "", , Principal.cadenadeconexion)
        If arlCoincidencias.Count >= 1 Then
            boosaber = True
        End If
        Return boosaber
    End Function
    Function validarCampos() As Boolean
        Dim booSaber As Boolean = False
        If Not txtCedula.Text.Equals("") Then
            If Not txtValor.Text.Equals("") Then
                If Not lstTarifas.SelectedItems.Count = 0 Then
                    If chkTarjeta.Checked AndAlso Not lstBancos.SelectedItems.Count = 0 Then
                        booSaber = True

                    ElseIf Not chkTarjeta.Checked Then
                        booSaber = True
                    Else
                        MessageBox.Show("Seleccione Un Banco", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("Ingrese una Tarifa antes de continuar", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Else
                MessageBox.Show("Ingrese una Tarifa antes de continuar", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txttarifa.Focus()
            End If
        Else : MessageBox.Show("Ingrese una cedula antes de continuar", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtCedula.Focus()
        End If

        Return booSaber
    End Function
    Sub ponerFoto(Optional ByVal foto As String = "1")
        If foto.Equals("1") Then
            If My.Computer.FileSystem.FileExists(Principal.Logo) Then
                Dim Imagen As New Bitmap(Principal.Logo)
                imagenHuella.Image = Imagen
            End If
        ElseIf My.Computer.FileSystem.FileExists(foto) Then
            Dim Imagen As New Bitmap(foto)
            imagenHuella.Image = Imagen
        End If


    End Sub
    Public Sub limpielista()
        For Each item As ListViewItem In lstBancos.SelectedItems
            item.Selected = False
        Next
        For Each item As ListViewItem In lstTarifas.SelectedItems
            item.Selected = False
        Next
    End Sub


    Public Sub limipar()
        lbldia.Text = Nothing
        txtCedula.Text = ""
        txtNombre.Text = ""
        txtFecha.Text = ""
        booabono = False
        strValorAbono = "0"
        intAbono = 0
        txtBanco.Text = ""
        intBanco = 0
        limpielista()
        intSaldo = 0
        txttarifa.Text = ""
        chkTarjeta.Checked = False
        intPagoTarjeta = 2
        txtValor.Text = ""
        txtCedula.Focus()
        intdiasRestantes = 0
        Principal.strCedulaGeneral = ""
        btnGuardar.Enabled = True
        btnModificar.Enabled = False
        ponerFoto()
        lstTarifas.Visible = False
        CreeTabla("pago", "SELECT c.cedula,c.nombre,c.apellido,c.huella,c.ruta,p.fecha_corte,p.id " & vbCrLf &
                   "FROM cliente c,pago p where c.cedula=p.cedula AND c.huella IS NOT  null order by huella")
        dwPago = dsSoltec.Tables("pago").DefaultView
        dwPago.Sort = "huella"
        pararCaptura()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        txtCedula.Focus()
        Timer2.Enabled = False
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If Not validarCampos() AndAlso cedulaEnCliente(txtCedula.Text) Then Exit Sub
        Dim fecha As Date = CDate(txtFecha.Text)

        'If tarifaRestringida(lstTarifas.SelectedItems(0).Tag, 3) AndAlso Not validarUsuarioInactivo(lstTarifas.SelectedItems(0).Tag, txtCedula.Text) Or UsuarioNuevo(txtCedula.Text) Then

        '    MessageBox.Show("EL usuario no cumple los requisitos de la tarifa", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'End If

        If tarifaRestringida(lstTarifas.SelectedItems(0).Tag, 4) Then
            If validarUsuarioInactivo(lstTarifas.SelectedItems(0).Tag, txtCedula.Text) Then

                Dim strDiferido As String = InputBox("Escriba la cedula del cliente referido", "Mensaje del Sistema")
                If strDiferido = "" Then : MessageBox.Show("registre una cedula", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub : End If
                If Not validarReferido(strDiferido) Then MessageBox.Show("el usuario suministrado es invalido o ya tiene un referido", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                con.registreDatos("update  pago set referido ='" & txtCedula.Text & "' where cedula ='" & strDiferido & "'")
            Else
                MessageBox.Show("El usuario debe estar inactivo por mas de 6 meses", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            End If
        End If
            If Not lstBancos.SelectedItems.Count = 0 Then
            intBanco = lstBancos.SelectedItems(0).Tag
        End If
        If Not ValideCedulaExistente(txtCedula.Text.ToString, "cliente") Then
            MessageBox.Show("La cedula no corresponde a un Usuario Inscrito en Pagos", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If txttarifa.Text = "DIA" And fecha >= DateAdd(DateInterval.Day, 3, Now.Date) Then
            MessageBox.Show("Error de fecha en el registro de Dias", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim strFechaPago As String = fecha
        Dim strfechaDetalle As String = txtFecha.Text

        If con.registreDatos("UPDATE PAGO SET fecha_corte='" & Format(fecha, "yyyy-MM-dd") & "',fecha_pago=CURDATE()," & vbCrLf &
                        " idprecio='" & lstTarifas.SelectedItems(0).Tag & "' WHERE id='" & intIdCliente & "'") Then

            If Not ValideCedulaExistente(txtCedula.Text.ToString, "pago") Then
                MessageBox.Show("La cedula no corresponde a un Usuario Inscrito en Pagos", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            con.registreDatos("INSERT INTO detalles (cedula,fecha_pago,fecha_fin,tiempo,valor,tarjeta,banco) VALUES " & vbCrLf &
                             "('" & txtCedula.Text & "',current_date,'" & txtFecha.Text & "','" & txttarifa.Text & "','" & txtValor.Text & "','" & intPagoTarjeta & "','" & intBanco & "')")
            If booabono Then
                con.registreDatos("INSERT INTO abonos (cedula,abono,saldo,estado,dia)VALUES" & vbCrLf &
                                  "('" & txtCedula.Text & "','" & intAbono & "','" & intSaldo & "',1,0)")
            End If
            registreMovimiento(1, 0, txtValor.Text, Principal.intidusuario)
            MessageBox.Show("El pago se Acturalizo Exitosamente", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Select Case (Principal.intTipoImpresion)
                Case 0

                Case 1
                    Dim res = MessageBox.Show("Desea Imprimir la factura ", "Informacion Del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    If res = Windows.Forms.DialogResult.Yes Then
                        imp.GenereImpresion(txtNombre.Text, txtCedula.Text, txttarifa.Text, txtValor.Text)
                    End If
                Case 2
                    imp.GenereImpresion(txtNombre.Text, txtCedula.Text, txttarifa.Text, txtValor.Text)
            End Select
            limipar()
        End If


    End Sub

    Private Sub txtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged
    End Sub

    Private Sub HacerAbonoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnAbono.Click

        If Not lstTarifas.SelectedItems.Count = 0 Then
            booabono = True
            strValorAbono = InputBox("Ingrese el valor del abono", "Mensaje del Sistema")
            If IsNumeric(strValorAbono) Then
                intAbono = strValorAbono
                intSaldo = txtValor.Text - intAbono
                txtValor.Text = intAbono
                If btnGuardar.Visible Then
                    btnGuardar.Focus()
                Else
                    btnModificar.Focus()
                End If
            Else
                MessageBox.Show("El monto ingresado es incorrecto", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else : MessageBox.Show("Debe seleccionar una tarifa primero", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnlimpiar_Click(sender As Object, e As EventArgs) Handles btnlimpiar.Click

        limipar()
    End Sub

    Private Sub PagarSaldoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnSaldo.Click
        Dim pg As New PagarSaldo()
        pg.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        If Not booEstadoHuellero Then

        End If
    End Sub

    Private Sub btncerrar_Click(sender As Object, e As EventArgs)
        Captura.StopCapture()
        Me.Dispose()
    End Sub

    Private Sub Pago_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

    End Sub


    Private Sub btncerrar_Click_1(sender As Object, e As EventArgs) Handles btncerrar.Click
        Me.Close()
    End Sub

    Private Sub Pago_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus

    End Sub

    Private Sub BuscarPorHuellaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarPorHuellla.Click
        Init()
        iniciarCaptura()


    End Sub

    Private Sub ModificarFechaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificarFechaToolStripMenuItem.Click
        Principal.intValidar = 2
        If Not Principal.intNivelUsuario = 4 Then
            Dim validar As New VALIDAR()
            validar.ShowDialog()
        Else
            Dim cam As New CambiarFecha()
            cam.ShowDialog()

        End If
       
    End Sub

    Private Sub lstTarifas_MouseClick(sender As Object, e As MouseEventArgs) Handles lstTarifas.MouseClick
        adicionefecha()
    End Sub
    Function adicionefecha() As Integer

        Dim fecha As Date
        Dim aux As Integer = 0
        If lstTarifas.SelectedItems.Count = 0 Then Return 1
        Dim intIdDeLaPersona = lstTarifas.SelectedItems(0).Tag
        txttarifa.Text = lstTarifas.SelectedItems(0).Text
        txtValor.Text = lstTarifas.SelectedItems(0).SubItems(1).Text
        Dim dias As Integer = lstTarifas.SelectedItems(0).SubItems(2).Text
        If intdiasRestantes > 0 Then
            dias += intdiasRestantes
        End If
        If dias = 0 Then dias = 1
        Dim intFormatoDia As Integer = Principal.intFormatoDias

        Select Case intFormatoDia

            Case 1
                lbldia.Text = dias
                Select Case dias
                    Case Is <= 30
                        fecha = DateAdd(DateInterval.Day, dias, Today)
                    Case Is < 365
                        fecha = DateAdd(DateInterval.Day, dias, Today)
                'fecha = DateAdd(DateInterval.Month, dias / 30, Today)
                'If Not dias Mod 30 = 0 Then fecha = DateAdd(DateInterval.Day, dias Mod 30, fecha)
                    Case Is >= 365
                        fecha = DateAdd(DateInterval.Year, 1, Today)
                End Select
                DateAdd(DateInterval.Day, -1, fecha)
                'If Not Now.Date.Month = 2 Then fecha = DateAdd(DateInterval.Day, -1, fecha)
                If dias <= 2 Then fecha = DateAdd(DateInterval.Day, -1, fecha)
                txtFecha.Text = fecha.Date
                lstTarifas.Visible = False
            Case 2
                Dim diasDelMes As Integer = Date.DaysInMonth(Now.Year, Now.Month)
                If (diasDelMes = 30 OrElse diasDelMes = 31) AndAlso dias < 5 Then dias = dias - 1
                If (diasDelMes = 28 And dias < 4) Then dias = dias - 1
                If (diasDelMes = 28 OrElse diasDelMes = 29) AndAlso dias > 15 Then dias = dias - 3
                If diasDelMes = 30 AndAlso dias = 30 Then dias = dias - 1
                diastotal = dias
                Select Case diastotal
                    Case Is <= 30
                        fecha = DateAdd(DateInterval.Day, diastotal, Today)
                    Case Is < 365
                        fecha = DateAdd(DateInterval.Day, diastotal, Today)
                   'fecha = DateAdd(DateInterval.Month, dias / 30, Today)
                   'If Not dias Mod 30 = 0 Then fecha = DateAdd(DateInterval.Day, dias Mod 30, fecha)
                    Case Is >= 365
                        fecha = DateAdd(DateInterval.Year, 1, Today)
                End Select
                DateAdd(DateInterval.Day, -1, fecha)
                'If Not Now.Date.Month = 2 Then fecha = DateAdd(DateInterval.Day, -1, fecha)
                '  If dias <= 2 Then fecha = DateAdd(DateInterval.Day, -1, fecha)
                txtFecha.Text = fecha.Date
                lstTarifas.Visible = False
        End Select

        Return 1
    End Function

    Private Shared Function NewMethod(dias As Integer) As Integer
        Return dias
    End Function

    Private Sub RegistrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarToolStripMenuItem.Click

        If Me.btnGuardar.Enabled Then
            Me.btnGuardar.PerformClick()
        Else
            Me.btnModificar.PerformClick()
        End If
    End Sub

    Private Sub TarifasEspecialesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TarifasEspecialesToolStripMenuItem.Click
        Dim tespecial As New TarifasEspeciales
        tespecial.ShowDialog()
    End Sub

    Private Sub txtCedula_TextChanged(sender As Object, e As EventArgs) Handles txtCedula.TextChanged

    End Sub

    Private Sub PagarCuotaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles variosAbonos.Click
        Principal.AbrirFormularios(Of SaldoMensualidad)()

    End Sub

    Private Sub chkTarjeta_CheckedChanged(sender As Object, e As EventArgs) Handles chkTarjeta.CheckedChanged
        If chkTarjeta.Checked Then
            intPagoTarjeta = 1
            txtBanco.Visible = True
            lstBancos.Visible = True
            mostrarBancosCuentas(lstBancos)
            txtBanco.Focus()
        Else
            intPagoTarjeta = 2
            txtBanco.Visible = False
            lstBancos.Visible = False
        End If
    End Sub

    Private Sub EliminarAbonoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarAbonoToolStripMenuItem.Click
        Principal.AbrirFormularios(Of EliminarSaldoMensualidad)()
    End Sub



   
    Private Sub txtBanco_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBanco.KeyDown
        lstBancos.Visible = True
        Dim intMovimiento As Integer = 0
        If e.KeyCode = Keys.Down Then intMovimiento = 1
        If e.KeyCode = Keys.Up Then intMovimiento = -1
        lstBancos.BringToFront()
        If intMovimiento = 0 Then
            If e.KeyCode = Keys.End Then
                If lstBancos.Visible Then
                    SeñaleItemListView(lstBancos, lstBancos.Items.Count - 1, False)
                    Exit Sub
                End If
            End If
            Exit Sub
        End If
        If lstBancos.Visible Then
            SeñaleItemListView(lstBancos, intMovimiento)
            Exit Sub
        End If
        txtBanco.Select(txtBanco.Text.Length + 1, 0)

    End Sub

    Private Sub txtBanco_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBanco.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtBanco.Text = lstBancos.SelectedItems(0).Text
            lstBancos.Visible = False
        End If

    End Sub

    Private Sub lstBancos_MouseClick(sender As Object, e As MouseEventArgs) Handles lstBancos.MouseClick
        txtBanco.Text = lstBancos.SelectedItems(0).Text
        lstBancos.Visible = False
    End Sub



    Private Sub CrearDeudaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CrearDeudaToolStripMenuItem.Click
        Principal.intValidar = 11
        If Not Principal.intNivelUsuario = 4 Then
            If Principal.validado = True Then
                creeSaldo()

            End If
        Else
            creeSaldo()

        End If
    End Sub
End Class