Imports System.Data.SqlClient
Public Class MVDV
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
            Fillddli()
            ViewState("Global") = Global_class

        End If
    End Sub
    Private Sub Fillddl()
        Dim Global_class As Declaraciones = ViewState("Global")
        Dim con As SqlConnection = New SqlConnection(Declaraciones.Coneccion)
        con.Open()
        Dim sql As String = "Select * From [Products] "
        Dim cm As New SqlCommand(sql, con)
        Dim da As New SqlDataAdapter(cm)
        Dim ds As New DataSet()
        da.Fill(ds)
        ddlproduct.DataSource = ds
        ddlproduct.DataTextField = "Product_ID"
        ddlproduct.DataValueField = "Product_ID"
        ddlproduct.DataBind()
        ddlproduct.Items.Insert(0, New ListItem("--Select--", "0"))
        con.Close()
        ViewState("Global") = Global_class
    End Sub
    Private Sub Fillddli()
        Dim Global_class As Declaraciones = ViewState("Global")
        Dim con As SqlConnection = New SqlConnection(Declaraciones.Coneccion)
        con.Open()
        Dim sql As String = "Select * From [Invoice] "
        Dim cd As New SqlCommand(sql, con)
        Dim sda As New SqlDataAdapter(cd)
        Dim dset As New DataSet()
        dset.Clear()
        sda.Fill(dset)
        ddliid.DataSource = dset
        ddliid.DataTextField = "Invoice_ID"
        ddliid.DataValueField = "Invoice_ID"
        ddliid.DataBind()
        ddliid.Items.Insert(0, New ListItem("--Select--", "0"))
        con.Close()
        ViewState("Global") = Global_class
    End Sub
    Private Sub Clear()
        Dim Global_class As Declaraciones = ViewState("Global")
        txtdeid.Text = ""
        ddliid.SelectedValue = 0
        txtindate.Text = ""
        ddlproduct.SelectedValue = 0
        txtpcd.Text = ""
        txtpctype.Text = ""
        txtpccat.Text = ""
        txtpcunit.Text = ""
        txtpcprice.Text = ""
        txtdtotal.Text = ""
        txtpeid.Text = ""
        cbtax.Checked = False
        ViewState("Global") = Global_class
    End Sub
    Private Sub Lock()
        Dim Global_class As Declaraciones = ViewState("Global")
        txtdeid.Enabled = False
        ddliid.Enabled = False
        txtindate.Enabled = False
        ddlproduct.Enabled = False
        txtpcd.Enabled = False
        txtpctype.Enabled = False
        txtpccat.Enabled = False
        txtpcunit.Enabled = False
        txtpcprice.Enabled = False
        txtdtotal.Enabled = False
        txtpeid.Enabled = False
        cbtax.Enabled = False
        ViewState("Global") = Global_class
    End Sub
    Private Sub unlock()
        Dim Global_class As Declaraciones = ViewState("Global")
        txtdeid.Enabled = True
        ddliid.Enabled = True
        ddlproduct.Enabled = True
        txtpcunit.Enabled = True
        txtpeid.Enabled = True
        cbtax.Enabled = True
        txtpcd.BackColor = Drawing.Color.White
        txtpctype.BackColor = Drawing.Color.White
        txtpccat.BackColor = Drawing.Color.White
        txtpcprice.BackColor = Drawing.Color.White
        txtdtotal.BackColor = Drawing.Color.White
        txtindate.BackColor = Drawing.Color.White
        ViewState("Global") = Global_class
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Global_class As Declaraciones = ViewState("Global")
        Dim sql As String = ""
        If select1.SelectedItem.Value = "ID" Then
            sql = "SELECT * FROM [dbo].[InvoiceDetail] WHERE Detail_ID = '" & txtSearch.Text.Trim & "'"
        End If

        If select1.SelectedItem.Value = "in ID" Then
            sql = "SELECT * FROM [dbo].[InvoiceDetail] WHERE Invoice_ID='" & txtSearch.Text.Trim & "'"
        End If

        If select1.SelectedItem.Value = "P ID" Then
            sql = "SELECT * FROM [dbo].[InvoiceDetail] WHERE Product_ID='" & txtSearch.Text.Trim & "'"
        End If

        If select1.SelectedItem.Value = "P type" Then
            sql = "SELECT * FROM [dbo].[InvoiceDetail] WHERE Product_Type ='" & txtSearch.Text.Trim & "'"
        End If
        If select1.SelectedItem.Value = "user" Then
            sql = "SELECT * FROM [dbo].[InvoiceDetail] WHERE stamp_userid ='" & txtSearch.Text.Trim & "'"
        End If
        If select1.SelectedItem.Value = "Seleccione una opcion" Then
            sql = "SELECT * FROM [dbo].[InvoiceDetail] "
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
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('No se encontró el detalle de venta');", True)
            End If
        Catch ex As SqlClient.SqlException
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Problemas al realizar la busqueda del detalle de venta');", True)
        End Try
        ViewState("Global") = Global_class

    End Sub
    Private Sub Addtype()
        Dim Global_class As Declaraciones = ViewState("Global")
        Dim cnn As SqlConnection = New SqlConnection(Declaraciones.Coneccion)
        Dim cmd As SqlCommand
        'SET		IDENTITY_INSERT PurchaseDetail ON   SET		IDENTITY_INSERT Animal OFF
        Try
            Dim sql As String = "SET IDENTITY_INSERT InvoiceDetail ON INSERT INTO [dbo].[InvoiceDetail]("
            sql &= "[Detail_ID]"
            sql &= ",[Invoice_ID]"
            sql &= ",[Invoice_Date]"
            sql &= ",[Product_ID]"
            sql &= ",[Product_Description]"
            sql &= ",[Product_Type]"
            sql &= ",[Product_Category]"
            sql &= ",[Product_Unit]"
            sql &= ",[Product_Price]"
            sql &= ",[Detail_Total]"
            sql &= ",[Personal_ID]"
            sql &= ",[Taxable]"
            sql &= ",[stamp_added]"
            sql &= ",[stamp_userid]) VALUES ( '" & txtdeid.Text.Trim & "'"
            sql &= ", '" & ddliid.Text.Trim & "'"
            sql &= ", '" & txtindate.Text.Trim & "'"
            sql &= ", '" & ddlproduct.Text.Trim & "'"
            sql &= ", '" & txtpcd.Text.Trim & "'"
            sql &= ", '" & txtpctype.Text.Trim & "'"
            sql &= ", '" & txtpccat.Text.Trim & "'"
            sql &= ", '" & txtpcunit.Text.Trim & "'"
            sql &= ", '" & txtpcprice.Text.Trim & "'"
            sql &= ", '" & txtdtotal.Text.Trim & "'"
            sql &= ", '" & txtpeid.Text.Trim & "'"
            sql &= ", '" & cbtax.Checked & "'"
            sql &= ", '" & Now & "'"
            sql &= ", '" & Global_class.User & "')SET IDENTITY_INSERT InvoiceDetail OFF"

            cmd = New SqlCommand(sql, cnn)
            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()
        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Ocurrio un error guardando el detalle de venta');", True)

        End Try
        ViewState("Global") = Global_class

    End Sub
    Private Sub Modtype()
        Dim Global_class As Declaraciones = ViewState("Global")
        Dim cnn As SqlConnection
        Dim cmd As SqlCommand '[Product_Type_Name]
        Try
            Dim sql As String = "UPDATE [dbo].[InvoiceDetail]"
            sql &= " SET [Invoice_ID] = '" & ddliid.Text.Trim & "'"
            sql &= ",[Invoice_Date] = '" & txtindate.Text.Trim & "'"
            sql &= ",[Product_ID] = '" & ddlproduct.Text.Trim & "'"
            sql &= ",[Product_Description] = '" & txtpcd.Text.Trim & "'"
            sql &= ",[Product_Type] = '" & txtpctype.Text.Trim & "'"
            sql &= ",[Product_Category] = '" & txtpccat.Text.Trim & "'"
            sql &= ",[Product_Unit] = '" & txtpcunit.Text.Trim & "'"
            sql &= ",[Product_Price] = '" & txtpcprice.Text.Trim & "'"
            sql &= ",[Detail_Total] = '" & txtdtotal.Text.Trim & "'"
            sql &= ",[Personal_ID] = '" & txtpeid.Text & "'"
            sql &= ",[Taxable] = '" & cbtax.Checked & "'"
            sql &= ",[stamp_userid] = '" & Global_class.User & "'"
            sql &= " WHERE [Detail_ID] = '" & txtdeid.Text.Trim & "'"
            cnn = New SqlConnection(Declaraciones.Coneccion)
            cmd = New SqlCommand(sql, cnn)
            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()


        Catch ex As SqlClient.SqlException
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Ocurrio un error actualizando el detalle de venta');", True)

        End Try
        ViewState("Global") = Global_class

    End Sub


    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim Global_class As Declaraciones = ViewState("Global")
        btnMod.Enabled = False
        btnSave.Enabled = True
        btnCancelar.Enabled = True

        unlock()
        Global_class.anadir = True
        ViewState("Global") = Global_class
    End Sub

    Private Sub btnMod_Click(sender As Object, e As EventArgs) Handles btnMod.Click
        Dim Global_class As Declaraciones = ViewState("Global")
        btnAdd.Enabled = False
        btnMod.Enabled = False
        btnSave.Enabled = True
        btnCancelar.Enabled = True
        unlock()
        ViewState("Global") = Global_class

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim Global_class As Declaraciones = ViewState("Global")
        Dim result As Boolean = True
        If Global_class.anadir = False Or Global_class.anadir = True Then
            If txtdeid.Text = "" Then
                result = False
                txtdeid.BackColor = Drawing.Color.Red
            Else
                txtdeid.BackColor = Drawing.Color.White
            End If
            If ddliid.Text = "" Then
                result = False
                ddliid.BackColor = Drawing.Color.Red
            Else
                ddliid.BackColor = Drawing.Color.White
            End If

            If txtindate.Text = "" Then
                result = False
                txtindate.BackColor = Drawing.Color.Red
            Else
                txtindate.BackColor = Drawing.Color.White
            End If

            If ddlproduct.Text = "--Select--" Then
                result = False
                ddlproduct.BackColor = Drawing.Color.Red
            Else
                ddlproduct.BackColor = Drawing.Color.White
            End If

            If txtpcd.Text = "" Then
                result = False
                txtpcd.BackColor = Drawing.Color.Red
            Else
                txtpcd.BackColor = Drawing.Color.White
            End If
            If txtpctype.Text = "" Then
                result = False
                txtpctype.BackColor = Drawing.Color.Red
            Else
                txtpctype.BackColor = Drawing.Color.White
            End If
            If txtpccat.Text = "" Then
                result = False
                txtpccat.BackColor = Drawing.Color.Red
            Else
                txtpccat.BackColor = Drawing.Color.White
            End If
            If txtpcunit.Text = "" Then
                result = False
                txtpcunit.BackColor = Drawing.Color.Red
            Else
                txtpcunit.BackColor = Drawing.Color.White
            End If
            If txtpcprice.Text = "" Then
                result = False
                txtpcprice.BackColor = Drawing.Color.Red
            Else
                txtpcprice.BackColor = Drawing.Color.White
            End If
            If txtdtotal.Text = "" Then
                result = False
                txtdtotal.BackColor = Drawing.Color.Red
            Else
                txtdtotal.BackColor = Drawing.Color.White
            End If

            If txtpeid.Text = "" Then
                result = False
                txtpeid.BackColor = Drawing.Color.Red
            Else
                txtpeid.BackColor = Drawing.Color.White
            End If

        End If
        If result = True And Global_class.anadir = True Then
            Addtype()
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('El Tipo de Producto ha sido guardado');", True)
            Lock()
            Clear()
        End If

        If result = True And Global_class.anadir = False Then
            Modtype()
            Lock()
            Clear()
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('La información del tipo de producto ha sido actualizado');", True)
        End If

        Response.Redirect("MVDV.aspx?UID=" & Global_class.UserID & "&UN=" & Global_class.UserName)
        ViewState("Global") = Global_class
    End Sub

    Private Sub GVSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVSearch.SelectedIndexChanged
        Dim Global_class As Declaraciones = ViewState("Global")
        Dim row As GridViewRow = GVSearch.SelectedRow
        btnAdd.Enabled = False
        btnMod.Enabled = True
        btnSave.Enabled = False
        btnCancelar.Enabled = False
        txtdeid.Text = row.Cells(1).Text
        ddliid.Text = row.Cells(2).Text
        txtindate.Text = row.Cells(3).Text
        ddlproduct.Text = row.Cells(4).Text
        txtpcd.Text = row.Cells(5).Text
        txtpctype.Text = row.Cells(6).Text
        txtpccat.Text = row.Cells(7).Text
        txtpcunit.Text = row.Cells(8).Text
        txtpcprice.Text = row.Cells(9).Text
        txtdtotal.Text = row.Cells(10).Text
        txtpeid.Text = row.Cells(11).Text
        cbtax.Checked = row.Cells(12).EnableViewState
        ViewState("Global") = Global_class
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Dim Global_class As Declaraciones = ViewState("Global")
        Clear()
        Lock()
        btnAdd.Enabled = True
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

    Protected Sub ddlproduct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlproduct.SelectedIndexChanged
        Dim Global_class As Declaraciones = ViewState("Global")
        Dim con As SqlConnection = New SqlConnection(Declaraciones.Coneccion)
        Dim sql As String = "Select * From [Products] where Product_ID='" & ddlproduct.Text & "' "
        Dim cm As New SqlCommand(sql, con)
        Dim da As New SqlDataAdapter(cm)
        Dim dt As New DataTable()
        dt.Clear()
        da.Fill(dt)
        dt.Dispose()
        txtpcd.Text = dt.Rows(0).Item("Product_Description")
        txtpctype.Text = dt.Rows(0).Item("Product_Type")
        txtpccat.Text = dt.Rows(0).Item("Product_Category")
        txtpcprice.Text = dt.Rows(0).Item("Product_Price")
        ViewState("Global") = Global_class
    End Sub

    Protected Sub ddliid_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddliid.SelectedIndexChanged
        Dim Global_class As Declaraciones = ViewState("Global")
        Dim con As SqlConnection = New SqlConnection(Declaraciones.Coneccion)
        Dim sql As String = "Select Invoice_Date From [Invoice] where Invoice_ID='" & ddliid.Text & "' "
        Dim cm As New SqlCommand(sql, con)
        Dim da As New SqlDataAdapter(cm)
        Dim dt As New DataTable()
        dt.Clear()
        da.Fill(dt)
        dt.Dispose()
        txtindate.Text = dt.Rows(0).Item("Invoice_Date")
        ViewState("Global") = Global_class
    End Sub

    Private Sub txtpcunit_TextChanged(sender As Object, e As EventArgs) Handles txtpcunit.TextChanged
        Dim Global_class As Declaraciones = ViewState("Global")
        Dim temp As Double
        Dim temp1 As Double
        temp = txtpcprice.Text
        temp1 = txtpcunit.Text
        txtdtotal.Text = temp * temp1
        ViewState("Global") = Global_class
    End Sub
End Class