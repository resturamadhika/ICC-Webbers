Imports System
Imports System.Data.SqlClient
Public Class user
    Inherits System.Web.UI.Page

    Dim Proses As New ClsConn
    Dim Sqldr, dr As SqlDataReader
    Dim com As New SqlCommand
    Dim sql, strsql As String
    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString)
    Dim Ticket, Email, Twitter, Facebook, Fax, Chat, Sms, Telegram, Instagram As String
    Dim VTicket, VEmail, VTwitter, VFacebook, VFax, VChat, VSms, VTelegram, VInstagram As String
    Dim ISubMenu, IlevelUser As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btn_simpan.Visible = True
        div_customer.Visible = True
        div_setting.Visible = True
        div_license.Visible = True
        hr_satu.Visible = True
        hr_dua.Visible = True
        hr_tiga.Visible = True
    End Sub

    Private Sub btn_simpan_Click(sender As Object, e As EventArgs) Handles btn_simpan.Click
        Dim IMenu As String = ""
        If chk_ticket.Checked = True Then
            Ticket = "TRUE"
            IMenu += "Insert Into User1 (MenuName) values('Master Data')"
            IMenu += "Insert Into User1 (MenuName) values('Ticket')"
        Else
            IMenu += "Insert Into User1 (MenuName) values('Master Data')"
            Ticket = "FALSE"
        End If
        If chk_email.Checked = True Or chk_twitter.Checked = True Or chk_facebook.Checked = True Or chk_fax.Checked = True Or chk_chat.Checked = True Or chk_sms.Checked = True Or chk_telegram.Checked = True Or chk_instagram.Checked = True Then
            IMenu += "Insert Into User1 (MenuName) values('Channel')"
        Else
        End If
        If chk_email.Checked = True Then
            Email = "TRUE"
        Else
            Email = "FALSE"
        End If
        If chk_twitter.Checked = True Then
            Twitter = "TRUE"
        Else
            Twitter = "FALSE"
        End If
        If chk_facebook.Checked = True Then
            Facebook = "TRUE"
        Else
            Facebook = "FALSE"
        End If
        If chk_fax.Checked = True Then
            Fax = "TRUE"
        Else
            Fax = "FALSE"
        End If
        If chk_chat.Checked = True Then
            Chat = "TRUE"
        Else
            Chat = "FALSE"
        End If
        If chk_sms.Checked = True Then
            Sms = "TRUE"
        Else
            Sms = "FALSE"
        End If
        If chk_telegram.Checked = True Then
            Telegram = "TRUE"
        Else
            Telegram = "FALSE"
        End If
        If chk_instagram.Checked = True Then
            Instagram = "TRUE"
        Else
            Instagram = "FALSE"
        End If
        IMenu += "Insert Into User1 (MenuName) values('Dashboard')"
        IMenu += "Insert Into User1 (MenuName) values('Todolist')"
        IMenu += "Insert Into User1 (MenuName) values('Report')"
        IMenu += "Insert Into User1 (MenuName) values('Management User')"
        IMenu += "Insert Into User1 (MenuName) values('Customer')"
        IMenu += "Insert Into User1 (MenuName) values('Grafik')"
        IMenu += "Insert Into User1 (MenuName) values('Knowledge Base')"
        Try
            com = New SqlCommand(IMenu, con)
            con.Open()
            com.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception

        End Try

        sql = "insert into mApplikasi(Company_Name, Email_Address, Phone, Address, Ticket, Email, Twitter, Facebook, Fax, Chat, Sms, Telegram, Instagram, License, Login_Type, Date_Create, User_Create) " & _
              "values('" & txt_company_name.Text & "','" & txt_email.Text & "','" & txt_phone.Text & "','" & txt_address.Text & "','" & Ticket & "','" & Email & "','" & Twitter & "','" & Facebook & "','" & Fax & "'," & _
              "'" & Chat & "','" & Sms & "','" & Telegram & "','" & Instagram & "','" & txt_license.Text & "', '" & cmb_status.Value & "', GETDATE(),'Support')"
        com = New SqlCommand(sql, con)
        con.Open()
        com.ExecuteNonQuery()
        con.Close()

        insert_sub_menu()
        div_customer.Visible = False
        div_setting.Visible = False
        div_license.Visible = False
        div_generate.Visible = True
        btn_generate.Visible = True
        btn_finis.Visible = False
        btn_simpan.Visible = False

    End Sub

    Sub insert_sub_menu()
        strsql = "select * from mApplikasi"
        dr = Proses.ExecuteReader(strsql)
        If dr.Read Then
            VTicket = dr("Ticket")
            VEmail = dr("Email")
            VTwitter = dr("Twitter")
            VFacebook = dr("Facebook")
            VFax = dr("Fax")
            VChat = dr("Chat")
            VSms = dr("Sms")
            VTelegram = dr("Telegram")
            VInstagram = dr("Instagram")

            Dim MenuID As String
            sql = "SELECT menuid, menuName FROM User1 Where menuname='Master data'"
            Sqldr = Proses.ExecuteReader(sql)
            If Sqldr.Read Then
                MenuID = Sqldr("MenuID")
                If VTicket = "TRUE" Then
                    ISubMenu += "Insert into User2 (menuID, SubMenuName) values ('" & MenuID & "','Brand')"
                    ISubMenu += "Insert into User2 (menuID, SubMenuName) values ('" & MenuID & "','Product')"
                    ISubMenu += "Insert into User2 (menuID, SubMenuName) values ('" & MenuID & "','Problem')"
                    ISubMenu += "Insert into User2 (menuID, SubMenuName) values ('" & MenuID & "','Status')"
                    ISubMenu += "Insert into User2 (menuID, SubMenuName) values ('" & MenuID & "','Email Alert')"
                    ISubMenu += "Insert into User2 (menuID, SubMenuName) values ('" & MenuID & "','Email Karyawan')"
                    IlevelUser += "Insert Into mLevelUser(Name, Description) Values('layer1','Agent')"
                    IlevelUser += "Insert Into mLevelUser(Name, Description) Values('layer2','Case Unit')"
                    IlevelUser += "Insert Into mLevelUser(Name, Description) Values('layer3','PIC')"
                    IlevelUser += "Insert Into mLevelUser(Name, Description) Values('Admin','Administrator')"
                    IlevelUser += "Insert Into mLevelUser(Name, Description) Values('Supervisor','Supervisor')"
                Else
                    ISubMenu += "Insert into User2 (menuID, SubMenuName) values ('" & MenuID & "','Source Type')"
                    ISubMenu += "Insert into User2 (menuID, SubMenuName) values ('" & MenuID & "','Group Type')"
                    ISubMenu += "Insert into User2 (menuID, SubMenuName) values ('" & MenuID & "','Category')"
                    ISubMenu += "Insert into User2 (menuID, SubMenuName) values ('" & MenuID & "','Sub Category')"
                    ISubMenu += "Insert into User2 (menuID, SubMenuName) values ('" & MenuID & "','Data Karyawan')"
                    IlevelUser += "Insert Into mLevelUser(Name, Description) Values('layer1','Agent')"
                    IlevelUser += "Insert Into mLevelUser(Name, Description) Values('Admin','Administrator')"
                    IlevelUser += "Insert Into mLevelUser(Name, Description) Values('Supervisor','Supervisor')"
                End If
                Sqldr.Close()
            Else
            End If
            ISubMenu += "Insert into User2 (menuID, SubMenuName) values ('" & MenuID & "','Transaction Type')"
            Sqldr.Close()

            sql = "SELECT menuid FROM User1 Where menuname='Ticket'"
            Sqldr = Proses.ExecuteReader(sql)
            If Sqldr.Read Then
                MenuID = Sqldr("MenuID")
                If VTicket = "TRUE" Then
                    ISubMenu += "Insert into User2 (menuID, SubMenuName) values ('" & MenuID & "','Create Ticket')"
                    ISubMenu += "Insert into User2 (menuID, SubMenuName) values ('" & MenuID & "','Ticket History')"
                Else
                End If
                Sqldr.Close()
            Else
            End If
            Sqldr.Close()

            sql = "SELECT menuid FROM User1 Where menuname='Channel'"
            Sqldr = Proses.ExecuteReader(sql)
            If Sqldr.Read Then
                MenuID = Sqldr("MenuID")
                If VEmail = "TRUE" Then
                    ISubMenu += "Insert into User2 (menuID, SubMenuName) values ('" & MenuID & "','Email')"
                Else
                End If
                If VTwitter = "TRUE" Then
                    ISubMenu += "Insert into User2 (menuID, SubMenuName) values ('" & MenuID & "','Twitter')"
                    ISubMenu += "Insert into User2 (menuID, SubMenuName) values ('" & MenuID & "','Twitter History')"
                    ISubMenu += "Insert into User2 (menuID, SubMenuName) values ('" & MenuID & "','Twitter Keyword Setting')"
                Else
                End If
                If VFacebook = "TRUE" Then
                    ISubMenu += "Insert into User2 (menuID, SubMenuName) values ('" & MenuID & "','Facebook')"
                    ISubMenu += "Insert into User2 (menuID, SubMenuName) values ('" & MenuID & "','Facebook History')"
                    ISubMenu += "Insert into User2 (menuID, SubMenuName) values ('" & MenuID & "','Facebook Keyword Setting')"
                Else
                End If
                If VFax = "TRUE" Then
                    ISubMenu += "Insert into User2 (menuID, SubMenuName) values ('" & MenuID & "','Fax')"
                Else
                End If
                If VChat = "TRUE" Then
                    ISubMenu += "Insert into User2 (menuID, SubMenuName) values ('" & MenuID & "','Chat')"
                Else
                End If
                If VSms = "TRUE" Then
                    ISubMenu += "Insert into User2 (menuID, SubMenuName) values ('" & MenuID & "','Sms')"
                Else
                End If
                If VTelegram = "TRUE" Then
                    ISubMenu += "Insert into User2 (menuID, SubMenuName) values ('" & MenuID & "','Telegram')"
                Else
                End If
                If VInstagram = "TRUE" Then
                    ISubMenu += "Insert into User2 (menuID, SubMenuName) values ('" & MenuID & "','Instagram')"
                Else
                End If
                Sqldr.Close()
            Else
            End If
            Sqldr.Close()

            sql = "SELECT menuid FROM User1 Where menuname='Management User'"
            Sqldr = Proses.ExecuteReader(sql)
            If Sqldr.Read Then
                MenuID = Sqldr("MenuID")
                ISubMenu += "Insert into User2 (menuID, SubMenuName) values ('" & MenuID & "','Add User')"
                ISubMenu += "Insert into User2 (menuID, SubMenuName) values ('" & MenuID & "','User Setting Previledge')"
            Else
            End If
            Sqldr.Close()

            sql = "SELECT menuid FROM User1 Where menuname='Report'"
            Sqldr = Proses.ExecuteReader(sql)
            If Sqldr.Read Then
                MenuID = Sqldr("MenuID")
                ISubMenu += "Insert into User2 (menuID, SubMenuName) values ('" & MenuID & "','Report Satu')"
                ISubMenu += "Insert into User2 (menuID, SubMenuName) values ('" & MenuID & "','Report Dua')"
            Else
            End If
            Sqldr.Close()
            Try
                com = New SqlCommand(ISubMenu, con)
                con.Open()
                com.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
            Try
                com = New SqlCommand(IlevelUser, con)
                con.Open()
                com.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
        End If
        dr.Close()
    End Sub

    Private Sub btn_generate_Click(sender As Object, e As EventArgs) Handles btn_generate.Click
        Dim MenuID, SubMenuID, Insr, STicket As String
        Dim i As Integer
        Dim Name As String
        Dim strMenu As String = ""
        Dim strSubMenu As String = ""
        Dim strArrMenu() As String
        Dim strArrSubMenu() As String

        Dim N As Integer = txt_license.Text

        'Dim IAgent As String = ""
        'strsql = "select * from mApplikasi"
        'dr = Proses.ExecuteReader(strsql)
        'If dr.Read Then
        '    STicket = dr("Ticket").ToString
        'End If
        'dr.Close()
        'If STicket = "TRUE" Then

        '    IAgent += "Insert Into user3"
        'Else

        'End If

        Dim LVID As String
        sql = "select LevelUserID, Name from mleveluser where Name='layer1'"
        Sqldr = Proses.ExecuteReader(sql)
        If Sqldr.Read Then
            LVID = Sqldr("LevelUserID")
        End If
        Sqldr.Close()

        strsql = "select user1.MenuID, user2.SubMenuID from User1 left outer join User2 on user1.MenuID = user2.MenuID"
        Sqldr = Proses.ExecuteReader(strsql)
        While Sqldr.Read
            MenuID &= Sqldr("menuID") & ";"
            SubMenuID &= Sqldr("SubMenuID") & ";"
        End While
        Sqldr.Close()

        strMenu = MenuID
        strArrMenu = strMenu.Split(";")

        strSubMenu = SubMenuID
        strArrSubMenu = strSubMenu.Split(";")
        For j = 0 To N
            For i = 0 To strArrSubMenu.Count - 2
                Insr = "Insert Into User3 (UserID, MenuID, SubMenuID, LevelUserID, Status) Values ('" & "Agent-" & j & "','" & strArrMenu(i) & "','" & strArrSubMenu(i) & "','" & LVID & "', 'TRUE')"
                com = New SqlCommand(Insr, con)
                con.Open()
                com.ExecuteNonQuery()
                con.Close()
            Next
        Next

        div_setting.Visible = False
        div_license.Visible = False
        div_generate.Visible = True
        sql_user.SelectCommand = "select distinct userid from user3"
        btn_finis.Visible = True
        btn_simpan.Visible = False
        div_customer.Visible = False
        div_setting.Visible = False
        div_license.Visible = False
        hr_satu.Visible = False
        hr_dua.Visible = False
        hr_tiga.Visible = False
        btn_generate.Visible = False
    End Sub

    Sub bener()
        Dim MenuID, SubMenuID, Insr As String
        Dim i As Integer
        Dim N As Integer = 3
        Dim Name As String
        Dim strCheckBox As String = ""
        Dim strArr() As String
        sql = "select menuID from user1"
        Sqldr = Proses.ExecuteReader(sql)
        While Sqldr.Read()
            MenuID &= Sqldr("menuID") & ";"
        End While
        Sqldr.Close()
        strCheckBox = MenuID
        strArr = strCheckBox.Split(";")
        For j = 0 To 3
            For i = 0 To strArr.Count - 2
                Insr = "Insert Into User3 (UserID, MenuID, SubMenuID) Values ('" & j & "','" & strArr(i) & "','001')"
                com = New SqlCommand(Insr, con)
                con.Open()
                com.ExecuteNonQuery()
                con.Close()
            Next
        Next
    End Sub

    Private Sub gv_app_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles gv_app.RowUpdating
        Dim value As String = e.NewValues("userid")
        Dim xvalue As String = e.OldValues("userid")
        sql_user.UpdateCommand = "update user3 set UserID=@userid where UserID='" & xvalue & "'"
        div_generate.Visible = True
        sql_user.SelectCommand = "select distinct userid from user3"
    End Sub

    Private Sub btn_finis_Click(sender As Object, e As EventArgs) Handles btn_finis.Click
        If cmb_status.Text = "LDAP" Then
            Response.Redirect("~/login.aspx")
        Else
            Response.Redirect("uat.aspx")
        End If
    End Sub

End Class