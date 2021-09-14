Imports System.Data.SqlClient
Public Class WebForm3
    Inherits System.Web.UI.Page
    Dim Global_class As Declaraciones = New Declaraciones
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Global_class.UserID = Request.QueryString.Item("UID")
        Global_class.UserName = Request.QueryString.Item("UN")
        Global_class.ID = Request.QueryString.Item("NI")
        Dim sql1 As String = "Select User_ID FROM [dbo].[Users] WHERE username = '" & Global_class.UserID & "'"
        Dim sda1 As SqlDataAdapter = New SqlDataAdapter(sql1, Declaraciones.Coneccion)
        Dim cmb As SqlCommandBuilder = New SqlCommandBuilder(sda1)
        Dim dta As DataTable = New DataTable
        dta.Locale = System.Globalization.CultureInfo.InvariantCulture
        dta.Clear()
        sda1.Fill(dta)
        sda1.Dispose()
        Global_class.UserID = Trim(dta.Rows(0).Item("User_ID"))
        If (Request.QueryString.Item("UN") = vbNullString) Then
            Response.Redirect("Login.aspx")
        End If
        If Session.IsNewSession = True Then
            Response.Redirect("Login.aspx")
        End If
        If Session.IsNewSession = True Then
            Response.Redirect("Login.aspx")
        End If
        If Session.Contents.Count < "1" Then
            Response.Redirect("Login.aspx")
        End If

        If (Global_class.ID = vbNullString) Then
            If btnAdd.Enabled = False Then
                btnMod.Enabled = False
                btnSave.Enabled = True
                btnCancelar.Enabled = True
                btnSalir.Enabled = True
                Global_class.anadir = True
            End If
        Else
            Dim dt As DataTable = New DataTable
            Dim sql As String = "Select * from [dbo].[Users] where UserName = '" & Global_class.ID & "'"
            Dim sda As SqlDataAdapter = New SqlDataAdapter(sql, Declaraciones.Coneccion)
            Dim con As SqlCommandBuilder = New SqlCommandBuilder(sda)
            dt.Locale = System.Globalization.CultureInfo.InvariantCulture
            dt.Clear()
            sda.Fill(dt)
            sda.Dispose()
            If dt.Rows.Count < "1" Then
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Error no se encontro usuario');", True)
            Else
                If btnMod.Enabled = True Then
                    '***********************************
                    btnSave.Enabled = False
                    btnAdd.Enabled = False
                    btnCancelar.Enabled = True
                    btnSalir.Enabled = True
                    '***********************************
                    ddlDept_ID.Text = dt.Rows(0).Item("Dept_ID")
                    ddlRole.Text = dt.Rows(0).Item("Role")
                    ddlSpecialization.Text = dt.Rows(0).Item("Specialization")
                    txtUser_ID.Text = dt.Rows(0).Item("User_ID")
                    txtUserFName.Text = dt.Rows(0).Item("UserFName")
                    txtUserLName1.Text = dt.Rows(0).Item("UserLName1")
                    txtUserLname2.Text = dt.Rows(0).Item("UserLName2")
                    txtUserMName.Text = dt.Rows(0).Item("UserMName")
                    txtusername.Text = dt.Rows(0).Item("username")
                    txtpassword.Text = dt.Rows(0).Item("password")
                    ckbActive_Flag.Checked = dt.Rows(0).Item("Active_Flag")
                End If

            End If
        End If

    End Sub

    Private Sub Clear()
        ddlDept_ID.Text = "1"
        ddlRole.Text = "Regular"
        ddlSpecialization.Text = "test11"
        txtUser_ID.Text = " "
        txtUserFName.Text = " "
        txtUserLName1.Text = " "
        txtUserLname2.Text = " "
        txtUserMName.Text = " "
        txtusername.Text = " "
        txtpassword.Text = " "
        ckbActive_Flag.Checked = False
    End Sub
    Private Sub Lock()
        txtUser_ID.Enabled = False
        txtUserFName.Enabled = False
        txtUserLName1.Enabled = False
        txtUserLname2.Enabled = False
        txtUserMName.Enabled = False
        txtusername.Enabled = False
        txtpassword.Enabled = False
        ckbActive_Flag.Enabled = False
        ddlDept_ID.Enabled = False
        ddlRole.Enabled = False
        ddlSpecialization.Enabled = False
    End Sub
    Private Sub AddUser()
        Dim cnn As SqlConnection
        Dim cmd As SqlCommand
        Try
            Dim sql As String = "INSERT INTO [dbo].[Users]("
            sql &= "[Dept_ID]"
            sql &= ",[UserFName]"
            sql &= ",[UserMName]"
            sql &= ",[UserLName1]"
            sql &= ",[UserLName2]"
            sql &= ",[username]"
            sql &= ",[password]"
            sql &= ",[Role]"
            sql &= ",[Specialization]"
            sql &= ",[Active_Flag]"
            sql &= ",[Stamp_added]"
            sql &= ",[stamp_userid]) VALUES ( '" & ddlDept_ID.SelectedItem.Text.Trim & "'"
            sql &= ", '" & txtUserFName.Text.Trim & "'"
            sql &= ", '" & txtUserMName.Text.Trim & "'"
            sql &= ", '" & txtUserLName1.Text.Trim & "'"
            sql &= ", '" & txtUserLname2.Text.Trim & "'"
            sql &= ", '" & txtusername.Text.Trim & "'"
            sql &= ", '" & txtpassword.Text.Trim & "'"
            sql &= ", '" & ddlRole.SelectedItem.Text.Trim & "'"
            sql &= ", '" & ddlSpecialization.SelectedItem.Text.Trim & "'"
            sql &= ", '" & ckbActive_Flag.Checked & "'"
            sql &= ", '" & Now & "'"
            sql &= ", '" & Global_class.UserID & "')"

            cnn = New SqlConnection(Declaraciones.Coneccion)
            cmd = New SqlCommand(sql, cnn)
            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('La información del Usuario ha sido guardado ');", True)
            Lock()
            Clear()

        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Ocurrio un error guardando la información del Usuario');", True)

        End Try
    End Sub
    Private Sub updateUser()
        Dim cnn As SqlConnection
        Dim cmd As SqlCommand
        Try
            Dim sql As String = "UPDATE [dbo].[Users]"
            sql &= " SET [Dept_ID] = '" & ddlDept_ID.SelectedItem.Text.Trim & "'"
            sql &= ",[UserFName] = '" & txtUserFName.Text.Trim & "'"
            sql &= ",[UserMName] = '" & txtUserMName.Text.Trim & "'"
            sql &= ",[UserLName1] = '" & txtUserLName1.Text.Trim & "'"
            sql &= ",[UserLName2] = '" & txtUserLname2.Text.Trim & "'"
            sql &= ",[username] = '" & txtusername.Text.Trim & "'"
            sql &= ",[password] = '" & txtpassword.Text.Trim & "'"
            sql &= ",[Role] = '" & ddlRole.SelectedItem.Text.Trim & "'"
            sql &= ",[Specialization] = '" & ddlSpecialization.SelectedItem.Text.Trim & "'"
            sql &= ",[Active_Flag] = '" & ckbActive_Flag.Checked & "'"
            sql &= ",[stamp_userid] = '" & Global_class.UserID & "'"
            sql &= " WHERE [User_ID] = '" & txtUser_ID.Text.Trim & "'"

            cnn = New SqlConnection(Declaraciones.Coneccion)
            ' Crear el comando
            cmd = New SqlCommand(sql, cnn)
            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('La información del Usuario ha sido actualizado ');", True)

        Catch ex As SqlClient.SqlException
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Ocurrio un error actualizando la información del Usuario ');", True)

        End Try
    End Sub
    Private Sub btnMod_Click(sender As Object, e As EventArgs) Handles btnMod.Click
        '*********************************
        btnMod.Enabled = False
        btnCancelar.Enabled = True
        btnSave.Enabled = True
        btnSalir.Enabled = True
        btnAdd.Enabled = False
        '*********************************
        txtUser_ID.Enabled = False
        txtUserFName.Enabled = True
        txtUserLName1.Enabled = True
        txtUserLname2.Enabled = True
        txtUserMName.Enabled = True
        txtusername.Enabled = True
        txtpassword.Enabled = True
        ckbActive_Flag.Enabled = True
        ddlDept_ID.Enabled = True
        ddlRole.Enabled = True
        ddlSpecialization.Enabled = True
        '*********************************
        Global_class.anadir = False


    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        'Este codigo es para validar si se ha entrado data en los campos
        Dim result As Boolean = True

        If Global_class.anadir = False Then
            If txtUser_ID.Text = "" Then
                result = False
                txtUser_ID.BackColor = Drawing.Color.Red
            Else
                txtUser_ID.BackColor = Drawing.Color.White
            End If
            If txtUserFName.Text = "" Then
                result = False
                txtUserFName.BackColor = Drawing.Color.Red
            Else
                txtUserFName.BackColor = Drawing.Color.White
            End If
            If txtUserLName1.Text = "" Then
                result = False
                txtUserLName1.BackColor = Drawing.Color.Red
            Else
                txtUserLName1.BackColor = Drawing.Color.White
            End If

            If txtusername.Text = "" Then
                result = False
                txtusername.BackColor = Drawing.Color.Red
            Else
                txtusername.BackColor = Drawing.Color.White
            End If
            If txtpassword.Text = "" Then
                result = False
                txtpassword.BackColor = Drawing.Color.Red
            Else
                txtpassword.BackColor = Drawing.Color.White
            End If
            If ddlRole.Text = "" Then
                result = False
                ddlRole.BackColor = Drawing.Color.Red
            Else
                ddlRole.BackColor = Drawing.Color.White
            End If
            If ddlSpecialization.Text = "" Then
                result = False
                ddlSpecialization.BackColor = Drawing.Color.Red
            Else
                ddlSpecialization.BackColor = Drawing.Color.White
            End If

        End If

        ' Si lleno todos los campos y esta añadiendo
        If result = True And Global_class.anadir = True Then
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Añadir');", True)
            AddUser()
            Clear()
        End If

        'Si lleno todos los campos y esta modificando
        If result = True And Global_class.anadir = False Then
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Actualizar');", True)
            updateUser()
            Clear()
        End If
        If result = False Then
            btnSave.Enabled = True
            btnCancelar.Enabled = True
            btnAdd.Enabled = False
            btnMod.Enabled = False
        End If

        btnAdd.Enabled = True
        btnMod.Enabled = False
        btnSave.Enabled = False
        btnCancelar.Enabled = False
        Response.Redirect("Search.aspx?UID=" & Global_class.UserID & "&UN=" & Global_class.UserName & "&NI=" & Global_class.ID & " ")
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'Habilitar y deshabilitar botones
        btnAdd.Enabled = False
        btnMod.Enabled = False
        btnSave.Enabled = True
        btnCancelar.Enabled = True
        btnSalir.Enabled = True
        'Habilitar y deshabilitar textbox, DropdownList y checkbox
        txtUser_ID.Enabled = True
        txtUserFName.Enabled = True
        txtUserLName1.Enabled = True
        txtUserLname2.Enabled = True
        txtUserMName.Enabled = True
        txtusername.Enabled = True
        txtpassword.Enabled = True
        ckbActive_Flag.Enabled = True
        ddlDept_ID.Enabled = True
        ddlRole.Enabled = True
        ddlSpecialization.Enabled = True
        Global_class.anadir = True
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        'Borrar contenido en los dropdownlist y Textbox
        Clear()
        Lock()
        'Habilitar y deshabilitar botones
        btnAdd.Enabled = True
        btnMod.Enabled = False
        btnSave.Enabled = False
        btnCancelar.Enabled = False
        btnSalir.Enabled = True
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Clear()
        Lock()
        Response.Redirect("Menu.aspx?UID=" & Global_class.UserID & "&UN=" & Global_class.UserName)

    End Sub

    Private Sub btnReload_Click(sender As Object, e As EventArgs) Handles btnReload.Click
        Response.Redirect("Edit.aspx?UID=" & Global_class.UserID & "&UN=" & Global_class.UserName & "&NI=" & Global_class.ID & " ")
    End Sub
End Class