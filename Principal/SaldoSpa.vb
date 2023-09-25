Public Class SaldoSpa
    Dim con As New conexion

    Private Sub SaldosPA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.VisualizarRortes(lstreportes, Format(Now, "yyyy-MM-dd"), Format(Now, "yyyy-MM-dd"), 200, txtTotal, , , , 3)
        colorBarras(PanelCabecera)
    End Sub

    Private Sub lstreportes_Click(sender As Object, e As EventArgs) Handles lstreportes.Click
        Dim factura As Integer = lstreportes.SelectedItems(0).Text
        Dim saldo As Integer = lstreportes.SelectedItems(0).SubItems(5).Text
        Dim strCadena As String
        Dim intAbonoNuevo As Integer = InputBox("El saldo es de '" & saldo & "' pesos. Escriba el valor a abonar", "Mensaje del Sistema")
        If Not IsNumeric(intAbonoNuevo) Then : MessageBox.Show("Debe ingresar Una cantidad", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
        End If
        Dim res = MessageBox.Show("Confirmar abono de  " & intAbonoNuevo & " pesos ", "Informacion Del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If res = Windows.Forms.DialogResult.Yes Then
            strCadena = "INSERT INTO cuenta_cliente(cuencli_idfactura,cuencli_valorabono) values ('" & factura & "','" & intAbonoNuevo & "') "
            registreMovimiento(2, 0, intAbonoNuevo, Principal.intidusuario, 2)
            If con.registreDatos(strCadena) Then
                MessageBox.Show("El abono fue registrado exitosamente", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                con.VisualizarRortes(lstreportes, Format(Now, "yyyy-MM-dd"), Format(Now, "yyyy-MM-dd"), 200, txtTotal, , , , 3)
            End If
        End If
    End Sub

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Me.Close()
    End Sub

    Private Sub lstreportes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstreportes.SelectedIndexChanged

    End Sub
End Class