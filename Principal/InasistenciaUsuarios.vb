Public Class InasistenciaUsuarios
    Dim con As New conexion
    Private Sub fdesde_KeyPress(sender As Object, e As KeyPressEventArgs) Handles fdesde.KeyPress
        If Asc(e.KeyChar) = 13 Then
            buscardatos()
        End If
    End Sub

    Public Sub buscardatos()

        Dim fecha1 As Date = fdesde.Value.Date
        Dim fecha2 As Date = fdesde.Value.Date
        con.VisualizarRortes(lstreportes, Format(fecha1, "yyyy-MM-dd"), Format(fecha2, "yyyy-MM-dd"), 502, txtTotal, , , )

    End Sub

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Me.Close()
    End Sub

    Private Sub InasistenciaUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtExportar_Click(sender As Object, e As EventArgs) Handles txtExportar.Click
        Dim SaveFileDialog1 As New Windows.Forms.SaveFileDialog
        SaveFileDialog1.DefaultExt = "*.csv"
        SaveFileDialog1.FileName = ""
        SaveFileDialog1.Filter = "Archivos CSV de Excel (*.csv|*.csv"
        SaveFileDialog1.ShowDialog()
        GuardeEnArchivo(ListViewACsv(lstreportes, True), SaveFileDialog1.FileName, True)
    End Sub
End Class