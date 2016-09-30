Public Class zz
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack Then
            TabName.Value = Request.Form(TabName.UniqueID)
        End If
    End Sub
End Class