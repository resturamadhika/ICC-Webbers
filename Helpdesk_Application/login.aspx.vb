Imports System.Data.SqlClient
Public Class login1
    Inherits System.Web.UI.Page

    Dim Proses As New ClsConn
    Dim sqldr As SqlDataReader
    Dim sql As String
    Dim valuesatu As Integer = 1
    Dim valuedua As Integer = 2
    Dim valuetiga As Integer = 3
    Dim leveluser As String
    Dim value As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session.RemoveAll()
        FormsAuthentication.SignOut()
    End Sub
    Sub Action_login()
        sql = "Select COUNT (UserID) as userID from msUser where UserName='" & txt_username.Text & "' and Password='" & txt_password.Text & "'"
        sqldr = Proses.ExecuteReader(sql)
        Try
            If sqldr.HasRows Then
                sqldr.Read()
                value = sqldr("userID")
            End If
            sqldr.Close()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
        If value > 0 Then
            sql = "Select * from msUser where UserName='" & txt_username.Text & "' and Password='" & txt_password.Text & "'"
            sqldr = Proses.ExecuteReader(sql)
            If sqldr.HasRows Then
                sqldr.Read()
                leveluser = sqldr("LevelUser").ToString
                Session("UserName") = sqldr("NIK").ToString
                Session("lblUserName") = sqldr("UserName").ToString
                Session("UnitKerja") = sqldr("UnitKerja").ToString
            End If
            sqldr.Close()

            sql = "Select * from mKaryawan where NIK='" & Session("UserName") & "'"
            sqldr = Proses.ExecuteReader(sql)
            If sqldr.HasRows Then
                sqldr.Read()
                Session("NameKaryawan") = sqldr("Name").ToString
                Session("divisi") = sqldr("Divisi").ToString
            End If
            sqldr.Close()

            sql = "Select * from msUserTrustee where LevelUser='" & leveluser & "'"
            sqldr = Proses.ExecuteReader(sql)
            If sqldr.HasRows Then
                sqldr.Read()
                Session("LoginType") = sqldr("LevelUserSbg")
            End If
            sqldr.Close()
            Session("LoginTypeAngka") = value
            Session("LoginTypeSbg") = leveluser

            If Session("LoginType") = "" Then

            ElseIf Session("LoginType") = "layer1" Then
                Session("LoginTypeAngka") = valuesatu
            ElseIf Session("LoginType") = "layer2" Then
                Session("LoginTypeAngka") = valuedua
            ElseIf Session("LoginType") = "layer3" Then
                Session("LoginTypeAngka") = valuetiga
            End If
            Response.Redirect("HTML/dashboard.aspx")
        Else
            ' lbl_error_messaege.Text = "user tidak terdaftar"
        End If
    End Sub

    Private Sub btn_login_Click(sender As Object, e As EventArgs) Handles btn_login.Click
        Action_login()
    End Sub
End Class