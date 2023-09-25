Public Class ClientesPorVencer
    Dim con As New conexion
    Dim intTarjeta As Integer = 2
    Private Sub ClientesPorVencer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        buscardatos()

    End Sub
    Public Sub buscardatos()

        Dim fecha1 As Date = fdesde.Value.Date
        Dim fecha2 As Date = fhasta.Value.Date
        con.VisualizarRortes(lstreportes, Format(fecha1, "yyyy-MM-dd"), Format(fecha2, "yyyy-MM-dd"), 4, txtTotal, , , )

    End Sub
    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Me.Close()
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
End Class