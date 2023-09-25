Public Class TarifasEspeciales
    Dim Gestor1 As New Soltec.Gestor
    Dim con As New conexion
    Dim intIdTarifa As Integer
    Dim intIdTarifaBuscada As Integer

    Private Sub txtTarifa_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTarifa.KeyDown
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
        txtTarifa.Select(txtTarifa.Text.Length + 1, 0)
    End Sub
    Private Sub txtTarifa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTarifa.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If lstTarifas.SelectedItems.Count = 0 Then Exit Sub
            intIdTarifa = lstTarifas.SelectedItems(0).Tag
            txtTarifa.Text = lstTarifas.SelectedItems(0).Text
            lstTarifas.Visible = False
            txtHora1.Focus()

        End If
    End Sub
    Private Sub txtTarifa_TextChanged(sender As Object, e As EventArgs) Handles txtTarifa.TextChanged
        If txtTarifa.Text = "" Then Exit Sub
        Dim arlCoincidencias = Gestor1.DatosDeConsulta("SELECT serial,tipo FROM precio WHERE tipo LIKE '%" & txtTarifa.Text & "%' ORDER BY tipo LIMIT 30", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then lstTarifas.Visible = True
        lstTarifas.Items.Clear()
        lstTarifas.BeginUpdate()
        For Each Encontrado As ArrayList In arlCoincidencias
            Dim lviEncontrado As New ListViewItem
            lviEncontrado.Tag = Encontrado(0)
            lviEncontrado.Text = Encontrado(1)
            lstTarifas.Items.Add(lviEncontrado)
        Next
        lstTarifas.EndUpdate()
    End Sub

    Private Sub txthora1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHora1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtHora2.Focus()
        End If
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else : e.Handled = True
        End If
    End Sub

  
    Private Sub txtHora2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHora2.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If btnAceptar.Enabled Then
                btnAceptar.PerformClick()
            End If
        End If
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else : e.Handled = True
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If Not txtHora1.Text.Equals("") AndAlso Not txtHora2.Text.Equals("") AndAlso Not txtTarifa.Text.Equals("") Then
            Dim strcadena As String = "INSERT tarifasespeciales (idtarifa,horaentrada,horasalida) values ('" & intIdTarifa & "','" & txtHora1.Text & "','" & txtHora2.Text & "')"
            If con.registreDatos(strcadena) Then
                MessageBox.Show("Registro exitoso", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                limpiar()
            End If
        Else
            MessageBox.Show("Es necesario alimentar todos los campos", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Sub limpiar()
        txtHora1.Text = ""
        txtHora2.Text = ""
        intIdTarifa = 0
        intIdTarifaBuscada = 0
        txtTarifa.Text = ""
        con.mostrarTariasEspeciales(lstGuardadas)
        btnAceptar.Enabled = True
        btnModificar.Enabled = False
    End Sub

    Private Sub TarifasEspeciales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.mostrarTariasEspeciales(lstGuardadas)
    End Sub

    Private Sub lstGuardadas_Click(sender As Object, e As EventArgs) Handles lstGuardadas.Click
        If lstGuardadas.SelectedItems.Count = 0 Then Exit Sub
        intIdTarifaBuscada = lstGuardadas.SelectedItems(0).Tag
        intIdTarifa = intIdTarifaBuscada
        txtTarifa.Text = lstGuardadas.SelectedItems(0).Text
        txtHora1.Text = lstGuardadas.SelectedItems(0).SubItems(1).Text
        txtHora2.Text = lstGuardadas.SelectedItems(0).SubItems(2).Text
        btnModificar.Enabled = True
        btnAceptar.Enabled = False
        txtTarifa.Focus()
        lstTarifas.Visible = False
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If Not txtHora1.Text.Equals("") AndAlso Not txtHora2.Text.Equals("") AndAlso Not txtTarifa.Text.Equals("") Then
            Dim strcadena As String = "UPDATE tarifasespeciales set idtarifa='" & intIdTarifa & "',horaentrada='" & txtHora1.Text & "',horasalida='" & txtHora2.Text & "' where id='" & intIdTarifaBuscada & "' "
            If con.registreDatos(strcadena) Then
                MessageBox.Show("Registro exitoso", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                limpiar()
            End If
        Else
            MessageBox.Show("Es necesario alimentar todos los campos", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class