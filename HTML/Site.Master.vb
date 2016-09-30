Public Class SiteMaster
    Inherits MasterPage


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        'If Request.QueryString("id") = "" Then

        'ElseIf Request.QueryString("id") = "voice" Then
        '    lbl_open.Text = "10"
        '    lbl_close.Text = "3"
        '    lbl_pending.Text = "2"
        '    lbl_on_progress.Text = "2"
        'ElseIf Request.QueryString("id") = "email" Then
        '    lbl_open.Text = "2"
        '    lbl_close.Text = "1"
        '    lbl_pending.Text = "1"
        '    lbl_on_progress.Text = "1"
        'ElseIf Request.QueryString("id") = "sms" Then
        '    lbl_open.Text = "3"
        '    lbl_close.Text = "10"
        '    lbl_pending.Text = "1"
        '    lbl_on_progress.Text = "1"
        'ElseIf Request.QueryString("id") = "fax" Then
        '    lbl_open.Text = "7"
        '    lbl_close.Text = "0"
        '    lbl_pending.Text = "0"
        '    lbl_on_progress.Text = "0"
        'ElseIf Request.QueryString("id") = "twitter" Then
        '    lbl_open.Text = "8"
        '    lbl_close.Text = "2"
        '    lbl_pending.Text = "1"
        '    lbl_on_progress.Text = "1"
        'End If

    End Sub
End Class