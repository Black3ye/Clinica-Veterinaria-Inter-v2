Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class MI
    Inherits System.Web.UI.Page
    Dim Global_class As Declaraciones = New Declaraciones
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Global_class.UserID = Request.QueryString.Item("UID")
        Global_class.UserName = Request.QueryString.Item("UN")
        If Global_class.UserName = vbNullString Or Session.IsNewSession = True Or Session.Contents.Count < 1 Then
            Response.Redirect("Login.aspx")
        End If
        Nameuser.Text = Global_class.UserName
        Dim sqla As String = "Select User_ID, Role FROM [dbo].[Users] WHERE username = '" & Global_class.UserID & "'"
        Dim sda1 As SqlDataAdapter = New SqlDataAdapter(sqla, Declaraciones.Coneccion)
        Dim cmb1 As SqlCommandBuilder = New SqlCommandBuilder(sda1)
        Dim dtab As DataTable = New DataTable
        dtab.Locale = System.Globalization.CultureInfo.InvariantCulture
        dtab.Clear()
        sda1.Fill(dtab)
        sda1.Dispose()
        Global_class.User = Trim(dtab.Rows(0).Item("User_ID"))
        Global_class.role = Trim(dtab.Rows(0).Item("role"))
        If btnAdd.Enabled = True Then
            Global_class.L = True
        Else
            Global_class.L = False
        End If
        If Global_class.role = "Administrator" Then
            btnAdd.Enabled = True
            btnMod.Enabled = False
        Else
            btnAdd.Enabled = False
            btnMod.Enabled = False
            btnSave.Enabled = False
            btnCancelar.Enabled = False
            [option].Enabled = False
        End If
    End Sub
    Private Sub btnback_Click(sender As Object, e As EventArgs) Handles btnback.Click
        Response.Redirect("Menu.aspx?UID=" & Global_class.UserID & "&UN=" & Global_class.UserName)
    End Sub
    Private Sub option_Click(sender As Object, e As EventArgs) Handles [option].Click
        If Report.Visible = False Then
            Report.Visible = True
        Else
            Report.Visible = False
        End If

    End Sub

    Private Sub Report_Click(sender As Object, e As EventArgs) Handles Report.Click
        Dim s As String = "window.open('Reportes/ReportProduct.aspx?UID=" & Global_class.UserID & "&UN=" & Global_class.UserName & "&NI=" & Global_class.ID & " ', '_blank');"
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "alertscript", s, True)
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
    Private Sub Clear()
        txtid.Text = ""
        txtdes.Text = ""
        txttype.Text = ""
        txtcat.Text = ""
        txtupc.Text = ""
        txtcode.Text = ""
        txtamount.Text = ""
        txtprice.Text = ""
        txtreorder.Text = ""
        txtmax.Text = ""
        ChTaxable.Checked = False
        txtostock.Text = ""
        Chstatus.Checked = False
        txtrestock.Text = ""

    End Sub
    Private Sub Lock()
        txtid.Enabled = False
        txtdes.Enabled = False
        txttype.Enabled = False
        txtcat.Enabled = False
        txtupc.Enabled = False
        txtcode.Enabled = False
        txtamount.Enabled = False
        txtprice.Enabled = False
        txtreorder.Enabled = False
        txtmax.Enabled = False
        ChTaxable.Enabled = False
        txtostock.Enabled = False
        Chstatus.Enabled = False
        txtrestock.Enabled = False
    End Sub
    Private Sub unlock()
        txtid.Enabled = True
        txtdes.Enabled = True
        txttype.Enabled = True
        txtcat.Enabled = True
        txtupc.Enabled = True
        txtcode.Enabled = True
        txtamount.Enabled = True
        txtprice.Enabled = True
        txtreorder.Enabled = True
        txtmax.Enabled = True
        ChTaxable.Enabled = True
        txtostock.Enabled = True
        Chstatus.Enabled = True
        txtrestock.Enabled = True
    End Sub
    Private Sub Addtype()
        Dim cnn As SqlConnection = New SqlConnection(Declaraciones.Coneccion)
        Dim cmd As SqlCommand
        Try
            Dim sql As String = "INSERT INTO [dbo].[Products]("
            sql &= "[Product_ID]"
            sql &= ",[Product_Description]"
            sql &= ",[Product_Type]"
            sql &= ",[Product_Category]"
            sql &= ",[Product_Upc]"
            sql &= ",[Product_Code]"
            sql &= ",[Product_Amount]"
            sql &= ",[Product_Price]"
            sql &= ",[Product_Reorder]"
            sql &= ",[Product_Max]"
            sql &= ",[Taxable]"
            sql &= ",[Out_of_stock_explanation]"
            sql &= ",[Product_Status]"
            sql &= ",[Restock_date]"
            sql &= ",[stamp_added]"
            sql &= ",[stamp_userid]) VALUES ( '" & txtid.Text.Trim & "'"
            sql &= ", '" & txtdes.Text.Trim & "'"
            sql &= ", '" & txttype.Text.Trim & "'"
            sql &= ", '" & txtcat.Text.Trim & "'"
            sql &= ", '" & txtupc.Text.Trim & "'"
            sql &= ", '" & txtcode.Text.Trim & "'"
            sql &= ", '" & txtamount.Text.Trim & "'"
            sql &= ", '" & txtprice.Text.Trim & "'"
            sql &= ", '" & txtreorder.Text.Trim & "'"
            sql &= ", '" & txtmax.Text.Trim & "'"
            sql &= ", '" & ChTaxable.Checked & "'"
            sql &= ", '" & txtostock.Text.Trim & "'"
            sql &= ", '" & Chstatus.Checked & "'"
            sql &= ", '" & txtrestock.Text.Trim & "'"
            sql &= ", '" & Now & "'"
            sql &= ", '" & Global_class.User & "')"

            cmd = New SqlCommand(sql, cnn)
            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()
        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Ocurrio un error guardando el tipo de producto');", True)

        End Try
    End Sub
    Private Sub Modtype()
        Dim cnn As SqlConnection
        Dim cmd As SqlCommand '[Product_Type_Name]
        Try
            Dim sql As String = "UPDATE [dbo].[Products]"
            sql &= " SET [Product_Description] = '" & txtdes.Text.Trim & "'"
            sql &= ",[Product_Type] = '" & txttype.Text.Trim & "'"
            sql &= ",[Product_Category] = '" & txtcat.Text.Trim & "'"
            sql &= ",[Product_Upc] = '" & txtupc.Text.Trim & "'"
            sql &= ",[Product_Code] = '" & txtcode.Text.Trim & "'"
            sql &= ",[Product_Amount] = '" & txtamount.Text.Trim & "'"
            sql &= ",[Product_Price] = '" & txtprice.Text.Trim & "'"
            sql &= ",[Product_Reorder] = '" & txtreorder.Text.Trim & "'"
            sql &= ",[Product_Max] = '" & txtmax.Text.Trim & "'"
            sql &= ",[Taxable] = '" & ChTaxable.Checked & "'"
            sql &= ",[Out_of_stock_explanation] = '" & txtostock.Text.Trim & "'"
            sql &= ",[Product_Status] = '" & Chstatus.Checked & "'"
            sql &= ",[Restock_date] = '" & txtrestock.Text.Trim & "'"
            sql &= ",[stamp_added] = '" & Now & "'"
            sql &= ",[stamp_userid] = '" & Global_class.User & "'"
            sql &= " WHERE [Product_ID] = '" & txtid.Text.Trim & "'"
            cnn = New SqlConnection(Declaraciones.Coneccion)
            cmd = New SqlCommand(sql, cnn)
            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()


        Catch ex As SqlClient.SqlException
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Ocurrio un error actualizando el tipo de producto');", True)

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql As String = ""
        If select1.SelectedItem.Value = "ID" Then
            sql = "SELECT * FROM [dbo].[Products] WHERE Product_ID = '" & txtSearch.Text.Trim & "'"
        End If

        If select1.SelectedItem.Value = "Type" Then
            sql = "SELECT * FROM [dbo].[Products] WHERE Product_Type='" & txtSearch.Text.Trim & "'"
        End If

        If select1.SelectedItem.Value = "Code" Then
            sql = "SELECT * FROM [dbo].[Products] WHERE Product_Code ='" & txtSearch.Text.Trim & "'"
        End If
        If select1.SelectedItem.Value = "Description" Then
            sql = "SELECT * FROM [dbo].[Products] WHERE Product_Description ='" & txtSearch.Text.Trim & "'"
        End If
        If select1.SelectedItem.Value = "Seleccione una opcion" Then
            sql = "SELECT * FROM [dbo].[Products] "
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
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('No se encontró el Inventario');", True)
            End If
        Catch ex As SqlClient.SqlException
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Problemas al realizar la busqueda del Inventario');", True)

        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        btnMod.Enabled = False
        btnSave.Enabled = True
        btnCancelar.Enabled = True
        btnReload.Enabled = False
        unlock()
    End Sub

    Private Sub btnMod_Click(sender As Object, e As EventArgs) Handles btnMod.Click
        btnAdd.Enabled = False
        btnMod.Enabled = False
        btnSave.Enabled = True
        btnCancelar.Enabled = True
        btnReload.Enabled = False
        unlock()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim result As Boolean = True
        If Global_class.L = True Then
            Global_class.anadir = True
        Else
            Global_class.anadir = False
        End If
        If Global_class.anadir = False Or Global_class.anadir = True Then
            If txtid.Text = "" Then
                result = False
                txtid.BackColor = Drawing.Color.Red
            Else
                txtid.BackColor = Drawing.Color.White
            End If
            If txtdes.Text = "" Then
                result = False
                txtdes.BackColor = Drawing.Color.Red
            Else
                txtdes.BackColor = Drawing.Color.White
            End If
            If txttype.Text = "" Then
                result = False
                txttype.BackColor = Drawing.Color.Red
            Else
                txttype.BackColor = Drawing.Color.White
            End If

            If txtcat.Text = "" Then
                result = False
                txtcat.BackColor = Drawing.Color.Red
            Else
                txtcat.BackColor = Drawing.Color.White
            End If
            If txtupc.Text = "" Then
                result = False
                txtupc.BackColor = Drawing.Color.Red
            Else
                txtupc.BackColor = Drawing.Color.White
            End If
            If txtcode.Text = "" Then
                result = False
                txtcode.BackColor = Drawing.Color.Red
            Else
                txtcode.BackColor = Drawing.Color.White
            End If
            If txtamount.Text = "" Then
                result = False
                txtamount.BackColor = Drawing.Color.Red
            Else
                txtamount.BackColor = Drawing.Color.White
            End If
            If txtprice.Text = "" Then
                result = False
                txtprice.BackColor = Drawing.Color.Red
            Else
                txtprice.BackColor = Drawing.Color.White
            End If
            If txtreorder.Text = "" Then
                result = False
                txtreorder.BackColor = Drawing.Color.Red
            Else
                txtreorder.BackColor = Drawing.Color.White
            End If
            If txtmax.Text = "" Then
                result = False
                txtmax.BackColor = Drawing.Color.Red
            Else
                txtmax.BackColor = Drawing.Color.White
            End If
            If txtostock.Text = "" Then
                result = False
                txtostock.BackColor = Drawing.Color.Red
            Else
                txtostock.BackColor = Drawing.Color.White
            End If
            If txtrestock.Text = "" Then
                result = False
                txtrestock.BackColor = Drawing.Color.Red
            Else
                txtrestock.BackColor = Drawing.Color.White
            End If

        End If
        txtrestock.ReadOnly = False
        If result = True And Global_class.anadir = True Then
            Call Addtype()
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
        Response.Redirect("MI.aspx?UID=" & Global_class.UserID & "&UN=" & Global_class.UserName)
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
        Response.Redirect("MI.aspx?UID=" & Global_class.UserID & "&UN=" & Global_class.UserName)
    End Sub

    Private Sub GVSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVSearch.SelectedIndexChanged
        Dim row As GridViewRow = GVSearch.SelectedRow
        If Global_class.role = "Administrator" Then
            btnAdd.Enabled = True
            btnMod.Enabled = False
            If row.Cells(1).Text.Trim <> "" Then
                btnAdd.Enabled = "False"
                btnMod.Enabled = "True"
                btnSave.Enabled = "False"
                btnCancelar.Enabled = "False"

                txtid.Text = row.Cells(1).Text
                txtdes.Text = row.Cells(2).Text
                txttype.Text = row.Cells(3).Text
                txtcat.Text = row.Cells(4).Text
                txtupc.Text = row.Cells(5).Text
                txtcode.Text = row.Cells(6).Text
                txtamount.Text = row.Cells(7).Text
                txtprice.Text = row.Cells(8).Text
                txtreorder.Text = row.Cells(9).Text
                txtmax.Text = row.Cells(10).Text
                ChTaxable.Checked = row.Cells(11).EnableViewState
                txtostock.Text = row.Cells(12).Text
                Chstatus.Checked = row.Cells(13).EnableViewState
                txtrestock.Text = row.Cells(14).Text
                Global_class.anadir = False
            End If
        Else
            btnAdd.Enabled = False
            btnMod.Enabled = False
            btnSave.Enabled = False
            btnCancelar.Enabled = False
        End If

    End Sub
End Class