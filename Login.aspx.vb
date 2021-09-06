Imports System.Data.SqlClient
Imports System.Data
Imports System.Text
Imports System.Web
Imports System.Web.UI
Imports System.Configuration
Imports System.Collections.Generic
Imports System.Web.UI.UserControl

Public Class Login
    Inherits System.Web.UI.Page
    Dim logclass As Declaraciones = New Declaraciones
    Dim dt As DataTable = New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1))
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Cache.SetNoStore()

    End Sub

    'Funcion del Boton del Login al hacer click
    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Valores ingresados atraves del login
        Dim username As String = txtusername.Text
        Dim password As String = txtPassword1.Text
        If (Trim(username) <> "" And Trim(password) <> "") Then
            Dim sql As String = ("Select [username],[UserFName] + ' ' + [UserMName]  + ' ' +  [UserLName1]  + ' ' +  [UserLName2] as name, [Active_Flag] from [dbo].[Users]" _
            & " where Active_Flag = 1 and username = '" & Trim(username) & "' AND password ='" & Trim(password) & "' ")
            Dim sda As SqlDataAdapter = New SqlDataAdapter(sql, Declaraciones.Coneccion)
            Dim commandBuilder As New SqlClient.SqlCommandBuilder(sda)
            dt.Locale = System.Globalization.CultureInfo.InvariantCulture
            dt.Clear()
            sda.Fill(dt)
            sda.Dispose()
            Try
                If dt.Rows.Count < "1" Then
                    ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Incorrect Username or Password')", True)
                    txtusername.Text = ""
                    txtPassword1.Text = ""


                Else
                    Session.Add("username", username)
                    'variable globales para el programa
                    logclass.UserName = Trim(dt.Rows(0).Item("name"))
                    logclass.UserID = Trim(dt.Rows(0).Item("Username")) & ""
                    FormsAuthentication.SetAuthCookie(logclass.UserName, False)
                    FormsAuthentication.RedirectFromLoginPage(logclass.UserName, False)

                    Response.Redirect("Menu.aspx?UID=" & logclass.UserID & "&UN=" & logclass.UserName)

                End If
            Catch ex As SqlClient.SqlException
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Problemas Accesando la Informacion de Usuario');", True)
            End Try
        Else
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Usted no puede dejar en blanco el username o password');", True)
        End If

    End Sub

    'Funcion del Boton de cancel para que redirija a Google
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("https://www.google.com/?gws_rd=ssl")
    End Sub

End Class