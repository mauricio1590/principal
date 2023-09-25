Public Class ArquepSpa
    Dim con As New conexion
    Dim intIdDeLaPersona As Integer = 0
    Dim gestor1 As New Soltec.Gestor
    Private Sub ArquepSpa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Principal.intNivelUsuario < 4 Then
            lblNombre.Visible = False
            txtname.Visible = False
            intIdDeLaPersona = Principal.intidusuario
        End If
        con.VisualizarRortes(lstreportes, Now.Date, Now.Date, 303, txtTotal, , intIdDeLaPersona)
        If Principal.intNivelUsuario < 4 Then
            btnArqueo.Visible = False
        End If
        colorBarras(PanelCabecera)
    End Sub
    Private Sub btnArqueo_Click(sender As Object, e As EventArgs) Handles btnArqueo.Click
        Dim strcadena As String = ""
        If intIdDeLaPersona = 0 Then
            Dim res1 = MessageBox.Show("Esta seguro de hacer el arqueo total", "Informacion Del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If res1 = Windows.Forms.DialogResult.Yes Then
                strcadena = "TRUNCATE CAJA2"
            End If
        Else
            Dim res1 = MessageBox.Show("Esta seguro de hacer el arqueo de este usuario", "Informacion Del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If res1 = Windows.Forms.DialogResult.Yes Then
                strcadena = "DELETE FROM CAJA2 WHERE usuario = " & intIdDeLaPersona & ""
            End If
        End If
        If Not strcadena.Equals("") Then
            con.registreDatos(strcadena)
            MessageBox.Show("registro correcto ", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If

        con.VisualizarRortes(lstreportes, Now.Date, Now.Date, 303, txtTotal)
    End Sub
    Private Sub txtname_TextChanged(sender As Object, e As EventArgs) Handles txtname.TextChanged
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

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Me.Close()
    End Sub
End Class