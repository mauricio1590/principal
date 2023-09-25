Public Class SaldoVentas
    Dim con As New conexion
    Private Sub SaldoVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargardatos()
        colorBarras(PanelCabecera)
    End Sub

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Me.Close()
    End Sub

    Private Sub lstreportes_MouseClick(sender As Object, e As MouseEventArgs) Handles lstreportes.MouseClick
        Dim factura As Integer = lstreportes.SelectedItems(0).Text
        Dim saldo As Integer = lstreportes.SelectedItems(0).SubItems(3).Text
        Dim strCadena As String
        Dim strcadena1 As String
        Dim intAbonoNuevo As Integer = InputBox("El saldo es de '" & saldo & "' pesos. Escriba el valor a abonar", "Mensaje del Sistema")
        If Not IsNumeric(intAbonoNuevo) Then : MessageBox.Show("Debe ingresar Una cantidad", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
        End If
        Dim res = MessageBox.Show("Confirmar abono de  " & intAbonoNuevo & " pesos ", "Informacion Del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If res = Windows.Forms.DialogResult.Yes Then
            strCadena = "UPDATE saldoventa set saldo=" & (extraerSaldoId(factura) - intAbonoNuevo) & " WHERE id='" & factura & "';"
            strCadena1 = "INSERT INTO historialdesaldo(idcliente,saldo,abono,newsaldo)values ('" & extraerIdterceroporidsaldo(factura) & "','" & saldo & "','" & intAbonoNuevo & "','" & saldo - intAbonoNuevo & "');"
            registreMovimiento(2, 0, intAbonoNuevo, Principal.intidusuario, 1)
            If con.registreDatos(strCadena) Then
                con.registreDatos(strcadena1)
                con.registreDatos("delete from saldoventa where saldo=0")

                MessageBox.Show("El abono fue registrado exitosamente", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                con.VisualizarRortes(lstreportes, Format(Now, "yyyy-MM-dd"), Format(Now, "yyyy-MM-dd"), 200, txtTotal)
            End If
            cargardatos()
        End If

    End Sub

    Sub cargardatos()
        con.VisualizarRortes(lstreportes, Format(Now, "yyyy-MM-dd"), Format(Now, "yyyy-MM-dd"), 200, txtTotal)
    End Sub

    Private Sub lstreportes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstreportes.SelectedIndexChanged

    End Sub
End Class