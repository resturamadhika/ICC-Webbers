Imports System.Data
Imports System.Data.SqlClient
Public Class calltype_one
    Inherits System.Web.UI.Page

    Dim Proses As New ClsConn
    Dim Sqldr As SqlDataReader
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        sql_calltype_one.SelectCommand = "select mSubCategoryLv1.SubCategory1ID, mSubCategoryLv1.CategoryID, mCategory.Name, mSubCategoryLv1.SubName, mSubCategoryLv1.NA from mSubCategoryLv1 left outer join mCategory on mSubCategoryLv1.CategoryID = mCategory.CategoryID"
        sql_transaction_type.SelectCommand = "select * from mCategory"
    End Sub
End Class