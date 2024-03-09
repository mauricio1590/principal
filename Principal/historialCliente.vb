Public Class historialCliente
    Dim Gestor1 As New Soltec.Gestor

    Dim con As New conexion

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Me.Close()
    End Sub

    Private Sub historialCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtname.Focus()
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
        If Asc(e.KeyChar) = 13 Then
            If lstNombres.SelectedItems.Count = 0 Then Exit Sub
            Dim intIdDeLaPersona = lstNombres.SelectedItems(0).Tag
            con.VisualizarRortes(lstreportes, Now.Date, Now.Date, 302, txtTotal, intIdDeLaPersona)
        End If
        lstNombres.Visible = False
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

    Private Sub lstNombres_MouseClick(sender As Object, e As MouseEventArgs) Handles lstNombres.MouseClick
        If lstNombres.SelectedItems.Count = 0 Then Exit Sub
        Dim intIdDeLaPersona = lstNombres.SelectedItems(0).Tag
        con.VisualizarRortes(lstreportes, Now.Date, Now.Date, 302, txtTotal, intIdDeLaPersona)
        lstNombres.Visible = False
    End Sub

    Private Sub lstreportes_MouseClick(sender As Object, e As MouseEventArgs) Handles lstreportes.MouseClick



        If lstreportes.SelectedItems.Count > 0 Then
            Dim strId As String = ""
            Dim strCedula As String = ""
            Dim intValor As Integer = -1
            Dim strNombre As String = ""
            Dim strTarifa As String = ""
            Dim strValor As String = ""

            Select Case Principal.intNivelUsuario
                Case 3
                    Dim imp As New Imprimir()
                    strId = lstreportes.SelectedItems(0).Text
                    strCedula = lstreportes.SelectedItems(0).SubItems(1).Text
                    strNombre = lstreportes.SelectedItems(0).SubItems(2).Text
                    strTarifa = lstreportes.SelectedItems(0).SubItems(3).Text
                    strValor = lstreportes.SelectedItems(0).SubItems(4).Text
                    imp.GenereImpresion(strNombre, strCedula, strTarifa, strValor)
                Case 4

                    Principal.intValidar = 6
                    Dim valide As New VALIDAR
                    valide.ShowDialog()
                    strId = lstreportes.SelectedItems(0).Text
                    strCedula = lstreportes.SelectedItems(0).SubItems(1).Text

                    intValor = lstreportes.SelectedItems(0).SubItems(4).Text

                    If Principal.booEliminarDetalle = True Then
                        Dim res = MessageBox.Show("Esta seguro de eliminar la factura '" & strId & "' ", "Informacion Del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                        If res = Windows.Forms.DialogResult.Yes Then
                            con.registreDatos("DELETE FROM detalles where id='" & strId & "' ; UPDATE PAGO set fecha_corte=current_date where cedula='" & strCedula & "'")
                            ElimineValorCaja(intValor)
                            MessageBox.Show("la factura  se Elimino correctamente", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                        Else : Exit Sub
                        End If
                    End If
            End Select


        End If
    End Sub

    Private Sub lstreportes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstreportes.SelectedIndexChanged

    End Sub

    Private Sub txtExportar_Click(sender As Object, e As EventArgs) Handles txtExportar.Click
        Dim SaveFileDialog1 As New Windows.Forms.SaveFileDialog
        SaveFileDialog1.DefaultExt = "*.csv"
        SaveFileDialog1.FileName = ""
        SaveFileDialog1.Filter = "Archivos CSV de Excel (*.csv|*.csv"
        SaveFileDialog1.ShowDialog()
        GuardeEnArchivo(ListViewACsv(lstreportes, True), SaveFileDialog1.FileName, True)
    End Sub



    Private Sub PanelCabecera_Paint(sender As Object, e As PaintEventArgs) Handles PanelCabecera.Paint

    End Sub
End Class