Imports System
Imports System.Data
Imports System.Data.SqlClient
Public Class Ticket
    Inherits System.Web.UI.MasterPage

    Dim value As String = ""
    Dim Proses As New ClsConn
    Dim sqldr As SqlDataReader
    Dim sql As String
    Dim VTicket, VTwitter, VFacebook, VEmail, VFax, Vchat, VSms As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lbl_user_login.Text = Session("NameKaryawan")
        lbl_user_login_detail.Text = Session("username")
        lbl_user_login_detail_nama.Text = Session("NameKaryawan")
        count_dispatch()
        session_master()
        sql = "select * from mApplikasi"
        sqldr = Proses.ExecuteReader(sql)
        If sqldr.Read Then
            VTicket = sqldr("Ticket").ToString
            VTwitter = sqldr("Twitter").ToString
            VFacebook = sqldr("Facebook").ToString
            VEmail = sqldr("Email").ToString
            VFax = sqldr("Fax").ToString
            Vchat = sqldr("Chat").ToString
            VSms = sqldr("Sms").ToString
        End If
        sqldr.Close()
        If VTicket = "Yes" Then
            sql = "select * from MTrustee where LEVEL_USER_SBG='" & Session("LoginType") & "'"
            sqldr = Proses.ExecuteReader(sql)
            While sqldr.Read
                If sqldr("MT") = "TRUE" Then
                    div_menu_master_table.Visible = True
                Else
                    div_menu_master_table.Visible = False
                End If
                If sqldr("MT_STY") = "TRUE" Then
                    div_master_sourcetype.Visible = True
                Else
                    div_master_sourcetype.Visible = False
                End If
                If sqldr("MT_GTY") = "TRUE" Then
                    div_master_grouptype.Visible = True
                Else
                    div_master_grouptype.Visible = False
                End If
                If sqldr("MT_TTY") = "TRUE" Then
                    div_master_Transaction_Type.Visible = True
                Else
                    div_master_Transaction_Type.Visible = False
                End If
                If sqldr("MT_CON") = "TRUE" Then
                    div_master_calltypeone.Visible = True
                Else
                    div_master_calltypeone.Visible = False
                End If
                If sqldr("MT_CTW") = "TRUE" Then
                    div_master_calltypetwo.Visible = True
                Else
                    div_master_calltypetwo.Visible = False
                End If
                If sqldr("MT_CTR") = "TRUE" Then
                    div_master_calltypetre.Visible = True
                Else
                    div_master_calltypetre.Visible = False
                End If
                If sqldr("MT_STS") = "TRUE" Then
                    div_master_status.Visible = True
                Else
                    div_master_status.Visible = False
                End If
                If sqldr("MT_DKY") = "TRUE" Then
                    div_master_karyawan.Visible = True
                Else
                    div_master_karyawan.Visible = False
                End If
                If sqldr("MT_EAL") = "TRUE" Then
                    div_master_email_alert.Visible = True
                Else
                    div_master_email_alert.Visible = False
                End If
                If sqldr("MT_EAD") = "TRUE" Then
                    div_master_email_address.Visible = True
                Else
                    div_master_email_address.Visible = False
                End If
                If sqldr("DS") = "TRUE" Then
                    div_menu_dashboard.Visible = True
                Else
                    div_menu_dashboard.Visible = False
                End If
                If sqldr("CH") = "TRUE" Then
                    div_menu_channel.Visible = True
                Else
                    div_menu_channel.Visible = False
                End If

                If VEmail = "Yes" Then
                    If sqldr("CH_EMA") = "TRUE" Then
                        div_channel_email.Visible = True
                    Else
                        div_channel_email.Visible = False
                    End If
                Else
                End If
                If VTwitter = "Yes" Then
                    If sqldr("CH_TWT") = "TRUE" Then
                        div_channel_twitter.Visible = True
                    Else
                        div_channel_twitter.Visible = False
                    End If
                    If sqldr("CH_TKS") = "TRUE" Then
                        div_twitter_keyword_setting.Visible = True
                    Else
                        div_twitter_keyword_setting.Visible = False
                    End If
                Else
                End If
                If VFacebook = "Yes" Then
                    If sqldr("CH_FCB") = "TRUE" Then
                        div_channel_facebook.Visible = True
                    Else
                        div_channel_facebook.Visible = False
                    End If
                    If sqldr("CH_FKS") = "TRUE" Then
                        div_facebook_keyword_setting.Visible = True
                    Else
                        div_facebook_keyword_setting.Visible = False
                    End If
                Else
                End If
                If VFax = "Yes" Then
                    If sqldr("CH_FAX") = "TRUE" Then
                        div_channel_fax.Visible = True
                    Else
                        div_channel_fax.Visible = False
                    End If
                Else
                End If
                If VSms = "Yes" Then
                    If sqldr("CH_SMS") = "TRUE" Then
                        div_channel_sms.Visible = True
                    Else
                        div_channel_sms.Visible = False
                    End If
                Else
                End If
                If Vchat = "Yes" Then
                    If sqldr("CH_CHA") = "TRUE" Then
                        div_channel_chat.Visible = True
                    Else
                        div_channel_chat.Visible = False
                    End If
                Else
                End If
                If sqldr("TIK") = "TRUE" Then
                    div_menu_ticket.Visible = True
                Else
                    div_menu_ticket.Visible = False
                End If
                If sqldr("TK_CRT") = "TRUE" Then
                    div_ticket_create.Visible = True
                Else
                    div_ticket_create.Visible = False
                End If
                If sqldr("TK_THS") = "TRUE" Then
                    div_ticket_history.Visible = True
                Else
                    div_ticket_history.Visible = False
                End If
                If sqldr("UM") = "TRUE" Then
                    div_menu_Management_user.Visible = True
                Else
                    div_menu_Management_user.Visible = False
                End If
                If sqldr("UM_ADS") = "TRUE" Then
                    div_user_add.Visible = True
                Else
                    div_user_add.Visible = False
                End If
                If sqldr("UM_SUP") = "TRUE" Then
                    div_user_setting.Visible = True
                Else
                    div_user_setting.Visible = False
                End If
                If sqldr("RP") = "TRUE" Then
                    div_menu_report.Visible = True
                Else
                    div_menu_report.Visible = False
                End If
                If sqldr("CT") = "TRUE" Then
                    div_menu_customer.Visible = True
                Else
                    div_menu_customer.Visible = False
                End If
                If sqldr("GF") = "TRUE" Then
                    div_menu_grafik.Visible = True
                Else
                    div_menu_grafik.Visible = False
                End If
                If sqldr("KB") = "TRUE" Then
                    div_menu_knowledge.Visible = True
                Else
                    div_menu_knowledge.Visible = False
                End If                
            End While
            sqldr.Close()
        Else

        End If
    End Sub

    Sub count_dispatch()
        If Session("LoginType") = "Admin" Then
            sql = "select COUNT(id) as DataMasuk from tTicket"
        Else
            sql = "select COUNT(id) as DataMasuk from tTicket where (UserCreate='" & Session("username") & "' or dispatch_user='" & Session("username") & "') and Status='Open' "
        End If
        sqldr = Proses.ExecuteReader(sql)
        If sqldr.HasRows Then
            sqldr.Read()
            lbl_count_dispatch.Text = sqldr("DataMasuk").ToString
        End If
        sqldr.Close()
        lbl_keterangan.Text = "You have " & lbl_count_dispatch.Text & " ticket dispatch"
        If Session("LoginType") = "Admin" Then
            sql = "select top 5 tTicket.TicketNumber, tTicket.DateCreate, mCustomer.NamaPerusahaan " & _
                  "from tTicket inner join mCustomer on tTicket.NIK = mCustomer.CustomerID "
        Else
            sql = "select top 5 tTicket.TicketNumber, tTicket.DateCreate, mCustomer.NamaPerusahaan " & _
                  "from tTicket inner join mCustomer on tTicket.NIK = mCustomer.CustomerID where (tTicket.UserCreate='" & Session("username") & "' or tTicket.dispatch_user='" & Session("username") & "') and tTicket.Status='Open'"
        End If
        sqldr = Proses.ExecuteReader(sql)
        While sqldr.Read()
            value &=
                "<a class='clearfix' href='utama.aspx?old=2&id=" & sqldr("TicketNumber") & "'>" & _
                         "<div class='detail'>" & _
                         "<strong>" & sqldr("TicketNumber") & "</strong>" & _
                         "<p class='no-margin'> " & sqldr("NamaPerusahaan") & "" & _
                         "</p> " & _
                         "<small class='text-muted'><i class='fa fa-check text-success'></i>&nbsp;" & sqldr("DateCreate") & "</small>" & _
                         "</div>" & _
                        "</a>"
        End While
        sqldr.Close()
        ltr_ticket_dispatch.Text = value
    End Sub

    Sub session_master()
        Session("menu") = Request.QueryString("page")
       If Session("menu") = "mst_tt" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_menu_master_table")
            ul = Page.Master.FindControl("div_master_Transaction_Type")
            li.Attributes.Add("class", "openable active")
            ul.Attributes.Add("class", "active")
        ElseIf Session("menu") = "mst_ctone" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_menu_master_table")
            ul = Page.Master.FindControl("div_master_calltypeone")
            li.Attributes.Add("class", "openable active")
            ul.Attributes.Add("class", "active")
        ElseIf Session("menu") = "mst_cttwo" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_menu_master_table")
            ul = Page.Master.FindControl("div_master_calltypetwo")
            li.Attributes.Add("class", "openable active")
            ul.Attributes.Add("class", "active")
        ElseIf Session("menu") = "mst_cttre" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_menu_master_table")
            ul = Page.Master.FindControl("div_master_calltypetre")
            li.Attributes.Add("class", "openable active")
            ul.Attributes.Add("class", "active")
        ElseIf Session("menu") = "mst_st" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_menu_master_table")
            ul = Page.Master.FindControl("div_master_sourcetype")
            li.Attributes.Add("class", "openable active")
            ul.Attributes.Add("class", "active")
        ElseIf Session("menu") = "mst_gt" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_menu_master_table")
            ul = Page.Master.FindControl("div_master_grouptype")
            li.Attributes.Add("class", "openable active")
            ul.Attributes.Add("class", "active")
        ElseIf Session("menu") = "mst_ss" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_menu_master_table")
            ul = Page.Master.FindControl("div_master_status")
            li.Attributes.Add("class", "openable active")
            ul.Attributes.Add("class", "active")
        ElseIf Session("menu") = "mst_ky" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_menu_master_table")
            ul = Page.Master.FindControl("div_master_karyawan")
            li.Attributes.Add("class", "openable active")
            ul.Attributes.Add("class", "active")
        ElseIf Session("menu") = "mst_eal" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_menu_master_table")
            ul = Page.Master.FindControl("div_master_email_alert")
            li.Attributes.Add("class", "openable active")
            ul.Attributes.Add("class", "active")
        ElseIf Session("menu") = "mst_ead" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_menu_master_table")
            ul = Page.Master.FindControl("div_master_email_address")
            li.Attributes.Add("class", "openable active")
            ul.Attributes.Add("class", "active")
        ElseIf Session("menu") = "dashboard" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_menu_dashboard")
            li.Attributes.Add("class", "active")
        ElseIf Session("menu") = "todolist" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_menu_todolist")
            li.Attributes.Add("class", "active")
        ElseIf Session("menu") = "twitter" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim li_sub As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_menu_channel")
            ul = Page.Master.FindControl("div_channel_twitter")
            li_sub = Page.Master.FindControl("div_channel_twitter_inbox")
            li.Attributes.Add("class", "openable active")
            ul.Attributes.Add("class", "openable active")
            li_sub.Attributes.Add("class", "active")
        ElseIf Session("menu") = "twt_ks" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim li_sub As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_menu_channel")
            ul = Page.Master.FindControl("div_channel_twitter")
            li_sub = Page.Master.FindControl("div_twitter_keyword_setting")
            li.Attributes.Add("class", "openable active")
            ul.Attributes.Add("class", "openable active")
            li_sub.Attributes.Add("class", "active")
        ElseIf Session("menu") = "fcb_ks" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim li_sub As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_menu_channel")
            ul = Page.Master.FindControl("div_channel_facebook")
            li_sub = Page.Master.FindControl("div_facebook_keyword_setting")
            li.Attributes.Add("class", "openable active")
            ul.Attributes.Add("class", "openable active")
            li_sub.Attributes.Add("class", "active")
        ElseIf Session("menu") = "tk_create" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_menu_ticket")
            ul = Page.Master.FindControl("div_ticket_create")
            li.Attributes.Add("class", "openable active")
            ul.Attributes.Add("class", "active")
        ElseIf Session("menu") = "tk_history" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_menu_ticket")
            ul = Page.Master.FindControl("div_ticket_history")
            li.Attributes.Add("class", "openable active")
            ul.Attributes.Add("class", "active")
        ElseIf Session("menu") = "usr_add" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_menu_Management_user")
            ul = Page.Master.FindControl("div_user_add")
            li.Attributes.Add("class", "openable active")
            ul.Attributes.Add("class", "active")
        ElseIf Session("menu") = "usr_set" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_menu_Management_user")
            ul = Page.Master.FindControl("div_user_setting")
            li.Attributes.Add("class", "openable active")
            ul.Attributes.Add("class", "active")
        ElseIf Session("menu") = "customer" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_menu_customer")
            li.Attributes.Add("class", "active")            
        End If
    End Sub
End Class