<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Configuracion
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Configuracion))
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbx_ambiente = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txt_sysid = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_sysnumber = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_contraseña = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_error = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_usuario = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_servidor = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.lblmensajemail = New System.Windows.Forms.Label()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.cbx_noti_error = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbx_noti_exi = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.txtlog = New System.Windows.Forms.TextBox()
        Me.Log = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.txtbtnsel1 = New System.Windows.Forms.Button()
        Me.txt_desmail = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TxtProcesados = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txterrorRFC = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txterrorFormato = New System.Windows.Forms.TextBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_elimina = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.txt_mail_exito = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_guardar
        '
        Me.btn_guardar.BackColor = System.Drawing.Color.Red
        Me.btn_guardar.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.ForeColor = System.Drawing.Color.White
        Me.btn_guardar.Location = New System.Drawing.Point(15, 12)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(75, 39)
        Me.btn_guardar.TabIndex = 0
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Red
        Me.Button1.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(96, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 39)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Cerrar"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Ambiente"
        '
        'cbx_ambiente
        '
        Me.cbx_ambiente.FormattingEnabled = True
        Me.cbx_ambiente.Items.AddRange(New Object() {"Produccion", "Test"})
        Me.cbx_ambiente.Location = New System.Drawing.Point(78, 65)
        Me.cbx_ambiente.Name = "cbx_ambiente"
        Me.cbx_ambiente.Size = New System.Drawing.Size(121, 21)
        Me.cbx_ambiente.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_sysid)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txt_sysnumber)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txt_contraseña)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txt_error)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txt_usuario)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txt_servidor)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 92)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(469, 135)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Conexion SAP"
        '
        'txt_sysid
        '
        Me.txt_sysid.Location = New System.Drawing.Point(278, 64)
        Me.txt_sysid.Name = "txt_sysid"
        Me.txt_sysid.Size = New System.Drawing.Size(100, 20)
        Me.txt_sysid.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(211, 68)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 13)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "System ID"
        '
        'txt_sysnumber
        '
        Me.txt_sysnumber.Location = New System.Drawing.Point(96, 64)
        Me.txt_sysnumber.Name = "txt_sysnumber"
        Me.txt_sysnumber.Size = New System.Drawing.Size(100, 20)
        Me.txt_sysnumber.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 68)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 13)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "System Number"
        '
        'txt_contraseña
        '
        Me.txt_contraseña.Location = New System.Drawing.Point(278, 104)
        Me.txt_contraseña.Name = "txt_contraseña"
        Me.txt_contraseña.Size = New System.Drawing.Size(100, 20)
        Me.txt_contraseña.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(211, 108)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Contraseña"
        '
        'txt_error
        '
        Me.txt_error.Location = New System.Drawing.Point(278, 19)
        Me.txt_error.Name = "txt_error"
        Me.txt_error.Size = New System.Drawing.Size(143, 20)
        Me.txt_error.TabIndex = 9
        Me.txt_error.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(211, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 13)
        Me.Label4.TabIndex = 4
        '
        'txt_usuario
        '
        Me.txt_usuario.Location = New System.Drawing.Point(96, 101)
        Me.txt_usuario.Name = "txt_usuario"
        Me.txt_usuario.Size = New System.Drawing.Size(100, 20)
        Me.txt_usuario.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 108)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Usuario"
        '
        'txt_servidor
        '
        Me.txt_servidor.Location = New System.Drawing.Point(96, 31)
        Me.txt_servidor.Name = "txt_servidor"
        Me.txt_servidor.Size = New System.Drawing.Size(100, 20)
        Me.txt_servidor.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Servidor"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ComboBox2)
        Me.GroupBox2.Controls.Add(Me.Button10)
        Me.GroupBox2.Controls.Add(Me.lblmensajemail)
        Me.GroupBox2.Controls.Add(Me.Button9)
        Me.GroupBox2.Controls.Add(Me.ComboBox1)
        Me.GroupBox2.Controls.Add(Me.cbx_noti_error)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.cbx_noti_exi)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 245)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(469, 111)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Notificaciones"
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(195, 59)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(189, 21)
        Me.ComboBox2.TabIndex = 16
        '
        'Button10
        '
        Me.Button10.BackColor = System.Drawing.Color.Transparent
        Me.Button10.BackgroundImage = Global.FacturaFactoring.My.Resources.Resources.if_list_edit_83882
        Me.Button10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button10.Location = New System.Drawing.Point(390, 56)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(29, 29)
        Me.Button10.TabIndex = 15
        Me.Button10.UseVisualStyleBackColor = False
        '
        'lblmensajemail
        '
        Me.lblmensajemail.AutoSize = True
        Me.lblmensajemail.Location = New System.Drawing.Point(196, 95)
        Me.lblmensajemail.Name = "lblmensajemail"
        Me.lblmensajemail.Size = New System.Drawing.Size(0, 13)
        Me.lblmensajemail.TabIndex = 14
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.Transparent
        Me.Button9.BackgroundImage = Global.FacturaFactoring.My.Resources.Resources.if_list_edit_83882
        Me.Button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button9.Location = New System.Drawing.Point(390, 25)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(29, 29)
        Me.Button9.TabIndex = 13
        Me.Button9.UseVisualStyleBackColor = False
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(195, 30)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(189, 21)
        Me.ComboBox1.TabIndex = 10
        '
        'cbx_noti_error
        '
        Me.cbx_noti_error.AutoSize = True
        Me.cbx_noti_error.Location = New System.Drawing.Point(10, 63)
        Me.cbx_noti_error.Name = "cbx_noti_error"
        Me.cbx_noti_error.Size = New System.Drawing.Size(89, 17)
        Me.cbx_noti_error.TabIndex = 8
        Me.cbx_noti_error.Text = "Notificar error"
        Me.cbx_noti_error.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(211, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Destinatario"
        '
        'cbx_noti_exi
        '
        Me.cbx_noti_exi.AutoSize = True
        Me.cbx_noti_exi.Location = New System.Drawing.Point(10, 30)
        Me.cbx_noti_exi.Name = "cbx_noti_exi"
        Me.cbx_noti_exi.Size = New System.Drawing.Size(142, 17)
        Me.cbx_noti_exi.TabIndex = 0
        Me.cbx_noti_exi.Text = "Notificar proceso exitoso"
        Me.cbx_noti_exi.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(190, 28)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button11)
        Me.GroupBox3.Controls.Add(Me.txtlog)
        Me.GroupBox3.Controls.Add(Me.Log)
        Me.GroupBox3.Controls.Add(Me.Button5)
        Me.GroupBox3.Controls.Add(Me.Button4)
        Me.GroupBox3.Controls.Add(Me.Button3)
        Me.GroupBox3.Controls.Add(Me.txtbtnsel1)
        Me.GroupBox3.Controls.Add(Me.txt_desmail)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.TxtProcesados)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.txterrorRFC)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.txterrorFormato)
        Me.GroupBox3.Location = New System.Drawing.Point(15, 362)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(469, 175)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Directorios"
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(349, 138)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(29, 23)
        Me.Button11.TabIndex = 22
        Me.Button11.Text = "..."
        Me.Button11.UseVisualStyleBackColor = True
        '
        'txtlog
        '
        Me.txtlog.Location = New System.Drawing.Point(96, 140)
        Me.txtlog.Name = "txtlog"
        Me.txtlog.Size = New System.Drawing.Size(242, 20)
        Me.txtlog.TabIndex = 21
        '
        'Log
        '
        Me.Log.AutoSize = True
        Me.Log.Location = New System.Drawing.Point(7, 143)
        Me.Log.Name = "Log"
        Me.Log.Size = New System.Drawing.Size(25, 13)
        Me.Log.TabIndex = 20
        Me.Log.Text = "Log"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(349, 109)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(29, 23)
        Me.Button5.TabIndex = 19
        Me.Button5.Text = "..."
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(349, 80)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(29, 23)
        Me.Button4.TabIndex = 18
        Me.Button4.Text = "..."
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(349, 55)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(29, 23)
        Me.Button3.TabIndex = 17
        Me.Button3.Text = "..."
        Me.Button3.UseVisualStyleBackColor = True
        '
        'txtbtnsel1
        '
        Me.txtbtnsel1.Location = New System.Drawing.Point(349, 22)
        Me.txtbtnsel1.Name = "txtbtnsel1"
        Me.txtbtnsel1.Size = New System.Drawing.Size(29, 23)
        Me.txtbtnsel1.TabIndex = 16
        Me.txtbtnsel1.Text = "..."
        Me.txtbtnsel1.UseVisualStyleBackColor = True
        '
        'txt_desmail
        '
        Me.txt_desmail.Location = New System.Drawing.Point(96, 27)
        Me.txt_desmail.Name = "txt_desmail"
        Me.txt_desmail.Size = New System.Drawing.Size(242, 20)
        Me.txt_desmail.TabIndex = 15
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(7, 30)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(74, 13)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "Descarga mail"
        '
        'TxtProcesados
        '
        Me.TxtProcesados.Location = New System.Drawing.Point(96, 114)
        Me.TxtProcesados.Name = "TxtProcesados"
        Me.TxtProcesados.Size = New System.Drawing.Size(242, 20)
        Me.TxtProcesados.TabIndex = 13
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(7, 114)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 13)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "Procesados"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(7, 86)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 13)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Error RFC"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(7, 60)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(70, 13)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Error Formato"
        '
        'txterrorRFC
        '
        Me.txterrorRFC.Location = New System.Drawing.Point(96, 83)
        Me.txterrorRFC.Name = "txterrorRFC"
        Me.txterrorRFC.Size = New System.Drawing.Size(242, 20)
        Me.txterrorRFC.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 30)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(0, 13)
        Me.Label9.TabIndex = 7
        '
        'txterrorFormato
        '
        Me.txterrorFormato.Location = New System.Drawing.Point(96, 57)
        Me.txterrorFormato.Name = "txterrorFormato"
        Me.txterrorFormato.Size = New System.Drawing.Size(242, 20)
        Me.txterrorFormato.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btn_elimina)
        Me.Panel1.Controls.Add(Me.Button8)
        Me.Panel1.Controls.Add(Me.Button6)
        Me.Panel1.Controls.Add(Me.txt_mail_exito)
        Me.Panel1.Location = New System.Drawing.Point(135, 233)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(264, 150)
        Me.Panel1.TabIndex = 10
        Me.Panel1.Visible = False
        '
        'btn_elimina
        '
        Me.btn_elimina.BackColor = System.Drawing.Color.Red
        Me.btn_elimina.ForeColor = System.Drawing.Color.White
        Me.btn_elimina.Location = New System.Drawing.Point(108, 89)
        Me.btn_elimina.Name = "btn_elimina"
        Me.btn_elimina.Size = New System.Drawing.Size(57, 23)
        Me.btn_elimina.TabIndex = 4
        Me.btn_elimina.Text = "Eliminar"
        Me.btn_elimina.UseVisualStyleBackColor = False
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.Red
        Me.Button8.ForeColor = System.Drawing.Color.White
        Me.Button8.Location = New System.Drawing.Point(171, 89)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(57, 23)
        Me.Button8.TabIndex = 3
        Me.Button8.Text = "Cerrar"
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.Red
        Me.Button6.ForeColor = System.Drawing.Color.White
        Me.Button6.Location = New System.Drawing.Point(47, 89)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(57, 23)
        Me.Button6.TabIndex = 2
        Me.Button6.Text = "Guardar"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'txt_mail_exito
        '
        Me.txt_mail_exito.Location = New System.Drawing.Point(55, 34)
        Me.txt_mail_exito.Name = "txt_mail_exito"
        Me.txt_mail_exito.Size = New System.Drawing.Size(182, 20)
        Me.txt_mail_exito.TabIndex = 1
        '
        'Configuracion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(505, 571)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cbx_ambiente)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btn_guardar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Configuracion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuracion"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbx_ambiente As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_contraseña As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_usuario As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_servidor As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_error As System.Windows.Forms.TextBox
    Friend WithEvents cbx_noti_error As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbx_noti_exi As System.Windows.Forms.CheckBox
    Friend WithEvents txt_sysid As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_sysnumber As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents txtbtnsel1 As System.Windows.Forms.Button
    Friend WithEvents txt_desmail As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtProcesados As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txterrorRFC As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txterrorFormato As System.Windows.Forms.TextBox
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents txt_mail_exito As System.Windows.Forms.TextBox
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents btn_elimina As System.Windows.Forms.Button
    Friend WithEvents lblmensajemail As System.Windows.Forms.Label
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents txtlog As System.Windows.Forms.TextBox
    Friend WithEvents Log As System.Windows.Forms.Label
End Class
