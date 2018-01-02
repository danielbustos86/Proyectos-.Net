Imports System.Configuration
Imports System.Collections.Specialized
Imports System.Xml
Imports System.IO


Public Class Configuracion
    Dim listas As New ArrayList
    Dim listas2 As New ArrayList
    Dim pos_sel As Integer

    Private Sub Configuracion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbx_ambiente.SelectedIndex = 0
        Dim ambiente As String = ""

        If cbx_ambiente.SelectedIndex = 0 Then
            ambiente = "Prod"
        Else
            ambiente = "Test"
        End If
        Leerparametros(ambiente)
    End Sub
    Sub recuperar_valores()
        Dim servidor As String = ""
        Dim usuario As String = ""
        Dim clave As String = ""
        Dim sysnumber As String = ""
        Dim sysid As String = " "
        Dim appSettings = ConfigurationManager.AppSettings
        If cbx_ambiente.SelectedIndex = 0 Then
            servidor = appSettings("Servidor_prod")
            usuario = appSettings("usuario_prod")
            clave = appSettings("contraseña_prod")
            sysnumber = appSettings("sysid_prod")
            sysid = appSettings("sysnumb_prod")
        Else
            servidor = appSettings("Servidor_test")
            usuario = appSettings("usuario_test")
            clave = appSettings("contraseña_test")
            sysnumber = appSettings("sysid_test")
            sysid = appSettings("sysnumb_test")

        End If

        txt_servidor.Text = servidor
        txt_usuario.Text = usuario
        txt_contraseña.Text = clave
        txt_sysnumber.Text = sysnumber
        txt_sysid.Text = sysid

    End Sub

    Sub AddUpdateAppSettings(key As String, value As String)
        Try
            Dim configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
            Dim settings = configFile.AppSettings.Settings
            If IsNothing(settings(key)) Then
                settings.Add(key, value)
            Else
                settings(key).Value = value
            End If
            configFile.Save(ConfigurationSaveMode.Modified)
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name)
        Catch e As ConfigurationErrorsException
            MsgBox("Error writing app settings")
        End Try
    End Sub

    Private Sub btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click
        '   AddUpdateAppSettings("Servidor_prod", "11111")

        'recuperar_valores()
        Dim ambiente As String = ""
        Try

            If cbx_ambiente.SelectedIndex = 0 Then
                ambiente = "Prod"
            Else
                ambiente = "Test"
            
            End If
            parametrosXML(ambiente)
            If MessageBox.Show("se guardaron correctamente los cambios,desea que la aplicacion funcione en ambiente: " + ambiente, "Facturas Factory", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                GuardaAmbiente(ambiente)
                Form1.lbl_servidor.Text = ambiente

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub
    Sub guardarparcial()
        Dim ambiente As String = ""
        Try

            If cbx_ambiente.SelectedIndex = 0 Then
                ambiente = "Prod"
            Else
                ambiente = "Test"

            End If
            parametrosXML(ambiente)
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Sub GuardaAmbiente(ByVal ambientesel As String)
        Dim ambiente1 As New ambiente

        Try

            Dim archivo As String = ""
            archivo = "Ambientesel.xml"

            Dim objWriter As New Serialization.XmlSerializer(GetType(ambiente))
            'Crear un objeto file de tipo StremWriter para almacenar el documento xml
            ambiente1.ambiente_actual = ambientesel
            Dim objfile As New StreamWriter(archivo)
            'Serializar y crear el documento XML
            objWriter.Serialize(objfile, ambiente1)
            'Cerrar el archivo
            objfile.Close()

        Catch ex As Exception
            MessageBox.Show("Error 10:" + ex.InnerException.Message.ToString, "Fact Factory", MessageBoxButtons.OK)
        End Try

    End Sub

    Private Sub parametrosXML(ByVal ambiente As String)
        'Crear objeto y poblarlo
        Dim parametros As New parametrogeneraless
        Dim archivo As String = ""
        Dim notiexi As String = ""
        Dim notierro As String = ""

        archivo = ambiente + ".xml"

        parametros.servidor = txt_servidor.Text
        parametros.usuario = txt_usuario.Text
        parametros.contraseña = txt_contraseña.Text
        parametros.systemId = txt_sysid.Text
        parametros.systemnumber = txt_sysnumber.Text
        If cbx_noti_exi.Checked Then
            notiexi = "S"
        Else
            notiexi = "N"
        End If
        parametros.notificarexitoso = notiexi

        'If (listas IsNot Nothing) Then

        '    For Each item As String In listas

        '        'TxtNombre.Text = item
        '        parametros.mailnotificaexi.Add(item)

        '    Next

        'End If

        parametros.mailnotificaexi = listas


        If cbx_noti_error.Checked Then
            notierro = "S"
        Else
            notierro = "N"
        End If
        parametros.notificaError = notierro
        parametros.mailnotiicaError = listas2

        parametros.dirDescargamail = txt_desmail.Text
        parametros.dirErrorFormato = txterrorFormato.Text
        parametros.dirErrorRFC = txterrorRFC.Text
        parametros.dirProcesados = TxtProcesados.Text
        parametros.dirlog = txtlog.Text
        Dim objWriter As New Serialization.XmlSerializer(GetType(parametrogeneraless))
        'Crear un objeto file de tipo StremWriter para almacenar el documento xml

        Dim objfile As New StreamWriter(archivo)
        'Serializar y crear el documento XML
        objWriter.Serialize(objfile, parametros)
        'Cerrar el archivo
        objfile.Close()
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
            txt_usuario.Text = parame.usuario
            txt_servidor.Text = parame.servidor
            txt_contraseña.Text = parame.contraseña
            txt_sysnumber.Text = parame.systemnumber
            txt_sysid.Text = parame.systemId
            notificaexito = parame.notificarexitoso
            If notificaexito = "S" Then
                cbx_noti_exi.Checked = True
                listas = parame.mailnotificaexi
                Cargar_combo(ComboBox1, listas)


            Else
                cbx_noti_exi.Checked = False
                txt_mail_exito.Text = ""

            End If
            notificaerror = parame.notificaError
            If notificaerror = "S" Then
                cbx_noti_error.Checked = True
                listas2 = parame.mailnotiicaError
                Cargar_combo(ComboBox2, listas2)

            Else
                cbx_noti_error.Checked = False
                txt_error.Text = ""
            End If
            txt_desmail.Text = parame.dirDescargamail
            txterrorFormato.Text = parame.dirErrorFormato
            txterrorRFC.Text = parame.dirErrorRFC
            TxtProcesados.Text = parame.dirProcesados
            txtlog.Text = parame.dirlog
            'Cerrar Archivo XML
            xmlReader.Close()
        Catch ex As Exception
            MsgBox(ex.InnerException.Message.ToString)
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ambiente As String = ""
        If cbx_ambiente.SelectedIndex = 0 Then
            ambiente = "Prod"
        Else
            ambiente = "Test"

        End If

        Leerparametros(ambiente)
    End Sub

    Private Sub cbx_ambiente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbx_ambiente.SelectedIndexChanged
        Dim ambiente As String = ""
        If cbx_ambiente.SelectedIndex = 0 Then
            ambiente = "Prod"
        Else
            ambiente = "Test"
        End If

        Leerparametros(ambiente)
    End Sub

    Private Sub txtbtnsel1_Click(sender As Object, e As EventArgs) Handles txtbtnsel1.Click
        cargaArchivo(txt_desmail)

    End Sub

    Sub cargaArchivo(ByVal text As TextBox)
        Try
            Dim openFileDialog1 As New OpenFileDialog()
            openFileDialog1.InitialDirectory = "C:\"
            openFileDialog1.FilterIndex = 4
            openFileDialog1.RestoreDirectory = True

            If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
                Dim dir As String = FolderBrowserDialog1.SelectedPath
                text.Text = dir

            Else
                If String.IsNullOrEmpty(openFileDialog1.FileName) Then
                    MessageBox.Show("No ha Seleccionado ningun archivo")
                    Return
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        cargaArchivo(txterrorFormato)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        cargaArchivo(txterrorRFC)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        cargaArchivo(TxtProcesados)
    End Sub
    Dim abrio As Integer
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If abrio = 1 Then
            Guardarpanel(ComboBox1, listas)
        Else
            Guardarpanel(ComboBox2, listas2)
        End If

    End Sub
    Sub Guardarpanel(ByVal combobox As ComboBox, ByVal listasaux As ArrayList)
        Dim mensaje As String = ""
        If pos_sel > -1 Then
            listasaux(pos_sel) = txt_mail_exito.Text
            '   lblmensajemail.Text = "Se modifico correctamente el mail"
            mensaje = "Se modifico correctamente el mail"


        Else
            listasaux.Add(txt_mail_exito.Text)
            mensaje = "Se registro el mail en la lista"

            '            lblmensajemail.Text = "Se registro el mail en la lista"
        End If

        MsgBox(mensaje)
        Cargar_combo(combobox, listasaux)
        Panel1.Visible = False
        guardarparcial()
    End Sub
    Private Sub Button8_Click(sender As Object, e As EventArgs)
        Panel1.Visible = False

    End Sub

    Sub Cargar_combo(ByVal combo As ComboBox, ByVal listaAux As ArrayList)
        Dim i = 0
        '  ComboBox1.SelectedIndex = 0
        combo.Items.Clear()

        While i < listaAux.Count
            combo.Items.Add(listaAux(i))
            i = i + 1
        End While
        combo.Text = "Lista de correos"
    End Sub
    Function BuscaEnLista(ByVal listax As ArrayList, ByVal mail As String) As Integer
        Dim i As Integer = 0
        Dim pos As Integer = -1
        Dim existe As String = "N"
        'MsgBox(listas.Count)
        While (i < listax.Count And existe = "N")

            If listax(i).Equals(mail) Then
                pos = i
                existe = "S"
            End If

            i = i + 1

        End While
        Return pos
    End Function

    Sub Borrar_lista(ByVal listax As ArrayList, ByVal mail As String, ByVal combo As ComboBox)
        Dim i As Integer = 0
        Dim pos As Integer = -1
        Dim existe As String = "N"
        '      MsgBox(listas.Count)
        While (i < listax.Count And existe = "N")

            If listax(i).Equals(mail) Then
                pos = i
                existe = "S"
            End If

            i = i + 1

        End While

        If pos >= 0 Then
            listax.RemoveAt(pos)
            Cargar_combo(combo, listax)

            guardarparcial()
            MsgBox("mail eliminado de la lista")
        End If

    End Sub

    Private Sub A_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        abrio = 1
        
        abrepanel(ComboBox1, listas)

    End Sub
    Sub abrepanel(ByVal combo As ComboBox, ByVal listaaux As ArrayList)
        If combo.SelectedIndex > -1 Then
            pos_sel = BuscaEnLista(listaaux, combo.SelectedItem.ToString)
        Else
            pos_sel = -1
        End If

        If pos_sel > -1 Then
            txt_mail_exito.Text = listaaux(pos_sel)
        Else
            txt_mail_exito.Text = ""
        End If

        Panel1.Show()
        If pos_sel > -1 Then
            btn_elimina.Enabled = True
        Else
            btn_elimina.Enabled = False
        End If
    End Sub

    Private Sub Button8_Click_1(sender As Object, e As EventArgs) Handles Button8.Click
        Panel1.Visible = False

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles btn_elimina.Click
        Try
            If abrio = 1 Then
                eliminar(listas, ComboBox1)
                Cargar_combo(ComboBox1, listas)
            Else
                eliminar(listas2, ComboBox2)
                Cargar_combo(ComboBox2, listas2)
            End If
            MsgBox("Se elimino correctamente")
        Catch ex As Exception

        End Try
        

    End Sub
    

    Private Sub Button10_Click_1(sender As Object, e As EventArgs) Handles Button10.Click
        abrio = 2

        abrepanel(ComboBox2, listas2)

    End Sub

    Sub eliminar(ByVal listax As ArrayList, ByVal combo As ComboBox)

        listax.RemoveAt(pos_sel)

        guardarparcial()

        Panel1.Visible = False

        '    MsgBox("Se elimino el mail")

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        cargaArchivo(txtlog)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class