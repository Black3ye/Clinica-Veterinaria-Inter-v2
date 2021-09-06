Imports System.Data.SqlClient
Public Class WebForm2
    Inherits System.Web.UI.Page
    Dim Global_class As Declaraciones = New Declaraciones
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString.Item("UN") = vbNullString Then
            Response.Redirect("Login.aspx")
        End If
        Global_class.UserID = Request.QueryString.Item("UID")           'UserID de Login
        Global_class.UserName = Request.QueryString.Item("UN")
        If Session.IsNewSession = True Then
            Response.Redirect("Login.aspx")
        End If
        If Session.Contents.Count < "1" Then
            Response.Redirect("Login.aspx")
        End If
    End Sub
    Public Sub search()
        Dim sql As String = "SELECT * FROM [dbo].[Users] where ([User_ID] is not null) "
        Dim sqltext As String = ""
        If select1.SelectedItem.Text = "Seleccione una opcion" Then
            sqltext &= "and Active_Flag = '" & scheckbox.Checked & "'"

        End If
        If select1.SelectedItem.Text = "Username" Then
            sqltext &= "and Username = '" & txtSearch.Text.Trim & "'and Active_Flag = '" & scheckbox.Checked & "'"
        End If

        If select1.SelectedItem.Value = "Nombre" Then
            sqltext &= "and UserFName ='" & txtSearch.Text.Trim & "'and Active_Flag = '" & scheckbox.Checked & "'"
        End If

        If select1.SelectedItem.Value = "Apellido Paterno" Then
            sqltext &= "and UserLName1 ='" & txtSearch.Text.Trim & "'and Active_Flag = '" & scheckbox.Checked & "'"
        End If

        If select1.SelectedItem.Value = "I.D. Departamento" Then
            sqltext &= "and Dept_ID ='" & txtSearch.Text.Trim & "'and Active_Flag = '" & scheckbox.Checked & "'"
        End If

        If select1.SelectedItem.Value = "Rol" Then
            sqltext &= "and Role ='" & txtSearch.Text.Trim & "'"
        End If

        sql = sql + sqltext

        Dim cnn As SqlConnection
        Dim cmd As SqlDataAdapter
        Dim table As DataTable
        Try
            ' Assign Connection String
            cnn = New SqlConnection(Declaraciones.Coneccion)

            ' Crear el comando
            cmd = New SqlDataAdapter(sql, cnn)

            'Defino una variable DataTable
            table = New DataTable()

            'Lleno la variable DataTable con los resultados del commando
            cmd.Fill(table)

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
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('No se encontró al Usuario');", True)
            End If
        Catch ex As SqlClient.SqlException
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Problemas al realizar la busqueda de Usuario');", True)

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        search()
    End Sub

    Private Sub GVSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVSearch.SelectedIndexChanged
        Dim srow As GridViewRow = GVSearch.SelectedRow
        Global_class.ID = srow.Cells(7).Text
        If Global_class.ID = vbNullString Then
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Problemas accesando a la cuenta');", True)

        Else
            Response.Redirect("Search.aspx?UID=" & Global_class.UserID & "&UN=" & Global_class.UserName & "&ID=" & Global_class.ID)
        End If

    End Sub



End Class