Public Class ReportesMes
    Dim con As New conexion
    Dim intTarjeta As Integer = 2
    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Me.Close()
    End Sub

    Private Sub ReportesMes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.VisualizarRortes(lstreportes, Format(Now.Date, "yyyy-MM-dd"), Format(Now.Date, "yyyy-MM-dd"), 1, txtTotal, , , 2)
    End Sub

    Private Sub lstreportes_MouseClick(sender As Object, e As MouseEventArgs) Handles lstreportes.MouseClick
        If lstreportes.SelectedItems.Count > 0 Then
            Dim strId As String = ""
            Dim strCedula As String = ""
            Dim intValor As Integer = -1
            Principal.intValidar = 6
            Dim valide As New VALIDAR
            valide.ShowDialog()
            strId = lstreportes.SelectedItems(0).Text
            strCedula = lstreportes.SelectedItems(0).SubItems(1).Text

            intValor = lstreportes.SelectedItems(0).SubItems(4).Text

            If Principal.booEliminarDetalle = True Then
                Dim res = MessageBox.Show("Esta seguro de eliminar la factura '" & strId & "' ", "Informacion Del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If res = Windows.Forms.DialogResult.Yes Then
                    Dim fechaantigua = DateAdd(DateInterval.Day, -1, Now.Date)
                    con.registreDatos("DELETE FROM detalles where id='" & strId & "' ; UPDATE PAGO set fecha_corte='" & Format(fechaantigua, "yyyy-MM-dd") & "' where cedula='" & strCedula & "'")
                    ElimineValorCaja(intValor)
                    MessageBox.Show("la factura  se Elimino correctamente", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Principal.booEliminarDetalle = False
                Else : Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub lstreportes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstreportes.SelectedIndexChanged

    End Sub
    Private Sub fhasta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles fdesde.KeyPress
        If Asc(e.KeyChar) = 13 Then
            buscardatos()
        End If
    End Sub
    Private Sub fdesde_KeyPress(sender As Object, e As KeyPressEventArgs) Handles fdesde.KeyPress
        If Asc(e.KeyChar) = 13 Then
            buscardatos()
        End If
    End Sub

    Public Sub buscardatos()
        If chkTarjeta.Checked Then
            intTarjeta = 1
        Else : intTarjeta = 2
        End If
        Dim fecha1 As Date = fdesde.Value.Date
        Dim fecha2 As Date = fhasta.Value.Date
        con.VisualizarRortes(lstreportes, Format(fecha1, "yyyy-MM-dd"), Format(fecha2, "yyyy-MM-dd"), 1, txtTotal, , , intTarjeta)

    End Sub

    Private Sub chkTarjeta_CheckedChanged(sender As Object, e As EventArgs) Handles chkTarjeta.CheckedChanged
        buscardatos()
    End Sub

    Private Sub fdesde_ValueChanged(sender As Object, e As EventArgs) Handles fdesde.ValueChanged

    End Sub
End Class