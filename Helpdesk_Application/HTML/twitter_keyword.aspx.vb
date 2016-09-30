Public Class twitter_keyword
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("id") = 2 Then
           
        Else
         
        End If
    End Sub

    Private Sub btn_submit_Click(sender As Object, e As EventArgs) Handles btn_submit.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        wizz2.Attributes.Add("class", "active")
        'wizardContent2.Attributes.Add("class", "tab-pane active")
        wizz1.Attributes.Remove("class")
        [as].Visible = False
        x.Visible = True
        'wizardContent1.Attributes.Add("class", "tab-pane")

        Response.Redirect("twitter_keyword.aspx#wizardContent2")
    End Sub

End Class