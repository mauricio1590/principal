Imports DPFP
Imports DPFP.Capture
Imports System.Text
Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.IO
Imports System.Globalization

Public Class pagoSpa
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
    Dim dsSoltec As New DataSet
    Dim Gestor1 As New Soltec.Gestor
    Dim dwCliente As DataView
    Dim dwPago As DataView
    Dim imp As New Imprimir()


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
        btnModificar.Enabled = False
        If Principal.intPagoAbono = 2 Then
            mnabonos.Visible = False
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
            dsSoltec.Tables(TablaVirtual).Clear()
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
            For Each Pago In dwPago
                Dim memoria As New MemoryStream(CType(Pago("huella"), Byte()))
                template.DeSerialize(memoria.ToArray)
                verificador.Verify(caracteristicas, template, result)
                If (result.Verified) Then
                    strNombreDetectado = "ESTA EN PAGO"
                    intextraer = 1
                    strcedula = Pago("cedula")
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
        Dim valorcaja As Integer = 0
        
        'Captura.StopCapture()
        'Captura.Dispose()
        If Not validarCampos() AndAlso cedulaEnCliente(txtCedula.Text) Then Exit Sub
        Dim fecha As Date = CDate(txtFecha.Text)
        If con.registreDatos("INSERT INTO factura (fac_idcliente,fac_idempleado,fac_tipo)" & vbCrLf &
                                "VALUES ('" & txtCedula.Text & "', '" & Principal.intidusuario & "', 3)") Then
            con.registreDatos("insert into detalle_producto(detpro_idfactura,detpro_idproducto,detpro_cantidad,detpro_precio)values('" & ultimaFactura() & "',1,1,'" & txtValor.Text & "')")
            If booabono Then
                Dim strFactura = "INSERT INTO cuenta_cliente (cuencli_idfactura,cuencli_valorabono,cuencli_fechaabono) values ('" & ultimaFactura() & "','" & intAbono & "',current_date)"
                valorcaja = intAbono
                con.registreDatos(strFactura)

            End If
            registreMovimiento(1, 0, txtValor.Text, Principal.intidusuario, 2)
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
        Dim arlCoincidencias = Gestor1.DatosDeConsulta("SELECT serial,tipo,valor,dias FROM precio where det=2", , Principal.cadenadeconexion)
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
            If con.ExtraerUltimoSpa(txtNombre, imagenHuella, txtFecha, txtCedula.Text, intdiasRestantes, intIdCliente, txttarifa) Then
                txttarifa.Focus()
                txttarifa.Text = "Servicio Spa"
                ''traerTarias()
            ElseIf con.ExtrarCliente(txtNombre, imagenHuella, txtCedula.Text) Then : txttarifa.Focus()
                txttarifa.Focus()
                txttarifa.Text = "Servicio Spa"
                ''traerTarias()
                txtFecha.Text = Now.Date
            Else : MessageBox.Show("Cliente No Registrado", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtCedula.Focus()
            End If
            If con.saberSaldo(txtCedula.Text, 1) Then
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

    Private Sub lstTarifas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lstTarifas.KeyPress

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
                    booSaber = True

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
    Public Sub limipar()
        lbldia.Text = Nothing
        txtCedula.Text = ""
        txtNombre.Text = ""
        txtFecha.Text = ""
        booabono = False
        strValorAbono = "0"
        intAbono = 0
        intSaldo = 0
        txttarifa.Text = ""
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
        If con.registreDatos("UPDATE PAGO SET fecha_corte='" & Format(fecha, "yyyy-MM-dd") & "',fecha_pago=CURDATE()," & vbCrLf &
                        " idprecio='" & lstTarifas.SelectedItems(0).Tag & "' WHERE id='" & intIdCliente & "'") Then
            con.registreDatos("INSERT INTO detalles (cedula,fecha_pago,fecha_fin,tiempo,valor,tarjeta) VALUES " & vbCrLf &
                             "('" & txtCedula.Text & "',current_date,'" & txtFecha.Text & "','" & txttarifa.Text & "','" & txtValor.Text & "','" & intPagoTarjeta & "')")
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

    Private Sub BuscarPorHuellaToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Init()
        iniciarCaptura()


    End Sub

    Private Sub ModificarFechaToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Principal.intValidar = 2
        Dim validar As New VALIDAR()
        validar.ShowDialog()
    End Sub

    Private Sub lstTarifas_MouseClick(sender As Object, e As MouseEventArgs) Handles lstTarifas.MouseClick
        adicionefecha()
    End Sub
    Public Sub adicionefecha()
        Dim fecha As Date
        Dim aux As Integer = 0
        If lstTarifas.SelectedItems.Count = 0 Then Exit Sub
        Dim intIdDeLaPersona = lstTarifas.SelectedItems(0).Tag
        txttarifa.Text = lstTarifas.SelectedItems(0).Text
        txtValor.Text = lstTarifas.SelectedItems(0).SubItems(1).Text
        Dim dias As Integer = lstTarifas.SelectedItems(0).SubItems(2).Text
        aux = dias
        If intdiasRestantes > 0 Then
            dias += intdiasRestantes
        End If
        lbldia.Text = dias
        If dias = 0 Then dias = 1
        Select Case dias
            Case Is < 30
                fecha = DateAdd(DateInterval.Day, dias, Today)
            Case Is < 365
                fecha = DateAdd(DateInterval.Month, dias / 30, Today)
                If Not dias Mod 30 = 0 Then fecha = DateAdd(DateInterval.Day, dias Mod 30, fecha)
            Case Is >= 365
                fecha = DateAdd(DateInterval.Year, 1, Today)
        End Select
        fecha = DateAdd(DateInterval.Day, -1, fecha)

        txtFecha.Text = fecha.Date
        lstTarifas.Visible = False

    End Sub

    Private Sub RegistrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarToolStripMenuItem.Click

        If Me.btnGuardar.Enabled Then
            Me.btnGuardar.PerformClick()
        Else
            Me.btnModificar.PerformClick()
        End If
    End Sub

    Private Sub TarifasEspecialesToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim tespecial As New TarifasEspeciales
        tespecial.ShowDialog()
    End Sub

    Private Sub txtCedula_TextChanged(sender As Object, e As EventArgs) Handles txtCedula.TextChanged

    End Sub

    Private Sub PagarCuotaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles variosAbonos.Click
        Principal.AbrirFormularios(Of SaldoSpa)()

    End Sub

  
End Class