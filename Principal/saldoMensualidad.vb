Public Class SaldoMensualidad
    Dim con As New conexion
    Dim imp As New Imprimir
    Private Sub SaldoVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.VisualizarRortes(lstreportes, Format(Now, "yyyy-MM-dd"), Format(Now, "yyyy-MM-dd"), 2, txtTotal)
        colorBarras(PanelCabecera)
    End Sub

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Me.Close()
    End Sub

    Private Sub lstreportes_MouseClick(sender As Object, e As MouseEventArgs) Handles lstreportes.MouseClick
        Dim cedula As String = lstreportes.SelectedItems(0).SubItems(1).Text
        Dim strId As String = lstreportes.SelectedItems(0).Text
        Dim nombre As String = lstreportes.SelectedItems(0).SubItems(1).Text
        Dim saldo As Integer = lstreportes.SelectedItems(0).SubItems(4).Text
        Dim strCadena As String
        Dim intAbonoNuevo As Integer = InputBox("El saldo es de '" & saldo & "' pesos. Escriba el valor a abonar", "Mensaje del Sistema")
        If Not IsNumeric(intAbonoNuevo) Then : MessageBox.Show("Debe ingresar Una cantidad", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub : End If
        If intAbonoNuevo > saldo Then : MessageBox.Show("el abono es Mayor al Saldo", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub : End If
        Dim res = MessageBox.Show("Confirmar abono de  " & intAbonoNuevo & " pesos ", "Informacion Del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If res = Windows.Forms.DialogResult.Yes Then
            strCadena = "UPDATE abonos set abono=(abono +" & intAbonoNuevo & ") ,saldo= (saldo -" & intAbonoNuevo & "),tipo=(tipo+1) WHERE idabonos='" & strId & "' "
            registreMovimiento(2, 0, intAbonoNuevo, Principal.intidusuario, 0)
            If con.registreDatos(strCadena) Then
                '  MessageBox.Show("El abono fue registrado exitosamente", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                con.registreDatos("INSERT INTO detalles (cedula,fecha_pago,fecha_fin,tiempo,valor)VALUES " & vbCrLf &
                            "('" & cedula & "',CURRENT_DATE,'" & Now.Date & "','SALDO','" & intAbonoNuevo & "')")
                Dim res2 = MessageBox.Show("Desea Imprimir la factura ", "Informacion Del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If res2 = Windows.Forms.DialogResult.Yes Then
                    imp.GenereImpresion(nombre, cedula, "Saldo Pendiente", intAbonoNuevo)
                End If

                con.registreDatos("UPDATE abonos SET dia=5 WHERE cedula='" & cedula & "'")

                con.registreDatos("DELETE FROM abonos WHERE saldo =0")
                con.VisualizarRortes(lstreportes, Format(Now, "yyyy-MM-dd"), Format(Now, "yyyy-MM-dd"), 2, txtTotal)
            End If
        End If

    End Sub

    Private Sub lstreportes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstreportes.SelectedIndexChanged

    End Sub
End Class