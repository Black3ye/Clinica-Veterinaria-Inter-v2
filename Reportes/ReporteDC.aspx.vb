Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Reporting.WebForms
Public Class ReporteDC
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not IsPostBack Then
                DataforReport()
            End If
        End If
    End Sub
    Public Sub DataforReport()
        Dim con As SqlConnection = New SqlConnection(Declaraciones.Coneccion)
        Dim sda As SqlDataAdapter = New SqlDataAdapter
        Dim Sql As String = "SELECT * FROM [Clinica].[dbo].[PurchaseDetail]"

        sda.SelectCommand = New SqlCommand(Sql, con)
        Dim dt As New DataTable
        con.Open()
        Try
            dt.Clear()
            sda.Fill(dt)
        Finally
            con.Close()
        End Try
        Dim rds = New ReportDataSource("DSDPurchase", dt)

        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewer1.LocalReport.ReportEmbeddedResource = "Reportes\rptDPurchase.rdlc"
        ReportViewer1.DataBind()
    End Sub
End Class