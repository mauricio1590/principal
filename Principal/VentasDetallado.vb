Public Class VentasDetallado
    Dim con As New conexion
    Dim Gestor1 As New Soltec.Gestor
    Dim intIdDeLaPersona As Integer = 0
    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Me.Close()
    End Sub

    Public Sub buscardatos(tipobusqueda)

        Dim fecha1 As Date = fdesde.Value.Date
        Dim fecha2 As Date = fhasta.Value.Date
        con.VisualizarRortes(lstreportes, Format(fecha1, "yyyy-MM-dd"), Format(fecha2, "yyyy-MM-dd"), 9, txtTotal, intIdDeLaPersona, , ,,,, tipobusqueda)
        txtname.Focus()
    End Sub

    Private Sub VentasDetallado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        buscardatos(2)
    End Sub

    Private Sub fdesde_KeyPress(sender As Object, e As KeyPressEventArgs) Handles fdesde.KeyPress
        If Asc(e.KeyChar) = 13 Then
            buscardatos(2)
        End If
    End Sub

    Private Sub fhasta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles fhasta.KeyPress
        If Asc(e.KeyChar) = 13 Then
            buscardatos(2)
        End If
    End Sub

    Private Sub fdesde_ValueChanged(sender As Object, e As EventArgs) Handles fdesde.ValueChanged

    End Sub

    Private Sub PanelCabecera_Paint(sender As Object, e As PaintEventArgs) Handles PanelCabecera.Paint

    End Sub

    Private Sub lstreportes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstreportes.SelectedIndexChanged

    End Sub

    Private Sub txtname_TextChanged(sender As Object, e As EventArgs) Handles txtname.TextChanged
        If txtname.Text = "" Then Exit Sub
        Dim arlCoincidencias = Gestor1.DatosDeConsulta("SELECT id, nombre ,apellido FROM cliente WHERE concat(nombre,' ',apellido) LIKE '%" & txtname.Text & "%' or cedula like '%" & txtname.Text & "%' ORDER BY nombre LIMIT 30", , Principal.cadenadeconexion)
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
        Dim intBusquedaVenta As Integer = 0
        If Asc(e.KeyChar) = 13 Then
            If lstNombres.SelectedItems.Count = 0 Then Exit Sub
            intIdDeLaPersona = lstNombres.SelectedItems(0).Tag
            intBusquedaVenta = 1
            Dim fecha1 As Date = fdesde.Value.Date
            Dim fecha2 As Date = fhasta.Value.Date
            buscardatos(1)
        End If

        lstNombres.Visible = False
    End Sub

    Private Sub lstNombres_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lstNombres.KeyPress
        If lstNombres.SelectedItems.Count = 0 Then Exit Sub
        intIdDeLaPersona = lstNombres.SelectedItems(0).Tag

        Dim fecha1 As Date = fdesde.Value.Date
        Dim fecha2 As Date = fhasta.Value.Date
        buscardatos(1)
    End Sub

    Private Sub lstNombres_MouseClick(sender As Object, e As MouseEventArgs) Handles lstNombres.MouseClick
        If lstNombres.SelectedItems.Count = 0 Then Exit Sub
        intIdDeLaPersona = lstNombres.SelectedItems(0).Tag

        Dim fecha1 As Date = fdesde.Value.Date
        Dim fecha2 As Date = fhasta.Value.Date
        buscardatos(1)
    End Sub
End Class