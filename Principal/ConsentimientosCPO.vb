Public Class ConsentimientosCPO

    Dim PDF As Report 'reportes
    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Me.Close()
    End Sub

    Private Sub btn_hidroxiapatita_Click(sender As Object, e As EventArgs) Handles btn_hidroxiapatita.Click
        Dim img As Image = Image.FromFile(Principal.strunidad & ":\SISTEMGYM_DATOS\Logos\DRA JULIANA MENESES CIRUGIA PLASTICA OCULAR.jpg")
        Dim Datos As New CirugiaPlasticaOcularVO("Jhon Alexander Grisales Aillon",
                                                 "1092364918",
                                                 Principal.strunidad & ":\SISTEMGYM_DATOS\Logos\Firma_prueba.jpg",
                                                 Principal.strunidad & ":\SISTEMGYM_DATOS\Logos\Firma_prueba.jpg")

        PDF = New Report
        PDF.Consentimiento_DraJulianaMeneses_RADIESSE(img, "APLICACIÓN DE HIDROXIAPATITA DE CALCIO (RADIESSE)", Datos)
    End Sub

    Private Sub btn_toxinaBotulinica_Click(sender As Object, e As EventArgs) Handles btn_toxinaBotulinica.Click
        Dim img As Image = Image.FromFile(Principal.strunidad & ":\SISTEMGYM_DATOS\Logos\DRA JULIANA MENESES CIRUGIA PLASTICA OCULAR.jpg")
        Dim Datos As New CirugiaPlasticaOcularVO("Jhon Alexander Grisales Aillon",
                                                 "1092364918",
                                                 Principal.strunidad & ":\SISTEMGYM_DATOS\Logos\Firma_prueba.jpg",
                                                 Principal.strunidad & ":\SISTEMGYM_DATOS\Logos\Firma_prueba.jpg")

        PDF = New Report
        PDF.Consentimiento_TOXINA_BOTULINICA_A(img, "APLICACIÓN DE TOXINA BOTULÍNICA TIPO A EN CARA Y-O CUELLO", Datos)
    End Sub

    Private Sub btn_acidoL_Click(sender As Object, e As EventArgs) Handles btn_acidoL.Click
        Dim img As Image = Image.FromFile(Principal.strunidad & ":\SISTEMGYM_DATOS\Logos\DRA JULIANA MENESES CIRUGIA PLASTICA OCULAR.jpg")
        Dim Datos As New CirugiaPlasticaOcularVO("Jhon Alexander Grisales Aillon",
                                                 "1092364918",
                                                 Principal.strunidad & ":\SISTEMGYM_DATOS\Logos\Firma_prueba.jpg",
                                                 Principal.strunidad & ":\SISTEMGYM_DATOS\Logos\Firma_prueba.jpg")

        PDF = New Report
    End Sub

    Private Sub btn_hilosLisos_Click(sender As Object, e As EventArgs) Handles btn_hilosLisos.Click
        Dim img As Image = Image.FromFile(Principal.strunidad & ":\SISTEMGYM_DATOS\Logos\DRA JULIANA MENESES CIRUGIA PLASTICA OCULAR.jpg")
        Dim Datos As New CirugiaPlasticaOcularVO("Jhon Alexander Grisales Aillon",
                                                 "1092364918",
                                                 Principal.strunidad & ":\SISTEMGYM_DATOS\Logos\Firma_prueba.jpg",
                                                 Principal.strunidad & ":\SISTEMGYM_DATOS\Logos\Firma_prueba.jpg")

        PDF = New Report
        PDF.Consentimiento_POLIDIOXANONA(img, "HILOS LISOS DE POLIDIOXANONA (PDO)", Datos)
    End Sub

    Private Sub btn_hialuronidasa_Click(sender As Object, e As EventArgs) Handles btn_hialuronidasa.Click
        Dim img As Image = Image.FromFile(Principal.strunidad & ":\SISTEMGYM_DATOS\Logos\DRA JULIANA MENESES CIRUGIA PLASTICA OCULAR.jpg")
        Dim Datos As New CirugiaPlasticaOcularVO("Jhon Alexander Grisales Aillon",
                                                 "1092364918",
                                                 Principal.strunidad & ":\SISTEMGYM_DATOS\Logos\Firma_prueba.jpg",
                                                 Principal.strunidad & ":\SISTEMGYM_DATOS\Logos\Firma_prueba.jpg")

        PDF = New Report
        PDF.Consentimiento_HIALURONIDASA(img, "APLICACIÓN DE HIALURONIDASA PARA DEGRADACIÓN DE ÁCIDO HIALURÓNICO", Datos)
    End Sub

    Private Sub btn_espiculados_Click(sender As Object, e As EventArgs) Handles btn_espiculados.Click
        Dim img As Image = Image.FromFile(Principal.strunidad & ":\SISTEMGYM_DATOS\Logos\DRA JULIANA MENESES CIRUGIA PLASTICA OCULAR.jpg")
        Dim Datos As New CirugiaPlasticaOcularVO("Jhon Alexander Grisales Aillon",
                                                 "1092364918",
                                                 Principal.strunidad & ":\SISTEMGYM_DATOS\Logos\Firma_prueba.jpg",
                                                 Principal.strunidad & ":\SISTEMGYM_DATOS\Logos\Firma_prueba.jpg")

        PDF = New Report
        PDF.Consentimiento_HILOS_ESPICULADOS_POLIDIOXANONA(img, "APLICACIÓN DE HILOS ESPICULADOS DE POLIDIOXANONA (PDO)", Datos)
    End Sub

    Private Sub btn_acidoReticulado_Click(sender As Object, e As EventArgs) Handles btn_acidoReticulado.Click
        Dim img As Image = Image.FromFile(Principal.strunidad & ":\SISTEMGYM_DATOS\Logos\DRA JULIANA MENESES CIRUGIA PLASTICA OCULAR.jpg")
        Dim Datos As New CirugiaPlasticaOcularVO("Jhon Alexander Grisales Aillon",
                                                 "1092364918",
                                                 Principal.strunidad & ":\SISTEMGYM_DATOS\Logos\Firma_prueba.jpg",
                                                 Principal.strunidad & ":\SISTEMGYM_DATOS\Logos\Firma_prueba.jpg")

        PDF = New Report
        PDF.Consentimiento_ACIDO_HIALURONICO_RETICULADO(img, "ACIDO HIALURONICO RETICULADO", Datos)
    End Sub

    Private Sub btn_hidroxiapatita_MouseMove(sender As Object, e As MouseEventArgs) Handles btn_hidroxiapatita.MouseMove

    End Sub

    Private Sub btn_hidroxiapatita_MouseHover(sender As Object, e As EventArgs) Handles btn_hidroxiapatita.MouseHover

    End Sub

    Private Sub btn_hidroxiapatita_MouseLeave(sender As Object, e As EventArgs) Handles btn_hidroxiapatita.MouseLeave
        btn_hidroxiapatita.Image = Image.FromFile(Principal.strunidad & ":\SISTEMGYM_DATOS\iconos\btn_consentimientos-3.png")
    End Sub

    Private Sub btn_hidroxiapatita_MouseEnter(sender As Object, e As EventArgs) Handles btn_hidroxiapatita.MouseEnter
        btn_hidroxiapatita.Image = Image.FromFile(Principal.strunidad & ":\SISTEMGYM_DATOS\iconos\btn_consentimientos-3_.png")
    End Sub

    Private Sub btn_toxinaBotulinica_MouseEnter(sender As Object, e As EventArgs) Handles btn_toxinaBotulinica.MouseEnter
        btn_toxinaBotulinica.Image = Image.FromFile(Principal.strunidad & ":\SISTEMGYM_DATOS\iconos\btn_consentimientos-3_.png")
    End Sub

    Private Sub btn_toxinaBotulinica_MouseLeave(sender As Object, e As EventArgs) Handles btn_toxinaBotulinica.MouseLeave
        btn_toxinaBotulinica.Image = Image.FromFile(Principal.strunidad & ":\SISTEMGYM_DATOS\iconos\btn_consentimientos-3.png")
    End Sub

    Private Sub btn_acidoL_MouseEnter(sender As Object, e As EventArgs) Handles btn_acidoL.MouseEnter
        btn_acidoL.Image = Image.FromFile(Principal.strunidad & ":\SISTEMGYM_DATOS\iconos\btn_consentimientos-3_.png")
    End Sub

    Private Sub btn_acidoL_MouseLeave(sender As Object, e As EventArgs) Handles btn_acidoL.MouseLeave
        btn_acidoL.Image = Image.FromFile(Principal.strunidad & ":\SISTEMGYM_DATOS\iconos\btn_consentimientos-3.png")
    End Sub

    Private Sub btn_hilosLisos_MouseEnter(sender As Object, e As EventArgs) Handles btn_hilosLisos.MouseEnter
        btn_hilosLisos.Image = Image.FromFile(Principal.strunidad & ":\SISTEMGYM_DATOS\iconos\btn_consentimientos-3_.png")
    End Sub

    Private Sub btn_hilosLisos_MouseLeave(sender As Object, e As EventArgs) Handles btn_hilosLisos.MouseLeave
        btn_hilosLisos.Image = Image.FromFile(Principal.strunidad & ":\SISTEMGYM_DATOS\iconos\btn_consentimientos-3.png")
    End Sub

    Private Sub btn_hialuronidasa_MouseEnter(sender As Object, e As EventArgs) Handles btn_hialuronidasa.MouseEnter
        btn_hialuronidasa.Image = Image.FromFile(Principal.strunidad & ":\SISTEMGYM_DATOS\iconos\btn_consentimientos-3_.png")
    End Sub

    Private Sub btn_hialuronidasa_MouseLeave(sender As Object, e As EventArgs) Handles btn_hialuronidasa.MouseLeave
        btn_hialuronidasa.Image = Image.FromFile(Principal.strunidad & ":\SISTEMGYM_DATOS\iconos\btn_consentimientos-3.png")
    End Sub

    Private Sub btn_espiculados_MouseEnter(sender As Object, e As EventArgs) Handles btn_espiculados.MouseEnter
        btn_espiculados.Image = Image.FromFile(Principal.strunidad & ":\SISTEMGYM_DATOS\iconos\btn_consentimientos-3_.png")
    End Sub

    Private Sub btn_espiculados_MouseLeave(sender As Object, e As EventArgs) Handles btn_espiculados.MouseLeave
        btn_espiculados.Image = Image.FromFile(Principal.strunidad & ":\SISTEMGYM_DATOS\iconos\btn_consentimientos-3.png")
    End Sub

    Private Sub btn_acidoReticulado_MouseHover(sender As Object, e As EventArgs) Handles btn_acidoReticulado.MouseHover

    End Sub

    Private Sub btn_acidoReticulado_MouseLeave(sender As Object, e As EventArgs) Handles btn_acidoReticulado.MouseLeave
        btn_acidoReticulado.Image = Image.FromFile(Principal.strunidad & ":\SISTEMGYM_DATOS\iconos\btn_consentimientos-3.png")
    End Sub

    Private Sub btn_acidoReticulado_MouseEnter(sender As Object, e As EventArgs) Handles btn_acidoReticulado.MouseEnter
        btn_acidoReticulado.Image = Image.FromFile(Principal.strunidad & ":\SISTEMGYM_DATOS\iconos\btn_consentimientos-3_.png")
    End Sub
End Class