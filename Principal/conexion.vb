Imports MySql.Data.MySqlClient
Imports System.IO

Public Class conexion
    Dim Gestor1 As New Soltec.Gestor

    Dim cliete As Clientes
    Public conexion As New MySqlConnection
    Public Function registreDatos(consulta As String) As Boolean
        Dim booRegistrado As Boolean = False
        Try
            Dim conectar As New MySqlConnection(Principal.cadenadeconexion)
            Dim cmd As New MySqlCommand(consulta, conectar)
            cmd.CommandText = consulta
            conectar.Open()
            If cmd.ExecuteNonQuery() = 1 Then
                booRegistrado = True
            End If
            conectar.Close()
            conectar.Dispose()
        Catch ex As Exception
            booRegistrado = False
            MsgBox(ex.Message)
        End Try
        Return booRegistrado
    End Function
    Function saberSaldo(strcedula As String, Optional ByRef tipo As Integer = 0) As Boolean
        Dim boosaldo As Boolean = False
        Dim arlCoincidencias As ArrayList
        If tipo > 0 Then
            arlCoincidencias = Gestor1.DatosDeConsulta("SELECT * FROM abonos WHERE cedula= '" & strcedula & "' and det=2", , Principal.cadenadeconexion)
        Else
            arlCoincidencias = Gestor1.DatosDeConsulta("SELECT * FROM abonos WHERE cedula= '" & strcedula & "'", , Principal.cadenadeconexion)
        End If

        If Not arlCoincidencias.Count = 0 Then
            boosaldo = True
        End If
        Return boosaldo
    End Function
    Function Extraersaldo(strcedula As String, nombre As TextBox, txtsaldo As TextBox, txtabon As TextBox) As Boolean
        Dim boosaber As Boolean = False
        Dim arlCoincidencias = Gestor1.DatosDeConsulta("SELECT c.nombre,c.apellido,a.saldo,a.abono FROM cliente AS c, abonos AS a" & vbCrLf &
        " WHERE a.cedula = c.cedula And a.estado = 1 And c.cedula ='" & strcedula & "'", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then
            For Each registro As ArrayList In arlCoincidencias
                boosaber = True
                nombre.Text = registro(0) & " " & registro(1)
                txtabon.Text = registro(3)
                txtsaldo.Text = registro(2)

            Next
        End If
        Return boosaber
    End Function
    Public Sub mostraReportes(lstTarifas As ListView, nombre As String)
        Dim arlCoincidencias = Gestor1.DatosDeConsulta("SELECT id,no FROM reporte WHERE no like '% '" & nombre & "' %'", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then lstTarifas.Visible = True
        lstTarifas.Items.Clear()
        lstTarifas.BeginUpdate()
        For Each Encontrado As ArrayList In arlCoincidencias
            Dim lviEncontrado As New ListViewItem
            lviEncontrado.Tag = Encontrado(0)
            lviEncontrado.Text = Encontrado(1)
            lstTarifas.Items.Add(lviEncontrado)
        Next
        lstTarifas.EndUpdate()

    End Sub

    Public Sub VisualizarRortes(lstreporte As ListView, fdesde As Date, fhasta As Date, intIdReperte As Integer, totales As TextBox, Optional idcliente As Integer = 0, Optional ByVal idusuario As Integer = 0, Optional ByVal intTarjeta As Integer = 0, Optional ByVal intSaldoVenta As Integer = 0, Optional ByVal intInstructor As Integer = 0, Optional ByRef strhorafac As String = "<24", Optional ByVal inttipoBusquedaVenta As Integer = 0)
        Dim Consulta As String = ""
        Dim ColumnasEsNumero() As Boolean = Nothing
        Dim ColumnasJustificaciones() As Integer = Nothing
        Dim FilasEtiquetas() As Integer = Nothing
        Dim ColumnasAmplitudes() As Integer = Nothing
        Dim booPromediar As Boolean = True
        Dim total As Integer = 0
        Select Case intIdReperte
            Case 1

                If intTarjeta = 1 Then
                    Consulta = "SELECT d.id,d.cedula AS Cedula,CONCAT(UPPER(c.nombre),' ',UPPER(c.apellido)) as Cliente,UPPER(tiempo) AS Descripcion,Valor,LEFT(d.fecha_pago,10)AS Fecha, bc.no as Banco" & vbCrLf &
                                                           "FROM detalles d,cliente c,bancoscuentas bc WHERE c.cedula=d.cedula AND tarjeta='" & intTarjeta & "' and bc.id=d.banco  and d.fecha_pago  " & vbCrLf &
                                                           " BETWEEN STR_TO_DATE('" & fdesde & "','%d/%m/%Y') AND STR_TO_DATE('" & fhasta & "','%d/%m/%Y') order by d.id "
                    FilasEtiquetas = {0, 1, 2, 3, 4, 5, 6}
                    ColumnasEsNumero = {False, False, False, False, True, False, False}
                    ColumnasJustificaciones = {0, 0, 0, 1, 1, 1, 1}
                    ColumnasAmplitudes = {0, 100, 250, 150, 100, 100, 100}
                Else
                    Consulta = "SELECT d.id,d.cedula AS Cedula,CONCAT(UPPER(c.nombre),' ',UPPER(c.apellido)) as Cliente,UPPER(tiempo) AS Descripcion,Valor,LEFT(d.fecha_pago,10)AS Fecha" & vbCrLf &
                                                           "FROM detalles d,cliente c WHERE c.cedula=d.cedula AND tarjeta='" & intTarjeta & "' and d.fecha_pago  " & vbCrLf &
                                                           "BETWEEN STR_TO_DATE('" & fdesde & "','%d/%m/%Y') AND STR_TO_DATE('" & fhasta & "','%d/%m/%Y')  order by d.id"

                    FilasEtiquetas = {0, 1, 2, 3, 4, 5}
                    ColumnasEsNumero = {False, False, False, False, True, False}
                    ColumnasJustificaciones = {0, 0, 0, 1, 1, 1}
                    ColumnasAmplitudes = {0, 100, 250, 150, 100, 100}
                End If

                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                Dim douSaldoEx As Double = 0
                For i As Integer = 1 To arlDatos1.Count - 1
                    If Not arlDatos1(i)(4).ToString.Equals("") Then
                        douSaldoEx += arlDatos1(i)(4)
                        totales.Text = douSaldoEx
                    End If
                Next
                booPromediar = False
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, True, booPromediar)
                Exit Sub
            Case 2
                Consulta = "SELECT a.idabonos AS id,c.cedula,CONCAT(UPPER(c.nombre),' ',UPPER(c.apellido)) AS Nombre,a.abono AS Abono,a.saldo AS Saldo,LEFT(a.mo,10) as Fecha " & vbCrLf &
                    "FROM cliente c,abonos a WHERE c.cedula=a.cedula AND a.estado=1 ORDER BY c.nombre ASC"
                FilasEtiquetas = {0, 0, 1, 2, 3, 4}
                ColumnasEsNumero = {False, False, False, True, True, False}
                ColumnasJustificaciones = {0, 0, 0, 1, 1, 1}
                ColumnasAmplitudes = {0, 100, 200, 150, 150, 100}
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                Dim douSaldoEx As Double = 0
                For i As Integer = 1 To arlDatos1.Count - 1
                    If Not arlDatos1(i)(4).ToString.Equals("") Then
                        douSaldoEx += arlDatos1(i)(4)
                        totales.Text = douSaldoEx
                    End If
                Next
                booPromediar = False
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, , booPromediar)
                Exit Sub
            Case 3
                Consulta = "SELECT  tp.nombre AS Nombre,g.descripcion AS Descripcion,g.valor AS Valor,LEFT(g.fecha,10) AS Fecha " & vbCrLf &
                    "FROM gastos g,tipogasto tp WHERE g.idtipo=tp.id " & vbCrLf &
                  " AND g.fecha BETWEEN STR_TO_DATE('" & fdesde & "','%d/%m/%Y') AND STR_TO_DATE('" & fhasta & "','%d/%m/%Y') "
                FilasEtiquetas = {0, 1, 2, 3}
                ColumnasEsNumero = {False, False, True, False}
                ColumnasJustificaciones = {0, 0, 1, 1}
                ColumnasAmplitudes = {200, 200, 150, 150}
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                Dim douSaldoEx As Double = 0
                For i As Integer = 1 To arlDatos1.Count - 1
                    If Not arlDatos1(i)(2).ToString.Equals("") Then
                        douSaldoEx += arlDatos1(i)(2)
                        totales.Text = douSaldoEx
                    End If

                Next
                booPromediar = False
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, True, booPromediar)
                Exit Sub

            Case 4 'clientes por vencer
                Consulta = "SELECT c.cedula AS Cedula,CONCAT(c.nombre,' ',c.apellido) AS Nombre,RIGHT(p.fecha_corte,10) AS 'Fecha final', pr.tipo AS " & vbCrLf & "Detalle,pr.valor as Valor" & vbCrLf &
                            "FROM cliente c,pago p,precio pr WHERE c.cedula=p.cedula AND p.idprecio=pr.serial AND fecha_corte >= current_date " & vbCrLf & "ORDER BY fecha_corte ASC LIMIT 200"
                FilasEtiquetas = {0, 1, 2, 3, 4}
                ColumnasEsNumero = {False, False, False, False, True}
                ColumnasJustificaciones = {0, 0, 1, 1, 1}
                ColumnasAmplitudes = {100, 200, 150, 150, 100}
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                Dim douSaldoEx As Double = 0
                For i As Integer = 1 To arlDatos1.Count - 1
                    If Not arlDatos1(i)(3).ToString.Equals("") Then
                        ' douSaldoEx += arlDatos1(i)(3)
                        'totales.Text = douSaldoEx
                    End If
                Next
                booPromediar = False
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, , booPromediar)
                pintarFilas(lstreporte, intIdReperte)
                Exit Sub
            Case 5
                Consulta = "SELECT c.cedula AS Cedula, c.nombre AS Nombre,c.apellido AS Apellido,c.telefono as Contacto,pr.tipo AS Tarifa,LEFT(p.fecha_pago,10) AS 'Fecha Inicial',LEFT(p.fecha_corte,10) AS 'Fecha Final'" & vbCrLf &
                            "FROM  cliente c,pago p,precio pr" & vbCrLf &
                            "WHERE c.cedula=p.cedula and p.idprecio=pr.serial AND P.fecha_corte >=current_date order by c.nombre"
                FilasEtiquetas = {0, 1, 2, 3, 4, 5, 6}
                ColumnasEsNumero = {False, False, False, False, False, False, False}
                ColumnasJustificaciones = {0, 0, 1, 1, 1, 1, 1}
                ColumnasAmplitudes = {80, 120, 120, 120, 150, 150, 150}
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                Dim douSaldoEx As Double = 0
                booPromediar = False
                totales.Text = "TOTAL ACTIVOS  " & arlDatos1.Count - 1
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, , booPromediar)

                Exit Sub
            Case 6
                Consulta = "SELECT cedula AS Cedula,nombre AS Nombre,apellido AS Apellido,telefono AS Telefono FROM CLIENTE ORDER BY nombre"
                FilasEtiquetas = {0, 1, 2, 3}
                ColumnasEsNumero = {False, False, False, False}
                ColumnasJustificaciones = {0, 1, 1, 1}
                ColumnasAmplitudes = {100, 200, 200, 150}
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                Dim douSaldoEx As Double = 0
                booPromediar = False
                totales.Text = "TOTAL CLIENTES  " & arlDatos1.Count - 1
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, , booPromediar)

                Exit Sub
            Case 7
                fhasta = DateAdd(DateInterval.Day, 1, fhasta)
                Consulta = "SELECT cedula as Cedula,concat(upper(nombre) ,' ',upper(apellido))as Nombre,left(fecha,10) as Fecha, right(fecha,8) as Hora" & vbCrLf &
                            "FROM empleado e,reporte_empleado r " & vbCrLf &
                            "WHERE e.cedula=r.idempleado  AND r.fecha >= STR_TO_DATE('" & fdesde & "','%d/%m/%Y') AND r.fecha <=  STR_TO_DATE('" & fhasta & "','%d/%m/%Y') "
                FilasEtiquetas = {0, 1, 2, 3}
                ColumnasEsNumero = {False, False, False, False}
                ColumnasJustificaciones = {0, 0, 1, 1}
                ColumnasAmplitudes = {100, 300, 150, 150, 150}
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                Dim douSaldoEx As Double = 0
                booPromediar = False
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, , booPromediar)
                Exit Sub
            Case 8
                fhasta = DateAdd(DateInterval.Day, 1, fhasta)
                Consulta = "select f.id_factura AS Factura,CONCAT(c.nombre,' ',c.apellido) AS Cliente,sum(d.detpro_cantidad*d.detpro_precio) AS Total, left(fac_fecha,10) AS Fecha" & vbCrLf &
                            "from factura f,detalle_producto d,producto p,cliente c" & vbCrLf &
                           " WHERE detpro_idfactura = id_factura" & vbCrLf &
                            "AND detpro_idproducto=p.id" & vbCrLf &
                           "AND c.id=f.fac_idcliente" & vbCrLf &
                            "AND f.fac_fecha >= STR_TO_DATE('" & fdesde & "','%d/%m/%Y') AND f.fac_fecha <  STR_TO_DATE('" & fhasta & "','%d/%m/%Y')  " & vbCrLf &
                            "GROUP BY f.id_factura"
                FilasEtiquetas = {0, 1, 2, 3}
                ColumnasEsNumero = {False, False, True, False}
                ColumnasJustificaciones = {0, 0, 1, 1}
                ColumnasAmplitudes = {100, 300, 150, 150}
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                Dim douSaldoEx As Double = 0
                For i As Integer = 1 To arlDatos1.Count - 1
                    If Not arlDatos1(i)(2).ToString.Equals("") Then
                        douSaldoEx += arlDatos1(i)(2)
                        totales.Text = douSaldoEx
                    End If
                Next
                booPromediar = False
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, , booPromediar)
                Exit Sub
            Case 9
                fhasta = DateAdd(DateInterval.Day, 1, fhasta)

                If inttipoBusquedaVenta = 1 Then
                    Consulta = " select f.id_factura AS Factura,CONCAT(c.nombre,' ',c.apellido) AS Cliente,d.detpro_cantidad as Cantidad,p.pro_nombre AS Nombre,p.pro_preciocosto as 'P Costo', " & vbCrLf &
                          " d.detpro_precio AS 'P Venta',(d.detpro_cantidad*d.detpro_precio)AS Total, left(fac_fecha,10) As Fecha " & vbCrLf &
                           "from factura f,detalle_producto d,producto p,cliente c" & vbCrLf &
                          " WHERE detpro_idfactura = id_factura" & vbCrLf &
                          "AND detpro_idproducto=p.id" & vbCrLf &
                          "AND c.id=f.fac_idcliente" & vbCrLf &
                          "AND c.id= " & idcliente & " " & vbCrLf &
                          "AND f.fac_fecha >= STR_TO_DATE('" & fdesde & "','%d/%m/%Y') AND f.fac_fecha <  STR_TO_DATE('" & fhasta & "','%d/%m/%Y')  and hour(fac_fecha)" & strhorafac & ""
                Else
                    Consulta = " select f.id_factura AS Factura,CONCAT(c.nombre,' ',c.apellido) AS Cliente,d.detpro_cantidad as Cantidad,p.pro_nombre AS Nombre,p.pro_preciocosto as 'P Costo', " & vbCrLf &
                           " d.detpro_precio AS 'P Venta',(d.detpro_cantidad*d.detpro_precio)AS Total, left(fac_fecha,10) As Fecha " & vbCrLf &
                            "from factura f,detalle_producto d,producto p,cliente c" & vbCrLf &
                           " WHERE detpro_idfactura = id_factura" & vbCrLf &
                           "AND detpro_idproducto=p.id" & vbCrLf &
                           "AND c.id=f.fac_idcliente" & vbCrLf &
                           "AND f.fac_fecha >= STR_TO_DATE('" & fdesde & "','%d/%m/%Y') AND f.fac_fecha <  STR_TO_DATE('" & fhasta & "','%d/%m/%Y')  and hour(fac_fecha)" & strhorafac & ""
                End If
                FilasEtiquetas = {0, 1, 2, 3, 4, 5, 6, 7}
                ColumnasEsNumero = {False, False, True, False, True, True, True, False}
                ColumnasJustificaciones = {0, 0, 1, 0, 1, 1, 1, 1}
                ColumnasAmplitudes = {80, 150, 60, 160, 90, 90, 70, 90}
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                Dim douSaldoEx As Double = 0
                For i As Integer = 1 To arlDatos1.Count - 1
                    If Not arlDatos1(i)(6).ToString.Equals("") Then
                        douSaldoEx += arlDatos1(i)(6)
                        totales.Text = douSaldoEx
                    End If
                Next
                booPromediar = False
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, , booPromediar)
                Exit Sub
            Case 10
                fhasta = DateAdd(DateInterval.Day, 1, fhasta)
                Consulta = "SELECT  CONCAT(c.nombre,' ',c.apellido) as CLiente,co.cant as Cantidad,LEFT(co.mo,10) AS Fecha " & vbCrLf &
                    "FROM cortesias co,cliente c  WHERE co.idcliente=c.id " & vbCrLf &
                  " AND co.mo BETWEEN STR_TO_DATE('" & fdesde & "','%d/%m/%Y') AND STR_TO_DATE('" & fhasta & "','%d/%m/%Y') "
                FilasEtiquetas = {0, 1, 2}
                ColumnasEsNumero = {False, False, False}
                ColumnasJustificaciones = {0, 0, 1}
                ColumnasAmplitudes = {200, 200, 150}
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                booPromediar = False
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, , booPromediar)
                Exit Sub
            Case 11
                fhasta = DateAdd(DateInterval.Day, 1, fhasta)
                Consulta = " SELECT c.cedula,CONCAT(c.nombre,' ',c.apellido)AS Nombre,co.mo,co.dias " & vbCrLf &
                            "FROM congelado co,cliente c " & vbCrLf &
                            "WHERE c.cedula=co.cedula and co.estado=1 "
                FilasEtiquetas = {0, 1, 2, 3}
                ColumnasEsNumero = {False, False, False, False}
                ColumnasJustificaciones = {0, 0, 1, 1}
                ColumnasAmplitudes = {100, 300, 200, 80}
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                Dim douSaldoEx As Double = 0
                booPromediar = False
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, , booPromediar)
                Exit Sub
            Case 12
                fhasta = DateAdd(DateInterval.Day, 1, fhasta)
                Consulta = "SELECT d.tiempo AS Tipo,SUM(d.valor) AS Total,COUNT(d.tiempo) AS Cantidad" & vbCrLf &
                            "FROM detalles d" & vbCrLf &
                            "WHERE tarjeta='" & intTarjeta & "' and " & vbCrLf &
                             " d.fecha_pago >= STR_TO_DATE('" & fdesde & "','%d/%m/%Y') AND d.fecha_pago < STR_TO_DATE('" & fhasta & "','%d/%m/%Y') " & vbCrLf &
                            "GROUP BY d.tiempo" & vbCrLf &
                            "UNION" & vbCrLf &
                            "SELECT 'SALDO',SUM(d2.VALOR),COUNT(d2.tiempo) FROM DETALLES d2 WHERE d2.tiempo='SALDO' " & vbCrLf &
                            "AND d2.fecha_pago >= STR_TO_DATE('" & fdesde & "','%d/%m/%Y') AND  d2.fecha_pago < STR_TO_DATE('" & fhasta & "','%d/%m/%Y') " & vbCrLf &
                            "UNION " & vbCrLf &
                            "SELECT 'INGRESO SPA',SUM(dp.detpro_precio),COUNT(dp.detpro_cantidad) " & vbCrLf &
                            "FROM factura f,detalle_producto dp " & vbCrLf &
                            "WHERE f.id_factura=dp.detpro_idfactura AND f.fac_tipo=3" & vbCrLf &
                            "AND f.fac_fecha >= STR_TO_DATE('" & fdesde & "','%d/%m/%Y') AND  f.fac_fecha < STR_TO_DATE('" & fhasta & "','%d/%m/%Y') " & vbCrLf &
                            " UNION " & vbCrLf &
                            "SELECT 'TOTAL CAFETERIA',SUM(detpro_cantidad*detpro_precio),SUM(DP.DETPRO_CANTIDAD) " & vbCrLf &
                            "FROM factura f,detalle_producto dp " & vbCrLf &
                            " WHERE f.id_factura=dp.detpro_idfactura AND f.fac_tipo=2" & vbCrLf &
                            "AND f.fac_fecha >= STR_TO_DATE('" & fdesde & "','%d/%m/%Y') AND  f.fac_fecha < STR_TO_DATE('" & fhasta & "','%d/%m/%Y')"
                FilasEtiquetas = {0, 1, 2}
                ColumnasEsNumero = {False, True, True}
                ColumnasJustificaciones = {0, 0, 0}
                ColumnasAmplitudes = {300, 300, 200}
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                Dim douSaldoEx As Double = 0
                For i As Integer = 1 To arlDatos1.Count - 1
                    If Not arlDatos1(i)(1).ToString.Equals("") Then
                        douSaldoEx += arlDatos1(i)(1)
                        totales.Text = douSaldoEx
                    End If
                Next
                booPromediar = False
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, , booPromediar)
                Exit Sub
            Case 13
                fhasta = DateAdd(DateInterval.Day, 1, fhasta)
                Consulta = " SELECT c.cedula AS Cedula,CONCAT(c.nombre,' ',c.apellido) AS Cliente,c.telefono AS Telefono,tiempo AS Tarifa,SUM(valor) AS Total," & vbCrLf &
                            "(SElECT COUNT(*) FROM entrada e WHERE c.cedula=e.cedula and  e.fecha BETWEEN STR_TO_DATE('" & fdesde & "','%d/%m/%Y') AND STR_TO_DATE('" & fhasta & "','%d/%m/%Y') ) as Ingresos " & vbCrLf &
                            "FROM detalles d,cliente c " & vbCrLf &
                            "where c.cedula=d.cedula AND d.fecha_pago BETWEEN STR_TO_DATE('" & fdesde & "','%d/%m/%Y') AND STR_TO_DATE('" & fhasta & "','%d/%m/%Y') " & vbCrLf &
                            "GROUP BY cedula  " & vbCrLf &
                            "ORDER BY c.nombre"
                FilasEtiquetas = {0, 1, 2, 3, 4, 5}
                ColumnasEsNumero = {False, False, False, False, True, False}
                ColumnasJustificaciones = {0, 0, 0, 0, 0, 0}
                ColumnasAmplitudes = {120, 280, 120, 120, 120, 90}
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                Dim douSaldoEx As Double = 0
                For i As Integer = 1 To arlDatos1.Count - 1
                    If Not arlDatos1(i)(4).ToString.Equals("") Then
                        douSaldoEx += arlDatos1(i)(4)
                        totales.Text = douSaldoEx
                    End If
                Next
                booPromediar = False
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, , booPromediar)
                Exit Sub
            Case 14
                fhasta = DateAdd(DateInterval.Day, 1, fhasta)
                Consulta = "SELECT EXTRACT(HOUR FROM FECHA) AS Hora,count(*) AS Cantidad" & vbCrLf &
                            "FROM ENTRADA " & vbCrLf &
                            "WHERE fecha >= STR_TO_DATE('" & fdesde & "','%d/%m/%Y') AND fecha < STR_TO_DATE('" & fhasta & "','%d/%m/%Y') " & vbCrLf &
                            "GROUP BY hora ORDER BY hora asc"
                FilasEtiquetas = {0, 1}
                ColumnasEsNumero = {False, False}
                ColumnasJustificaciones = {0, 0}
                ColumnasAmplitudes = {300, 200}
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                Dim douSaldoEx As Double = 0
                For i As Integer = 1 To arlDatos1.Count - 1
                    If Not arlDatos1(i)(1).ToString.Equals("") Then
                        douSaldoEx += arlDatos1(i)(1)
                        totales.Text = douSaldoEx
                    End If
                Next
                booPromediar = False
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, , booPromediar)

                Exit Sub
            Case 15
                fhasta = DateAdd(DateInterval.Day, 1, fhasta)
                Consulta = "SELECT f.id_factura AS Factura,LEFT(f.fac_fecha,10) AS Fecha,CONCAT(c.nombre,' ',c.apellido)AS Proveedor, SUM(k.cantidad*k.valor) AS Total,u.usuario AS Vendedor" & vbCrLf &
                            "FROM factura f,cliente c,login u,kardex k " & vbCrLf &
                            "WHERE f.fac_tipo = 1 And f.id_factura = k.idfactura " & vbCrLf &
                            "AND f.fac_idempleado=u.id AND f.fac_idcliente=c.id" & vbCrLf &
                            "AND f.fac_fecha >= STR_TO_DATE('" & fdesde & "','%d/%m/%Y') AND f.fac_fecha <  STR_TO_DATE('" & fhasta & "','%d/%m/%Y')  " & vbCrLf &
                            "GROUP BY f.id_factura"

                FilasEtiquetas = {0, 1, 2, 3, 4}
                ColumnasEsNumero = {False, False, False, True, False}
                ColumnasJustificaciones = {0, 0, 0, 0, 0}
                ColumnasAmplitudes = {100, 150, 300, 150, 150}
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                Dim douSaldoEx As Double = 0
                For i As Integer = 1 To arlDatos1.Count - 1
                    If Not arlDatos1(i)(3).ToString.Equals("") Then
                        douSaldoEx += arlDatos1(i)(3)
                        totales.Text = douSaldoEx
                    End If
                Next
                booPromediar = False
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, , booPromediar)
                Exit Sub
            Case 16
                fhasta = DateAdd(DateInterval.Day, 1, fhasta)
                Consulta = "SELECT f.id_factura AS Factura,LEFT(f.fac_fecha,10) AS Fecha,CONCAT(c.nombre,' ',c.apellido)AS Proveedor,p.pro_nombre AS Articulo,k.cantidad AS Cantidad,k.valor AS Costo,k.cantidad*k.valor AS Subtotal,u.usuario AS Vendedor " & vbCrLf &
                            "FROM factura f,cliente c,login u,kardex k,producto p " & vbCrLf &
                            "WHERE f.fac_tipo = 1 And f.id_factura = k.idfactura And " & vbCrLf &
                            "k.idproducto = p.id And f.fac_idempleado = u.id And f.fac_idcliente = c.id " & vbCrLf &
                            "AND f.fac_fecha >= STR_TO_DATE('" & fdesde & "','%d/%m/%Y') AND f.fac_fecha <  STR_TO_DATE('" & fhasta & "','%d/%m/%Y')"

                FilasEtiquetas = {0, 1, 2, 3, 4, 5, 6, 7}
                ColumnasEsNumero = {False, False, False, False, True, True, True, False}
                ColumnasJustificaciones = {0, 0, 0, 0, 1, 1, 1, 1}
                ColumnasAmplitudes = {80, 100, 160, 140, 80, 80, 70, 90}
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                Dim douSaldoEx As Double = 0
                For i As Integer = 1 To arlDatos1.Count - 1
                    If Not arlDatos1(i)(6).ToString.Equals("") Then
                        douSaldoEx += arlDatos1(i)(6)
                        totales.Text = douSaldoEx
                    End If
                Next
                booPromediar = False
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, , booPromediar)
                Exit Sub
            Case 17
                fhasta = DateAdd(DateInterval.Day, 1, fhasta)
                Consulta = "SELECT p.pro_nombre AS Nombre,k.cantidad AS Ajuste,k.scantidad 'Cant Nueva',k.costo AS costo,k.costo*k.cantidad AS Subtotal,k.nota AS Nota,l.usuario AS Responsable,LEFT(k.modificado,10) AS Fecha  " & vbCrLf &
                            "FROM kardex k,producto p,login l,tipomovimiento tp " & vbCrLf &
                            "WHERE k.idproducto = p.id" & vbCrLf &
                            "AND l.id=k.idfactura" & vbCrLf &
                            "AND k.mov=tp.id" & vbCrLf &
                            "AND tp.id=6" & vbCrLf &
                            "AND k.modificado >= STR_TO_DATE('" & fdesde & "','%d/%m/%Y') AND k.modificado <  STR_TO_DATE('" & fhasta & "','%d/%m/%Y')"

                FilasEtiquetas = {0, 1, 2, 3, 4, 5, 6, 7}
                ColumnasEsNumero = {False, True, True, True, True, False, False, False}
                ColumnasJustificaciones = {0, 0, 0, 0, 1, 1, 1, 1}
                ColumnasAmplitudes = {130, 80, 80, 80, 80, 140, 90, 90}
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                Dim douSaldoEx As Double = 0
                For i As Integer = 1 To arlDatos1.Count - 1
                    If Not arlDatos1(i)(4).ToString.Equals("") Then
                        douSaldoEx += arlDatos1(i)(4)
                        totales.Text = douSaldoEx
                    End If
                Next
                booPromediar = False
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, , booPromediar)
                Exit Sub

            Case 18
                Consulta = "SELECT c.cedula  AS Cedula, CONCAT(nombre,' ',apellido) AS Nombre, Telefono AS Telefono,left(Nacimiento,10) AS Nacimiento  " & vbCrLf &
                            "FROM cliente c,pago p" & vbCrLf &
                            "WHERE c.cedula=p.cedula and p.fecha_corte>=current_date " & vbCrLf &
                            "ORDER BY Month(nacimiento),day (nacimiento)"
                FilasEtiquetas = {0, 1, 2, 3}
                ColumnasEsNumero = {False, False, False, False}
                ColumnasJustificaciones = {0, 0, 1, 1}
                ColumnasAmplitudes = {100, 400, 150, 150}
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                Dim douSaldoEx As Double = 0
                booPromediar = False
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, , booPromediar)
                Exit Sub
            Case 19
                fdesde = DateAdd(DateInterval.Day, 0, Now)
                Consulta = "SELECT c.cedula AS cedula, CONCAT(c.nombre,' ',c.apellido) AS Nombre,c.telefono AS Telefono,(select tiempo from detalles where cedula=c.cedula order by id desc limit 1) 'Ultima tarifa'," & vbCrLf &
                          "left(p.fecha_corte,10) AS 'Ultimo Ingreso' " & vbCrLf &
                            "FROM CLIENTE c,PAGO p,detalles d " & vbCrLf &
                            "WHERE c.cedula = p.cedula " & vbCrLf &
                            "AND c.cedula=d.cedula " & vbCrLf &
                            "AND p.fecha_corte <= STR_TO_DATE('" & fdesde & "','%d/%m/%Y')" & vbCrLf &
                            "GROUP BY c.cedula ORDER BY p.fecha_corte"
                FilasEtiquetas = {0, 1, 2, 3, 4}
                ColumnasEsNumero = {False, False, False, False, False}
                ColumnasJustificaciones = {0, 0, 0, 0, 0}
                ColumnasAmplitudes = {80, 280, 100, 150, 150}
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                Dim douSaldoEx As Double = 0
                booPromediar = False
                totales.Text = "TOTAL CLIENTES  " & arlDatos1.Count - 1
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, , booPromediar)

                Exit Sub
            Case 20   'informe del mes por dia
                fhasta = DateAdd(DateInterval.Day, 1, fhasta)
                Consulta = "SELECT (ELT(WEEKDAY(d.fecha_pago) + 1, 'Lunes', 'Martes', 'Miercoles', 'Jueves', 'Viernes', 'Sabado', 'Domingo')) AS 'Dia Semanal'," & vbCrLf &
                            "LEFT(d.fecha_pago,10) AS Fecha,sum(d.valor) AS Total,(select count(*)FROM detalles de WHERE YEAR(de.fecha_pago)=YEAR(d.fecha_pago) AND MONTH(de.fecha_pago)=MONTH(d.fecha_pago) AND day(de.fecha_pago)=day(d.fecha_pago)) AS 'Total Afiliados'     " & vbCrLf &
                            "FROM detalles d " & vbCrLf &
                            "WHERE d.fecha_pago >= STR_TO_DATE('" & fdesde & "','%d/%m/%Y') AND d.fecha_pago <  STR_TO_DATE('" & fhasta & "','%d/%m/%Y')" & vbCrLf &
                            "GROUP BY d.fecha_pago"

                FilasEtiquetas = {0, 1, 2, 3}
                ColumnasEsNumero = {False, False, True, True}
                ColumnasJustificaciones = {1, 1, 1, 1}
                ColumnasAmplitudes = {130, 150, 150, 150}
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                Dim douSaldoEx As Double = 0
                For i As Integer = 1 To arlDatos1.Count - 1
                    If Not arlDatos1(i)(2).ToString.Equals("") Then
                        douSaldoEx += arlDatos1(i)(2)
                        totales.Text = douSaldoEx
                    End If
                Next
                booPromediar = False
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, , booPromediar)
                Exit Sub
            Case 21

                fhasta = DateAdd(DateInterval.Day, 1, fhasta)
                Consulta = " select f.id_factura AS Factura,CONCAT(c.nombre,' ',c.apellido) AS Cliente,d.detpro_cantidad as Cantidad,'Servicio Spa'," & vbCrLf &
                           " d.detpro_precio AS 'Valor',left(fac_fecha,10) As Fecha " & vbCrLf &
                            "from factura f,detalle_producto d,cliente c" & vbCrLf &
                           " WHERE detpro_idfactura = id_factura" & vbCrLf &
                            "AND detpro_idproducto=1" & vbCrLf &
                           "AND c.cedula=f.fac_idcliente" & vbCrLf &
                            "AND f.fac_fecha >= STR_TO_DATE('" & fdesde & "','%d/%m/%Y') AND f.fac_fecha <  STR_TO_DATE('" & fhasta & "','%d/%m/%Y')"
                FilasEtiquetas = {0, 1, 2, 3, 4, 5}
                ColumnasEsNumero = {True, False, True, False, True, False}
                ColumnasJustificaciones = {0, 0, 1, 0, 1, 1}
                ColumnasAmplitudes = {80, 200, 60, 200, 100, 100}
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                Dim douSaldoEx As Double = 0
                For i As Integer = 1 To arlDatos1.Count - 1
                    If Not arlDatos1(i)(4).ToString.Equals("") Then
                        douSaldoEx += arlDatos1(i)(4)
                        totales.Text = douSaldoEx
                    End If
                Next
                booPromediar = False
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, , booPromediar)
                Exit Sub
            Case 22
                fhasta = DateAdd(DateInterval.Day, 1, fhasta)
                Consulta = "SELECT t1.factura AS Factura, p.pro_nombre as Articulo,t1.cantidad AS Cantidad,(t1.cantidad*t1.pventa) AS 'Total Venta',(t1.cantidad*t1.costo) AS 'Costo de Venta', " & vbCrLf &
                                   "((t1.cantidad*t1.pventa)-(t1.cantidad*t1.costo)) AS 'Utilidad',t1.fecha AS Fecha " & vbCrLf &
                            "FROM producto p, " & vbCrLf &
                                    "(SELECT f.id_factura AS factura,d.detpro_idproducto AS idproducto,d.detpro_cantidad as cantidad,d.detpro_precio as pventa,k.costo AS costo, left(f.fac_fecha,10) as fecha " & vbCrLf &
                                    "FROM factura f,detalle_producto d,kardex k " & vbCrLf &
                                    "WHERE f.id_factura = detpro_idfactura " & vbCrLf &
                                    "AND f.id_factura=k.idfactura) as t1 " & vbCrLf &
                            "WHERE p.id=t1.idproducto " & vbCrLf &
                            "AND t1.fecha >= STR_TO_DATE('" & fdesde & "','%d/%m/%Y') AND t1.fecha <  STR_TO_DATE('" & fhasta & "','%d/%m/%Y')"
                FilasEtiquetas = {0, 1, 2, 3, 4, 5, 6}
                ColumnasEsNumero = {False, False, True, True, True, True, False}
                ColumnasJustificaciones = {0, 0, 0, 0, 1, 1, 1}
                ColumnasAmplitudes = {90, 150, 80, 120, 120, 120, 90}
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                Dim douSaldoEx As Double = 0
                For i As Integer = 1 To arlDatos1.Count - 1
                    If Not arlDatos1(i)(5).ToString.Equals("") Then
                        douSaldoEx += arlDatos1(i)(5)
                        totales.Text = douSaldoEx
                    End If
                Next
                booPromediar = False
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, , booPromediar)
                Exit Sub
            Case 23  'Clientes por  mes
                fhasta = DateAdd(DateInterval.Day, 1, fhasta)
                Consulta = "  SELECT CASE month(d.fecha_pago) " & vbCrLf &
                             "WHEN 1 then 'ENERO'  WHEN 2 THEN 'FEBRERO'  WHEN 3 THEN 'MARZO' WHEN 4 THEN 'ABRIL' WHEN 5 THEN 'MAYO'  WHEN 6 THEN 'JUNIO'  " & vbCrLf &
                             "WHEN 7 THEN 'JULIO' WHEN 8 THEN 'AGOSTO' WHEN 9 THEN 'SEPTIEMBRE' WHEN 10 THEN 'OCTUBRE' WHEN 11 THEN 'NOVIEMBRE' WHEN 12 THEN 'DICIEMBRE'  " & vbCrLf &
                             "ELSE 'OTRO' END AS 'MES',  " & vbCrLf &
                             " count(tiempo) AS TOTAL " & vbCrLf &
                             "FROM detalles d WHERE d.tiempo<>'SALDO'  AND D.fecha_PAGO >= STR_TO_DATE('" & fdesde & "','%d/%m/%Y') AND d.fecha_pago < STR_TO_DATE('" & fhasta & "','%d/%m/%Y')" & vbCrLf &
                             "GROUP BY month(d.fecha_pago) "
                FilasEtiquetas = {0, 1}
                ColumnasEsNumero = {False, True}
                ColumnasJustificaciones = {0, 0}
                ColumnasAmplitudes = {300, 150}
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                Dim douSaldoEx As Double = 0
                For i As Integer = 1 To arlDatos1.Count - 1
                    If Not arlDatos1(i)(1).ToString.Equals("") Then
                        douSaldoEx += arlDatos1(i)(1)
                        totales.Text = douSaldoEx
                    End If
                Next
                booPromediar = False
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, , booPromediar)
                Exit Sub
            Case 24
                fhasta = DateAdd(DateInterval.Day, 1, fhasta)
                Consulta = "SELECT cl.cedula AS Cedula,concat(cl.nombre,' ',cl.apellido) AS Nombre, de.fecha_pago as 'Fecha de pago', de.tiempo AS Tarifa,de.valor AS Valor," & vbCrLf &
                    "IFNULL((select ab.dia FROM abonos ab WHERE ab.cedula=de.cedula order by idabonos desc limit 1),'PAGADO') AS INGRESOS " & vbCrLf &
                    "FROM detalles de,cliente cl,precio pr " & vbCrLf &
                    "WHERE cl.cedula = de.cedula" & vbCrLf &
                    "AND de.tiempo = pr.tipo" & vbCrLf &
                     "AND de.tiempo <> 'SALDO' " & vbCrLf &
                    "AND de.valor <> pr.valor" & vbCrLf &
                    "AND de.fecha_pago>= STR_TO_DATE('" & fdesde & "','%d/%m/%Y') AND de.fecha_pago <  STR_TO_DATE('" & fhasta & "','%d/%m/%Y') ORDER By fecha_pago desc "
                FilasEtiquetas = {0, 1, 2, 3, 4, 5}
                ColumnasEsNumero = {False, False, False, False, True, False}
                ColumnasJustificaciones = {0, 0, 0, 1, 1, 1}
                ColumnasAmplitudes = {100, 200, 100, 120, 120, 100}
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                Dim douSaldoEx As Double = 0
                For i As Integer = 1 To arlDatos1.Count - 1
                    If Not arlDatos1(i)(4).ToString.Equals("") Then
                        douSaldoEx += arlDatos1(i)(4)
                        totales.Text = douSaldoEx
                    End If
                Next
                booPromediar = False
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, , booPromediar)
                Exit Sub

            Case 25
                fhasta = DateAdd(DateInterval.Day, 1, fhasta)
                Consulta = "SELECT left(t.fecha,10)AS Fecha,cl.cedula AS Cedula,concat(cl.nombre,' ',cl.apellido) AS Nombre,cl.telefono AS Telefono,cl.email as Direccion,right(t.fecha,8) AS Hora, t.tem As 'Temperatua (celsius)', t.obs as Observaciones, 'Cliente' FROM cliente cl,temperatura t " & vbCrLf &
                    "WHERE cl.id=t.persona_id AND tipo=1 " & vbCrLf &
                    "AND t.fecha > STR_TO_DATE('" & fdesde & "','%d/%m/%Y') AND t.fecha <  STR_TO_DATE('" & fhasta & "','%d/%m/%Y')" & vbCrLf &
                    "UNION SELECT left(t.fecha,10)AS Fecha,e.cedula AS Cedula,concat(e.nombre,' ',e.apellido) AS Nombre,e.cell AS Telefono,'' as Direccion,right(t.fecha,8) AS Hora, t.tem As 'Temperatua (celsius)', t.obs as Observaciones ,'Empleado' FROM empleado e,temperatura t " & vbCrLf &
                    "WHERE e.id=t.persona_id AND tipo=2" & vbCrLf &
                    "AND t.fecha > STR_TO_DATE('" & fdesde & "','%d/%m/%Y') AND t.fecha <  STR_TO_DATE('" & fhasta & "','%d/%m/%Y') ORDER By fecha desc "
                FilasEtiquetas = {0, 1, 2, 3, 4, 5, 6, 7, 8}
                ColumnasEsNumero = {False, False, False, False, False, False, False, False, False}
                ColumnasJustificaciones = {0, 0, 0, 1, 1, 0, 0, 0, 0}
                ColumnasAmplitudes = {100, 100, 210, 100, 100, 80, 80, 100, 80}
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                booPromediar = False
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, , booPromediar)
                Exit Sub
            Case 26
                Consulta = "SELECT ho.nombre AS Hora,count(pe.hora_id) AS Total " & vbCrLf &
                  "FROM horario pe, pago pa,hora ho,cliente cl " & vbCrLf &
                  "WHERE pa.fecha_corte>=current_date" & vbCrLf &
                  "AND pa.cedula=cl.cedula AND cl.id=pe.persona_id" & vbCrLf &
                  "AND   pe.hora_id=ho.id GROUP BY ho.id ORDER BY ho.id"
                FilasEtiquetas = {0, 1}
                ColumnasEsNumero = {False, False}
                ColumnasJustificaciones = {0, 0}
                ColumnasAmplitudes = {200, 250}
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                Dim douSaldoEx As Double = 0
                Dim douEgreso As Double = 0
                For i As Integer = 1 To arlDatos1.Count - 1

                Next
                totales.Text = douSaldoEx - douEgreso
                booPromediar = False
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, , booPromediar)
                Exit Sub
            Case 27 'ingresos por hora detallado
                fhasta = DateAdd(DateInterval.Day, 1, fhasta)
                Consulta = "SELECT cl.cedula AS Cedula,concat(cl.nombre,' ',cl.apellido) AS Nombre, cl.telefono AS 'Telefono', (SELECT tiempo from detalles d where d.cedula=cl.cedula order by id desc limit 1) AS Tarifa,Left(e.fecha,10) as Fecha, RIGHT(e.fecha,9) AS Hora,TIMESTAMPDIFF(MINUTE, fecha, now()) as 'Tiempo en el GYM'" & vbCrLf &
                                       "FROM cliente cl,entrada e" & vbCrLf &
                    "WHERE cl.cedula = e.cedula" & vbCrLf &
                    "AND e.fecha>= STR_TO_DATE('" & fdesde & "','%d/%m/%Y') AND e.fecha <  STR_TO_DATE('" & fhasta & "','%d/%m/%Y') group by e.cedula ORDER By e.fecha desc "
                FilasEtiquetas = {0, 1, 2, 3, 4, 5, 6}
                ColumnasEsNumero = {False, False, False, False, False, False, True}
                ColumnasJustificaciones = {0, 0, 0, 1, 1, 1, 1, 1}
                ColumnasAmplitudes = {80, 200, 80, 120, 120, 80, 140}
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                booPromediar = False
                Dim cantidad As Integer = 0
                For i As Integer = 1 To arlDatos1.Count - 1
                    cantidad = cantidad + 1
                Next
                totales.Text = cantidad
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, True, booPromediar)

                pintarFilas(lstreporte, intIdReperte)

                Exit Sub
            Case 28 'Historial de mensualidades en año vigen
                fhasta = DateAdd(DateInterval.Day, 1, fhasta)
                Consulta = "SELECT c.cedula AS Cedula,CONCAT(c.nombre,' ',c.apellido) AS Cliente,count(*) as Mensualidades " & vbCrLf &
                            "FROM cliente c,detalles d " & vbCrLf &
                            "where c.cedula = d.cedula " & vbCrLf &
                            "AND  year(fecha_pago) = year(now()) " & vbCrLf &
                            "AND valor>30000 " & vbCrLf &
                            "group by d.cedula" & vbCrLf &
                            "having count(*)>4" & vbCrLf &
                            "order by Mensualidades desc"
                FilasEtiquetas = {0, 1, 2}
                ColumnasEsNumero = {False, False, True}
                ColumnasJustificaciones = {0, 1, 0}
                ColumnasAmplitudes = {80, 250, 80}
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                booPromediar = False
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, , booPromediar)

                pintarFilas(lstreporte, intIdReperte)

                Exit Sub
            Case 29
                fhasta = DateAdd(DateInterval.Day, 1, fhasta)
                Consulta = " select c.cedula AS Cedula,CONCAT(c.nombre,' ',c.apellido) AS Cliente,p.pro_nombre AS Nombre,d.detpro_cantidad as Cantidad, " & vbCrLf &
                           " d.detpro_precio AS 'P Venta',(d.detpro_cantidad*d.detpro_precio)AS Total, left(fac_fecha,10) As Fecha " & vbCrLf &
                            "from factura f,detalle_producto d,producto p,cliente c" & vbCrLf &
                           " WHERE detpro_idfactura = id_factura" & vbCrLf &
                            "AND detpro_idproducto=p.id" & vbCrLf &
                           "AND c.id=f.fac_idcliente" & vbCrLf &
                            "AND f.fac_fecha >= STR_TO_DATE('" & fdesde & "','%d/%m/%Y') AND f.fac_fecha <  STR_TO_DATE('" & fhasta & "','%d/%m/%Y')  " & vbCrLf &
                            ""
                FilasEtiquetas = {0, 1, 2, 3, 4, 5, 6}
                ColumnasEsNumero = {False, False, False, False, True, True, False}
                ColumnasJustificaciones = {0, 0, 1, 0, 1, 1, 1}
                ColumnasAmplitudes = {80, 150, 150, 160, 90, 90, 70}
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                Dim douSaldoEx As Double = 0
                For i As Integer = 1 To arlDatos1.Count - 1
                    If Not arlDatos1(i)(6).ToString.Equals("") Then
                        douSaldoEx += arlDatos1(i)(5)
                        totales.Text = douSaldoEx
                    End If
                Next
                booPromediar = False
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, , booPromediar)
                Exit Sub
            Case 30
                fhasta = DateAdd(DateInterval.Day, 1, fhasta)
                Consulta = "SELECT cl.cedula,concat(cl.nombre,' ',cl.apellido) AS Cliente,left(me1.mo,10)as fecha,DATEDIFF (current_Date, me1.mo) as Dias " & vbCrLf &
                            "FROM medida me1,cliente cl,pago pa " & vbCrLf &
                            "WHERE me1.mo = (SELECT MAX(mo) from medida me where me1.cliente=me.cliente )" & vbCrLf &
                            "AND me1.cliente=cl.id" & vbCrLf &
                            "AND cl.cedula=pa.cedula " & vbCrLf &
                            "AND pa.fecha_corte>=current_date" & vbCrLf &
                            "group by cliente" & vbCrLf &
                            "order by Dias Desc"
                FilasEtiquetas = {0, 1, 2, 3}
                ColumnasEsNumero = {False, False, False, True}
                ColumnasJustificaciones = {0, 0, 0, 0}
                ColumnasAmplitudes = {150, 250, 150, 160}
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                Dim douSaldoEx As Double = 0

                booPromediar = False
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, , booPromediar)
                pintarFilas(lstreporte, intIdReperte)
                Exit Sub
            Case 31
                fhasta = DateAdd(DateInterval.Day, 1, fhasta)
                Consulta = "SELECT cl.cedula AS Cedula,concat(cl.nombre,' ',cl.apellido) As Nombre,cl.telefono AS Telefono, de.tiempo AS Tarifa,de.valor AS Precio,left(cl.mo,10) as 'Fecha de Ingreso'" & vbCrLf &
                           "FROM detalles de, cliente cl " & vbCrLf &
                            "WHERE cl.cedula = de.cedula" & vbCrLf &
                            "AND cl.mo >='2022-01-07'" & vbCrLf &
                            "group by cl.cedula"
                FilasEtiquetas = {0, 1, 2, 3, 4, 5}
                ColumnasEsNumero = {False, False, False, False, True, False}
                ColumnasJustificaciones = {0, 0, 0, 0, 0, 0}
                ColumnasAmplitudes = {100, 250, 100, 80, 100, 150}
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                Dim douSaldoEx As Double = 0
                totales.Text = arlDatos1.Count - 1
                booPromediar = False
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, , booPromediar)
                pintarFilas(lstreporte, intIdReperte)
                Exit Sub


            Case 32   'historial de mensualidades actividad de usuarios 

                fhasta = DateAdd(DateInterval.Day, 1, fhasta)
                Consulta = "SELECT cl.cedula Documento,CONCAT(cl.nombre,' ',cl.apellido) AS Nombre,cl.telefono AS Contacto,count(de.cedula) AS 'Total Tarifas',max(left(de.fecha_pago,10)) AS 'Ultimo Pago', " & vbCrLf &
                           "Case  " & vbCrLf &
                           "WHEN pa.fecha_corte > current_date THEN 'Activo' " & vbCrLf &
                           "Else 'Inactivo' " & vbCrLf &
                           "END AS Estado,       " & vbCrLf &
                           "(SELECT Tiempo FROM detalles d WHERE d.cedula=de.cedula AND max(de.id)=d.id) AS Tarifa " & vbCrLf &
                           "FROM cliente cl,pago pa,detalles de  " & vbCrLf &
                           "WHERE cl.cedula=pa.cedula " & vbCrLf &
                           "And  pa.cedula=de.cedula " & vbCrLf &
                           "AND year(de.fecha_pago)=2022 " & vbCrLf &
                           "And tiempo <>'SALDO' " & vbCrLf &
                           "group by de.cedula"
                FilasEtiquetas = {0, 1, 2, 3, 4, 5, 6}
                ColumnasEsNumero = {False, False, False, True, False, False, False}
                ColumnasJustificaciones = {0, 0, 0, 0, 0, 0, 0}
                ColumnasAmplitudes = {100, 250, 100, 60, 100, 80, 100}
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                Dim douSaldoEx As Double = 0
                totales.Text = arlDatos1.Count - 1
                booPromediar = False
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, , booPromediar)

                Exit Sub
            Case 33   'personalizados

                fhasta = DateAdd(DateInterval.Day, 1, fhasta)
                Consulta = "SELECT cl.cedula Documento,CONCAT(cl.nombre,' ',cl.apellido) AS Nombre,cl.telefono AS Contacto,cl.instructor AS 'Instructor', " & vbCrLf &
                           "(SELECT Tiempo FROM detalles d WHERE d.cedula=de.cedula AND max(de.id)=d.id) AS Tarifa " & vbCrLf &
                           "FROM cliente cl,pago pa,detalles de  " & vbCrLf &
                           "WHERE cl.cedula=pa.cedula " & vbCrLf &
                           "And  pa.cedula=de.cedula " & vbCrLf &
                           "AND pa.fecha_corte>=current_date " & vbCrLf &
                           "And tiempo <>'SALDO' " & vbCrLf &
                           "group by de.cedula"
                FilasEtiquetas = {0, 1, 2, 3, 4}
                ColumnasEsNumero = {False, False, False, False, False}
                ColumnasJustificaciones = {0, 0, 0, 0, 0}
                ColumnasAmplitudes = {100, 250, 120, 150, 150}
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                Dim douSaldoEx As Double = 0
                totales.Text = arlDatos1.Count - 1
                booPromediar = False
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, , booPromediar)

                Exit Sub
            Case 34  'Historial de confelados por mes 

                fhasta = DateAdd(DateInterval.Day, 1, fhasta)
                Consulta = "SELECT cl.cedula, CONCAT(cl.nombre,' ',cl.apellido) AS Usuario, co.dias AS 'Dias Congelados',(select tiempo from detalles de where de.cedula=cl.cedula and de.fecha_pago<=co.mo and tiempo <>'SALDO' order by id desc limit 1) as Tarifa " & vbCrLf &
                            "From cliente cl, congelado co " & vbCrLf &
                            "WHERE cl.cedula=co.cedula " & vbCrLf &
                             "AND co.mo >= STR_TO_DATE('" & fdesde & "','%d/%m/%Y') AND co.mo <  STR_TO_DATE('" & fhasta & "','%d/%m/%Y')  " & vbCrLf &
                             "GROUP BY co.cedula"
                FilasEtiquetas = {0, 1, 2, 3}
                ColumnasEsNumero = {False, False, True, False}
                ColumnasJustificaciones = {0, 0, 0, 0}
                ColumnasAmplitudes = {100, 250, 120, 120}
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                Dim douSaldoEx As Double = 0
                totales.Text = arlDatos1.Count - 1
                booPromediar = False
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, , booPromediar)

                Exit Sub

            Case 35 'inasistencia de usuarios
                Exit Sub
            Case 36 ' INFORME GENERAL O DE GERENCIA
                Dim mes As String = fdesde.Month
                Dim año As String = fdesde.Year
                Dim finicio As String = "01/" & mes & "/" & año & ""
                Dim ffinal As String = fdesde.Day & "/" & mes & "/" & año
                fhasta = DateAdd(DateInterval.Day, 1, fhasta)
                Consulta = "SELECT  'TOTAL INGRESO',IFNULL(SUM(VALOR),0) AS TOTAL fROM DETALLES WHERE fecha_pago= STR_TO_DATE('" & ffinal & "','%d/%m/%Y')
                            UNION
                            Select IFNULL(bn.no,'Efectivo') As Descripcion, SUM(valor) as Total
                            From DETALLES, bancoscuentas bn Where banco = bn.id And fecha_pago =STR_TO_DATE('" & ffinal & "','%d/%m/%Y')
                            GROUP BY BANCO
                            UNION
                            SELECT '',''
                            UNION
                            SELECT 'TOTAL DEL MES MES',''
                            UNION
                            SELECT ' ',' '
                            UNION
                            SELECT  'TOTAL INGRESO MES',SUM(VALOR) AS TOTAL
                            FROM DETALLES WHERE fecha_pago>= STR_TO_DATE('" & finicio & "','%d/%m/%Y') AND fecha_pago<= STR_TO_DATE('" & ffinal & "','%d/%m/%Y')
                            UNION
                            SELECT  IFNULL(bn.no,'EFECTIVO') As Descripcion, SUM(valor) as Total
                            FROM DETALLES,bancoscuentas bn WHERE banco=bn.id AND fecha_pago>= STR_TO_DATE('" & finicio & "','%d/%m/%Y') AND fecha_pago<= STR_TO_DATE('" & ffinal & "','%d/%m/%Y')
                            GROUP BY BANCO
                            UNION
                            SELECT '      ','      '
                            UNION
                            SELECT 'TOTAL AFILIADOS',''
                            UNION
                            SELECT '      ','     '
                            UNION
                            SELECT 'AFILIADOS DEL DIA',COUNT(*)
                            FROM DETALLES WHERE fecha_pago= STR_TO_DATE('" & ffinal & "','%d/%m/%Y')
                            UNION
                            SELECT 'AFILIADOS DEL MES',COUNT(*)
                            FROM DETALLES WHERE fecha_pago>= STR_TO_DATE('" & finicio & "','%d/%m/%Y') AND fecha_pago<= STR_TO_DATE('" & ffinal & "','%d/%m/%Y')
                            UNION
                                            Select '.','.'
                            UNION
                                                Select 'TOTAL AFILIADOS DISCRIMINADO POR TARIFAS',''
                            UNION
                                                    Select '  ','  '
                            UNION
                            Select TIEMPO,COUNT(*)
                            From DETALLES Where fecha_pago >= STR_TO_DATE('" & finicio & "','%d/%m/%Y') AND fecha_pago<= STR_TO_DATE('" & ffinal & "','%d/%m/%Y')  GROUP BY tiempo
                            UNION
                            Select 'TOTAL AFILIADOS EN EL MES', COUNT(*)
                            From DETALLES Where fecha_pago >= STR_TO_DATE('" & finicio & "','%d/%m/%Y') AND fecha_pago<= STR_TO_DATE('" & ffinal & "','%d/%m/%Y')
                            UNION
                            SELECT '   ','   '
                            UNION
                            SELECT 'GASTOS Y UTILIDADES',''
                            UNION
                            SELECT '    ','    '
                            UNION
                            SELECT 'TOTAL GASTOS DEL DIA',IFNULL(SUM(VALOR),0) as consolidado
                            FROM gastos WHERE fecha=STR_TO_DATE('" & ffinal & "','%d/%m/%Y')
                            UNION
                            SELECT 'TOTAL GASTOS MES',SUM(VALOR) as consolidado
                            FROM gastos WHERE FECHA>=STR_TO_DATE('" & finicio & "','%d/%m/%Y') and fecha<=STR_TO_DATE('" & ffinal & "','%d/%m/%Y')
                            UNION
                            SELECT '   ','   '
                            UNION
                            SELECT 'UTILIDAD  DEL DIA',IFNULL((SELECT SUM(VALOR) FROM DETALLES WHERE fecha_pago=STR_TO_DATE('" & ffinal & "','%d/%m/%Y'))-SUM(g.valor),0)
                            FROM gastos g WHERE fecha=STR_TO_DATE('" & ffinal & "','%d/%m/%Y') 
                            UNION
                            SELECT 'UTILIDAD  DEL DIA EN EFECTIVO',IFNULL((SELECT SUM(VALOR) FROM DETALLES WHERE fecha_pago=STR_TO_DATE('" & ffinal & "','%d/%m/%Y') AND tarjeta=2)-SUM(g.valor),0)
                            FROM gastos g WHERE fecha=STR_TO_DATE('" & ffinal & "','%d/%m/%Y') 
                            UNION
                            SELECT 'UTILIDAD DEL MES  ',(SELECT SUM(VALOR) FROM DETALLES WHERE fecha_pago >= STR_TO_DATE('" & finicio & "','%d/%m/%Y') AND fecha_pago<= STR_TO_DATE('" & ffinal & "','%d/%m/%Y'))-SUM(g.valor)
                            FROM gastos g WHERE fecha >=STR_TO_DATE('" & finicio & "','%d/%m/%Y')  AND fecha<=STR_TO_DATE('" & ffinal & "','%d/%m/%Y') 
                            UNION        
                            SELECT 'UTILIDAD DEL MES EN EFECTIVO',(SELECT SUM(VALOR) FROM DETALLES WHERE fecha_pago >= STR_TO_DATE('" & finicio & "','%d/%m/%Y') AND fecha_pago<= STR_TO_DATE('" & ffinal & "','%d/%m/%Y') AND tarjeta=2)-SUM(g.valor)
                            FROM gastos g WHERE fecha >=STR_TO_DATE('" & finicio & "','%d/%m/%Y')  AND fecha<=STR_TO_DATE('" & ffinal & "','%d/%m/%Y')   
                            UNION 
                            SELECT '        ','          '
                            UNION
                            SELECT 'TARIFA PROMEDIO','   '
                            UNION
                            SELECT '           ','           '
                            UNION
                            SELECT  'TARIFA PROMEDIO', FORMAT((SELECT SUM(VALOR) AS TOTAL FROM DETALLES WHERE fecha_pago>= STR_TO_DATE('" & finicio & "','%d/%m/%Y') AND fecha_pago<= STR_TO_DATE('" & ffinal & "','%d/%m/%Y'))/(Select  COUNT(*)
                            From DETALLES Where fecha_pago >= STR_TO_DATE('" & finicio & "','%d/%m/%Y') AND fecha_pago<= STR_TO_DATE('" & ffinal & "','%d/%m/%Y')),1)"


                FilasEtiquetas = {0, 1}
                ColumnasEsNumero = {False, False}
                ColumnasJustificaciones = {0, 0}
                ColumnasAmplitudes = {450, 250}
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                Dim douSaldoEx As Double = 0
                'totales.Text = arlDatos1.Count - 1
                booPromediar = False
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, , booPromediar)

                Exit Sub

            Case 100
                Consulta = " Select id,peso As Peso, talla As Talla,imc As IMC, porgrasa As '% grasa'," & vbCrLf &
                                    "pantorrilla AS pantorrilla,muslomedio AS Muslo, gluteo AS Gluteo,cintura AS Cintura, " & vbCrLf &
                                    "espalda AS Espalda, pectorales AS Pectoral,brizq AS 'Brazo IZQ', brder AS 'Brazo DER', " & vbCrLf &
                                    "restriccion AS Restriccion, objetivo AS Observaciones " & vbCrLf &
                                    "FROM medida WHERE cliente='" & idcliente & "'"
                FilasEtiquetas = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14}
                ColumnasEsNumero = {True, True, True, True, True, True, True, True, True, True, True, True, True, False, False}
                ColumnasJustificaciones = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1}
                ColumnasAmplitudes = {0, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 120, 120}
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                Dim douSaldoEx As Double = 0
                booPromediar = False
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, , booPromediar)
                Exit Sub

            Case 200
                Consulta = "SELECT sv.id,cl.cedula,concat(cl.nombre,' ',cl.apellido) as nombre,sv.saldo,sv.fecha " & vbCrLf &
                           "From cliente cl, saldoVenta sv " & vbCrLf &
                            "WHERE cl.id=sv.idcliente" & vbCrLf &
                           "Order BY cl.nombre"

                FilasEtiquetas = {0, 1, 2, 3, 4}
                ColumnasEsNumero = {True, False, False, True, False}
                ColumnasJustificaciones = {0, 0, 0, 0, 0, 0}
                ColumnasAmplitudes = {100, 100, 300, 80, 80}
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                Dim douSaldoEx As Double = 0
                'For i As Integer = 1 To arlDatos1.Count - 1
                '    If Not arlDatos1(i)(5).ToString.Equals("") Then
                '        douSaldoEx += arlDatos1(i)(5)
                '        totales.Text = douSaldoEx
                '    End If
                'Next
                booPromediar = False
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, , booPromediar)
                Exit Sub
            Case 300
                Consulta = " select m.nombre as 'Movimiento',case c.escredito" & vbCrLf &
                                                        "when 1 then 'EGRESO'" & vbCrLf &
                                                        "when 0 then 'INGRESO' end as 'TIPO'," & vbCrLf &
                                                        "c.valor as Valor," & vbCrLf &
                                     "l.usuario as 'Usario',c.fecha as Fecha				" & vbCrLf &
                         "from caja c,tipomovimiento m,login l " & vbCrLf &
                         "WHERE m.id=c.movimiento AND c.usuario=l.id "
                If idusuario > 0 Then
                    Consulta = Consulta & " AND c.usuario = '" & idusuario & "'"
                End If
                FilasEtiquetas = {0, 1, 2, 3, 4}
                ColumnasEsNumero = {False, False, True, False, False}
                ColumnasJustificaciones = {0, 0, 1, 1, 1}
                ColumnasAmplitudes = {200, 150, 150, 150, 150}
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                Dim douSaldoEx As Double = 0
                Dim douEgreso As Double = 0
                For i As Integer = 1 To arlDatos1.Count - 1
                    If arlDatos1(i)(1).ToString.Equals("INGRESO") Then
                        douSaldoEx += arlDatos1(i)(2)
                    ElseIf arlDatos1(i)(1).ToString.Equals("EGRESO") Then
                        douEgreso += arlDatos1(i)(2)
                    End If
                Next
                totales.Text = douSaldoEx - douEgreso
                booPromediar = False
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, , booPromediar)
                Exit Sub
            Case 301
                Consulta = " select m.nombre as 'Movimiento',case c.escredito" & vbCrLf &
                                                        "when 1 then 'EGRESO'" & vbCrLf &
                                                        "when 0 then 'INGRESO' end as 'TIPO'," & vbCrLf &
                                                        "c.valor as Valor," & vbCrLf &
                                     "l.usuario as 'Usuario',c.fecha as Fecha				" & vbCrLf &
                         "from caja1 c,tipomovimiento m ,login l" & vbCrLf &
                         "WHERE m.id=c.movimiento AND c.usuario=l.id "
                If idusuario > 0 Then
                    Consulta = Consulta & " AND c.usuario = '" & idusuario & "'"
                End If
                FilasEtiquetas = {0, 1, 2, 3, 4}
                ColumnasEsNumero = {False, False, True, False, False}
                ColumnasJustificaciones = {0, 0, 1, 1, 1}
                ColumnasAmplitudes = {200, 150, 150, 150, 150}
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                Dim douSaldoEx As Double = 0
                Dim douEgreso As Double = 0
                For i As Integer = 1 To arlDatos1.Count - 1
                    If arlDatos1(i)(1).ToString.Equals("INGRESO") Then
                        douSaldoEx += arlDatos1(i)(2)
                    ElseIf arlDatos1(i)(1).ToString.Equals("EGRESO") Then
                        douEgreso += arlDatos1(i)(2)
                    End If
                Next
                totales.Text = douSaldoEx - douEgreso
                booPromediar = False
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, , booPromediar)
                Exit Sub

            Case 302
                Consulta = "SELECT d.id,c.cedula AS cedula, CONCAT(c.nombre,' ',c.apellido) AS Nombre,d.tiempo AS 'Ultima tarifa',d.valor as Valor," & vbCrLf &
                            " LEFT(d.fecha_pago,10) AS 'Pagos realizados',d.fecha_fin'Fecha final' " & vbCrLf &
                            "FROM CLIENTE c,PAGO p ,detalles d " & vbCrLf &
                            "WHERE c.cedula = p.cedula " & vbCrLf &
                            "AND c.id= '" & idcliente & "' AND d.cedula=p.cedula" & vbCrLf &
                            "ORDER BY D.FECHA_PAGO;"
                FilasEtiquetas = {0, 1, 2, 3, 4, 5, 6}
                ColumnasEsNumero = {False, False, False, False, False, False, False}
                ColumnasJustificaciones = {0, 0, 0, 1, 1, 1, 1}
                ColumnasAmplitudes = {80, 100, 200, 100, 100, 100, 100}
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                booPromediar = False
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, , booPromediar)
                Exit Sub



            Case 303  'reporte de arqueo caja SPA
                Consulta = " select m.nombre as 'Movimiento',case c.escredito" & vbCrLf &
                                                        "when 1 then 'EGRESO'" & vbCrLf &
                                                        "when 0 then 'INGRESO' end as 'TIPO'," & vbCrLf &
                                                        "c.valor as Valor," & vbCrLf &
                                     "l.usuario 'Usuario',c.fecha as Fecha				" & vbCrLf &
                         "from caja2 c,tipomovimiento m ,login l" & vbCrLf &
                         "WHERE m.id=c.movimiento AND c.usuario=l.id "
                If idusuario > 0 Then
                    Consulta = Consulta & " AND c.usuario = '" & idusuario & "'"
                End If
                FilasEtiquetas = {0, 1, 2, 3, 4}
                ColumnasEsNumero = {False, False, True, False, False}
                ColumnasJustificaciones = {0, 0, 1, 1, 1}
                ColumnasAmplitudes = {200, 150, 150, 150, 150}
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                Dim douSaldoEx As Double = 0
                Dim douEgreso As Double = 0
                For i As Integer = 1 To arlDatos1.Count - 1
                    If arlDatos1(i)(1).ToString.Equals("INGRESO") Then
                        douSaldoEx += arlDatos1(i)(2)
                    ElseIf arlDatos1(i)(1).ToString.Equals("EGRESO") Then
                        douEgreso += arlDatos1(i)(2)
                    End If
                Next
                totales.Text = douSaldoEx - douEgreso
                booPromediar = False
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, , booPromediar)
                Exit Sub

            Case 500  'Personalizados por Instructor
                Consulta = "SELECT pe.id,CONCAT(em.nombre,' ',em.apellido) AS Instructor,ho.nombre AS Hora,CONCAT(cl.nombre,' ',cl.apellido)AS Cliente" & vbCrLf &
                    "FROM personalizado pe, pago pa,cliente cl,hora ho,empleado em " & vbCrLf &
                    "WHERE pe.empleado_id = em.id" & vbCrLf &
                    "AND   pe.persona_id=cl.id" & vbCrLf &
                     "AND   pe.empleado_id='" & intInstructor & "'" & vbCrLf &
                    "AND cl.cedula=pa.cedula" & vbCrLf &
                    "AND pa.fecha_corte>=current_date" & vbCrLf &
                    "AND   pe.hora_id=ho.id ORDER BY ho.id"
                FilasEtiquetas = {0, 1, 2, 3}
                ColumnasEsNumero = {True, False, False, False}
                ColumnasJustificaciones = {0, 0, 1, 0}
                ColumnasAmplitudes = {0, 200, 150, 250}
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                Dim douSaldoEx As Double = 0
                Dim douEgreso As Double = 0
                For i As Integer = 1 To arlDatos1.Count - 1

                Next

                booPromediar = False
                totales.Text = arlDatos1.Count - 1
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, , booPromediar)
                Exit Sub
            Case 501  'Lista de horarios de clientes
                Consulta = "SELECT pe.id,ho.nombre AS Hora,CONCAT(cl.nombre,' ',cl.apellido)AS Cliente" & vbCrLf &
                    "FROM horario pe, pago pa,cliente cl,hora ho " & vbCrLf &
                    "WHERE  pe.persona_id=cl.id" & vbCrLf &
                    "AND cl.cedula=pa.cedula" & vbCrLf &
                    "AND pa.fecha_corte>=current_date" & vbCrLf &
                    "AND   pe.hora_id=ho.id ORDER BY ho.id"
                FilasEtiquetas = {0, 1, 2}
                ColumnasEsNumero = {True, False, False}
                ColumnasJustificaciones = {0, 0, 1}
                ColumnasAmplitudes = {0, 200, 250}
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                Dim douSaldoEx As Double = 0
                Dim douEgreso As Double = 0
                For i As Integer = 1 To arlDatos1.Count - 1

                Next
                totales.Text = douSaldoEx - douEgreso
                booPromediar = False
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, , booPromediar)
                Exit Sub
            Case 502  'Inasistencia de usuarios 
                Consulta = "SELECT cl.cedula,CONCAT(cl.nombre,' ',cl.apellido) AS Cliente,cl.telefono,pr.tipo " & vbCrLf &
                            "From cliente cl, pago pg, precio pr" & vbCrLf &
                            "Where cl.cedula = pg.cedula " & vbCrLf &
                            "AND  pg.fecha_corte>=current_date " & vbCrLf &
                            "AND pg.idprecio = pr.serial " & vbCrLf &
                            "AND pg.cedula NOT IN (SELECT en.cedula FROM entrada en WHERE left(en.fecha,10) ='" & Format(fdesde, "yyyy-MM-dd") & "');"
                FilasEtiquetas = {0, 1, 2, 3}
                ColumnasEsNumero = {False, False, False, False}
                ColumnasJustificaciones = {0, 0, 0, 0}
                ColumnasAmplitudes = {150, 300, 120, 120}

                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                totales.Text = arlDatos1.Count - 1
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, , booPromediar)

                Exit Sub
            Case 503  'Historial de saldo de ventas 
                fhasta = DateAdd(DateInterval.Day, 1, fhasta)
                If idcliente > 0 Then
                    Consulta = "SELECT cl.cedula,CONCAT(cl.nombre,' ',cl.apellido) AS Cliente,hs.saldo,hs.abono,hs.newsaldo,left(hs.modificado,10) as fecha " & vbCrLf &
                           "From cliente cl, historialdesaldo hs" & vbCrLf &
                           "Where cl.id = hs.idcliente " & vbCrLf &
                           "AND hs.idcliente='" & idcliente & "'" & vbCrLf &
                            "AND hs.modificado >= STR_TO_DATE('" & fdesde & "','%d/%m/%Y') AND hs.modificado <=  STR_TO_DATE('" & fhasta & "','%d/%m/%Y')  "
                Else
                    Consulta = "SELECT cl.cedula,CONCAT(cl.nombre,' ',cl.apellido) AS Cliente,hs.saldo,hs.abono,hs.newsaldo, left(hs.modificado,10) as fecha" & vbCrLf &
                         "From cliente cl, historialdesaldo hs" & vbCrLf &
                         "Where cl.id = hs.idcliente " & vbCrLf &
                         "AND hs.modificado >= STR_TO_DATE('" & fdesde & "','%d/%m/%Y') AND hs.modificado <=  STR_TO_DATE('" & fhasta & "','%d/%m/%Y')  "
                End If


                FilasEtiquetas = {0, 1, 2, 3, 4, 5}
                ColumnasEsNumero = {False, False, True, True, True, False}
                ColumnasJustificaciones = {0, 0, 0, 0, 0, 0}
                ColumnasAmplitudes = {100, 280, 120, 120, 100, 100}
                Dim douSaldoEx As Double = 0
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                For i As Integer = 1 To arlDatos1.Count - 1
                    If Not arlDatos1(i)(3).ToString.Equals("") Then
                        douSaldoEx += arlDatos1(i)(3)
                        totales.Text = douSaldoEx
                    End If
                Next
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, , booPromediar)
                Exit Sub
            Case 900
                fhasta = DateAdd(DateInterval.Day, 1, fhasta)
                Consulta = "SELECT cl.cedula,concat(cl.nombre,' ',cl.apellido) AS Cliente,left(en.fecha,10) AS Fecha,right(en.fecha,8) AS Hora,(select de.tiempo from detalles de where month(de.fecha_pago)=month(en.fecha) order by id desc limit 1) AS Tarifa " & vbCrLf &
                            "FROM entrada en,cliente cl " & vbCrLf &
                            "WHERE cl.id= " & idcliente & " " & vbCrLf &
                            "AND en.cedula=cl.cedula  " & vbCrLf &
                            "AND en.fecha>= STR_TO_DATE('" & fdesde & "','%d/%m/%Y') AND en.fecha <  STR_TO_DATE('" & fhasta & "','%d/%m/%Y') ORDER By en.id"
                FilasEtiquetas = {0, 1, 2, 3, 4}
                ColumnasEsNumero = {False, False, False, False, False}
                ColumnasJustificaciones = {0, 0, 0, 0, 0}
                ColumnasAmplitudes = {120, 250, 100, 100, 100}
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                booPromediar = False
                totales.Text = arlDatos1.Count - 1
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, , booPromediar)
                Exit Sub

        End Select




    End Sub
    Public Sub pintarFilas(lstreporte As ListView, intIdreporte As Integer)

        Select Case intIdreporte
            Case 4
                For i As Integer = 0 To lstreporte.Items.Count - 1
                    Dim fecha As Date = lstreporte.Items(i).SubItems(2).Text
                    Dim dias As Integer = DateDiff(DateInterval.Day, Now.Date(), fecha)

                    If dias < 3 Then
                        lstreporte.Items(i).BackColor = Color.Red
                    ElseIf dias >= 3 And dias < 7 Then
                        lstreporte.Items(i).BackColor = Color.Orange
                    Else
                        lstreporte.Items(i).BackColor = Color.Green
                    End If


                Next
            Case 27
                For i As Integer = 0 To lstreporte.Items.Count - 1
                    Dim dias As Integer = lstreporte.Items(i).SubItems(6).Text

                    If dias < 120 Then
                        lstreporte.Items(i).BackColor = Color.Green
                    ElseIf dias >= 120 Then
                        lstreporte.Items(i).BackColor = Color.Red

                    End If


                Next
            Case 30
                For i As Integer = 0 To lstreporte.Items.Count - 1
                    Dim dias As Integer = lstreporte.Items(i).SubItems(3).Text
                    If dias >= 37 Then
                        lstreporte.Items(i).BackColor = Color.Red
                    ElseIf dias >= 30 And dias < 37 Then
                        lstreporte.Items(i).BackColor = Color.Orange
                    Else
                        lstreporte.Items(i).BackColor = Color.Green
                    End If


                Next
            Case 27
        End Select


    End Sub


    Public Sub mostrarTariasEspeciales(lstTarifas As ListView)

        Dim arlCoincidencias = Gestor1.DatosDeConsulta("SELECT id,tipo,horaentrada,horasalida FROM precio,tarifasespeciales where idtarifa=serial", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then lstTarifas.Visible = True
        lstTarifas.Items.Clear()
        lstTarifas.BeginUpdate()
        For Each Encontrado As ArrayList In arlCoincidencias
            Dim lviEncontrado As New ListViewItem
            lviEncontrado.Tag = Encontrado(0)
            lviEncontrado.Text = Encontrado(1)
            lviEncontrado.SubItems.Add(Encontrado(2))
            lviEncontrado.SubItems.Add(Encontrado(3))
            lstTarifas.Items.Add(lviEncontrado)
        Next
        lstTarifas.EndUpdate()

    End Sub
    Public Sub mostrarTariasnoCongelables(lstTarifas As ListView)

        Dim arlCoincidencias = Gestor1.DatosDeConsulta("SELECT id,tipo FROM precio,tarifasespeciales where idtarifa=serial", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then lstTarifas.Visible = True
        lstTarifas.Items.Clear()
        lstTarifas.BeginUpdate()
        For Each Encontrado As ArrayList In arlCoincidencias
            Dim lviEncontrado As New ListViewItem
            lviEncontrado.Tag = Encontrado(0)
            lviEncontrado.Text = Encontrado(1)
            lstTarifas.Items.Add(lviEncontrado)
        Next
        lstTarifas.EndUpdate()
    End Sub
    Public Sub mostrarTipogatos(lstTarifas As ListView)

        Dim arlCoincidencias = Gestor1.DatosDeConsulta("SELECT id,nombre,ifnull(descripcion,'nada') FROM tipogasto", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then lstTarifas.Visible = True
        lstTarifas.Items.Clear()
        lstTarifas.BeginUpdate()
        For Each Encontrado As ArrayList In arlCoincidencias
            Dim lviEncontrado As New ListViewItem
            lviEncontrado.Tag = Encontrado(0)
            lviEncontrado.Text = Encontrado(1)
            lviEncontrado.SubItems.Add(Encontrado(2))
            lstTarifas.Items.Add(lviEncontrado)
        Next
        lstTarifas.EndUpdate()

    End Sub

    Public Sub mostrarTarias(lstTarifas As ListView)

        Dim arlCoincidencias = Gestor1.DatosDeConsulta("SELECT serial,tipo,valor,dias,det FROM precio", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then lstTarifas.Visible = True
        lstTarifas.Items.Clear()
        lstTarifas.BeginUpdate()
        For Each Encontrado As ArrayList In arlCoincidencias
            Dim lviEncontrado As New ListViewItem
            lviEncontrado.Tag = Encontrado(0)
            lviEncontrado.Text = Encontrado(1)
            lviEncontrado.SubItems.Add(Encontrado(2))
            lviEncontrado.SubItems.Add(Encontrado(3))
            If Encontrado(4) = 1 Then
                lviEncontrado.SubItems.Add("GYM")
            Else
                lviEncontrado.SubItems.Add("SPA")
            End If


            lstTarifas.Items.Add(lviEncontrado)
        Next
        lstTarifas.EndUpdate()

    End Sub
    Public Sub reporteListview(Lista As ListView, arl As ArrayList, Optional EncabezadosIncluidos As Boolean = False, Optional FilasEtiquetas() As Integer = Nothing, Optional AutoFit As Boolean = False, Optional ColumnasAmplitudes() As Integer = Nothing, Optional ColumnasJustificaciones() As Integer = Nothing, Optional ColumnasEsNumero() As Boolean = Nothing, Optional Totalizar As Boolean = False, Optional Promediar As Boolean = False)

        lista.BeginUpdate()
        lista.Items.Clear()
        lista.Columns.Clear()
        lista.Groups.Clear()
        Dim arlTotales As New ArrayList
        Dim arlPromedios As New ArrayList
        For i As Integer = 0 To arl.Count - 1
            Dim booCreeFila As Boolean = True
            If i = 0 Then
                If EncabezadosIncluidos Then booCreeFila = False
                For l As Integer = 0 To arl(0).Count - 1
                    arlTotales.Add(0)
                    arlPromedios.Add(0)
                Next
            End If
            If booCreeFila Then
                Dim Fila As New ListViewItem
                If Not IsNothing(FilasEtiquetas) Then
                    Dim strEtiqueta As String = arl(i)(FilasEtiquetas(0))
                    For n As Integer = 1 To FilasEtiquetas.Count - 1
                        strEtiqueta += "|" & arl(i)(FilasEtiquetas(n))
                    Next
                    Fila.Tag = strEtiqueta
                End If
                Dim arlFila As ArrayList = arl(i)
                For k = 0 To arlFila.Count - 1
                    If Not IsNothing(ColumnasEsNumero) Then
                        If ColumnasEsNumero(k) Then
                            Dim douValor As Double = ProceseValor(arlFila(k).ToString)
                            If Totalizar Then arlTotales(k) += douValor
                            arlFila(k) = FormatNumber(douValor, bytDecimales)
                        End If
                    End If
                    If k = 0 Then
                        Fila.Text = arlFila(k)
                    Else
                        Fila.SubItems.Add(arlFila(k).ToString)
                    End If
                Next
                lista.Items.Add(Fila)
            End If
        Next
        If Not arl.Count = 0 Then
            If Totalizar Then
                Dim lviTotales As New ListViewItem
                lviTotales.Text = "Totales (" & Lista.Items.Count & ")"
                For s As Integer = 1 To arl(0).Count - 1
                    lviTotales.SubItems.Add("")
                    If Not IsNothing(ColumnasEsNumero) Then
                        If ColumnasEsNumero(s) Then lviTotales.SubItems(s).Text = FormatNumber(arlTotales(s), bytDecimales)
                    End If
                Next
                Lista.Items.Add(lviTotales)
            End If
            If Promediar Then
                Dim lviPromedios As New ListViewItem
                lviPromedios.Text = "Promedios"
                For s As Integer = 1 To arl(0).Count - 1
                    lviPromedios.SubItems.Add("")
                    If Not IsNothing(ColumnasEsNumero) Then
                        If ColumnasEsNumero(s) Then lviPromedios.SubItems(s).Text = FormatNumber(arlTotales(s) / (Lista.Items.Count - 1), bytDecimales)
                    End If
                Next
                Lista.Items.Add(lviPromedios)
            End If
        End If
        If Not Lista.Items.Count = 0 Then
            Lista.Items(Lista.Items.Count - 1).Selected = True
            Lista.Items(Lista.Items.Count - 1).EnsureVisible()
        End If
        If Not arl.Count = 0 Then
            Dim CuentaColumnas As ArrayList = arl(0)
            For j = 0 To CuentaColumnas.Count - 1
                Lista.Columns.Add(CuentaColumnas(j).ToString, 120)
                If Not IsNothing(ColumnasAmplitudes) Then
                    If Not IsNothing(ColumnasAmplitudes) Then Lista.Columns(j).Width = ColumnasAmplitudes(j)
                Else
                    Lista.Columns(j).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                End If
                If Not IsNothing(ColumnasJustificaciones) Then Lista.Columns(j).TextAlign = ColumnasJustificaciones(j)
            Next
        End If
        Lista.EndUpdate()
    End Sub

    Public Function ProceseValor(strValor As String) As Double
        If IsNothing(strValor) Then Return 0
        If Not IsNumeric(strValor) Then Return 0
        Dim ii As Byte
        For ii = 1 To Len(strValor)
            If Mid(strValor, ii, 1) = "," Then Mid(strValor, ii, 1) = "."
        Next
        Return Val(strValor)
    End Function
    Public Function ExtrarCliente(nombres As TextBox, foto As PictureBox, strCedula As String) As Boolean
        Dim booEncontrado = False
        Dim arlCoincidencias = Gestor1.DatosDeConsulta("SELECT c.nombre,c.apellido,C.ruta" & vbCrLf &
                                                      "FROM cliente AS c " & vbCrLf &
                                                      "WHERE c.cedula='" & strCedula & "'", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then
            For Each Encontrado As ArrayList In arlCoincidencias
                booEncontrado = True
                nombres.Text = Encontrado(0) & " " & Encontrado(1)
                If My.Computer.FileSystem.FileExists(Encontrado(2).ToString) Then
                    Dim Imagen As New Bitmap(Encontrado(2).ToString)
                    foto.Image = Imagen
                End If

            Next
        End If
        Return booEncontrado
    End Function
    Public Function ExtraerUltimoSpa(nombres As TextBox, foto As PictureBox, fecha As TextBox, strCedula As String, ByRef intDiasRestantes As Integer, ByRef intIdCliente As Integer, txtdescripcion As TextBox) As Boolean
        Dim booEncontrado As Boolean = False
        Dim arlCoincidencias = Gestor1.DatosDeConsulta("SELECT c.nombre,c.apellido, left(f.fac_fecha,10) as Fecha,f.fac_fecha as Fecha,p.serial,c.ruta,fac_idcliente,p.tipo" & vbCrLf &
                                                      "FROM cliente AS c,factura  AS f,precio AS p,detalle_producto pd " & vbCrLf &
                                                      "WHERE f.fac_idcliente=c.cedula AND pd.detpro_idfactura=f.id_factura" & vbCrLf &
                                                      "AND f.fac_idcliente='" & strCedula & "' " & vbCrLf &
                                                      "AND pd.detpro_idproducto=p.serial;", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then
            For Each Encontrado As ArrayList In arlCoincidencias
                booEncontrado = True
                nombres.Text = Encontrado(0) & " " & Encontrado(1)
                Dim fec As Date = (Encontrado(2))
                fecha.Text = fec

                If My.Computer.FileSystem.FileExists(Encontrado(5).ToString) Then
                    Dim Imagen As New Bitmap(Encontrado(5).ToString)
                    foto.Image = Imagen
                End If
                txtdescripcion.Text = Encontrado(7)

            Next
        End If
        Return booEncontrado
    End Function
    Public Function valideLicencia() As Boolean
        Dim saber As Boolean = False
        Dim cadena As String = "Licencia hasta: "
        Principal.intidOnline = informaciongym("idonline")
        Dim arlCoincidencias As ArrayList = Gestor1.DatosDeConsulta("SELECT  li  FROM LIC order by id desc limit 1", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then
            For Each fecha As ArrayList In arlCoincidencias
                If FormatDateTime(fecha(0)) < Now.Date Then
                    saber = valideLicenciaOnline(Principal.intidOnline)
                Else
                    cadena = cadena & fecha(0)
                    Principal.lblLicencia.Text = cadena
                    saber = True
                End If
            Next
        Else
            saber = valideLicenciaOnline(Principal.intidOnline)
        End If
        Return saber
    End Function
    Public Function valideLicenciaOnline(idlicencia As Integer) As Boolean
        Dim cadena As String = "Licencia hasta: "
        Dim saber As Boolean = False
        Dim arlCoincidencias As ArrayList = Gestor1.DatosDeConsulta("SELECT fecha_final FROM licencias where id='" & idlicencia & "'", , Principal.cadenadeconexionOnline)
        If Not arlCoincidencias.Count = 0 Then
            For Each fecha As ArrayList In arlCoincidencias
                If Not FormatDateTime(fecha(0)) < Now.Date Then
                    cadena = cadena & fecha(0)
                    registreDatos("INSERT INTO lic(li) VALUES ('" & Format(fecha(0), "yyyy-MM-dd") & "')")
                    Principal.lblLicencia.Text = cadena
                    saber = True
                End If
            Next
        End If
        Return saber
    End Function
    Public Function ExtraerUltimoPago(nombres As TextBox, foto As PictureBox, fecha As TextBox, strCedula As String, ByRef intDiasRestantes As Integer, ByRef intIdCliente As Integer, txtdescripcion As TextBox) As Boolean
        Dim booEncontrado As Boolean = False
        Dim arlCoincidencias = Gestor1.DatosDeConsulta(" SELECT c.nombre, c.apellido, p.fecha_corte, p.fecha_pago, " & vbCrLf &
                                                              "IFNULL((select pr.serial   from precio pr  where pr.serial=p.idprecio),'')  as serial,  " & vbCrLf &
                                                              "c.ruta, p.id, " & vbCrLf &
                                                              "IFNULL((select pr.tipo from precio pr  where pr.serial=p.idprecio),'') as tipo  " & vbCrLf &
                                                    "FROM cliente AS c, pago AS p, precio AS pr  " & vbCrLf &
                                                    "WHERE p.cedula=" & strCedula & " AND p.cedula=c.cedula; ", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then
            For Each Encontrado As ArrayList In arlCoincidencias
                booEncontrado = True
                nombres.Text = Encontrado(0) & " " & Encontrado(1)
                fecha.Text = Encontrado(2)
                If FormatDateTime(Encontrado(2)) > Now.Date Then
                    intDiasRestantes = DateDiff(DateInterval.Day, Now.Date(), Encontrado(2))
                End If
                If Encontrado(2) = Now.Date Then
                    intDiasRestantes = 1
                End If
                If My.Computer.FileSystem.FileExists(Encontrado(5).ToString) Then
                    Dim Imagen As New Bitmap(Encontrado(5).ToString)
                    foto.Image = Imagen
                End If
                intIdCliente = Encontrado(6)
                txtdescripcion.Text = Encontrado(7)

            Next
        End If
        Return booEncontrado
    End Function
    Public Sub ponerFoto(logo As String, picFoto As PictureBox)
        If My.Computer.FileSystem.FileExists(logo) Then
            Dim Imagen As New Bitmap(Principal.Logo)
            picFoto.Image = Imagen

        End If
    End Sub
    Public Function validarContraseña(texto As String) As Boolean
        Dim boosaber As Boolean = False
        Try
            conexion.ConnectionString = Principal.cadenadeconexion
            conexion.Open()
            Dim cadena As String
            cadena = "SELECT usuario FROM login WHERE contraseña='" & texto & "'"
            Dim cmd As New MySqlCommand(cadena, conexion)
            Using leerdato As MySqlDataReader = cmd.ExecuteReader()
                While leerdato.Read()
                    boosaber = True
                End While
            End Using
            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return boosaber

    End Function
    Public Function saberingreso(cedula As String, Optional tabla As String = "cliente") As Boolean
        Dim boosaber As Boolean = False
        Try
            conexion.ConnectionString = Principal.cadenadeconexion
            conexion.Open()
            Dim cadena As String
            cadena = "SELECT id FROM " & tabla & " WHERE cedula='" & cedula & "'"
            Dim cmd As New MySqlCommand(cadena, conexion)
            Using leerdato As MySqlDataReader = cmd.ExecuteReader()
                While leerdato.Read()
                    boosaber = True
                End While
            End Using
            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return boosaber

    End Function
    Public Function saberNombreporCedula(cedula As String, Optional tabla As String = "cliente") As String
        Dim strClente As String = ""
        Try
            conexion.ConnectionString = Principal.cadenadeconexion
            conexion.Open()
            Dim cadena As String
            cadena = "SELECT CONCAT(nombre,' ',apellido) as cliente FROM " & tabla & " WHERE cedula='" & cedula & "'"
            Dim cmd As New MySqlCommand(cadena, conexion)
            Using leerdato As MySqlDataReader = cmd.ExecuteReader()
                While leerdato.Read()
                    strClente = leerdato(0)
                End While
            End Using
            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return strClente

    End Function

    Function saberIdPago(strcedula As String) As Integer
        Dim intID As Integer = 0
        Dim arlCoincidecias As ArrayList = Gestor1.DatosDeConsulta("SELECT id FROM pago WHERE cedula='" & strcedula & "' limit 1", , Principal.cadenadeconexion)
        If Not arlCoincidecias.Count = 0 Then
            For Each cliente As ArrayList In arlCoincidecias
                intID = cliente(0)
            Next
        End If

        Return intID
    End Function
    Function saberIdTerceroByCedula(strcedula As String) As Integer
        Dim intID As Integer = 0
        Dim arlCoincidecias As ArrayList = Gestor1.DatosDeConsulta("SELECT id FROM cliente WHERE cedula='" & strcedula & "' limit 1", , Principal.cadenadeconexion)
        If Not arlCoincidecias.Count = 0 Then
            For Each cliente As ArrayList In arlCoincidecias
                intID = cliente(0)
            Next
        End If

        Return intID
    End Function
    Public Function datosempleado(txtcedula As TextBox, strcedula As String, nom As TextBox, ape As TextBox, telefono As TextBox, foto As PictureBox, tipobusqueda As Integer, ByRef strruta As String, ByRef intmodificado As Integer) As Boolean
        Dim booSaber = False
        Dim arlConicidencias As New ArrayList
        Select Case tipobusqueda
            Case 1
                arlConicidencias = Gestor1.DatosDeConsulta("SELECT id,cedula,nombre,apellido,cell,ruta FROM empleado WHERE id = '" & strcedula & "' ", , Principal.cadenadeconexion)
            Case 2
                arlConicidencias = Gestor1.DatosDeConsulta("SELECT * FROM empleado WHERE cedula = '" & strcedula & "' ", , Principal.cadenadeconexion)
        End Select
        If Not arlConicidencias.Count = 0 Then
            For Each empleado As ArrayList In arlConicidencias
                intmodificado = empleado(0)
                booSaber = True
                txtcedula.Text = empleado(1)
                nom.Text = empleado(2)
                ape.Text = empleado(3)
                telefono.Text = empleado(4)
                strruta = empleado(5)
                If My.Computer.FileSystem.FileExists(strruta) Then
                    Clientes.imagenfoto.Image = Nothing
                    Dim Imagen As New Bitmap(strruta)
                    foto.Image = Imagen

                End If

            Next
        End If
        Return booSaber
    End Function
    Public Function Alimentar(txtcedula As TextBox, cedula As String, nom As TextBox, ape As TextBox, telefono As TextBox, direccion As TextBox, email As TextBox, fecha As DateTimePicker, foto As PictureBox, tipobusqueda As Integer, ByRef intmodificado As Integer, ByRef intIdPago As Integer, ByRef strfoto As String, eps As TextBox, contanto As TextBox, telefono2 As TextBox, rh As TextBox, instructor As TextBox) As Boolean
        Dim booClienteEncontrado As Boolean = False
        Try
            conexion.ConnectionString = Principal.cadenadeconexion
            conexion.Open()
            Dim cadena As String = ""

            Select Case tipobusqueda
                Case 1
                    cadena = "SELECT id,cedula,nombre,apellido,ifnull(telefono,'NADA') AS TELEFONO,ifnull(direccion,'') as direccion, correo,ifnull(nacimiento,'2018-01-01') as nacimiento,ruta,eps,contacto,telefono2,rh,instructor FROM cliente WHERE id='" & cedula & "'"
                Case 2
                    cadena = "SELECT id,cedula,nombre,apellido,ifnull(telefono,'NADA') AS TELEFONO,ifnull(direccion,'') as direccion, correo,ifnull(nacimiento,'2018-01-01') as nacimiento,ruta,eps,contacto,telefono2,rh,instructor FROM cliente WHERE cedula='" & cedula & "'"
            End Select

            Dim cmd As New MySqlCommand(cadena, conexion)
            Using leerdato As MySqlDataReader = cmd.ExecuteReader()
                While leerdato.Read()
                    txtcedula.Text = leerdato.GetString("cedula")
                    intIdPago = saberIdPago(leerdato.GetString("cedula"))
                    nom.Text = leerdato.GetString("nombre")
                    intmodificado = leerdato.GetInt32("id")
                    ape.Text = leerdato.GetString("apellido")
                    telefono.Text = leerdato.GetString("telefono")
                    direccion.Text = leerdato.GetString("direccion")
                    email.Text = leerdato.GetString("correo")
                    booClienteEncontrado = True
                    Dim fe As Date = leerdato.Item("nacimiento")
                    fecha.Text = Format(fe, "dd-MM-yyyy")
                    strfoto = leerdato.GetString("ruta")
                    eps.Text = leerdato.GetString("eps")
                    contanto.Text = leerdato.GetString("contacto")
                    telefono2.Text = leerdato.GetString("telefono2")
                    rh.Text = leerdato.GetString("rh")
                    instructor.Text = leerdato.GetString("instructor")
                    If My.Computer.FileSystem.FileExists(strfoto) Then
                        Clientes.imagenfoto.Image = Nothing
                        Dim Imagen As New Bitmap(strfoto)
                        foto.Image = Imagen
                    End If
                End While
            End Using
            conexion.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return booClienteEncontrado
    End Function

End Class
