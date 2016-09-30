Imports System.Data
Imports System.Data.SqlClient
Public Class Transaction_Type
    Inherits System.Web.UI.Page

    Dim Proses As New ClsConn
    Dim sqldr As SqlDataReader
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        sql_transaction_type.SelectCommand = "select * from mcategory"
        sql_transaction_type.UpdateCommand = ""
    End Sub
End Class