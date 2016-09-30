Imports System.Data.SqlClient
Public Class inbox_twitter
    Inherits System.Web.UI.Page

    Dim Proses As New ClsSos
    Dim sqldr As SqlDataReader
    Dim sql As String
    Dim valTwitter As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("account") = "" Then
            'sql = "sp_twitter_mention"
            'sqldr = Proses.ExecuteReader(sql)
            'Try
            '    While sqldr.Read()
            '        valTwitter &= "<tr>" & _
            '                     "<td><span class='not-starred'><i><a class='nonelink' href='utama.aspx?channel=twitter&id=" & sqldr("id_Twitter") & "&account=" & sqldr("screen_Name") & "' target='_blank'>" & sqldr("screen_Name") & "</i></span></td>" & _
            '                      "<td>" & sqldr("tText").ToString & "</td>" & _
            '                      "<td>" & sqldr("created_at").ToString & "</td>" & _
            '                      "</tr>"
            '    End While
            '    sqldr.Close()
            '    ltr_twitter.Text = valTwitter
            'Catch ex As Exception
            '    Response.Write(ex.Message)
            'End Try
            sql_inbox_twitter.SelectCommand = "SELECT * FROM tw_tMention"
        Else
               
        End If      
    End Sub
End Class