Public Class Cumpleaños
    Dim con As New conexion
    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Me.Close()
    End Sub

    Private Sub Cumpleaños_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.VisualizarRortes(lstreportes, Format(Now.Date, "yyyy-MM-dd"), Format(Now.Date, "yyyy-MM-dd"), 18, txtTotal, , , 2)
    End Sub
End Class