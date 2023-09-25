Public Class HistorialDeAcceso
    Dim Gestor1 As New Gestor
    Dim intIdDeLaPersona As New Integer
    Dim con As New conexion
    Private Sub txtname_TextChanged(sender As Object, e As EventArgs) Handles txtname.TextChanged
        If txtname.Text = "" Then Exit Sub
        Dim con As String = Principal.cadenadeconexion
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

    Private Sub lstNombres_MouseClick(sender As Object, e As MouseEventArgs) Handles lstNombres.MouseClick
        buscardatos()
    End Sub

    Private Sub HistorialDeAcceso_Load(sender As Object, e As EventArgs) Handles MyBase.Load, fdesde.TabIndexChanged
        txtname.Focus()
    End Sub
    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Me.Close()
    End Sub
    Private Sub txtname_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtname.PreviewKeyDown
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
    Sub buscardatos()
        Dim fecha1 As Date = fdesde.Value.Date
        Dim fecha2 As Date = fhasta.Value.Date
        If lstNombres.SelectedItems.Count = 0 Then Exit Sub
        intIdDeLaPersona = lstNombres.SelectedItems(0).Tag
        con.VisualizarRortes(lstreportes, fecha1, fecha2, 900, txtTotal, intIdDeLaPersona)
        lstNombres.Visible = False
    End Sub

    Private Sub txtname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtname.KeyPress
        If Asc(e.KeyChar) = 13 Then
            buscardatos()
        End If

    End Sub

    Private Sub txtExportar_Click(sender As Object, e As EventArgs) Handles txtExportar.Click
        Dim SaveFileDialog1 As New Windows.Forms.SaveFileDialog
        SaveFileDialog1.DefaultExt = "*.csv"
        SaveFileDialog1.FileName = ""
        SaveFileDialog1.Filter = "Archivos CSV de Excel (*.csv|*.csv"
        SaveFileDialog1.ShowDialog()
        GuardeEnArchivo(ListViewACsv(lstreportes, True), SaveFileDialog1.FileName, True)
    End Sub

    Private Sub fdesde_KeyPress(sender As Object, e As KeyPressEventArgs) Handles fdesde.KeyPress
        If Asc(e.KeyChar) = 13 Then
            buscardatos()
        End If
    End Sub

    Private Sub fhasta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles fhasta.KeyPress
        If Asc(e.KeyChar) = 13 Then
            buscardatos()
        End If
    End Sub

    Private Sub fdesde_Enter(sender As Object, e As EventArgs) Handles fdesde.Enter, txtname.TabIndexChanged, lstNombres.TabIndexChanged

        buscardatos()

    End Sub
End Class