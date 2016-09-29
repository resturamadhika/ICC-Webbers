Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI
Imports System.Threading
Imports DevExpress.Web.ASPxGridView
Public Class inbox
    Inherits System.Web.UI.Page

    Dim sqlDr As SqlDataReader
    Dim Proses As New ClsSos
    Dim Execute As New ClsConn
    Dim sql As String
    Dim VInbox, VTodolist As String
    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString)
    Dim com As New SqlCommand
    Dim str, AppTicket As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("status") = "" Then
            div_inbox.Visible = True
            div_todolist.Visible = False
            str = "select * from fb_tGet_Header"
            sqlDr = Proses.ExecuteReader(str)
            While sqlDr.Read()
                VInbox &= "<tr>" & _
                            "<td><span class='not-starred'><i><a class='nonelink' href='utama.aspx?id=" & sqlDr("facebook_ID") & "&account=" & sqlDr("facebook_Name") & "&channel=facebook'>" & sqlDr("facebook_ID") & "</i></span></td>" & _
                            "<td>" & sqlDr("facebook_Name").ToString & "</td>" & _
                            "<td>" & sqlDr("facebook_Message").ToString & "</td>" & _
                            "<td>" & sqlDr("ddate").ToString & "</td>" & _
                            "<td>" & _
                            "</tr>"
            End While
            sqlDr.Close()
            ltr_inbox.Text = VInbox
        Else
            ''Setting Applikasi
            sql = "Select * from mApplikasi"
            sqlDr = Execute.ExecuteReader(sql)
            If sqlDr.HasRows Then
                sqlDr.Read()
                AppTicket = sqlDr("Ticket").ToString
            End If
            sqlDr.Close()
            If AppTicket = "Yes" Then
                Ticket_Todo()
                div_inbox.Visible = False
                div_todolist.Visible = True
            Else
                div_inbox.Visible = True
                div_todolist.Visible = False
            End If                   
        End If
    End Sub
    Sub Ticket_Todo()
        str = "spExec_ToDoListCUdanPIC " & Session("LoginTypeAngka") & "," & Session("divisi") & "," & Session("UserName") & ""
        com = New SqlCommand(str, con)
        Try
            con.Open()
            sqlDr = com.ExecuteReader()
            While sqlDr.Read()
                Dim range As Integer = sqlDr("Range").ToString
                Dim SLA As String = sqlDr("SLA").ToString
                Dim Warna As String
                If range > 0 Then
                    Warna = "<div class='progress progress-striped active' style='height:8px; margin:5px 0 0 0;'>" & _
                                "<div class='progress-bar progress-bar-danger' style='width: 100%'>" & _
                                "<span class='sr-only'>45% Complete</span> " & _
                                "</div>" & _
                                "</div></td>"
                ElseIf range = 0 Then
                    Warna = "<div class='progress progress-striped active' style='height:8px; margin:5px 0 0 0;'>" & _
                                "<div class='progress-bar progress-bar-success' style='width: 100%'>" & _
                                "<span class='sr-only'>45% Complete</span> " & _
                                "</div>" & _
                                "</div></td>"
                ElseIf range < SLA Then
                    Warna = "<div class='progress progress-striped active' style='height:8px; margin:5px 0 0 0;'>" & _
                                "<div class='progress-bar progress-bar-warning' style='width: 100%'>" & _
                                "<span class='sr-only'>45% Complete</span> " & _
                                "</div>" & _
                                "</div></td>"
                End If
                VTodolist &= "<tr>" & _
                        "<td>" & sqlDr("NumberRow").ToString & "</td>" & _
                        "<td><span class='not-starred'><i><a class='nonelink' href='utama.aspx?tid=" & sqlDr("TicketNumber") & "&layer=" & Session("LoginType") & "&NIK=" & sqlDr("NIK") & "&datecreate=" & sqlDr("DateCreate") & "'>" & sqlDr("TicketNumber") & "</i></span></td>" & _
                        "<td>" & sqlDr("NamePIC").ToString & "</td>" & _
                        "<td>" & sqlDr("DetailComplaint").ToString & "</td>" & _
                        "<td>" & sqlDr("Status").ToString & "</td>" & _
                        "<td>" & Warna & "</td>" & _
                        "<td>" & _
                        "</tr>"
            End While
            sqlDr.Close()
            con.Close()
            ltr_todolist.Text = VTodolist
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
End Class