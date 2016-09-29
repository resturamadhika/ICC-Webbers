Imports System.Web
Imports System.Web.UI
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Newtonsoft.Json.Linq
Imports System.IO
Public Class xx
    Inherits System.Web.UI.Page

    Dim sqlcon_Ticket As New SqlConnection(ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString)
    Dim sqlcom As SqlCommand
    Dim sqldr As SqlDataReader
    Dim strSql, tampungan As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        strSql = "select top 2 IVC_ID, ETO from IVC_EMAIL_IN_TM"
        sqlcom = New SqlCommand(strSql, sqlcon_Ticket)
        sqlcon_Ticket.Open()
        sqldr = sqlcom.ExecuteReader()
        While sqldr.Read()
            tampungan &= "<tr>" & _
                          "<td><span class='not-starred'><a href='#' onClick='updateHeaderChannel(" & sqldr("IVC_ID").ToString & ")' data-target='#ModalEmail' data-toggle='modal' class='shortcut-link' target='_blank'>Replay</a></span></td>" & _
                          "<td>" & sqldr("ETO").ToString & "</td>" & _
                          "</tr>"

        End While
        sqldr.Close()
        sqlcon_Ticket.Close()
        ltr_email.Text = tampungan



    End Sub

    Private Sub Btn_upload_Click(sender As Object, e As EventArgs) Handles Btn_upload.Click
        Dim Time As String = DateTime.Now.ToString("yyyyMMddhhmmss")
        Dim FilePath As String = ConfigurationManager.AppSettings("FilePath").ToString()
        Dim FileFullPath As String = ConfigurationManager.AppSettings("FileFullPath").ToString()
        Dim blSucces As Boolean = False
        Dim filename As String = String.Empty
        'To check whether file is selected or not to uplaod
        If ww.HasFile Then
            Try
                Dim allowdFile As String() = {".jpg", ".xls", ".pdf", ".doc", ".docx", ".xlsx", ".flv", ".mkv", ".avi", ".mp4", ".mp3", ".png", ".951"}
                'Here we are allowing only pdf file so verifying selected file pdf or not
                Dim FileExt As String = System.IO.Path.GetExtension(ww.PostedFile.FileName)
                Dim isValidFile As Boolean = allowdFile.Contains(FileExt)
                If Not isValidFile Then
                    'ASPxLabel2.ForeColor = System.Drawing.Color.Red
                    'ASPxLabel2.Text = "Please upload only jpg "
                Else
                    ' Get size of uploaded file, here restricting size of file
                    Dim FileSize As Integer = ww.PostedFile.ContentLength
                    If FileSize <= 1073741824 Then
                        '1048576 byte = 1MB
                        'Get file name of selected file
                        filename = Path.GetFileName(ww.FileName)
                        'Save selected file into specified location
                        ww.SaveAs(Server.MapPath(FilePath) & filename)
                        'ASPxLabel2.Text = "File upload successfully!"
                        blSucces = True
                    Else
                        'ASPxLabel2.Text = "Attachment file size should not be greater then 1 G!"
                    End If
                End If
            Catch ex As Exception
                lblcc.Text = "Error occurred while uploading a file: " + ex.Message
            End Try
        End If
    End Sub
End Class