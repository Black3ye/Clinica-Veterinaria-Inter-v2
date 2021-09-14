Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Web
Public Class Menu
    Inherits System.Web.UI.Page
    Dim Global_class As Declaraciones = New Declaraciones
    Dim dt As DataTable = New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Global_class.UserID = Request.QueryString.Item("UID")
        Global_class.UserName = Request.QueryString.Item("UN")
        Nameuser.Text = Global_class.UserName
        If Session.IsNewSession = True Then
            Response.Redirect("Login.aspx")
        End If
        If Session.Contents.Count < "1" Then
            Response.Redirect("Login.aspx")
        End If
        If Global_class.UserName = vbNullString Then
            Response.Redirect("Login.aspx")
        End If

    End Sub
    Public Sub validation()
        Dim sql As String = "Select [role] as role from [dbo].[Users] where username='" & Trim(Global_class.UserID) & "'"
        Dim sda As SqlDataAdapter = New SqlDataAdapter(sql, Declaraciones.Coneccion)
        Dim commandBuilder As New SqlClient.SqlCommandBuilder(sda)
        dt.Locale = System.Globalization.CultureInfo.InvariantCulture
        dt.Clear()
        sda.Fill(dt)
        sda.Dispose()
        Global_class.role = Trim(dt.Rows(0).Item("role"))

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Session.Contents.Clear()
        Session.RemoveAll()
        Session.Abandon()
        Response.Buffer = True
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1D)
        Response.Expires = -1500
        Response.CacheControl = "no-cache"
        Response.Redirect("Menu.aspx?UID=" & Global_class.UserID & "&UN=" & Global_class.UserName)

    End Sub

    Private Sub MU_Click(sender As Object, e As EventArgs) Handles MU.Click
        validation()
        If Global_class.role = "Administrator" Then
            FormsAuthentication.SetAuthCookie(Global_class.UserName, False)
            FormsAuthentication.RedirectFromLoginPage(Global_class.UserName, False)
            Response.Redirect("Search.aspx?UID=" & Global_class.UserID & "&UN=" & Global_class.UserName)
        Else
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Usted no es Administrador');", True)
        End If
    End Sub


    Private Sub MT_Click(sender As Object, e As EventArgs) Handles MT.Click
        validation()
        If Global_class.role = "Administrator" Then
            FormsAuthentication.SetAuthCookie(Global_class.UserName, False)
            FormsAuthentication.RedirectFromLoginPage(Global_class.UserName, False)
            Response.Redirect("MT.aspx?UID=" & Global_class.UserID & "&UN=" & Global_class.UserName)
        Else
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Usted no es Administrador');", True)
        End If

    End Sub

    Private Sub MI_Click(sender As Object, e As EventArgs) Handles MI.Click
        Response.Redirect("MI.aspx?UID=" & Global_class.UserID & "&UN=" & Global_class.UserName)
    End Sub

    Private Sub MC_Click(sender As Object, e As EventArgs) Handles MC.Click
        validation()
        If Global_class.role = "Administrator" Then
            FormsAuthentication.SetAuthCookie(Global_class.UserName, False)
            FormsAuthentication.RedirectFromLoginPage(Global_class.UserName, False)
            Response.Redirect("MCadd.aspx?UID=" & Global_class.UserID & "&UN=" & Global_class.UserName)
        Else
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Usted no es Administrador');", True)
        End If
    End Sub

    Private Sub MV_Click(sender As Object, e As EventArgs) Handles MV.Click
        Response.Redirect("MVadd.aspx?UID=" & Global_class.UserID & "&UN=" & Global_class.UserName)
    End Sub
End Class