Imports System.Data.SqlClient
Public Class MVSEdit
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
            Fillddl()
            Fillddlp()
            Lock()
            Global_class.User = Trim(dtab.Rows(0).Item("User_ID"))
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
    Private Sub Fillddlp()
        Dim Global_class As Declaraciones = ViewState("Global")
        Dim con As SqlConnection = New SqlConnection(Declaraciones.Coneccion)
        con.Open()
        Dim sql As String = "Select * From [Horses] "
        Dim cd As SqlCommand = New SqlCommand(sql, con)
        Dim sda As SqlDataAdapter = New SqlDataAdapter(cd)
        Dim dset As DataSet = New DataSet()
        dset.Clear()
        sda.Fill(dset)
        ddlhoid.DataSource = dset
        ddlhoid.DataTextField = "Horse_ID"
        ddlhoid.DataValueField = "Horse_ID"
        ddlhoid.DataBind()
        ddlhoid.Items.Insert(0, New ListItem("--Select--", "0"))
        con.Close()
        ViewState("Global") = Global_class
    End Sub
    Private Sub Clear()
        Dim Global_class As Declaraciones = ViewState("Global")
        txtinid.Text = ""
        ddlsupid.SelectedValue = 0
        txtstname.Text = ""
        ddlhoid.SelectedValue = 0
        txthoname.Text = ""
        txtindate.Text = ""
        txtmedto.Text = ""
        txtmatto.Text = ""
        txtservto.Text = ""
        txttax.Text = ""
        txtinto.Text = ""
        ViewState("Global") = Global_class
    End Sub
    Private Sub Lock()
        Dim Global_class As Declaraciones = ViewState("Global")
        txtinid.Enabled = False
        ddlsupid.Enabled = False
        txtstname.Enabled = False
        ddlsupid.Enabled = False
        ddlhoid.Enabled = False
        txthoname.Enabled = False
        txtindate.Enabled = False
        txtmedto.Enabled = False
        txtmatto.Enabled = False
        txtservto.Enabled = False
        txttax.Enabled = False
        txtinto.Enabled = False
        ViewState("Global") = Global_class
    End Sub
    Private Sub unlock()
        Dim Global_class As Declaraciones = ViewState("Global")
        txtinid.Enabled = True
        ddlsupid.Enabled = True
        txtstname.BackColor = Drawing.Color.White
        ddlhoid.Enabled = True
        ddlsupid.Enabled = True
        txthoname.BackColor = Drawing.Color.White
        txtindate.Enabled = True
        txtmedto.Enabled = True
        txtmatto.Enabled = True
        txtservto.Enabled = True
        txttax.Enabled = True
        txtinto.BackColor = Drawing.Color.White
        ViewState("Global") = Global_class
    End Sub
    Private Sub Editpurchases()
        Dim Global_class As Declaraciones = ViewState("Global")
        Dim cnn As SqlConnection
        Dim cmd As SqlCommand
        Try
            Dim sql As String = "UPDATE [dbo].[Invoice]"
            sql &= "Set [Stable_ID] = '" & ddlsupid.Text.Trim & "'"
            sql &= ",[Stable_Name] = '" & txtstname.Text.Trim & "'"
            sql &= ",[Horse_ID] = '" & ddlhoid.Text.Trim & "'"
            sql &= ",[Horse_Name] = '" & txthoname.Text.Trim & "'"
            sql &= ",[Invoice_Date] = '" & txtindate.Text.Trim & "'"
            sql &= ",[Total_Med] = '" & txtmedto.Text.Trim & "'"
            sql &= ",[Total_Mat] = '" & txtmatto.Text.Trim & "'"
            sql &= ",[Total_Serv] = '" & txtservto.Text.Trim & "'"
            sql &= ",[Taxes] = '" & txttax.Text.Trim & "'"
            sql &= ",[Invoice_Total] = '" & txtinto.Text.Trim & "'"
            sql &= ",[stamp_userid] = '" & Global_class.User & "'"
            sql &= " WHERE [Invoice_ID] = '" & txtinid.Text.Trim & "'"
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
        Lock()
        btnMod.Enabled = "True"
        btnSave.Enabled = "False"
        btnCancelar.Enabled = "False"

        txtinid.Text = row.Cells(1).Text
        ddlsupid.Text = row.Cells(2).Text
        txtstname.Text = row.Cells(3).Text
        ddlhoid.Text = row.Cells(4).Text
        txthoname.Text = row.Cells(5).Text
        txtindate.Text = row.Cells(6).Text
        txtmedto.Text = row.Cells(7).Text
        txtmatto.Text = row.Cells(8).Text
        txtservto.Text = row.Cells(9).Text
        txttax.Text = row.Cells(10).Text
        txtinto.Text = row.Cells(11).Text

        Global_class.anadir = False
        ViewState("Global") = Global_class
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Global_class As Declaraciones = ViewState("Global")
        Dim sql As String = ""
        If select1.SelectedItem.Value = "ID" Then
            sql = "SELECT * FROM [dbo].[Invoice] WHERE Purchase_ID = '" & txtSearch.Text.Trim & "'"
        End If

        If select1.SelectedItem.Value = "Su ID" Then
            sql = "SELECT * FROM [dbo].[Invoice] WHERE Supplier_ID='" & txtSearch.Text.Trim & "'"
        End If

        If select1.SelectedItem.Value = "Total" Then
            sql = "SELECT * FROM [dbo].[Invoice] WHERE Purchase_Total ='" & txtSearch.Text.Trim & "'"
        End If
        If select1.SelectedItem.Value = "user" Then
            sql = "SELECT * FROM [dbo].[Invoice] WHERE stamp_userid ='" & txtSearch.Text.Trim & "'"
        End If
        If select1.SelectedItem.Value = "Seleccione una opcion" Then
            sql = "SELECT * FROM [dbo].[Invoice] "
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
        ViewState("Global") = Global_class
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim Global_class As Declaraciones = ViewState("Global")
        Dim result As Boolean = True
        If Global_class.L = True Then
            Global_class.anadir = True
        Else
            Global_class.anadir = False
        End If
        If txtinid.Text = "" Then
            result = False
            txtinid.BackColor = Drawing.Color.Red
        Else
            txtinid.BackColor = Drawing.Color.White
        End If
        If ddlsupid.Text = "--Select--" Then
            result = False
            ddlsupid.BackColor = Drawing.Color.Red
        Else
            ddlsupid.BackColor = Drawing.Color.White
        End If
        If txtstname.Text = "" Then
            result = False
            txtstname.BackColor = Drawing.Color.Red
        Else
            txtstname.BackColor = Drawing.Color.White
        End If

        If ddlhoid.Text = "--Select--" Then
            result = False
            ddlhoid.BackColor = Drawing.Color.Red
        Else
            ddlhoid.BackColor = Drawing.Color.White
        End If
        If txthoname.Text = "" Then
            result = False
            txthoname.BackColor = Drawing.Color.Red
        Else
            txthoname.BackColor = Drawing.Color.White
        End If

        If txtindate.Text = "" Then
            result = False
            txtindate.BackColor = Drawing.Color.Red
        Else
            txtindate.BackColor = Drawing.Color.White
        End If
        If txtmedto.Text = "" Then
            result = False
            txtmedto.BackColor = Drawing.Color.Red
        Else
            txtmedto.BackColor = Drawing.Color.White
        End If
        If txtmatto.Text = "" Then
            result = False
            txtmatto.BackColor = Drawing.Color.Red
        Else
            txtmatto.BackColor = Drawing.Color.White
        End If
        If txtservto.Text = "" Then
            result = False
            txtservto.BackColor = Drawing.Color.Red
        Else
            txtservto.BackColor = Drawing.Color.White
        End If
        If txttax.Text = "" Then
            result = False
            txttax.BackColor = Drawing.Color.Red
        Else
            txttax.BackColor = Drawing.Color.White
        End If
        If txtinto.Text = "" Then
            result = False
            txtinto.BackColor = Drawing.Color.Red
        Else
            txtinto.BackColor = Drawing.Color.White
        End If
        If result = True Then
            Editpurchases()
        End If
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
        txtstname.Text = dt.Rows(0).Item("Supplier_Name")
        ViewState("Global") = Global_class
    End Sub

    Protected Sub ddlhoid_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlhoid.SelectedIndexChanged
        Dim Global_class As Declaraciones = ViewState("Global")
        Dim con As SqlConnection = New SqlConnection(Declaraciones.Coneccion)
        Dim sql As String = "Select * From [Horses] where Horse_ID='" & ddlhoid.Text & "' "
        Dim cm As New SqlCommand(sql, con)
        Dim da As New SqlDataAdapter(cm)
        Dim dt As New DataTable()
        dt.Clear()
        da.Fill(dt)
        dt.Dispose()
        txthoname.Text = dt.Rows(0).Item("Horse_Name")
        ViewState("Global") = Global_class
    End Sub

    Protected Sub txttax_TextChanged(sender As Object, e As EventArgs) Handles txttax.TextChanged
        Dim Global_class As Declaraciones = ViewState("Global")
        Dim temp As Integer
        Dim temp1 As Integer
        Dim temp2 As Integer
        Dim temp3 As Integer
        temp = txtmatto.Text
        temp1 = txtmedto.Text
        temp2 = txtservto.Text
        temp = txttax.Text
        txtinto.Text = temp + temp1 + temp2 + temp3
        ViewState("Global") = Global_class
    End Sub
End Class