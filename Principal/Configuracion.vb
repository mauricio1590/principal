Public Class Configuracion

    Dim con As conexion = New conexion
  
    Private Sub Configuracion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUnidad.Text = Principal.strunidad
        If Principal.intIngresoClientes = 1 Then chkIngresoClientes.Checked = True
        If Principal.intCongelarCliente = 1 Then
            chkCongelar.Checked = True
            txtdiascongelados.Text = Principal.intNumeroDiasMinimos
        End If
        If Principal.intCongelarpormes = 1 Then
            chkVecesXMes.Checked = True
        End If
        If Principal.intValidarEntradas = 1 Then
            chkbloquearDeuda.Checked = True
            txtEntradas.Text = Principal.intNumeroEntradas
        End If
        If Principal.intIngresoEmpleado = 1 Then chkEmpleados.Checked = True
        If Principal.intPagoAbono = 1 Then chkAbonos.Checked = True
        If Principal.intEnviarEmail = 1 Then chkInforme.Checked = True
        If Principal.intHuella = 1 Then chControlHuella.Checked = True
        If Principal.intVariosAbonos = 1 Then chkVariosAbonos.Checked = True
        txtTipopc.Text = Principal.intTipopc
        txtPuerto.Text = Principal.strPuerto
        txtentradascliente.Text = Principal.intEntradasCliente
        cbcImpresion.SelectedIndex() = Principal.intTipoImpresion
        If Principal.intRestringirDiasCongelado = 1 Then
            ChkCongeladoFuera.Checked = True
            txtCondeladoFuera.Text = Principal.intDiasRestringidos
        End If
        If Principal.intValideLicenciaOnline = 1 Then chkValideConexionOnline.Checked = True
        If Principal.intOcultarDiasAcceso = 1 Then chkOcultarDiasAcceso.Checked = True
        If Principal.intFormatoDias = 2 Then chkFormatoDias.Checked = True
        If Principal.intFormularioClientespa = 1 Then chkFormularioClientespa.Checked = True
        If Principal.intCongelarConClaveAdmin = 1 Then chkCongelarconAdmin.Checked = True


    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim unidad As String = ""
        Dim intEnviarCorreo As Integer = Principal.intEnviarEmail
        Dim intingresoempleado As Integer = Principal.intIngresoEmpleado
        Dim intingresoclientes As Integer = Principal.intIngresoClientes
        Dim intvalidarentradas As Integer = Principal.intValidarEntradas
        Dim intCantidadEntradas As Integer = 0
        Dim intPagoAbonos As Integer = Principal.intPagoAbono
        Dim intVariosAbonos As Integer = Principal.intVariosAbonos
        Dim intCongelar As Integer = Principal.intCongelarCliente
        Dim intMinimoDias As Integer = Principal.intNumeroDiasMinimos
        Dim intCongelarXMes As Integer = Principal.intCongelarpormes
        Dim intmaximoDias As Integer = Principal.intCongelarpormes
        Dim intHuella As Integer = Principal.intHuella
        Dim intTipoImpresion As Integer = Principal.intTipoImpresion
        Dim intEntradaCliente As Integer = Principal.intEntradasCliente
        Dim strPuerto As String = Principal.strPuerto
        Dim intTipopc As Integer = Principal.intTipopc
        Dim intCongeladoFuera As Integer = Principal.intRestringirDiasCongelado
        Dim intDiasRestringidos As Integer = Principal.intDiasRestringidos
        Dim intConexionOnline As Integer = Principal.intValideLicenciaOnline
        Dim intOcultarDiasAcceso As Integer = Principal.intOcultarDiasAcceso
        Dim intFormatoDias As Integer = Principal.intFormatoDias
        Dim intFormularioClienteSpa As Integer = Principal.intFormularioClientespa
        Dim intCongelarAdmin As Integer = Principal.intCongelarConClaveAdmin
        If txtUnidad.Text.Equals("") Then MessageBox.Show("debe escribir la unidad donde se va a almacenar la informacion ", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
        unidad = txtUnidad.Text
        If chkInforme.Checked Then intEnviarCorreo = 1 Else intEnviarCorreo = 2
        If chkEmpleados.Checked Then intingresoempleado = 1 Else intingresoempleado = 2
        If chkIngresoClientes.Checked Then intingresoclientes = 1 Else intingresoclientes = 2
        If chkbloquearDeuda.Checked Then intvalidarentradas = 1 Else intvalidarentradas = 2
        If txtEntradas.Text.Equals("") Then intCantidadEntradas = 5 Else intCantidadEntradas = txtEntradas.Text
        If chkAbonos.Checked Then intPagoAbonos = 1 Else intPagoAbonos = 2
        If chkVariosAbonos.Checked Then intVariosAbonos = 1 Else intVariosAbonos = 2
        If chkCongelar.Checked Then intCongelar = 1 Else intCongelar = 2
        If chkVecesXMes.Checked Then intCongelarXMes = 1 Else intCongelarXMes = 2
        If txtdiascongelados.Text.Equals("") Then intMinimoDias = 8 Else intMinimoDias = txtdiascongelados.Text
        If chControlHuella.Checked Then intHuella = 1 Else intHuella = 2
        If Not intTipoImpresion = cbcImpresion.SelectedIndex() Then intTipoImpresion = cbcImpresion.SelectedIndex
        If Not intEntradaCliente = txtentradascliente.Text Then intEntradaCliente = txtentradascliente.Text
        If Not strPuerto = txtPuerto.Text Then strPuerto = txtPuerto.Text
        If Not intTipopc = txtTipopc.Text Then intTipopc = txtTipopc.Text
        If ChkCongeladoFuera.AutoCheck Then
            intCongeladoFuera = 1
            intDiasRestringidos = txtCondeladoFuera.Text
        End If
        If chkValideConexionOnline.Checked = True Then intConexionOnline = 1 Else intConexionOnline = 2
        If chkOcultarDiasAcceso.Checked = True Then intOcultarDiasAcceso = 1 Else intOcultarDiasAcceso = 2
        If chkFormatoDias.Checked = True Then intFormatoDias = 2 Else intFormatoDias = 1
        If chkFormularioClientespa.Checked = True Then intFormularioClienteSpa = 1 Else intFormularioClienteSpa = 0
        If chkCongelarconAdmin.Checked = True Then intCongelarAdmin = 1 Else intCongelarAdmin = 2
        Dim strCadena = "UPDATE conf SET unidad='" & unidad & "', enco='" & intEnviarCorreo & "',inem='" & intingresoempleado & "',incl='" & intingresoclientes & "'," & vbCrLf &
                                    " vaen='" & intvalidarentradas & "', nuen='" & intCantidadEntradas & "',paab ='" & intPagoAbonos & "',cocl='" & intCongelar & "', " & vbCrLf &
                                    "nuco='" & intMinimoDias & "',numaco='" & intCongelarXMes & "',huella='" & intHuella & "', imp='" & intTipoImpresion & "',nuencl='" & intEntradaCliente & "'," & vbCrLf &
                                    "puerto='" & strPuerto & "',pepaab='" & intVariosAbonos & "', tipopc= '" & intTipopc & "', rescon ='" & intCongeladoFuera & "'," & vbCrLf &
                                    "diasres='" & intDiasRestringidos & "',vacoon='" & intConexionOnline & "',ocdiac='" & intOcultarDiasAcceso & "',fodi='" & intFormatoDias & "',foclsp='" & intFormularioClienteSpa & "'," & vbCrLf &
                                    "cococl='" & intCongelarAdmin & "'"
        If con.registreDatos(strCadena) Then
            Application.Restart()
        Else
            MessageBox.Show("No se puedo cambiar la configuracion ", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub InsertarReporteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InsertarReporteToolStripMenuItem.Click
        Dim strCadena As String = InputBox("Ingrese el Nuevo Reporte", "Mensaje Del Sistema", "Reporte")
        Dim strInsert As String = "INSERT INTO REPORTE (no) VALUES ('" & strCadena & "')"
        con.registreDatos(strInsert)
        MessageBox.Show("Reporte Ingresado Exitosamente ", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    End Sub
End Class