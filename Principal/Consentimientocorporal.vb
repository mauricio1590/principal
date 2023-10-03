Imports MySql.Data.MySqlClient

Public Class Consentimientocorporal
    Dim validaciones As New conexion
    Dim idcorporalModificado As Integer = 0
    Dim intRegistro As Integer = 0
    Public conexion As New MySqlConnection
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        registreCorporal(1)
        limpiar()
        MessageBox.Show("Registro Correcto", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    End Sub

    Sub registreCorporal(tipoRegistro As Integer)
        Dim strCadena As String
        Dim intIdTercero As Integer = validaciones.saberIdTerceroByCedula(txtDocumento.Text)
        Dim intEcardiaca As Integer = 2
        Dim intRenales As Integer = 2
        Dim intCirculatoria As Integer = 2
        Dim intPulmonares As Integer = 2
        Dim intDigestivas As Integer = 2
        Dim intHermatologica As Integer = 2
        Dim intEndocrina As Integer = 2
        Dim intNeurologica As Integer = 2
        Dim intPpresion As Integer = 2
        Dim intAlergias As Integer = 2
        Dim intPpiel As Integer = 2
        Dim intConvulsiones As Integer = 2

        Dim inttabaco As Integer = 2
        Dim intAlcohol As Integer = 2
        Dim intDrogras As Integer = 2
        Dim intMarcapasos As Integer = 2

        Dim cintura As String = txtc1.Text & "-" & txtc2.Text & "-" & txtc3.Text
        Dim Pecho As String = txtp1.Text & "-" & txtp2.Text & "-" & txtp3.Text
        Dim cadera As String = txtca1.Text & "-" & txtca2.Text & "-" & txtca3.Text
        Dim brazoIzq As String = txtbI1.Text & "-" & txtBi2.Text & "-" & txtBi3.Text
        Dim brazoder As String = txtBd1.Text & "-" & txtBd2.Text & "-" & txtBd3.Text
        Dim musloizq As String = txtmi1.Text & "-" & txtMi2.Text & "-" & txtMi3.Text
        Dim musloder As String = txtMd1.Text & "-" & txtMd2.Text & "-" & txtMd3.Text
        Dim abdomenalto As String = txtAba1.Text & "-" & txtAba2.Text & "-" & txtAba3.Text
        Dim abdomenmedio As String = txtAbm1.Text & "-" & txtAbm2.Text & "-" & txtAbm3.Text
        Dim abdomenbajo As String = txtAbb1.Text & "-" & txtAbb2.Text & "-" & txtAbb3.Text

        Dim generales As String = txtObservaciones.Text
        Dim diagnostico As String = txtTratamiento.Text

        If rbCardiacasi.Checked Then intEcardiaca = 1 : Else intEcardiaca = 2
        If rbRenalessi.Checked Then intRenales = 1 : Else intRenales = 2
        If rbCirculatoriassi.Checked Then intCirculatoria = 1 : Else intCirculatoria = 2
        If rbPulmonaressi.Checked Then intPulmonares = 1 : Else intPulmonares = 2
        If rbDigestivassi.Checked Then intDigestivas = 1 : Else intDigestivas = 2
        If rbHermatologicasi.Checked Then intHermatologica = 1 : Else intHermatologica = 2
        If rbEndocrinassi.Checked Then intEndocrina = 1 : Else intEndocrina = 2
        If rbNeurologicasi.Checked Then intNeurologica = 1 : Else intNeurologica = 2
        If rbPresionsi.Checked Then intPpresion = 1 : Else intPpresion = 2
        If rbAlergiassi.Checked Then intAlergias = 1 : Else intAlergias = 2
        If rbPpielsi.Checked Then intPpiel = 1 : Else intPpiel = 2
        If rbConvulsionsi.Checked Then intConvulsiones = 1 : Else intConvulsiones = 2
        If rbTabacosi.Checked Then inttabaco = 1 : Else inttabaco = 2
        If rbAlcoholsi.Checked Then intAlcohol = 1 : Else intAlcohol = 2
        If rbDrogassi.Checked Then intDrogras = 1 : Else intDrogras = 2
        If rbMarcapasossi.Checked Then intMarcapasos = 1 : Else intMarcapasos = 2

        Select Case tipoRegistro
            Case 1

                strCadena = "INSERT INTO corporal (idtercero,ecardiaca,erenal,ecirculatoria,epulmonares,edigestivas,ehermatologicas,eendocrinas,eneurologicas,ppresion,alergias,ppiel,convulsiones,
                             tabaco,alcohol,drogas,marcapasos,edad,peso,estatura,observacionesg,diagnosticos,cintura,pecho,cadera,brazoi,brazod,musloi,muslod,abdomena,abdomenm,abdomenb) values 
                             ('" & intIdTercero & "','" & intEcardiaca & "','" & intRenales & "','" & intCirculatoria & "','" & intPulmonares & "','" & intDigestivas & "','" & intHermatologica & "',
                             '" & intEndocrina & "','" & intNeurologica & "','" & intPpresion & "','" & intAlergias & "','" & intPpiel & "','" & intConvulsiones & "','" & inttabaco & "','" & intAlcohol & "',
                              '" & intDrogras & "','" & intMarcapasos & "','" & txtEdad.Text & "','" & txtPeso.Text & "','" & txtestatura.Text & "','" & generales & "','" & diagnostico & "',
                              '" & cintura & "','" & Pecho & "','" & cadera & "','" & brazoIzq & "','" & brazoder & "','" & musloizq & "','" & musloder & "','" & abdomenalto & "','" & abdomenmedio & "',
                              '" & abdomenbajo & "')"

                If validaciones.registreDatos(strCadena) Then
                    intRegistro = 1
                End If

            Case 2
                strCadena = "UPDATE corporal set idtercero='" & intIdTercero & "',ecardiaca='" & intEcardiaca & "',erenal='" & intRenales & "',ecirculatoria='" & intCirculatoria & "',epulmonares='" & intPulmonares & "',
                            edigestivas='" & intDigestivas & "',ehermatologicas='" & intHermatologica & "',eendocrinas= '" & intEndocrina & "',eneurologicas='" & intNeurologica & "', ppresion='" & intPpresion & "',
                            alergias='" & intAlergias & "',ppiel='" & intPpiel & "',convulsiones='" & intConvulsiones & "', tabaco='" & inttabaco & "',alcohol='" & intAlcohol & "',drogas= '" & intDrogras & "',
                            marcapasos='" & intMarcapasos & "',edad='" & txtEdad.Text & "',peso='" & txtPeso.Text & "',estatura='" & txtestatura.Text & "',observacionesg='" & generales & "',
                            diagnosticos='" & diagnostico & "',cintura='" & cintura & "',pecho='" & Pecho & "',cadera='" & cadera & "',brazoi='" & brazoIzq & "',brazod='" & brazoder & "',musloi='" & musloizq & "',
                            muslod='" & musloder & "',abdomena='" & abdomenalto & "',abdomenm='" & abdomenmedio & "',abdomenb='" & abdomenbajo & "' where id='" & idcorporalModificado & "'"
                If validaciones.registreDatos(strCadena) Then
                    intRegistro = 1
                End If
        End Select






    End Sub
    Sub limpiar()
        txtObservaciones.Text = ""
        txtDocumento.Text = ""
        lblCliente.Text = ""
        txtc1.Text = ""
        txtc2.Text = ""
        txtc3.Text = ""
        txtp1.Text = ""
        txtp2.Text = ""
        txtp3.Text = ""
        txtca1.Text = ""
        txtca2.Text = ""
        txtca3.Text = ""
        txtbI1.Text = ""
        txtBi2.Text = ""
        txtBi3.Text = ""
        txtBd2.Text = ""
        txtBd1.Text = ""
        txtBd3.Text = ""
        txtmi1.Text = ""
        txtMi2.Text = ""
        txtMi3.Text = ""
        txtMd1.Text = ""
        txtMd2.Text = ""
        txtMd3.Text = ""
        txtAba1.Text = ""
        txtAba2.Text = ""
        txtAba3.Text = ""
        txtAbm1.Text = ""
        txtAbm2.Text = ""
        txtAbm3.Text = ""
        txtAbb1.Text = ""
        txtAbb2.Text = ""
        txtAbb3.Text = ""
        txtEdad.Text = ""
        txtestatura.Text = ""
        txtPeso.Text = ""
        idcorporalModificado = 0
        btnGuardar.Enabled = True
        btnModificar.Enabled = False

        If rbCardiacasi.Checked Then rbCardiacasi.Checked = False : Else rbCardiacano.Checked = False
        If rbRenalessi.Checked Then rbRenalessi.Checked = False : Else rbRenalesno.Checked = False
        If rbCirculatoriassi.Checked Then rbCirculatoriassi.Checked = False : Else rbCirculatoriasno.Checked = False
        If rbPulmonaressi.Checked Then rbPulmonaressi.Checked = False : Else rbPulmonaresno.Checked = False
        If rbDigestivassi.Checked Then rbDigestivassi.Checked = False : rbDigestivasno.Checked = False
        If rbHermatologicasi.Checked Then rbHermatologicasi.Checked = False : Else rbHermatologicano.Checked = False
        If rbEndocrinassi.Checked Then rbEndocrinassi.Checked = False : Else rbEndocrinasno.Checked = False
        If rbNeurologicasi.Checked Then rbNeurologicasi.Checked = False : rbNeurologicano.Checked = False
        If rbPresionsi.Checked Then rbPresionsi.Checked = False : rbPresionno.Checked = False
        If rbAlergiassi.Checked Then rbAlergiassi.Checked = False : Else rbAlergiasno.Checked = False
        If rbPpielsi.Checked Then rbPpielsi.Checked = False : Else rbPpielno.Checked = False
        If rbConvulsionsi.Checked Then rbConvulsionsi.Checked = False : Else rbConvulsionno.Checked = False
        If rbTabacosi.Checked Then rbTabacosi.Checked = False : Else rbTabacono.Checked = False
        If rbAlcoholsi.Checked Then rbAlcoholsi.Checked = False : Else rbAlcoholno.Checked = False
        If rbDrogassi.Checked Then rbDrogassi.Checked = False : Else rbDrogasno.Checked = False
        If rbMarcapasossi.Checked Then rbMarcapasossi.Checked = False : Else rbMarcapasosNo.Checked = False
    End Sub
    Private Sub txtDocumento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDocumento.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If validaciones.saberingreso(txtDocumento.Text) Then
                lblCliente.Text = validaciones.saberNombreporCedula(txtDocumento.Text)
            Else
                MessageBox.Show("EL documento ingresado no Existe", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If


        End If
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else : e.Handled = True
        End If
    End Sub

    Private Sub BuscarPorDocumentoToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BuscarPorDocumentoToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles BuscarPorDocumentoToolStripMenuItem.Click
        Dim strCedula = InputBox("Escriba una cedula", "Mensaje del Sistema")
        If Not strCedula.Equals("") Then
            alimentarCorporal(strCedula, 1)
            btnGuardar.Enabled = True
            btnModificar.Enabled = True
        Else
            MessageBox.Show("EL documento ingresado no se encontro en la base de datos", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Public Function alimentarCorporal(cedula As String, tipobusqueda As Integer) As Boolean
        Dim booClienteEncontrado As Boolean = False
        Try
            conexion.ConnectionString = Principal.cadenadeconexion
            conexion.Open()
            Dim cadena As String = ""

            Select Case tipobusqueda
                Case 1
                    cadena = "SELECT  cl.id as idcliente,corporal.id as idcorporal,cl.cedula,concat(cl.nombre,' ',cl.apellido) as cliente,ecardiaca,erenal,ecirculatoria,epulmonares,edigestivas,ehermatologicas,
                             eendocrinas,eneurologicas,ppresion,alergias,ppiel,convulsiones,tabaco,alcohol,drogas,marcapasos,edad,peso,estatura,observacionesg,diagnosticos,cintura,pecho,cadera,brazoi,brazod,
                             musloi,muslod,abdomena,abdomenm,abdomenb,corporal.mo  FROM cliente cl,corporal  WHERE cl.id=corporal.idtercero AND cl.cedula='" & cedula & "'"
                Case 2
                    cadena = "SELECT cl.id as idcliente,sp.id as idspa,cl.cedula,cl.nombre,cl.apellido,ifnull(cl.telefono,'NADA') AS TELEFONO,ifnull(cl.direccion,'') as direccion,ifnull(cl.nacimiento,'2018-01-01') as nacimiento,
                               cl.rh,sp.profesion,sp.signo,sp.estatura,sp.fcancer,sp.fcancert,sp.hijos,sp.hijost,sp.planifica,sp.planificat,sp.farmacos,sp.farmacost,sp.alergias,sp.alergiast,sp.cirugias,sp.cirugiast,sp.tiroides,
                                sp.estreñimiento, sp.diabetes,sp.hipertenso,sp.covid,sp.alcohol,sp.vacunase,sp.vacunaset,sp.otros,sp.motivo
                             FROM cliente cl,clientespa sp WHERE cl.cedula='" & cedula & "' and cl.cedula=sp.cedula"
            End Select

            Dim cmd As New MySqlCommand(cadena, conexion)
            Using leerdato As MySqlDataReader = cmd.ExecuteReader()
                While leerdato.Read()
                    lblCliente.Text = leerdato.GetString("cliente")
                    idcorporalModificado = leerdato.GetString("idcorporal")
                    txtDocumento.Text = leerdato.GetString("cedula")
                    If leerdato.GetInt32("ecardiaca") = 1 Then rbCardiacasi.Checked = True Else rbCardiacano.Checked = True
                    If leerdato.GetInt32("erenal") = 1 Then rbRenalessi.Checked = True Else rbRenalesno.Checked = True
                    If leerdato.GetInt32("ecirculatoria") = 1 Then rbCirculatoriassi.Checked = True Else rbCirculatoriasno.Checked = True
                    If leerdato.GetInt32("epulmonares") = 1 Then rbPulmonaressi.Checked = True Else rbPulmonaresno.Checked = True
                    If leerdato.GetInt32("edigestivas") = 1 Then rbDigestivassi.Checked = True Else rbDigestivasno.Checked = True
                    If leerdato.GetInt32("ehermatologicas") = 1 Then rbHermatologicasi.Checked = True Else rbHermatologicasi.Checked = True
                    If leerdato.GetInt32("eendocrinas") = 1 Then rbEndocrinassi.Checked = True Else rbEndocrinasno.Checked = True
                    If leerdato.GetInt32("eneurologicas") = 1 Then rbNeurologicasi.Checked = True Else rbNeurologicano.Checked = True
                    If leerdato.GetInt32("ppresion") = 1 Then rbPresionsi.Checked = True Else rbPresionno.Checked = True
                    If leerdato.GetInt32("alergias") = 1 Then rbAlergiassi.Checked = True Else rbAlergiasno.Checked = True
                    If leerdato.GetInt32("ppiel") = 1 Then rbPpielsi.Checked = True Else rbPpielno.Checked = True
                    If leerdato.GetInt32("convulsiones") = 1 Then rbConvulsionsi.Checked = True Else rbConvulsionno.Checked = True
                    If leerdato.GetInt32("tabaco") = 1 Then rbTabacosi.Checked = True Else rbTabacono.Checked = True
                    If leerdato.GetInt32("alcohol") = 1 Then rbAlcoholsi.Checked = True Else rbAlcoholno.Checked = True
                    If leerdato.GetInt32("drogas") = 1 Then rbDrogassi.Checked = True Else rbDrogasno.Checked = True
                    If leerdato.GetInt32("marcapasos") = 1 Then rbMarcapasossi.Checked = True Else rbMarcapasosNo.Checked = True
                    txtEdad.Text = leerdato.GetString("edad")
                    txtPeso.Text = leerdato.GetString("peso")
                    txtestatura.Text = leerdato.GetString("estatura")
                    txtObservaciones.Text = leerdato.GetString("observacionesg")
                    txtTratamiento.Text = leerdato.GetString("diagnosticos")
                    Dim cintura As Array = leerdato.GetString("cintura").Split("-")
                    txtc1.Text = cintura(0)
                    txtc2.Text = cintura(1)
                    txtc3.Text = cintura(2)
                    Dim pecho As Array = leerdato.GetString("pecho").Split("-")
                    txtp1.Text = pecho(0)
                    txtp2.Text = pecho(1)
                    txtp3.Text = pecho(2)
                    Dim cadera As Array = leerdato.GetString("cadera").Split("-")
                    txtca1.Text = cadera(0)
                    txtca2.Text = cadera(1)
                    txtca3.Text = cadera(2)
                    Dim brazoi As Array = leerdato.GetString("brazoi").Split("-")
                    txtbI1.Text = brazoi(0)
                    txtBi2.Text = brazoi(1)
                    txtBi3.Text = brazoi(2)
                    Dim brazod As Array = leerdato.GetString("brazod").Split("-")
                    txtBd1.Text = brazod(0)
                    txtBd2.Text = brazod(1)
                    txtBd3.Text = brazod(2)
                    Dim musloi As Array = leerdato.GetString("musloi").Split("-")
                    txtmi1.Text = musloi(0)
                    txtMi2.Text = musloi(1)
                    txtMi3.Text = musloi(2)
                    Dim muslod As Array = leerdato.GetString("muslod").Split("-")
                    txtMd1.Text = muslod(0)
                    txtMd2.Text = muslod(1)
                    txtMd3.Text = muslod(2)
                    Dim abdomena As Array = leerdato.GetString("abdomena").Split("-")
                    txtAba1.Text = abdomena(0)
                    txtAba2.Text = abdomena(1)
                    txtAba3.Text = abdomena(2)
                    Dim abdomenm As Array = leerdato.GetString("abdomenm").Split("-")
                    txtAbm1.Text = abdomenm(0)
                    txtAbm2.Text = abdomenm(1)
                    txtAbm3.Text = abdomenm(2)
                    Dim abdomenb As Array = leerdato.GetString("abdomenb").Split("-")
                    txtAbb1.Text = abdomenb(0)
                    txtAbb2.Text = abdomenb(1)
                    txtAbb3.Text = abdomenb(2)

                End While
            End Using
            conexion.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return booClienteEncontrado
    End Function

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        registreCorporal(2)
        limpiar()
        MessageBox.Show("Registro Actualizado", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    End Sub
End Class