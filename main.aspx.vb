Imports System.Web
Imports System.Web.UI
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class main
    Inherits System.Web.UI.Page
    Dim sqlcon As New SqlConnection(ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString)
    Dim sqlcom As SqlCommand
    Dim sqldr As SqlDataReader
    Dim strSql, strSqlString As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        strSql = "select * from mcustomer where customerid='" & Request.QueryString("id") & "'"
        sqlcom = New SqlCommand(strSql, sqlcon)
        sqlcon.Open()
        Try
            sqldr = sqlcom.ExecuteReader()
            If sqldr.HasRows() Then
                sqldr.Read()
                lbl_nama.Text = sqldr("NamaPerusahaan").ToString
                lbl_email.Text = sqldr("email").ToString
                lbl_tlp.Text = sqldr("Telepon").ToString
            End If
            sqldr.Close()
            sqlcon.Close()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
        sql_source_type.SelectCommand = "select * from mSourceType"
        sql_group_type.SelectCommand = "select * from mGroupType"
        sql_transaction_type.SelectCommand = "select * from mCategory"
        sql_priority.SelectCommand = "select * from mpriority"
        sql_severity.SelectCommand = "select * from mseverity"
        sql_status.SelectCommand = "select * from mstatus"
        strSqlString = "select top 1 * from tticket inner join mKaryawan on tticket.usercreate = mKaryawan.NIK where tticket.NIK='" & Request.QueryString("id") & "'"
        sqlcom = New SqlCommand(strSqlString, sqlcon)
        sqlcon.Open()
        Try
            sqldr = sqlcom.ExecuteReader()
            If sqldr.HasRows() Then
                sqldr.Read()
                lbl_agent.Text = sqldr("Name").ToString
                lbl_nik_agent.Text = sqldr("UserCreate").ToString
                lbl_date_create.Text = sqldr("DateCreate")
                cmb_source_type.Text = sqldr("TicketSource").ToString
                cmb_group_type.Text = sqldr("TicketGroupName").ToString
                cmb_transaction_type.Text = sqldr("CategoryName").ToString
                cmb_brand.Text = sqldr("SubCategory1Name").ToString
                cmb_product.Text = sqldr("SubCategory2Name").ToString
                cmb_problem.Text = sqldr("SubCategory3Name").ToString
                cmb_priority.Text = sqldr("ComplaintLevel").ToString
                cmb_severity.Text = sqldr("Severity").ToString
                cmb_status.Text = sqldr("Status").ToString
                txt_description.Text = sqldr("DetailComplaint").ToString
                lbl_sla.Text = sqldr("SLA").ToString
            End If
            sqldr.Close()
            sqlcon.Close()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
        'Datatable interaction
        Dim tampung As String = ""
        Dim selectdata As String = "select ResponseComplaint,tticket.DateCreate, Name from tInteraction inner join mKaryawan " & _
        "on tInteraction.AgentCreate = mKaryawan.NIK inner join tTicket on tInteraction.TicketNumber = tTicket.TicketNumber " & _
        "where tTicket.NIK = " & Request.QueryString("id") & ""
        sqlcom = New SqlCommand(selectdata, sqlcon)
        sqlcon.Open()
        sqldr = sqlcom.ExecuteReader()
        While sqldr.Read
            tampung &= "<tr>" & _
                    "<td>" & sqldr("Name").ToString & "</td>" & _
                    "<td>" & sqldr("ResponseComplaint").ToString & "</td>" & _
                    "<td style='width:200px'>" & sqldr("DateCreate").ToString & "</td>" & _
                    "</td>" & _
                  "</tr> "
        End While
        sqldr.Close()
        sqlcon.Close()
        ltr_interaction.Text = tampung
    End Sub

End Class