Imports System.Data.SqlClient
Imports System.Data.Sql
Public Class MT
    Inherits System.Web.UI.Page
    Dim Global_class As Declaraciones = New Declaraciones
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Global_class.UserID = Request.QueryString.Item("UID")
        Global_class.UserName = Request.QueryString.Item("UN")
        If Global_class.UserName = vbNullString Then
            Response.Redirect("Login.aspx")
        End If
        If Session.IsNewSession = True Then
            Response.Redirect("Login.aspx")
        End If
        If Session.Contents.Count < "1" Then
            Response.Redirect("Login.aspx")
        End If
        Nameuser.Text = Global_class.UserName
        Dim sqla As String = "Select User_ID FROM [dbo].[Users] WHERE username = '" & Global_class.UserID & "'"
        Dim sda1 As SqlDataAdapter = New SqlDataAdapter(sqla, Declaraciones.Coneccion)
        Dim cmb1 As SqlCommandBuilder = New SqlCommandBuilder(sda1)
        Dim dtab As DataTable = New DataTable
        dtab.Locale = System.Globalization.CultureInfo.InvariantCulture
        dtab.Clear()
        sda1.Fill(dtab)
        sda1.Dispose()
        Global_class.User = Trim(dtab.Rows(0).Item("User_ID"))
        If btnAdd.Enabled = True Then
            Global_class.anadir = True
        Else
            Global_class.anadir = False
        End If

    End Sub
    Private Sub Evaluate()
        Dim sql As String = "Select [role] as role from [dbo].[Users] where username='" & Trim(Global_class.UserID) & "'"
        Dim sda As SqlDataAdapter = New SqlDataAdapter(sql, Declaraciones.Coneccion)
        Dim dt As DataTable = New DataTable
        Dim commandBuilder As New SqlClient.SqlCommandBuilder(sda)
        dt.Locale = System.Globalization.CultureInfo.InvariantCulture
        dt.Clear()
        sda.Fill(dt)
        sda.Dispose()
        Global_class.role = Trim(dt.Rows(0).Item("role"))
    End Sub
    Private Sub option_Click(sender As Object, e As EventArgs) Handles [option].Click
        If Report.Visible = False Then
            Report.Visible = True
        Else
            Report.Visible = False
        End If

    End Sub

    Private Sub Report_Click(sender As Object, e As EventArgs) Handles Report.Click

        Evaluate()
        If Global_class.role = "Administrator" Then
            Dim s As String = "window.open('Reportes/ReportType.aspx?UID=" & Global_class.UserID & "&UN=" & Global_class.UserName & "&NI=" & Global_class.ID & " ', '_blank');"
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "alertscript", s, True)
        Else
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Usted no es Administrador');", True)
        End If
    End Sub
    Private Sub btnback_Click(sender As Object, e As EventArgs) Handles btnback.Click
        Response.Redirect("Menu.aspx?UID=" & Global_class.UserID & "&UN=" & Global_class.UserName)
    End Sub
    Private Sub btnlo_Click(sender As Object, e As EventArgs) Handles btnlo.Click
        Session.Contents.Clear()
        Session.RemoveAll()
        Session.Abandon()
        Response.Buffer = True
        Response.ExpiresAbsolute = DateTime.Now
        Response.Expires = -1500
        Response.CacheControl = "no-cache"
        Response.Redirect("MT.aspx?UID=" & Global_class.UserID & "&UN=" & Global_class.UserName)
        Response.Redirect("Menu.aspx?UID=" & Global_class.UserID & "&UN=" & Global_class.UserName)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql As String = ""
        If select1.SelectedItem.Value = "Type ID" Then
            sql = "SELECT * FROM [dbo].[Types] WHERE Product_Type_ID = '" & txtSearch.Text.Trim & "'"
        End If

        If select1.SelectedItem.Value = "Type Name" Then
            sql = "SELECT * FROM [dbo].[Types] WHERE Product_Type_Name ='" & txtSearch.Text.Trim & "'"
        End If

        If select1.SelectedItem.Value = "stamp userid" Then
            sql = "SELECT * FROM [dbo].[Types] WHERE stamp_userid ='" & txtSearch.Text.Trim & "'"
        End If

        If select1.SelectedItem.Value = "Seleccione una opcion" Then
            sql = "SELECT * FROM [dbo].[Types] "
        End If

        Dim cnn As SqlConnection = New SqlConnection(Declaraciones.Coneccion)
        Dim cmd As SqlDataAdapter = New SqlDataAdapter(sql, cnn)
        Dim cmb As SqlCommandBuilder = New SqlCommandBuilder(cmd)
        Dim table As DataTable = New DataTable()
        table.Locale = System.Globalization.CultureInfo.InvariantCulture
        table.Clear()
        cmd.Fill(table)
        cmd.Dispose()
        Try
            'Si la tabla tiene valores
            If table.Rows.Count > 0 Then

                'Asigno los valores de la Tabla resultandte al Grid View
                GVSearch.DataSource = table
                GVSearch.DataBind()
                lbTotal.Text = table.Rows.Count



            Else
                'Vacio el Grid View
                GVSearch.DataSource = Nothing
                GVSearch.DataBind()
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('No se encontró el Tipo de Inventario');", True)
            End If
        Catch ex As SqlClient.SqlException
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Problemas al realizar la busqueda de el Tipo de Inventario');", True)

        End Try
    End Sub

    Private Sub GVSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVSearch.SelectedIndexChanged
        Dim row As GridViewRow = GVSearch.SelectedRow

        If row.Cells(1).Text.Trim <> "" Then
            TextBox1.Text = row.Cells(1).Text
            TextBox2.Text = row.Cells(2).Text
            btnAdd.Enabled = False
            btnMod.Enabled = True
            btnSave.Enabled = False
            btnCancelar.Enabled = False
        End If
    End Sub
    Private Sub Clear()
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub
    Private Sub Lock()
        TextBox1.Enabled = "False"
        TextBox2.Enabled = "False"
    End Sub
    Private Sub Addtype()
        Dim cnn As SqlConnection = New SqlConnection(Declaraciones.Coneccion)
        Dim cmd As SqlCommand
        Try
            Dim sql As String = "INSERT INTO [dbo].[Types]("
            sql &= "[Product_Type_ID]"
            sql &= ",[Product_Type_Name]"
            sql &= ",[Stamp_added]"
            sql &= ",[stamp_userid]) VALUES ( '" & TextBox1.Text.Trim & "'"
            sql &= ", '" & TextBox2.Text.Trim & "'"
            sql &= ", '" & Now & "'"
            sql &= ", '" & Global_class.User & "')"

            cmd = New SqlCommand(sql, cnn)
            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('El Tipo de Producto ha sido guardado ');", True)
            Lock()
            Clear()

        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Ocurrio un error guardando el tipo de producto');", True)

        End Try
    End Sub
    Private Sub Modtype()
        Dim cnn As SqlConnection
        Dim cmd As SqlCommand
        Try
            Dim sql As String = "UPDATE [dbo].[Types]"
            sql &= " SET [Product_Type_Name] = '" & TextBox2.Text.Trim & "'"
            sql &= ",[stamp_userid] = '" & Global_class.User & "'"
            sql &= " WHERE [Product_Type_ID] = '" & TextBox1.Text.Trim & "'"
            cnn = New SqlConnection(Declaraciones.Coneccion)
            cmd = New SqlCommand(sql, cnn)
            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()
            Lock()
            Clear()
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('La información del tipo de producto ha sido actualizado ');", True)

        Catch ex As SqlClient.SqlException
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Ocurrio un error actualizando el tipo de producto');", True)

        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Global_class.anadir = True
        btnMod.Enabled = False
        btnSave.Enabled = True
        btnCancelar.Enabled = True
        btnReload.Enabled = False
        TextBox1.Enabled = True
        TextBox2.Enabled = True
    End Sub

    Private Sub btnMod_Click(sender As Object, e As EventArgs) Handles btnMod.Click
        Global_class.anadir = False
        btnAdd.Enabled = False
        btnMod.Enabled = False
        btnSave.Enabled = True
        btnCancelar.Enabled = True
        btnReload.Enabled = False
        TextBox1.Enabled = False
        TextBox2.Enabled = True
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim result As Boolean = True

        If Global_class.anadir = False Or Global_class.anadir = True Then
            If TextBox1.Text = vbNullString Then
                result = False
                TextBox1.BackColor = Drawing.Color.Red
            Else
                TextBox1.BackColor = Drawing.Color.White
            End If
            If TextBox2.Text = vbNullString Then
                result = False
                TextBox2.BackColor = Drawing.Color.Red
            Else
                TextBox2.BackColor = Drawing.Color.White
            End If
        End If
        'Anadir
        If result = True And Global_class.anadir = True Then
            Addtype()
        End If
        'Modicar
        If result = True And Global_class.anadir = False Then
            Modtype()
        End If
        Response.Redirect("MT.aspx?UID=" & Global_class.UserID & "&UN=" & Global_class.UserName)

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Clear()
        Lock()
        btnAdd.Enabled = True
        btnMod.Enabled = False
        btnSave.Enabled = False
        btnCancelar.Enabled = False
        btnReload.Enabled = True
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Clear()
        Lock()
        Response.Redirect("Menu.aspx?UID=" & Global_class.UserID & "&UN=" & Global_class.UserName)
    End Sub

    Private Sub btnReload_Click(sender As Object, e As EventArgs) Handles btnReload.Click
        Response.Redirect("MT.aspx?UID=" & Global_class.UserID & "&UN=" & Global_class.UserName)
    End Sub

End Class