Public Class TarifasNoCongelables
    Dim gestor1 As New Soltec.Gestor
    Dim con As New conexion
    Dim intIdTarifa As Integer
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


        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If Not txtTarifa.Text.Equals("") Then
            Dim strcadena As String = "INSERT tarifasnocongelables (idtarifa) values ('" & intIdTarifa & "')"
            If con.registreDatos(strcadena) Then
                MessageBox.Show("Registro exitoso", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                limpiar()
            End If
        Else
            MessageBox.Show("Es necesario alimentar todos los campos", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Sub limpiar()

        intIdTarifa = 0
        txtTarifa.Text = ""
        con.mostrarTariasEspeciales(lstGuardadas)
        btnAceptar.Enabled = True

    End Sub

    Private Sub TarifasNoCongelables_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.mostrarTariasnoCongelables(lstGuardadas)
    End Sub
End Class