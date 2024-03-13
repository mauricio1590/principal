
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.tool.xml
Imports MySql.Data.MySqlClient


Public Class ClientesSpa
    Dim validaciones As conexion = New conexion()
    Dim intRegistro As Integer = 0
    Dim Gestor1 As New Soltec.Gestor
    Dim paginaHtml_texto As String = ""
    Dim intIdPago = 0
    Public intidmodificado As Integer = 0
    Public intidmodificadospa As Integer = 0
    Dim strCedulaAntigua As String = ""
    Dim tipobusqueda As Integer = 1
    Dim intbusqueda As Integer = 1
    Dim pdfDoc As New Document(iTextSharp.text.PageSize.A4, 15.0F, 15.0F, 30.0F, 30.0F)
    Dim PdfDoc1 As New Document(PageSize.A4, 25, 25, 25, 25)
    Dim pdfWriter As PdfWriter

    Public conexion As New MySqlConnection
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If validaciones.saberingreso(txtcedula.Text) Then MessageBox.Show("EL documento ingresado ya fue registrado", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
        If validarCampossPA() Then
            Dim Builderconex As New MySqlConnectionStringBuilder()
            Builderconex.Server = Principal.servidor
            Builderconex.UserID = Principal.usuario
            Builderconex.Password = Principal.password
            Builderconex.Database = Principal.database
            Dim conexion As New MySqlConnection(Builderconex.ToString())
            conexion.Open()
            Dim cmd As New MySqlCommand()
            cmd = conexion.CreateCommand()
            cmd.CommandText = "INSERT INTO cliente (cedula,nombre,apellido,telefono,direccion,nacimiento,rh,ruta,correo) VALUES (?,?,?,?,?,?,?,?,?)"
            cmd.Parameters.AddWithValue("cedula", txtcedula.Text.ToString())
            cmd.Parameters.AddWithValue("nombre", txtname.Text.ToString().ToUpper)
            cmd.Parameters.AddWithValue("apellido", txtApellido.Text.ToString().ToUpper)
            cmd.Parameters.AddWithValue("telefono", txtTelefono.Text.ToString())
            cmd.Parameters.AddWithValue("direccion", txtdireccion.Text.ToString())
            cmd.Parameters.AddWithValue("nacimiento", Format(dtFecha.Value, "yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("rh", txtrh.Text.ToString())
            cmd.Parameters.AddWithValue("ruta", "")
            cmd.Parameters.AddWithValue("correo", "")

            cmd.ExecuteNonQuery()
            cmd.Dispose()
            conexion.Close()
            conexion.Dispose()

            registreAdicional(1)
            registreMedidas()
            If Not intRegistro = 1 Then
                MessageBox.Show("Error en el Registro", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            reiniciar()
            MessageBox.Show("El registro se hizo correctamente", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Else : MessageBox.Show("Debe Alimentar Los Campos Minimos", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Sub registreMedidas()
        Dim strPeso As String = txtPeso.Text
        Dim strBrazo As String = txtBrazo.Text
        Dim strAbdomena As String = txtAbdomenalto.Text
        Dim strCintura As String = txtCintura.Text
        Dim strCadera As String = txtCadera.Text
        Dim strPierna As String = txtPierna.Text
        Dim strAbdonenb As String = txtAbdomenBajo.Text
        Dim strEspalda As String = txtEspalda.Text

        Dim strcadena As String = "INSERT INTO medidaspa (cedula,peso,brazo,abdomena,cintura,cadera,pierna,abdomenb,espalda) values ('" & txtcedula.Text & "','" & strPeso & "','" & strBrazo & "',
                                    '" & strAbdomena & "','" & strCintura & "','" & strCadera & "','" & strPierna & "','" & strAbdonenb & "','" & strEspalda & "')"

        If validaciones.registreDatos(strcadena) Then
            intRegistro = 1
        End If


    End Sub
    Sub registreAdicional(tiporegistro As Integer)
        Dim strCadena As String
        Dim strCedula As String = txtcedula.Text
        Dim strProfesion As String = txtProfesion.Text
        Dim strSigno As String = txtSigno.Text
        Dim strEstatura As String = txtEstatura.Text
        Dim intFcancer As Integer = 2
        Dim strFcancer As String = txtFcancer.Text
        Dim intHijos As Integer = 2
        Dim strHijos As String = txtHijos.Text
        Dim intPlanifica As Integer = 2
        Dim strPlanificat As String = txtPlanifica.Text
        Dim intFarmacos As Integer = 2
        Dim strFarmacos As String = txtfarmacos.Text
        Dim intAlergias As Integer = 2
        Dim strAlergias As String = txtalergias.Text
        Dim intCirugias As Integer = 1
        Dim strCirugias As String = txtcirugias.Text
        Dim intTiroides As Integer = 2
        Dim intEstreñimiento As Integer = 2
        Dim intDiabetes As Integer = 2
        Dim intHiper As Integer = 2
        Dim intCovid As Integer = 2
        Dim intAlcohol As Integer = 2
        Dim intsecundario As Integer = 2
        Dim strSecundario As String = txtEfectos.Text
        Dim strOtros As String = txtotros.Text
        Dim strMotivo As String = txtmotivo.Text

        If rbcancersi.Checked Then intFcancer = 1 : Else intFcancer = 2
        If rbplanificasi.Checked Then intPlanifica = 1 : Else intPlanifica = 2
        If rbfarmacossi.Checked Then intFarmacos = 1 : Else intFarmacos = 2
        If rbalergiassi.Checked Then intAlergias = 1 : Else intAlergias = 2
        If rbcirugiassi.Checked Then intCirugias = 1 : Else intCirugias = 2
        If rbtiroidessi.Checked Then intTiroides = 1 : Else intTiroides = 2
        If rbestreñimientosi.Checked Then intEstreñimiento = 1 : Else intEstreñimiento = 2
        If rbdiabetessi.Checked Then intDiabetes = 1 : Else intDiabetes = 2
        If rbhipersi.Checked Then intHiper = 1 : Else intHiper = 2
        If rbcovidsi.Checked Then intCovid = 1 : Else intCovid = 2
        If rbalcoholsi.Checked Then intAlcohol = 1 : Else intAlcohol = 2
        If rbsecundariosi.Checked Then intsecundario = 1 : Else intsecundario = 2

        Select Case tiporegistro
            Case 1
                strCadena = "INSERT INTO clientespa (cedula,profesion,signo,estatura,fcancer,fcancert,hijos,hijost,planifica,planificat,farmacos,farmacost,alergias,alergiast,cirugias,cirugiast,tiroides,estreñimiento,
                                   diabetes,hipertenso,covid,alcohol,vacunase,vacunaset,otros,motivo) values ('" & strCedula & "','" & strProfesion & "','" & strSigno & "','" & strEstatura & "' , '" & intFcancer & "', '" & strFcancer & "',
                                    '" & intHijos & "', '" & strHijos & "', '" & intPlanifica & "','" & strPlanificat & "', '" & intFarmacos & "','" & strFarmacos & "','" & intAlergias & "' , '" & strAlergias & "',
                                    '" & intCirugias & "','" & strCirugias & "','" & intTiroides & "','" & intEstreñimiento & "','" & intDiabetes & "','" & intHiper & "','" & intCovid & "','" & intAlcohol & "',
                                    '" & intsecundario & "','" & strSecundario & "','" & strOtros & "','" & strMotivo & "')"

                If validaciones.registreDatos(strCadena) Then
                    intRegistro = 1
                End If
            Case 2
                strCadena = "update clientespa set cedula = '" & strCedula & "',profesion ='" & strProfesion & "',signo='" & strSigno & "',estatura='" & strEstatura & "',fcancer='" & intFcancer & "',fcancert='" & strFcancer & "',hijos='" & intHijos & "',
                             hijost='" & strHijos & "',planifica='" & intPlanifica & "',planificat='" & strPlanificat & "',farmacos='" & intFarmacos & "',farmacost ='" & strFarmacos & "',alergias='" & intAlergias & "',
                             alergiast='" & strAlergias & "',cirugias='" & intCirugias & "',cirugiast='" & strCirugias & "',tiroides='" & intTiroides & "',estreñimiento='" & intEstreñimiento & "',
                             diabetes='" & intDiabetes & "',hipertenso='" & intHiper & "',covid='" & intCovid & "',alcohol='" & intAlcohol & "',vacunase='" & intsecundario & "',vacunaset='" & strSecundario & "',
                             otros='" & strOtros & "',motivo='" & strMotivo & "' where id='" & intidmodificadospa & "' "
                If validaciones.registreDatos(strCadena) Then
                    registreMedidas()
                    intRegistro = 1
                End If

        End Select






    End Sub

    Function validarCampossPA() As Boolean

        If Not txtcedula.Text.ToString.Equals("") Then
            If Not txtname.Text.ToString.Equals("") Then
                If Not txtApellido.Text.ToString.Equals("") Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If
        Else : Return False
        End If
    End Function
    Private Sub reiniciar()

        intRegistro = 0
        txtcedula.Text = ""
        txtname.Text = ""
        txtApellido.Text = ""
        txtTelefono.Text = ""
        txtdireccion.Text = ""
        lblEdad.Text = "Edad:"
        txtrh.Text = ""
        dtFecha.Format = DateTimePickerFormat.Custom
        dtFecha.Text = "01/01/2000"
        txtProfesion.Text = ""
        txtSigno.Text = ""
        If rbcancerno.Checked Then rbcancerno.Checked = False : Else rbcancersi.Checked = False
        txtFcancer.Text = ""
        txtEstatura.Text = ""
        txtHijos.Text = ""
        If rbplanificano.Checked Then rbplanificano.Checked = False : Else rbplanificasi.Checked = False
        txtPlanifica.Text = ""
        If rbfarmacosno.Checked Then rbfarmacosno.Checked = False : Else rbfarmacossi.Checked = False
        txtfarmacos.Text = ""
        If rbalergiasno.Checked Then rbalergiasno.Checked = False : Else rbalergiassi.Checked = False
        txtalergias.Text = ""
        If rbcirugiasno.Checked Then rbcirugiasno.Checked = False : Else rbcirugiassi.Checked = False
        txtcirugias.Text = ""
        If rbtiroidesno.Checked Then rbtiroidesno.Checked = False : Else rbtiroidessi.Checked = False
        If rbestreñimientono.Checked Then rbestreñimientono.Checked = False : Else rbestreñimientosi.Checked = False
        If rbdiabetesno.Checked Then rbdiabetesno.Checked = False : Else rbdiabetessi.Checked = False
        If rbhiperno.Checked Then rbhiperno.Checked = False : Else rbhipersi.Checked = False
        If rbhiperno.Checked Then rbhiperno.Checked = False : Else rbhipersi.Checked = False
        If rbcovidno.Checked Then rbcovidno.Checked = False : Else rbcovidsi.Checked = False
        If rbalcoholno.Checked Then rbalcoholno.Checked = False : Else rbalcoholsi.Checked = False
        If rbsecundariono.Checked Then rbsecundariono.Checked = False : Else rbsecundariosi.Checked = False
        txtotros.Text = ""
        intbusqueda = 1
        intidmodificado = 0
        intidmodificadospa = 0
        txtPeso.Text = ""
        txtBrazo.Text = ""
        txtAbdomenalto.Text = ""
        txtCintura.Text = ""
        txtCadera.Text = ""
        txtPierna.Text = ""
        txtAbdomenBajo.Text = ""
        txtEspalda.Text = ""
        txtEfectos.Text = ""
        txtmotivo.Text = ""





        'btnModificar.Enabled = False
        btnGuardar.Enabled = True
        'pararCaptura()
        ' intbusqueda = 1



    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim strCedula As String = Nothing
        tipobusqueda = 2
        strCedula = InputBox("Escriba una cedula", "Mensaje del Sistema")
        If Not strCedula.Equals("") Then

            If Alimentarspa(strCedula) Then
                AlimentarMedida(strCedula)
                pongaEdad()
                btnModificar.Enabled = True
                btnGuardar.Enabled = False
                strCedulaAntigua = txtcedula.Text

            Else
                MessageBox.Show("EL documento ingresado no se encontro en la base de datos", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Public Function AlimentarMedida(cedula As String) As Boolean
        Dim booClienteEncontrado As Boolean = False
        Try
            conexion.ConnectionString = Principal.cadenadeconexion
            conexion.Open()
            Dim cadena As String = ""

            cadena = "SELECT * FROM medidaspa WHERE cedula='" & cedula & "' order by id desc limit 1"

            Dim cmd As New MySqlCommand(cadena, conexion)
            Using leerdato As MySqlDataReader = cmd.ExecuteReader()
                While leerdato.Read()
                    txtcedula.Text = leerdato.GetString("cedula")
                    txtPeso.Text = leerdato.GetString("peso")
                    txtBrazo.Text = leerdato.GetString("brazo")
                    txtAbdomenalto.Text = leerdato.GetString("abdomena")
                    txtCintura.Text = leerdato.GetString("cintura")
                    txtCadera.Text = leerdato.GetString("cadera")
                    txtPierna.Text = leerdato.GetString("pierna")
                    txtAbdomenBajo.Text = leerdato.GetString("abdomenb")
                    txtEspalda.Text = leerdato.GetString("espalda")

                End While
            End Using
            conexion.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return booClienteEncontrado
    End Function
    Public Function Alimentarspa(cedula As String) As Boolean
        Dim booClienteEncontrado As Boolean = False
        Try
            conexion.ConnectionString = Principal.cadenadeconexion
            conexion.Open()
            Dim cadena As String = ""

            Select Case tipobusqueda
                Case 1
                    cadena = "SELECT cl.id as idcliente,sp.id as idspa,cl.cedula,cl.nombre,cl.apellido,ifnull(cl.telefono,'NADA') AS TELEFONO,ifnull(cl.direccion,'') as direccion,ifnull(cl.nacimiento,'2018-01-01') as nacimiento,
                               cl.rh,sp.profesion,sp.signo,sp.estatura,sp.fcancer,sp.fcancert,sp.hijos,sp.hijost,sp.planifica,sp.planificat,sp.farmacos,sp.farmacost,sp.alergias,sp.alergiast,sp.cirugias,sp.cirugiast,sp.tiroides,
                                sp.estreñimiento, sp.diabetes,sp.hipertenso,sp.covid,sp.alcohol,sp.vacunase,sp.vacunaset,sp.otros,sp.motivo
                             FROM cliente cl,clientespa sp WHERE cl.cedula=sp.cedula AND cl.id='" & cedula & "'"
                Case 2
                    cadena = "SELECT cl.id as idcliente,sp.id as idspa,cl.cedula,cl.nombre,cl.apellido,ifnull(cl.telefono,'NADA') AS TELEFONO,ifnull(cl.direccion,'') as direccion,ifnull(cl.nacimiento,'2018-01-01') as nacimiento,
                               cl.rh,sp.profesion,sp.signo,sp.estatura,sp.fcancer,sp.fcancert,sp.hijos,sp.hijost,sp.planifica,sp.planificat,sp.farmacos,sp.farmacost,sp.alergias,sp.alergiast,sp.cirugias,sp.cirugiast,sp.tiroides,
                                sp.estreñimiento, sp.diabetes,sp.hipertenso,sp.covid,sp.alcohol,sp.vacunase,sp.vacunaset,sp.otros,sp.motivo
                             FROM cliente cl,clientespa sp WHERE cl.cedula='" & cedula & "' and cl.cedula=sp.cedula"
            End Select

            Dim cmd As New MySqlCommand(cadena, conexion)
            Using leerdato As MySqlDataReader = cmd.ExecuteReader()
                While leerdato.Read()
                    txtcedula.Text = leerdato.GetString("cedula")
                    intIdPago = validaciones.saberIdPago(leerdato.GetString("cedula"))
                    txtname.Text = leerdato.GetString("nombre")
                    txtApellido.Text = leerdato.GetString("apellido")
                    txtTelefono.Text = leerdato.GetString("telefono")
                    txtdireccion.Text = leerdato.GetString("direccion")
                    intidmodificado = leerdato.GetInt32("idcliente")
                    intidmodificadospa = leerdato.GetInt32("idspa")
                    booClienteEncontrado = True
                    Dim fe As Date = leerdato.Item("nacimiento")
                    dtFecha.Text = Format(fe, "dd-MM-yyyy")
                    txtrh.Text = leerdato.GetString("rh")
                    txtProfesion.Text = leerdato.GetString("profesion")
                    txtSigno.Text = leerdato.GetString("signo")
                    txtEstatura.Text = leerdato.GetString("estatura")
                    If leerdato.GetInt32("fcancer") = 1 Then rbcancersi.Checked = True Else rbcancerno.Checked = True
                    txtFcancer.Text = leerdato.GetString("fcancert")
                    txtHijos.Text = leerdato.GetString("hijost")
                    If leerdato.GetInt32("planifica") = 1 Then rbplanificasi.Checked = True Else rbplanificano.Checked = True
                    txtPlanifica.Text = leerdato.GetString("planificat")
                    If leerdato.GetInt32("farmacos") = 1 Then rbfarmacossi.Checked = True Else rbfarmacosno.Checked = True
                    txtfarmacos.Text = leerdato.GetString("farmacost")
                    If leerdato.GetInt32("alergias") = 1 Then rbalergiassi.Checked = True Else rbalergiasno.Checked = True
                    txtalergias.Text = leerdato.GetString("alergiast")
                    If leerdato.GetInt32("cirugias") = 1 Then rbcirugiassi.Checked = True Else rbcirugiasno.Checked = True
                    txtcirugias.Text = leerdato.GetString("cirugiast")
                    If leerdato.GetInt32("tiroides") = 1 Then rbtiroidessi.Checked = True Else rbtiroidesno.Checked = True
                    If leerdato.GetInt32("estreñimiento") = 1 Then rbestreñimientosi.Checked = True Else rbestreñimientono.Checked = True
                    If leerdato.GetInt32("diabetes") = 1 Then rbdiabetessi.Checked = True Else rbdiabetesno.Checked = True
                    If leerdato.GetInt32("hipertenso") = 1 Then rbhipersi.Checked = True Else rbhiperno.Checked = True
                    If leerdato.GetInt32("covid") = 1 Then rbcovidsi.Checked = True Else rbcovidno.Checked = True
                    If leerdato.GetInt32("alcohol") = 1 Then rbalcoholsi.Checked = True Else rbalcoholno.Checked = True
                    If leerdato.GetInt32("vacunase") = 1 Then rbsecundariosi.Checked = True Else rbsecundariono.Checked = True
                    txtEfectos.Text = leerdato.GetString("vacunaset")
                    txtotros.Text = leerdato.GetString("otros")
                    txtmotivo.Text = leerdato.GetString("motivo")


                End While
            End Using
            conexion.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return booClienteEncontrado
    End Function

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click

        If validarCampossPA() Then
            conexion.Open()
            Dim cmd As New MySqlCommand()
            cmd = conexion.CreateCommand()
            cmd.CommandText = "UPDATE CLIENTE set cedula=?,nombre=?,apellido=?,telefono=?,direccion=?,nacimiento=?,rh=? WHERE id=" & intidmodificado
            cmd.Parameters.AddWithValue("cedula", txtcedula.Text.ToString())
            cmd.Parameters.AddWithValue("nombre", txtname.Text.ToString().ToUpper)
            cmd.Parameters.AddWithValue("apellido", txtApellido.Text.ToString().ToUpper)
            cmd.Parameters.AddWithValue("telefono", txtTelefono.Text.ToString())
            cmd.Parameters.AddWithValue("direccion", txtdireccion.Text.ToString())
            Dim fechan As Date
            fechan = dtFecha.Value.Date
            cmd.Parameters.AddWithValue("nacimiento", fechan)
            cmd.Parameters.AddWithValue("rh", txtrh.Text)

            validaciones.registreDatos("UPDATE pago SET cedula='" & txtcedula.Text & "' WHERE id='" & intIdPago & "'")
            If Not txtcedula.Equals(txtcedula.Text) Then
                validaciones.registreDatos("UPDATE abonos set cedula='" & txtcedula.Text & "' where cedula='" & strCedulaAntigua & "'")
                validaciones.registreDatos("UPDATE detalles set cedula='" & txtcedula.Text & "' where cedula='" & strCedulaAntigua & "'")
            End If
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            conexion.Close()
            conexion.Dispose()
            registreAdicional(2)
            reiniciar()
            MessageBox.Show("El registro se actualizo correctamente", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Else : MessageBox.Show("Debe Alimentar Los Campos Minimos", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub



    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Me.Close()
    End Sub

    Private Sub btLimpiar_Click(sender As Object, e As EventArgs) Handles btLimpiar.Click
        reiniciar()
    End Sub

    Private Sub BuscarClientesToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ConsentimientoToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub EliminarToolStripMenuItem_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub BuscarPorNombreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarPorNombreToolStripMenuItem.Click
        Me.txtname.Focus()
        intbusqueda = 2
        Me.btnModificar.Enabled = True
        Me.btnGuardar.Enabled = False
    End Sub

    Private Sub txtname_TextChanged(sender As Object, e As EventArgs) Handles txtname.TextChanged, txtcedula.TabIndexChanged
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
                    txtApellido.Focus()
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
                    tipobusqueda = 1

                    If Alimentarspa(intIdDeLaPersona) Then
                        AlimentarMedida(txtcedula.Text)
                        pongaEdad()
                        btnGuardar.Enabled = False
                        btnModificar.Enabled = True
                    Else
                        MessageBox.Show("EL documento ingresado no se encontro en la base de datos", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                    lstNombres.Visible = False

                End If
        End Select
    End Sub

    Private Sub lstNombres_MouseClick(sender As Object, e As MouseEventArgs) Handles lstNombres.MouseClick
        If lstNombres.SelectedItems.Count = 0 Then Exit Sub
        Dim intIdDeLaPersona = lstNombres.SelectedItems(0).Tag
        intbusqueda = 1
        tipobusqueda = 1
        If Alimentarspa(intIdDeLaPersona) Then

            btnGuardar.Enabled = False
            btnModificar.Enabled = True
            strCedulaAntigua = txtcedula.Text
            AlimentarMedida(strCedulaAntigua)
            pongaEdad()
        Else
            MessageBox.Show("EL documento ingresado no se encontro en la base de datos", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        lstNombres.Visible = False
    End Sub

    Private Sub ClientesSpa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtcedula.Focus()
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

    Private Sub GenerarHistoriaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerarHistoriaToolStripMenuItem.Click
        '        Dim direccion As String = Principal.strunidad & ":\SISTEMGYM_DATOS\historias\"
        '        If Not My.Computer.FileSystem.DirectoryExists(direccion) Then My.Computer.FileSystem.CreateDirectory(direccion)
        '        Dim nameFile As String = txtname.Text & " " & txtApellido.Text & " " & txtcedula.Text & ".pdf"
        '        Dim ruta As String = direccion & "\" & nameFile
        '        pdfWriter = pdfWriter.GetInstance(pdfDoc, New FileStream(ruta, FileMode.Create))
        '        Dim font8 As New Font(FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.NORMAL))
        '        Dim fontB8 As New Font(FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.BOLD))
        '        Dim font12 As New Font(FontFactory.GetFont(FontFactory.HELVETICA, 10, iTextSharp.text.Font.ITALIC))
        '        Dim font12neg As New Font(FontFactory.GetFont(FontFactory.HELVETICA, 10, iTextSharp.text.Font.BOLD))
        '        Dim Cvacio As PdfPCell = New PdfPCell(New Phrase(""))
        '        Cvacio.Border = 0

        '        pdfDoc.Open()
        '        Dim table1 As PdfPTable = New PdfPTable(4)
        '        Dim col1 As PdfPCell
        '        Dim col2 As PdfPCell
        '        Dim col3 As PdfPCell
        '        Dim col4 As PdfPCell
        '        '


        '        table1.WidthPercentage = 95

        '        Dim widthS As Single() = New Single() {6.0F, 4.0F, 1.0F, 3.0F}
        '        table1.SetWidths(widthS)

        '#Region "tabla1-Encabezado"

        '        Dim imagenURL As String = Principal.strunidad & ":\SISTEMGYM_DATOS\Imagenes\logo.jpg"
        '        Dim imagenBPM As iTextSharp.text.Image
        '        imagenBPM = iTextSharp.text.Image.GetInstance(imagenURL)
        '        imagenBPM.ScaleToFit(150.0F, 200.0F)
        '        imagenBPM.SpacingBefore = 20.0F
        '        imagenBPM.SpacingAfter = 10.0F
        '        imagenBPM.SetAbsolutePosition(40, 760)
        '        pdfDoc.Add(imagenBPM)

        '        table1.AddCell(Cvacio)
        '        col3 = New PdfPCell(New Phrase("LA VID SPA", fontB8))
        '        'table1.WidthPercentage = 40
        '        col3.Border = 0
        '        table1.AddCell(col3)
        '        table1.AddCell(Cvacio)
        '        col3 = New PdfPCell(New Phrase("HISTORIA", fontB8))
        '        'table1.WidthPercentage = 30
        '        col3.Border = 0
        '        table1.AddCell(col3)

        '        table1.AddCell(Cvacio)
        '        col2 = New PdfPCell(New Phrase("av gauimaral", fontB8))
        '        col2.Border = 0
        '        table1.AddCell(col2)
        '        table1.AddCell(Cvacio)
        '        col3 = New PdfPCell(New Phrase("DEL PACIENTE", fontB8))
        '        col3.Border = 0
        '        table1.AddCell(col3)

        '        table1.AddCell(Cvacio)
        '        col2 = New PdfPCell(New Phrase("CUCUTA - COLOMBIA", fontB8))
        '        col2.Border = 0
        '        table1.AddCell(col2)
        '        table1.AddCell(Cvacio)
        '        col3 = New PdfPCell(New Phrase("", fontB8))
        '        col3.Border = 0
        '        table1.AddCell(col3)

        '        table1.AddCell(Cvacio)
        '        col2 = New PdfPCell(New Phrase("REDES:  @LAVIDSPA", fontB8))
        '        col2.Border = 0
        '        table1.AddCell(col2)
        '        table1.AddCell(Cvacio)
        '        col3 = New PdfPCell(New Phrase("FORMATO", fontB8))
        '        col3.Border = 0
        '        table1.AddCell(col3)


        '        table1.AddCell(Cvacio)
        '        col2 = New PdfPCell(New Phrase("", fontB8))
        '        col2.Border = 0
        '        table1.AddCell(col2)
        '        table1.AddCell(Cvacio)
        '        col3 = New PdfPCell(New Phrase("F1-0001 ", fontB8))
        '        col3.Border = 0
        '        table1.AddCell(col3)

        '        pdfDoc.Add(table1)

        '#End Region
        '        pintarCuadrado(0.7, 410, 740, 530, 820)
        '        pintarLinea(0.5, 30, 733, 530, 733)
        '        pdfDoc.Add(New Paragraph("."))
        '#Region "Tabla2-cliente"
        '        Dim table2 As PdfPTable = New PdfPTable(4)
        '        Dim widths2 As Single() = New Single() {2.0F, 8.0F, 3.0F, 2.0F}
        '        table2.WidthPercentage = 95
        '        table2.SetWidths(widths2)
        '        table2.AddCell(Cvacio)
        '        table2.AddCell(Cvacio)
        '        table2.AddCell(Cvacio)
        '        table2.AddCell(Cvacio)
        '        col1 = New PdfPCell(New Phrase("CLIENTE", font12neg))
        '        col1.Border = 0
        '        table2.AddCell(col1)
        '        col2 = New PdfPCell(New Phrase(txtname.Text & " " & txtApellido.Text, font12neg))
        '        col2.Border = 0
        '        table2.AddCell(col2)
        '        col3 = New PdfPCell(New Phrase("FECHA", font12neg))
        '        col3.Border = 0
        '        table2.AddCell(col3)
        '        col4 = New PdfPCell(New Phrase(Now.Date, font12neg))
        '        col4.Border = 0
        '        table2.AddCell(col4)



        '        col1 = New PdfPCell(New Phrase("DOCUMENTO", font12neg))
        '        col1.Border = 0
        '        table2.AddCell(col1)
        '        col2 = New PdfPCell(New Phrase(txtcedula.Text, font12neg))
        '        col2.Border = 0
        '        table2.AddCell(col2)

        '        col3 = New PdfPCell(New Phrase("TELEFONO:", font12neg))
        '        col3.Border = 0
        '        table2.AddCell(col3)
        '        col4 = New PdfPCell(New Phrase(txtTelefono.Text, font12neg))
        '        col4.Border = 0
        '        table2.AddCell(col4)
        '        col3 = New PdfPCell(New Phrase("DIRECCION", font12neg))
        '        col3.Border = 0
        '        table2.AddCell(col3)
        '        col4 = New PdfPCell(New Phrase(txtdireccion.Text, font12neg))
        '        col4.Border = 0
        '        table2.AddCell(col4)

        '        col1 = New PdfPCell(New Phrase("", font12neg))
        '        col1.Border = 0
        '        table2.AddCell(col1)
        '        col2 = New PdfPCell(New Phrase("USUARIO SISTEMA", font12neg))
        '        table2.AddCell(Cvacio)
        '        table2.AddCell(Cvacio)

        '        pdfDoc.Add(table2)
        '#End Region
        '        pintarLinea(0.5, 30, 681, 530, 681)

        '#Region "Tabla3-Cabecera"
        '        Dim table3 As PdfPTable = New PdfPTable(4)
        '        Dim widths3 As Single() = New Single() {5.0F, 5.0F, 5.0F, 5.0F}
        '        table3.WidthPercentage = 95
        '        table3.SetWidths(widths3)
        '        col1 = New PdfPCell(New Phrase("COLUMNA 1", fontB8))
        '        col1.Border = 0
        '        table3.AddCell(col1)

        '        col2 = New PdfPCell(New Phrase("COLUMNA 2", fontB8))
        '        col2.Border = 0
        '        table3.AddCell(col2)
        '        pdfDoc.Add(table3)

        '        pdfDoc.Add(table3)


        '#End Region
        '        'pintarLinea(0.5, 30, 662, 530, 662)

        '#Region "tabla4-detalle"
        '        Dim table4 As PdfPTable = New PdfPTable(4)
        '        Dim widths4 As Single() = New Single() {1.0F, 8.0F, 1.0F, 1.0F}
        '        table4.WidthPercentage = 95
        '        table4.SetWidths(widths4)
        '        col1 = New PdfPCell(New Phrase("01", fontB8))
        '        col1.Border = 0
        '        table4.AddCell(col1)
        '        col2 = New PdfPCell(New Phrase("COLUMNA1", fontB8))
        '        col2.Border = 0
        '        table4.AddCell(col2)
        '        col3 = New PdfPCell(New Phrase("COLUMNA2", fontB8))
        '        col3.Border = 0
        '        table4.AddCell(col3)

        '        pdfDoc.Add(table4)

        '#End Region
        '        'pintarLinea(0.5, 30, 200, 530, 200)
        '#Region "cuerpo"

        '        Dim tabledet As PdfPTable = New PdfPTable(3)
        '        Dim widthdet As Single() = New Single() {3.0F, 0.5F, 3.0F}
        '        tabledet.WidthPercentage = 95
        '        tabledet.SetWidths(widthdet)
        '        tabledet.AddCell(Cvacio)
        '        tabledet.AddCell(Cvacio)
        '        tabledet.AddCell(Cvacio)
        '        tabledet.AddCell(Cvacio)
        '        tabledet.AddCell(Cvacio)
        '        tabledet.AddCell(Cvacio)
        '        tabledet.AddCell(Cvacio)
        '        tabledet.AddCell(Cvacio)
        '        tabledet.AddCell(Cvacio)
        '        Dim años As Integer = DateDiff(DateInterval.Year, dtFecha.Value, Now.Date)
        '        col2 = New PdfPCell(New Phrase("FECHA DE NACIMIENTO:  " & dtFecha.Value, font12))
        '        col2.Border = 0
        '        tabledet.AddCell(col2)
        '        tabledet.AddCell(Cvacio)
        '        col3 = New PdfPCell(New Phrase("ESTATURA: " & txtEstatura.Text & "     EDAD: " & años, font12))
        '        col3.Border = 0
        '        tabledet.AddCell(col3)

        '        col2 = New PdfPCell(New Phrase("TIPO DE SANGRE: " & txtrh.Text & "", font12))
        '        col2.Border = 0
        '        tabledet.AddCell(col2)
        '        tabledet.AddCell(Cvacio)
        '        col3 = New PdfPCell(New Phrase("SIGNO: " & txtSigno.Text & "", font12))
        '        col3.Border = 0
        '        tabledet.AddCell(col3)

        '        col2 = New PdfPCell(New Phrase("PROFESION: " & txtProfesion.Text & "", font12))
        '        col2.Border = 0
        '        tabledet.AddCell(col2)
        '        tabledet.AddCell(Cvacio)
        '        col3 = New PdfPCell(New Phrase("", font12))
        '        col3.Border = 0
        '        tabledet.AddCell(col3)

        '        'FAMILIAR CON CANCER
        '        Dim fcancer As String = "NO"

        '        If rbcancersi.Checked Then fcancer = "SI"

        '        col2 = New PdfPCell(New Phrase("FAMILIAR CON CANCER: " & fcancer & "", font12))
        '        col2.Border = 0
        '        tabledet.AddCell(col2)
        '        tabledet.AddCell(Cvacio)
        '        col3 = New PdfPCell(New Phrase("CUAL: " & txtFcancer.Text, font12))
        '        col3.Border = 0
        '        tabledet.AddCell(col3)


        '        'TIENE HIJOS
        '        Dim hijos As String = "NO"

        '        col2 = New PdfPCell(New Phrase("HIJOS:", font12))
        '        col2.Border = 0
        '        tabledet.AddCell(col2)
        '        tabledet.AddCell(Cvacio)
        '        col3 = New PdfPCell(New Phrase("" & txtHijos.Text, font12))
        '        col3.Border = 0
        '        tabledet.AddCell(col3)

        '        'PLANIFICA
        '        Dim planifica As String = "NO"
        '        If rbplanificasi.Checked Then planifica = "SI"
        '        col2 = New PdfPCell(New Phrase("PLANIFICA: " & planifica & "", font12))
        '        col2.Border = 0
        '        tabledet.AddCell(col2)
        '        tabledet.AddCell(Cvacio)
        '        col3 = New PdfPCell(New Phrase("CUAL: " & txtPlanifica.Text & "", font12))
        '        col3.Border = 0
        '        tabledet.AddCell(col3)

        '        'FARMACOS
        '        Dim farmacos As String = "NO"
        '        If rbplanificasi.Checked Then farmacos = "SI"
        '        col2 = New PdfPCell(New Phrase("FARMACOS: " & farmacos & "", font12))
        '        col2.Border = 0
        '        tabledet.AddCell(col2)
        '        tabledet.AddCell(Cvacio)
        '        col3 = New PdfPCell(New Phrase("CUAL: " & txtfarmacos.Text & "", font12))
        '        col3.Border = 0
        '        tabledet.AddCell(col3)

        '        'ALERGIAS
        '        Dim alergias As String = "NO"
        '        If rbalergiassi.Checked Then alergias = "SI"
        '        col2 = New PdfPCell(New Phrase("ALERGIAS: " & alergias & "", font12))
        '        col2.Border = 0
        '        tabledet.AddCell(col2)
        '        tabledet.AddCell(Cvacio)
        '        col3 = New PdfPCell(New Phrase("CUAL: " & txtalergias.Text & "", font12))
        '        col3.Border = 0
        '        tabledet.AddCell(col3)

        '        'CIRUGIAS
        '        Dim cirugias As String = "NO"
        '        If rbcirugiassi.Checked Then cirugias = "SI"
        '        col2 = New PdfPCell(New Phrase("CIRUGIAS: " & cirugias & "", font12))
        '        col2.Border = 0
        '        tabledet.AddCell(col2)
        '        tabledet.AddCell(Cvacio)
        '        col3 = New PdfPCell(New Phrase("CUAL: " & txtcirugias.Text & "", font12))
        '        col3.Border = 0
        '        tabledet.AddCell(col3)

        '        'TIROIDES
        '        Dim tiroides As String = "NO"
        '        Dim estreñimiento As String = "NO"
        '        If rbtiroidessi.Checked Then cirugias = "SI"
        '        If rbestreñimientosi.Checked Then cirugias = "SI"
        '        col2 = New PdfPCell(New Phrase("TIROIDES: " & cirugias & "", font12))
        '        col2.Border = 0
        '        tabledet.AddCell(col2)
        '        tabledet.AddCell(Cvacio)
        '        col3 = New PdfPCell(New Phrase("ESTREÑIMIENTO: " & estreñimiento, font12))
        '        col3.Border = 0
        '        tabledet.AddCell(col3)

        '        'diabetes
        '        Dim diabetes As String = "NO"
        '        Dim hiper As String = "NO"
        '        If rbdiabetessi.Checked Then diabetes = "SI"
        '        If rbhipersi.Checked Then hiper = "SI"
        '        col2 = New PdfPCell(New Phrase("DIABETES: " & diabetes & "", font12))
        '        col2.Border = 0
        '        tabledet.AddCell(col2)
        '        tabledet.AddCell(Cvacio)
        '        col3 = New PdfPCell(New Phrase("HIPERENCIÓN: " & hiper, font12))
        '        col3.Border = 0
        '        tabledet.AddCell(col3)


        '        'COVID
        '        Dim covid As String = "NO"
        '        Dim alcohol As String = "NO"
        '        If rbcovidsi.Checked Then covid = "SI"
        '        If rbalcoholsi.Checked Then alcohol = "SI"
        '        col2 = New PdfPCell(New Phrase("COVID: " & covid & "", font12))
        '        col2.Border = 0
        '        tabledet.AddCell(col2)
        '        tabledet.AddCell(Cvacio)
        '        col3 = New PdfPCell(New Phrase("ALCOHOL: " & alcohol, font12))
        '        col3.Border = 0
        '        tabledet.AddCell(col3)

        '        'EFECTOS SECUNDARIOS
        '        Dim efectos As String = "NO"
        '        If rbsecundariosi.Checked Then covid = "SI"
        '        col2 = New PdfPCell(New Phrase("EFECTOS SECUNDARIOS A VACUNAS EXPERIMENTALES: " & efectos & "", font12))
        '        col2.Border = 0
        '        tabledet.AddCell(col2)
        '        tabledet.AddCell(Cvacio)
        '        col3 = New PdfPCell(New Phrase("", font12))
        '        col3.Border = 0
        '        tabledet.AddCell(col3)

        '        'OTROS
        '        col2 = New PdfPCell(New Phrase("OTROS: " & txtotros.Text & "", font12))
        '        col2.Border = 0
        '        tabledet.AddCell(col2)
        '        tabledet.AddCell(Cvacio)
        '        col3 = New PdfPCell(New Phrase("", font12))
        '        col3.Border = 0
        '        tabledet.AddCell(col3)

        '        'OTROS
        '        col2 = New PdfPCell(New Phrase("MOTIVO DE CONSULTA: " & txtmotivo.Text & "", font12))
        '        col2.Border = 0
        '        tabledet.AddCell(col2)
        '        tabledet.AddCell(Cvacio)
        '        col3 = New PdfPCell(New Phrase("", font12))
        '        col3.Border = 0
        '        tabledet.AddCell(col3)






        '        'MEDIDAS
        '        col2 = New PdfPCell(New Phrase("PESO: " & txtPeso.Text & "", font12))
        '        col2.Border = 0
        '        tabledet.AddCell(col2)
        '        tabledet.AddCell(Cvacio)
        '        col3 = New PdfPCell(New Phrase("BRAZO: " & txtBrazo.Text, font12))
        '        col3.Border = 0
        '        tabledet.AddCell(col3)



        '        'MEDIDAS
        '        col2 = New PdfPCell(New Phrase("ABDOMEN ALTO: " & txtAbdomenalto.Text & "", font12))
        '        col2.Border = 0
        '        tabledet.AddCell(col2)
        '        tabledet.AddCell(Cvacio)
        '        col3 = New PdfPCell(New Phrase("CINTURA: " & txtCintura.Text, font12))
        '        col3.Border = 0
        '        tabledet.AddCell(col3)


        '        'MEDIDAS
        '        col2 = New PdfPCell(New Phrase("CADERA: " & txtCadera.Text & "", font12))
        '        col2.Border = 0
        '        tabledet.AddCell(col2)
        '        tabledet.AddCell(Cvacio)
        '        col3 = New PdfPCell(New Phrase("PIERNAS: " & txtPierna.Text, font12))
        '        col3.Border = 0
        '        tabledet.AddCell(col3)


        '        'MEDIDAS
        '        col2 = New PdfPCell(New Phrase("ABDOMEN BAJO: " & txtAbdomenBajo.Text & "", font12))
        '        col2.Border = 0
        '        tabledet.AddCell(col2)
        '        tabledet.AddCell(Cvacio)
        '        col3 = New PdfPCell(New Phrase("ESPALDAS: " & txtEspalda.Text, font12))
        '        col3.Border = 0
        '        tabledet.AddCell(col3)
        '        pdfDoc.Add(tabledet)



        '#End Region

        '        pintarLinea(0.5, 30, 300, 530, 300)

        '#Region "tala5-final"
        '        Dim table5 As PdfPTable = New PdfPTable(5)
        '        Dim widths5 As Single() = New Single() {8.0F, 1.0F, 2.0F, 2.0F, 1.0F}
        '        table5.WidthPercentage = 95
        '        table5.SetWidths(widths5)
        '        table5.AddCell(Cvacio)
        '        table5.AddCell(Cvacio)
        '        table5.AddCell(Cvacio)
        '        table5.AddCell(Cvacio)
        '        table5.AddCell(Cvacio)
        '        table5.AddCell(Cvacio)
        '        table5.AddCell(Cvacio)
        '        table5.AddCell(Cvacio)
        '        table5.AddCell(Cvacio)
        '        table5.AddCell(Cvacio)
        '        col1 = New PdfPCell(New Phrase("OBSERVACIONES", fontB8))
        '        col1.Border = 0
        '        table5.AddCell(col1)
        '        table5.AddCell(Cvacio)
        '        'col3 = New PdfPCell(New Phrase("SUB TOTAL", fontB8))
        '        'col3.Border = 0
        '        table5.AddCell(Cvacio)
        '        col4 = New PdfPCell(New Phrase("", fontB8))
        '        col4.Border = 0
        '        col4.HorizontalAlignment = 2
        '        table5.AddCell(col4)
        '        table5.AddCell(Cvacio)

        '        col1 = New PdfPCell(New Phrase("___________________________________", fontB8))
        '        col1.Border = 0
        '        table5.AddCell(col1)
        '        table5.AddCell(Cvacio)
        '        'col3 = New PdfPCell(New Phrase("IVG", fontB8))
        '        'col3.Border = 0
        '        table5.AddCell(Cvacio)
        '        'col4 = New PdfPCell(New Phrase("10000", fontB8))
        '        'col4.Border = 0
        '        col4.HorizontalAlignment = 2
        '        table5.AddCell(Cvacio)
        '        table5.AddCell(Cvacio)

        '        col1 = New PdfPCell(New Phrase("", fontB8))
        '        col1.Border = 0
        '        table5.AddCell(col1)
        '        table5.AddCell(Cvacio)
        '        'col3 = New PdfPCell(New Phrase("TOTAL S/", fontB8))
        '        'col3.Border = 0
        '        table5.AddCell(Cvacio)
        '        'col4 = New PdfPCell(New Phrase("232000", fontB8))
        '        'col4.Border = 0
        '        col4.HorizontalAlignment = 2
        '        table5.AddCell(Cvacio)


        '        col1 = New PdfPCell(New Phrase("", fontB8))
        '        col1.Border = 0
        '        col1.Colspan = 2
        '        table5.AddCell(col1)
        '        table5.AddCell(Cvacio)
        '        table5.AddCell(Cvacio)
        '        table5.AddCell(Cvacio)
        '        col1 = New PdfPCell(New Phrase("", fontB8))
        '        col1.Border = 0
        '        col1.Colspan = 2
        '        table5.AddCell(col1)


        '        pdfDoc.Add(table5)


        '#End Region

        '        'Dim imagenURL2 As String = "D:\SISTEMGYM_DATOS\Imagenes\logo.jpg"
        '        'Dim imagenBPM2 As iTextSharp.text.Image
        '        'imagenBPM2 = iTextSharp.text.Image.GetInstance(imagenURL2)
        '        'imagenBPM2.ScaleToFit(110.0F, 140.0F)
        '        'imagenBPM2.SpacingBefore = 20.0F
        '        'imagenBPM2.SpacingAfter = 10.0F
        '        'imagenBPM2.SetAbsolutePosition(270, 270)
        '        'pdfDoc.Add(imagenBPM2)

        '        pdfDoc.Close()

        '        Process.Start(ruta)
        '    End Sub

        '    Private Sub pintarLinea(ByVal numGrosor As Double,
        '                           ByVal X1 As Integer, ByVal Y1 As Integer,
        '                           ByVal X2 As Integer, ByVal Y2 As Integer)

        '        Dim linea As PdfContentByte
        '        linea = pdfWriter.DirectContent
        '        linea.SetLineWidth(numGrosor)
        '        linea.MoveTo(X1, Y1)
        '        linea.LineTo(X2, Y2)
        '        linea.Stroke()

    End Sub

    Private Sub pintarCuadrado(ByVal numGrosor As Double, ByVal X1 As Integer, ByVal Y1 As Integer, ByVal X2 As Integer, ByVal Y2 As Integer)
        Dim linea As PdfContentByte
        linea = pdfWriter.DirectContent
        linea.SetLineWidth(numGrosor)
        linea.MoveTo(X1, Y1)
        linea.LineTo(X2, Y1)
        linea.Stroke()
        linea.MoveTo(X2, Y1)
        linea.LineTo(X2, Y2)
        linea.Stroke()
        linea.MoveTo(X2, Y2)
        linea.LineTo(X1, Y2)
        linea.Stroke()
        linea.MoveTo(X1, Y2)
        linea.LineTo(X1, Y1)
        linea.Stroke()
        pdfDoc.Add(Chunk.NEWLINE)
    End Sub

    Private Sub dtFecha_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtFecha.KeyPress
        If Asc(e.KeyChar) = 13 Then
            pongaEdad()
            txtSigno.Text = saberSigno(DateAndTime.Month(dtFecha.Value), dtFecha.Value.Day)
        End If
    End Sub

    Sub pongaEdad()
        Dim edad As Integer = DateDiff(DateInterval.Year, dtFecha.Value, Now.Date)
        lblEdad.Text = "Edad: " & edad & " Años"
    End Sub

    Private Sub HISTORIAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HISTORIAToolStripMenuItem.Click
        If txtcedula.Text = "" Then Exit Sub
        Dim direccion As String = Principal.strunidad & ":\SISTEMGYM_DATOS\historias"
        If Not My.Computer.FileSystem.DirectoryExists(direccion) Then My.Computer.FileSystem.CreateDirectory(direccion)
        Dim nameFile As String = txtname.Text & " " & txtApellido.Text & " " & txtcedula.Text & ".pdf"
        Dim ruta As String = direccion & "\" & nameFile
        Dim guardar As SaveFileDialog = New SaveFileDialog()
        guardar.FileName = ruta
        'If File.Exists(ruta) Then
        '    Process.Start(ruta)
        'Else
        '    pdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(ruta, FileMode.Create))
        '    pdfWriter.Close()
        'End If



        paginaHtml_texto = genereHtml()

        reemplazarTexto("@cliente", txtname.Text & " " & txtApellido.Text)
        reemplazarTexto("@factual", Now.Date)
        reemplazarTexto("@documento", txtcedula.Text)
        reemplazarTexto("@edad", DateDiff(DateInterval.Year, dtFecha.Value, Now.Date))
        reemplazarTexto("@telefono", txtTelefono.Text)
        reemplazarTexto("@direccion", txtdireccion.Text)
        reemplazarTexto("@nacimiento", dtFecha.Value)
        reemplazarTexto("@estatura", txtEstatura.Text)
        reemplazarTexto("@rh", txtrh.Text)
        reemplazarTexto("@signo", txtSigno.Text)
        reemplazarTexto("@profesion", txtProfesion.Text)
        reemplazarTexto("@fhijos", txtHijos.Text)
        Dim fcancer As String = "NO"
        If rbcancersi.Checked Then fcancer = "SI"
        reemplazarTexto("@fcancert", txtFcancer.Text)
        reemplazarTexto("@fcancer", fcancer)
        Dim planifica As String = "NO"
        If rbplanificasi.Checked Then planifica = "SI"
        reemplazarTexto("@planificat", txtPlanifica.Text)
        reemplazarTexto("@planifica", planifica)
        Dim farmacos As String = "NO"
        If rbplanificasi.Checked Then farmacos = "SI"
        reemplazarTexto("@farmacost", txtfarmacos.Text)
        reemplazarTexto("@farmacos", farmacos)
        Dim alergias As String = "NO"
        If rbalergiassi.Checked Then alergias = "SI"
        reemplazarTexto("@alergiast", txtalergias.Text)
        reemplazarTexto("@alergias", alergias)
        Dim cirugias As String = "NO"
        If rbcirugiassi.Checked Then cirugias = "SI"
        reemplazarTexto("@cirugiast", txtcirugias.Text)
        reemplazarTexto("@cirugias", cirugias)
        Dim tiroides As String = "NO"
        Dim estreñimiento As String = "NO"
        If rbtiroidessi.Checked Then tiroides = "SI"
        If rbestreñimientosi.Checked Then estreñimiento = "SI"
        reemplazarTexto("@tiroides", tiroides)
        reemplazarTexto("@estreñimiento", estreñimiento)
        Dim diabetes As String = "NO"
        Dim hiper As String = "NO"
        If rbdiabetessi.Checked Then diabetes = "SI"
        If rbhipersi.Checked Then hiper = "SI"
        reemplazarTexto("@diabetes", diabetes)
        reemplazarTexto("@hipertencion", hiper)
        Dim covid As String = "NO"
        Dim alcohol As String = "NO"
        If rbcovidsi.Checked Then covid = "SI"
        If rbalcoholsi.Checked Then alcohol = "SI"
        reemplazarTexto("@covid", covid)
        reemplazarTexto("@alcohol", alcohol)
        Dim efectos As String = "NO"
        If rbsecundariosi.Checked Then covid = "SI"
        reemplazarTexto("@secundariost", txtEfectos.Text)
        reemplazarTexto("@secundarios", efectos)
        reemplazarTexto("@otros", txtotros.Text)
        reemplazarTexto("@motivo", txtmotivo.Text)

        reemplazarTexto("@medida", construirMedida(txtcedula.Text))

        Dim ruta2 = ruta
        Dim stream As FileStream = New FileStream(ruta2, FileMode.Create)
        Dim pdfstream As Document = New Document(PageSize.A4, 25, 25, 25, 25)
        Dim writer As PdfWriter = PdfWriter.GetInstance(pdfstream, stream)
        pdfstream.Open()
        pdfstream.Add(New Phrase(""))
        Dim sr As StringReader = New StringReader(paginaHtml_texto)

        'poner la imagen 
        Dim imagenURL As String = Principal.strunidad & ":\SISTEMGYM_DATOS\Imagenes\logo.jpg"
        Dim imagenBPM As iTextSharp.text.Image
        imagenBPM = iTextSharp.text.Image.GetInstance(imagenURL)
        imagenBPM.ScaleToFit(150.0F, 200.0F)
        imagenBPM.SpacingBefore = 20.0F
        imagenBPM.SpacingAfter = 10.0F
        imagenBPM.SetAbsolutePosition(35, 750)
        pdfstream.Add(imagenBPM)

        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfstream, sr)
        pdfstream.Close()
        stream.Close()

        Process.Start(ruta)

    End Sub
    Sub reemplazarTexto(variable As String, dato As String)
        paginaHtml_texto = paginaHtml_texto.Replace(variable, dato)

    End Sub

    Function construirMedida(strcedula As String) As String
        Dim cadena As String = String.Empty

        Dim boosaber As Boolean = False
        Dim arlCoincidencias = Gestor1.DatosDeConsulta("SELECT left(mo,10),peso,abdomena,abdomenb,brazo,cintura,cadera,pierna,espalda FROM medidaspa WHERE cedula ='" & strcedula & "'", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then
            For Each registro As ArrayList In arlCoincidencias
                cadena += "<tr>"
                cadena += "<td> " & registro(0) & " </td>"
                cadena += "<td> " & registro(1) & " </td>"
                cadena += "<td> " & registro(2) & " </td>"
                cadena += "<td> " & registro(3) & " </td>"
                cadena += "<td> " & registro(4) & " </td>"
                cadena += "<td> " & registro(5) & " </td>"
                cadena += "<td> " & registro(6) & " </td>"
                cadena += "<td> " & registro(7) & " </td>"
                cadena += "<td> " & registro(8) & " </td>"
                cadena += "</tr>"
            Next
        End If

        Return cadena
    End Function

    Function genereHtml() As String
        Dim cadena As String = ""

        cadena = "<!DOCTYPE html>
                <html lang='en'>
                <head>
                    <meta charset='UTF-8'></meta>
                    <meta http-equiv='X-UA-Compatible' content='IE=edge'></meta>
                    <meta name='viewport' content='width=device-width, initial-scale=1.0'></meta>
                       <style>

        table.border {
            border-collapse: collapse;
        }
        table.border th{
            padding: 5px;
            border: 1px solid black;
        }
        table.border td{
            padding: 5px;
            border: 1px solid black;
        }
        .centro{
            text-align: center;
            font-size: 13px;
        }.titulo{
            text-align: center;
            font-size: 12px;
        }
    </style>
                </head>
                <body>
                   <table class='titulo' border='0' style='width: 100%' >
                        <tr>
                            <td  style='width: 30%'></td>
                            <td style='width: 60%'>
                                <table align='center' class='centro'>
                                    <tr><td align='center'> LA VID SPA</td></tr>
                                    <tr><td align='center'> DIRECCION: CLL 13N #11AE-123 GUAIMARAL</td></tr>
                                    <tr><td align='center'> REDES: @LAVIDSPA</td></tr>

                                </table>
                            </td>
                            <td style='width: 20%'>
                                <table  style='width:100% ;' align='center' class='border centro' >
                                    <tr><td align='center'> HISTORIA DEL PACIENTE</td></tr>
                                    <tr><td align='center'> FORMATO 001</td></tr>
                                    <tr><td align='center'> @factual</td></tr>

                                </table>
                            </td>  
                        </tr>

                    <tr><td colspan='4' height='20'></td></tr>
        <tr>    
           <td colspan='4'>
            <table style='width: 100%'>
                <tr>
                <td colspan='1' style='width: 20%;'> Cliente:</td>
                <td colspan='3' style='width: 60%; border-bottom: 1px solid black;'> @cliente</td>
                <td colspan='1' style='width: 20%;'> Documento:</td>
                <td colspan='1' style='width: 30%; border-bottom: 1px solid black;'> @documento</td>
                </tr>
                <tr>
                    <td colspan='1' style='width: 20%;'> Edad:</td>
                    <td colspan='1' style='width: 30%; border-bottom: 1px solid black;'> @edad</td>
                    <td colspan='1' style='width: 10%;'> Telefono:</td>
                    <td colspan='1' style='width: 40%; border-bottom: 1px solid black;'> @telefono</td>
                    <td colspan='1' style='width: 200%;'> Direccion:</td>
                     <td colspan='1' style='width: 30%; border-bottom: 1px solid black;'> @direccion</td>
                </tr>
            </table>
            </td>
        </tr>
        <tr><td colspan='4' height='20'></td></tr>
         <tr>
            <td colspan='4'>
                 <table style='width: 100%' border='1' align='center' class='border' >
                      <tr class='centro'>
                             <td colspan='1' style='width: 20%;'> F. DE NACIMIENTO:</td>
                             <td colspan='1' style='width: 20%; border-bottom: 1px solid black;'> @nacimiento</td>
                             <td colspan='1' style='width: 20%;'> ESTATURA:</td>
                             <td colspan='1' style='width: 20%; border-bottom: 1px solid black;'> @estatura</td>
                      </tr>
                      <tr class='centro'>
                            <td colspan='1' style='width: 20%;'> TIPO DE SANGRE:</td>
                            <td colspan='1' style='width: 20%; border-bottom: 1px solid black;'> @rh</td>
                            <td colspan='1' style='width: 20%;'> SIGNO:</td>
                            <td colspan='1' style='width: 20%; border-bottom: 1px solid black;'> @signo</td>
                      </tr>
                      <tr class='centro'>
                             <td colspan='1' style='width: 20%;'> PROFESION:</td>
                             <td colspan='1' style='width: 20%; border-bottom: 1px solid black;'> @profesion</td>
                             <td colspan='1' style='width: 20%;'> EMBARAZOS:</td>
                             <td colspan='1' style='width: 20%; border-bottom: 1px solid black;'> @fhijos</td>
                     </tr>
                    <tr class='centro'>
                            <td colspan='1' style='width: 20%;'> FAMILIAR CON CANCER:</td>
                            <td colspan='1' style='width: 20%; border-bottom: 1px solid black;'> @fcancer</td>
                            <td colspan='1' style='width: 20%;'> QUIEN:</td>
                            <td colspan='1' style='width: 20%; border-bottom: 1px solid black;'> @fcancert</td>
                    </tr>
                    <tr class='centro'>
                            <td colspan='1' style='width: 20%;'> PLANIFICA:</td>
                            <td colspan='1' style='width: 20%; border-bottom: 1px solid black;'> @planifica</td>
                            <td colspan='1' style='width: 20%;'> CUAL:</td>
                            <td colspan='1' style='width: 20%; border-bottom: 1px solid black;'> @planificat</td>
                    </tr>
                    <tr class='centro'>
                            <td colspan='1' style='width: 20%;'> FARMACOS:</td>
                            <td colspan='1' style='width: 20%; border-bottom: 1px solid black;'> @farmacos</td>
                            <td colspan='1' style='width: 20%;'> CUAL:</td>
                            <td colspan='1' style='width: 20%; border-bottom: 1px solid black;'> @farmacost</td>
                    </tr>
                   <tr class='centro'>
                            <td colspan='1' style='width: 20%;'> ALERGIAS:</td>
                            <td colspan='1' style='width: 20%; border-bottom: 1px solid black;'> @alergias</td>
                            <td colspan='1' style='width: 20%;'> CUAL:</td>
                            <td colspan='1' style='width: 20%; border-bottom: 1px solid black;'> @alergiast </td>
                   </tr>
                  <tr class='centro'>
                            <td colspan='1' style='width: 20%;'> CIRUGIAS:</td>
                            <td colspan='1' style='width: 20%; border-bottom: 1px solid black;'> @cirugias</td>
                            <td colspan='0' style='width: 20%;'> CUAL:</td>
                            <td colspan='1' style='width: 20px; border-bottom: 1px solid black;'> @cirugiast</td>
                  </tr>
                  <tr class='centro'>
                            <td colspan='1' style='width: 20%;'> TIROIDES:</td>
                            <td colspan='1' style='width: 20%; border-bottom: 1px solid black;'> @tiroides</td>
                            <td colspan='0' style='width: 20%;'> ESTREÑIMIENTO:</td>
                            <td colspan='1' style='width: 20px; border-bottom: 1px solid black;'> @estreñimiento</td>
                   </tr>
                <tr class='centro'>
                            <td colspan='1' style='width: 20%;'> DIABETES:</td>
                            <td colspan='1' style='width: 20%; border-bottom: 1px solid black;'> @diabetes</td>
                            <td colspan='0' style='width: 20%;'> HIPERTENCION:</td>
                            <td colspan='1' style='width: 20%; border-bottom: 1px solid black;'> @hipertencion</td>
                </tr>
                <tr class='centro'>
                            <td colspan='1' style='width: 20%;'> COVID:</td>
                            <td colspan='1' style='width: 20%; border-bottom: 1px solid black;'> @covid</td>
                            <td colspan='0' style='width: 20%;'> ALCOHOL:</td>
                            <td colspan='1' style='width: 20px; border-bottom: 1px solid black;'> @alcohol</td>
                </tr>
                <tr class='centro'>
                    <td colspan='1' style='width: 20%;'> EFECTOS SECUNDARIOS A VACUNAS EXPERIMENTALES:</td>
                    <td colspan='1' style='width: 20%; border-bottom: 1px solid black;'> @secundarios</td>
                    <td colspan='0' style='width: 20%;'> CUALES:</td>
                    <td colspan='1' style='width: 20px; border-bottom: 1px solid black;'> @secundariost</td>
                </tr>
                <tr class='centro'>
                    <td colspan='1' style='width: 20%;'> OTROS:</td>
                    <td colspan='1' style='width: 20%; border-bottom: 1px solid black;'> @otros</td>
                    <td colspan='0' style='width: 20%;'> MOTIVO DE COSULTA:</td>
                    <td colspan='1' style='width: 20px; border-bottom: 1px solid black;'> @motivo</td>
                </tr>
               </table>

            
            </td> 
        </tr>
            <tr><td colspan='3' height='20'></td></tr>
        <tr>
            <td colspan='4'>
                <table class='border centro' style='width: 100%;'>
                    <thead style='background-color: #92ec9a;'>
                        <tr>
                            <th>Fecha</th>
                        <th>Peso</th>
                        <th>Abdomen Alto</th>
                        <th>Abdomen Bajo</th>
                        <th>Brazo</th>
                        <th>Cintura</th>
                        <th>Cadera</th>
                        <th>Piernas</th>
                        <th>Espalda</th>
                        </tr>
                    </thead>
                    <tbody>
                        @medidas
                    </tbody>
                </table>
            </td>
        </tr>

         <tr><td colspan='3' height='20'></td></tr>
        <tr>    
           <td colspan='3'>
            <table style='width: 100%'>
                <tr>
                <td colspan='1' style='width: 30%;'> OBSERVACIONES:</td>
                <td colspan='3' style='width: 70%; border-bottom: 1px solid black;'></td>
                </tr>
            </table>
            </td>
        </tr>
      
 </table>
                </body>
                </html>"

        Return cadena
    End Function


End Class