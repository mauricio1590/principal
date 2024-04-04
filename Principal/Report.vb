'Imports iTextSharp.text.Table
Imports System.IO
Imports System.Text
Imports iTextSharp.text
Imports iTextSharp.text.pdf
'Imports WebSupergoo.ABCpdf11.Elements
'Imports Element = iTextSharp.text.Element
'Imports DocumentFormat.OpenXml.Bibliography
'Imports DocumentFormat.OpenXml.Drawing
'Imports System.Buffers
'Imports DocumentFormat.OpenXml.Spreadsheet
'Imports DocumentFormat.OpenXml.InkML

'Imports System.Net.Mime.MediaTypeNames

Public Class Report

    Dim rutaDirectorio As String = Principal.strunidad & ":\sistemgym_datos\informes"
    Dim unidad As String = Principal.strunidad
    Dim docPDF As New Document()
    Dim fotoPDF As iTextSharp.text.Image
    Dim pdfw As iTextSharp.text.pdf.PdfWriter
    Dim borde As Chunk
    Dim ruta As String = ""
    Dim x, y As Integer


    Public Sub FichaFacialPDF(Logo As Bitmap, Titulo As Bitmap, Datos As FichaFacialVO, Anatomia As Bitmap)

        crearDirectorio()
        ruta = rutaDirectorio & "\\FichaFacial " & Datos.Nombre1 & ".pdf"
        If File.Exists(ruta) Then
            File.Delete(ruta)
        End If
        pdfw = PdfWriter.GetInstance(docPDF, New FileStream(ruta, FileMode.Create))
        docPDF.SetPageSize(PageSize.A4)
        'docPDF.SetMargins(70.8661F, 70.8661F, 85.0394F, 85.0394F)
        'docPDF.SetPageSize(New Rectangle(612.0F, 792.0F).Rotate) 'tamaño de la página
        docPDF.SetMargins(28.34F, 28.34F, 10.0F, 10.0F) 'CONVERTIR CM A PUNTOS
        'docPDF.SetMargins(20.0F, 20.0F, 0.0F, 0.0F) 'CONVERTIR CM A PUNTOS
        docPDF.Open()


        'y -= 150
        Dim fuente As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.TIMES, 16, iTextSharp.text.Font.BOLD).BaseFont, 16)
        Dim fuente14 As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.TIMES, 12).BaseFont, 12)
        Dim fuenteTexto As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.TIMES, 12).BaseFont, 12)
        'Dim textoRojo As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.TIMES, 9, New BaseColor(255, 0, 0)).BaseFont, 9)
        Dim textoRojo = FontFactory.GetFont(FontFactory.TIMES_BOLD, 9, BaseColor.RED)
        Dim textoblanco = FontFactory.GetFont(FontFactory.TIMES, 18, BaseColor.WHITE)
        Dim anchoSINOAF As Integer = 63 'ANCHO SI_NO ACTIVIDAD FISICA
        Dim altoSINOAF As Integer = 15 'ALTO SI_NO ACTIVIDAD FISICA
        Dim anchoSINOIP As Integer = 42 'ANCHO SI_NO INFORME PATOLOGICO
        Dim altoSINOIP As Integer = 10 'ALTO SI_NO INFORME PATOLOGICO
        Dim anchoSINOCA As Integer = 42 'ANCHO SI_NO CUTIS ANATOMIA FACIAL
        Dim altoSINOCA As Integer = 10 'ALTO SI_NO CUTIS ANATOMIA FACIAL


        'LOGO
        fotoPDF = iTextSharp.text.Image.GetInstance(Logo, BaseColor.WHITE)
        fotoPDF.ScaleAbsolute(130, 60)

        Dim cb As PdfContentByte
        Dim colorBordes As New BaseColor(201, 128, 138) 'COLOR DE BORDES
        'BORDE SUPERIOR
        'borde = New Chunk(New iTextSharp.text.pdf.draw.LineSeparator(30.0F, 110.0F, New BaseColor(220, 120, 170), Element.ALIGN_JUSTIFIED_ALL, -1))
        'docPDF.Add(borde)
        cb = pdfw.DirectContent
        cb.MoveTo(841.89F, 841.89F)
        cb.LineTo(0, 841.89F)
        cb.SetLineWidth(30)
        'cb.SetCMYKColorFill(23, 30, 40, 20)
        cb.SetColorStroke(colorBordes)
        cb.ClosePathStroke()

        'BORDE IZQUIERDO
        cb = pdfw.DirectContent
        cb.MoveTo(0, 0)
        cb.LineTo(0, 841.89F)
        cb.SetLineWidth(30)
        'cb.SetCMYKColorFill(23, 30, 40, 20)
        cb.SetColorStroke(colorBordes)
        cb.ClosePathStroke()

        'BORDE DERECHO
        cb = pdfw.DirectContent
        cb.MoveTo(595.0F, 0)
        cb.LineTo(595.0F, 841.89F)
        cb.SetLineWidth(30)
        'cb.SetCMYKColorFill(23, 30, 40, 20)
        cb.SetColorStroke(colorBordes)
        cb.ClosePathStroke()

        'BORDE INFERIOR
        cb = pdfw.DirectContent
        cb.MoveTo(0, 0)
        cb.LineTo(595.0F, 0)
        cb.SetLineWidth(30)
        'cb.SetCMYKColorFill(23, 30, 40, 20)
        cb.SetColorStroke(colorBordes)
        cb.ClosePathStroke()


        'docPDF.Add(New Phrase(" "))
        'docPDF.Add(New Phrase(" "))

        Dim tabla As New PdfPTable(New Single() {80.0F, 20.0F})
        tabla.WidthPercentage = 100.0F
        Dim cell As New PdfPCell(New Phrase("", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_RIGHT,
            .Padding = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("N°: " + Datos.NExpediente1, fuente)) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_RIGHT,
            .PaddingTop = 10,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        'TABLA
        tabla = New PdfPTable(New Single() {30.0F, 40.0F, 30.0F})
        tabla.WidthPercentage = 100.0F
        'LOGO
        cell = New PdfPCell(fotoPDF) With { 'LOGO
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .Padding = 10,
            .Border = 0,
            .Rowspan = 2
        }
        tabla.AddCell(cell)

        'TITULO
        fotoPDF = iTextSharp.text.Image.GetInstance(Titulo, BaseColor.WHITE)
        fotoPDF.ScaleAbsolute(185, 55)
        cell = New PdfPCell(fotoPDF) With { 'TITULO
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Padding = 10,
            .Border = 0,
            .Rowspan = 2
        }
        tabla.AddCell(cell)


        'FIRMA PROFESIONAL
        cell = New PdfPCell(New Phrase("Profesional", fuente14)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        fotoPDF = iTextSharp.text.Image.GetInstance(Datos.Profesional1) 'FIRMA DEL PROFESIONAL
        fotoPDF.ScaleAbsolute(140, 24)
        fotoPDF.SetAbsolutePosition(415, 733)
        cb.AddImage(fotoPDF)

        cb = pdfw.DirectContent
        cb.SetLineWidth(3)
        cb.MoveTo(410, 760)
        cb.LineTo(560, 760)
        cb.LineTo(560, 730)
        cb.LineTo(410, 730)
        cb.ClosePathStroke()
        cb.SetColorStroke(colorBordes)

        docPDF.Add(tabla)

        'docPDF.Add(New Phrase(" "))

        Dim padding1 As Integer = 5 'MARGEN ENTRE CAJAS DE TEXTO
        Dim padding2 As Integer = 5 'MARGEN ENTRE CHECK
        Dim colorTxt As New BaseColor(245, 243, 248) 'COLOR CAJA DE TEXTO

        '---------------------------------LINEA DATOS GENERALES---------------------------
        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F
        cell = New PdfPCell(New Phrase("Datos Generales", textoblanco)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .BackgroundColor = colorBordes,
            .Border = 0,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        'SECCIÓN DATOS GENERALES
        tabla = New PdfPTable(New Single() {50.0F, 50.0F})
        tabla.WidthPercentage = 100.0F
        'columna 1
        cell = New PdfPCell(New Phrase("Nombre: " + Datos.Nombre1, fuenteTexto)) With {
            .Rowspan = 4,
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .Border = 0,
            .PaddingTop = padding1
        }
        tabla.AddCell(cell)

        'cb = pdfw.DirectContent
        'cb.SetColorStroke(colorTxt)
        'cb.MoveTo(90, 710)
        'cb.LineTo(280, 710)
        'cb.LineTo(280, 693)
        'cb.LineTo(90, 693)
        'cb.Fill()


        'columna 2
        cell = New PdfPCell(New Phrase("Correo: " + Datos.Correo1, fuenteTexto)) With {
            .Rowspan = 4,
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .Border = 0,
            .PaddingTop = padding1
        }
        tabla.AddCell(cell)



        'FILA 2 COLUMNA 1 (DOMICILIO)
        cell = New PdfPCell(New Phrase("Domicilio: " + Datos.Domicilio1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .Border = 0,
            .PaddingTop = padding1
        }
        tabla.AddCell(cell)

        'cb = pdfw.DirectContent
        'cb.SetColorStroke(colorTxt)
        'cb.MoveTo(100, 700)
        'cb.LineTo(280, 700)
        'cb.LineTo(280, 683)
        'cb.LineTo(100, 683)
        'cb.Fill()

        'FILA 2 COLUMNA 2 (TELEFONO)
        cell = New PdfPCell(New Phrase("Telefono: " + Datos.Telefono1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .Border = 0,
            .PaddingTop = padding1
        }
        tabla.AddCell(cell)

        'FILA 3 COLUMNA 1 (EDAD)
        cell = New PdfPCell(New Phrase("Edad: " + Datos.Edad1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .Border = 0,
            .PaddingTop = padding1
        }
        tabla.AddCell(cell)

        'FILA 3 COLUMNA 2 (ESTADO CIVIL)
        cell = New PdfPCell(New Phrase("Estado Civil: " + Datos.EstadoCivil1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .Border = 0,
            .PaddingTop = padding1
        }
        tabla.AddCell(cell)

        'FILA 4 COLUMNA 1 (Fecha de nacimiento)
        cell = New PdfPCell(New Phrase("Fecha de Nacimiento: " + Datos.FechaNacimiento1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .Border = 0,
            .PaddingTop = padding1,
            .PaddingBottom = 10
        }
        tabla.AddCell(cell)

        'FILA 4 COLUMNA 2 (MOTIVO CONSULTA)
        cell = New PdfPCell(New Phrase("Motivo de Consulta: " + Datos.MotivoConsulta1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .Border = 0,
            .PaddingTop = padding1
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        'docPDF.Add(New Phrase(" "))

        '---------------------------------LINEA INFORME PATOLÓGICO---------------------------
        tabla = New PdfPTable(New Single() {100.0F}) With {
            .WidthPercentage = 100.0F
        }
        cell = New PdfPCell(New Phrase("Informe Patológico", textoblanco)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .BackgroundColor = colorBordes,
            .Border = 0,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        'docPDF.Add(New Phrase(""))

        'DATOS INFORME PATOLÓGICO
        tabla = New PdfPTable(New Single() {33.3F, 33.3F, 33.3F}) With {
            .WidthPercentage = 100.0F
        }
        cell = New PdfPCell(New Phrase("¿Enfermedades Cardiacas?", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .PaddingTop = padding1
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Enfermedades Circulatorias?", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .PaddingTop = padding1
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Presenta Alergias?", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .PaddingTop = padding1
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {10.0F, 23.3F, 10.0F, 23.3F, 10.0F, 23.3F}) With {
            .WidthPercentage = 100.0F
        }

        fotoPDF = iTextSharp.text.Image.GetInstance(Preguntar_SiNo(Datos.PCardiacas1))
        fotoPDF.ScaleAbsolute(anchoSINOIP, altoSINOIP)

        'FILA1
        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_RIGHT,
            .Border = 0,
            .PaddingTop = padding2
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(Datos.CCardiacas1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_MIDDLE,
            .Border = 0,
            .BorderWidthBottom = 1,
            .PaddingTop = padding2
        }
        tabla.AddCell(cell)

        fotoPDF = iTextSharp.text.Image.GetInstance(Preguntar_SiNo(Datos.PCirculatorias1))
        fotoPDF.ScaleAbsolute(anchoSINOIP, altoSINOIP)
        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_RIGHT,
            .Border = 0,
            .PaddingTop = padding2
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(Datos.CCirculatorias1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_MIDDLE,
            .Border = 0,
            .BorderWidthBottom = 1,
            .PaddingTop = padding2
        }
        tabla.AddCell(cell)

        fotoPDF = iTextSharp.text.Image.GetInstance(Preguntar_SiNo(Datos.PAlergias1))
        fotoPDF.ScaleAbsolute(anchoSINOIP, altoSINOIP)
        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_RIGHT,
            .Border = 0,
            .PaddingTop = padding2
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(Datos.CAlergias1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_MIDDLE,
            .Border = 0,
            .BorderWidthBottom = 1,
            .PaddingTop = padding2
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {33.3F, 33.3F, 33.3F}) With {
            .WidthPercentage = 100.0F
        }
        cell = New PdfPCell(New Phrase("¿Enfermedades Renales?", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .PaddingTop = padding1
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Problemas de Azucar?", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .PaddingTop = padding1
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Sufre Convulsiones?", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .PaddingTop = padding1
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {10.0F, 23.3F, 10.0F, 23.3F, 10.0F, 23.3F}) With {
            .WidthPercentage = 100.0F
        }
        'FILA2
        fotoPDF = iTextSharp.text.Image.GetInstance(Preguntar_SiNo(Datos.PRenales1))
        fotoPDF.ScaleAbsolute(anchoSINOIP, altoSINOIP)
        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_RIGHT,
            .Border = 0,
            .PaddingTop = padding2
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_MIDDLE,
            .Border = 0,
            .BorderWidthBottom = 1,
            .PaddingTop = padding2
        }
        tabla.AddCell(cell)
        fotoPDF = iTextSharp.text.Image.GetInstance(Preguntar_SiNo(Datos.PAzucar1))
        fotoPDF.ScaleAbsolute(anchoSINOIP, altoSINOIP)
        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_RIGHT,
            .Border = 0,
            .PaddingTop = padding2
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_MIDDLE,
            .Border = 0,
            .BorderWidthBottom = 1,
            .PaddingTop = padding2
        }
        tabla.AddCell(cell)
        fotoPDF = iTextSharp.text.Image.GetInstance(Preguntar_SiNo(Datos.PConvulsiones1))
        fotoPDF.ScaleAbsolute(anchoSINOIP, altoSINOIP)
        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_RIGHT,
            .Border = 0,
            .PaddingTop = padding2
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_MIDDLE,
            .Border = 0,
            .BorderWidthBottom = 1,
            .PaddingTop = padding2
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {33.3F, 33.3F, 33.3F}) With {
            .WidthPercentage = 100.0F
        }
        cell = New PdfPCell(New Phrase("¿Enfermedades Digestivas?", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .PaddingTop = padding1
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Problemas de Presión?", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .PaddingTop = padding1
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Cremas de uso Actual?", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .PaddingTop = padding1
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {10.0F, 23.3F, 10.0F, 23.3F, 10.0F, 23.3F}) With {
            .WidthPercentage = 100.0F
        }
        'FILA 3
        fotoPDF = iTextSharp.text.Image.GetInstance(Preguntar_SiNo(Datos.PDigestvas1))
        fotoPDF.ScaleAbsolute(anchoSINOIP, altoSINOIP)
        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_RIGHT,
            .Border = 0,
            .PaddingTop = padding2
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(Datos.CDigestivas1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_MIDDLE,
            .Border = 0,
            .BorderWidthBottom = 1,
            .PaddingTop = padding2
        }
        tabla.AddCell(cell)
        fotoPDF = iTextSharp.text.Image.GetInstance(Preguntar_SiNo(Datos.PPresion1))
        fotoPDF.ScaleAbsolute(anchoSINOIP, altoSINOIP)
        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_RIGHT,
            .Border = 0,
            .PaddingTop = padding2
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(Datos.CPresion1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_MIDDLE,
            .Border = 0,
            .BorderWidthBottom = 1,
            .PaddingTop = padding2
        }
        tabla.AddCell(cell)
        fotoPDF = iTextSharp.text.Image.GetInstance(Preguntar_SiNo(Datos.PCremas1))
        fotoPDF.ScaleAbsolute(anchoSINOIP, altoSINOIP)
        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_RIGHT,
            .Border = 0,
            .PaddingTop = padding2
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(Datos.CCremas1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_MIDDLE,
            .Border = 0,
            .BorderWidthBottom = 1,
            .PaddingTop = padding2
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {33.3F, 33.3F, 33.3F}) With {
            .WidthPercentage = 100.0F
        }
        cell = New PdfPCell(New Phrase("¿Utiliza lentes de Contacto?", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .PaddingTop = padding1
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Problemas en la piel?", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .PaddingTop = padding1
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Se ha realizado alguna cirugía?", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .PaddingTop = padding1
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {10.0F, 23.3F, 10.0F, 23.3F, 10.0F, 23.3F}) With {
            .WidthPercentage = 100.0F
        }

        'FILA4
        fotoPDF = iTextSharp.text.Image.GetInstance(Preguntar_SiNo(Datos.PLentes1))
        fotoPDF.ScaleAbsolute(anchoSINOIP, altoSINOIP)
        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_RIGHT,
            .Border = 0,
            .PaddingTop = padding2
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(Datos.CLentes1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_MIDDLE,
            .Border = 0,
            .BorderWidthBottom = 1,
            .PaddingTop = padding2
        }
        tabla.AddCell(cell)
        fotoPDF = iTextSharp.text.Image.GetInstance(Preguntar_SiNo(Datos.PPiel1))
        fotoPDF.ScaleAbsolute(anchoSINOIP, altoSINOIP)
        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_RIGHT,
            .Border = 0,
            .PaddingTop = padding2
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(Datos.CPiel1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_MIDDLE,
            .Border = 0,
            .BorderWidthBottom = 1,
            .PaddingTop = padding2
        }
        tabla.AddCell(cell)
        fotoPDF = iTextSharp.text.Image.GetInstance(Preguntar_SiNo(Datos.PCirugia1))
        fotoPDF.ScaleAbsolute(anchoSINOIP, altoSINOIP)
        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_RIGHT,
            .Border = 0,
            .PaddingTop = padding2
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(Datos.CCirugia1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_MIDDLE,
            .Border = 0,
            .BorderWidthBottom = 1,
            .PaddingTop = padding2
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {33.3F, 33.3F, 33.3F}) With {
            .WidthPercentage = 100.0F
        }
        cell = New PdfPCell(New Phrase("¿Posee implantes dentales?", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .PaddingTop = padding1
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Tiene alguna fractura facial?", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .PaddingTop = padding1
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Consume algún medicamento?", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .PaddingTop = padding1
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {10.0F, 23.3F, 10.0F, 23.3F, 10.0F, 23.3F}) With {
            .WidthPercentage = 100.0F
        }

        'FILA5
        fotoPDF = iTextSharp.text.Image.GetInstance(Preguntar_SiNo(Datos.PImplantes1))
        fotoPDF.ScaleAbsolute(anchoSINOIP, altoSINOIP)
        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_RIGHT,
            .Border = 0,
            .PaddingTop = padding2
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(Datos.CImplantes1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_MIDDLE,
            .Border = 0,
            .BorderWidthBottom = 1,
            .PaddingTop = padding2
        }
        tabla.AddCell(cell)
        fotoPDF = iTextSharp.text.Image.GetInstance(Preguntar_SiNo(Datos.PFractura1))
        fotoPDF.ScaleAbsolute(anchoSINOIP, altoSINOIP)
        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_RIGHT,
            .Border = 0,
            .PaddingTop = padding2
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(Datos.CFractura1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_MIDDLE,
            .Border = 0,
            .BorderWidthBottom = 1,
            .PaddingTop = padding2
        }
        tabla.AddCell(cell)
        fotoPDF = iTextSharp.text.Image.GetInstance(Preguntar_SiNo(Datos.PMedicamento1))
        fotoPDF.ScaleAbsolute(anchoSINOIP, altoSINOIP)
        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_RIGHT,
            .Border = 0,
            .PaddingTop = padding2
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(Datos.CMeicamento1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_MIDDLE,
            .Border = 0,
            .BorderWidthBottom = 1,
            .PaddingTop = padding2
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {40.0F, 60.0F}) With {
            .WidthPercentage = 100.0F
        }
        cell = New PdfPCell(New Phrase("¿Tratamientos dermatológicos?", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .Border = 0,
            .PaddingTop = padding1
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Observaciones", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .PaddingTop = padding1
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {10.0F, 25.0F, 5.0F, 60.0F}) With {
            .WidthPercentage = 100.0F
        }
        fotoPDF = iTextSharp.text.Image.GetInstance(Preguntar_SiNo(Datos.PTratamiento1))
        fotoPDF.ScaleAbsolute(anchoSINOIP, altoSINOIP)
        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_RIGHT,
            .Border = 0,
            .PaddingTop = padding2
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(Datos.CTratamiento1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_MIDDLE,
            .Border = 0,
            .BorderWidthBottom = 1,
            .PaddingTop = padding2
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_MIDDLE,
            .Border = 0,
            .PaddingTop = padding2
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(Datos.Observaciones1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_MIDDLE,
            .Border = 0,
            .BorderWidthBottom = 1,
            .PaddingTop = padding2
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        'docPDF.Add(New Phrase(" "))

        '---------------------------------LINEA CUTIS---------------------------
        tabla = New PdfPTable(New Single() {100.0F}) With {
            .WidthPercentage = 100.0F
        }
        cell = New PdfPCell(New Phrase(" ", textoblanco)) With {
            .Border = 0,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        '---------------------------------LINEA CUTIS---------------------------
        tabla = New PdfPTable(New Single() {50.0F, 50.0F}) With {
            .WidthPercentage = 100.0F
        }
        cell = New PdfPCell(New Phrase("Clase de Cutis", textoblanco)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .BackgroundColor = colorBordes,
            .Border = 0,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Anatomia Facial", textoblanco)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .BackgroundColor = colorBordes,
            .Border = 0,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {30.0F, 10.0F, 30.0F, 30.0F}) With {
                .WidthPercentage = 100.0F
            }
        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
                .VerticalAlignment = Element.ALIGN_CENTER,
                .HorizontalAlignment = Element.ALIGN_RIGHT,
                .Border = 0,
                .PaddingTop = padding1
            }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
                .VerticalAlignment = Element.ALIGN_CENTER,
                .HorizontalAlignment = Element.ALIGN_CENTER,
                .Border = 0,
                .PaddingTop = padding1
            }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("  Observaciones          " + Datos.ObservacionCutis1, fuenteTexto)) With {
                .VerticalAlignment = Element.ALIGN_CENTER,
                .HorizontalAlignment = Element.ALIGN_CENTER,
                .Border = 0,
                .PaddingTop = padding1,
                .Rowspan = 9
            }
        tabla.AddCell(cell)

        'IMAGEN
        fotoPDF = iTextSharp.text.Image.GetInstance(Anatomia, BaseColor.WHITE)
        fotoPDF.ScaleAbsolute(130, 150)

        cell = New PdfPCell(fotoPDF) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
                .HorizontalAlignment = Element.ALIGN_CENTER,
                .Border = 0,
                .PaddingTop = padding1,
                .Rowspan = 9
            }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Piel Seca", fuenteTexto)) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
             .HorizontalAlignment = Element.ALIGN_RIGHT,
                .Border = 0,
                .PaddingTop = padding1
            }
        tabla.AddCell(cell)

        'IMAGEN
        fotoPDF = iTextSharp.text.Image.GetInstance(Preguntar_SiNo(Datos.PPSeca1))
        fotoPDF.ScaleAbsolute(anchoSINOCA, altoSINOCA)
        cell = New PdfPCell(fotoPDF) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
                .HorizontalAlignment = Element.ALIGN_RIGHT,
                .Border = 0,
                .PaddingTop = padding1,
                .PaddingRight = padding1
            }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Piel Levemente Seca", fuenteTexto)) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
                .HorizontalAlignment = Element.ALIGN_RIGHT,
                .Border = 0,
                .PaddingTop = padding1
            }
        tabla.AddCell(cell)
        fotoPDF = iTextSharp.text.Image.GetInstance(Preguntar_SiNo(Datos.PPLeveSeca1))
        fotoPDF.ScaleAbsolute(anchoSINOCA, altoSINOCA)
        cell = New PdfPCell(fotoPDF) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
                .HorizontalAlignment = Element.ALIGN_RIGHT,
                .Border = 0,
                .PaddingTop = padding1,
                .PaddingRight = padding1
            }
        tabla.AddCell(cell)


        cell = New PdfPCell(New Phrase("Piel Medianamente Seca", fuenteTexto)) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
                .HorizontalAlignment = Element.ALIGN_RIGHT,
                .Border = 0,
                .PaddingTop = padding1
            }
        tabla.AddCell(cell)
        fotoPDF = iTextSharp.text.Image.GetInstance(Preguntar_SiNo(Datos.PPMedSeca1))
        fotoPDF.ScaleAbsolute(anchoSINOCA, altoSINOCA)
        cell = New PdfPCell(fotoPDF) With {
               .VerticalAlignment = Element.ALIGN_MIDDLE,
                .HorizontalAlignment = Element.ALIGN_RIGHT,
                .Border = 0,
                .PaddingTop = padding1,
                .PaddingRight = padding1
            }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Piel Muy Seca", fuenteTexto)) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
                .HorizontalAlignment = Element.ALIGN_RIGHT,
                .Border = 0,
                .PaddingTop = padding1
            }
        tabla.AddCell(cell)
        fotoPDF = iTextSharp.text.Image.GetInstance(Preguntar_SiNo(Datos.PPMuySeca1))
        fotoPDF.ScaleAbsolute(anchoSINOCA, altoSINOCA)
        cell = New PdfPCell(fotoPDF) With {
               .VerticalAlignment = Element.ALIGN_MIDDLE,
                .HorizontalAlignment = Element.ALIGN_RIGHT,
                .Border = 0,
                .PaddingTop = padding1,
                .PaddingRight = padding1
            }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Piel Grasa", fuenteTexto)) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
                .HorizontalAlignment = Element.ALIGN_RIGHT,
                .Border = 0,
                .PaddingTop = padding1
            }
        tabla.AddCell(cell)
        fotoPDF = iTextSharp.text.Image.GetInstance(Preguntar_SiNo(Datos.PPGrasa1))
        fotoPDF.ScaleAbsolute(anchoSINOCA, altoSINOCA)
        cell = New PdfPCell(fotoPDF) With {
               .VerticalAlignment = Element.ALIGN_MIDDLE,
                .HorizontalAlignment = Element.ALIGN_RIGHT,
                .Border = 0,
                .PaddingTop = padding1,
                .PaddingRight = padding1
            }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Piel Levemente Grasa", fuenteTexto)) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
                .HorizontalAlignment = Element.ALIGN_RIGHT,
                .Border = 0,
                .PaddingTop = padding1
            }
        tabla.AddCell(cell)
        fotoPDF = iTextSharp.text.Image.GetInstance(Preguntar_SiNo(Datos.PPLeveGrasa1))
        fotoPDF.ScaleAbsolute(anchoSINOCA, altoSINOCA)
        cell = New PdfPCell(fotoPDF) With {
               .VerticalAlignment = Element.ALIGN_MIDDLE,
                .HorizontalAlignment = Element.ALIGN_RIGHT,
                .Border = 0,
                .PaddingTop = padding1,
                .PaddingRight = padding1
            }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Piel Medianamente Grasa", fuenteTexto)) With {
               .VerticalAlignment = Element.ALIGN_MIDDLE,
                .HorizontalAlignment = Element.ALIGN_RIGHT,
                .Border = 0,
                .PaddingTop = padding1
            }
        tabla.AddCell(cell)
        fotoPDF = iTextSharp.text.Image.GetInstance(Preguntar_SiNo(Datos.PPMedGrasa1))
        fotoPDF.ScaleAbsolute(anchoSINOCA, altoSINOCA)
        cell = New PdfPCell(fotoPDF) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
                .HorizontalAlignment = Element.ALIGN_RIGHT,
                .Border = 0,
                .PaddingTop = padding1,
                .PaddingRight = padding1
            }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Piel Muy Grasa", fuenteTexto)) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
                .HorizontalAlignment = Element.ALIGN_RIGHT,
                .Border = 0,
                .PaddingTop = padding1
            }
        tabla.AddCell(cell)
        fotoPDF = iTextSharp.text.Image.GetInstance(Preguntar_SiNo(Datos.PPMuyGrasa1))
        fotoPDF.ScaleAbsolute(anchoSINOCA, altoSINOCA)
        cell = New PdfPCell(fotoPDF) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
                .HorizontalAlignment = Element.ALIGN_RIGHT,
                .Border = 0,
                .PaddingTop = padding1,
                .PaddingRight = padding1
            }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Observaciones generales", fuenteTexto)) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
                .HorizontalAlignment = Element.ALIGN_RIGHT,
                .Border = 0,
                .PaddingTop = padding1
            }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        docPDF.Add(New Phrase(" ", fuenteTexto))

        '---------------------------------ACTIVIDAD FISICA---------------------------
        tabla = New PdfPTable(New Single() {100.0F}) With {
            .WidthPercentage = 100.0F
        }
        cell = New PdfPCell(New Phrase("Actividad Fisica", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .PaddingTop = 0,
            .PaddingBottom = padding1,
            .BorderWidthBottom = 1
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)



        tabla = New PdfPTable(New Single() {25.0F, 25.0F, 25.0F, 25.0F}) With {
            .WidthPercentage = 100.0F
        }

        cell = New PdfPCell(New Phrase("Desvitalizada", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .PaddingTop = padding1,
            .PaddingBottom = padding1
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Asfictica", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .PaddingTop = padding1,
            .PaddingBottom = padding1
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Hidratada", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .PaddingTop = padding1,
            .PaddingBottom = padding1
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Standar", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .PaddingTop = padding1,
            .PaddingBottom = padding1
        }
        tabla.AddCell(cell)

        fotoPDF = iTextSharp.text.Image.GetInstance(Preguntar_SiNo(Datos.Desvitalizada1))
        fotoPDF.ScaleAbsolute(anchoSINOAF, altoSINOAF)
        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .PaddingTop = padding1
        }
        tabla.AddCell(cell)

        fotoPDF = iTextSharp.text.Image.GetInstance(Preguntar_SiNo(Datos.Asfictica1))
        fotoPDF.ScaleAbsolute(anchoSINOAF, altoSINOAF)
        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .PaddingTop = padding1
        }
        tabla.AddCell(cell)

        fotoPDF = iTextSharp.text.Image.GetInstance(Preguntar_SiNo(Datos.Hidratada1))
        fotoPDF.ScaleAbsolute(anchoSINOAF, altoSINOAF)
        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .PaddingTop = padding1
        }
        tabla.AddCell(cell)

        fotoPDF = iTextSharp.text.Image.GetInstance(Preguntar_SiNo(Datos.Standar1))
        fotoPDF.ScaleAbsolute(anchoSINOAF, altoSINOAF)
        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .PaddingTop = padding1
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        docPDF.Close()

        MsgBox("Documento generado")
        Dim Proc As New System.Diagnostics.Process
        Proc.StartInfo.FileName = ruta
        Proc.Start()

    End Sub

    Public Sub ConsentimientoPDF(Logo As Bitmap, Titulo As Bitmap, Anatomia As Bitmap, Datos As AutorizacionFacialVO)

        crearDirectorio()

        ruta = rutaDirectorio & "\\ConsentimientoTensaMax " & Datos.NomPaciente1 & ".pdf"
        'If File.Exists(ruta) Then
        '    File.Delete(ruta)
        'End If
        pdfw = PdfWriter.GetInstance(docPDF, New FileStream(ruta, FileMode.Create))
        docPDF.SetPageSize(PageSize.A4)
        'docPDF.SetMargins(70.8661F, 70.8661F, 85.0394F, 85.0394F)
        'docPDF.SetPageSize(New Rectangle(612.0F, 792.0F).Rotate) 'tamaño de la página
        docPDF.SetMargins(28.34F, 28.34F, 10.0F, 10.0F) 'CONVERTIR CM A PUNTOS
        'docPDF.SetMargins(20.0F, 20.0F, 0.0F, 0.0F) 'CONVERTIR CM A PUNTOS
        docPDF.Open()

        Dim cb As PdfContentByte
        Dim colorBordes As New BaseColor(201, 128, 138) 'COLOR DE BORDES

        'y -= 150
        Dim fuente As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.TIMES, 18, iTextSharp.text.Font.BOLD).BaseFont, 18)
        Dim fuente14 As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.TIMES, 14).BaseFont, 14)
        Dim fuenteTexto As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.TIMES, 14).BaseFont, 14)

        'Dim textoRojo As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.TIMES, 9, New BaseColor(255, 0, 0)).BaseFont, 9)
        Dim textoBorde = FontFactory.GetFont(FontFactory.TIMES, 26, colorBordes)
        Dim textoblanco = FontFactory.GetFont(FontFactory.TIMES, 18, BaseColor.WHITE)
        Dim anchoSINOAF As Integer = 63 'ANCHO SI_NO ACTIVIDAD FISICA
        Dim altoSINOAF As Integer = 15 'ALTO SI_NO ACTIVIDAD FISICA
        Dim anchoSINOIP As Integer = 42 'ANCHO SI_NO INFORME PATOLOGICO
        Dim altoSINOIP As Integer = 10 'ALTO SI_NO INFORME PATOLOGICO
        Dim anchoSINOCA As Integer = 42 'ANCHO SI_NO CUTIS ANATOMIA FACIAL
        Dim altoSINOCA As Integer = 10 'ALTO SI_NO CUTIS ANATOMIA FACIAL


        'LOGO
        fotoPDF = iTextSharp.text.Image.GetInstance(Logo, BaseColor.WHITE)
        fotoPDF.ScaleAbsolute(130, 60)


        'BORDE SUPERIOR
        'borde = New Chunk(New iTextSharp.text.pdf.draw.LineSeparator(30.0F, 110.0F, New BaseColor(220, 120, 170), Element.ALIGN_JUSTIFIED_ALL, -1))
        'docPDF.Add(borde)
        cb = pdfw.DirectContent
        cb.MoveTo(841.89F, 841.89F)
        cb.LineTo(0, 841.89F)
        cb.SetLineWidth(30)
        'cb.SetCMYKColorFill(23, 30, 40, 20)
        cb.SetColorStroke(colorBordes)
        cb.ClosePathStroke()

        'BORDE IZQUIERDO
        cb = pdfw.DirectContent
        cb.MoveTo(0, 0)
        cb.LineTo(0, 841.89F)
        cb.SetLineWidth(30)
        'cb.SetCMYKColorFill(23, 30, 40, 20)
        cb.SetColorStroke(colorBordes)
        cb.ClosePathStroke()

        'BORDE DERECHO
        cb = pdfw.DirectContent
        cb.MoveTo(595.0F, 0)
        cb.LineTo(595.0F, 841.89F)
        cb.SetLineWidth(30)
        'cb.SetCMYKColorFill(23, 30, 40, 20)
        cb.SetColorStroke(colorBordes)
        cb.ClosePathStroke()

        'BORDE INFERIOR
        cb = pdfw.DirectContent
        cb.MoveTo(0, 0)
        cb.LineTo(595.0F, 0)
        cb.SetLineWidth(30)
        'cb.SetCMYKColorFill(23, 30, 40, 20)
        cb.SetColorStroke(colorBordes)
        cb.ClosePathStroke()


        'docPDF.Add(New Phrase(" "))
        'docPDF.Add(New Phrase(" "))

        'TABLA
        Dim tabla As New PdfPTable(New Single() {70.0F, 30.0F})
        tabla.WidthPercentage = 100.0F


        Dim cell As New PdfPCell(New Phrase("Consentimiento TensaMax", textoBorde)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .PaddingTop = 10,
            .Border = 0
        }
        tabla.AddCell(cell)



        'LOGO
        cell = New PdfPCell(fotoPDF) With { 'LOGO
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Padding = 10,
            .Border = 0,
            .Rowspan = 2
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Nombre del paciente: " + Datos.NomPaciente1, fuenteTexto)) With { 'LOGO
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)


        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("Yo, " + Datos.NomAcomp1 + " Identicado con la cédula de ciudadanía " + Datos.CedAcomp1 + ", me permito manifestar que a la fecha, " + Datos.Fecha1 + " he recibido por parte del operador del equipo TENSAMAX la información respecto del procedimiento conocido como RADIOFRECUENCIA MONOPOLAR RESISTIVA Y CAPACITIVA CON EL EQUIPO TENSAMAX.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        'docPDF.Add(New Phrase(" "))

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("El procedimiento consiste en trabajar con un dispositivo que usa radiofrecuencia Monopolar, tanto Capacitiva como resisitiva, y se basa en diatermia e hipertermia de la zona, causando un calentamiento profundo de la piel y en el tejido graso. Entiendo que los resultados de estos tratamientos varian en cada persona y los tratamientos multiples son necesarios.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("Este tratamiento sirve para tonificación de la piel, reducción volumétrica de medidas, tratamiento de celulitis, dolores musculares y post quirurgicos.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("La sensación que produce la radio frecuencia en el área a tratar es solo un calor intenso y confortable mas no Dolor. Como en cualquier tratamiento existen riesgos, un cuando en la mayoria de las personas no presenten ninguno. Normalmente despues del tratamiento puede presentarse enrojecimiento de la piel o edema suave del tejido tratado. El mayor riesgo es que se presente una quemadura y para evitarlo es importante que el operador este en permanénte comunicación con el paciente acerca del grado para determinar la intensidad de energia y los movimientos de los electrodos.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("Hay personas que no deben ser tratadas por contraindicaciones. Embarazo, marcapasos, o cualquier implante electrónico. cáncer de piel, infecciones bacterianas o virales, epilepsia, enfermedades autoinmunes, flebitis, enfermedades vasculares.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("Las indicaciones que se deben dar a los pacientes que se están haciendo radiofrecuencia son: tomar de 4 a 6 vasos de agua al día, tener un plan complementario de nutrición y una rutina de ejercicio. En el momento de salir de la sesión se recomienda NO darse baños de agua fría de inmediato, no usar el mismo día cámaras de bronceo, saunas, por el aumento de la temperatura corporal que queda en el cuerpo del paciente por algunas horas. En caso de mostrar algún efecto secundario al tratamiento comunicarse inmediatamente con su médico.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("Conozco las consecuencias en el evento de no realizar el procedimiento adecuado y declaro que he recibido la información requerida de manera clara y completa, por lo tanto, autorizo al operador del equipo " + Datos.NomOperador1 + " y a los asistentes de su elección, de la especialidad que se estime conveniente, para que me realice el procedimiento con el equipo TENSAMAX, reconozco que en cualquier momento puedo revocar este consentimiento y lo comunicare por el medio más expedito a la persona tratante. De igual manera reconozco que las obligaciones adquiridas por parte del médico son de medio y no de resultado y por lo tanto los resultados no pueden ser garantizados, entiendo que mi problema es únicamente de tipo cosmético y que el tratamiento mencionado se llevara a cabo porque así lo deseo. ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("He leído y entiendo este formato y más inquietudes han sido contestadas satisfactoriamente e He leído las recomendaciones para antes y después del tratamiento y las seguiré para proteger mi piel.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        'seccion de firma

        tabla = New PdfPTable(New Single() {30.0F, 40.0F, 30.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 5,
            .Border = 0
        }
        tabla.AddCell(cell)

        fotoPDF = iTextSharp.text.Image.GetInstance(Datos.FirmaPaciente1)
        fotoPDF.ScaleAbsolute(180, 45)
        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 10,
            .PaddingBottom = 5,
            .Border = 0,
            .BorderWidthBottom = 1
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 5,
            .Border = 0
        }
        tabla.AddCell(cell)


        'SEGUNDA LINEA TEXTO FIRMA PACIENTE

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 5,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Firma del Paciente", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_TOP,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 5,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 5,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F


        Dim fecha As Date = Now.Date
        cell = New PdfPCell(New Phrase("Fecha del tratamiento: " + fecha, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_BOTTOM,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 10,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)
        docPDF.Close()

        MsgBox("Documento generado")
        Dim Proc As New System.Diagnostics.Process
        Proc.StartInfo.FileName = ruta
        Proc.Start()

    End Sub
    Public Sub ConsentimientoHidrafacialPDF(Logo As Bitmap, Titulo As Bitmap, Anatomia As Bitmap, Datos As HidraFacialVO)

        crearDirectorio()
        ruta = rutaDirectorio & "\\Consentimiento Hidrafacial.pdf"
        If File.Exists(ruta) Then
            File.Delete(ruta)

        End If

        If Not File.Exists(ruta) Then

        End If
        pdfw = PdfWriter.GetInstance(docPDF, New FileStream(ruta, FileMode.Create))
        docPDF.SetPageSize(PageSize.A4)
        'docPDF.SetMargins(70.8661F, 70.8661F, 85.0394F, 85.0394F)
        'docPDF.SetPageSize(New Rectangle(612.0F, 792.0F).Rotate) 'tamaño de la página
        docPDF.SetMargins(28.34F, 28.34F, 10.0F, 10.0F) 'CONVERTIR CM A PUNTOS
        'docPDF.SetMargins(20.0F, 20.0F, 0.0F, 0.0F) 'CONVERTIR CM A PUNTOS
        docPDF.Open()

        Dim cb As PdfContentByte
        Dim colorBordes As New BaseColor(201, 128, 138) 'COLOR DE BORDES


        'y -= 150
        Dim fuente As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.TIMES, 18, iTextSharp.text.Font.BOLD).BaseFont, 18)
        Dim fuente14 As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.TIMES, 14).BaseFont, 14)
        Dim fuenteTexto As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.TIMES, 14).BaseFont, 14)

        'Dim textoRojo As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.TIMES, 9, New BaseColor(255, 0, 0)).BaseFont, 9)
        Dim textoBorde = FontFactory.GetFont(FontFactory.TIMES, 26, colorBordes)
        Dim textoblanco = FontFactory.GetFont(FontFactory.TIMES, 18, BaseColor.WHITE)
        Dim anchoSINOAF As Integer = 63 'ANCHO SI_NO ACTIVIDAD FISICA
        Dim altoSINOAF As Integer = 15 'ALTO SI_NO ACTIVIDAD FISICA
        Dim anchoSINOIP As Integer = 42 'ANCHO SI_NO INFORME PATOLOGICO
        Dim altoSINOIP As Integer = 10 'ALTO SI_NO INFORME PATOLOGICO
        Dim anchoSINOCA As Integer = 42 'ANCHO SI_NO CUTIS ANATOMIA FACIAL
        Dim altoSINOCA As Integer = 10 'ALTO SI_NO CUTIS ANATOMIA FACIAL


        'LOGO
        fotoPDF = iTextSharp.text.Image.GetInstance(Logo, BaseColor.WHITE)
        fotoPDF.ScaleAbsolute(130, 60)


        'BORDE SUPERIOR
        'borde = New Chunk(New iTextSharp.text.pdf.draw.LineSeparator(30.0F, 110.0F, New BaseColor(220, 120, 170), Element.ALIGN_JUSTIFIED_ALL, -1))
        'docPDF.Add(borde)
        cb = pdfw.DirectContent
        cb.MoveTo(841.89F, 841.89F)
        cb.LineTo(0, 841.89F)
        cb.SetLineWidth(30)
        'cb.SetCMYKColorFill(23, 30, 40, 20)
        cb.SetColorStroke(colorBordes)
        cb.ClosePathStroke()

        'BORDE IZQUIERDO
        cb = pdfw.DirectContent
        cb.MoveTo(0, 0)
        cb.LineTo(0, 841.89F)
        cb.SetLineWidth(30)
        'cb.SetCMYKColorFill(23, 30, 40, 20)
        cb.SetColorStroke(colorBordes)
        cb.ClosePathStroke()

        'BORDE DERECHO
        cb = pdfw.DirectContent
        cb.MoveTo(595.0F, 0)
        cb.LineTo(595.0F, 841.89F)
        cb.SetLineWidth(30)
        'cb.SetCMYKColorFill(23, 30, 40, 20)
        cb.SetColorStroke(colorBordes)
        cb.ClosePathStroke()

        'BORDE INFERIOR
        cb = pdfw.DirectContent
        cb.MoveTo(0, 0)
        cb.LineTo(595.0F, 0)
        cb.SetLineWidth(30)
        'cb.SetCMYKColorFill(23, 30, 40, 20)
        cb.SetColorStroke(colorBordes)
        cb.ClosePathStroke()


        'docPDF.Add(New Phrase(" "))
        'docPDF.Add(New Phrase(" "))

        'TABLA
        Dim tabla As New PdfPTable(New Single() {70.0F, 30.0F})
        tabla.WidthPercentage = 100.0F


        Dim cell As New PdfPCell(New Phrase("Consentimiento Hidrafacial", textoBorde)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .PaddingTop = 10,
            .Border = 0
        }
        tabla.AddCell(cell)

        'LOGO
        cell = New PdfPCell(fotoPDF) With { 'LOGO
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Padding = 10,
            .Border = 0,
            .Rowspan = 2
        }
        tabla.AddCell(cell)


        cell = New PdfPCell(New Phrase("Tratamiento a Realizar: " + Datos.Procedimiento1, fuenteTexto)) With { 'LOGO
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("Es un tratamiento cosmetológico que permite mantener el rostro limpio de impurezas, como comedones (también llamados puntos negros) y estos de células muertas, dando lugar a una piel fresca, luminosa y bien cuidada.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        'docPDF.Add(New Phrase(" "))

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("Hidra Facial utiliza una tecnología patentada para limpiar, extraer e hidratar la piel al tiempo que infunde sérums altamente eficaces adaptados a las necesidades especificas de tu piel. Este proceso único ayuda a mejorar el aspecto de varios problemas de la piel, como líneas finas y pliegues, la firmeza de la piel, la textura y la congestión de los poros. Adecuado para todo tipo de pieles, este tratamiento rejuvenecedor es suave, no invasivo y de efecto inmediato.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("El dispositivo Hidra Facial utiliza tres acciones que contribuyen al rejuvenecimiento de la piel: la exfoliación física mediante la presión del agua y una punta texturizada, la exfoliación química mediante ácidos como el glicólico y el salicílico, y la succión para levantar las células muertas de la superficie.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("Un tratamiento básico comienza con una solución a base de agua que se aplica a la piel para romper la capa superior de células muertas. Gracias a la punta se succión en espiral del dispositivo Hydra Facial, las células muertas de la piel y los restos superficiales se levantan, proporcionando un método de extracción más suave.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)


        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("Como este facialista debe estar al tanto de cualquier enfermedad que tenga, he comunicado todas las enfermedades medicas conocidas, y es mi responsabilidad mantenerlo informado sobre el estado de mi salud física.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("También se me ha informado debidamente de otros procedimientos alternativos.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("1.	He comprendido las especificaciones que se me han facilitado en un lenguaje claro y sencillo, y el profesional que me ha atendido me ha permitido realizar todas las observaciones y me ha aclarado todas las dudas que le he planteado.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("2.	Por ello manifiesto mi conformidad con la información recibida y comprendo el alcance y los riesgos del procedimiento.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("3.	También se me ha informado debidamente de otros procedimientos", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("4.	Como el profesional que realiza el procedimiento  debe estar al tanto de cualquier enfermedad que tenga, he comunicado todas las enfermedades medicas conocidas, y es mi responsabilidad mantenerlo informado sobre el estado de mi salid física.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)



        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("5.	Accedo y autorizo a seguir un control fotográfico pre y post tratamientos u otros materiales audiovisuales y gráficos y con la sola finalidad del control evolutivo de mi tratamiento y valoración científica.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("6.	Considero que he sido suficientemente informado/a y aclaradas mis posibles dudas sobre el procedimiento y posibles resultados", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        ''parte de las firmas 

        tabla = New PdfPTable(New Single() {30.0F, 40.0F, 30.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .Border = 0
        }
        tabla.AddCell(cell)

        fotoPDF = iTextSharp.text.Image.GetInstance(Datos.FirmaPaciente1)
        fotoPDF.ScaleAbsolute(180, 45)
        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 10,
            .PaddingBottom = 5,
            .Border = 0,
            .BorderWidthBottom = 1
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .Border = 0
        }
        tabla.AddCell(cell)

        'SEGUNDA LINEA TEXTO FIRMA DEL PACIENTE

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 5,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Firma del Paciente", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_TOP,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 5,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 5,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F


        Dim fecha As Date = Now.Date
        cell = New PdfPCell(New Phrase("Fecha del tratamiento: " + fecha, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_BOTTOM,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 10,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        docPDF.Close()
        docPDF.Dispose()
        'MsgBox("siii")
        Dim msgBoxResult = MsgBox("Documento prueba generado")
        Dim Proc As New System.Diagnostics.Process
        Proc.StartInfo.FileName = ruta
        Proc.Start()


    End Sub

    Public Sub FichaCorporalPDF(Logo As Bitmap, Titulo As Bitmap, Datos As FichaCorporalVO, Anatomia As Bitmap)

        crearDirectorio()
        ruta = rutaDirectorio & "\\FichaCorporal " & Datos.Nombre1 & ".pdf"
        If File.Exists(ruta) Then
            File.Delete(ruta)
        End If
        pdfw = PdfWriter.GetInstance(docPDF, New FileStream(ruta, FileMode.Create))
        docPDF.SetPageSize(PageSize.A4)
        'docPDF.SetMargins(70.8661F, 70.8661F, 85.0394F, 85.0394F)
        'docPDF.SetPageSize(New Rectangle(612.0F, 792.0F).Rotate) 'tamaño de la página
        docPDF.SetMargins(28.34F, 28.34F, 10.0F, 10.0F) 'CONVERTIR CM A PUNTOS
        'docPDF.SetMargins(20.0F, 20.0F, 0.0F, 0.0F) 'CONVERTIR CM A PUNTOS
        docPDF.Open()


        'y -= 150
        Dim fuente As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.TIMES, 18, iTextSharp.text.Font.BOLD).BaseFont, 18)
        Dim fuente14 As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.TIMES, 14).BaseFont, 14)
        Dim fuenteTexto As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.TIMES, 14).BaseFont, 14)
        Dim fuenteTexto12 As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.TIMES, 12).BaseFont, 12)
        'Dim textoRojo As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.TIMES, 9, New BaseColor(255, 0, 0)).BaseFont, 9)
        Dim textoRojo = FontFactory.GetFont(FontFactory.TIMES_BOLD, 9, BaseColor.RED)
        Dim textoblanco = FontFactory.GetFont(FontFactory.TIMES, 18, BaseColor.WHITE)
        Dim anchoSINOCA As Integer = 21 'ANCHO SI_NO CUTIS ANATOMIA FACIAL
        Dim altoSINOCA As Integer = 10 'ALTO SI_NO CUTIS ANATOMIA FACIAL


        'LOGO
        fotoPDF = iTextSharp.text.Image.GetInstance(Logo, BaseColor.WHITE)
        fotoPDF.ScaleAbsolute(130, 60)

        Dim cb As PdfContentByte
        Dim colorBordes As New BaseColor(201, 128, 138) 'COLOR DE BORDES
        'BORDE SUPERIOR
        'borde = New Chunk(New iTextSharp.text.pdf.draw.LineSeparator(30.0F, 110.0F, New BaseColor(220, 120, 170), Element.ALIGN_JUSTIFIED_ALL, -1))
        'docPDF.Add(borde)
        cb = pdfw.DirectContent
        cb.MoveTo(841.89F, 841.89F)
        cb.LineTo(0, 841.89F)
        cb.SetLineWidth(30)
        'cb.SetCMYKColorFill(23, 30, 40, 20)
        cb.SetColorStroke(colorBordes)
        cb.ClosePathStroke()

        'BORDE IZQUIERDO
        cb = pdfw.DirectContent
        cb.MoveTo(0, 0)
        cb.LineTo(0, 841.89F)
        cb.SetLineWidth(30)
        'cb.SetCMYKColorFill(23, 30, 40, 20)
        cb.SetColorStroke(colorBordes)
        cb.ClosePathStroke()

        'BORDE DERECHO
        cb = pdfw.DirectContent
        cb.MoveTo(595.0F, 0)
        cb.LineTo(595.0F, 841.89F)
        cb.SetLineWidth(30)
        'cb.SetCMYKColorFill(23, 30, 40, 20)
        cb.SetColorStroke(colorBordes)
        cb.ClosePathStroke()

        'BORDE INFERIOR
        cb = pdfw.DirectContent
        cb.MoveTo(0, 0)
        cb.LineTo(595.0F, 0)
        cb.SetLineWidth(30)
        'cb.SetCMYKColorFill(23, 30, 40, 20)
        cb.SetColorStroke(colorBordes)
        cb.ClosePathStroke()


        'docPDF.Add(New Phrase(" "))
        'docPDF.Add(New Phrase(" "))

        Dim tabla As New PdfPTable(New Single() {80.0F, 20.0F})
        tabla.WidthPercentage = 100.0F
        Dim cell As New PdfPCell(New Phrase("", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_RIGHT,
            .Padding = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("N°: " + Datos.NExpediente1, fuente)) With {
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_RIGHT,
            .PaddingTop = 10,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        'TABLA
        tabla = New PdfPTable(New Single() {30.0F, 40.0F, 30.0F})
        tabla.WidthPercentage = 100.0F
        'LOGO
        cell = New PdfPCell(fotoPDF) With { 'LOGO
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .Padding = 10,
            .Border = 0,
            .Rowspan = 2
        }
        tabla.AddCell(cell)

        'TITULO
        fotoPDF = iTextSharp.text.Image.GetInstance(Titulo, BaseColor.WHITE)
        fotoPDF.ScaleAbsolute(185, 55)
        cell = New PdfPCell(fotoPDF) With { 'TITULO
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Padding = 10,
            .Border = 0,
            .Rowspan = 2
        }
        tabla.AddCell(cell)


        'FIRMA PROFESIONAL
        cell = New PdfPCell(New Phrase("Especialista", fuente14)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        fotoPDF = iTextSharp.text.Image.GetInstance(Datos.Profesional1) 'FIRMA DEL PROFESIONAL
        fotoPDF.ScaleAbsolute(140, 24)
        fotoPDF.SetAbsolutePosition(415, 733)
        cb.AddImage(fotoPDF)

        cb = pdfw.DirectContent
        cb.SetLineWidth(3)
        cb.MoveTo(410, 760)
        cb.LineTo(560, 760)
        cb.LineTo(560, 730)
        cb.LineTo(410, 730)
        cb.ClosePathStroke()
        cb.SetColorStroke(colorBordes)

        docPDF.Add(tabla)

        'docPDF.Add(New Phrase(" "))

        Dim padding1 As Integer = 5 'MARGEN ENTRE CAJAS DE TEXTO
        Dim padding10 As Integer = 10 'MARGEN ENTRE CAJAS DE TEXTO
        Dim colorTxt As New BaseColor(245, 243, 248) 'COLOR CAJA DE TEXTO

        '---------------------------------LINEA DATOS GENERALES---------------------------
        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F
        cell = New PdfPCell(New Phrase("Datos Generales", textoblanco)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .BackgroundColor = colorBordes,
            .Border = 0,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        'SECCIÓN DATOS GENERALES
        tabla = New PdfPTable(New Single() {50.0F, 50.0F})
        tabla.WidthPercentage = 100.0F
        'columna 1
        cell = New PdfPCell(New Phrase("Nombre: " + Datos.Nombre1, fuenteTexto)) With {
            .Rowspan = 4,
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .Border = 0,
            .PaddingTop = padding1
        }
        tabla.AddCell(cell)

        'cb = pdfw.DirectContent
        'cb.SetColorStroke(colorTxt)
        'cb.MoveTo(90, 710)
        'cb.LineTo(280, 710)
        'cb.LineTo(280, 693)
        'cb.LineTo(90, 693)
        'cb.Fill()


        'columna 2
        cell = New PdfPCell(New Phrase("Correo: " + Datos.Correo1, fuenteTexto)) With {
            .Rowspan = 4,
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .Border = 0,
            .PaddingTop = padding1
        }
        tabla.AddCell(cell)



        'FILA 2 COLUMNA 1 (DOMICILIO)
        cell = New PdfPCell(New Phrase("Domicilio: " + Datos.Domicilio1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .Border = 0,
            .PaddingTop = padding1
        }
        tabla.AddCell(cell)

        'cb = pdfw.DirectContent
        'cb.SetColorStroke(colorTxt)
        'cb.MoveTo(100, 700)
        'cb.LineTo(280, 700)
        'cb.LineTo(280, 683)
        'cb.LineTo(100, 683)
        'cb.Fill()

        'FILA 2 COLUMNA 2 (TELEFONO)
        cell = New PdfPCell(New Phrase("Telefono: " + Datos.Telefono1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .Border = 0,
            .PaddingTop = padding1
        }
        tabla.AddCell(cell)

        'FILA 3 COLUMNA 1 (EDAD)
        cell = New PdfPCell(New Phrase("Edad: " + Datos.Edad1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .Border = 0,
            .PaddingTop = padding1
        }
        tabla.AddCell(cell)

        'FILA 3 COLUMNA 2 (ESTADO CIVIL)
        cell = New PdfPCell(New Phrase("Estado Civil: " + Datos.EstadoCivil1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .Border = 0,
            .PaddingTop = padding1
        }
        tabla.AddCell(cell)

        'FILA 4 COLUMNA 1 (Fecha de nacimiento)
        cell = New PdfPCell(New Phrase("Fecha de Nacimiento: " + Datos.FechaNacimiento1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .Border = 0,
            .PaddingTop = padding1,
            .PaddingBottom = 10
        }
        tabla.AddCell(cell)

        'FILA 4 COLUMNA 2 (MOTIVO CONSULTA)
        cell = New PdfPCell(New Phrase("Motivo de Consulta: " + Datos.MotivoConsulta1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .Border = 0,
            .PaddingTop = padding1
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        '---------------------------------LINEA CUTIS---------------------------
        tabla = New PdfPTable(New Single() {50.0F, 50.0F}) With {
            .WidthPercentage = 100.0F
        }
        cell = New PdfPCell(New Phrase("Datos Clinicos", textoblanco)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .BackgroundColor = colorBordes,
            .Border = 0,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Anatomia Corporal", textoblanco)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .BackgroundColor = colorBordes,
            .Border = 0,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {50.0F, 10.0F, 6.6F, 10.0F, 6.6F, 10.0F, 6.6F}) With {
                .WidthPercentage = 100.0F
            }

        cell = New PdfPCell(New Phrase(" ", fuenteTexto12)) With {
                .VerticalAlignment = Element.ALIGN_CENTER,
             .HorizontalAlignment = Element.ALIGN_LEFT,
                .Border = 0,
                .PaddingTop = padding1
            }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Edad:", fuenteTexto12)) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
             .HorizontalAlignment = Element.ALIGN_RIGHT,
                .Border = 0,
                .PaddingTop = padding1
            }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(Datos.Edad1, fuenteTexto12)) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
             .HorizontalAlignment = Element.ALIGN_RIGHT,
                .Border = 0,
                .PaddingTop = padding1,
                .BorderWidthBottom = 1
            }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Peso:", fuenteTexto12)) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
             .HorizontalAlignment = Element.ALIGN_RIGHT,
                .Border = 0,
                .PaddingTop = padding1
            }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(Datos.Peso1, fuenteTexto12)) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
             .HorizontalAlignment = Element.ALIGN_RIGHT,
                .Border = 0,
                .PaddingTop = padding1,
                .BorderWidthBottom = 1
            }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Estatura:", fuenteTexto12)) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
             .HorizontalAlignment = Element.ALIGN_RIGHT,
                .Border = 0,
                .PaddingTop = padding1
            }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(Datos.Estatura1, fuenteTexto12)) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
             .HorizontalAlignment = Element.ALIGN_RIGHT,
                .Border = 0,
                .PaddingTop = padding1,
                .BorderWidthBottom = 1
            }
        tabla.AddCell(cell)

        docPDF.Add(tabla)



        tabla = New PdfPTable(New Single() {20.0F, 5.0F, 25.0F, 5.0F, 45.0F}) With {
                .WidthPercentage = 100.0F
            }

        cell = New PdfPCell(New Phrase("Enf. Cardiacas:", fuenteTexto12)) With {
                .VerticalAlignment = Element.ALIGN_CENTER,
             .HorizontalAlignment = Element.ALIGN_LEFT,
                .Border = 0,
                .PaddingTop = padding1
            }
        tabla.AddCell(cell)

        'IMAGEN
        fotoPDF = iTextSharp.text.Image.GetInstance(Preguntar_SiNo_FichaCorporal(Datos.EnfCardiacas1))
        fotoPDF.ScaleAbsolute(anchoSINOCA, altoSINOCA)
        cell = New PdfPCell(fotoPDF) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
                .HorizontalAlignment = Element.ALIGN_RIGHT,
                .Border = 0,
                .PaddingTop = padding1,
                .PaddingRight = padding1
            }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Problemas de presion:", fuenteTexto12)) With {
                .VerticalAlignment = Element.ALIGN_CENTER,
             .HorizontalAlignment = Element.ALIGN_LEFT,
                .Border = 0,
                .PaddingTop = padding1
            }
        tabla.AddCell(cell)

        'IMAGEN
        fotoPDF = iTextSharp.text.Image.GetInstance(Preguntar_SiNo_FichaCorporal(Datos.Presion1))
        fotoPDF.ScaleAbsolute(anchoSINOCA, altoSINOCA)
        cell = New PdfPCell(fotoPDF) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
                .HorizontalAlignment = Element.ALIGN_RIGHT,
                .Border = 0,
                .PaddingTop = padding1,
                .PaddingRight = padding1
            }
        tabla.AddCell(cell)

        'IMAGEN
        fotoPDF = iTextSharp.text.Image.GetInstance(Anatomia, BaseColor.WHITE)
        fotoPDF.ScaleAbsolute(130, 150)
        cell = New PdfPCell(fotoPDF) With {
                .VerticalAlignment = Element.ALIGN_CENTER,
                .HorizontalAlignment = Element.ALIGN_CENTER,
                .Border = 0,
                .PaddingTop = padding10,
                .PaddingBottom = padding10,
                .Rowspan = 8
            }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Enf. Renales:", fuenteTexto12)) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
             .HorizontalAlignment = Element.ALIGN_LEFT,
                .Border = 0,
                .PaddingTop = padding1
            }
        tabla.AddCell(cell)

        'IMAGEN
        fotoPDF = iTextSharp.text.Image.GetInstance(Preguntar_SiNo_FichaCorporal(Datos.EnfRenales1))
        fotoPDF.ScaleAbsolute(anchoSINOCA, altoSINOCA)
        cell = New PdfPCell(fotoPDF) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
                .HorizontalAlignment = Element.ALIGN_RIGHT,
                .Border = 0,
                .PaddingTop = padding1,
                .PaddingRight = padding1
            }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Algún tipo de alergia:", fuenteTexto12)) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
             .HorizontalAlignment = Element.ALIGN_LEFT,
                .Border = 0,
                .PaddingTop = padding1
            }
        tabla.AddCell(cell)

        'IMAGEN
        fotoPDF = iTextSharp.text.Image.GetInstance(Preguntar_SiNo_FichaCorporal(Datos.Alergia1))
        fotoPDF.ScaleAbsolute(anchoSINOCA, altoSINOCA)
        cell = New PdfPCell(fotoPDF) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
                .HorizontalAlignment = Element.ALIGN_RIGHT,
                .Border = 0,
                .PaddingTop = padding1,
                .PaddingRight = padding1
            }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Enf. Circulatorias:", fuenteTexto12)) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
             .HorizontalAlignment = Element.ALIGN_LEFT,
                .Border = 0,
                .PaddingTop = padding1
            }
        tabla.AddCell(cell)

        'IMAGEN
        fotoPDF = iTextSharp.text.Image.GetInstance(Preguntar_SiNo_FichaCorporal(Datos.EnfCirculatorias1))
        fotoPDF.ScaleAbsolute(anchoSINOCA, altoSINOCA)
        cell = New PdfPCell(fotoPDF) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
                .HorizontalAlignment = Element.ALIGN_RIGHT,
                .Border = 0,
                .PaddingTop = padding1,
                .PaddingRight = padding1
            }
        tabla.AddCell(cell)


        cell = New PdfPCell(New Phrase("Problemas en la piel:", fuenteTexto12)) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
             .HorizontalAlignment = Element.ALIGN_LEFT,
                .Border = 0,
                .PaddingTop = padding1
            }
        tabla.AddCell(cell)

        'IMAGEN
        fotoPDF = iTextSharp.text.Image.GetInstance(Preguntar_SiNo_FichaCorporal(Datos.Piel1))
        fotoPDF.ScaleAbsolute(anchoSINOCA, altoSINOCA)
        cell = New PdfPCell(fotoPDF) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
                .HorizontalAlignment = Element.ALIGN_RIGHT,
                .Border = 0,
                .PaddingTop = padding1,
                .PaddingRight = padding1
            }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Enf. Pulmonares:", fuenteTexto12)) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
             .HorizontalAlignment = Element.ALIGN_LEFT,
                .Border = 0,
                .PaddingTop = padding1
            }
        tabla.AddCell(cell)

        'IMAGEN
        fotoPDF = iTextSharp.text.Image.GetInstance(Preguntar_SiNo_FichaCorporal(Datos.EnfPulmonares1))
        fotoPDF.ScaleAbsolute(anchoSINOCA, altoSINOCA)
        cell = New PdfPCell(fotoPDF) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
                .HorizontalAlignment = Element.ALIGN_RIGHT,
                .Border = 0,
                .PaddingTop = padding1,
                .PaddingRight = padding1
            }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Sufre Convulsiones:", fuenteTexto12)) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
             .HorizontalAlignment = Element.ALIGN_LEFT,
                .Border = 0,
                .PaddingTop = padding1
            }
        tabla.AddCell(cell)

        'IMAGEN
        fotoPDF = iTextSharp.text.Image.GetInstance(Preguntar_SiNo_FichaCorporal(Datos.Convulsiones1))
        fotoPDF.ScaleAbsolute(anchoSINOCA, altoSINOCA)
        cell = New PdfPCell(fotoPDF) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
                .HorizontalAlignment = Element.ALIGN_RIGHT,
                .Border = 0,
                .PaddingTop = padding1,
                .PaddingRight = padding1
            }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Enf. Digestivas:", fuenteTexto12)) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
             .HorizontalAlignment = Element.ALIGN_LEFT,
                .Border = 0,
                .PaddingTop = padding1
            }
        tabla.AddCell(cell)

        'IMAGEN
        fotoPDF = iTextSharp.text.Image.GetInstance(Preguntar_SiNo_FichaCorporal(Datos.EnfDigestivas1))
        fotoPDF.ScaleAbsolute(anchoSINOCA, altoSINOCA)
        cell = New PdfPCell(fotoPDF) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
                .HorizontalAlignment = Element.ALIGN_RIGHT,
                .Border = 0,
                .PaddingTop = padding1,
                .PaddingRight = padding1
            }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Tabaco:", fuenteTexto12)) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
             .HorizontalAlignment = Element.ALIGN_LEFT,
                .Border = 0,
                .PaddingTop = padding1
            }
        tabla.AddCell(cell)

        'IMAGEN
        fotoPDF = iTextSharp.text.Image.GetInstance(Preguntar_SiNo_FichaCorporal(Datos.Tabaco1))
        fotoPDF.ScaleAbsolute(anchoSINOCA, altoSINOCA)
        cell = New PdfPCell(fotoPDF) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
                .HorizontalAlignment = Element.ALIGN_RIGHT,
                .Border = 0,
                .PaddingTop = padding1,
                .PaddingRight = padding1
            }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Enf. Hematológicas", fuenteTexto12)) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
             .HorizontalAlignment = Element.ALIGN_LEFT,
                .Border = 0,
                .PaddingTop = padding1
            }
        tabla.AddCell(cell)

        'IMAGEN
        fotoPDF = iTextSharp.text.Image.GetInstance(Preguntar_SiNo_FichaCorporal(Datos.EnfHematologicas1))
        fotoPDF.ScaleAbsolute(anchoSINOCA, altoSINOCA)
        cell = New PdfPCell(fotoPDF) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
                .HorizontalAlignment = Element.ALIGN_RIGHT,
                .Border = 0,
                .PaddingTop = padding1,
                .PaddingRight = padding1
            }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Alcohol:", fuenteTexto12)) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
             .HorizontalAlignment = Element.ALIGN_LEFT,
                .Border = 0,
                .PaddingTop = padding1
            }
        tabla.AddCell(cell)

        'IMAGEN
        fotoPDF = iTextSharp.text.Image.GetInstance(Preguntar_SiNo_FichaCorporal(Datos.Alcohol1))
        fotoPDF.ScaleAbsolute(anchoSINOCA, altoSINOCA)
        cell = New PdfPCell(fotoPDF) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
                .HorizontalAlignment = Element.ALIGN_RIGHT,
                .Border = 0,
                .PaddingTop = padding1,
                .PaddingRight = padding1
            }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Enf. Endocrinas:", fuenteTexto12)) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
             .HorizontalAlignment = Element.ALIGN_LEFT,
                .Border = 0,
                .PaddingTop = padding1
            }
        tabla.AddCell(cell)

        'IMAGEN
        fotoPDF = iTextSharp.text.Image.GetInstance(Preguntar_SiNo_FichaCorporal(Datos.EnfEndocrinas1))
        fotoPDF.ScaleAbsolute(anchoSINOCA, altoSINOCA)
        cell = New PdfPCell(fotoPDF) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
                .HorizontalAlignment = Element.ALIGN_RIGHT,
                .Border = 0,
                .PaddingTop = padding1,
                .PaddingRight = padding1
            }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Drogas:", fuenteTexto12)) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
             .HorizontalAlignment = Element.ALIGN_LEFT,
                .Border = 0,
                .PaddingTop = padding1
            }
        tabla.AddCell(cell)

        'IMAGEN
        fotoPDF = iTextSharp.text.Image.GetInstance(Preguntar_SiNo_FichaCorporal(Datos.Drogas1))
        fotoPDF.ScaleAbsolute(anchoSINOCA, altoSINOCA)
        cell = New PdfPCell(fotoPDF) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
                .HorizontalAlignment = Element.ALIGN_RIGHT,
                .Border = 0,
                .PaddingTop = padding1,
                .PaddingRight = padding1
            }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Enf. Neurológicas:", fuenteTexto12)) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
             .HorizontalAlignment = Element.ALIGN_LEFT,
                .Border = 0,
                .PaddingTop = padding1
            }
        tabla.AddCell(cell)

        'IMAGEN
        fotoPDF = iTextSharp.text.Image.GetInstance(Preguntar_SiNo_FichaCorporal(Datos.EnfNeurologicas1))
        fotoPDF.ScaleAbsolute(anchoSINOCA, altoSINOCA)
        cell = New PdfPCell(fotoPDF) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
                .HorizontalAlignment = Element.ALIGN_RIGHT,
                .Border = 0,
                .PaddingTop = padding1,
                .PaddingRight = padding1
            }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Posee Marcapasos:", fuenteTexto12)) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
             .HorizontalAlignment = Element.ALIGN_LEFT,
                .Border = 0,
                .PaddingTop = padding1
            }
        tabla.AddCell(cell)

        'IMAGEN
        fotoPDF = iTextSharp.text.Image.GetInstance(Preguntar_SiNo_FichaCorporal(Datos.Marcapasos1))
        fotoPDF.ScaleAbsolute(anchoSINOCA, altoSINOCA)
        cell = New PdfPCell(fotoPDF) With {
                .VerticalAlignment = Element.ALIGN_MIDDLE,
                .HorizontalAlignment = Element.ALIGN_RIGHT,
                .Border = 0,
                .PaddingTop = padding1,
                .PaddingRight = padding1
            }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {50.0F, 50.0F}) With {
            .WidthPercentage = 100.0F
        }
        cell = New PdfPCell(New Phrase("Medidas Corporales", textoblanco)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .BackgroundColor = colorBordes,
            .Border = 0,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Observaciones Generales", textoblanco)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .BackgroundColor = colorBordes,
            .Border = 0,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {20.0F, 10.0F, 10.0F, 10.0F, 50.0F}) With {
            .WidthPercentage = 100.0F
        }
        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .BorderWidthBottom = 1,
            .PaddingTop = padding10
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Inicio", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .BorderWidthBottom = 1,
            .PaddingTop = padding10
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Medio", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .BorderWidthBottom = 1,
            .PaddingTop = padding10
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Final", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .BorderWidthBottom = 1,
            .PaddingTop = padding10
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(Datos.ObsGenerales1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .PaddingTop = 0,
            .Rowspan = 5
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Cintura", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .Border = 0,
            .BorderWidthLeft = 1,
            .BorderWidthBottom = 1,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(Datos.CinturaI1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .BorderWidthLeft = 1,
            .BorderWidthBottom = 1,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase(Datos.CinturaM1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .BorderWidthLeft = 1,
            .BorderWidthBottom = 1,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase(Datos.CinturaF1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .BorderWidthLeft = 1,
            .BorderWidthBottom = 1,
            .BorderWidthRight = 1,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Pecho", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .Border = 0,
            .BorderWidthLeft = 1,
            .BorderWidthBottom = 1,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(Datos.PechoI1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .BorderWidthLeft = 1,
            .BorderWidthBottom = 1,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase(Datos.PechoM1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .BorderWidthLeft = 1,
            .BorderWidthBottom = 1,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase(Datos.PechoF1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .BorderWidthLeft = 1,
            .BorderWidthBottom = 1,
            .BorderWidthRight = 1,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Cadera", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .Border = 0,
            .BorderWidthLeft = 1,
            .BorderWidthBottom = 1,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(Datos.CaderaI1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .BorderWidthLeft = 1,
            .BorderWidthBottom = 1,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase(Datos.CaderaM1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .BorderWidthLeft = 1,
            .BorderWidthBottom = 1,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase(Datos.CaderaF1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .BorderWidthLeft = 1,
            .BorderWidthBottom = 1,
            .BorderWidthRight = 1,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Brazo Izquierdo", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .Border = 0,
            .BorderWidthLeft = 1,
            .BorderWidthBottom = 1,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(Datos.BIzquierdoI1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .BorderWidthLeft = 1,
            .BorderWidthBottom = 1,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase(Datos.BIzquierdoM1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .BorderWidthLeft = 1,
            .BorderWidthBottom = 1,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase(Datos.BIzquierdoF1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .BorderWidthLeft = 1,
            .BorderWidthBottom = 1,
            .BorderWidthRight = 1,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Brazo Derecho", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .Border = 0,
            .BorderWidthLeft = 1,
            .BorderWidthBottom = 1,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(Datos.BDerechoI1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .BorderWidthLeft = 1,
            .BorderWidthBottom = 1,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase(Datos.BDerechoM1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .BorderWidthLeft = 1,
            .BorderWidthBottom = 1,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase(Datos.BDerechoF1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .BorderWidthLeft = 1,
            .BorderWidthBottom = 1,
            .BorderWidthRight = 1,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Diagnóstico y Tratamiento", textoblanco)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .BackgroundColor = colorBordes,
            .Border = 0,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Muslo Izquierdo", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .Border = 0,
            .BorderWidthLeft = 1,
            .BorderWidthBottom = 1,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(Datos.MizquierdoI1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .BorderWidthLeft = 1,
            .BorderWidthBottom = 1,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase(Datos.MizquierdoM1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .BorderWidthLeft = 1,
            .BorderWidthBottom = 1,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase(Datos.MizquierdoF1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .BorderWidthLeft = 1,
            .BorderWidthBottom = 1,
            .BorderWidthRight = 1,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase(Datos.Diagnostico1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .PaddingTop = 0,
            .Rowspan = 5
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Muslo Derecho", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .Border = 0,
            .BorderWidthLeft = 1,
            .BorderWidthBottom = 1,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(Datos.MDerechoI1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .BorderWidthLeft = 1,
            .BorderWidthBottom = 1,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase(Datos.MDerechoM1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .BorderWidthLeft = 1,
            .BorderWidthBottom = 1,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase(Datos.MDerechoF1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .BorderWidthLeft = 1,
            .BorderWidthBottom = 1,
            .BorderWidthRight = 1,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Abdomen Alto", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .Border = 0,
            .BorderWidthLeft = 1,
            .BorderWidthBottom = 1,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(Datos.AAltoI1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .BorderWidthLeft = 1,
            .BorderWidthBottom = 1,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase(Datos.AAltoM1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .BorderWidthLeft = 1,
            .BorderWidthBottom = 1,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase(Datos.AAltoF1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .BorderWidthLeft = 1,
            .BorderWidthBottom = 1,
            .BorderWidthRight = 1,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Abdomen Medio", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .Border = 0,
            .BorderWidthLeft = 1,
            .BorderWidthBottom = 1,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(Datos.AMedioI1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .BorderWidthLeft = 1,
            .BorderWidthBottom = 1,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase(Datos.AMedioM1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .BorderWidthLeft = 1,
            .BorderWidthBottom = 1,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase(Datos.AMedioF1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .BorderWidthLeft = 1,
            .BorderWidthBottom = 1,
            .BorderWidthRight = 1,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Abdomen Bajo", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .Border = 0,
            .BorderWidthLeft = 1,
            .BorderWidthBottom = 1,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(Datos.ABajoI1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .BorderWidthLeft = 1,
            .BorderWidthBottom = 1,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase(Datos.ABajoM1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .BorderWidthLeft = 1,
            .BorderWidthBottom = 1,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase(Datos.ABajoF1, fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .BorderWidthLeft = 1,
            .BorderWidthBottom = 1,
            .BorderWidthRight = 1,
            .PaddingTop = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        docPDF.Add(New Phrase(" "))

        tabla = New PdfPTable(New Single() {35.0F, 30.0F, 35.0F}) With {
            .WidthPercentage = 100.0F
        }

        cell = New PdfPCell(New Phrase("", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0
        }
        tabla.AddCell(cell)

        fotoPDF = iTextSharp.text.Image.GetInstance(Datos.FirmaUsuario1)
        fotoPDF.ScaleAbsolute(100, 30)
        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0,
            .BorderWidthBottom = 1,
            .PaddingTop = padding10,
            .PaddingBottom = padding1
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Firma Usuario", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_TOP,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        docPDF.Close()

        MsgBox("Documento generado")
        Dim Proc As New System.Diagnostics.Process
        Proc.StartInfo.FileName = ruta
        Proc.Start()

    End Sub
    Private Function Preguntar_SiNo(valor As Integer)
        If (valor = 1) Then 'SI
            Return Principal.strunidad + ":\sistemgym_datos\imagenes\SI-3.png"
        Else 'NO
            Return unidad + ":\sistemgym_datos\imagenes\NO-3.png"
        End If
    End Function


    Private Sub crearDirectorio()
        If (Not Directory.Exists(rutaDirectorio)) Then
            Directory.CreateDirectory(rutaDirectorio)
        End If

    End Sub

    Private Function verificarDocumento(nombreArchivo As String) As Boolean
        If (File.Exists(rutaDirectorio & "\\" & nombreArchivo & ".pdf")) Then
            Return True
        End If
        Return False
    End Function

    Private Function Preguntar_SiNo_FichaCorporal(valor As Integer)
        If (valor = 1) Then 'SI
            Return unidad + ":\sistemgym_datos\imagenes\SI-4.png"
        Else 'NO
            Return unidad + ":\sistemgym_datos\imagenes\NO-4.png"
        End If
    End Function


    Public Sub Consentimiento_DraJulianaMeneses_RADIESSE(Logo As Bitmap, Titulo As String, Datos As CirugiaPlasticaOcularVO)

        crearDirectorio()
        ruta = rutaDirectorio & "\\Consentimiento_" & Titulo & ".pdf"
        If File.Exists(ruta) Then
            File.Delete(ruta)

        End If

        If Not File.Exists(ruta) Then

        End If
        pdfw = PdfWriter.GetInstance(docPDF, New FileStream(ruta, FileMode.Create))
        docPDF.SetPageSize(PageSize.A4)
        'docPDF.SetMargins(70.8661F, 70.8661F, 85.0394F, 85.0394F)
        'docPDF.SetPageSize(New Rectangle(612.0F, 792.0F).Rotate) 'tamaño de la página
        docPDF.SetMargins(28.34F, 28.34F, 10.0F, 10.0F) 'CONVERTIR CM A PUNTOS
        'docPDF.SetMargins(20.0F, 20.0F, 0.0F, 0.0F) 'CONVERTIR CM A PUNTOS
        docPDF.Open()

        Dim cb As PdfContentByte
        Dim colorBordes As New BaseColor(201, 128, 138) 'COLOR DE BORDES


        'y -= 150
        Dim fuente As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.TIMES, 18, iTextSharp.text.Font.BOLD).BaseFont, 18)
        Dim fuente14 As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.TIMES, 14).BaseFont, 14)
        Dim fuenteTexto As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.HELVETICA, 12).BaseFont, 12)
        Dim fuenteTextoNegrita As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.HELVETICA_BOLDOBLIQUE, 12).BaseFont, 12)
        Dim fuenteTextoNegrita2 As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12).BaseFont, 12)
        Dim fuenteTitulo14 As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, iTextSharp.text.Font.BOLD).BaseFont, 14)

        'Dim textoRojo As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.TIMES, 9, New BaseColor(255, 0, 0)).BaseFont, 9)
        Dim textoBorde = FontFactory.GetFont(FontFactory.TIMES, 26, colorBordes)
        Dim textoblanco = FontFactory.GetFont(FontFactory.TIMES, 18, BaseColor.WHITE)

        'LOGO
        fotoPDF = iTextSharp.text.Image.GetInstance(Logo, BaseColor.WHITE)
        fotoPDF.ScaleAbsolute(230, 50)

        'TABLA
        Dim tabla As New PdfPTable(New Single() {50.0F, 50.0F})
        tabla.WidthPercentage = 100.0F


        Dim cell As New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)


        cell = New PdfPCell(New Phrase("CONSENTIMIENTO INFORMADO " + Titulo, fuenteTitulo14)) With { 'LOGO
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("De conformidad con lo estipulado en la Ley 23 de 1981 y los paquetes instruccionales de Seguridad del Paciente emitidos en 2010 por Ministerio de Salud y Protección Social", fuenteTextoNegrita)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 20,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Yo " & Datos.NomPaciente1 & ", identificado con documento de identidad C.C " & Datos.CCPaciente1 & ", se me ha informado los siguientes lineamientos sobre el procedimiento de APLICACIÓN DE HIDROXIAPATITA DE CALCIO.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Cómo se llama el procedimiento?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Aplicación de Hidroxiapatita de Calcio en Cara, cuello, escote y/o manos.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)


        cell = New PdfPCell(New Phrase("¿Qué es la Hidroxiapatita de Calcio?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("La Hidroxiapatita de Calcio es una sustancia ampliamente utilizada en medicina desde hace más de 10 años en especialidades como la ortopedia y también en odontología. Es un material muy bien aceptado por el cuerpo humano.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("En estudios científicos se encontró que este material es capaz de promover la formación de colágeno alrededor del mismo durante el tiempo que se encuentra presente en el cuerpo humano. A partir de estos hallazgos se estudió y se estableció la implantación de micropartículas de hidroxiapatita de calcio debajo de la piel con fines estéticos.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("La hidroxiapatita de calcio para inyección es un dispositivo médico que se implanta debajo de la piel, que viene en jeringas pre-llenadas y puede ser aplicado puro o también puede diluirse según el uso y la zona de aplicación. Dentro de la jeringa se encuentra una suspensión compuesta por una matriz de sostén en la que se encuentran las micropartículas de hidroxiapatita de calcio. La suspensión es de consistencia tipo gel y de color blanquecino.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿La Hidroxiapatita de Calcio para inyección contiene otras sustancias diferentes a la Hidroxiapatita de Calcio?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Si. La hidroxiapatita de Calcio viene en forma de microesferas sólidas. Para que estas microesferas puedan inyectarse y acomodarse según el médico determine, deben estar suspendidas en un gel que de celulosa y agua para inyección, un material totalmente biocompatible y que se reabsorbe rápidamente.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Además, muchas preparaciones de Hidroxiapatita de calcio para inyección añaden Lidocaína en una pequeña cantidad, un anestésico local ampliamente conocido y usado en medicina y odontología con el fin de maximizar el confort del paciente al momento de la aplicación.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("El médico tratante le informará si la preparación de hidroxiapatita de calcio contiene o no Lidocaína y así mismo debes informar al médico tratante si tienes algún historial de alergia a esta sustancia.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Para qué se realiza este tratamiento?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Por su capacidad de inducir la formación de colágeno, este dispositivo se usa para mejorar el aspecto, turgencia, lozanía y tensión de la piel en cualquier parte del cuerpo. Las zonas donde más frecuentemente se implanta la hidroxiapatita de calcio son la cara, el cuello, el escote, la piel de los senos, espalda, abdomen, brazos, piernas, glúteos, manos.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Dependiendo de la forma de aplicación, cantidad y concentración también puede usarse con el fin de dar volumen a los tejidos y rellenar depresiones o arrugas.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("El médico le informará de que manera se va a usar en su caso particular y si es con el fin de otorgar volumen a los tejidos o solamente con el fin de mejorar el aspecto de la piel.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("1", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_BOTTOM,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 40,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        'SALTO DE PÁGINA
        docPDF.NewPage()

        'ENCABEZADO
        tabla = New PdfPTable(New Single() {50.0F, 50.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("CONSENTIMIENTO INFORMADO " + Titulo, fuenteTitulo14)) With { 'LOGO
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F
        cell = New PdfPCell(New Phrase("¿Cómo se realiza este tratamiento?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Se hace a través de la inyección, subdérmica (debajo de la piel) o perióstica (en la superficie del hueso) de la sustancia, usando agujas muy finas y delgadas que atraviesan lapiel y en algunos casos microcánulas que se diferencian de las agujas en tener un extremo no cortante (redondeado) para minimizar la posibilidad de sangrado o evitar la punción de un vaso sanguíneo.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Es mejor el uso de cánulas o de agujas?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Dependiendo de la anatomía y la zona a tratar del paciente se elige cuál de los dos instrumentos médicos es el más apropiado para la zona, maximizando el resultado y minimizando los riesgos. Ambos dispositivos son considerados de bajo riesgo al ser usados por un médico entrenado y con experiencia.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Todas las arrugas se pueden tratar con Hidroxiapatita de Calcio para Inyección?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("No. Algunas arrugas se originan por movimientos musculares debajo de la piel en cuyo caso se indicará tratarlas mejor con otros procedimientos como la aplicación de Toxina Botulínica Tipo A, algunas arrugas muy superficiales serán tratadas mejor con tratamientos abrasivos físicos como la microdermoabrasión o químicos como el peeling médico, otras pueden mejorar con cremas o lociones. También existen líneas de expresión consideradas normales y típicas del ser humano que no serán tratadas.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Cuándo se ven los resultados?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("En los casos donde se aplique en la forma y concentración necesaria para obtener aumento de volumen del tejido, parte de los resultados serán apreciables de forma inmediata. Sin embargo, al momento de la aplicación se producirá inflamación, puede haber sangrados, equimosis (moretones) o hematomas que pueden distorsionar temporalmente los resultados finales. Se considera que aproximadamente a los 7 días de la aplicación se pueden apreciar los resultados sin distorsión, una vez hayan cedido la inflamación, se hayan reabsorbido las equimosis o hematomas y se haya producido el efecto de hidratación de la zona.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Hacia la segunda o tercera semana de la aplicación se dejará de percibir el efecto o disminuirá debido a la reabsorción de la matriz de gel de celulosa. Después de los 21 días de la aplicación inicia la formación de colágeno a partir de las microesferas de hidroxiapatitade calcio, es decir que pasados los 30 días se recuperará la visibilidad de los resultados que habían sido percibidos durante la primera semana y que habían disminuido o desaparecido hacia la tercera semana.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("En los casos en los que la hidroxiapatita de calcio sea diluida con el fin de evitar el efecto de volumen y al ser un tratamiento de inducción de la formación del colágeno, los resultados no serán visibles sino hasta cuando el proceso de formación de colágeno se haya dado.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Tras la implantación inicial, el cuerpo humano tomará aproximadamente 21 días en INICIAR la producción de colágeno alrededor de las microesferas de hidroxiapatita de calcio, por lo que pueden llegar a ser inicialmente perceptibles los cambios en la piel del paciente a partir del día 30 aproximadamente. De ahí en adelante la cantidad de colágeno irá en aumento hasta el tiempo de duración de las microesferas de hidroxiapatita de calcio, con una mejoría gradual del aspecto de la piel.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Cuánto duran los resultados?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("En promedio los resultados son apreciables al ojo no entrenado por un tiempo de aproximadamente un año, oscilando desde 6 meses hasta 18 meses. Este tiempo puede estar afectado por factores como los estados de deshidratación crónica causados por bajo consumo de líquidos, ejercicio sin la correcta reposición de líquidos, exposición excesiva al sol, consumo frecuente de diuréticos como el café o el té o algunos medicamentos, abuso de alcohol y niveles altos de actividad física influyen de forma negativa sobre la duración del resultado.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        'NUMERACIÓN DE PÁGINA
        cell = New PdfPCell(New Phrase("2", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_BOTTOM,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 20,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        'SALTO DE PÁGINA
        docPDF.NewPage()

        'ENCABEZADO
        tabla = New PdfPTable(New Single() {50.0F, 50.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("CONSENTIMIENTO INFORMADO " + Titulo, fuenteTitulo14)) With { 'LOGO
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("¿Voy a ver el mismo resultado durante todo el tiempo de duración del efecto?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("No. En el caso del uso de la hidroxiapatita de calcio sin diluir para lograr efecto de volumen se verá inicialmente un aumento del volumen de la zona tratada que disminuye o desaparece  hacia la tercera semana. Una vez pasados los 30 días y adelante se recupera la visibilidad  de los resultados y éstos desaparecerán de forma lenta y paulatina en un periodo promedio de 1 año.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Cuando la hidroxiapatita de calcio es diluida y usada con el único fin de mejorar el aspecto de la piel, el resultado suele ser imperceptible por los primeros 30 días, luego empiezan a percibirse y a mejorar paulatinamente con los días hasta culminar el proceso de degradación de las microesferas de hidroxiapatita. Si el paciente hace sesiones adicionales, el aspecto de la piel continúa en mejoría.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Existen alternativas a este tratamiento que puedan mejorar el aspecto de mi piel y arrugas?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Si. Existen otros tratamientos orientados a la mejoría del aspecto de la piel desde no invasivos  como el uso de cremas, mascarillas y lociones, el uso de aparatos no invasivos como la radiofrecuencia o la microdermoabrasión, tratamientos mínimamente invasivos como la aplicación de inyecciones de estimuladores de colágeno y también cirugías plásticas que incluyan injertos de grasa del mismo paciente o prótesis. Sin embargo, ninguno de los  tratamientos mencionados comparte el mismo mecanismo de acción, por lo que los  resultados serían distintos a los obtenidos con la aplicación de Hidroxiapatita de Calcio.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Cuáles son los cuidados que debo tener después del tratamiento?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("No aplicar maquillaje el día del procedimiento, no entrar en contacto con superficies o agua contaminada, abstenerse de hacer ejercicio el día del procedimiento, abstenerse de entrar en cuerpos de agua como piscinas, lagos, o el mar, no consumir licor en el día del procedimiento,  no usar medicaciones distintas a las prescritas por su médico, no masajear las zonas tratadas, no manipular las zonas tratadas.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Debo volver a algún control?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("No es necesario regresar a control a menos que el paciente note algún efecto o síntoma que no haya sido advertido por el médico. Se recomienda al paciente regresar al año para hacer una nueva sesión. En caso de querer mayor nivel de volumen en los tejidos, es necesario aplicar más cantidad de producto por lo que se generarían costos adicionales.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Cuáles son los riesgos a los que me expongo al realizarme este procedimiento?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Aunque la mayoría de los pacientes no experimentan efectos adversos, secundarios y/o complicaciones, pueden aparecer después de la aplicación de Hidroxiapatita de Calcio a nivel de la cara, cuello, escote o manos los siguientes riesgos:", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Riesgos asociados al uso de agujas que atraviesan la piel de la cara, cuello, escote o manos:  Cefalea (dolor de cabeza), parestesia (alteraciones de la sensibilidad), tirantez de lapiel, dolor facial, edema (hinchazón), dolor, parálisis facial, irritación, hematomas y prurito (comezón) en el sitio de inyección, equimosis (moretones), infección de los puntos de inyección, dolor en las manos.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Riesgos asociados a la hidroxiapatita de calcio o alguna de las sustancias presentes en la preparación: Edema (hinchazón), inflamación, hematomas, enrojecimiento de la zona después de la aplicación, prurito (rasquiña), dolor, induración o nódulos en el punto de inyección, coloración o decoloración en la zona de inyección, inyecciones intravasculares accidentales (dentro de los vasos sanguíneos) que conlleven a necrosis (muerte del tejido) cutánea con o sin pérdida de tejido y cicatrices y/o ceguera permanente, abscesos, granulomas, hipersensibilidad inmediata o tardía, inflamación recurrente y persistente de las zonas tratadas (edema transitorio intermitente), alergias.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        'NUMERACIÓN DE PÁGINA
        cell = New PdfPCell(New Phrase("3", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_BOTTOM,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        'SALTO DE PÁGINA
        docPDF.NewPage()

        'ENCABEZADO
        tabla = New PdfPTable(New Single() {50.0F, 50.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("CONSENTIMIENTO INFORMADO " + Titulo, fuenteTitulo14)) With { 'LOGO
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("En el caso extremadamente raro de complicaciones por inyección intravascular (dentro de un vaso sanguíneo) no existe forma de diluir o degradar la sustancia para restablecer el flujo de sangre.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Pueden existir efectos secundarios y/o adversos que no estén descritos anteriormente debido  a la respuesta biológica única e irrepetible de cada persona ante un procedimiento o medicamento. Sin embargo han sido mencionados los que figuran en la literatura científica.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Hay alguna forma de minimizar los riesgos?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Si. En primer lugar proveer toda la información que el médico tratante pregunte, no ocultar nada de la historia clínica, informar de tratamientos previos o eventos adversos previos si los hubiera, informar acerca de todos los medicamentos que esté tomando en este momento, no tomar medicamentos que favorezcan el sangrado en los 3 a 7 días previos como aspirina, antiinflamatorios, o suplementos como el omega o las vitaminas. Mantener una higiene del área tratada, no manipular las zonas tratadas y seguir todas las indicacionesque el médico ordene.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Además, el entrenamiento y amplio conocimiento del médico tratante permitirá reducir la posibilidad de algunos de los eventos adversos.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Hay alguna forma de GARANTIZAR que no ocurran eventos adversos, efectos secundarios o complicaciones?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("No. No existe forma de garantizarlo.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Hay alguna forma de NO CORRER NINGÚN RIESGO?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Si. Abstenerse de realizarse el procedimiento lo mantendrá libre de todo riesgo asociado al procedimiento.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Es posible que el tratamiento no surta ningún efecto en mi caso?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Si. Existen arrugas que aunque sean rellenadas pueden no desaparecer por completo.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Están garantizados los resultados positivos y a mi agrado?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("No. Garantizamos que usamos el dispositivo adecuado y en cumplimiento con la ley vigente de las entidades sanitarias, garantizamos que quien realiza el procedimiento se encuentra plenamente capacitado para ello y cuenta con experiencia suficiente, garantizamos que los métodos usados cumplen con los estándares de calidad y académicos a nivel mundial, sin embargo la práctica de la medicina no es una ciencia exacta, y aunque se esperan buenos resultados no hay garantía explícita de que puedan obtenerse, pues están afectados por factores intrínsecos y extrínsecos del paciente.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Qué pasa si no me gusta el resultado y/o quiero eliminar el dispositivo de mi cuerpo?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Las microesferas de hidroxiapatita de calcio se degradan por sí solas en un periodo de aproximadamente 18 meses y deben desaparecer del cuerpo una vez transcurridos los tiempos mencionados anteriormente. Sin embargo, no existe ninguna forma de retirar el material aplicado antes de degradación espontánea y tampoco se conoce ninguna sustancia o procedimiento que haya probado en la literatura científica poder degradar más rápidamente la hidroxiapatita de Calcio.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Si no me agrada el resultado se me devolverá el dinero?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Como se explicó antes, no es posible asegurar el resultado y toda realización del procedimiento genera un costo independientemente del resultado, por este motivo no habrá lugar a devoluciones una vez haya sido realizado el procedimiento. Sin embargo, si el procedimiento aún no ha tenido lugar, el paciente está en todo su derecho de cambiar de opinión y solicitar la devolución del dinero pagado", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        'NUMERACIÓN DE PÁGINA
        cell = New PdfPCell(New Phrase("4", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_BOTTOM,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 40,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        'SALTO DE PÁGINA
        docPDF.NewPage()

        'ENCABEZADO
        tabla = New PdfPTable(New Single() {50.0F, 50.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("CONSENTIMIENTO INFORMADO " + Titulo, fuenteTitulo14)) With { 'LOGO
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("Certifico que el presente documento ha sido leído y entendido por mi en su integridad.  Doy fe que no he omitido o alterado datos al exponer mi historial clínico y antecedentes clínico-quirúrgicos.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Certifico que lo aquí escrito me ha sido explicado adicionalmente de forma personal por mi médico y que ha respondido de forma satisfactoria a todas las preguntas adicionales que he tenido.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Declaro haber comprendido cuáles son los cuidados posteriores al tratamiento y exonero a mi médico tratante de cualquier responsabilidad derivada del incumplimiento de los mismos.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Me ha sido explicado de forma comprensible el procedimiento de aplicación de hidroxiapatita de calcio, los procedimientos alternativos u otros métodos de tratamiento, los riesgos del procedimiento de aplicación de hidroxiapatita de calcio, y que estoy en total libertad de elegir no correr ningún riesgo a través de la abstención de la realización del procedimiento aquí descrito.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Anexo Covid 19:", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Es posible que después de un tratamiento médico, su sistema inmunológico se pueda ver comprometido y por ende facilitar el riesgo de contagio frente a esta enfermedad, por lo cual se han tomado y debe tomar medidas por mitigar su contagio, sin embargo este riesgo existe y por ello se le hace entrega de un instructivo para mitigareste riesgo en el momento que solicita su cita, además será atendido bajo protocolos de seguridad que disminuyan el riesgo de un posible contagio durante la atención médica. En caso de que se presente la enfermedad, tomará las medidas sanitarias necesarias de aislamiento social para salvaguardar la salud de todas las personas de su entorno, dicha enfermedad podría llegar a afectar los resultados del tratamiento realizado y también comprometer de manera importante su salud.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Medidas de Mitigación Covid 19:", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Aseguró no haber estado en contacto con mi familia, amigos, y en el trabajo que presenten síntomas respiratorios o sugestivos de Covid 19 o que sean Covid 19 positivos en el último mes. No he tenido síntomas como tos, fiebre, malestar general, fatiga, alteración del olfato, alteraciones del gusto o cualquier otro síntoma relacionado con Covid 19 en el último mes. He cumplido con las medidas preventivas de contagio de Covid 19 como lavado de manos, uso de tapabocas y lentes protectores, distanciamiento social de mínimo 2 metros con otras personas, desinfección adecuada de alimentos, superficies y además en mi entorno, con el fin de evitar el riesgo de contagiarme. En caso de iniciar algún síntoma posterior a la realización del tratamiento, me pondré inmediatamente en contacto con mi médico tratante para evaluar la posibilidad de un posible contagio con Covid 19. En caso de no cumplir con estas medidas enunciadas para evitar el contagio, el médico podrá negarse a la realización de mi consulta y procedimiento.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Autorizo a la Dra. JULIANA MENESES PEREZ a llevar a cabo en mi cuerpo el procedimiento APLICACIÓN DE HIDROXIAPATITA DE CALCIO.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        '''parte de las firmas 

        tabla = New PdfPTable(New Single() {10.0F, 35.0F, 10.0F, 35.0F, 10.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)

        fotoPDF = iTextSharp.text.Image.GetInstance(Datos.FirmaPaciente1)
        fotoPDF.ScaleAbsolute(180, 45)
        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .PaddingBottom = 5,
            .Border = 0,
            .BorderWidthBottom = 1
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)

        fotoPDF = iTextSharp.text.Image.GetInstance(Datos.FirmaProfesional1)
        fotoPDF.ScaleAbsolute(180, 45)
        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .PaddingBottom = 5,
            .Border = 0,
            .BorderWidthBottom = 1
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)

        'TEXTO FIRMAS

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("FIRMA DEL PACIENTE", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("FIRMA DEL PROFESIONAL", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)
        'CC
        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("CC: " & Datos.CCPaciente1, fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("JULIANA MENESES PEREZ", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        'FECHA
        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)
        Dim fecha As Date = Now.Date
        cell = New PdfPCell(New Phrase("FECHA: " & fecha, fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("TP – R.M. 543677", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        'NUMERACIÓN DE PÁGINA
        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F
        cell = New PdfPCell(New Phrase("5", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_BOTTOM,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        docPDF.Close()
        docPDF.Dispose()
        'MsgBox("siii")
        Dim msgBoxResult = MsgBox("Documento prueba generado")
        Dim Proc As New System.Diagnostics.Process
        Proc.StartInfo.FileName = ruta
        Proc.Start()


    End Sub

    Public Sub Consentimiento_TOXINA_BOTULINICA_A(Logo As Bitmap, Titulo As String, Datos As CirugiaPlasticaOcularVO)

        crearDirectorio()
        ruta = rutaDirectorio & "\\Consentimiento_" & Titulo & ".pdf"
        If File.Exists(ruta) Then
            File.Delete(ruta)

        End If

        If Not File.Exists(ruta) Then

        End If
        pdfw = PdfWriter.GetInstance(docPDF, New FileStream(ruta, FileMode.Create))
        docPDF.SetPageSize(PageSize.A4)
        'docPDF.SetMargins(70.8661F, 70.8661F, 85.0394F, 85.0394F)
        'docPDF.SetPageSize(New Rectangle(612.0F, 792.0F).Rotate) 'tamaño de la página
        docPDF.SetMargins(28.34F, 28.34F, 10.0F, 10.0F) 'CONVERTIR CM A PUNTOS
        'docPDF.SetMargins(20.0F, 20.0F, 0.0F, 0.0F) 'CONVERTIR CM A PUNTOS
        docPDF.Open()

        Dim cb As PdfContentByte
        Dim colorBordes As New BaseColor(201, 128, 138) 'COLOR DE BORDES


        'y -= 150
        Dim fuente As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.TIMES, 18, iTextSharp.text.Font.BOLD).BaseFont, 18)
        Dim fuente14 As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.TIMES, 14).BaseFont, 14)
        Dim fuenteTexto As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.HELVETICA, 12).BaseFont, 12)
        Dim fuenteTextoNegrita As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.HELVETICA_BOLDOBLIQUE, 12).BaseFont, 12)
        Dim fuenteTextoNegrita2 As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12).BaseFont, 12)
        Dim fuenteTitulo14 As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, iTextSharp.text.Font.BOLD).BaseFont, 14)

        'Dim textoRojo As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.TIMES, 9, New BaseColor(255, 0, 0)).BaseFont, 9)
        Dim textoBorde = FontFactory.GetFont(FontFactory.TIMES, 26, colorBordes)
        Dim textoblanco = FontFactory.GetFont(FontFactory.TIMES, 18, BaseColor.WHITE)

        'LOGO
        fotoPDF = iTextSharp.text.Image.GetInstance(Logo, BaseColor.WHITE)
        fotoPDF.ScaleAbsolute(230, 50)

        'TABLA
        Dim tabla As New PdfPTable(New Single() {50.0F, 50.0F})
        tabla.WidthPercentage = 100.0F


        Dim cell As New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)


        cell = New PdfPCell(New Phrase("CONSENTIMIENTO INFORMADO " + Titulo, fuenteTitulo14)) With { 'LOGO
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("De conformidad con lo estipulado en la Ley 23 de 1981 y los paquetes instruccionales de Seguridad del Paciente emitidos en 2010 por Ministerio de Salud y Protección Social", fuenteTextoNegrita)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 20,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Yo " & Datos.NomPaciente1 & ", identificado con documento de identidad C.C " & Datos.CCPaciente1 & ", se me ha informado los siguientes lineamientos sobre el procedimiento de APLICACIÓN DE TOXINA BOTULÍNICA TIPO A en cara y/o cuello.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Cómo se llama el procedimiento?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Aplicación de Toxina Botulínica Tipo A en cara y/o cuello", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)


        cell = New PdfPCell(New Phrase("¿Qué es la Toxina Botulínica Tipo A?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Es un medicamento que produce la relajación de los músculos donde se aplica. Esta relajación es transitoria y el músculo recuperará su fuerza original al cabo de cierto tiempo.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Para qué se realiza este tratamiento?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Los movimientos de los músculos debajo de la piel de la cara y del cuello se encargan de generar todos los gestos normales en una persona. Sin embargo, con el tiempo esta constante gesticulación produce marcas a nivel de la piel, más conocidas como arrugas. El tratamiento con Toxina Botulínica Tipo A, busca relajar esta musculatura para que en consecuencia los dobleces y marcas en la piel sean menos visibles o se evite su aparición.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Cómo se realiza este tratamiento?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Se hace a través de la inyección intramuscular del medicamento, usando agujas muy finas y delgadas que atraviesan la piel.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Todas las arrugas se pueden tratar con Toxina Botulínica Tipo A?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("No. Solamente aquellas asociadas a los movimientos musculares debajo de la piel, las más frecuentes son las líneas de la frente al levantar los ojos, las líneas en el entrecejo al fruncir el ceño y algunas de las líneas alrededor de los ojos al sonreír. También se pueden tratar las líneas o depresiones que se forman a nivel del mentón al hablar o hacer gestos de tristeza, se puede disminuir la caída de las comisuras (esquinas de la boca) cuando dependen de un movimiento muscular exagerado, se puede disminuir el tamaño de los músculos masticadores llamados maseteros cuando el paciente presenta una condición llamada bruxismo (mordida nocturna), se puede usar para disminuir la elevación excesiva del labio superior al sonreír llamada sonrisa gingival, se puede usar para disminuir algunas líneas del cuello siempre y cuando sean causadas por la contracción de un músculo llamado platisma, se puede usar para mejorar el contorno inferior de la cara cuando el músculo platisma actúa de forma excesiva, se puede usar para evitar o mejorar la caída de la punta nasal cuando se detecta actividad excesiva de un músculo llamado depresor de la punta nasal y se puede usar en microdosis muy superficialmente en toda la piel de la cara para mejorar el aspecto de la piel y disminuir la sudoración o el exceso de producción de grasa.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿La Toxina Botulínica Tipo A rellena las arrugas?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("No. Solamente tiene efecto sobre los músculos debajo de la piel. No produce ningún efecto de relleno o aumento de volumen del tejido tratado.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Existen alternativas a este tratamiento que puedan mejorar el aspecto de mi piel y arrugas?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Si. Existen otros tratamientos orientados a la mejoría del aspecto de la piel desde no invasivos como el uso de cremas, mascarillas y lociones, el uso de aparatos no invasivos como la radiofrecuencia o la microdermoabrasión, tratamientos mínimamente invasivos como la aplicación de inyecciones de estimuladores de colágeno y también cirugías plásticas. Sin embargo, ninguno de los tratamientos mencionados comparte el mismo mecanismo de acción, por lo que los resultados serían distintos a los obtenidos con la aplicación de Toxina Botulínica Tipo A.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        'NUMERACIÓN
        cell = New PdfPCell(New Phrase("1", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_BOTTOM,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        '--SALTO DE PÁGINA--
        docPDF.NewPage()

        '---ENCABEZADO---
        tabla = New PdfPTable(New Single() {50.0F, 50.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("CONSENTIMIENTO INFORMADO " + Titulo, fuenteTitulo14)) With { 'LOGO
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)
        '---FIN ENCABEZADO---

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("¿Cuándo se ven los resultados?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Lo más común es que empiecen a hacerse visibles hacia el tercer día de la aplicación y su resultado alcanzará su pico máximo entre el día 10 y 15 después de la aplicación. Recuerda  que los tiempos aquí descritos son los tiempos promedio, esto significa que aunque la gran mayoría reaccionan de esta manera, pueden existir pacientes que muestren los cambios antes, o después.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Cuánto duran los resultados?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("El efecto de la toxina Botulínica tiene una duración promedio de 120 días, es decir 4 meses. Esto significa que habrán pacientes a quienes les dure menos de 4 meses y pacientes que les dure más de 4 meses. Se ha comprobado también que la realización de actividad física frecuente acorta el efecto de la Toxina Botulínica Tipo A.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Voy a ver el mismo resultado durante todo el tiempo de duración del efecto?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("No. como ha sido explicado antes, el efecto empieza a ser visible a los 3 días aproximadamente, alcanza un punto máximo hacia el día 15, momento desde el cual inicia su descenso paulatino y gradual hasta volver al punto inicial. Es decir que los resultados no se mantienen estáticos hasta el día final de duración, sino que van lentamente desapareciendo. En promedio si el efecto de la toxina botulínica Tipo A dura 120 días (4 meses) es probable que en la mitad de ese tiempo (60) días, ya se tenga una pérdida del Resultado inicial que se encuentre en algún punto entre el efecto del día 15 y el estado previo a la aplicación.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Las dosis (unidades) aplicadas influyen en el resultado?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Si. Principalmente en la duración del mismo. Aplicar dosis por debajo de las recomendadas acorta el tiempo de duración de los resultados, por esta razón el médico aplicará siempre las dosis completas.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Puedo elegir la dosis (unidades) para mi tratamiento?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("No. Existen dosis determinadas para cada área según estudios clínicos científicos que definen la cantidad necesaria de unidades para conseguir el efecto deseado. El médico usará las dosis que se conocen como dosis efectivas para cada caso, evitando que exista una subdosificación (poner menos unidades de las necesarias) que conduzca a un resultado insatisfactorio.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Cuáles son los cuidados que debo tener después del tratamiento?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("No aplicar maquillaje el día del procedimiento, no entrar en contacto con superficies o agua contaminada, abstenerse de hacer ejercicio el día del procedimiento, abstenerse de entrar en cuerpos de agua como piscinas, lagos, o el mar, no consumir licor en el día del procedimiento, no usar medicaciones distintas a las prescritas por su médico, no masajear las zonas tratadas, no manipular las zonas tratadas, no acostarse a dormir hasta tanto no hayan transcurrido 4 horas después de la aplicación del medicamento.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Debo volver a algún control?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Si. Se recomienda que asistas a una cita de control entre el día 10 y 15 después de la aplicación. Esto permitirá en algunos casos, no en todos, realizar pequeños ajustes adicionales a los resultados. No debes asistir antes, pues los resultados aún no serán evaluables, y aunque puedes asistir después del día 15 solamente servirá para tomar nota de los resultados pues no se recomienda realizar re-aplicaciones pasados los 15 días. En ese caso se debe esperar un tiempo mínimo de 3 meses.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Cuáles son los riesgos a los que me expongo al realizarme este procedimiento?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Aunque la mayoría de los pacientes no experimentan efectos adversos, secundarios y/o complicaciones, pueden aparecer después de la aplicación de la toxina botulínica a nivel de la cara o cuello los siguientes riesgos:", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        '---salto
        'NUMERACIÓN
        cell = New PdfPCell(New Phrase("2", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_BOTTOM,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 40,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        '--SALTO DE PÁGINA--
        docPDF.NewPage()

        '---ENCABEZADO---
        tabla = New PdfPTable(New Single() {50.0F, 50.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("CONSENTIMIENTO INFORMADO " + Titulo, fuenteTitulo14)) With { 'LOGO
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)
        '---FIN ENCABEZADO---

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("Riesgos asociados al uso de agujas que atraviesan la piel de la cara y/o cuello: Cefalea (dolor de cabeza), parestesia (alteraciones de la sensibilidad), tirantez de la piel, dolor facial,edema (hinchazón), dolor, parálisis facial, irritación, hematomas y prurito (comezón) en el sitio de inyección, equimosis (moretones), infección de los puntos de inyección.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Riesgos asociados al medicamento: Raramente diplopía (visión doble), ptosis de alguno o ambos párpados (caída de los párpados), debilidad muscular, nódulos inflamatorios persistentes en los sitios de inyección, alteraciones en la deglución de alimentos y saliva (dificultad para tragar), asimetrías faciales en reposo o al realizar movimientos, dificultad para retener líquidos en la boca.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Pueden existir efectos secundarios y/o adversos que no estén descritos anteriormente debido a la respuesta biológica única e irrepetible de cada persona ante un procedimiento o medicamento. Sin embargo han sido mencionados los que figuran en la literatura científica.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Hay alguna forma de minimizar los riesgos?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Si. En primer lugar proveer toda la información que el médico tratante pregunte, no ocultar nada de la historia clínica, informar de tratamientos previos o eventos adversos previos si los hubiera, informar acerca de todos los medicamentos que esté tomando este momento, no tomar medicamentos que favorezcan el sangrado en los 3 a 7 días previos como aspirina, antiinflamatorios, o suplementos como el omega o las vitaminas. Mantener una higiene del área tratada, no manipular las zonas tratadas y seguir todas las indicaciones que el médico ordene.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Además, el entrenamiento y amplio conocimiento del médico tratante permitirá reducir la posibilidad de algunos de los eventos adversos.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Hay alguna forma de GARANTIZAR que no ocurran eventos adversos, efectos secundarios o complicaciones?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("No. No existe forma de garantizarlo.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Hay alguna forma de NO CORRER NINGÚN RIESGO?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Si. Abstenerse de realizarse el procedimiento lo mantendrá libre de todo riesgo asociado al procedimiento.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Es posible que el tratamiento no surta ningún efecto en mi caso?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Si. Existen casos documentados en la literatura médica de pacientes que son resistentes al medicamento. También se ha documentado que en algunas personas puede desarrollarse resistencia al repetir el tratamiento por lo que es posible que aunque hubiera funcionado antes, no haya efecto en una futura aplicación, esto ocurre generalmente cuando el paciente hace de forma repetida aplicaciones en períodos de tiempo menores a 3 meses.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Están garantizados los resultados positivos y a mi agrado?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("No. Garantizamos que usamos el medicamento adecuado y en cumplimiento con la ley vigente de las entidades sanitarias, garantizamos que quien realiza el procedimiento se encuentra plenamente capacitado para ello y cuenta con experiencia suficiente, garantizamos que los métodos usados cumplen con los estándares de calidad y académicos a nivel mundial, sin embargo la práctica de la medicina no es una ciencia exacta, y aunque se esperan buenos resultados no hay garantía explícita de que puedan obtenerse, pues están afectados por factores intrínsecos y extrínsecos del paciente", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        '------------------------

        cell = New PdfPCell(New Phrase("¿Qué pasa si no me gusta el resultado y quiero eliminar el efecto del medicamento?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("La primera opción es esperar a que el resultado ceda por sí mismo. En caso de querer acelerar el proceso, se ha documentado en la literatura médica que el uso de la radiofrecuencia puede algunas veces hacer que el efecto pase más rápidamente. Los gastos que se generen en este caso no serán cubiertos por el médico tratante.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        'salto
        'NUMERACIÓN DE PÁGINA
        cell = New PdfPCell(New Phrase("3", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_BOTTOM,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        'SALTO DE PÁGINA
        docPDF.NewPage()

        'ENCABEZADO
        tabla = New PdfPTable(New Single() {50.0F, 50.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("CONSENTIMIENTO INFORMADO " + Titulo, fuenteTitulo14)) With { 'LOGO
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("¿Si no me agrada el resultado se me devolverá el dinero?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Como se explicó antes, no es posible asegurar el resultado y toda realización del procedimiento genera un costo independientemente del resultado, por este motivo no habrá lugar a devoluciones una vez haya sido realizado el procedimiento. Sin embargo, si el procedimiento aún no ha tenido lugar, el paciente está en todo su derecho de cambiar de opinión y solicitar la devolución del dinero pagado", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Certifico que el presente documento ha sido leído y entendido por mi en su integridad.  Doy fe que no he omitido o alterado datos al exponer mi historial clínico y antecedentes clínico-quirúrgicos.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Certifico que lo aquí escrito me ha sido explicado adicionalmente de forma personal por mi médico y que ha respondido de forma satisfactoria a todas las preguntas adicionales que he tenido.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Declaro haber comprendido cuáles son los cuidados posteriores al tratamiento y exonero a mi médico tratante de cualquier responsabilidad derivada del incumplimiento de los mismos.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Me ha sido explicado de forma comprensible el procedimiento de aplicación de toxina botulínica tipo A, los procedimientos alternativos u otros métodos de tratamiento, los riesgos del procedimiento de aplicación de toxina botulínica tipo A, y que estoy en total libertad de elegir no correr ningún riesgo a través de la abstención de la realización del procedimiento aquí descrito.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Anexo Covid 19:", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Es posible que después de un tratamiento médico, su sistema inmunológico se pueda ver comprometido y por ende facilitar el riesgo de contagio frente a esta enfermedad, por lo cual se han tomado y debe tomar medidas por mitigar su contagio, sin embargo este riesgo existe y por ello se le hace entrega de un instructivo para mitigareste riesgo en el momento que solicita su cita, además será atendido bajo protocolos de seguridad que disminuyan el riesgo de un posible contagio durante la atención médica. En caso de que se presente la enfermedad, tomará las medidas sanitarias necesarias de aislamiento social para salvaguardar la salud de todas las personas de su entorno, dicha enfermedad podría llegar a afectar los resultados del tratamiento realizado y también comprometer de manera importante su salud.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Medidas de Mitigación Covid 19:", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Aseguró no haber estado en contacto con mi familia, amigos, y en el trabajo que presenten síntomas respiratorios o sugestivos de Covid 19 o que sean Covid 19 positivos en el último mes. No he tenido síntomas como tos, fiebre, malestar general, fatiga, alteración del olfato, alteraciones del gusto o cualquier otro síntoma relacionado con Covid 19 en el último mes. He cumplido con las medidas preventivas de contagio de Covid 19 como lavado de manos, uso de tapabocas y lentes protectores, distanciamiento social de mínimo 2 metros con otras personas, desinfección adecuada de alimentos, superficies y además en mi entorno, con el fin de evitar el riesgo de contagiarme. En caso de iniciar algún síntoma posterior a la realización del tratamiento, me pondré inmediatamente en contacto con mi médico tratante para evaluar la posibilidad de un posible contagio con Covid 19. En caso de no cumplir con estas medidas enunciadas para evitar el contagio, el médico podrá negarse a la realización de mi consulta y procedimiento.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        'salto
        'NUMERACIÓN DE PÁGINA
        cell = New PdfPCell(New Phrase("4", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_BOTTOM,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 80,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        'SALTO DE PÁGINA
        docPDF.NewPage()

        'ENCABEZADO
        tabla = New PdfPTable(New Single() {50.0F, 50.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("CONSENTIMIENTO INFORMADO " + Titulo, fuenteTitulo14)) With { 'LOGO
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("Autorizo a la Dra. JULIANA MENESES PEREZ a llevar a cabo en mi rostro y/o cuello el procedimiento APLICACIÓN DE TOXINA BOTULÍNICA TIPO A.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        '''parte de las firmas 

        tabla = New PdfPTable(New Single() {10.0F, 35.0F, 10.0F, 35.0F, 10.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)

        fotoPDF = iTextSharp.text.Image.GetInstance(Datos.FirmaPaciente1)
        fotoPDF.ScaleAbsolute(180, 45)
        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .PaddingBottom = 5,
            .Border = 0,
            .BorderWidthBottom = 1
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)

        fotoPDF = iTextSharp.text.Image.GetInstance(Datos.FirmaProfesional1)
        fotoPDF.ScaleAbsolute(180, 45)
        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .PaddingBottom = 5,
            .Border = 0,
            .BorderWidthBottom = 1
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)

        'TEXTO FIRMAS

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("FIRMA DEL PACIENTE", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("FIRMA DEL PROFESIONAL", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)
        'CC
        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("CC: " & Datos.CCPaciente1, fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("JULIANA MENESES PEREZ", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        'FECHA
        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)
        Dim fecha As Date = Now.Date
        cell = New PdfPCell(New Phrase("FECHA: " & fecha, fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("TP – R.M. 543677", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        'NUMERACIÓN DE PÁGINA
        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F
        cell = New PdfPCell(New Phrase("5", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_BOTTOM,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 550,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)


        docPDF.Close()
        docPDF.Dispose()
        'MsgBox("siii")
        Dim msgBoxResult = MsgBox("Documento prueba generado")
        Dim Proc As New System.Diagnostics.Process
        Proc.StartInfo.FileName = ruta
        Proc.Start()

    End Sub

    Public Sub Consentimiento_ACIDO_HIALURONICO_RETICULADO(Logo As Bitmap, Name As String, Datos As CirugiaPlasticaOcularVO)

        crearDirectorio()
        ruta = rutaDirectorio & "\\Consentimiento_" & Name & ".pdf"
        If File.Exists(ruta) Then
            File.Delete(ruta)

        End If

        If Not File.Exists(ruta) Then

        End If
        pdfw = PdfWriter.GetInstance(docPDF, New FileStream(ruta, FileMode.Create))
        docPDF.SetPageSize(PageSize.A4)
        'docPDF.SetMargins(70.8661F, 70.8661F, 85.0394F, 85.0394F)
        'docPDF.SetPageSize(New Rectangle(612.0F, 792.0F).Rotate) 'tamaño de la página
        docPDF.SetMargins(28.34F, 28.34F, 10.0F, 10.0F) 'CONVERTIR CM A PUNTOS
        'docPDF.SetMargins(20.0F, 20.0F, 0.0F, 0.0F) 'CONVERTIR CM A PUNTOS
        docPDF.Open()

        Dim cb As PdfContentByte
        Dim colorBordes As New BaseColor(201, 128, 138) 'COLOR DE BORDES


        'y -= 150
        Dim fuente As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.TIMES, 18, iTextSharp.text.Font.BOLD).BaseFont, 18)
        Dim fuente14 As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.TIMES, 14).BaseFont, 14)
        Dim fuenteTexto As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.HELVETICA, 12).BaseFont, 12)
        Dim fuenteTextoNegrita As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.HELVETICA_BOLDOBLIQUE, 12).BaseFont, 12)
        Dim fuenteTextoNegrita2 As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12).BaseFont, 12)
        Dim fuenteTitulo14 As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, iTextSharp.text.Font.BOLD).BaseFont, 14)

        'Dim textoRojo As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.TIMES, 9, New BaseColor(255, 0, 0)).BaseFont, 9)
        Dim textoBorde = FontFactory.GetFont(FontFactory.TIMES, 26, colorBordes)
        Dim textoblanco = FontFactory.GetFont(FontFactory.TIMES, 18, BaseColor.WHITE)

        'LOGO
        fotoPDF = iTextSharp.text.Image.GetInstance(Logo, BaseColor.WHITE)
        fotoPDF.ScaleAbsolute(230, 50)

        'TABLA
        Dim tabla As New PdfPTable(New Single() {50.0F, 50.0F})
        tabla.WidthPercentage = 100.0F


        Dim cell As New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)

        Dim Titulo As String = "ÁCIDO HIALURÓNICO RETICULADO EN CARA, CUELLO, ESCOTE Y/O MANOS"

        cell = New PdfPCell(New Phrase("CONSENTIMIENTO INFORMADO " + Titulo, fuenteTitulo14)) With { 'LOGO
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("De conformidad con lo estipulado en la Ley 23 de 1981 y los paquetes instruccionales de Seguridad del Paciente emitidos en 2010 por Ministerio de Salud y Protección Social", fuenteTextoNegrita)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 20,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Yo " & Datos.NomPaciente1 & ", identificado con documento de identidad C.C " & Datos.CCPaciente1 & ", se me ha informado los siguientes lineamientos sobre el procedimiento de APLICACIÓN DE ÁCIDO HIALURÓNICO.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Cómo se llama el procedimiento?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Aplicación de Ácido Hialurónico Reticulado en Cara, cuello, escote y/o manos.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)


        cell = New PdfPCell(New Phrase("¿Qué es el Ácido Hialurónico?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("El Ácido Hialurónico es una sustancia presente en muchos tejidos del cuerpo humano, especialmente en la piel y en el tejido debajo de ella que se produce naturalmente todos los días desde que nacemos. El Ácido Hialurónico Reticulado para inyección es un dispositivo médico sintetizado en un laboratorio de origen NO animal considerado biológicamente idéntico al humano.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿El Ácido Hialurónico Reticulado para inyección contiene otras sustancias diferentes al ácido hialurónico?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Si. El ácido hialurónico puro (sin otras sustancias) es un componente que se degrada a gran velocidad (horas o días) al ser aplicado en el cuerpo humano por la acción de unas moléculas llamadas enzimas que están presentes en el tejido de todos los seres humanos.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Con el fin de alargar el tiempo de duración del producto aplicado se añaden sustancias conocidas como Agentes Reticulantes. Estas sustancias tienen como función impedir que el ácido hialurónico sea degradado rápidamente y retrasa su absorción para que sea más lenta (varios meses). El agente reticulante más frecuentemente presente en las formulaciones de ácido hialurónico reticulado es el Butanodiol Diglicidil Éter, por sus siglas BDDE, el cual ha sido usado con éxito por más de 10 años en las preparaciones de Ácido Hialurónico inyectable. Sin embargo debido a los constantes avances de la tecnología en dispositivos médicos inyectables de ácido hialurónico pueden existir agentes reticulantes distintos al BDDE o inclusive no contenerlo.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Además, muchas preparaciones de Ácido Hialurónico Reticulado para inyección añaden Lidocaína en una pequeña cantidad, un anestésico local ampliamente conocido y usado en medicina y odontología con el fin de maximizar el confort del paciente al momento de la aplicación.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("El médico tratante le informará si el Ácido Hialurónico Reticulado contiene o no Lidocaína y así mismo debes informar al médico tratante si tienes algún historial de alergia a esta sustancia.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Para qué se realiza este tratamiento?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("El Ácido Hialurónico tiene dos funciones principales, la primera de ellas es ocupar un espacio donde se aplica, es decir otorgar volúmen al área tratada. En segundo lugar, el ácido hialurónico absorbe y retiene agua por lo que ocurre también un efecto de hidratación en el área. A través de su aplicación se consigue la restauración del volumen perdido, el relleno de algunas líneas de expresión y/o arrugas.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("El ácido hialurónico puede ser usado a nivel facial para rellenar arrugas finas a nivel de la piel, también para dar volumen a nivel de las cejas, pómulos, reborde de la cara, mentón, y labios, para rellenar depresiones debajo de los ojos (ojeras), para devolver volumen perdido a nivel de las mejillas, y para rellenar o cambiar la forma de la nariz. También se usa en cantidades pequeñas para dar hidratación a la piel con o sin la adición de volumen a la zona tratada.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        ''SALTO----
        'NUMERACIÓN
        cell = New PdfPCell(New Phrase("1", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_BOTTOM,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        '--SALTO DE PÁGINA--
        docPDF.NewPage()

        '---ENCABEZADO---
        tabla = New PdfPTable(New Single() {50.0F, 50.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("CONSENTIMIENTO INFORMADO " + Titulo, fuenteTitulo14)) With { 'LOGO
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)
        '---FIN ENCABEZADO---

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("A nivel del cuello y escote puede ser usado para hidratar la zona o también para rellenar arrugas.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("A nivel de las manos puede ser usado para hidratar la piel con o sin la adición de volumen perdido en las manos.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Cómo se realiza este tratamiento?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Se hace a través de la inyección intradérmica (en la piel), subdérmica (debajo de la piel) o perióstica (en la superficie del hueso) de la sustancia, usando agujas muy finas y delgadas que atraviesan la piel y en algunos casos microcánulas que se diferencian de las agujas en tener un extremo no cortante (redondeado) para minimizar la posibilidad de sangrado o evitar la punción de un vaso sanguíneo.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Es mejor el uso de cánulas o de agujas?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Dependiendo de la anatomía y la zona a tratar del paciente se elige cuál de los dos instrumentos médicos es el más apropiado para la zona, maximizando el resultado y minimizando los riesgos. Ambos dispositivos son considerados de bajo riesgo al ser usados por un médico entrenado y con experiencia.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Todas las arrugas se pueden tratar con Ácido Hialurónico Reticulado para Inyección?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("No. Algunas arrugas se originan por movimientos musculares debajo de la piel en cuyo caso se indicará tratarlas mejor con otros procedimientos como la aplicación de Toxina Botulínica Tipo A, algunas arrugas muy superficiales serán tratadas mejor con tratamientos abrasivos físicos como la microdermoabrasión o químicos como el peeling médico, otras pueden mejorar con cremas o lociones. También existen líneas de expresión consideradas normales y típicas del ser humano que no serán tratadas.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Cuándo se ven los resultados?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Parte de los resultados serán apreciables de forma inmediata. Sin embargo, al momento de la aplicación se producirá inflamación, puede haber sangrados, equimosis (moretones) o hematomas que pueden distorsionar temporalmente los resultados finales. Se considera que aproximadamente a los 15 días de la aplicación se pueden apreciar los resultados finales, una vez hayan cedido la inflamación, se hayan reabsorbido las equimosis o hematomas y se haya producido el efecto de hidratación de la zona.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Cuánto duran los resultados?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("En promedio los resultados son apreciables al ojo no entrenado por un tiempo de aproximadamente un año, oscilando desde 6 meses hasta 18 meses. Este tiempo puede estar afectado por factores como:", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Dureza y densidad del Ácido Hialurónico usado: Algunas preparaciones son más duras y densas que otras, se seleccionarán de acuerdo a la zona de uso, prefiriendo preparaciones menos duras en áreas más delgadas y delicadas como el área alrededor de los ojos y más duras y densas en áreas donde se requiere más volumen. Las preparaciones más duras y densas suelen durar más que las más suaves y menos densas.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Tecnología de Reticulación: La tecnología de reticulación (que es el proceso mediante el cual se añaden componentes que demoran la degradación del dispositivo) influye sobre la duración. Algunas tecnologías ofrecen más duración que otras, manteniéndose todas cerca del promedio.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Factores propios del paciente: Los estados de deshidratación crónica causados por bajo consumo de líquidos, ejercicio sin la correcta reposición de líquidos, exposición excesiva al sol, consumo frecuente de diuréticos como el café o el té o algunos medicamentos, abuso de alcohol y niveles altos de actividad física influyen de forma negativa sobre la duración del ácido hialurónico.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        'SALTO---
        '---salto
        'NUMERACIÓN
        cell = New PdfPCell(New Phrase("2", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_BOTTOM,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 20,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        '--SALTO DE PÁGINA--
        docPDF.NewPage()

        '---ENCABEZADO---
        tabla = New PdfPTable(New Single() {50.0F, 50.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("CONSENTIMIENTO INFORMADO " + Titulo, fuenteTitulo14)) With { 'LOGO
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)
        '---FIN ENCABEZADO---

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("¿Voy a ver el mismo resultado durante todo el tiempo de duración del efecto?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("No. La dosis necesaria para el área es aplicada en un cien por ciento en la zona y desdeese mismo momento se inicia el proceso de degradación por las enzimas propias del cuerpo humano, se irá perdiendo una pequeña cantidad del dispositivo día tras día. Es decir que los resultados no se mantienen estáticos hasta el día final de duración, sino que van lentamente desapareciendo. En promedio si el efecto del Ácido Hialurónico dura 12 meses (pudiendo ser más, o menos) es probable que en la mitad de ese tiempo (6 meses), ya se tenga una pérdida de aproximadamente el cincuenta por ciento de los resultados iniciales.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Existen alternativas a este tratamiento que puedan mejorar el aspecto de mi piel y arrugas?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Si. Existen otros tratamientos orientados a la mejoría del aspecto de la piel desde no invasivos como el uso de cremas, mascarillas y lociones, el uso de aparatos no invasivos como la radiofrecuencia o la microdermoabrasión, tratamientos mínimamente invasivos como la aplicación de inyecciones de estimuladores de colágeno y también cirugías plásticas que incluyan injertos de grasa del mismo paciente o prótesis. Sin embargo, ninguno de los tratamientos mencionados comparte el mismo mecanismo de acción, por lo que los resultados serían distintos a los obtenidos con la aplicación de Ácido Hialurónico.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Cuáles son los cuidados que debo tener después del tratamiento?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("No aplicar maquillaje el día del procedimiento, no entrar en contacto con superficies o agua contaminada, abstenerse de hacer ejercicio el día del procedimiento, abstenerse de entrar en cuerpos de agua como piscinas, lagos, o el mar, no consumir licor en el día del procedimiento, no usar medicaciones distintas a las prescritas por su médico, no masajear las zonas tratadas, no manipular las zonas tratadas.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Debo volver a algún control?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Si. Se recomienda que asistas a una cita de control entre el día 10 y 15 después de la aplicación. Esto permitirá en algunos casos, no en todos, realizar pequeños ajustes adicionales a los resultados. En algunas áreas como debajo de los ojos o los labios, es posible que el médico guarde una pequeña porción del dispositivo con el fin de tenerlo disponible para hacer ajustes finales sin generar costos adicionales. Si el dispositivo fue aplicado en su totalidad el día del procedimiento y se requiere o el paciente desea en común acuerdo con la recomendación médica aplicar más cantidad se generarán cobros adicionales por el uso del material adicional.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Cuáles son los riesgos a los que me expongo al realizarme este procedimiento?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Aunque la mayoría de los pacientes no experimentan efectos adversos, secundarios y/o complicaciones, pueden aparecer después de la aplicación de Ácido Hialurónico a nivel de la cara, cuello, escote o manos los siguientes riesgos:", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Riesgos asociados al uso de agujas que atraviesan la piel de la cara, cuello, escote o manos: Cefalea (dolor de cabeza), parestesia (alteraciones de la sensibilidad), tirantez de lapiel, dolor facial, edema (hinchazón), dolor, parálisis facial, irritación, hematomas y prurito (Comezón) en el sitio de inyección, equimosis (moretones), infección de los puntos de inyección, dolor en las manos.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Riesgos asociados al Ácido Hialurónico o alguna de las sustancias presentes en la preparación: Edema (hinchazón), inflamación, hematomas, enrojecimiento de la zona después de la aplicación, prurito (rasquiña), dolor, induración o nódulos en el punto de inyección, coloración o decoloración en la zona de inyección, inyecciones intravasculares accidentales (dentro de los vasos sanguíneos) que conlleven a necrosis (muerte del tejido) cutánea con o sin pérdida de tejido y cicatrices y/o ceguera permanente, abscesos, granulomas, hipersensibilidad inmediata o tardía, inflamación recurrente y persistente de las zonas tratadas (edema transitorio intermitente), alergias.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        'salto
        'NUMERACIÓN DE PÁGINA
        cell = New PdfPCell(New Phrase("3", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_BOTTOM,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        'SALTO DE PÁGINA
        docPDF.NewPage()

        'ENCABEZADO
        tabla = New PdfPTable(New Single() {50.0F, 50.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("CONSENTIMIENTO INFORMADO " + Titulo, fuenteTitulo14)) With { 'LOGO
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("Pueden existir efectos secundarios y/o adversos que no estén descritos anteriormente debido a la respuesta biológica única e irrepetible de cada persona ante un procedimiento o medicamento. Sin embargo han sido mencionados los que figuran en la literatura científica.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Hay alguna forma de minimizar los riesgos?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Si. En primer lugar proveer toda la información que el médico tratante pregunte, no ocultar nada de la historia clínica, informar de tratamientos previos o eventos adversos previos si los hubiera, informar acerca de todos los medicamentos que esté tomando en este momento, no tomar medicamentos que favorezcan el sangrado en los 3 a 7 días previos como aspirina, antiinflamatorios, o suplementos como el omega o las vitaminas. Mantener una higiene del área tratada, no manipular las zonas tratadas y seguir todas las indicacionesque el médico ordene.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Además, el entrenamiento y amplio conocimiento del médico tratante permitirá reducir la posibilidad de algunos de los eventos adversos.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Hay alguna forma de GARANTIZAR que no ocurran eventos adversos, efectos secundarios o complicaciones?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("No. No existe forma de garantizarlo.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Hay alguna forma de NO CORRER NINGÚN RIESGO?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Si. Abstenerse de realizarse el procedimiento lo mantendrá libre de todo riesgo asociado al procedimiento.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Es posible que el tratamiento no surta ningún efecto en mi caso?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Si. Existen arrugas que aunque sean rellenadas pueden no desaparecer por completo.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Están garantizados los resultados positivos y a mi agrado?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("No. Garantizamos que usamos el dispositivo adecuado y en cumplimiento con la ley vigente de las entidades sanitarias, garantizamos que quien realiza el procedimiento se encuentra plenamente capacitado para ello y cuenta con experiencia suficiente, garantizamos que los métodos usados cumplen con los estándares de calidad y académicos a nivel mundial, sin embargo la práctica de la medicina no es una ciencia exacta, y aunque se esperan buenos resultados no hay garantía explícita de que puedan obtenerse, pues están afectados por factores intrínsecos y extrínsecos del paciente.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Pueden haber asimetrías (un lado diferente del otro)?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Si. Lo primero que debes tener claro es que aunque no lo notamos, toda la humanidad sin excepción tiene asimetrías naturales. Es decir, un lado de tu cara no es igual al otro. Siempre habrá diferencias en tamaño, calidad de la piel, color. A menos que las diferencias sean demasiado marcadas y vengas específicamente para corregirlas, el médicoaplicará por lo general (y te avisará si no es así) la misma cantidad de ácido hialurónico de ambos lados de la cara. Esto significa que tienes exactamente la misma cantidad de producto de ambos lados, sin embargo al aumentar los tamaños de ciertas zonas como labios o pómulos, es posible que notes después estas diferencias que antes eran imperceptibles. Si deseas corregirlas debes hablarlo con el médico para aplicar más cantidad en el lado que haga falta, esto implica el uso de más producto lo que genera costos adicionales que no están incluidos en el pago inicial.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Qué pasa si no me gusta el resultado y/o quiero eliminar el efecto del medicamento?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("La primera opción es esperar a que el resultado ceda por sí mismo. En caso de querer acelerar el proceso, podría usarse una enzima llamada hialuronidasa que puede disolver rápidamente el ácido hialurónico. La aplicación de hialuronidasa contempla también riesgos y posibles efectos colaterales que deben ser tenidos en cuenta antes de decidir su uso. La aplicación de hialuronidasa es un procedimiento adicional que genera costos adicionales y que no es cubierto por el médico tratante.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        'salto
        'NUMERACIÓN DE PÁGINA
        cell = New PdfPCell(New Phrase("4", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_BOTTOM,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        'SALTO DE PÁGINA
        docPDF.NewPage()

        'ENCABEZADO
        tabla = New PdfPTable(New Single() {50.0F, 50.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("CONSENTIMIENTO INFORMADO " + Titulo, fuenteTitulo14)) With { 'LOGO
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("¿Si no me agrada el resultado se me devolverá el dinero?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("No. Como se explicó antes, no es posible asegurar el resultado y toda realización del procedimiento genera un costo independientemente del resultado, por este motivo no habrá lugar a devoluciones una vez haya sido realizado el procedimiento. Sin embargo, si el procedimiento aún no ha tenido lugar, el paciente está en todo su derecho de cambiar de opinión y solicitar la devolución del dinero pagado.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Certifico que el presente documento ha sido leído y entendido por mi en su integridad.  Doy fe que no he omitido o alterado datos al exponer mi historial clínico y antecedentes clínico-quirúrgicos.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Certifico que lo aquí escrito me ha sido explicado adicionalmente de forma personal por mi médico y que ha respondido de forma satisfactoria a todas las preguntas adicionales que he tenido.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Declaro haber comprendido cuáles son los cuidados posteriores al tratamiento y exonero a mi médico tratante de cualquier responsabilidad derivada del incumplimiento de los mismos.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Me ha sido explicado de forma comprensible el procedimiento de aplicación de ácido hialurónico, los procedimientos alternativos u otros métodos de tratamiento, los riesgos del procedimiento de aplicación de ácido hialurónico, y que estoy en total libertad de elegir no correr ningún riesgo a través de la abstención de la realización del procedimiento aquí descrito.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Anexo Covid 19:", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Es posible que después de un tratamiento médico, su sistema inmunológico se pueda ver comprometido y por ende facilitar el riesgo de contagio frente a esta enfermedad, por lo cual se han tomado y debe tomar medidas por mitigar su contagio, sin embargo este riesgo existe y por ello se le hace entrega de un instructivo para mitigareste riesgo en el momento que solicita su cita, además será atendido bajo protocolos de seguridad que disminuyan el riesgo de un posible contagio durante la atención médica. En caso de que se presente la enfermedad, tomará las medidas sanitarias necesarias de aislamiento social para salvaguardar la salud de todas las personas de su entorno, dicha enfermedad podría llegar a afectar los resultados del tratamiento realizado y también comprometer de manera importante su salud.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Medidas de Mitigación Covid 19:", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Aseguró no haber estado en contacto con mi familia, amigos, y en el trabajo que presenten síntomas respiratorios o sugestivos de Covid 19 o que sean Covid 19 positivos en el último mes. No he tenido síntomas como tos, fiebre, malestar general, fatiga, alteración del olfato, alteraciones del gusto o cualquier otro síntoma relacionado con Covid 19 en el último mes. He cumplido con las medidas preventivas de contagio de Covid 19 como lavado de manos, uso de tapabocas y lentes protectores, distanciamiento social de mínimo 2 metros con otras personas, desinfección adecuada de alimentos, superficies y además en mi entorno, con el fin de evitar el riesgo de contagiarme. En caso de iniciar algún síntoma posterior a la realización del tratamiento, me pondré inmediatamente en contacto con mi médico tratante para evaluar la posibilidad de un posible contagio con Covid 19. En caso de no cumplir con estas medidas enunciadas para evitar el contagio, el médico podrá negarse a la realización de mi consulta y procedimiento.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        'salto
        'NUMERACIÓN DE PÁGINA
        cell = New PdfPCell(New Phrase("5", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_BOTTOM,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 80,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        'SALTO DE PÁGINA
        docPDF.NewPage()

        'ENCABEZADO
        tabla = New PdfPTable(New Single() {50.0F, 50.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("CONSENTIMIENTO INFORMADO " + Titulo, fuenteTitulo14)) With { 'LOGO
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("Autorizo a la Dra. JULIANA MENESES PEREZ a llevar a cabo en mi cuerpo el procedimiento APLICACIÓN DE ÁCIDO HIALURÓNICO.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        '''parte de las firmas 

        tabla = New PdfPTable(New Single() {10.0F, 35.0F, 10.0F, 35.0F, 10.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)

        fotoPDF = iTextSharp.text.Image.GetInstance(Datos.FirmaPaciente1)
        fotoPDF.ScaleAbsolute(180, 45)
        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .PaddingBottom = 5,
            .Border = 0,
            .BorderWidthBottom = 1
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)

        fotoPDF = iTextSharp.text.Image.GetInstance(Datos.FirmaProfesional1)
        fotoPDF.ScaleAbsolute(180, 45)
        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .PaddingBottom = 5,
            .Border = 0,
            .BorderWidthBottom = 1
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)

        'TEXTO FIRMAS

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("FIRMA DEL PACIENTE", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("FIRMA DEL PROFESIONAL", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)
        'CC
        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("CC: " & Datos.CCPaciente1, fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("JULIANA MENESES PEREZ", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        'FECHA
        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)
        Dim fecha As Date = Now.Date
        cell = New PdfPCell(New Phrase("FECHA: " & fecha, fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("TP – R.M. 543677", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        'NUMERACIÓN DE PÁGINA
        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F
        cell = New PdfPCell(New Phrase("6", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_BOTTOM,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 560,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)


        docPDF.Close()
        docPDF.Dispose()
        'MsgBox("siii")
        Dim msgBoxResult = MsgBox("Documento prueba generado")
        Dim Proc As New System.Diagnostics.Process
        Proc.StartInfo.FileName = ruta
        Proc.Start()

    End Sub

    Public Sub Consentimiento_HILOS_ESPICULADOS_POLIDIOXANONA(Logo As Bitmap, Titulo As String, Datos As CirugiaPlasticaOcularVO)

        crearDirectorio()
        ruta = rutaDirectorio & "\\Consentimiento_" & Titulo & ".pdf"
        If File.Exists(ruta) Then
            File.Delete(ruta)

        End If

        If Not File.Exists(ruta) Then

        End If
        pdfw = PdfWriter.GetInstance(docPDF, New FileStream(ruta, FileMode.Create))
        docPDF.SetPageSize(PageSize.A4)
        'docPDF.SetMargins(70.8661F, 70.8661F, 85.0394F, 85.0394F)
        'docPDF.SetPageSize(New Rectangle(612.0F, 792.0F).Rotate) 'tamaño de la página
        docPDF.SetMargins(28.34F, 28.34F, 10.0F, 10.0F) 'CONVERTIR CM A PUNTOS
        'docPDF.SetMargins(20.0F, 20.0F, 0.0F, 0.0F) 'CONVERTIR CM A PUNTOS
        docPDF.Open()

        Dim cb As PdfContentByte
        Dim colorBordes As New BaseColor(201, 128, 138) 'COLOR DE BORDES


        'y -= 150
        Dim fuente As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.TIMES, 18, iTextSharp.text.Font.BOLD).BaseFont, 18)
        Dim fuente14 As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.TIMES, 14).BaseFont, 14)
        Dim fuenteTexto As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.HELVETICA, 12).BaseFont, 12)
        Dim fuenteTextoNegrita As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.HELVETICA_BOLDOBLIQUE, 12).BaseFont, 12)
        Dim fuenteTextoNegrita2 As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12).BaseFont, 12)
        Dim fuenteTitulo14 As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, iTextSharp.text.Font.BOLD).BaseFont, 14)

        'Dim textoRojo As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.TIMES, 9, New BaseColor(255, 0, 0)).BaseFont, 9)
        Dim textoBorde = FontFactory.GetFont(FontFactory.TIMES, 26, colorBordes)
        Dim textoblanco = FontFactory.GetFont(FontFactory.TIMES, 18, BaseColor.WHITE)

        'LOGO
        fotoPDF = iTextSharp.text.Image.GetInstance(Logo, BaseColor.WHITE)
        fotoPDF.ScaleAbsolute(230, 50)

        'TABLA
        Dim tabla As New PdfPTable(New Single() {50.0F, 50.0F})
        tabla.WidthPercentage = 100.0F


        Dim cell As New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)


        cell = New PdfPCell(New Phrase("CONSENTIMIENTO INFORMADO " + Titulo, fuenteTitulo14)) With { 'LOGO
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("De conformidad con lo estipulado en la Ley 23 de 1981 y los paquetes instruccionales de Seguridad del Paciente emitidos en 2010 por Ministerio de Salud y Protección Social", fuenteTextoNegrita)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 20,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Yo " & Datos.NomPaciente1 & ", identificado con documento de identidad C.C " & Datos.CCPaciente1 & ", se me ha informado los siguientes lineamientos sobre el procedimiento de  APLICACIÓN DE HILOS ESPICULADOS DE POLIDIOXANONA (PDO).", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Cómo se llama el procedimiento?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Aplicación de Hilos espiculados de Polidioxanona (PDO) en Cara, cuello, brazos, abdomen, espalda, glúteos, piernas y/o senos.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)


        cell = New PdfPCell(New Phrase("¿Qué son los Hilos espiculados de PDO?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Son suturas (hilos) que van dentro de una aguja o cánula delgada y que están hechos de un material denominado Polidioxanona o por sus siglas PDO. Los hilos espiculados están provistos de pequeñas estructuras que actúan como ganchos (espículas) y que tienen la capacidad de anclarse en el tejido para reubicarlo en la posición deseada.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("La polidioxanona es un material utilizado ampliamente en medicina desde hace más de 10 años especialmente en cirugía cardiovascular. Cuando una persona es operada del corazón y en general en partes del cuerpo donde se necesite cerrar una herida se emplean suturas de materiales reabsorbibles, es decir, materiales que no requieren ser retirados posteriormente porque se degradan y se eliminan por completo del cuerpo después de cierto tiempo. La polidioxanona es uno de estos materiales.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("En estudios científicos se encontró que este material que venía siendo usado exclusivamente para la fabricación de suturas, es capaz de promover la formación de colágeno alrededor del mismo durante el tiempo que se encuentra presente en el cuerpo humano. A partir de estos hallazgos se estudió y se estableció la implantación de hebras o hilos de este material (PDO) debajo de la piel con fines estéticos.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Para qué se realiza este tratamiento?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Los hilos espiculados de PDO están indicados en situaciones donde se requiera sostener, mantener o reubicar el tejido de la piel y debajo de la piel. Está especialmente indicado en la corrección de la caída de las mejillas con pérdida de la línea del contorno inferior de la cara, algunos casos de caída o laxitud del cuello, algunos casos de flacidez y caída de la posición normal del ombligo, en algunos casos de caída de glúteos (cuando son pequeños ytienen poco peso), en algunos casos de laxitud de la piel de los brazos y de las piernas.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Cómo se realiza este tratamiento?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Los hilos se introducen a nivel subdérmico superficial (debajo de la piel) a través de una punción con una aguja o cánula muy delgada donde viene introducido el hilo. Una vez posicionada la aguja o cánula debajo de la piel, se reubica el tejido en la posición deseada y se retira la aguja o cánula quedando el hilo o hebra de polidioxanona debajo de la piel sosteniendo el tejido en su nueva posición de forma transitoria mientras es degradado por el cuerpo en un tiempo determinado.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Los hilos espiculados de PDO sirven para rellenar arrugas?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("No. Los hilos espiculados de PDO no sirven para rellenar arrugas.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Los hilos espiculados de PDO tienen efecto 'lifting' o de levantamiento?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Si. Es su principal indicación. Buscan levantar o mantener los tejidos en una nueva posiciónpor un tiempo determinado.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        ''SALTO----
        'NUMERACIÓN
        cell = New PdfPCell(New Phrase("1", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_BOTTOM,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 50,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        '--SALTO DE PÁGINA--
        docPDF.NewPage()

        '---ENCABEZADO---
        tabla = New PdfPTable(New Single() {50.0F, 50.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("CONSENTIMIENTO INFORMADO " + Titulo, fuenteTitulo14)) With { 'LOGO
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)
        '---FIN ENCABEZADO---

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("¿Cuándo se ven los resultados?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Los resultados son apreciables de forma inmediata, sin embargo por la inflamación y la posibilidad de equimosis (moretones), hematomas, zonas de tracción transitorias e irregularidades transitorias del tejido, pueden verse distorsionados. Se considera que el paciente puede apreciar un resultado cercano al final aproximadamente en 30 días o una vez hayan cedido las equimosis, hematomas, zonas de tracción transitorias e irregularidades transitorias del tejido.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Cuánto tiempo duran los hilos en el cuerpo?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("En promedio, según los estudios científicos, los hilos son degradados en aproximadamente 240 días (8 meses", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Cuánto duran los resultados?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Durante el tiempo que los hilos estén en el cuerpo formarán fibras de colágeno que permiten al tejido continuar en la posición deseada por un tiempo adicional. Por lo que se considera que aunque los hilos duran alrededor de 8 meses, los resultados podrían mantenerse visibles por aproximadamente 12 meses.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Se requiere más de una sesión?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Usualmente una sola aplicación es suficiente para obtener el resultado deseado, sin embargo existen casos en donde sea necesaria la aplicación de hilos adicionales más adelante, el tiempo para aplicarlo suele ser después de transcurridos 90 días (3 meses) de aplicados los primeros, pero depende de cada caso en particular y el médico le indicará en qué momento debe hacerse si fuera necesario. La aplicación de hilos adicionales implica costos adicionales que serán cobrados fuera del costo pactado para la sesión inicial si llegara a ser necesario.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Voy a ver el mismo resultado durante todo el tiempo de duración del efecto?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("No. Inicialmente el resultado será muy perceptible con algunas distorsiones por la inflamación y zonas de tracción o irregularidad transitorias. Al cabo de 30 días se aprecia el resultado final y este irá disminuyendo paulatinamente hasta acercarse aproximadamente a los 12 meses. Los resultados pueden variar de persona a persona, dependiendo de las características del tejido, su peso, su elasticidad, la zona aplicada, el número de hilos aplicados, los cuidados del paciente y el estilo de vida del paciente.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Existen alternativas a este tratamiento que puedan mejorar el aspecto de mi piel y arrugas?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Si. Existen otros tratamientos orientados a la mejoría del aspecto de la piel desde no invasivos como el uso de cremas, mascarillas y lociones, el uso de aparatos no invasivos como la radiofrecuencia o la microdermoabrasión, tratamientos mínimamente invasivos como la aplicación de inyecciones de estimuladores de colágeno y también cirugías plásticas que incluyan injertos de grasa del mismo paciente o prótesis. Sin embargo, ninguno de los tratamientos mencionados comparte el mismo mecanismo de acción, por lo que los resultados serían distintos a los obtenidos con la aplicación de Hilos espiculados de PDO.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Cuáles son los cuidados que debo tener después del tratamiento?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("No aplicar maquillaje el día del procedimiento, no entrar en contacto con superficies o agua contaminada, abstenerse de hacer ejercicio el día del procedimiento, abstenerse de entrar en cuerpos de agua como piscinas, lagos, o el mar, no consumir licor en el día del procedimiento, no usar medicaciones distintas a las prescritas por su médico, no masajear las zonas tratadas, no manipular las zonas tratadas, evitar la apertura total de la boca al bostezar, reír, comer o asistir al odontólogo por un mes. Se recomienda el uso de mentonera o micropore por el mismo tiempo según el médico disponga y según el área tratada.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("No seguir las indicaciones anteriores sobretodo en los primeros 30 días puede conducir a un desanclaje del hilo que el paciente percibirá como un 'tirón' acompañado de la evidente pérdida del efecto inicial. Si esto ocurre, será necesario implantar nuevos hilos en el momento en el que el médico lo determine según el estado del paciente y generará costos adicionales.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        'SALTO---
        '---salto
        'NUMERACIÓN
        cell = New PdfPCell(New Phrase("2", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_BOTTOM,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        '--SALTO DE PÁGINA--
        docPDF.NewPage()

        '---ENCABEZADO---
        tabla = New PdfPTable(New Single() {50.0F, 50.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("CONSENTIMIENTO INFORMADO " + Titulo, fuenteTitulo14)) With { 'LOGO
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)
        '---FIN ENCABEZADO---

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("¿Debo volver a algún control?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("No es necesario regresar a control a menos que el paciente note algún efecto o síntoma que no haya sido advertido por el médico. Se recomienda al paciente regresar a los 12 meses para considerar la aplicación de nuevos hilos espiculados de PDO.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Cuáles son los riesgos a los que me expongo al realizarme este procedimiento?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Aunque la mayoría de los pacientes no experimentan efectos adversos, secundarios y/o complicaciones, pueden aparecer después de la aplicación de Hilos espiculados de PDO los siguientes riesgos:", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Riesgos asociados al uso de agujas que atraviesan la piel de la cara, cuello, brazos, abdomen, espalda, glúteos, piernas y/o senos: Cefalea (dolor de cabeza), parestesia (alteraciones de la sensibilidad), tirantez de la piel, dolor facial, edema (hinchazón), dolor, parálisis facial, irritación, hematomas y prurito (comezón) en el sitio de inyección, equimosis (moretones), infección de los puntos de inyección. ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Riesgos asociados al hilo de espiculado polidioxanona: Edema (hinchazón), inflamación, hematomas, enrojecimiento de la zona después de la aplicación, prurito (rasquiña), dolor, induración o nódulos en el punto de inyección, coloración o decoloración en la zona de inyección, abscesos, granulomas, hipersensibilidad inmediata o tardía, inflamación recurrente y persistente de las zonas tratadas (edema transitorio intermitente), alergias en casos raros, muy infrecuentemente rechazo del material.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Es normal, y suele aparecer en la gran mayoría de los casos, áreas con irregularidades o líneas de tensión transitorias que suelen resolver espontáneamente durante los primeros 30 días.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Pueden existir efectos secundarios y/o adversos que no estén descritos anteriormente debido a la respuesta biológica única e irrepetible de cada persona ante un procedimiento o medicamento. Sin embargo han sido mencionados los que figuran en la literatura científica.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Hay alguna forma de minimizar los riesgos?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Si. En primer lugar proveer toda la información que el médico tratante pregunte, no ocultar nada de la historia clínica, informar de tratamientos previos o eventos adversos previos si los hubiera, informar acerca de todos los medicamentos que esté tomando este momento, no tomar medicamentos que favorezcan el sangrado en los 3 a 7 días previos como aspirina, antiinflamatorios, o suplementos como el omega o las vitaminas. Mantener una higiene del área tratada, no manipular las zonas tratadas y seguir todas las indicaciones que el médico ordene.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Además, el entrenamiento y amplio conocimiento del médico tratante permitirá reducir la posibilidad de algunos de los eventos adversos.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Hay alguna forma de GARANTIZAR que no ocurran eventos adversos, efectos secundarios o complicaciones?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("No. No existe forma de garantizarlo.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Hay alguna forma de NO CORRER NINGÚN RIESGO?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Si. Abstenerse de realizarse el procedimiento lo mantendrá libre de todo riesgo asociado al procedimiento.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Es posible que el tratamiento no surta ningún efecto en mi caso?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Si. Aunque en la inmensa mayoría de los pacientes se obtienen resultados visibles y satisfactorios, existen tejidos que al ser demasiado rígidos o pesados, superan la capacidad de las espículas (ganchos) de los hilos para moverlos o sostenerlos, pudiendo producirse un fracaso terapéutico donde no se aprecie resultados, o resultados de corta duración muy por debajo de los tiempos de duración promedio del efecto. ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        'salto
        'NUMERACIÓN DE PÁGINA
        cell = New PdfPCell(New Phrase("3", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_BOTTOM,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 20,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        'SALTO DE PÁGINA
        docPDF.NewPage()

        'ENCABEZADO
        tabla = New PdfPTable(New Single() {50.0F, 50.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("CONSENTIMIENTO INFORMADO " + Titulo, fuenteTitulo14)) With { 'LOGO
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("¿Están garantizados los resultados positivos y a mi agrado?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("No. Garantizamos que usamos el dispositivo adecuado y en cumplimiento con la ley vigente de las entidades sanitarias, garantizamos que quien realiza el procedimiento se encuentra plenamente capacitado para ello y cuenta con experiencia suficiente, garantizamos que los métodos usados cumplen con los estándares de calidad y académicos a nivel mundial, sin embargo la práctica de la medicina no es una ciencia exacta, y aunque se esperan buenos resultados no hay garantía explícita de que puedan obtenerse, pues están afectados por factores intrínsecos y extrínsecos del paciente. ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Qué pasa si no me gusta el resultado y/o quiero retirar los hilos de mi cuerpo?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Los hilos se degradan por sí solos y deben desaparecer del cuerpo una vez transcurridos los tiempos mencionados anteriormente. Sin embargo, no existe ninguna forma de retirar el material aplicado antes de degradación espontánea y tampoco se conoce ninguna sustancia o procedimiento que haya probado en la literatura científica poder degradar más rápidamente los hilos.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Si no me agrada el resultado se me devolverá el dinero?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Como se explicó antes, no es posible asegurar el resultado y toda realización del procedimiento genera un costo independientemente del resultado, por este motivo no habrá lugar a devoluciones una vez haya sido realizado el procedimiento. Sin embargo, si el procedimiento aún no ha tenido lugar, el paciente está en todo su derecho de cambiar de opinión y solicitar la devolución del dinero pagado.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Certifico que el presente documento ha sido leído y entendido por mi en su integridad.  Doy fe que no he omitido o alterado datos al exponer mi historial clínico y antecedentes clínico-quirúrgicos.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Certifico que lo aquí escrito me ha sido explicado adicionalmente de forma personal por mi médico y que ha respondido de forma satisfactoria a todas las preguntas adicionales que he tenido.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Declaro haber comprendido cuáles son los cuidados posteriores al tratamiento y exonero a mi médico tratante de cualquier responsabilidad derivada del incumplimiento de los mismos.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Me ha sido explicado de forma comprensible el procedimiento de aplicación de hilos espiculados de polidioxanona, los procedimientos alternativos u otros métodos de tratamiento, los riesgos del procedimiento de aplicación de hilos espiculados de polidioxanona, y que estoy en total libertad de elegir no correr ningún riesgo a través de la abstención de la realización del procedimiento aquí descrito.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Me ha sido explicado que la hialuronidasa en Colombia no cuenta con indicación aprobada por el INVIMA para su uso inyectable y tampoco para degradar rellenos de ácido hialurónico y que la aplicación que estoy autorizando es para solucionar una complicación que no fué causada por el Dr. Luis Alberto Parra y que éste último se ha ofrecido amablemente a manejar dicha complicación para mejorar mi estado actual sin ninguna garantía de que exista un resultado satisfactorio o que no exista ninguna complicación derivada del nuevo procedimiento.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        'SALTO---
        'salto
        'NUMERACIÓN DE PÁGINA
        cell = New PdfPCell(New Phrase("4", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_BOTTOM,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 130,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        'SALTO DE PÁGINA
        docPDF.NewPage()

        'ENCABEZADO
        tabla = New PdfPTable(New Single() {50.0F, 50.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("CONSENTIMIENTO INFORMADO " + Titulo, fuenteTitulo14)) With { 'LOGO
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("Anexo Covid 19:", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Es posible que después de un tratamiento médico, su sistema inmunológico se pueda ver comprometido y por ende facilitar el riesgo de contagio frente a esta enfermedad, por lo cual se han tomado y debe tomar medidas por mitigar su contagio, sin embargo este riesgo existe y por ello se le hace entrega de un instructivo para mitigareste riesgo en el momento que solicita su cita, además será atendido bajo protocolos de seguridad que disminuyan el riesgo de un posible contagio durante la atención médica. En caso de que se presente la enfermedad, tomará las medidas sanitarias necesarias de aislamiento social para salvaguardar la salud de todas las personas de su entorno, dicha enfermedad podría llegar a afectar los resultados del tratamiento realizado y también comprometer de manera importante su salud.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Medidas de Mitigación Covid 19:", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Aseguró no haber estado en contacto con mi familia, amigos, y en el trabajo que presenten síntomas respiratorios o sugestivos de Covid 19 o que sean Covid 19 positivos en el último mes. No he tenido síntomas como tos, fiebre, malestar general, fatiga, alteración del olfato, alteraciones del gusto o cualquier otro síntoma relacionado con Covid 19 en el último mes. He cumplido con las medidas preventivas de contagio de Covid 19 como lavado de manos, uso de tapabocas y lentes protectores, distanciamiento social de mínimo 2 metros con otras personas, desinfección adecuada de alimentos, superficies y además en mi entorno, con el fin de evitar el riesgo de contagiarme. En caso de iniciar algún síntoma posterior a la realización del tratamiento, me pondré inmediatamente en contacto con mi médico tratante para evaluar la posibilidad de un posible contagio con Covid 19. En caso de no cumplir con estas medidas enunciadas para evitar el contagio, el médico podrá negarse a la realización de mi consulta y procedimiento.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Autorizo a la Dra. JULIANA MENESES PEREZ a llevar a cabo en mi cuerpo el procedimiento APLICACIÓN DE HILOS ESPICULADOS DE POLIDIOXANONA.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        '''parte de las firmas 

        tabla = New PdfPTable(New Single() {10.0F, 35.0F, 10.0F, 35.0F, 10.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)

        fotoPDF = iTextSharp.text.Image.GetInstance(Datos.FirmaPaciente1)
        fotoPDF.ScaleAbsolute(180, 45)
        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .PaddingBottom = 5,
            .Border = 0,
            .BorderWidthBottom = 1
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)

        fotoPDF = iTextSharp.text.Image.GetInstance(Datos.FirmaProfesional1)
        fotoPDF.ScaleAbsolute(180, 45)
        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .PaddingBottom = 5,
            .Border = 0,
            .BorderWidthBottom = 1
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)

        'TEXTO FIRMAS

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("FIRMA DEL PACIENTE", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("FIRMA DEL PROFESIONAL", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)
        'CC
        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("CC: " & Datos.CCPaciente1, fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("JULIANA MENESES PEREZ", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        'FECHA
        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)
        Dim fecha As Date = Now.Date
        cell = New PdfPCell(New Phrase("FECHA: " & fecha, fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("TP – R.M. 543677", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        'NUMERACIÓN DE PÁGINA
        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F
        cell = New PdfPCell(New Phrase("5", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_BOTTOM,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 240,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)


        docPDF.Close()
        docPDF.Dispose()
        'MsgBox("siii")
        Dim msgBoxResult = MsgBox("Documento prueba generado")
        Dim Proc As New System.Diagnostics.Process
        Proc.StartInfo.FileName = ruta
        Proc.Start()

    End Sub

    Public Sub Consentimiento_ACIDO_L_POLILACTICO(Logo As Bitmap, Titulo As String, Datos As CirugiaPlasticaOcularVO)

        crearDirectorio()
        ruta = rutaDirectorio & "\\Consentimiento_" & Titulo & ".pdf"
        If File.Exists(ruta) Then
            File.Delete(ruta)

        End If

        If Not File.Exists(ruta) Then

        End If
        pdfw = PdfWriter.GetInstance(docPDF, New FileStream(ruta, FileMode.Create))
        docPDF.SetPageSize(PageSize.A4)
        'docPDF.SetMargins(70.8661F, 70.8661F, 85.0394F, 85.0394F)
        'docPDF.SetPageSize(New Rectangle(612.0F, 792.0F).Rotate) 'tamaño de la página
        docPDF.SetMargins(28.34F, 28.34F, 10.0F, 10.0F) 'CONVERTIR CM A PUNTOS
        'docPDF.SetMargins(20.0F, 20.0F, 0.0F, 0.0F) 'CONVERTIR CM A PUNTOS
        docPDF.Open()

        Dim cb As PdfContentByte
        Dim colorBordes As New BaseColor(201, 128, 138) 'COLOR DE BORDES


        'y -= 150
        Dim fuente As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.TIMES, 18, iTextSharp.text.Font.BOLD).BaseFont, 18)
        Dim fuente14 As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.TIMES, 14).BaseFont, 14)
        Dim fuenteTexto As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.HELVETICA, 12).BaseFont, 12)
        Dim fuenteTextoNegrita As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.HELVETICA_BOLDOBLIQUE, 12).BaseFont, 12)
        Dim fuenteTextoNegrita2 As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12).BaseFont, 12)
        Dim fuenteTitulo14 As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, iTextSharp.text.Font.BOLD).BaseFont, 14)

        'Dim textoRojo As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.TIMES, 9, New BaseColor(255, 0, 0)).BaseFont, 9)
        Dim textoBorde = FontFactory.GetFont(FontFactory.TIMES, 26, colorBordes)
        Dim textoblanco = FontFactory.GetFont(FontFactory.TIMES, 18, BaseColor.WHITE)

        'LOGO
        fotoPDF = iTextSharp.text.Image.GetInstance(Logo, BaseColor.WHITE)
        fotoPDF.ScaleAbsolute(230, 50)

        'TABLA
        Dim tabla As New PdfPTable(New Single() {50.0F, 50.0F})
        tabla.WidthPercentage = 100.0F


        Dim cell As New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)


        cell = New PdfPCell(New Phrase("CONSENTIMIENTO INFORMADO " + Titulo, fuenteTitulo14)) With { 'LOGO
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("De conformidad con lo estipulado en la Ley 23 de 1981 y los paquetes instruccionales de Seguridad del Paciente emitidos en 2010 por Ministerio de Salud y Protección Social", fuenteTextoNegrita)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 20,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Yo " & Datos.NomPaciente1 & ", identificado con documento de identidad C.C " & Datos.CCPaciente1 & ", se me ha informado los siguientes lineamientos sobre el procedimiento de APLICACIÓN DE ÁCIDO L-POLILÁCTICO.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Cómo se llama el procedimiento?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Aplicación de Ácido L-Poliláctico en Cara, cuello, escote y/o manos.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)


        cell = New PdfPCell(New Phrase("¿Qué es la Ácido L-Poliláctico?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("La Ácido L-Poliláctico es una sustancia ampliamente utilizada en medicina desde hace varios años en forma de suturas y de suspensión. Es un material muy bien aceptado por el cuerpo humano.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("En estudios científicos se encontró que este material es capaz de promover la formación de colágeno alrededor del mismo durante el tiempo que se encuentra presente en el cuerpo humano. A partir de estos hallazgos se estudió y se estableció la implantación de micropartículas de Ácido L-Poliláctico debajo de la piel con fines estéticos.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("La Ácido L-Poliláctico para inyección es un dispositivo médico que se implanta debajo de la piel, que viene en viales que son reconstituidos (se les aplica agua para inyección) uno a tres días antes y puede diluirse según el uso y la zona de aplicación. Dentro de del vial reconstituido se encuentra una suspensión compuesta por una matriz de sostén en la quese encuentran las micropartículas de Ácido L-Poliláctico. La suspensión es de consistencia tipo acuosa y de color blanquecino.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿La Ácido L-Poliláctico para inyección contiene otras sustancias diferentes a la Ácido L-Poliláctico?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Si. La Ácido L-Poliláctico viene en forma de microesferas sólidas. Para que éstas microesferas puedan inyectarse y acomodarse según el médico determine, deben estar suspendidas en un gel que de celulosa y agua para inyección, un material totalmente biocompatible y que se reabsorbe rápidamente.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Además, muchas preparaciones de Ácido L-Poliláctico para inyección añaden Lidocaína en una pequeña cantidad, un anestésico local ampliamente conocido y usado en medicina y odontología con el fin de maximizar el confort del paciente al momento de la aplicación.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("El médico tratante le informará si la preparación de Ácido L-Poliláctico contiene o no Lidocaina y así mismo debes informar al médico tratante si tienes algún historial de alergia aesta sustancia.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Para qué se realiza este tratamiento?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Por su capacidad de inducir la formación de colágeno, este dispositivo se usa para mejorar el aspecto, turgencia, lozanía y tensión de la piel en cualquier parte del cuerpo. Las zonas donde más frecuentemente se implanta la Ácido L-Poliláctico son la cara, el cuello, el escote, la piel de los senos, espalda, abdomen, brazos, piernas, glúteos, manos.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Dependiendo de la forma de aplicación, cantidad y concentración también puede usarse con el fin de dar volumen a los tejidos y rellenar depresiones o arrugas.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("El médico le informará de que manera se va a usar en su caso particular y si es con el fin de otorgar volumen a los tejidos o solamente con el fin de mejorar el aspecto de la piel.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        ''SALTO----
        'NUMERACIÓN
        cell = New PdfPCell(New Phrase("1", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_BOTTOM,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 40,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        '--SALTO DE PÁGINA--
        docPDF.NewPage()

        '---ENCABEZADO---
        tabla = New PdfPTable(New Single() {50.0F, 50.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("CONSENTIMIENTO INFORMADO " + Titulo, fuenteTitulo14)) With { 'LOGO
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)
        '---FIN ENCABEZADO---

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("¿Cómo se realiza este tratamiento?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Se hace a través de la inyección, subdérmica (debajo de la piel) o perióstica (en la superficie del hueso) de la sustancia, usando agujas muy finas y delgadas que atraviesan lapiel y en algunos casos microcánulas que se diferencian de las agujas en tener un extremo no cortante (redondeado) para minimizar la posibilidad de sangrado o evitar la punción de un vaso sanguíneo.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Es mejor el uso de cánulas o de agujas?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Dependiendo de la anatomía y la zona a tratar del paciente se elige cuál de los dos instrumentos médicos es el más apropiado para la zona, maximizando el resultado y minimizando los riesgos. Ambos dispositivos son considerados de bajo riesgo al ser usados por un médico entrenado y con experiencia.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Todas las arrugas se pueden tratar con Ácido L-Poliláctico para Inyección?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("No. Algunas arrugas se originan por movimientos musculares debajo de la piel en cuyo caso se indicará tratarlas mejor con otros procedimientos como la aplicación de Toxina Botulínica Tipo A, algunas arrugas muy superficiales serán tratadas mejor con tratamientos abrasivos físicos como la microdermoabrasión o químicos como el peeling médico, otras pueden mejorar con cremas o lociones. También existen líneas de expresión consideradas normales y típicas del ser humano que no serán tratadas.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Cuándo se ven los resultados?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("En los casos donde se aplique en la forma y concentración necesaria para obtener aumento de volumen del tejido, parte de los resultados serán apreciables de forma inmediata. Sin Embargo, al momento de la aplicación se producirá inflamación, puede haber sangrados, equimosis (moretones) o hematomas que pueden distorsionar temporalmente los resultados finales. Los resultados no serán visibles sino hasta cuando el proceso de formación de colágeno se haya dado.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Tras la implantación inicial, el cuerpo humano tomará aproximadamente 21 días en INICIAR la producción de colágeno alrededor de las micro esferas de Ácido L-Poliláctico, por lo que pueden llegar a ser inicialmente perceptibles los cambios en la piel del paciente a partir del día 30 aproximadamente. De ahí en adelante la cantidad de colágeno irá en aumento hasta el tiempo de duración de las micro esferas de Ácido L-Poliláctico, con una mejoría gradual del aspecto de la piel.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Cuánto duran los resultados?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("En promedio los resultados son apreciables al ojo no entrenado por un tiempo de aproximadamente un año, oscilando desde 6 meses hasta 18 meses aproximadamente. Este tiempo puede estar afectado por factores como los estados de deshidratación crónica causados por bajo consumo de líquidos, ejercicio sin la correcta reposición de líquidos, exposición excesiva al sol, consumo frecuente de diuréticos como el café o el té o algunos medicamentos, abuso de alcohol y niveles altos de actividad física influyen de forma negativa sobre la duración del resultado.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Voy a ver el mismo resultado durante todo el tiempo de duración del efecto?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("No. En el caso del uso de la Ácido L-Poliláctico sin diluir para lograr efecto de volumen se verá inicialmente un aumento del volumen de la zona tratada que disminuye o desaparece en 1 a 3 días aproximadamente. Una vez pasados los 30 días y en adelante se recupera la visibilidad de los resultados y éstos desaparecerán de forma lenta y paulatina en un periodo promedio de 1 año.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Cuando el Ácido L-Poliláctico es diluido y usado con el único fin de mejorar el aspecto de la piel, el resultado suele ser imperceptible por los primeros 30 días, luego empiezan a percibirse y a mejorar paulatinamente con los días hasta culminar el proceso de degradación de las micro esferas de Ácido L-Poliláctico. Si el paciente hace sesiones adicionales, el aspecto de la piel continúa en mejoría.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        'SALTO---
        '---salto
        'NUMERACIÓN
        cell = New PdfPCell(New Phrase("2", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_BOTTOM,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        '--SALTO DE PÁGINA--
        docPDF.NewPage()

        '---ENCABEZADO---
        tabla = New PdfPTable(New Single() {50.0F, 50.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("CONSENTIMIENTO INFORMADO " + Titulo, fuenteTitulo14)) With { 'LOGO
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)
        '---FIN ENCABEZADO---

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("¿Se requiere más de una sesión?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Si bien una sola aplicación producirá en la mayoría de los casos resultados visibles, es recomendable hacer 3 aplicaciones en total a una distancia de 2 meses entre una y otra con el fin de conseguir una estimulación suficiente de la formación de colágeno.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Existen alternativas a este tratamiento que puedan mejorar el aspecto de mi piel y arrugas?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Si. Existen otros tratamientos orientados a la mejoría del aspecto de la piel desde no invasivos como el uso de cremas, mascarillas y lociones, el uso de aparatos no invasivos como la radiofrecuencia o la microdermoabrasión, tratamientos mínimamente invasivos como la aplicación de inyecciones de estimuladores de colágeno y también cirugías plásticas que incluyan injertos de grasa del mismo paciente o prótesis. Sin embargo, ninguno de los tratamientos mencionados comparte el mismo mecanismo de acción, por lo que los resultados serían distintos a los obtenidos con la aplicación de Ácido L-Poliláctico.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Cuáles son los cuidados que debo tener después del tratamiento?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("No aplicar maquillaje el día del procedimiento, no entrar en contacto con superficies o agua contaminada, abstenerse de hacer ejercicio el día del procedimiento, abstenerse de entrar en cuerpos de agua como piscinas, lagos, o el mar, no consumir licor en el día del procedimiento, no usar medicaciones distintas a las prescritas por su médico.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Es necesario que el paciente haga un masaje profundo en las zonas tratadas por 5 minutos cada vez, repitiéndolo 5 veces al día (cada 4 horas), durante 5 días con el fin de conseguir una dispersión homogénea del producto y evitar formaciones de nódulos.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Debo volver a algún control?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("No es necesario regresar a control a menos que el paciente note algún efecto o síntoma que no haya sido advertido por el médico. Se recomienda al paciente regresar a los dos meses para hacer una nueva sesión hasta completar 3 sesiones. Después de este tiempo se puede repetir el procedimiento a partir de los 6 a 12 meses.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Cuáles son los riesgos a los que me expongo al realizarme este procedimiento?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Aunque la mayoría de los pacientes no experimentan efectos adversos, secundarios y/o complicaciones, pueden aparecer después de la aplicación de Ácido L-Poliláctico a nivel de la cara, cuello, escote o manos los siguientes riesgos:", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Riesgos asociados al uso de agujas que atraviesan la piel de la cara, cuello, escote o manos: Cefalea (dolor de cabeza), parestesia (alteraciones de la sensibilidad), tirantez de lapiel, dolor facial, edema (hinchazón), dolor, parálisis facial, irritación, hematomas y prurito (comezón) en el sitio de inyección, equimosis (moretones), infección de los puntos de inyección, dolor en las manos.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Riesgos asociados a la Ácido L-Poliláctico o alguna de las sustancias presentes en la preparación: Edema (hinchazón), inflamación, hematomas, enrojecimiento de la zona después de la aplicación, prurito (rasquiña), dolor, induración o nódulos en el punto de Inyección, coloración o decoloración en la zona de inyección, inyecciones intravasculares accidentales (dentro de los vasos sanguíneos) que conlleven a necrosis (muerte del tejido) cutánea con o sin pérdida de tejido y cicatrices y/o ceguera permanente, abscesos, granulomas, hipersensibilidad inmediata o tardía, inflamación recurrente y persistente de las zonas tratadas (edema transitorio intermitente), alergias.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("En el caso extremadamente raro de complicaciones por inyección intravascular (dentro de un vaso sanguíneo) no existe forma de diluir o degradar la sustancia para restablecer el flujo de sangre.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Pueden existir efectos secundarios y/o adversos que no estén descritos anteriormente debido a la respuesta biológica única e irrepetible de cada persona ante un procedimiento o medicamento. Sin embargo han sido mencionados los que figuran en la literatura científica.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        'salto
        'NUMERACIÓN DE PÁGINA
        cell = New PdfPCell(New Phrase("3", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_BOTTOM,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 5,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        'SALTO DE PÁGINA
        docPDF.NewPage()

        'ENCABEZADO
        tabla = New PdfPTable(New Single() {50.0F, 50.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("CONSENTIMIENTO INFORMADO " + Titulo, fuenteTitulo14)) With { 'LOGO
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("¿Hay alguna forma de minimizar los riesgos?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Si. En primer lugar proveer toda la información que el médico tratante pregunte, no ocultar nada de la historia clínica, informar de tratamientos previos o eventos adversos previos si los hubiera, informar acerca de todos los medicamentos que esté tomando en este momento, no tomar medicamentos que favorezcan el sangrado en los 3 a 7 días previos como aspirina, antiinflamatorios, o suplementos como el omega o las vitaminas. Mantener una higiene del área tratada, no manipular las zonas tratadas y seguir todas las indicacionesque el médico ordene.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Además, el entrenamiento y amplio conocimiento del médico tratante permitirá reducir la posibilidad de algunos de los eventos adversos.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Hay alguna forma de GARANTIZAR que no ocurran eventos adversos, efectos secundarios o complicaciones?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("No. No existe forma de garantizarlo.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Hay alguna forma de NO CORRER NINGÚN RIESGO?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Si. Abstenerse de realizarse el procedimiento lo mantendrá libre de todo riesgo asociado al procedimiento.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Es posible que el tratamiento no surta ningún efecto en mi caso?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Si. Existen arrugas que aunque sean rellenadas pueden no desaparecer por completo.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Están garantizados los resultados positivos y a mi agrado?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("No. Garantizamos que usamos el dispositivo adecuado y en cumplimiento con la ley vigente de las entidades sanitarias, garantizamos que quien realiza el procedimiento se encuentra plenamente capacitado para ello y cuenta con experiencia suficiente, garantizamos que los métodos usados cumplen con los estándares de calidad y académicos a nivel mundial, sin embargo la práctica de la medicina no es una ciencia exacta, y aunque se esperan buenos resultados no hay garantía explícita de que puedan obtenerse, pues están afectados por factores intrínsecos y extrínsecos del paciente.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        '------------------------

        cell = New PdfPCell(New Phrase("¿Qué pasa si no me gusta el resultado y/o quiero eliminar el dispositivo de mi cuerpo?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Las micro esferas de Ácido L-Poliláctico se degradan por sí solas en un periodo de aproximadamente 18 a 24 meses y deben desaparecer del cuerpo una vez transcurridos los tiempos mencionados anteriormente. Sin embargo, no existe ninguna forma de retirar el material aplicado antes de degradación espontánea y tampoco se conoce ninguna sustancia o procedimiento que haya probado en la literatura científica poder degradar más rápidamente el ácido L-Poliláctico.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Si no me agrada el resultado se me devolverá el dinero?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Como se explicó antes, no es posible asegurar el resultado y toda realización del procedimiento genera un costo independientemente del resultado, por este motivo no habrá lugar a devoluciones una vez haya sido realizado el procedimiento. Sin embargo, si el procedimiento aún no ha tenido lugar, el paciente está en todo su derecho de cambiar de opinión y solicitar la devolución del dinero pagado.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Certifico que el presente documento ha sido leído y entendido por mi en su integridad.  Doy fe que no he omitido o alterado datos al exponer mi historial clínico y antecedentes clínico-quirúrgicos.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Certifico que lo aquí escrito me ha sido explicado adicionalmente de forma personal por mi médico y que ha respondido de forma satisfactoria a todas las preguntas adicionales que he tenido.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Declaro haber comprendido cuáles son los cuidados posteriores al tratamiento y exonero a mi médico tratante de cualquier responsabilidad derivada del incumplimiento de los mismos.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        'SALTO---
        'salto
        'NUMERACIÓN DE PÁGINA
        cell = New PdfPCell(New Phrase("4", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_BOTTOM,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        'SALTO DE PÁGINA
        docPDF.NewPage()

        'ENCABEZADO
        tabla = New PdfPTable(New Single() {50.0F, 50.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("CONSENTIMIENTO INFORMADO " + Titulo, fuenteTitulo14)) With { 'LOGO
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("Me ha sido explicado de forma comprensible el procedimiento de aplicación de Ácido L-Poliláctico, los procedimientos alternativos u otros métodos de tratamiento, los riesgos del procedimiento de aplicación de Ácido L-Poliláctico, y que estoy en total Libertad de elegir no correr ningún riesgo a través de la abstención de la realización del procedimiento aquí descrito.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Anexo Covid 19:", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Es posible que después de un tratamiento médico, su sistema inmunológico se pueda ver comprometido y por ende facilitar el riesgo de contagio frente a esta enfermedad, por lo cual se han tomado y debe tomar medidas por mitigar su contagio, sin embargo este riesgo existe y por ello se le hace entrega de un instructivo para mitigareste riesgo en el momento que solicita su cita, además será atendido bajo protocolos de seguridad que disminuyan el riesgo de un posible contagio durante la atención médica. En caso de que se presente la enfermedad, tomará las medidas sanitarias necesarias de aislamiento social para salvaguardar la salud de todas las personas de su entorno, dicha enfermedad podría llegar a afectar los resultados del tratamiento realizado y también comprometer de manera importante su salud.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Medidas de Mitigación Covid 19:", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Aseguró no haber estado en contacto con mi familia, amigos, y en el trabajo que presenten síntomas respiratorios o sugestivos de Covid 19 o que sean Covid 19 positivos en el último mes. No he tenido síntomas como tos, fiebre, malestar general, fatiga, alteración del olfato, alteraciones del gusto o cualquier otro síntoma relacionado con Covid 19 en el último mes. He cumplido con las medidas preventivas de contagio de Covid 19 como lavado de manos, uso de tapabocas y lentes protectores, distanciamiento social de mínimo 2 metros con otras personas, desinfección adecuada de alimentos, superficies y además en mi entorno, con el fin de evitar el riesgo de contagiarme. En caso de iniciar algún síntoma posterior a la realización del tratamiento, me pondré inmediatamente en contacto con mi médico tratante para evaluar la posibilidad de un posible contagio con Covid 19. En caso de no cumplir con estas medidas enunciadas para evitar el contagio, el médico podrá negarse a la realización de mi consulta y procedimiento.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Autorizo a la Dra. JULIANA MENESES PEREZ a llevar a cabo en mi cuerpo el procedimiento APLICACIÓN DE ÁCIDO L-POLILÁCTICO.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        '''parte de las firmas 

        tabla = New PdfPTable(New Single() {10.0F, 35.0F, 10.0F, 35.0F, 10.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)

        fotoPDF = iTextSharp.text.Image.GetInstance(Datos.FirmaPaciente1)
        fotoPDF.ScaleAbsolute(180, 45)
        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .PaddingBottom = 5,
            .Border = 0,
            .BorderWidthBottom = 1
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)

        fotoPDF = iTextSharp.text.Image.GetInstance(Datos.FirmaProfesional1)
        fotoPDF.ScaleAbsolute(180, 45)
        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .PaddingBottom = 5,
            .Border = 0,
            .BorderWidthBottom = 1
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)

        'TEXTO FIRMAS

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("FIRMA DEL PACIENTE", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("FIRMA DEL PROFESIONAL", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)
        'CC
        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("CC: " & Datos.CCPaciente1, fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("JULIANA MENESES PEREZ", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        'FECHA
        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)
        Dim fecha As Date = Now.Date
        cell = New PdfPCell(New Phrase("FECHA: " & fecha, fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("TP – R.M. 543677", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        'NUMERACIÓN DE PÁGINA
        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F
        cell = New PdfPCell(New Phrase("5", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_BOTTOM,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 160,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)


        docPDF.Close()
        docPDF.Dispose()
        'MsgBox("siii")
        Dim msgBoxResult = MsgBox("Documento prueba generado")
        Dim Proc As New System.Diagnostics.Process
        Proc.StartInfo.FileName = ruta
        Proc.Start()

    End Sub

    Public Sub Consentimiento_POLIDIOXANONA(Logo As Bitmap, Titulo As String, Datos As CirugiaPlasticaOcularVO)

        crearDirectorio()
        ruta = rutaDirectorio & "\\Consentimiento_" & Titulo & ".pdf"
        If File.Exists(ruta) Then
            File.Delete(ruta)

        End If

        If Not File.Exists(ruta) Then

        End If
        pdfw = PdfWriter.GetInstance(docPDF, New FileStream(ruta, FileMode.Create))
        docPDF.SetPageSize(PageSize.A4)
        'docPDF.SetMargins(70.8661F, 70.8661F, 85.0394F, 85.0394F)
        'docPDF.SetPageSize(New Rectangle(612.0F, 792.0F).Rotate) 'tamaño de la página
        docPDF.SetMargins(28.34F, 28.34F, 10.0F, 10.0F) 'CONVERTIR CM A PUNTOS
        'docPDF.SetMargins(20.0F, 20.0F, 0.0F, 0.0F) 'CONVERTIR CM A PUNTOS
        docPDF.Open()

        Dim cb As PdfContentByte
        Dim colorBordes As New BaseColor(201, 128, 138) 'COLOR DE BORDES


        'y -= 150
        Dim fuente As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.TIMES, 18, iTextSharp.text.Font.BOLD).BaseFont, 18)
        Dim fuente14 As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.TIMES, 14).BaseFont, 14)
        Dim fuenteTexto As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.HELVETICA, 12).BaseFont, 12)
        Dim fuenteTextoNegrita As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.HELVETICA_BOLDOBLIQUE, 12).BaseFont, 12)
        Dim fuenteTextoNegrita2 As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12).BaseFont, 12)
        Dim fuenteTitulo14 As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, iTextSharp.text.Font.BOLD).BaseFont, 14)

        'Dim textoRojo As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.TIMES, 9, New BaseColor(255, 0, 0)).BaseFont, 9)
        Dim textoBorde = FontFactory.GetFont(FontFactory.TIMES, 26, colorBordes)
        Dim textoblanco = FontFactory.GetFont(FontFactory.TIMES, 18, BaseColor.WHITE)

        'LOGO
        fotoPDF = iTextSharp.text.Image.GetInstance(Logo, BaseColor.WHITE)
        fotoPDF.ScaleAbsolute(230, 50)

        'TABLA
        Dim tabla As New PdfPTable(New Single() {50.0F, 50.0F})
        tabla.WidthPercentage = 100.0F


        Dim cell As New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)


        cell = New PdfPCell(New Phrase("CONSENTIMIENTO INFORMADO " + Titulo, fuenteTitulo14)) With { 'LOGO
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("De conformidad con lo estipulado en la Ley 23 de 1981 y los paquetes instruccionales de Seguridad del Paciente emitidos en 2010 por Ministerio de Salud y Protección Social", fuenteTextoNegrita)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 20,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Yo " & Datos.NomPaciente1 & ", identificado con documento de identidad C.C " & Datos.CCPaciente1 & ", se me ha informado los siguientes lineamientos sobre el procedimiento de APLICACIÓN DE HILOS LISOS DE POLIDIOXANONA (PDO).", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Cómo se llama el procedimiento?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Aplicación de Hilos lisos de Polidioxanona (PDO) en piel de la Cara, cuello, escote, manos, brazos, abdomen, espalda, glúteos, piernas, senos, y/o vulva.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)


        cell = New PdfPCell(New Phrase("¿Qué son los Hilos Lisos de PDO?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Son suturas (hilos) que van dentro de una aguja delgada y que están hechos de un material denominado Polidioxanona o por sus siglas PDO.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("La Polidioxanona es un material utilizado ampliamente en medicina desde hace más de 10 años especialmente en cirugía cardiovascular. Cuando una persona es operada del corazón y en general en partes del cuerpo donde se necesite cerrar una herida se emplean suturas de materiales reabsorbibles, es decir, materiales que no requieren ser retirados posteriormente porque se degradan y se eliminan por completo del cuerpo después de cierto tiempo. La Polidioxanona es uno de estos materiales.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("En estudios científicos se encontró que este material que venía siendo usado exclusivamente para la fabricación de suturas, es capaz de promover la formación de colágeno alrededor del mismo durante el tiempo que se encuentra presente en el cuerpo humano. A partir de estos hallazgos se estudió y se estableció la implantación de hebras o hilos de este material (PDO) debajo de la piel con fines estéticos.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Para qué se realiza este tratamiento?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Por su capacidad de inducir la formación de colágeno, este dispositivo se usa para mejorar el aspecto, turgencia, lozanía y tensión de la piel en cualquier parte del cuerpo. Las zonas donde más frecuentemente se implantan los hilos son la cara, el cuello, el escote, la piel de los senos, espalda, abdomen, brazos, piernas, glúteos, manos, vulva y área alrededor de la vulva.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Cómo se realiza este tratamiento?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Los hilos se introducen a nivel subdérmico superficial (debajo de la piel) a través de una punción con una aguja muy delgada donde viene introducido el hilo. Una vez posicionada la Aguja debajo de la piel, se retira quedando el hilo o hebra de Polidioxanona debajo de la piel de forma transitoria mientras es degradado por el cuerpo en un tiempo determinado.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Los hilos lisos de PDO sirven para rellenar arrugas?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Si. En algunos casos. Especialmente en arrugas del cuello, del escote, en algunas arrugas finas alrededor de los ojos o en la piel de la cara. El hilo de PDO inducirá la formación de colágeno y éste último será quien termine por mejorar el aspecto de la arruga pudiendo o no quitarla en su totalidad.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Cuándo se ven los resultados?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Al ser los Hilos de PDO un tratamiento de inducción de la formación del colágeno, los resultados no serán visibles sino hasta cuando el proceso de formación de colágeno se haya dado.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        ''SALTO----
        'NUMERACIÓN
        cell = New PdfPCell(New Phrase("1", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_BOTTOM,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 60,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        '--SALTO DE PÁGINA--
        docPDF.NewPage()

        '---ENCABEZADO---
        tabla = New PdfPTable(New Single() {50.0F, 50.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("CONSENTIMIENTO INFORMADO " + Titulo, fuenteTitulo14)) With { 'LOGO
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)
        '---FIN ENCABEZADO---

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("Tras la implantación inicial, el cuerpo humano tomará aproximadamente 21 días en INICIAR la producción de colágeno alrededor de los hilos, por lo que pueden llegar a ser inicialmente perceptibles los cambios en la piel del paciente a partir del día 30 aproximadamente. De ahí en adelante la cantidad de colágeno irá en aumento hasta el tiempo de duración de los hilos, con una mejoría gradual del aspecto de la piel.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Cuánto tiempo duran los hilos en el cuerpo?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("En promedio, según los estudios científicos, los hilos son degradados en aproximadamente 120 días (4 meses). Es decir que el paciente formará colágeno desde el día 21 tras la implantación aproximadamente hasta los 120 días en promedio. Una vez el hilo haya sido degradado ya no se formará más colágeno.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Se requiere más de una sesión?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Si bien una sola aplicación producirá en la mayoría de los casos resultados visibles, es recomendable hacer 3 aplicaciones en total a una distancia de 4 meses entre una y otra con el fin de conseguir una estimulación suficiente de la formación de colágeno por al menos 1 año.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Los hilos Lisos de PDO tienen efecto 'lifting' o de levantamiento?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("No. Los hilos lisos de PDO son un tratamiento exclusivamente de estimulación de la formación del colágeno. No están anclados a ninguna parte, y no tienen la capacidad de producir tracción o levantamiento de ningún tejido. Sus resultados están orientados hacia la mejoría del aspecto de la piel.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Cuánto duran los resultados?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("En este caso el resultado va a estar dado por el colágeno resultante de la estimulación que ha hecho el hilo de PDO en la piel del paciente. Una vez se ha formado el colágeno, éste durará años y se degradará paulatinamente. Los tiempos de degradación dependen de factores como la edad, y estilo de vida del paciente y dependen del proceso individual de envejecimiento de cada persona.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("No es posible estimar ni medir un tiempo de duración del colágeno producido por el hilo de polidioxanona, sin embargo los pacientes manifiesta con frecuencia el sostenimiento de los resultados por al menos 12 meses aproximadamente.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Voy a ver el mismo resultado durante todo el tiempo de duración del efecto?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("No. El resultado suele ser imperceptible por los primeros 30 días, luego empiezan a percibirse y a mejorar paulatinamente con los días hasta culminar el proceso de degradación de los hilos. Si el paciente hace sesiones adicionales, el aspecto de la piel continúa en mejoría.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Existen alternativas a este tratamiento que puedan mejorar el aspecto de mi piel y arrugas?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Si. Existen otros tratamientos orientados a la mejoría del aspecto de la piel desde no invasivos como el uso de cremas, mascarillas y lociones, el uso de aparatos no invasivos como la radiofrecuencia o la microdermoabrasión, tratamientos mínimamente invasivos como la aplicación de inyecciones de estimuladores de colágeno y también cirugías plásticas que incluyan injertos de grasa del mismo paciente o prótesis. Sin embargo, ninguno de los tratamientos mencionados comparte el mismo mecanismo de acción, por lo que los resultados serían distintos a los obtenidos con la aplicación de Hilos lisos de PDO.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Cuáles son los cuidados que debo tener después del tratamiento?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("No aplicar maquillaje el día del procedimiento, no entrar en contacto con superficies o agua contaminada, abstenerse de hacer ejercicio el día del procedimiento, abstenerse de entrar en cuerpos de agua como piscinas, lagos, o el mar, no consumir licor en el día del procedimiento, no usar medicaciones distintas a las prescritas por su médico, no masajear las zonas tratadas, no manipular las zonas tratadas.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        'SALTO---
        '---salto
        'NUMERACIÓN
        cell = New PdfPCell(New Phrase("2", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_BOTTOM,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        '--SALTO DE PÁGINA--
        docPDF.NewPage()

        '---ENCABEZADO---
        tabla = New PdfPTable(New Single() {50.0F, 50.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("CONSENTIMIENTO INFORMADO " + Titulo, fuenteTitulo14)) With { 'LOGO
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)
        '---FIN ENCABEZADO---

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("¿Debo volver a algún control?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("No es necesario regresar a control a menos que el paciente note algún efecto o síntoma que no haya sido advertido por el médico. Se recomienda al paciente regresar a los 4 meses para hacer una nueva sesión", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Cuáles son los riesgos a los que me expongo al realizarme este procedimiento?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Aunque la mayoría de los pacientes no experimentan efectos adversos, secundarios y/o complicaciones, pueden aparecer después de la aplicación de Hilos lisos de PDO los siguientes riesgos:", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Riesgos asociados al uso de agujas que atraviesan la piel de la cara, cuello, escote, manos, brazos, abdomen, espalda, glúteos, piernas, senos, y/o vulva: Cefalea (dolor de cabeza), parestesia (alteraciones de la sensibilidad), tirantez de la piel, dolor facial, edema (hinchazón), dolor, parálisis facial, irritación, hematomas y prurito (comezón) en el sitio de inyección, equimosis (moretones), infección de los puntos de inyección.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Riesgos asociados al hilo de polidioxanona: Edema (hinchazón), inflamación, hematomas, enrojecimiento de la zona después de la aplicación, prurito (rasquiña), dolor, induración o nódulos en el punto de inyección, coloración o decoloración en la zona de inyección, abscesos, granulomas, hipersensibilidad inmediata o tardía, inflamación recurrente y persistente de las zonas tratadas (edema transitorio intermitente), alergias en casos raros, muy infrecuentemente rechazo del material.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Pueden existir efectos secundarios y/o adversos que no estén descritos anteriormente debido a la respuesta biológica única e irrepetible de cada persona ante un procedimiento o medicamento. Sin embargo han sido mencionados los que figuran en la literatura científica.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Hay alguna forma de minimizar los riesgos?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Si. En primer lugar proveer toda la información que el médico tratante pregunte, no ocultar nada de la historia clínica, informar de tratamientos previos o eventos adversos previos si los hubiera, informar acerca de todos los medicamentos que esté tomando este momento, no tomar medicamentos que favorezcan el sangrado en los 3 a 7 días previos como aspirina, antiinflamatorios, o suplementos como el omega o las vitaminas. Mantener una higiene del área tratada, no manipular las zonas tratadas y seguir todas las indicaciones que el médico ordene.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Además, el entrenamiento y amplio conocimiento del médico tratante permitirá reducir la posibilidad de algunos de los eventos adversos.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Hay alguna forma de GARANTIZAR que no ocurran eventos adversos, efectos secundarios o complicaciones?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("No. No existe forma de garantizarlo.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Hay alguna forma de NO CORRER NINGÚN RIESGO?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Si. Abstenerse de realizarse el procedimiento lo mantendrá libre de todo riesgo asociado al procedimiento.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Es posible que el tratamiento no surta ningún efecto en mi caso?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Si. Existen arrugas que aunque sean rellenadas pueden no desaparecer por completo.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Están garantizados los resultados positivos y a mi agrado?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("No. Garantizamos que usamos el dispositivo adecuado y en cumplimiento con la ley vigente de las entidades sanitarias, garantizamos que quien realiza el procedimiento se encuentra plenamente capacitado para ello y cuenta con experiencia suficiente, garantizamos que los métodos usados cumplen con los estándares de calidad y académicos a nivel mundial, sin embargo la práctica de la medicina no es una ciencia exacta, y aunque se esperan buenos resultados no hay garantía explícita de que puedan obtenerse, pues están afectados por factores intrínsecos y extrínsecos del paciente.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        'salto
        'NUMERACIÓN DE PÁGINA
        cell = New PdfPCell(New Phrase("3", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_BOTTOM,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        'SALTO DE PÁGINA
        docPDF.NewPage()

        'ENCABEZADO
        tabla = New PdfPTable(New Single() {50.0F, 50.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("CONSENTIMIENTO INFORMADO " + Titulo, fuenteTitulo14)) With { 'LOGO
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("¿Qué pasa si no me gusta el resultado y/o quiero retirar los hilos de mi cuerpo?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Los hilos se degradan por sí solos y deben desaparecer del cuerpo una vez transcurridos los tiempos mencionados anteriormente. Sin embargo, no existe ninguna forma de retirar el material aplicado antes de degradación espontánea y tampoco se conoce ninguna sustancia o procedimiento que haya probado en la literatura científica poder degradar más rápidamente los hilos.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Si no me agrada el resultado se me devolverá el dinero?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Como se explicó antes, no es posible asegurar el resultado y toda realización del procedimiento genera un costo independientemente del resultado, por este motivo no habrá lugar a devoluciones una vez haya sido realizado el procedimiento. Sin embargo, si el procedimiento aún no ha tenido lugar, el paciente está en todo su derecho de cambiar de opinión y solicitar la devolución del dinero pagado.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Certifico que el presente documento ha sido leído y entendido por mi en su integridad.  Doy fe que no he omitido o alterado datos al exponer mi historial clínico y antecedentes clínico-quirúrgicos.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Certifico que lo aquí escrito me ha sido explicado adicionalmente de forma personal por mi médico y que ha respondido de forma satisfactoria a todas las preguntas adicionales que he tenido.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Declaro haber comprendido cuáles son los cuidados posteriores al tratamiento y exonero a mi médico tratante de cualquier responsabilidad derivada del incumplimiento de los mismos.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Me ha sido explicado de forma comprensible el procedimiento de aplicación de hilos Lisos de polidioxanona, los procedimientos alternativos u otros métodos de tratamiento, los riesgos del procedimiento de aplicación de hilos lisos de polidioxanona, y que estoy en total libertad de elegir no correr ningún riesgo a través de la abstención de la realización del procedimiento aquí descrito.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Anexo Covid 19:", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Es posible que después de un tratamiento médico, su sistema inmunológico se pueda ver comprometido y por ende facilitar el riesgo de contagio frente a esta enfermedad, por lo cual se han tomado y debe tomar medidas por mitigar su contagio, sin embargo este riesgo existe y por ello se le hace entrega de un instructivo para mitigareste riesgo en el momento que solicita su cita, además será atendido bajo protocolos de seguridad que disminuyan el riesgo de un posible contagio durante la atención médica. En caso de que se presente la enfermedad, tomará las medidas sanitarias necesarias de aislamiento social para salvaguardar la salud de todas las personas de su entorno, dicha enfermedad podría llegar a afectar los resultados del tratamiento realizado y también comprometer de manera importante su salud.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Medidas de Mitigación Covid 19:", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Aseguró no haber estado en contacto con mi familia, amigos, y en el trabajo que presenten síntomas respiratorios o sugestivos de Covid 19 o que sean Covid 19 positivos en el último mes. No he tenido síntomas como tos, fiebre, malestar general, fatiga, alteración del olfato, alteraciones del gusto o cualquier otro síntoma relacionado con Covid 19 en el último mes. He cumplido con las medidas preventivas de contagio de Covid 19 como lavado de manos, uso de tapabocas y lentes protectores, distanciamiento social de mínimo 2 metros con otras personas, desinfección adecuada de alimentos, superficies y además en mi entorno, con el fin de evitar el riesgo de contagiarme. En caso de iniciar algún síntoma posterior a la realización del tratamiento, me pondré inmediatamente en contacto con mi médico tratante para evaluar la posibilidad de un posible contagio con Covid 19. En caso de no cumplir con estas medidas enunciadas para evitar el contagio, el médico podrá negarse a la realización de mi consulta y procedimiento.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        'SALTO---
        'salto
        'NUMERACIÓN DE PÁGINA
        cell = New PdfPCell(New Phrase("4", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_BOTTOM,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        'SALTO DE PÁGINA
        docPDF.NewPage()

        'ENCABEZADO
        tabla = New PdfPTable(New Single() {50.0F, 50.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("CONSENTIMIENTO INFORMADO " + Titulo, fuenteTitulo14)) With { 'LOGO
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("Autorizo a la Dra. JULIANA MENESES PEREZ a llevar a cabo en mi cuerpo el procedimiento APLICACIÓN DE HILOS LISOS DE POLIDIOXANONA.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        '''parte de las firmas 

        tabla = New PdfPTable(New Single() {10.0F, 35.0F, 10.0F, 35.0F, 10.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)

        fotoPDF = iTextSharp.text.Image.GetInstance(Datos.FirmaPaciente1)
        fotoPDF.ScaleAbsolute(180, 45)
        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .PaddingBottom = 5,
            .Border = 0,
            .BorderWidthBottom = 1
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)

        fotoPDF = iTextSharp.text.Image.GetInstance(Datos.FirmaProfesional1)
        fotoPDF.ScaleAbsolute(180, 45)
        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .PaddingBottom = 5,
            .Border = 0,
            .BorderWidthBottom = 1
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)

        'TEXTO FIRMAS

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("FIRMA DEL PACIENTE", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("FIRMA DEL PROFESIONAL", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)
        'CC
        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("CC: " & Datos.CCPaciente1, fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("JULIANA MENESES PEREZ", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        'FECHA
        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)
        Dim fecha As Date = Now.Date
        cell = New PdfPCell(New Phrase("FECHA: " & fecha, fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("TP – R.M. 543677", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        'NUMERACIÓN DE PÁGINA
        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F
        cell = New PdfPCell(New Phrase("5", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_BOTTOM,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 560,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)


        docPDF.Close()
        docPDF.Dispose()
        'MsgBox("siii")
        Dim msgBoxResult = MsgBox("Documento prueba generado")
        Dim Proc As New System.Diagnostics.Process
        Proc.StartInfo.FileName = ruta
        Proc.Start()

    End Sub

    Public Sub Consentimiento_HIALURONIDASA(Logo As Bitmap, Titulo As String, Datos As CirugiaPlasticaOcularVO)

        crearDirectorio()
        ruta = rutaDirectorio & "\\Consentimiento_" & Titulo & ".pdf"
        If File.Exists(ruta) Then
            File.Delete(ruta)

        End If

        If Not File.Exists(ruta) Then

        End If
        pdfw = PdfWriter.GetInstance(docPDF, New FileStream(ruta, FileMode.Create))
        docPDF.SetPageSize(PageSize.A4)
        'docPDF.SetMargins(70.8661F, 70.8661F, 85.0394F, 85.0394F)
        'docPDF.SetPageSize(New Rectangle(612.0F, 792.0F).Rotate) 'tamaño de la página
        docPDF.SetMargins(28.34F, 28.34F, 10.0F, 10.0F) 'CONVERTIR CM A PUNTOS
        'docPDF.SetMargins(20.0F, 20.0F, 0.0F, 0.0F) 'CONVERTIR CM A PUNTOS
        docPDF.Open()

        Dim cb As PdfContentByte
        Dim colorBordes As New BaseColor(201, 128, 138) 'COLOR DE BORDES


        'y -= 150
        Dim fuente As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.TIMES, 18, iTextSharp.text.Font.BOLD).BaseFont, 18)
        Dim fuente14 As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.TIMES, 14).BaseFont, 14)
        Dim fuenteTexto As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.HELVETICA, 12).BaseFont, 12)
        Dim fuenteTextoNegrita As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.HELVETICA_BOLDOBLIQUE, 12).BaseFont, 12)
        Dim fuenteTextoNegrita2 As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12).BaseFont, 12)
        Dim fuenteTitulo14 As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, iTextSharp.text.Font.BOLD).BaseFont, 14)

        'Dim textoRojo As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.TIMES, 9, New BaseColor(255, 0, 0)).BaseFont, 9)
        Dim textoBorde = FontFactory.GetFont(FontFactory.TIMES, 26, colorBordes)
        Dim textoblanco = FontFactory.GetFont(FontFactory.TIMES, 18, BaseColor.WHITE)

        'LOGO
        fotoPDF = iTextSharp.text.Image.GetInstance(Logo, BaseColor.WHITE)
        fotoPDF.ScaleAbsolute(230, 50)

        'TABLA
        Dim tabla As New PdfPTable(New Single() {50.0F, 50.0F})
        tabla.WidthPercentage = 100.0F


        Dim cell As New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)


        cell = New PdfPCell(New Phrase("CONSENTIMIENTO INFORMADO " + Titulo, fuenteTitulo14)) With { 'LOGO
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("De conformidad con lo estipulado en la Ley 23 de 1981 y los paquetes instruccionales de Seguridad del Paciente emitidos en 2010 por Ministerio de Salud y Protección Social", fuenteTextoNegrita)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 20,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Yo " & Datos.NomPaciente1 & ", identificado con documento de identidad C.C " & Datos.CCPaciente1 & ", se me ha informado los siguientes lineamientos sobre el procedimiento de APLICACIÓN DE HIALURONIDASA.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Cómo se llama el procedimiento?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Aplicación de Hialuronidasa en el rostro.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)


        cell = New PdfPCell(New Phrase("¿Qué es la hialuronidasa?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("La hilauronidasa es una enzima que al entrar en contacto con el ácido hialurónico, promueve su degradación.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿La Hialuronidasa contiene otras sustancias diferentes a la hialuronidasa?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Si. Antes de su aplicación, la hialuronidasa se diluye en solución salina fisiológica y lidocaína al 2% sin epinefrina para otorgar un efecto anestésico que disminuya la sensación de ardor típica de la hialuronidasa pura.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Para qué se realiza este tratamiento?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("La Hialuronidasa se usa para degradar rellenos de ácido hialurónico que han sido aplicados previamente en el tejido. Sin embargo, en Colombia la hialuronidasa no se encuentra aprobada por el INVIMA para esta indicación y tampoco para su uso de forma inyectable. De manera que su aplicación sería considerada 'OFF LABEL'.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Qué es una aplicación 'OFF LABEL'?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Es cuando médico y paciente en común acuerdo deciden el uso de una sustancia o medicamento en una forma distinta a la aprobada por los entes regulatorios, basándose en la literatura científica mundial y el conocimiento y experticia del profesional.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Cómo se realiza este tratamiento?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Se hace a través de la inyección subdérmica (debajo de la piel) de la sustancia, usando agujas muy finas y delgadas que atraviesan la piel y en algunos casos microcánulas que se diferencian de las agujas en tener un extremo no cortante (redondeado) para minimizar la posibilidad de sangrado o evitar la punción de un vaso sanguíneo.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Es mejor el uso de cánulas o de agujas?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Dependiendo de la anatomía y la zona a tratar del paciente se elige cuál de los dos instrumentos médicos es el más apropiado para la zona, maximizando el resultado y minimizando los riesgos. Ambos dispositivos son considerados de bajo riesgo al ser usados por un médico entrenado y con experiencia.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Todo el Ácido Hialurónico se elimina por completo a través de su aplicación?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("No necesariamente. Aunque el médico selecciona la dosis apropiada para cada caso, es posible que se requiera alguna aplicación adicional. Es importante recordar que la hialuronidasa solamente degrada el ácido hialurónico, y que los ácidos hialurónicos para inyección pueden contener otras sustancias llamadas agentes reticulantes que serán degradados por el propio cuerpo del paciente, y no por la hialuronidasa.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Cuándo se ven los resultados?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Generalmente se observan resultados en aproximadamente 5 minutos posterior a la aplicación. Sin embargo, los resultados finales serán apreciables cuando todo el líquido en el que está contenido la hialuronidasa se reabsorba y cuando la inflamación haya finalizado. Esto puede tomar un tiempo aproximado de 7 días.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        ''SALTO----
        'NUMERACIÓN
        cell = New PdfPCell(New Phrase("1", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_BOTTOM,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        '--SALTO DE PÁGINA--
        docPDF.NewPage()

        '---ENCABEZADO---
        tabla = New PdfPTable(New Single() {50.0F, 50.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("CONSENTIMIENTO INFORMADO " + Titulo, fuenteTitulo14)) With { 'LOGO
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)
        '---FIN ENCABEZADO---

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("Los resultados son variables, normalmente se espera que el tejido retorne al estado previo a la aplicación del ácido hialurónico, pero puede ser que no se degrade por completo el ácido hialurónico y se requieran más sesiones, o también puede pasar que se degrade también parte del ácido hialurónico propio del tejido, obteniéndose un resultado distinto al previo a la aplicación del ácido hialurónico.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Cuánto duran los resultados?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Una vez eliminado el ácido hialurónico, este no se vuelve a formar", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Existen alternativas a este tratamiento que puedan degradar el ácido hialurónico?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("En estudios científicos no se ha encontrado alguna otra sustancia capaz de degradar el ácido hialurónico. De forma anecdótica sin embargo, algunos profesionales consideran que el ácido hialurónico puede degradarse a través de sesiones repetidas de radiofrecuencia en un tiempo menor a su degradación espontánea, pero no tan rápido como la hialuronidasa.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Recuerde que si no hace nada, de igual manera el ácido hialurónico se degradará por completo, solamente que este proceso puede tomar varios meses o años dependiendo del producto aplicado.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Cuáles son los cuidados que debo tener después del tratamiento?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("No aplicar maquillaje el día del procedimiento, no entrar en contacto con superficies o agua contaminada, abstenerse de hacer ejercicio el día del procedimiento, abstenerse de entrar en cuerpos de agua como piscinas, lagos, o el mar, no consumir licor en el día del procedimiento, no usar medicaciones distintas a las prescritas por su médico, no masajear las zonas tratadas, no manipular las zonas tratadas.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Debo volver a algún control?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Si. Se recomienda que asistas a una cita de control a los 8 días aproximadamente para evaluar si pudieran ser necesarias aplicaciones adicionales.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Cuáles son los riesgos a los que me expongo al realizarme este procedimiento?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Aunque la mayoría de los pacientes no experimentan efectos adversos, secundarios y/o complicaciones, pueden aparecer después de la aplicación de la hialuronidasa a nivel de la cara los siguientes riesgos:", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Riesgos asociados al uso de agujas que atraviesan la piel de la cara, cuello, escote o manos: Cefalea (dolor de cabeza), parestesia (alteraciones de la sensibilidad), tirantez de lapiel, dolor facial, edema (hinchazón), dolor, parálisis facial, irritación, hematomas y prurito (comezón) en el sitio de inyección, equimosis (moretones), infección de los puntos de inyección, dolor en las manos.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Riesgos asociados a la Hialuronidasa o alguna de las sustancias presentes en la preparación: Edema (hinchazón), inflamación, hematomas, enrojecimiento de la zona después de la aplicación, prurito (rasquiña), dolor, induración o nódulos en el punto de inyección, coloración o decoloración en la zona de inyección, abscesos, granulomas, hipersensibilidad inmediata o tardía, inflamación recurrente y persistente de las zonas tratadas (edema transitorio intermitente), alergias, shock anafiláctico (reacción alérgica severa que puede causar la muerte).", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Es posible que el médico realice un test de alergia previo en el antebrazo", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Pueden existir efectos secundarios y/o adversos que no estén descritos anteriormente debido a la respuesta biológica única e irrepetible de cada persona ante un procedimiento o medicamento. Sin embargo han sido mencionados los que figuran en la literatura científica.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        'SALTO---
        '---salto
        'NUMERACIÓN
        cell = New PdfPCell(New Phrase("2", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_BOTTOM,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 40,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        '--SALTO DE PÁGINA--
        docPDF.NewPage()

        '---ENCABEZADO---
        tabla = New PdfPTable(New Single() {50.0F, 50.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("CONSENTIMIENTO INFORMADO " + Titulo, fuenteTitulo14)) With { 'LOGO
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)
        '---FIN ENCABEZADO---

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("¿Hay alguna forma de minimizar los riesgos?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Si. En primer lugar proveer toda la información que el médico tratante pregunte, no ocultar nada de la historia clínica, informar de tratamientos previos o eventos adversos previos si los hubiera, informar acerca de todos los medicamentos que esté tomando en este momento, no tomar medicamentos que favorezcan el sangrado en los 3 a 7 días previos como aspirina, antiinflamatorios, o suplementos como el omega o las vitaminas. Mantener una higiene del área tratada, no manipular las zonas tratadas y seguir todas las indicaciones que el médico ordene.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Además, el entrenamiento y amplio conocimiento del médico tratante permitirá reducir la posibilidad de algunos de los eventos adversos.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Hay alguna forma de GARANTIZAR que no ocurran eventos adversos, efectos secundarios o complicaciones?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("No. No existe forma de garantizarlo.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Hay alguna forma de NO CORRER NINGÚN RIESGO?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Si. Abstenerse de realizarse el procedimiento lo mantendrá libre de todo riesgo asociado al procedimiento.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Están garantizados los resultados positivos y a mi agrado?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("No. Garantizamos que usamos el dispositivo adecuado y en cumplimiento con la ley vigente de las entidades sanitarias, garantizamos que quien realiza el procedimiento se encuentra plenamente capacitado para ello y cuenta con experiencia suficiente, garantizamos que los métodos usados cumplen con los estándares de calidad y académicos a nivel mundial, sin embargo la práctica de la medicina no es una ciencia exacta, y aunque se esperan buenos resultados no hay garantía explícita de que puedan obtenerse, pues están afectados por factores intrínsecos y extrínsecos del paciente.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Pueden haber asimetrías (un lado diferente del otro)?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Si. Lo primero que debes tener claro es que aunque no lo notamos, toda la humanidad sinexcepción tiene asimetrías naturales. Es decir, un lado de tu cara no es igual al otro. Siempre habrán diferencias en tamaño, calidad de la piel, color. A menos que las diferencias sean demasiado marcadas y vengas específicamente para corregirlas, el médicoaplicará por lo general (y te avisará si no es así) la misma cantidad de hialuronidasa de ambos lados de la cara. Esto significa que tienes exactamente la misma cantidad de producto de ambos lados, pero aún así pueden generarse diferencias. Si deseas corregirlas debes hablarlo con el médico para aplicar mas cantidad en el lado que haga falta, esto implica el uso de más producto lo que genera costos adicionales que no están incluidos en el pago inicial.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Qué pasa si no me gusta el resultado y quiero volver a rellenar la zona?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("En este caso el médico es libre de decidir si desea realizar un nuevo procedimiento de relleno en la zona. En caso de que así lo decida se realizará el procedimiento de relleno con sus propios riesgos que serán informados previamente en un consentimiento similar a éste. Este nuevo procedimiento tiene un costo aparte al aquí mencionado.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("¿Si no me agrada el resultado se me devolverá el dinero?", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Como se explicó antes, no es posible asegurar el resultado y toda realización del procedimiento genera un costo independientemente del resultado, por este motivo no habrá lugar a devoluciones una vez haya sido realizado el procedimiento. Sin embargo, si el procedimiento aún no ha tenido lugar, el paciente está en todo su derecho de cambiar de opinión y solicitar la devolución del dinero pagado.", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        'salto
        'NUMERACIÓN DE PÁGINA
        cell = New PdfPCell(New Phrase("3", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_BOTTOM,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 70,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        'SALTO DE PÁGINA
        docPDF.NewPage()

        'ENCABEZADO
        tabla = New PdfPTable(New Single() {50.0F, 50.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("CONSENTIMIENTO INFORMADO " + Titulo, fuenteTitulo14)) With { 'LOGO
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("Certifico que el presente documento ha sido leído y entendido por mi en su integridad.  Doy fe que no he omitido o alterado datos al exponer mi historial clínico y antecedentes clínico-quirúrgicos.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Certifico que lo aquí escrito me ha sido explicado adicionalmente de forma personal por mi médico y que ha respondido de forma satisfactoria a todas las preguntas adicionales que he tenido.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Declaro haber comprendido cuáles son los cuidados posteriores al tratamiento y exonero a mi médico tratante de cualquier responsabilidad derivada del incumplimiento de los mismos.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Me ha sido explicado de forma comprensible el procedimiento de aplicación de hialuronidasa, los procedimientos alternativos u otros métodos de tratamiento, los riesgos del procedimiento de aplicación de hialuronidasa, y que estoy en total libertad de elegir no correr ningún riesgo a través de la abstención de la realización del procedimiento aquí descrito.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Me ha sido explicado que la hialuronidasa en Colombia no cuenta con indicación aprobada por el INVIMA para su uso inyectable y tampoco para degradar rellenos de ácido hialurónico y que la aplicación que estoy autorizando es para solucionar una complicación que no fué causada por el Dr. Luis Alberto Parra y que éste último se ha ofrecido amablemente a manejar dicha complicación para mejorar mi estado actual sin ninguna garantía de que exista un resultado satisfactorio o que no exista ninguna complicación derivada del nuevo procedimiento.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Anexo Covid 19:", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Es posible que después de un tratamiento médico, su sistema inmunológico se pueda ver comprometido y por ende facilitar el riesgo de contagio frente a esta enfermedad, por lo cual se han tomado y debe tomar medidas por mitigar su contagio, sin embargo este riesgo existe y por ello se le hace entrega de un instructivo para mitigareste riesgo en el momento que solicita su cita, además será atendido bajo protocolos de seguridad que disminuyan el riesgo de un posible contagio durante la atención médica. En caso de que se presente la enfermedad, tomará las medidas sanitarias necesarias de aislamiento social para salvaguardar la salud de todas las personas de su entorno, dicha enfermedad podría llegar a afectar los resultados del tratamiento realizado y también comprometer de manera importante su salud.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Medidas de Mitigación Covid 19:", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("Aseguró no haber estado en contacto con mi familia, amigos, y en el trabajo que presenten síntomas respiratorios o sugestivos de Covid 19 o que sean Covid 19 positivos en el último mes. No he tenido síntomas como tos, fiebre, malestar general, fatiga, alteración del olfato, alteraciones del gusto o cualquier otro síntoma relacionado con Covid 19 en el último mes. He cumplido con las medidas preventivas de contagio de Covid 19 como lavado de manos, uso de tapabocas y lentes protectores, distanciamiento social de mínimo 2 metros con otras personas, desinfección adecuada de alimentos, superficies y además en mi entorno, con el fin de evitar el riesgo de contagiarme. En caso de iniciar algún síntoma posterior a la realización del tratamiento, me pondré inmediatamente en contacto con mi médico tratante para evaluar la posibilidad de un posible contagio con Covid 19. En caso de no cumplir con estas medidas enunciadas para evitar el contagio, el médico podrá negarse a la realización de mi consulta y procedimiento.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        'SALTO---
        'salto
        'NUMERACIÓN DE PÁGINA
        cell = New PdfPCell(New Phrase("4", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_BOTTOM,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 70,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        'SALTO DE PÁGINA
        docPDF.NewPage()

        'ENCABEZADO
        tabla = New PdfPTable(New Single() {50.0F, 50.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_LEFT,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("CONSENTIMIENTO INFORMADO " + Titulo, fuenteTitulo14)) With { 'LOGO
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase("Sabiendo todo lo anterior, autorizo a la Dra. JULIANA MENESES PEREZ a llevar a cabo en mi cuerpo el procedimiento APLICACIÓN DE HIALURONIDASA.", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)

        docPDF.Add(tabla)

        '''parte de las firmas 

        tabla = New PdfPTable(New Single() {10.0F, 35.0F, 10.0F, 35.0F, 10.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)

        fotoPDF = iTextSharp.text.Image.GetInstance(Datos.FirmaPaciente1)
        fotoPDF.ScaleAbsolute(180, 45)
        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .PaddingBottom = 5,
            .Border = 0,
            .BorderWidthBottom = 1
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)

        fotoPDF = iTextSharp.text.Image.GetInstance(Datos.FirmaProfesional1)
        fotoPDF.ScaleAbsolute(180, 45)
        cell = New PdfPCell(fotoPDF) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 30,
            .PaddingBottom = 5,
            .Border = 0,
            .BorderWidthBottom = 1
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 30,
            .Border = 0
        }
        tabla.AddCell(cell)

        'TEXTO FIRMAS

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("FIRMA DEL PACIENTE", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("FIRMA DEL PROFESIONAL", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)
        'CC
        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)
        cell = New PdfPCell(New Phrase("CC: " & Datos.CCPaciente1, fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("JULIANA MENESES PEREZ", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        'FECHA
        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)
        Dim fecha As Date = Now.Date
        cell = New PdfPCell(New Phrase("FECHA: " & fecha, fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("TP – R.M. 543677", fuenteTextoNegrita2)) With {
            .VerticalAlignment = Element.ALIGN_CENTER,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 0,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)

        'NUMERACIÓN DE PÁGINA
        tabla = New PdfPTable(New Single() {100.0F})
        tabla.WidthPercentage = 100.0F
        cell = New PdfPCell(New Phrase("5", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_BOTTOM,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 560,
            .PaddingLeft = 20,
            .PaddingRight = 20,
            .Border = 0
        }
        tabla.AddCell(cell)
        docPDF.Add(tabla)


        docPDF.Close()
        docPDF.Dispose()
        'MsgBox("siii")
        Dim msgBoxResult = MsgBox("Documento prueba generado")
        Dim Proc As New System.Diagnostics.Process
        Proc.StartInfo.FileName = ruta
        Proc.Start()

    End Sub

End Class
