'Imports iTextSharp.text.Table
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Runtime.InteropServices
'Imports WebSupergoo.ABCpdf11.Elements
'Imports Element = iTextSharp.text.Element
Imports Org.BouncyCastle.Utilities
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button
Imports iTextSharp.text.pdf.qrcode
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

        tabla = New PdfPTable(New Single() {10.0F, 35.0F, 10.0F, 35.0F, 10.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .Border = 0
        }
        tabla.AddCell(cell)

        fotoPDF = iTextSharp.text.Image.GetInstance(Datos.FirmaPaciente1)
        fotoPDF.ScaleAbsolute(100, 30)
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

        fotoPDF = iTextSharp.text.Image.GetInstance(Datos.FirmaAcomp1)
        fotoPDF.ScaleAbsolute(100, 30)
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

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Firma del Paciente", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_TOP,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Firma Acompañante", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_TOP,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_TOP,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .PaddingTop = 10,
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

        '   docPDF.Close()

        MsgBox("Documento generado")
        'Dim Proc As New System.Diagnostics.Process
        'Proc.StartInfo.FileName = ruta
        'Proc.Start()

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

        tabla = New PdfPTable(New Single() {10.0F, 35.0F, 10.0F, 35.0F, 10.0F})
        tabla.WidthPercentage = 100.0F

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .Border = 0
        }
        tabla.AddCell(cell)

        fotoPDF = iTextSharp.text.Image.GetInstance(Datos.FirmaPaciente1)
        fotoPDF.ScaleAbsolute(100, 30)
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

        'fotoPDF = iTextSharp.text.Image.GetInstance(Datos.FirmaAcomp1)
        'fotoPDF.ScaleAbsolute(100, 30)
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

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase("Firma del Paciente", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_TOP,
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = 0
        }
        tabla.AddCell(cell)

        cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
            .VerticalAlignment = Element.ALIGN_JUSTIFIED,
            .HorizontalAlignment = Element.ALIGN_JUSTIFIED,
            .PaddingTop = 10,
            .Border = 0
        }
        tabla.AddCell(cell)

        'cell = New PdfPCell(New Phrase("Firma Acompañante", fuenteTexto)) With {
        '    .VerticalAlignment = Element.ALIGN_TOP,
        '    .HorizontalAlignment = Element.ALIGN_CENTER,
        '    .Border = 0
        '}
        tabla.AddCell(cell)

        'cell = New PdfPCell(New Phrase(" ", fuenteTexto)) With {
        '    .VerticalAlignment = Element.ALIGN_TOP,
        '    .HorizontalAlignment = Element.ALIGN_CENTER,
        '    .PaddingTop = 10,
        '    .Border = 0
        '}
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
        MsgBox("siii")
        Dim msgBoxResult = MsgBox("Documento prueba generado")
        'Dim Proc As New System.Diagnostics.Process
        'Proc.StartInfo.FileName = ruta
        'Proc.Start()


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
End Class
