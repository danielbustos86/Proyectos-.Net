Imports System.IO
Imports System.Xml
Imports SAP.Middleware.Connector

Public Class Form1
    Public WithEvents FSWC As FileSystemWatcher
    Dim pathorigen As String = ""
    Dim procesado As String
    Dim error_formato As String
    Dim error_rfc As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        recuperaserver()
        FSWC = New FileSystemWatcher(dirDescargamail1)
        FSWC.EnableRaisingEvents = True
        ListBox1.Items.Add("Servicio Iniciado")
        revisaPendientes()
    End Sub
    Sub revisaPendientes()
        Dim folder As New DirectoryInfo(dirDescargamail1)

        For Each file As FileInfo In folder.GetFiles()
            'ListBox1.Items.Add(file.FullName)
            leetext(file.FullName)
        Next
    End Sub

    Private Sub Button1_HOVER(sender As Object, e As EventArgs) Handles Button1.MouseHover
        Button1.BackgroundImage = My.Resources.iniciar_2

    End Sub

    Private Sub Button1_leave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        Button1.BackgroundImage = My.Resources.iniciar1

    End Sub

    Private Sub Button1_down(sender As Object, e As EventArgs) Handles Button1.MouseDown
        Button1.BackgroundImage = My.Resources.iniciar_3

    End Sub

    Private Sub FSWC_Changed(sender As Object, e As FileSystemEventArgs) Handles FSWC.Changed
        'ListBox1.Items.Add("MODIFICADO")
    End Sub

    Private Sub FSWC_Created(sender As Object, e As FileSystemEventArgs) Handles FSWC.Created
        Dim validaabierto As Boolean = True
        ListBox1.Items.Add("SE CREAN ARCHIVOS")
        Dim folder As New DirectoryInfo(dirDescargamail1)
        Dim ruta As String
        ruta = e.FullPath.ToString
        ListBox1.Items.Add(e.FullPath.ToString)

        While validaabierto = True
            validaabierto = IsFileOpen(e.FullPath.ToString)
            ListBox1.Items.Add("Proceso de copia")
        End While
        ListBox1.Items.Add("Copia finalizada")
        leetext(ruta)
        'For Each file As FileInfo In folder.GetFiles()
        '    ListBox1.Items.Add(file.Name)
        'Next
    End Sub
    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Dim strEstado As String = Me.WindowState.ToString()
        If strEstado <> "Normal" Then
            If strEstado = "Maximized" Then
                MessageBox.Show("Ventana Maximizada")
            Else

                NotifyIcon1.Visible = True
                NotifyIcon1.BalloonTipText = "La aplicacion seguira en ejecucion en segundo plano"
                NotifyIcon1.BalloonTipTitle = "Primastec"
                NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
                NotifyIcon1.ShowBalloonTip(1000000)
                NotifyIcon1.Icon = Me.Icon
                NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1

                Me.Visible = False
            End If
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
        CheckForIllegalCrossThreadCalls = False
        recuperaserver()
        'AppServerHost = "222.1.120.3" '"222.1.60.6"
        'SystemNumber = "00" '"04"
        'SystemID = "TST" '"DES"
        'UserSAP = "ex_prismatec" ' "ex_prismatec"
        'PasswordSAP = "pris0403" '"pris0403"
        Client = "400"
        Language = "ES"
        PoolSize = "5"
        MaxPoolSize = "10"
        IdleTimeout = "600"
    End Sub
    Sub recuperaserver()
        Dim archivo As String = ""
        archivo = "Ambientesel.xml"
        Dim notificaexito As String = ""
        Dim notificaerror As String = " "
        Dim xmlReader As New XmlTextReader(Application.StartupPath + "\" + archivo)
        'Crear un objeto para deserializar el archivo XML
        Dim Reader As New Serialization.XmlSerializer(GetType(ambiente))
        'Deserialziar el archivo xml y cargarlo en un objeto
        Dim parame = Reader.Deserialize(xmlReader)
        lbl_servidor.Text = parame.ambiente_actual

        'Cerrar Archivo XML
        xmlReader.Close()
        Leerparametros(lbl_servidor.Text)
        Dim parametros As parametrogeneraless = New parametrogeneraless()

    End Sub
    Private Sub Leerparametros(ByVal ambiente As String)
        'Leer un archivo XML y cargarlo en un objeto
        Try
            Dim archivo As String = ""
            archivo = ambiente + ".xml"
            Dim notificaexito As String = ""
            Dim notificaerror As String = " "
            Dim xmlReader As New XmlTextReader(Application.StartupPath + "\" + archivo)
            'Crear un objeto para deserializar el archivo XML
            Dim Reader As New Serialization.XmlSerializer(GetType(parametrogeneraless))
            'Deserialziar el archivo xml y cargarlo en un objeto
            Dim parame = Reader.Deserialize(xmlReader)
            'Cargar los datos en la forma.
            usuario1 = parame.usuario
            servidor1 = parame.servidor
            contraseña1 = parame.contraseña
            SystemNumber = parame.systemnumber
            systemId1 = parame.systemId


            AppServerHost = parame.servidor
            SystemNumber = parame.systemnumber
            SystemID = parame.systemId
            UserSAP = parame.usuario
            PasswordSAP = parame.contraseña




            notificarexitoso1 = parame.notificarexitoso
            mailnotificaexi1 = parame.mailnotificaexi               
            notificaError1 = parame.notificaError

            mailnotiicaError1 = parame.mailnotiicaError
            dirDescargamail1 = parame.dirDescargamail
            dirErrorFormato1 = parame.dirErrorFormato
            dirErrorRFC1 = parame.dirErrorRFC
            dirProcesados1 = parame.dirProcesados
            dirlog1 = parame.dirlog
            'Cerrar Archivo XML
            xmlReader.Close()
        Catch ex As Exception
            MsgBox(ex.InnerException.Message.ToString)
        End Try

    End Sub
    Private Function IsFileOpen(filePath As String) As Boolean
        Dim rtnvalue As Boolean = False
        Try
            Dim fs As System.IO.FileStream = System.IO.File.OpenWrite(filePath)
            fs.Close()
        Catch ex As System.IO.IOException
            rtnvalue = True
        End Try
        Return rtnvalue
    End Function
    Sub leetext(ByVal ruta As String)
        Dim objReader As New StreamReader(ruta)
        Dim sLine As String = ""
        Dim arrText As New ArrayList()
        Dim arrtext1 As New ArrayList()
        Dim limpio As String = ""
        Dim aux As String = ""
        Dim factura As String = ""
        Dim factura1 As String = ""
        Dim posicion_final As Integer = 0
        Dim largo As Integer = 0
        Dim emisor As String = ""
        Dim posicion_inicial As Integer = 0
        Dim montototal As String = ""
        Dim fechaemi As String = ""
        Dim cedidoa As String = ""
        Dim FechaRecepcion As String = ""
        Dim FechaRecepcionaux As String = ""
        Dim ano As String = ""
        Dim cedidonombre As String = ""

        Dim esfactura As Boolean
        Dim esemisor As Boolean
        Dim esmontototal As Boolean
        Dim esfechaemi As Boolean
        Dim escedido As Boolean
        Dim pasoesfactura As Boolean
        Dim pasoesemisor As Boolean
        Dim esfechaRecepcion As Boolean
        Dim escedidonombre As Boolean



        Dim result As String

        result = Path.GetFileName(ruta)

        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                arrText.Add(sLine)

            End If
        Loop Until sLine Is Nothing
        objReader.Close()



        For Each sLine In arrText

            limpio = sLine
            If Not limpio.Contains("Cedido a") Then

                aux = Replace(limpio, " ", "")
            Else
                aux = limpio


            End If
            If Not aux Is Nothing Then

                'ListBox1.Items.Add(aux)
                esfechaRecepcion = aux.Contains("FechadeRecepcion")

                If esfechaRecepcion Then
                    posicion_inicial = InStr(aux, ":", CompareMethod.Text)
                    posicion_inicial = posicion_inicial + 1
                    largo = aux.Length
                    FechaRecepcion = Mid(aux, posicion_inicial, 10)
                    FechaRecepcionaux = FechaRecepcion
                    FechaRecepcion = Mid(FechaRecepcionaux, 7, 4) + Mid(FechaRecepcionaux, 4, 2) + Mid(FechaRecepcionaux, 1, 2)

                    ListBox1.Items.Add("Fecha de Recepcion:" + FechaRecepcion)


                End If

                esfactura = aux.Contains("FACTURAELECTRONICA")
                If esfactura Then
                    posicion_final = InStr(aux, "-", CompareMethod.Text)
                    posicion_final = posicion_final
                    largo = posicion_final - 21
                    factura = Mid(aux, 21, largo)
                    pasoesfactura = True
                    ListBox1.Items.Add("Factura:" + factura)
                End If

                esmontototal = aux.Contains("MontoTotal")
                If esmontototal Then
                    posicion_inicial = InStr(aux, "$", CompareMethod.Text)
                    posicion_inicial = posicion_inicial + 1
                    posicion_final = aux.Length
                    montototal = Mid(aux, posicion_inicial, posicion_final)
                    ListBox1.Items.Add("Monto total:" + montototal)
                End If

                esemisor = aux.Contains("Emisor")
                If esemisor Then
                    posicion_inicial = InStr(aux, ":", CompareMethod.Text)
                    posicion_inicial = posicion_inicial + 1
                    largo = aux.Length
                    posicion_final = InStr(aux, "-", CompareMethod.Text)
                    posicion_final = posicion_final + 2
                    posicion_final = posicion_final - posicion_inicial
                    emisor = Mid(aux, posicion_inicial, posicion_final)
                    ListBox1.Items.Add("Emisor: " + emisor)
                    pasoesemisor = True

                End If

                esfechaemi = aux.Contains("FechaEmision")
                If esfechaemi Then
                    posicion_inicial = InStr(aux, ":", CompareMethod.Text)
                    posicion_inicial = posicion_inicial + 1
                    largo = aux.Length
                    fechaemi = Mid(aux, posicion_inicial, largo)
                    fechaemi = Replace(fechaemi, "-", "")
                    ListBox1.Items.Add("Fecha Emision: " + fechaemi)
                End If

                escedido = aux.Contains("Cedido a")
                If escedido Then
                    posicion_inicial = InStr(aux, ":", CompareMethod.Text)
                    posicion_inicial = posicion_inicial + 1
                    posicion_final = InStr(aux, "-", CompareMethod.Text)
                    posicion_final = posicion_final + 2
                    posicion_final = posicion_final - posicion_inicial
                    cedidoa = Mid(aux, posicion_inicial, posicion_final)

                    ListBox1.Items.Add("Cedido a : " + RTrim(LTrim(cedidoa)))

                    posicion_inicial = InStr(aux, "-", CompareMethod.Text)
                    posicion_inicial = posicion_inicial + 3
                    posicion_final = aux.Length - posicion_inicial
                    cedidonombre = Mid(aux, posicion_inicial, posicion_final)
                    ListBox1.Items.Add("Nombre Factory: " + cedidonombre)

                End If



            End If


        Next
        Dim Cuerpo As String = ""

        If pasoesemisor And pasoesfactura Then
            ListBox1.Items.Add("Esperando respuesta de SAP...")

            Dim mensaje As String = ""
            mensaje = CARGARFC(fechaemi, FechaRecepcion, RTrim(LTrim(cedidoa)), RTrim(LTrim(cedidonombre)), factura, emisor)

            If mensaje = "OK" Then
                If File.Exists(dirProcesados1 + "\" + result) Then
                    File.Delete(dirProcesados1 + "\" + result)

                End If
                File.Move(ruta, dirProcesados1 + "\" + result)
                ListBox1.Items.Add("Procesado correctamente en SAP")
                Cuerpo = "Se cargo una notificacion de Factory para la Factura:" + factura + " Emisor:" + emisor

                If notificarexitoso1 = "S" Then
                    EnviarMail(mailnotificaexi1, Cuerpo, "Proceso de Carga Factura Factory", "danielbustos86@gmail.com")

                End If
                

            Else
                If File.Exists(dirErrorRFC1 + "\" + result) Then
                    File.Delete(dirErrorRFC1 + "\" + result)

                End If
                File.Move(ruta, dirErrorRFC1 + "\" + result)
                ListBox1.Items.Add("Error al cargar el RFC")
                Cuerpo = "Error al enviar informacion a SAP  Factura:" + factura + " Emisor:" + emisor + " Archivo: " + result

                If notificaError1 = "S" Then
                    EnviarMail(mailnotiicaError1, Cuerpo, "Error Factura Factory", "danielbustos86@gmail.com")

                End If


            End If

        Else

            If File.Exists(dirErrorFormato1 + "\" + result) Then
                File.Delete(dirErrorFormato1 + "\" + result)

            End If
            File.Move(ruta, dirErrorFormato1 + "\" + result)

            ListBox1.Items.Add("No cumple formato")
            Cuerpo = "Error de Formato archivo:" + result
            If notificaError1 = "S" Then
                EnviarMail(mailnotiicaError1, Cuerpo, "Error Factura Factory", "danielbustos86@gmail.com")

            End If

            
        End If
        RespaldaListbox()
    End Sub
    Sub RespaldaListbox()
        If ListBox1.Items.Count > 300 Then

            Dim rutaFichero As String
            Dim nombrelog As String
            Dim i As Integer
            rutaFichero = dirlog1 + "\" + Now.Day.ToString + "-" + Now.Month.ToString + "-" + Now.Year.ToString

            If Not Directory.Exists(rutaFichero) Then
                Directory.CreateDirectory(rutaFichero)
            End If

            nombrelog = "LOG_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString + ".txt"

            rutaFichero = Path.Combine(rutaFichero, nombrelog)
            Dim fichero As New IO.StreamWriter(rutaFichero)
            For i = 0 To ListBox1.Items.Count - 1
                fichero.WriteLine(ListBox1.Items(i))
            Next
            fichero.Close()

            ListBox1.Items.Clear()
        End If
    End Sub

    'Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    '    NotifyIcon1.Visible = True
    '    NotifyIcon1.BalloonTipText = "La aplicacion seguira en ejecucion en segundo plano"
    '    NotifyIcon1.BalloonTipTitle = "Primastec"
    '    NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
    '    NotifyIcon1.ShowBalloonTip(1000000)
    '    NotifyIcon1.Icon = Me.Icon
    '    NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1

    '    Me.Visible = False
    'End Sub

    Private Sub MostrarAplicacionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MostrarAplicacionToolStripMenuItem.Click
        Me.Visible = True
        NotifyIcon1.Visible = False
        Me.WindowState = FormWindowState.Normal

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim con As Configuracion = New Configuracion()

        con.Show()


    End Sub
    Private Sub Button5_MOUSELEAVE(sender As Object, e As EventArgs) Handles Button5.MouseLeave
        Button5.BackgroundImage = My.Resources.configuracion_11

    End Sub

    Private Sub Button5_MOUSEHOVER(sender As Object, e As EventArgs) Handles Button5.MouseHover
        Button5.BackgroundImage = My.Resources.configuracion_2
    End Sub

    Private Sub Button5_MOUSEdown(sender As Object, e As EventArgs) Handles Button5.MouseDown
        Button5.BackgroundImage = My.Resources.configuracion_3

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        '  recuperaserver()
        FSWC = New FileSystemWatcher(dirDescargamail1)
        FSWC.EnableRaisingEvents = False
        ListBox1.Items.Add("Servicio Detenido")
        
        'Dim csap As New ECCDestinationConfig

        'Try
        '    RfcDestinationManager.RegisterDestinationConfiguration(csap)
        'Catch ex As Exception

        '    MessageBox.Show("ERROR: " & ex.Message, "MDATA", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    'Exit Sub
        'End Try
        'Dim prd As RfcDestination = RfcDestinationManager.GetDestination("EZC")
        'Dim repo As RfcRepository
        'Try
        '    repo = prd.Repository
        'Catch ex As Exception
        '    Me.Cursor = Cursors.Default
        '    RfcDestinationManager.UnregisterDestinationConfiguration(csap)
        '    MessageBox.Show("ERROR: " & ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'End Try
        'Dim companyBapi1 As IRfcFunction = repo.CreateFunction("ZFI_DTE_INSERTA")
        'Dim table As IRfcTable = companyBapi1.GetTable("T_CABECERA")
        'companyBapi1.SetValue("I_FACTORING", "X")


        'table.Append()
        'table.SetValue("BUKRS", "T2")
        'table.SetValue("TIPODTE", "33")
        'table.SetValue("ESTADO", "F")
        'table.SetValue("FEC_EMI_CN", "20171212")
        'table.SetValue("FEC_REC_CN", "20171213")
        'table.SetValue("RUT_PROVEEDOR", "76261789-7")
        'table.SetValue("NOM_PROVEEDOR", "EMPRESA FACT")

        'table.SetValue("USER_FACTORING", "EX_PRISMATEC")
        'table.SetValue("FOLIO", "93765")
        'table.SetValue("RUTEMISOR", "96656410-5")
        '' table.SetValue("I_FACTORING", "X")






        ''FEC_EMI_CN
        ''FEC_REC_CN
        ''RUT_PROVEEDOR()
        ''USER_FACTORING()
        ''ZDTE_FEC_EMIS
        ''ZDTE_FEC_RECEP
        ''ZDTE_RUT_PROV
        ''ZDTE_USER_FACT

        'companyBapi1.Invoke(prd)
        'Dim retorno As String = companyBapi1.GetString("E_RETORNO")
        'Dim mensaje As String = companyBapi1.GetString("E_MENSAJE")
        'If retorno = "OK" Then
        '    MsgBox("Envio OK")
        '    MsgBox(mensaje)
        'Else
        '    MsgBox(retorno)
        '    MsgBox(mensaje)
        'End If
        'RfcDestinationManager.UnregisterDestinationConfiguration(csap)

    End Sub
    Function CARGARFC(ByVal FEC_EMI_CN As String, ByVal FEC_REC_CN As String, ByVal RUT_PROVEEDOR As String, ByVal NOM_PROVEEDOR As String, ByVal FOLIO As String, ByVal RUTEMISOR As String) As String
        Dim respuesta As String
        Dim csap As New ECCDestinationConfig

        Try
            RfcDestinationManager.RegisterDestinationConfiguration(csap)
        Catch ex As Exception

            MessageBox.Show("ERROR: " & ex.Message, "MDATA", MessageBoxButtons.OK, MessageBoxIcon.Error)
            respuesta = "ERROR: " & ex.Message
            'Exit Sub
        End Try
        Dim prd As RfcDestination = RfcDestinationManager.GetDestination("EZC")
        Dim repo As RfcRepository
        Try
            repo = prd.Repository
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            RfcDestinationManager.UnregisterDestinationConfiguration(csap)
            '    MessageBox.Show("ERROR: " & ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            respuesta = "ERROR: " & ex.Message
            Return respuesta
            Exit Function
        End Try
        Dim companyBapi1 As IRfcFunction = repo.CreateFunction("ZFI_DTE_INSERTA")
        Dim table As IRfcTable = companyBapi1.GetTable("T_CABECERA")
        companyBapi1.SetValue("I_FACTORING", "X")


        table.Append()
        table.SetValue("BUKRS", "T2")
        table.SetValue("TIPODTE", "33")
        table.SetValue("ESTADO", "F")
        table.SetValue("FEC_EMI_CN", FEC_EMI_CN)
        table.SetValue("FEC_REC_CN", FEC_REC_CN)
        table.SetValue("RUT_PROVEEDOR", RUT_PROVEEDOR)
        table.SetValue("NOM_PROVEEDOR", NOM_PROVEEDOR)

        table.SetValue("USER_FACTORING", "EX_PRISMATEC")
        table.SetValue("FOLIO", FOLIO)
        table.SetValue("RUTEMISOR", RUTEMISOR)
        ' table.SetValue("I_FACTORING", "X")






        'FEC_EMI_CN
        'FEC_REC_CN
        'RUT_PROVEEDOR()
        'USER_FACTORING()
        'ZDTE_FEC_EMIS
        'ZDTE_FEC_RECEP
        'ZDTE_RUT_PROV
        'ZDTE_USER_FACT

        companyBapi1.Invoke(prd)
        Dim retorno As String = companyBapi1.GetString("E_RETORNO")
        Dim mensaje As String = companyBapi1.GetString("E_MENSAJE")
        If retorno = "OK" Then
            'MsgBox("Envio OK")
            'MsgBox(mensaje)
            respuesta = "OK"
        Else
            'MsgBox(retorno)
            'MsgBox(mensaje)
            respuesta = mensaje
        End If
        RfcDestinationManager.UnregisterDestinationConfiguration(csap)

        Return respuesta

    End Function

    Private Sub Button4_hover(sender As Object, e As EventArgs) Handles Button4.MouseHover
        Button4.BackgroundImage = My.Resources.detener_2
    End Sub

    Private Sub Button4_leave(sender As Object, e As EventArgs) Handles Button4.MouseLeave
        Button4.BackgroundImage = My.Resources.detener1
    End Sub

    Private Sub Button4_down(sender As Object, e As EventArgs) Handles Button4.MouseDown
        Button4.BackgroundImage = My.Resources.detener_3
    End Sub

    Private Sub Button1_down(sender As Object, e As MouseEventArgs) Handles Button1.MouseDown

    End Sub
    Private Sub Button4_down(sender As Object, e As MouseEventArgs) Handles Button4.MouseDown

    End Sub
    Private Sub Button5_MOUSEdown(sender As Object, e As MouseEventArgs) Handles Button5.MouseDown

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Try

            'cuerpo = cuerpo + "<table border=1 cellpadding=0 cellspacing=0>"
            'cuerpo = cuerpo + "  <tr><td><table border=0 cellpadding=0 cellspacing=0><tr>"
            'cuerpo = cuerpo + "<td width=90 height=40>&nbsp;</td>"
            'cuerpo = cuerpo + "<td width=257 align=center valign=middle><strong>NOTIFICACION PROCESO AUTOMATICO</strong></td>"
            'cuerpo = cuerpo + "<td width=99>&nbsp;</td></tr><tr>Factura:XXXX<td colspan=3><table width=448 border=0>"
            'cuerpo = cuerpo + "<tr> <td width=218 align=center> </td><td width=206 align=center>Proveedor:21313</td>"
            'cuerpo = cuerpo + "</tr></table></td></tr><tr><td>&nbsp;</td><td><div align=center></div></td><td>Empresa Factory:BCI FAC</td>"
            'cuerpo = cuerpo + "</tr><tr><td>&nbsp;</td><td><div align=center></div></td><td>Rut Factory:221212</td></tr><tr>"
            'cuerpo = cuerpo + "<td colspan=3><div align=center></div></td></tr><tr>"
            'cuerpo = cuerpo + "<td colspan=3 align=center><h6></h6></td></tr></table></td></tr></table>"
            Dim cuerpo As String = ""
            'cuerpo = "<html>"
            'cuerpo = cuerpo + "<table><tr><td>Algo en html</td></tr></table>"
            'cuerpo = cuerpo + "</html>"

            cuerpo = "algo" + "br" + "Linea 2"

            Dim Archivo As String = ""
            Dim DataArchivo As Byte()
            'OpenFileDialog1.Title = "Open File"
            'OpenFileDialog1.FileName = String.Empty
            'OpenFileDialog1.ShowDialog()
            'If OpenFileDialog1.FileName = String.Empty Then
            '    '
            'Else
            '    Archivo = System.IO.Path.GetFileName(OpenFileDialog1.FileName)
            '    Dim fInfo As New FileInfo(OpenFileDialog1.FileName)
            '    Dim numBytes As Long = fInfo.Length
            '    Dim dLen As Double = Convert.ToDouble(fInfo.Length / 1000000)
            '    If (dLen < 5) Then
            '        Dim fStream As New FileStream(OpenFileDialog1.FileName, FileMode.Open,
            '        FileAccess.Read)
            '        Dim br As New BinaryReader(fStream)
            '        DataArchivo = br.ReadBytes(Convert.ToInt32(numBytes))
            '        br.Close()
            '        fStream.Close()
            '        fStream.Dispose()
            '    End If
            'End If
            Dim URL As String = "http://222.1.60.66/WS_MailServerTransport/EnvioMail.asmx"
            Dim manualWebClient As New System.Net.WebClient()
            manualWebClient.Headers.Add("Content-Type", "application/soap+xml;  charset=utf-8")
            Dim requestSoapXML = "<soap12:Envelope xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema' xmlns:soap12='http://www.w3.org/2003/05/soap-envelope'>"
            requestSoapXML = requestSoapXML & "<soap12:Body>"
            requestSoapXML = requestSoapXML & "<Enviar_Correo xmlns='http://WS_MailServerTransporte/'>"
            requestSoapXML = requestSoapXML & "<DesdeCorreo>sistemas@embonor.cl</DesdeCorreo>"
            requestSoapXML = requestSoapXML & "<DesdeNombre>Facturas Factory Automatico</DesdeNombre>"
            requestSoapXML = requestSoapXML & "<Cuerpo>" + cuerpo + "</Cuerpo>"
            requestSoapXML = requestSoapXML & "<EsHtml>SI</EsHtml>"
            requestSoapXML = requestSoapXML & "<SubJect>Correo de prueba</SubJect>"
            requestSoapXML = requestSoapXML & "<Archivo></Archivo>"
            requestSoapXML = requestSoapXML & "<DestinatariosPara>"
            requestSoapXML = requestSoapXML & "<Entrada>"
            requestSoapXML = requestSoapXML & "<DESTINO>danielbustos86@gmail.com</DESTINO>"
            requestSoapXML = requestSoapXML & "</Entrada>"
            requestSoapXML = requestSoapXML & "<Entrada>"
            requestSoapXML = requestSoapXML & "<DESTINO>victorbron@gmail.com</DESTINO>"
            requestSoapXML = requestSoapXML & "</Entrada>"
            requestSoapXML = requestSoapXML & "</DestinatariosPara>"
            requestSoapXML = requestSoapXML & "<DestinatariosCopia>"
            requestSoapXML = requestSoapXML & "<Entrada>"
            requestSoapXML = requestSoapXML & "<DESTINO>danielbustos86@gmail.com</DESTINO>"
            requestSoapXML = requestSoapXML & "</Entrada>"
            requestSoapXML = requestSoapXML & "</DestinatariosCopia>"
            requestSoapXML = requestSoapXML & "<DestinatariosCopiaOculta>"
            requestSoapXML = requestSoapXML & "</DestinatariosCopiaOculta>"
            '      If OpenFileDialog1.FileName = String.Empty Then
            requestSoapXML = requestSoapXML & "<f></f>"
            'Else
            'requestSoapXML = requestSoapXML & "<f>" & Convert.ToBase64String(DataArchivo) & "</f>"
            'End If
            requestSoapXML = requestSoapXML & "</Enviar_Correo>"
            requestSoapXML = requestSoapXML & "</soap12:Body>"
            requestSoapXML = requestSoapXML & "</soap12:Envelope>"
            Dim bytArguments As Byte() = System.Text.Encoding.ASCII.GetBytes(requestSoapXML)
            Dim bytRetData As Byte() = manualWebClient.UploadData(URL, "POST", bytArguments)
            ListBox1.Items.Add("Mail Enviado")

        Catch ex As Exception
            ListBox1.Items.Add("Mail no Enviado" + ex.Message.ToString)
        End Try
    End Sub

    Sub EnviarMail(ByVal destinatarios As ArrayList, ByVal cuerpo As String, ByVal titulo As String, ByVal copia As String)

        Try
            Dim Archivo As String = ""
            Dim DataArchivo As Byte()
            Dim i As Integer = 0

            Dim URL As String = "http://222.1.60.66/WS_MailServerTransport/EnvioMail.asmx"
            Dim manualWebClient As New System.Net.WebClient()
            manualWebClient.Headers.Add("Content-Type", "application/soap+xml;  charset=utf-8")
            Dim requestSoapXML = "<soap12:Envelope xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema' xmlns:soap12='http://www.w3.org/2003/05/soap-envelope'>"
            requestSoapXML = requestSoapXML & "<soap12:Body>"
            requestSoapXML = requestSoapXML & "<Enviar_Correo xmlns='http://WS_MailServerTransporte/'>"
            requestSoapXML = requestSoapXML & "<DesdeCorreo>sistemas@embonor.cl</DesdeCorreo>"
            requestSoapXML = requestSoapXML & "<DesdeNombre>Facturas Factory</DesdeNombre>"
            requestSoapXML = requestSoapXML & "<Cuerpo>" + cuerpo + "</Cuerpo>"
            requestSoapXML = requestSoapXML & "<EsHtml>SI</EsHtml>"
            requestSoapXML = requestSoapXML & "<SubJect>" + titulo + "</SubJect>"
            requestSoapXML = requestSoapXML & "<Archivo></Archivo>"
            requestSoapXML = requestSoapXML & "<DestinatariosPara>"

            'requestSoapXML = requestSoapXML & "<Entrada>"
            'requestSoapXML = requestSoapXML & "<DESTINO>danielbustos86@gmail.com</DESTINO>"
            'requestSoapXML = requestSoapXML & "</Entrada>"
            'requestSoapXML = requestSoapXML & "<Entrada>"
            'requestSoapXML = requestSoapXML & "<DESTINO>danielbustos86@gmail.com</DESTINO>"
            'requestSoapXML = requestSoapXML & "</Entrada>"


            While i < destinatarios.Count
                requestSoapXML = requestSoapXML & "<Entrada>"
                requestSoapXML = requestSoapXML & "<DESTINO>" + destinatarios(i).ToString + "</DESTINO>"
                requestSoapXML = requestSoapXML & "</Entrada>"

                i = i + 1

            End While


            requestSoapXML = requestSoapXML & "</DestinatariosPara>"
            requestSoapXML = requestSoapXML & "<DestinatariosCopia>"
            requestSoapXML = requestSoapXML & "<Entrada>"
            requestSoapXML = requestSoapXML & "<DESTINO>danielbustos86@gmail.com</DESTINO>"
            requestSoapXML = requestSoapXML & "</Entrada>"
            requestSoapXML = requestSoapXML & "</DestinatariosCopia>"
            requestSoapXML = requestSoapXML & "<DestinatariosCopiaOculta>"
            requestSoapXML = requestSoapXML & "</DestinatariosCopiaOculta>"
            '      If OpenFileDialog1.FileName = String.Empty Then
            requestSoapXML = requestSoapXML & "<f></f>"
            'Else
            'requestSoapXML = requestSoapXML & "<f>" & Convert.ToBase64String(DataArchivo) & "</f>"
            'End If
            requestSoapXML = requestSoapXML & "</Enviar_Correo>"
            requestSoapXML = requestSoapXML & "</soap12:Body>"
            requestSoapXML = requestSoapXML & "</soap12:Envelope>"
            Dim bytArguments As Byte() = System.Text.Encoding.ASCII.GetBytes(requestSoapXML)
            Dim bytRetData As Byte() = manualWebClient.UploadData(URL, "POST", bytArguments)
            ListBox1.Items.Add("Mail Enviado")

        Catch ex As Exception
            ListBox1.Items.Add("Mail no Enviado" + ex.Message.ToString)
        End Try
    End Sub


    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        Dim cuerpo As String = ""

        cuerpo = "<table border=1 cellpadding=0 cellspacing=0>"
        cuerpo = cuerpo + "  <tr><td><table border=0 cellpadding=0 cellspacing=0><tr>"
        cuerpo = cuerpo + "<td width=90 height=40>&nbsp;</td>"
        cuerpo = cuerpo + "<td width=257 align=center valign=middle><strong>NOTIFICACION PROCESO AUTOMATICO</strong></td>"
        cuerpo = cuerpo + "<td width=99>&nbsp;</td></tr><tr>Factura:XXXX<td colspan=3><table width=448 border=0>"
        cuerpo = cuerpo + "<tr> <td width=218 align=center> </td><td width=206 align=center>Proveedor:21313</td>"
        cuerpo = cuerpo + "</tr></table></td></tr><tr><td>&nbsp;</td><td><div align=center></div></td><td>Empresa Factory:BCI FAC</td>"
        cuerpo = cuerpo + "</tr><tr><td>&nbsp;</td><td><div align=center></div></td><td>Rut Factory:221212</td></tr><tr>"
        cuerpo = cuerpo + "<td colspan=3><div align=center></div></td></tr><tr>"
        cuerpo = cuerpo + "<td colspan=3 align=center><h6></h6></td></tr></table></td></tr></table>"
        cuerpo = "Se cargo notificacion Factory en Sap para Factura:      Proveedor:    "
        EnviarMail(mailnotificaexi1, cuerpo, "Facturas Factory Embonor", "danielbustos86@gmail.com")


    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        RespaldaListbox()
    End Sub
End Class
