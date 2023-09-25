Public Class Medidas
    Dim gestor1 As New Soltec.Gestor
    Dim sexo As Integer = -1
    Dim con As New conexion
    Dim intIdDeLaPersona As String
    Private Sub txtName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtName.KeyDown
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
        txtName.Select(txtName.Text.Length + 1, 0)

    End Sub

    Private Sub txtName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtName.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If lstNombres.SelectedItems.Count = 0 Then Exit Sub
            intIdDeLaPersona = lstNombres.SelectedItems(0).Tag
            txtName.Text = lstNombres.SelectedItems(0).SubItems(0).Text & " " & lstNombres.SelectedItems(0).SubItems(1).Text
            con.VisualizarRortes(lstEstados, Now.Date, Now.Date, 100, txtCintura, intIdDeLaPersona)
            lstNombres.Visible = False
        End If
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        If txtname.Text = "" Then Exit Sub
        Dim arlCoincidencias = gestor1.DatosDeConsulta("SELECT id, nombre ,apellido FROM cliente WHERE concat(nombre,' ',apellido) LIKE '%" & txtName.Text & "%' or cedula LIKE '%" & txtName.Text & "%'  ORDER BY nombre LIMIT 30", , Principal.cadenadeconexion)
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

    End Sub

    Private Sub txtPeso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPeso.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtTalla.Focus()
        End If
    End Sub

    Private Sub txtPeso_TextChanged(sender As Object, e As EventArgs) Handles txtPeso.TextChanged

    End Sub
    Function valideCampos() As Boolean
        Dim booSaber = False
        If Not sexo = -1 Then
            If Not txtPeso.Text.Equals("") Then
                If Not txtTalla.Text.Equals("") Then
                    If Not txtEdad.Text.Equals("") Then
                        booSaber = True
                    Else
                        MessageBox.Show("Debe ingresar la edad", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtEdad.Focus()
                    End If
                Else
                    MessageBox.Show("Debe ingresar la talla en cm", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtTalla.Focus()
                End If
            Else
                MessageBox.Show("Debe ingresar el peso en kg", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPeso.Focus()
            End If
        Else
            MessageBox.Show("Seleccione un sexo", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        Return booSaber
    End Function

    Private Sub txtTalla_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTalla.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtEdad.Focus()
        End If
    End Sub

    Private Sub txtEdad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEdad.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If valideCampos() Then
                txtImc.Text = IMCORPORAL(txtPeso.Text, txtTalla.Text, lblEstato)
                txtGrasa.Text = porcentajeGrasa(sexo, txtImc.Text, txtEdad.Text)
                txtFc.Focus()
            End If
        End If
    End Sub

    Private Sub txtGrasa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtGrasa.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtFc.Focus()
        End If
    End Sub

    Private Sub txtTalla_TextChanged(sender As Object, e As EventArgs) Handles txtTalla.TextChanged

    End Sub

    Private Sub rdFemenino_CheckedChanged(sender As Object, e As EventArgs) Handles rdFemenino.CheckedChanged
        sexo = 0
    End Sub

    Private Sub rdMasculino_CheckedChanged(sender As Object, e As EventArgs) Handles rdMasculino.CheckedChanged
        sexo = 1
    End Sub
    Sub limpiarr()
        txtName.Text = ""
        lblEstato.Text = ""
        txtPeso.Text = "0"
        txtTalla.Text = "0"
        txtEdad.Text = "0"
        txtImc.Text = "0"
        txtGrasa.Text = "0"
        txtFc.Text = "0"
        txtpantorrilla.Text = "0"
        txtMuslo.Text = "0"
        txtGluteo.Text = "0"
        rdMasculino.Checked = False
        rdFemenino.Checked = False
        txtCintura.Text = "0"
        txtEspalda.Text = "0"
        txtPectoral.Text = "0"
        txtBrazoder.Text = "0"
        txtPiernader.Text = "0"
        txtPiernaizq.Text = "0"
        txtPechoespalda.Text = "0"
        txtCuello.Text = "0"
        txtBiceps.Text = "0"
        txtTriceps.Text = "0"
        txtSuprailiaca.Text = "0"
        txtSubescapula.Text = "0"
        txtBrazoizq.Text = "0"
        txtRestricciones.Text = "0"
        txtObservaciones.Text = "0"
        rdMasculino.AutoCheck = False
        rdFemenino.AutoCheck = False

        txtName.Focus()

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim cadena As String = "INSERT INTO medida (cliente,edad,sexo,peso,talla,fcxmin,imc,porgrasa, pantorrilla,muslomedio,gluteo,cintura,espalda,pectorales,brizq,brder,restriccion,objetivo,pechoespalda,cuello,piizq,pider,bicep,tricep,subes,supra) values" & vbCrLf &
                                                "( '" & intIdDeLaPersona & "','" & txtEdad.Text & "','" & sexo & "','" & txtPeso.Text & "','" & txtTalla.Text & "','" & txtFc.Text & "','" & Replace(txtImc.Text, ",", ".") & "','" & Replace(txtGrasa.Text, ",", ".") & "','" & txtpantorrilla.Text & "','" & txtMuslo.Text & "','" & txtGluteo.Text & "','" & txtCintura.Text & "','" & txtEspalda.Text & "','" & txtPectoral.Text & "','" & txtBrazoizq.Text & "','" & txtBrazoder.Text & "' " & vbCrLf &
                                                " ,'" & txtRestricciones.Text & "','" & txtObservaciones.Text & "','" & txtPechoespalda.Text & "','" & txtCuello.Text & "','" & txtPiernaizq.Text & "','" & txtPiernader.Text & "','" & txtBiceps.Text & "','" & txtTriceps.Text & "','" & txtSubescapula.Text & "','" & txtSuprailiaca.Text & "' )"
        If con.registreDatos(cadena) Then
            MessageBox.Show("Registro Exitoso", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            limpiarr()
        End If
    End Sub

    Private Sub Medidas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtName.Focus()
        colorBarras(PanelCabecera)
    End Sub

    Private Sub txtFc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFc.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtpantorrilla.Focus()
        End If
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else : e.Handled = True
        End If
    End Sub

    Private Sub txtpantorrilla_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtpantorrilla.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtMuslo.Focus()
        End If
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else : e.Handled = True
        End If
    End Sub

    Private Sub txtMuslo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMuslo.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtBiceps.Focus()
        End If
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else : e.Handled = True
        End If
    End Sub

    Private Sub txtGluteo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtGluteo.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtBrazoder.Focus()
        End If
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else : e.Handled = True
        End If
    End Sub

    Private Sub txtCintura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCintura.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtGluteo.Focus()
        End If
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else : e.Handled = True
        End If
    End Sub

    Private Sub txtEspalda_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEspalda.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtPectoral.Focus()
        End If
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else : e.Handled = True
        End If
    End Sub

    Private Sub txtPectoral_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPectoral.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtCintura.Focus()
        End If
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else : e.Handled = True
        End If
    End Sub

    Private Sub txtIzquierdo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBrazoizq.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtPiernader.Focus()
        End If
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else : e.Handled = True
        End If
    End Sub

    Private Sub txtDerecho_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            txtRestricciones.Focus()
        End If
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else : e.Handled = True
        End If
    End Sub

    Private Sub txtRestricciones_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRestricciones.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtObservaciones.Focus()
        End If

    End Sub

    Private Sub txtObservaciones_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtObservaciones.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btnGuardar.PerformClick()
        End If

    End Sub

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Me.Close()
    End Sub

    Private Sub txtBiceps_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBiceps.KeyPress
        If Asc(e.KeyChar) = 13 Then
            porgrasa()
            txtTriceps.Focus()
        End If
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else : e.Handled = True
        End If
    End Sub

    Private Sub txtTriceps_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTriceps.KeyPress
        If Asc(e.KeyChar) = 13 Then
            porgrasa()
            txtSubescapula.Focus()
        End If
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else : e.Handled = True
        End If
    End Sub

    Sub porgrasa()
        If IsNumeric(txtBiceps.Text) And IsNumeric(txtTriceps.Text) And IsNumeric(txtSubescapula.Text) And IsNumeric(txtSuprailiaca.Text) Then
            txtGrasa.Text = Int32.Parse(txtBiceps.Text) + Int32.Parse(txtSuprailiaca.Text) + Int32.Parse(txtSubescapula.Text)
        End If
    End Sub

    Private Sub txtTriceps_TextChanged(sender As Object, e As EventArgs) Handles txtTriceps.TextChanged

    End Sub

    Private Sub txtSubescapula_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSubescapula.KeyPress
        If Asc(e.KeyChar) = 13 Then
            porgrasa()
            txtSuprailiaca.Focus()
        End If
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else : e.Handled = True
        End If
    End Sub

    Private Sub txtSuprailiaca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSuprailiaca.KeyPress
        If Asc(e.KeyChar) = 13 Then
            porgrasa()
        End If
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else : e.Handled = True
        End If
    End Sub

    Private Sub txtCuello_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCuello.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtPechoespalda.Focus()
        End If
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else : e.Handled = True
        End If
    End Sub

    Private Sub txtPechoespalda_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPechoespalda.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtEspalda.Focus()
        End If
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else : e.Handled = True
        End If
    End Sub

    Private Sub txtBrazoder_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBrazoder.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtBrazoizq.Focus()
        End If
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else : e.Handled = True
        End If
    End Sub

    Private Sub txtBrazoizq_TextChanged(sender As Object, e As EventArgs) Handles txtBrazoizq.TextChanged

    End Sub

    Private Sub txtPiernader_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPiernader.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtPiernaizq.Focus()
        End If
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else : e.Handled = True
        End If
    End Sub

    Private Sub txtPiernaizq_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPiernaizq.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtpantorrilla.Focus()
        End If
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else : e.Handled = True
        End If
    End Sub

    Private Sub txtMuslo_TextChanged(sender As Object, e As EventArgs) Handles txtMuslo.TextChanged

    End Sub

    Private Sub lstNombres_MouseClick(sender As Object, e As MouseEventArgs) Handles lstNombres.MouseClick

        If lstNombres.SelectedItems.Count = 0 Then Exit Sub
        intIdDeLaPersona = lstNombres.SelectedItems(0).Tag
        txtName.Text = lstNombres.SelectedItems(0).SubItems(0).Text & " " & lstNombres.SelectedItems(0).SubItems(1).Text
        con.VisualizarRortes(lstEstados, Now.Date, Now.Date, 100, txtCintura, intIdDeLaPersona)
        lstNombres.Visible = False

    End Sub
End Class