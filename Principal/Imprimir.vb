Imports LibPrintTicketMatriz.Class1
Public Class Imprimir

    Public Sub GenereImpresion(cliente As String, cedula As String, detalle As String, valor As String)
        imprimir_TiqueteMensualidad(cliente, cedula, detalle, valor)
    End Sub
    Public Sub GenereImpresionventa(cliente As String, cedula As String, detalle As ListView, valor As String)
        imprimir_TiqueteVenta(cliente, cedula, detalle, valor)
    End Sub

    Private Sub imprimir_TiqueteMensualidad(cliente As String, cedula As String, detalle As String, valor As String)
        'Clase creada en c# por alguien que no se quien
        'Yo lo que hice fue cambiar algunos parámetros y 
        'Crear dll para utilizarla en vb.net
        'adjunto los tres proyectos
        'supersanpedro2@gmail.com
        '**********************************
        '// La clase "CreaTicket" tiene varios metodos para imprimir con diferentes formatos (izquierda, derecha, centrado, desripcion precio,etc), a
        '   // continuacion se muestra el metodo con ejemplo de parametro que acepta, longitud maxima y un ejemplo de como imprimira, esta clase esta 
        '   // basada en una impresora Epson de matriz de puntos con impresion maxima de 40 caracteres por renglon
        '   // METODO                                      MAX_LONG                        EJEMPLOS
        '   //--------------------------------------------------------------------------------------------------------------------------
        '   // TextoIzquierda("Empleado 1")                    40                      Empleado 1      
        '   // TextoDerecha("Caja 1")                          40                                                        Caja 1
        '   // TextoCentro("Ticket")                           40                                         Ticket   
        '   // TextoExtremos("Fecha 6/1/2011","Hora:13:25")     18 y 18                 Fecha 6/1/2011                Hora:13:25
        '   // EncabezadoVenta()                                n/a                     Articulo        Can    P.Unit    Importe
        '   // LineasGuion()                                    n/a                     ----------------------------------------
        '   // AgregaArticulo("Aspirina","2",45.25,90.5)        16,3,10,11              Aspirina          2    $45.25     $90.50
        '   // LineasTotales()                                  n/a                                                ----------
        '   // AgregaTotales("Subtotal",235.25)                 25 y 15                Subtotal                         $235.25
        '   // LineasAsterisco()                                n/a                     ****************************************
        '   // LineasIgual()                                    n/a                     ========================================des
        '   // CortaTicket()
        '   // AbreCajon()
        Dim instance As New Printing.PrinterSettings
        Dim impresosaPredt As String = instance.PrinterName
        Dim Descp As String
        Dim Totallinea As String
        Dim Hora As String
        Hora = DateTime.Now.ToString("h:mm:ss")
        Dim total As String
        Dim Ticket1 As New CreaTicket()
        Ticket1.impresora = impresosaPredt
        Ticket1.AbreCajon()

        Ticket1.TextoIzquierda("RECIBO DE INGRESO")
        If Not esvacio("no") Then Ticket1.TextoIzquierda(informaciongym("no"))
        If Not esvacio("nit") Then Ticket1.TextoIzquierda("Nit: " + informaciongym("nit"))
        If Not esvacio("regimen") Then Ticket1.TextoIzquierda("Regimen: " + informaciongym("regimen"))
        If Not esvacio("propietario") Then Ticket1.TextoIzquierda(informaciongym("propietario"))
        If Not esvacio("telefono") Then Ticket1.TextoIzquierda("Tel: " + informaciongym("telefono"))
        If Not esvacio("direccion") Then Ticket1.TextoIzquierda("Dir: " + informaciongym("direccion"))
        Ticket1.LineasIgual()
        Ticket1.TextoIzquierda("CLIENTE : " + cliente)
        Ticket1.TextoIzquierda("CC   : " + cedula)
        Ticket1.TextoIzquierda("CAJERO  : " & Principal.strUsuario & "")
        Ticket1.TextoExtremos("FECHA: " + Trim(Now.Date), "HORA: " + Hora)
        Ticket1.LineasIgual()
        Ticket1.EncabezadoVenta()
        Ticket1.LineasIgual()
        Dim i As Integer = 1
        Descp = detalle
        Totallinea = valor
        Ticket1.AgregaArticulo(i, Descp, Totallinea) 'imprime una linea de descripcion

        Ticket1.LineasIgual()
        total = (valor)
        Ticket1.AgregaTotales(" TOTAL", total) ' // imprime linea con total
        Ticket1.LineasTotales()
        Ticket1.LineasIgual()
        Ticket1.TextoCentro("EL GIMNASIO NO SE HACE")
        Ticket1.TextoCentro("RESPONSABLE DE OBJETOS")
        Ticket1.TextoCentro("PERDIDOS")
        Ticket1.TextoCentro("...................")
        Ticket1.CortaTicket()

    End Sub

    Private Sub imprimir_TiqueteVenta(cliente As String, cedula As String, detalle As ListView, valor As String)
        'Clase creada en c# por alguien que no se quien
        'Yo lo que hice fue cambiar algunos parámetros y 
        'Crear dll para utilizarla en vb.net
        'adjunto los tres proyectos
        'supersanpedro2@gmail.com
        '**********************************
        '// La clase "CreaTicket" tiene varios metodos para imprimir con diferentes formatos (izquierda, derecha, centrado, desripcion precio,etc), a
        '   // continuacion se muestra el metodo con ejemplo de parametro que acepta, longitud maxima y un ejemplo de como imprimira, esta clase esta 
        '   // basada en una impresora Epson de matriz de puntos con impresion maxima de 40 caracteres por renglon
        '   // METODO                                      MAX_LONG                        EJEMPLOS
        '   //--------------------------------------------------------------------------------------------------------------------------
        '   // TextoIzquierda("Empleado 1")                    40                      Empleado 1      
        '   // TextoDerecha("Caja 1")                          40                                                        Caja 1
        '   // TextoCentro("Ticket")                           40                                         Ticket   
        '   // TextoExtremos("Fecha 6/1/2011","Hora:13:25")     18 y 18                 Fecha 6/1/2011                Hora:13:25
        '   // EncabezadoVenta()                                n/a                     Articulo        Can    P.Unit    Importe
        '   // LineasGuion()                                    n/a                     ----------------------------------------
        '   // AgregaArticulo("Aspirina","2",45.25,90.5)        16,3,10,11              Aspirina          2    $45.25     $90.50
        '   // LineasTotales()                                  n/a                                                ----------
        '   // AgregaTotales("Subtotal",235.25)                 25 y 15                Subtotal                         $235.25
        '   // LineasAsterisco()                                n/a                     ****************************************
        '   // LineasIgual()                                    n/a                     ========================================des
        '   // CortaTicket()
        '   // AbreCajon()
        Dim instance As New Printing.PrinterSettings
        Dim impresosaPredt As String = instance.PrinterName
        ' Dim Descp As String
        'Dim Totallinea As String
        Dim Hora As String
        Hora = DateTime.Now.ToString("h:mm:ss")
        Dim total As String
        Dim Ticket1 As New CreaTicket()
        Ticket1.impresora = impresosaPredt
        Ticket1.AbreCajon()

        Ticket1.TextoIzquierda("RECIBO DE INGRESO")
        If Not esvacio("no") Then Ticket1.TextoIzquierda(informaciongym("no"))
        If Not esvacio("nit") Then Ticket1.TextoIzquierda("Nit: " + informaciongym("nit"))
        If Not esvacio("regimen") Then Ticket1.TextoIzquierda("Regimen: " + informaciongym("regimen"))
        If Not esvacio("propietario") Then Ticket1.TextoIzquierda(informaciongym("propietario"))
        If Not esvacio("telefono") Then Ticket1.TextoIzquierda("Tel: " + informaciongym("telefono"))
        If Not esvacio("direccion") Then Ticket1.TextoIzquierda("Dir: " + informaciongym("direccion"))
        Ticket1.LineasIgual()
        Ticket1.TextoIzquierda("CLIENTE : " + cliente)
        Ticket1.TextoIzquierda("CC   : " + cedula)
        Ticket1.TextoIzquierda("CAJERO  : " & Principal.strUsuario & "")
        Ticket1.TextoExtremos("FECHA: " + Trim(Now.Date), "HORA: " + Hora)
        Ticket1.LineasIgual()
        Ticket1.EncabezadoVenta()
        Ticket1.LineasIgual()
        Dim i As Integer = 1

        Dim idproducto As Integer = 0
        Dim cantidad As Integer = 0
        Dim precio As Integer = 0
        For Each item As ListViewItem In detalle.Items
            idproducto = Convert.ToInt32(item.Tag)
            cantidad = Convert.ToInt32(item.SubItems(0).Text)
            precio = Convert.ToInt32(item.SubItems(2).Text)
            Ticket1.TextoIzquierda(nombreArticuloById(idproducto) & "   " & cantidad & "  " & precio) 'imprime una linea de descripcion
        Next


        Ticket1.LineasIgual()
        total = (valor)
        Ticket1.AgregaTotales(" TOTAL", total) ' // imprime linea con total
        Ticket1.LineasTotales()
        Ticket1.LineasIgual()
        Ticket1.TextoCentro("EL GIMNASIO NO SE HACE")
        Ticket1.TextoCentro("RESPONSABLE DE OBJETOS")
        Ticket1.TextoCentro("PERDIDOS")
        Ticket1.TextoCentro("...................")
        Ticket1.CortaTicket()

    End Sub

End Class

