Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class MCadd
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
            txtsuname.BackColor = Drawing.Color.White
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
    Private Sub Addpurchases()
        Dim Global_class As Declaraciones = ViewState("Global")
        Dim scn As SqlConnection = New SqlConnection(Declaraciones.Coneccion)
        Dim cmd As SqlCommand
        Try
            Dim sql As String = "INSERT INTO [dbo].[Purchases]("
            sql &= "[Purchase_ID]"
            sql &= ",[Supplier_ID]"
            sql &= ",[Supplier_Name]"
            sql &= ",[Purchase_Number]"
            sql &= ",[Purchase_Date]"
            sql &= ",[Purchase_Taxes]"
            sql &= ",[Purchase_Total]"
            sql &= ",[stamp_added]"
            sql &= ",[stamp_userid]) VALUES ( '" & txtpuid.Text.Trim & "'"
            sql &= ", '" & ddlsupid.Text.Trim & "'"
            sql &= ", '" & txtsuname.Text.Trim & "'"
            sql &= ", '" & txtpunum.Text.Trim & "'"
            sql &= ", '" & txtpudate.Text.Trim & "'"
            sql &= ", '" & txtputaxes.Text.Trim & "'"
            sql &= ", '" & txtputotal.Text.Trim & "'"
            sql &= ", '" & Now & "'"
            sql &= ", '" & Global_class.User & "')"

            cmd = New SqlCommand(sql, scn)
            scn.Open()
            cmd.ExecuteNonQuery()
            scn.Close()
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Se ha añadido la compra');", True)

        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Ocurrio un error guardando la compra');", True)

        End Try
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
    Private Sub Save_Click(sender As Object, e As EventArgs) Handles Save.Click
        Dim Global_class As Declaraciones = ViewState("Global")
        Dim result As Boolean
        If Global_class.L = True Then
            Global_class.anadir = True
        Else
            Global_class.anadir = False
        End If
        If txtpuid.Text = "" Then
            result = False
            txtpuid.BackColor = Drawing.Color.Red
        Else
            txtpuid.BackColor = Drawing.Color.White
            result = True
        End If
        If ddlsupid.SelectedValue = "0" Then
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
            Addpurchases()
            Clear()
        End If
        ViewState("Global") = Global_class
    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Dim Global_class As Declaraciones = ViewState("Global")
        Clear()
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