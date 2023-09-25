Public Class EliminarSaldoMensualidad
    Dim con As New conexion
    Private Sub lstreportes_MouseClick(sender As Object, e As MouseEventArgs) Handles lstreportes.MouseClick
        If lstreportes.SelectedItems.Count > 0 Then
            Dim strId As String = ""
            Dim strCedula As String = ""
            Dim intValor As Integer = -1
            Principal.intValidar = 7
            Dim valide As New VALIDAR
            valide.ShowDialog()
            strCedula = lstreportes.SelectedItems(0).SubItems(1).Text
            strId = lstreportes.SelectedItems(0).Text
            If Principal.booEliminarDetalle = True Then
                Dim res = MessageBox.Show("Esta seguro de eliminar el Abono  de '" & strCedula & "' ", "Informacion Del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If res = Windows.Forms.DialogResult.Yes Then
                    con.registreDatos("DELETE FROM abonos where idabonos='" & strId & "'")
                    MessageBox.Show("El abono  se Elimino correctamente", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    con.VisualizarRortes(lstreportes, Format(Now, "yyyy-MM-dd"), Format(Now, "yyyy-MM-dd"), 2, txtTotal)
                    Principal.booEliminarDetalle = False
                Else : Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub EliminarSaldoMensualidad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.VisualizarRortes(lstreportes, Format(Now, "yyyy-MM-dd"), Format(Now, "yyyy-MM-dd"), 2, txtTotal)
        colorBarras(PanelCabecera)
    End Sub

    Private Sub lstreportes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstreportes.SelectedIndexChanged

    End Sub

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Me.Close()

    End Sub
End Class