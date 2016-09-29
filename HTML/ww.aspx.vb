Imports System.Web
Imports System.Web.UI
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls.Literal
Public Class ww
    Inherits System.Web.UI.Page


    Dim sqlcon_Ticket As New SqlConnection(ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString)
    Dim sqlcom As SqlCommand
    Dim sqldr As SqlDataReader
    Dim strSql, tampungan As String
    Dim strConnString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
    Dim xx As String
    Dim arr = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.bind()
        End If
    End Sub
    Sub bind()
        sql_source.SelectCommand = "select * from mSourceType"
    End Sub

    Private Sub btn_Click(sender As Object, e As EventArgs) Handles btn.Click
        'Dim fieldValues As List(Of Object) = grid.GetSelectedFieldValues(New String() {"typecode", "Name"})
        'For Each item As Object() In fieldValues
        '    strSql = "Insert into mSourceType (typecode, Name) values ('xx'," & ASPxListBox1.Items(0).Value & ")"
        '    sqlcom = New SqlCommand(strSql, sqlcon_Ticket)
        '    sqlcon_Ticket.Open()
        '    sqlcom.ExecuteNonQuery()
        '    sqlcon_Ticket.Close()
        'Next

    End Sub
End Class