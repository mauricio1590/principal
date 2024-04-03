Imports MySql.Data.MySqlClient

Public Class consentimientofacial
    Dim validaciones As New conexion
    Public conexion As New MySqlConnection
    Dim intRegistro As Integer = 0
    Dim idFacialModificado As Integer = 0
    Dim PDF As New Report
    Dim Logo As String = Principal.strunidad + ":\sistemgym_datos\imagenes\Logo.png"
    Dim Titulo As String = Principal.strunidad + ":\sistemgym_datos\imagenes\Titulo.png"
    Dim si_no As String = Principal.strunidad + ":\sistemgym_datos\imagenes\SI_NO-3.png"
    Dim Anatomia As String = Principal.strunidad + ":\sistemgym_datos\imagenes\Anatomia.png"
    Dim idTerceroModificado As Integer = 0
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

    Private Sub panelContenedor_Paint(sender As Object, e As PaintEventArgs) Handles panelContenedor.Paint

    End Sub

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        registreFacial(1)

        reiniciar()
        MessageBox.Show("Registro Correcto", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    End Sub


    Public Sub registreFacial(tipoRegistro As Integer)
        Dim strCadena As String
        Dim intIdTercero As Integer = validaciones.saberIdTerceroByCedula(txtDocumento.Text)
        Dim intEcardiaca As Integer = 2
        Dim strCardiaca As String = txtcardiacas.Text
        Dim intRenal As Integer = 2
        Dim strRenal As String = txtRenales.Text
        Dim intDigestivo As Integer = 2
        Dim strDigestivo As String = txtDigestivas.Text
        Dim intLcontacto As Integer = 2
        Dim strLcontacto As String = txtLcontacto.Text
        Dim intImpDental As Integer = 2
        Dim strImpDental As String = txtDentales.Text
        Dim intEcirculatoria As Integer = 2
        Dim strEcirculatoria As String = txtCirculatorias.Text
        Dim intPazucar As Integer = 2
        Dim strPazucar As String = txtAzucar.Text
        Dim intPpresion As Integer = 2
        Dim strPpresion As String = txtPresion.Text
        Dim intPpiel As Integer = 2
        Dim strPpiel As String = txtProblemaspiel.Text
        Dim intFfacial As Integer = 2
        Dim strFfacial As String = txtFracturafacial.Text
        Dim intAlergias As Integer = 2
        Dim strAlergias As String = txtAlergias.Text
        Dim intConvulsiones As Integer = 2
        Dim strConvulsiones As String = txtConvulsiones.Text
        Dim intCremas As Integer = 2
        Dim strcremas As String = txtCremas.Text
        Dim intCirugias As Integer = 2
        Dim strCirugias As String = txtCirugias.Text
        Dim intMedicamento As Integer = 2
        Dim strMedicamento As String = txtMedicamento.Text
        Dim strObservaciones As String = txtObservaciones1.Text
        Dim intPielSeca As Integer = 2
        Dim intPielLevementeSeca As Integer = 2
        Dim intPielMedianamenteSeca As Integer = 2
        Dim intPielMuySeca As Integer = 2
        Dim intPielgrasa As Integer = 2
        Dim intPielLevementegrasa As Integer = 2
        Dim intPielMedianamenteGrasa As Integer = 2
        Dim intPielMuyGrasa As Integer = 2
        Dim strObservacionesPiel As String = txtObservaciones1.Text
        Dim intDesvitalizada As Integer = 2
        Dim intAsfictica As Integer = 2
        Dim intHidratada As Integer = 2
        Dim intStandar As Integer = 2

        If rbCardiacasi.Checked Then intEcardiaca = 1 : Else intEcardiaca = 2
        If rbRenalessi.Checked Then intRenal = 1 : Else intRenal = 2
        If rbDigestivassi.Checked Then intDigestivo = 1 : Else intDigestivo = 2
        If rbLcontactosi.Checked Then intLcontacto = 1 : Else intLcontacto = 2
        If rbDentalessi.Checked Then intImpDental = 1 : Else intImpDental = 2
        If rbCirculatoriassi.Checked Then intEcirculatoria = 1 : Else intEcirculatoria = 2
        If rbAzucarsi.Checked Then intPazucar = 1 : Else intPazucar = 2
        If rbPresionsi.Checked Then intPpresion = 1 : Else intPpresion = 2
        If rbPpielsi.Checked Then intPpiel = 1 : Else intPpiel = 2
        If rbFfacialsi.Checked Then intFfacial = 1 : Else intFfacial = 2
        If rbAlergiassi.Checked Then intAlergias = 1 : Else intAlergias = 2
        If rbConvulsionsi.Checked Then intConvulsiones = 1 : Else intConvulsiones = 2
        If rbCremassi.Checked Then intCremas = 1 : Else intCremas = 2
        If rbCirugiassi.Checked Then intCirugias = 1 : Else intCirugias = 2
        If rbMedicamentossi.Checked Then intMedicamento = 1 : Else intMedicamento = 2
        If rbPielsecasi.Checked Then intPielSeca = 1 : Else intPielSeca = 2
        If rbPielLevesecasi.Checked Then intPielLevementeSeca = 1 : Else intPielLevementeSeca = 2
        If rbPielMediasecasi.Checked Then intPielMedianamenteSeca = 1 : Else intPielMedianamenteSeca = 2
        If rbPielmuySecasi.Checked Then intPielMuySeca = 1 : Else intPielMuySeca = 2
        If rbPielgrasasi.Checked Then intPielgrasa = 1 : Else intPielgrasa = 2
        If rbPielLeveGrasasi.Checked Then intPielLevementegrasa = 1 : Else intPielLevementegrasa = 2
        If rbPielMediaGrasasi.Checked Then intPielMedianamenteGrasa = 1 : Else intPielMedianamenteGrasa = 2
        If rbPielMuyGrasasi.Checked Then intPielMuyGrasa = 1 : Else intPielMuyGrasa = 2
        If rbDesvitalizadasi.Checked Then intDesvitalizada = 1 : Else intDesvitalizada = 2
        If rbAsficticasi.Checked Then intAsfictica = 1 : Else intAsfictica = 2
        If rbHidratadasi.Checked Then intHidratada = 1 : Else intHidratada = 2
        If rbStandarsi.Checked Then intStandar = 1 : Else intStandar = 2


        Select Case tipoRegistro
            Case 1
                strCadena = "INSERT INTO facial (idtercero,ecardiaca,ecardiacat,erenal,erenalt,edigestiva,edigestivat,lcontacto,lcontactot,impdental,impdentalt,ecirculatoria,ecirculatoriat,pazucar,pazucart,ppresion,ppresiont,
                             ppiel,ppielt,ffacial,ffacialt,alergias,alergiast,convulsiones,convulsionest,cremas,cremast,cirugias,cirugiast,medicamento,medicamentot,observaciones,pielseca,piellevementeseca,pielmedianamenteseca,
                             pielmuyseca,pielgrasa,piellevementegrasa,pielmedianamentegrasa,pielmuygrasa,obspiel,desvitalizada,asfictica,hidratada,standar) VALUES
                             ('" & intIdTercero & "','" & intEcardiaca & "','" & strCardiaca & "','" & intRenal & "','" & strRenal & "','" & intDigestivo & "','" & strDigestivo & "','" & intLcontacto & "',
                              '" & strLcontacto & "','" & intImpDental & "','" & strImpDental & "','" & intEcirculatoria & "','" & strEcirculatoria & "','" & intPazucar & "','" & strPazucar & "','" & intPpresion & "',
                             '" & strPpresion & "','" & intPpiel & "','" & strPpiel & "','" & intFfacial & "','" & strFfacial & "','" & intAlergias & "','" & strAlergias & "','" & intConvulsiones & "',
                             '" & strConvulsiones & "','" & intCremas & "','" & strcremas & "','" & intCirugias & "','" & strCirugias & "','" & intMedicamento & "','" & strMedicamento & "','" & strObservaciones & "',
                             '" & intPielSeca & "','" & intPielLevementeSeca & "','" & intPielMedianamenteSeca & "','" & intPielMuySeca & "','" & intPielgrasa & "','" & intPielLevementeSeca & "',
                              '" & intPielMedianamenteGrasa & "','" & intPielMuyGrasa & "','" & strObservacionesPiel & "','" & intDesvitalizada & "','" & intAsfictica & "','" & intHidratada & "','" & intStandar & "')"
                If validaciones.registreDatos(strCadena) Then
                    intRegistro = 1
                End If
            Case 2

                strCadena = "UPDATE facial set idtercero='" & intIdTercero & "',ecardiaca='" & intEcardiaca & "' ,ecardiacat ='" & strCardiaca & "',erenal='" & intRenal & "',erenalt='" & strRenal & "',edigestiva='" & intDigestivo & "',
                                     edigestivat='" & strDigestivo & "',lcontacto='" & intLcontacto & "',lcontactot= '" & strLcontacto & "',impdental='" & intImpDental & "',impdentalt='" & strImpDental & "',
                                     ecirculatoria='" & intEcirculatoria & "',ecirculatoriat='" & strEcirculatoria & "',pazucar='" & intPazucar & "', pazucart='" & strPazucar & "',ppresion='" & intPpresion & "',
                                     ppresiont='" & strPpresion & "', ppiel='" & intPpiel & "',ppielt='" & strPpiel & "',ffacial='" & intFfacial & "',ffacialt='" & strFfacial & "',alergias='" & intAlergias & "',
                                     alergiast='" & strAlergias & "',convulsiones='" & intConvulsiones & "',convulsionest= '" & strConvulsiones & "',cremas='" & intCremas & "',cremast='" & strcremas & "',
                                     cirugias='" & intCirugias & "',cirugiast='" & strCirugias & "',medicamento='" & intMedicamento & "',medicamentot='" & strMedicamento & "', observaciones='" & strObservaciones & "',
                                     pielseca= '" & intPielSeca & "',piellevementeseca='" & intPielLevementeSeca & "',pielmedianamenteseca='" & intPielMedianamenteSeca & "',pielmuyseca='" & intPielMuySeca & "',
                                     pielgrasa='" & intPielgrasa & "',piellevementegrasa='" & intPielLevementeSeca & "',pielmedianamentegrasa='" & intPielMedianamenteGrasa & "',pielmuygrasa='" & intPielMuyGrasa & "',
                                     obspiel='" & strObservacionesPiel & "',desvitalizada='" & intDesvitalizada & "',asfictica='" & intAsfictica & "',hidratada='" & intHidratada & "',standar='" & intStandar & "'
                                    WHERE ID='" & idFacialModificado & "'"
                If validaciones.registreDatos(strCadena) Then
                    intRegistro = 1
                End If
        End Select



    End Sub

    Private Sub BuscarPorDocumentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarPorDocumentoToolStripMenuItem.Click
        Dim strCedula = InputBox("Escriba una cedula", "Mensaje del Sistema")
        If validaciones.saberingreso(strCedula) Then
            If Not strCedula.Equals("") Then
                alimentarFacial(strCedula, 1)
                btnGuardar.Enabled = True
                btnModificar.Enabled = True
            Else
                MessageBox.Show("EL documento ingresado no se encontro en la base de datos", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("EL documento ingresado no se encontro en la base de datos", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Public Function alimentarFacial(cedula As String, tipobusqueda As Integer) As Boolean
        Dim booClienteEncontrado As Boolean = False
        Try
            conexion.ConnectionString = Principal.cadenadeconexion
            conexion.Open()
            Dim cadena As String = ""

            Select Case tipobusqueda
                Case 1
                    cadena = "SELECT  cl.id as idcliente,facial.id as idfacial,cl.cedula,concat(cl.nombre,' ',cl.apellido) as cliente,ecardiaca,ecardiacat,erenal,erenalt,edigestiva,edigestivat,lcontacto,lcontactot,impdental,impdentalt,ecirculatoria,ecirculatoriat,pazucar,pazucart,ppresion,ppresiont,
                             ppiel,ppielt,ffacial,ffacialt,alergias,alergiast,convulsiones,convulsionest,cremas,cremast,cirugias,cirugiast,medicamento,medicamentot,observaciones,pielseca,piellevementeseca,pielmedianamenteseca,
                             pielmuyseca,pielgrasa,piellevementegrasa,pielmedianamentegrasa,pielmuygrasa,obspiel,desvitalizada,asfictica,hidratada,standar
                             FROM cliente cl,facial  WHERE cl.id=facial.idtercero AND cl.cedula='" & cedula & "'"
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
                    idFacialModificado = leerdato.GetString("idfacial")
                    txtDocumento.Text = leerdato.GetString("cedula")
                    If leerdato.GetInt32("ecardiaca") = 1 Then rbCardiacasi.Checked = True Else rbCardiacano.Checked = True
                    txtcardiacas.Text = leerdato.GetString("ecardiacat")
                    If leerdato.GetInt32("erenal") = 1 Then rbRenalessi.Checked = True Else rbRenalesno.Checked = True
                    txtRenales.Text = leerdato.GetString("erenalt")
                    If leerdato.GetInt32("edigestiva") = 1 Then rbDigestivassi.Checked = True Else rbDigestivasno.Checked = True
                    txtDigestivas.Text = leerdato.GetString("edigestivat")
                    If leerdato.GetInt32("lcontacto") = 1 Then rbLcontactosi.Checked = True Else rbLcontactono.Checked = True
                    txtLcontacto.Text = leerdato.GetString("lcontactot")
                    If leerdato.GetInt32("impdental") = 1 Then rbDentalessi.Checked = True Else rbDentalesno.Checked = True
                    txtDentales.Text = leerdato.GetString("impdentalt")
                    If leerdato.GetInt32("ecirculatoria") = 1 Then rbCirculatoriassi.Checked = True Else rbCirculatoriasno.Checked = True
                    txtDentales.Text = leerdato.GetString("ecirculatoriat")
                    If leerdato.GetInt32("pazucar") = 1 Then rbAzucarsi.Checked = True Else rbAzucarno.Checked = True
                    txtAzucar.Text = leerdato.GetString("pazucart")
                    If leerdato.GetInt32("ppresion") = 1 Then rbPresionsi.Checked = True Else rbPresionno.Checked = True
                    txtPresion.Text = leerdato.GetString("ppresiont")
                    If leerdato.GetInt32("ppiel") = 1 Then rbPpielsi.Checked = True Else rbPpielno.Checked = True
                    txtProblemaspiel.Text = leerdato.GetString("ppielt")
                    If leerdato.GetInt32("ffacial") = 1 Then rbFfacialsi.Checked = True Else rbFfacialno.Checked = True
                    txtFracturafacial.Text = leerdato.GetString("ffacialt")
                    If leerdato.GetInt32("alergias") = 1 Then rbAlergiassi.Checked = True Else rbAlergiasno.Checked = True
                    txtAlergias.Text = leerdato.GetString("alergiast")
                    If leerdato.GetInt32("convulsiones") = 1 Then rbConvulsionsi.Checked = True Else rbConvulsionno.Checked = True
                    txtConvulsiones.Text = leerdato.GetString("convulsionest")
                    If leerdato.GetInt32("cremas") = 1 Then rbCremassi.Checked = True Else rbCremasno.Checked = True
                    txtCremas.Text = leerdato.GetString("cremast")
                    If leerdato.GetInt32("cirugias") = 1 Then rbCirugiassi.Checked = True Else rbCirugiasno.Checked = True
                    txtCirugias.Text = leerdato.GetString("cirugiast")
                    If leerdato.GetInt32("medicamento") = 1 Then rbMedicamentossi.Checked = True Else rbMedicamentosno.Checked = True
                    txtMedicamento.Text = leerdato.GetString("medicamentot")
                    txtObservaciones1.Text = leerdato.GetString("observaciones")
                    If leerdato.GetInt32("pielseca") = 1 Then rbPielsecasi.Checked = True Else rbPielsecano.Checked = True
                    If leerdato.GetInt32("piellevementeseca") = 1 Then rbPielLevesecasi.Checked = True Else rbpielLevesecano.Checked = True
                    If leerdato.GetInt32("pielmedianamenteseca") = 1 Then rbPielMediasecasi.Checked = True Else rbPielMediasecano.Checked = True
                    If leerdato.GetInt32("pielmuyseca") = 1 Then rbPielmuySecasi.Checked = True Else rbPielMuysecano.Checked = True
                    If leerdato.GetInt32("pielgrasa") = 1 Then rbPielgrasasi.Checked = True Else rbPielgrasano.Checked = True
                    If leerdato.GetInt32("piellevementegrasa") = 1 Then rbPielLeveGrasasi.Checked = True Else rbPielleveGrasano.Checked = True
                    If leerdato.GetInt32("pielmedianamentegrasa") = 1 Then rbPielMediaGrasasi.Checked = True Else rbPielMediaGrasasi.Checked = True
                    If leerdato.GetInt32("pielmuygrasa") = 1 Then rbPielMuyGrasasi.Checked = True Else rbPielmuyGrasano.Checked = True
                    txtObeservacionesPiel.Text = leerdato.GetString("obspiel")
                    If leerdato.GetInt32("desvitalizada") = 1 Then rbDesvitalizadasi.Checked = True Else rbDesvitalizadano.Checked = True
                    If leerdato.GetInt32("asfictica") = 1 Then rbAsficticasi.Checked = True Else rbAsficticasi.Checked = True
                    If leerdato.GetInt32("hidratada") = 1 Then rbHidratadasi.Checked = True Else rbHidratadasi.Checked = True
                    If leerdato.GetInt32("standar") = 1 Then rbStandarsi.Checked = True Else rbStandarsi.Checked = True



                End While
            End Using
            conexion.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return booClienteEncontrado
    End Function



    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        registreFacial(2)
        reiniciar()
        MessageBox.Show("Registro modificado", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

    End Sub

    Function validarCampos() As Boolean
        If Not txtDocumento.Text.ToString.Equals("") Then
            If Not lblCliente.Text.ToString.Equals("") Then

                Return True

            Else : Return False
            End If
        Else : Return False
        End If
    End Function

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        reiniciar()
    End Sub
    Sub reiniciar()
        txtDocumento.Text = ""
        lblCliente.Text = ""
        txtcardiacas.Text = ""
        txtRenales.Text = ""
        txtDigestivas.Text = ""
        txtLcontacto.Text = ""
        txtDentales.Text = ""
        txtCirculatorias.Text = ""
        txtAzucar.Text = ""
        txtPresion.Text = ""
        txtProblemaspiel.Text = ""
        txtFracturafacial.Text = ""
        txtAlergias.Text = ""
        txtConvulsiones.Text = ""
        txtCremas.Text = ""
        txtCirugias.Text = ""
        txtMedicamento.Text = ""
        txtObservaciones1.Text = ""
        txtObeservacionesPiel.Text = ""
        btnGuardar.Enabled = True
        btnModificar.Enabled = False
        If rbCardiacasi.Checked Then rbCardiacasi.Checked = False : Else rbCardiacano.Checked = False
        If rbRenalessi.Checked Then rbRenalessi.Checked = False : Else rbRenalesno.Checked = False
        If rbDigestivassi.Checked Then rbDigestivassi.Checked = False : Else rbDigestivasno.Checked = False
        If rbLcontactosi.Checked Then rbLcontactosi.Checked = False : Else rbLcontactosi.Checked = False
        If rbDentalessi.Checked Then rbDentalessi.Checked = False : Else rbDentalesno.Checked = False
        If rbCirculatoriassi.Checked Then rbCirculatoriassi.Checked = False : Else rbCirculatoriasno.Checked = False
        If rbAzucarsi.Checked Then rbAzucarsi.Checked = False : Else rbAzucarno.Checked = False
        If rbPresionsi.Checked Then rbPresionsi.Checked = False : Else rbPresionno.Checked = False
        If rbPpielsi.Checked Then rbPpielsi.Checked = False : Else rbPpielno.Checked = False
        If rbFfacialsi.Checked Then rbFfacialsi.Checked = False : Else rbFfacialno.Checked = False
        If rbAlergiassi.Checked Then rbAlergiassi.Checked = False : Else rbAlergiasno.Checked = False
        If rbConvulsionsi.Checked Then rbConvulsionsi.Checked = False : Else rbConvulsionno.Checked = False
        If rbCremassi.Checked Then rbCremassi.Checked = False : Else rbCremasno.Checked = False
        If rbCirugiassi.Checked Then rbCirugiassi.Checked = False : Else rbCirugiasno.Checked = False
        If rbMedicamentossi.Checked Then rbMedicamentossi.Checked = False : Else rbMedicamentosno.Checked = False
        If rbPielsecasi.Checked Then rbPielsecasi.Checked = False : Else rbPielsecano.Checked = False
        If rbPielLevesecasi.Checked Then rbPielLevesecasi.Checked = False : Else rbpielLevesecano.Checked = False
        If rbPielMediasecasi.Checked Then rbPielMediasecasi.Checked = False : Else rbPielMediasecano.Checked = False
        If rbPielmuySecasi.Checked Then rbPielmuySecasi.Checked = False : Else rbPielMuysecano.Checked = False
        If rbPielgrasasi.Checked Then rbPielgrasasi.Checked = False : Else rbPielgrasano.Checked = False
        If rbPielLeveGrasasi.Checked Then rbPielLeveGrasasi.Checked = False : Else rbPielleveGrasano.Checked = False
        If rbPielMediaGrasasi.Checked Then rbPielMediaGrasasi.Checked = False : Else rbPielMediagrasano.Checked = False
        If rbPielMuyGrasasi.Checked Then rbPielMuyGrasasi.Checked = False : Else rbPielmuyGrasano.Checked = False
        If rbDesvitalizadasi.Checked Then rbDesvitalizadasi.Checked = False : Else rbDesvitalizadano.Checked = False
        If rbAsficticasi.Checked Then rbAsficticasi.Checked = False : Else rbAsficticano.Checked = False
        If rbHidratadasi.Checked Then rbHidratadasi.Checked = False : Else rbHidratadano.Checked = False
        If rbStandarsi.Checked Then rbStandarsi.Checked = False : Else rbStandarno.Checked = False

        idFacialModificado = 0
        idTerceroModificado = 0
    End Sub

    Private Sub consentimientofacial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnModificar.Enabled = False
    End Sub

    Private Sub GenerarDocumentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerarDocumentoToolStripMenuItem.Click

        Dim intIdTercero As Integer = validaciones.saberIdTerceroByCedula(txtDocumento.Text)
        Dim intEcardiaca As Integer = 2
        Dim strCardiaca As String = txtcardiacas.Text
        Dim intRenal As Integer = 2
        Dim strRenal As String = txtRenales.Text
        Dim intDigestivo As Integer = 2
        Dim strDigestivo As String = txtDigestivas.Text
        Dim intLcontacto As Integer = 2
        Dim strLcontacto As String = txtLcontacto.Text
        Dim intImpDental As Integer = 2
        Dim strImpDental As String = txtDentales.Text
        Dim intEcirculatoria As Integer = 2
        Dim strEcirculatoria As String = txtCirculatorias.Text
        Dim intPazucar As Integer = 2
        Dim strPazucar As String = txtAzucar.Text
        Dim intPpresion As Integer = 2
        Dim strPpresion As String = txtPresion.Text
        Dim intPpiel As Integer = 2
        Dim strPpiel As String = txtProblemaspiel.Text
        Dim intFfacial As Integer = 2
        Dim strFfacial As String = txtFracturafacial.Text
        Dim intAlergias As Integer = 2
        Dim strAlergias As String = txtAlergias.Text
        Dim intConvulsiones As Integer = 2
        Dim strConvulsiones As String = txtConvulsiones.Text
        Dim intCremas As Integer = 2
        Dim strcremas As String = txtCremas.Text
        Dim intCirugias As Integer = 2
        Dim strCirugias As String = txtCirugias.Text
        Dim intMedicamento As Integer = 2
        Dim strMedicamento As String = txtMedicamento.Text
        Dim strObservaciones As String = txtObservaciones1.Text
        Dim intPielSeca As Integer = 2
        Dim intPielLevementeSeca As Integer = 2
        Dim intPielMedianamenteSeca As Integer = 2
        Dim intPielMuySeca As Integer = 2
        Dim intPielgrasa As Integer = 2
        Dim intPielLevementegrasa As Integer = 2
        Dim intPielMedianamenteGrasa As Integer = 2
        Dim intPielMuyGrasa As Integer = 2
        Dim strObservacionesPiel As String = txtObservaciones1.Text
        Dim intDesvitalizada As Integer = 2
        Dim intAsfictica As Integer = 2
        Dim intHidratada As Integer = 2
        Dim intStandar As Integer = 2

        If rbCardiacasi.Checked Then intEcardiaca = 1 : Else intEcardiaca = 2
        If rbRenalessi.Checked Then intRenal = 1 : Else intRenal = 2
        If rbDigestivassi.Checked Then intDigestivo = 1 : Else intDigestivo = 2
        If rbLcontactosi.Checked Then intLcontacto = 1 : Else intLcontacto = 2
        If rbDentalessi.Checked Then intImpDental = 1 : Else intImpDental = 2
        If rbCirculatoriassi.Checked Then intEcirculatoria = 1 : Else intEcirculatoria = 2
        If rbAzucarsi.Checked Then intPazucar = 1 : Else intPazucar = 2
        If rbPresionsi.Checked Then intPpresion = 1 : Else intPpresion = 2
        If rbPpielsi.Checked Then intPpiel = 1 : Else intPpiel = 2
        If rbFfacialsi.Checked Then intFfacial = 1 : Else intFfacial = 2
        If rbAlergiassi.Checked Then intAlergias = 1 : Else intAlergias = 2
        If rbConvulsionsi.Checked Then intConvulsiones = 1 : Else intConvulsiones = 2
        If rbCremassi.Checked Then intCremas = 1 : Else intCremas = 2
        If rbCirugiassi.Checked Then intCirugias = 1 : Else intCirugias = 2
        If rbMedicamentossi.Checked Then intMedicamento = 1 : Else intMedicamento = 2
        If rbPielsecasi.Checked Then intPielSeca = 1 : Else intPielSeca = 2
        If rbPielLevesecasi.Checked Then intPielLevementeSeca = 1 : Else intPielLevementeSeca = 2
        If rbPielMediasecasi.Checked Then intPielMedianamenteSeca = 1 : Else intPielMedianamenteSeca = 2
        If rbPielmuySecasi.Checked Then intPielMuySeca = 1 : Else intPielMuySeca = 2
        If rbPielgrasasi.Checked Then intPielgrasa = 1 : Else intPielgrasa = 2
        If rbPielLeveGrasasi.Checked Then intPielLevementegrasa = 1 : Else intPielLevementegrasa = 2
        If rbPielMediaGrasasi.Checked Then intPielMedianamenteGrasa = 1 : Else intPielMedianamenteGrasa = 2
        If rbPielMuyGrasasi.Checked Then intPielMuyGrasa = 1 : Else intPielMuyGrasa = 2
        If rbDesvitalizadasi.Checked Then intDesvitalizada = 1 : Else intDesvitalizada = 2
        If rbAsficticasi.Checked Then intAsfictica = 1 : Else intAsfictica = 2
        If rbHidratadasi.Checked Then intHidratada = 1 : Else intHidratada = 2
        If rbStandarsi.Checked Then intStandar = 1 : Else intStandar = 2

        Dim img As Image = Image.FromFile(Logo)
        Dim cedula As String = txtDocumento.Text
        Dim img2 As Image = Image.FromFile(Titulo)
        Dim S_N As Image = Image.FromFile(si_no)
        Dim img3 As Image = Image.FromFile(Anatomia)
        Dim Datos As New FichaFacialVO(Principal.strunidad + ":\sistemgym_datos\fotos\profesional.jpg",
                                       idFacialModificado,
                                       lblCliente.Text,
                                       "Cúcuta",
                                       saberEdad(cedula),
                                       "NA",
                                       traerCampo(cedula, "nacimiento"),
                                       traerCampo(cedula, "correo"),
                                        traerCampo(cedula, "telefono"),
                                       "Chequeo",
                                       intEcardiaca, strCardiaca,
                                       intEcirculatoria, strEcirculatoria,
                                       intAlergias, strAlergias,
                                       intRenal, strRenal,
                                       intPazucar, strPazucar,
                                       intConvulsiones, strConvulsiones,
                                       intDigestivo, strDigestivo,
                                       intPpresion, strPpresion,
                                       intCremas, strcremas,
                                       intLcontacto, strLcontacto,
                                       intPpiel, strPpiel,
                                       intCirugias, strCirugias,
                                       intImpDental, strImpDental,
                                       2, "",
                                       intMedicamento, strMedicamento,
                                       2, "",
                                       strObservaciones,
                                       intPielSeca,
                                       intPielLevementeSeca,
                                       intPielMedianamenteSeca,
                                       intPielMuySeca,
                                       intPielgrasa,
                                       intPielMuyGrasa,
                                       intPielMedianamenteGrasa,
                                       intPielMuyGrasa,
                                       strObservacionesPiel,
                                       intDesvitalizada,
                                       intAsfictica,
                                       intHidratada,
                                       intStandar)
        PDF = New Report
        PDF.FichaFacialPDF(img, img2, Datos, img3)
    End Sub

    Private Sub ConsentimientoToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ConsentimientoHidrafacialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsentimientoHidrafacialToolStripMenuItem.Click
        Dim img As Image = Image.FromFile(Logo)
        Dim img2 As Image = Image.FromFile(Titulo)
        Dim S_N As Image = Image.FromFile(si_no)
        Dim procedimiento As String = InputBox("Escriba el procedimiento")
        Dim img3 As Image = Image.FromFile(Anatomia)
        Dim Datos As New HidraFacialVO(lblCliente.Text,
                                               Date.Now,
                                               traerCampo(txtDocumento.Text, "ruta"),
                                                traerCampo(txtDocumento.Text, "instructor"),
                                                procedimiento)
        PDF = New Report
        PDF.ConsentimientoHidrafacialPDF(img, img2, img3, Datos)
    End Sub

    Private Sub EnvieFacturaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnvieFacturaToolStripMenuItem.Click

    End Sub

    Private Sub PanelCabecera_Paint(sender As Object, e As PaintEventArgs) Handles PanelCabecera.Paint

    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub rbPresionno_CheckedChanged(sender As Object, e As EventArgs) Handles rbPresionno.CheckedChanged

    End Sub

    Private Sub rbPresionsi_CheckedChanged(sender As Object, e As EventArgs) Handles rbPresionsi.CheckedChanged

    End Sub

    Private Sub GroupBox16_Enter(sender As Object, e As EventArgs) Handles GroupBox16.Enter

    End Sub

    Private Sub Label22_Click(sender As Object, e As EventArgs) Handles Label22.Click

    End Sub

    Private Sub rbConvulsionno_CheckedChanged(sender As Object, e As EventArgs) Handles rbConvulsionno.CheckedChanged

    End Sub

    Private Sub rbConvulsionsi_CheckedChanged(sender As Object, e As EventArgs) Handles rbConvulsionsi.CheckedChanged

    End Sub

    Private Sub GroupBox15_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub rbStandarno_CheckedChanged(sender As Object, e As EventArgs) Handles rbStandarno.CheckedChanged

    End Sub

    Private Sub rbStandarsi_CheckedChanged(sender As Object, e As EventArgs) Handles rbStandarsi.CheckedChanged

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtDocumento_TextChanged(sender As Object, e As EventArgs) Handles txtDocumento.TextChanged

    End Sub
End Class