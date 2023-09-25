Imports System.IO

Public Class MensajesWhatsap

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        Dim id As String = "wdRlPuJXHUeuINSiJBjkl01BVVJJQ0lPNTkwX2F0X0hPVE1BSUxfZG90X0NPTQ=="
        Dim strTelefono As String = txtCelular.Text
        Dim strmensaje As String = txtMensaje.Text

        Try
            Dim url As String = "https://niceapi.net/"
            Dim solicitud As System.Net.HttpWebRequest = CType(System.Net.WebRequest.Create(url), System.Net.HttpWebRequest)
            solicitud.Method = "POST"
            solicitud.ContentType = "application/x-www-for-urlencoded"
            solicitud.Headers.Add("X-APIID", id)
            solicitud.Headers.Add("X-APIMobile", strTelefono)

            Using streamOut As New StreamWriter(solicitud.GetRequestStream())
                streamOut.Write(strmensaje)
            End Using

            Using streamIn As New StreamReader(solicitud.GetResponse().GetResponseStream())
                Console.WriteLine(streamIn.ReadToEnd)
            End Using

            MessageBox.Show("Mensaje Enviado")
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

    End Sub
End Class