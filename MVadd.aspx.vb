Imports System.Data.SqlClient
Public Class MVadd
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
            Fillddli()
            txtstname.BackColor = Drawing.Color.White
            txthoname.BackColor = Drawing.Color.White
            txtinto.BackColor = Drawing.Color.White
            Global_class.User = Trim(dtab.Rows(0).Item("User_ID"))
            ViewState("Global") = Global_class
        End If


    End Sub
    Private Sub Fillddl()
        Dim Global_class As Declaraciones = ViewState("Global")
        Dim con As SqlConnection = New SqlConnection(Declaraciones.Coneccion)
        con.Open()
        Dim sql As String = "Select * From [Stables] "
        Dim cm As New SqlCommand(sql, con)
        Dim da As New SqlDataAdapter(cm)
        Dim ds As New DataSet()
        da.Fill(ds)
        ddlstid.DataSource = ds
        ddlstid.DataTextField = "Stable_ID"
        ddlstid.DataValueField = "Stable_ID"
        ddlstid.DataBind()
        ddlstid.Items.Insert(0, New ListItem("--Select--", "0"))
        con.Close()
        ViewState("Global") = Global_class
    End Sub
    Private Sub Fillddli()
        Dim Global_class As Declaraciones = ViewState("Global")
        Dim con As SqlConnection = New SqlConnection(Declaraciones.Coneccion)
        con.Open()
        Dim sql As String = "Select * From [Horses]"
        Dim cd As New SqlCommand(sql, con)
        Dim sda As New SqlDataAdapter(cd)
        Dim dset As New DataSet()
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
    Private Sub Addpurchases()
        Dim Global_class As Declaraciones = ViewState("Global")
        Dim scn As SqlConnection = New SqlConnection(Declaraciones.Coneccion)
        Dim cmd As SqlCommand
        Try
            Dim sql As String = "INSERT INTO [dbo].[Invoice]("
            sql &= "[Invoice_ID]"
            sql &= ",[Stable_ID]"
            sql &= ",[Stable_Name]"
            sql &= ",[Horse_ID]"
            sql &= ",[Horse_Name]"
            sql &= ",[Invoice_Date]"
            sql &= ",[Total_Med]"
            sql &= ",[Total_Mat]"
            sql &= ",[Total_Serv]"
            sql &= ",[Taxes]"
            sql &= ",[Invoice_Total]"
            sql &= ",[stamp_added]"
            sql &= ",[stamp_userid]) VALUES ( '" & txtinid.Text.Trim & "'"
            sql &= ", '" & ddlstid.Text.Trim & "'"
            sql &= ", '" & txtstname.Text.Trim & "'"
            sql &= ", '" & ddlhoid.Text.Trim & "'"
            sql &= ", '" & txthoname.Text.Trim & "'"
            sql &= ", '" & txtindate.Text.Trim & "'"
            sql &= ", '" & txtmedto.Text.Trim & "'"
            sql &= ", '" & txtmatto.Text.Trim & "'"
            sql &= ", '" & txtservto.Text.Trim & "'"
            sql &= ", '" & txttax.Text.Trim & "'"
            sql &= ", '" & txtinto.Text.Trim & "'"
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
        txtinid.Text = ""
        ddlstid.SelectedValue = 0
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
    Private Sub Save_Click(sender As Object, e As EventArgs) Handles Save.Click
        Dim Global_class As Declaraciones = ViewState("Global")
        Dim result As Boolean
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
            result = True
        End If
        If ddlstid.Text = "" Then
            result = False
            ddlstid.BackColor = Drawing.Color.Red
        Else
            ddlstid.BackColor = Drawing.Color.White
            result = True
        End If
        If txtstname.Text = "" Then
            result = False
            txtstname.BackColor = Drawing.Color.Red
        Else
            txtstname.BackColor = Drawing.Color.White
            result = True
        End If

        If ddlhoid.Text = "" Then
            result = False
            ddlhoid.BackColor = Drawing.Color.Red
        Else
            ddlhoid.BackColor = Drawing.Color.White
            result = True
        End If
        If txthoname.Text = "" Then
            result = False
            txthoname.BackColor = Drawing.Color.Red
        Else
            txthoname.BackColor = Drawing.Color.White
            result = True
        End If

        If txtindate.Text = "" Then
            result = False
            txtindate.BackColor = Drawing.Color.Red
        Else
            txtindate.BackColor = Drawing.Color.White
            result = True
        End If
        If txtmedto.Text = "" Then
            result = False
            txtmedto.BackColor = Drawing.Color.Red
        Else
            txtmedto.BackColor = Drawing.Color.White
            result = True
        End If
        If txtmatto.Text = "" Then
            result = False
            txtmatto.BackColor = Drawing.Color.Red
        Else
            txtmatto.BackColor = Drawing.Color.White
            result = True
        End If
        If txtservto.Text = "" Then
            result = False
            txtservto.BackColor = Drawing.Color.Red
        Else
            txtservto.BackColor = Drawing.Color.White
            result = True
        End If
        If txttax.Text = "" Then
            result = False
            txttax.BackColor = Drawing.Color.Red
        Else
            txttax.BackColor = Drawing.Color.White
            result = True
        End If
        If txtinto.Text = "" Then
            result = False
            txtinto.BackColor = Drawing.Color.Red
        Else
            txtinto.BackColor = Drawing.Color.White
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

    Protected Sub ddlstid_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlstid.SelectedIndexChanged
        Dim Global_class As Declaraciones = ViewState("Global")
        Dim con As SqlConnection = New SqlConnection(Declaraciones.Coneccion)
        Dim sql As String = "Select * From [Stables] where Stable_ID='" & ddlstid.Text & "'"
        Dim cm As New SqlCommand(sql, con)
        Dim da As New SqlDataAdapter(cm)
        Dim dt As New DataTable()
        dt.Clear()
        da.Fill(dt)
        dt.Dispose()
        txtstname.Text = dt.Rows(0).Item("Stable_Name")
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
        temp3 = txttax.Text
        temp = temp + temp1
        txtinto.Text = (temp + (temp2 + temp3))
        ViewState("Global") = Global_class
    End Sub
End Class