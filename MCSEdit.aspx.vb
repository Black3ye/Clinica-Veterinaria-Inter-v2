Imports System.Data.SqlClient
Public Class MCSEdit
    Inherits System.Web.UI.Page
    Dim Global_class As Declaraciones = New Declaraciones
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Global_class.UserID = Request.QueryString.Item("UID")
        Global_class.UserName = Request.QueryString.Item("UN")
        If Global_class.UserName = vbNullString Or Session.IsNewSession = True Or Session.Contents.Count < 1 Then
            Response.Redirect("Login.aspx")
        End If
        If Not IsPostBack Then
            Dim sqla As String = "Select User_ID FROM [dbo].[Users] WHERE username = '" & Global_class.UserID & "'"
            Dim sda1 As SqlDataAdapter = New SqlDataAdapter(sqla, Declaraciones.Coneccion)
            Dim cmb1 As SqlCommandBuilder = New SqlCommandBuilder(sda1)
            Dim dtab As DataTable = New DataTable
            dtab.Locale = System.Globalization.CultureInfo.InvariantCulture
            dtab.Clear()
            sda1.Fill(dtab)
            sda1.Dispose()
            Global_class.User = Trim(dtab.Rows(0).Item("User_ID"))

            Lock()
            Fillddl()
            ViewState("Global") = Global_class
        End If

    End Sub
    Private Sub Fillddl()
        Dim Global_class As Declaraciones = ViewState("Global")
        Dim con As SqlConnection = New SqlConnection(Declaraciones.Coneccion)
        con.Open()
        Dim sql As String = "Select * From [Suppliers] "
        Dim cm As New SqlCommand(sql, con)
        Dim da As New SqlDataAdapter(cm)
        Dim ds As New DataSet()
        da.Fill(ds)
        ddlsupid.DataSource = ds
        ddlsupid.DataTextField = "Supplier_ID"
        ddlsupid.DataValueField = "Supplier_ID"
        ddlsupid.DataBind()
        ddlsupid.Items.Insert(0, New ListItem("--Select--", "0"))
        con.Close()
        ViewState("Global") = Global_class
    End Sub
    Private Sub Clear()
        Dim Global_class As Declaraciones = ViewState("Global")
        txtpuid.Text = ""
        ddlsupid.SelectedValue = 0
        txtsuname.Text = ""
        txtpunum.Text = ""
        txtpudate.Text = ""
        txtputaxes.Text = ""
        txtputotal.Text = ""
        ViewState("Global") = Global_class
    End Sub
    Private Sub Lock()
        Dim Global_class As Declaraciones = ViewState("Global")
        txtpuid.Enabled = False
        ddlsupid.Enabled = False
        txtsuname.Enabled = False
        txtpunum.Enabled = False
        txtpudate.Enabled = False
        txtputaxes.Enabled = False
        txtputotal.Enabled = False
        ViewState("Global") = Global_class
    End Sub
    Private Sub unlock()
        Dim Global_class As Declaraciones = ViewState("Global")
        txtsuname.BackColor = Drawing.Color.White
        txtpuid.Enabled = True
        ddlsupid.Enabled = True
        txtpunum.Enabled = True
        txtpudate.Enabled = True
        txtputaxes.Enabled = True
        txtputotal.Enabled = True
        ViewState("Global") = Global_class
    End Sub
    Private Sub Editpurchases()
        Dim Global_class As Declaraciones = ViewState("Global")
        Dim cnn As SqlConnection
        Dim cmd As SqlCommand
        Try
            Dim sql As String = "UPDATE [dbo].[Purchases]"
            sql &= " SET [Supplier_ID] = '" & ddlsupid.Text.Trim & "'"
            sql &= ",[Supplier_Name] = '" & txtsuname.Text.Trim & "'"
            sql &= ",[Purchase_Number] = '" & txtpunum.Text.Trim & "'"
            sql &= ",[Purchase_Date] = '" & txtpudate.Text.Trim & "'"
            sql &= ",[Purchase_Taxes] = '" & txtputaxes.Text.Trim & "'"
            sql &= ",[Purchase_Total] = '" & txtputotal.Text.Trim & "'"
            sql &= ",[stamp_userid] = '" & Global_class.User & "'"
            sql &= " WHERE [Purchase_ID] = '" & txtpuid.Text.Trim & "'"
            cnn = New SqlConnection(Declaraciones.Coneccion)
            cmd = New SqlCommand(sql, cnn)
            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()
            Clear()
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Se ha actualizando la compra');", True)
        Catch ex As SqlClient.SqlException
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Ocurrio un error actualizando la compra');", True)

        End Try
        ViewState("Global") = Global_class
    End Sub
    Private Sub GVSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVSearch.SelectedIndexChanged
        Dim Global_class As Declaraciones = ViewState("Global")
        Dim row As GridViewRow = GVSearch.SelectedRow
        btnMod.Enabled = True
        btnSave.Enabled = False
        btnCancelar.Enabled = False

        txtpuid.Text = row.Cells(1).Text
        ddlsupid.Text = row.Cells(2).Text
        txtsuname.Text = row.Cells(3).Text
        txtpunum.Text = row.Cells(4).Text
        txtpudate.Text = row.Cells(5).Text
        txtputaxes.Text = row.Cells(6).Text
        txtputotal.Text = row.Cells(7).Text

        Global_class.anadir = False
        ViewState("Global") = Global_class
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Global_class As Declaraciones = ViewState("Global")
        Dim sql As String = ""
        If select1.SelectedItem.Value = "ID" Then
            sql = "Select * FROM [dbo].[Purchases] WHERE Purchase_ID = '" & txtSearch.Text.Trim & "'"
        End If

        If select1.SelectedItem.Value = "Su ID" Then
            sql = "SELECT * FROM [dbo].[Purchases] WHERE Supplier_ID='" & txtSearch.Text.Trim & "'"
        End If

        If select1.SelectedItem.Value = "Total" Then
            sql = "SELECT * FROM [dbo].[Purchases] WHERE Purchase_Total ='" & txtSearch.Text.Trim & "'"
        End If
        If select1.SelectedItem.Value = "user" Then
            sql = "SELECT * FROM [dbo].[Purchases] WHERE stamp_userid ='" & txtSearch.Text.Trim & "'"
        End If
        If select1.SelectedItem.Value = "Seleccione una opcion" Then
            sql = "SELECT * FROM [dbo].[Purchases] "
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
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('No se encontró la compra');", True)
            End If
        Catch ex As SqlClient.SqlException
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Problemas al realizar la busqueda de la Compra');", True)

        End Try
        ViewState("Global") = Global_class
    End Sub

    Private Sub btnMod_Click(sender As Object, e As EventArgs) Handles btnMod.Click
        Dim Global_class As Declaraciones = ViewState("Global")
        btnMod.Enabled = "False"
        btnSave.Enabled = "True"
        btnCancelar.Enabled = "True"
        unlock()
        Global_class.anadir = False
        ViewState("Global") = Global_class
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim Global_class As Declaraciones = ViewState("Global")
        Dim result As Boolean = True

        If txtpuid.Text = "" Then
            result = False
            txtpuid.BackColor = Drawing.Color.Red
        Else
            txtpuid.BackColor = Drawing.Color.White

        End If
        If ddlsupid.Text = "--Select--" Then
            result = False
            ddlsupid.BackColor = Drawing.Color.Red
        Else
            ddlsupid.BackColor = Drawing.Color.White
            result = True
        End If
        If txtsuname.Text = "" Then
            result = False
            txtsuname.BackColor = Drawing.Color.Red
        Else
            txtsuname.BackColor = Drawing.Color.White
            result = True
        End If

        If txtpunum.Text = "" Then
            result = False
            txtpunum.BackColor = Drawing.Color.Red
        Else
            txtpunum.BackColor = Drawing.Color.White
            result = True
        End If
        If txtpudate.Text = "" Then
            result = False
            txtpudate.BackColor = Drawing.Color.Red
        Else
            txtpudate.BackColor = Drawing.Color.White
            result = True
        End If
        If txtputaxes.Text = "" Then
            result = False
            txtputaxes.BackColor = Drawing.Color.Red
        Else
            txtputaxes.BackColor = Drawing.Color.White
            result = True
        End If
        If txtputotal.Text = "" Then
            result = False
            txtputotal.BackColor = Drawing.Color.Red
        Else
            txtputotal.BackColor = Drawing.Color.White
            result = True
        End If
        If result = True Then
            Editpurchases()
        End If
        ViewState("Global") = Global_class
    End Sub
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Dim Global_class As Declaraciones = ViewState("Global")
        Clear()
        Lock()
        btnMod.Enabled = False
        btnSave.Enabled = False
        btnCancelar.Enabled = False
        ViewState("Global") = Global_class
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dim Global_class As Declaraciones = ViewState("Global")
        Response.Redirect("Menu.aspx?UID=" & Global_class.UserID & "&UN=" & Global_class.UserName)
        ViewState("Global") = Global_class
    End Sub

    Protected Sub ddlsupid_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlsupid.SelectedIndexChanged
        Dim Global_class As Declaraciones = ViewState("Global")
        Dim con As SqlConnection = New SqlConnection(Declaraciones.Coneccion)
        Dim sql As String = "Select * From [Suppliers] where Supplier_ID='" & ddlsupid.Text & "' "
        Dim cm As New SqlCommand(sql, con)
        Dim da As New SqlDataAdapter(cm)
        Dim dt As New DataTable()
        dt.Clear()
        da.Fill(dt)
        dt.Dispose()
        txtsuname.Text = dt.Rows(0).Item("Supplier_Name")
        ViewState("Global") = Global_class
    End Sub
End Class