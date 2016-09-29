Imports System
Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.IO
Imports System.Configuration
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Newtonsoft.Json.Linq
Imports System.Timers
Imports System.Data.OleDb
Imports System.Net
Imports System.Net.Sockets
Imports System.Windows.Forms
Public Class IndomaretAction
    Inherits System.Web.UI.Page
    Dim Comm As New SqlCommand
    Dim Com As SqlCommand
    Dim Dr As SqlDataReader
    Dim weberConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("mpduiConnectionString").ConnectionString)
    Dim strCon As String = ConfigurationManager.ConnectionStrings("mpduiConnectionString").ConnectionString
    Dim senderX As New Socket(AddressFamily.InterNetwork, _
    SocketType.Stream, ProtocolType.Tcp)
    Dim ValueSocket As String
    Dim UpdateTrx As String
    Dim CNumberAsking, MprIDAsking As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ProcessAjaxRequest()
        End If
    End Sub
    Private Sub ProcessAjaxRequest()
        If Request.QueryString("Save") = "1" Then
            If Request.QueryString("ket") = "updateView" Then
                updateTrxChannel()
            ElseIf Request.QueryString("ket") = "updateViewHeader" Then
                updateViewHeader()
            ElseIf Request.QueryString("ket") = "updateViewMpr" Then
                updateViewMpr()
            ElseIf Request.QueryString("ket") = "sendSocket" Then
                sendSocket()
            ElseIf Request.QueryString("ket") = "sendSocketAsking" Then
                sendSocketAsking()
            ElseIf Request.QueryString("ket") = "InsertHeaderChannel" Then
                InsertHeaderChannel()
            ElseIf Request.QueryString("ket") = "UpdateHeaderChannel" Then
                updateViewHeader()
            ElseIf Request.QueryString("ket") = "UpdateChanges" Then
                UpdateHeaderChannel()
            ElseIf Request.QueryString("ket") = "DeleteHeaderChannel" Then

            ElseIf Request.QueryString("ket") = "DeleteChannel" Then
                DeleteHeaderChannel()
            End If
        End If
        If Request.QueryString("Update") = "1" Then
            If Request.QueryString("ket") = "UpdateTrxMPR" Then
                UpdateSelect()
            ElseIf Request.QueryString("ket") = "UpdateTrxAction" Then
                UpdateActionTrxMPR()
            Else
            End If
        End If
        If Request.QueryString("Update") = "4" Then
            If Request.QueryString("ket") = "UpdateUserId" Then
                UpdateUserId()
            ElseIf Request.QueryString("ket") = "UpdateUserTrustee" Then
                UpdateUserTrustee()
            Else
            End If
        End If
        If Request.QueryString("SaveUser") = "1" Then
            If Request.QueryString("ket") = "InsertMsUser" Then
                InsertMsUser()
            Else
            End If
        End If
    End Sub

    Private Sub InsertMsUser()
        Dim sr As New System.IO.StreamReader(Request.InputStream)
        Dim line As String = ""
        line = sr.ReadToEnd()

        Dim lineJson As String = line
        Dim cleanDataCTI As String = lineJson.Replace("""", "\""")
        Dim fixCleanDataCTI As String = cleanDataCTI.Replace("/", "\/")
        Dim jo As JObject = JObject.Parse(fixCleanDataCTI)

        Dim UserName As String = Replace(jo("UserName").ToString, """", "")
        Dim Password As String = Replace(jo("Password").ToString, """", "")
        Dim LevelUser As String = Replace(jo("Otorisasi").ToString, """", "")
        Dim UnitKerja As String = Replace(jo("MprID").ToString, """", "")

        Dim HslCount As String
        Dim Count As String = "select count(UserID) As UserAda from msuser where UserName='" & UserName & "' And LevelUser='" & LevelUser & "'"
        Com = New SqlCommand(Count, weberConnection)
        weberConnection.Open()
        Dr = Com.ExecuteReader()
        If Dr.Read() Then
            HslCount = Dr("UserAda").ToString
        End If
        Dr.Close()
        weberConnection.Close()
        If HslCount = "0" Then
            Dim INSERTUSERT As String = "INSERT INTO MSUSER (USERNAME, PASSWORD, HAK, UnitKerja) VALUES ('" & UserName & "','" & Password & "','" & LevelUser & "','" & UnitKerja & "')"
            Com = New SqlCommand(INSERTUSERT, weberConnection)
            weberConnection.Open()
            Com.ExecuteNonQuery()
            weberConnection.Close()
            Response.Write(DirectCast("Success", String))
        Else
            Response.Write(DirectCast("User Already Exits", String))
        End If


    End Sub

    Private Sub sendSocket()

        Dim sr As New System.IO.StreamReader(Request.InputStream)
        Dim line As String = ""
        line = sr.ReadToEnd()

        Dim lineJson As String = line
        Dim cleanDataCTI As String = lineJson.Replace("""", "\""")
        Dim fixCleanDataCTI As String = cleanDataCTI.Replace("/", "\/")
        Dim jo As JObject = JObject.Parse(fixCleanDataCTI)

        Dim strCommand As String = Replace(jo("sCmd").ToString, """", "")
        Dim intPort As Integer = Replace(jo("iPort").ToString, """", "")
        'Dim GetHeaderChannelID As String = Replace(jo("HeaderChannelID").ToString, """", "")
        'Dim GetCNumber As String = Replace(jo("CNumber").ToString, """", "")
        'Dim GetCDesc As String = Replace(jo("CDesc").ToString, """", "")
        'Dim GetTCPPort As String = Replace(jo("iPort").ToString, """", "")
        'Dim intPort As Integer = 8800
        If strCommand = 1 Then
            strCommand = "HTTP_CMD_SEND_FILE_START"
        ElseIf strCommand = 2 Then
            strCommand = "HTTP_CMD_SEND_FILE_STOP"
        ElseIf strCommand = 3 Then
            strCommand = "HTTP_CMD_NUM_OF_PART"
        ElseIf strCommand = 4 Then
            strCommand = "HTTP_CMD_UPDATE_DATA"
        End If
        Dim Filelist As String

        Try

            Dim bytes(1024) As Byte

            Dim ipHostInfo As IPHostEntry = Dns.Resolve(Dns.GetHostName())

            Dim ipAddress As IPAddress = ipAddress.Parse("127.0.1.1")

            'port dibuat dinamis sesuai header channel
            'di semua exec socket
            Dim remoteEP As New IPEndPoint(ipAddress, intPort)

            Try
                senderX.Connect(remoteEP)

                ' Encode the data string into a byte array.
                Dim msg As Byte() = _
                    Encoding.ASCII.GetBytes(strCommand)

                ' Send the data through the socket.

                Dim bytesSent As Integer = senderX.Send(msg)

                ' Receive the response from the remote device.
                Dim bytesRec As Integer = senderX.Receive(bytes)


                senderX.GetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.KeepAlive, 1)
                ''Response.Write(DirectCast("{0}" & Encoding.ASCII.GetString(bytes, 0, bytesRec) & "", String))
                'ValueSocket = DirectCast("{0}" & Encoding.ASCII.GetString(bytes, 0, bytesRec) & "", String)
                ValueSocket = DirectCast(Encoding.ASCII.GetString(bytes, 0, bytesRec) & "", String)
                Response.Write(ValueSocket)
                If strCommand = "HTTP_CMD_NUM_OF_PART" Then
                    'Dim GetTrxChannelID As String = Replace(jo("HeaderChannelID").ToString, """", "")
                    Dim UpdateTrx As String = "Update HeaderChannel set JumlahPart='" & ValueSocket & "' where HeaderChannelID='1' "
                    Com = New SqlCommand(UpdateTrx, weberConnection)
                    weberConnection.Open()
                    Com.ExecuteNonQuery()
                    weberConnection.Close()
                Else
                End If



            Catch
                Response.Write(String.Format("Socket failed to connect {0}<br>", senderX.RemoteEndPoint))
            End Try

        Catch ex As Exception
            Response.Write(DirectCast("", String))
        Finally

        End Try
    End Sub

    Private Sub updateViewHeader()
        'data passed in as JSON format
        Dim sr As New System.IO.StreamReader(Request.InputStream)
        Dim line As String = ""
        line = sr.ReadToEnd()

        Dim lineJson As String = line
        Dim cleanDataCTI As String = lineJson.Replace("""", "\""")
        Dim fixCleanDataCTI As String = cleanDataCTI.Replace("/", "\/")
        Dim jo As JObject = JObject.Parse(fixCleanDataCTI)
        Dim strCommand As String = Replace(jo("sCmd").ToString, """", "")
        Dim chnlIDstr As String = Replace(jo("chnlID").ToString, """", "")
        Dim GetCNumber As String = Replace(jo("ChannelNumber").ToString, """", "")
        'Dim intPort As Integer = Replace(jo("iPort").ToString, """", "")
        'Dim GetCNumber As String = Replace(jo("ChannelNumber").ToString, """", "")
        Dim Filelist As String
        Try
            Dim Com As SqlCommand
            Dim Dr As SqlDataReader
            Dim sqlCekMailKirim As String = "select HeaderChannelID, MprId, CNumber, CDescription, GroupAddress, " & _
                                "GroupPort, MaxBandwith, TTL, NumOfRetry, RetryInterval, " & _
                                "Multimedia, StatusChannel,convert(varchar,eExecDateTime,101) as eExecDateTime,ePacketSize,eFDBuffer, " & _
                                "eUniqueID,eFilename,eSendingInterval,eLoopback, TCPPortListener FROM HeaderChannel where HeaderChannelID = '" & chnlIDstr & "'"
            Com = New SqlCommand(sqlCekMailKirim, weberConnection)
            weberConnection.Open()
            Dr = Com.ExecuteReader()
            Dr.Read()
            Filelist = Dr("HeaderChannelID").ToString & "|" & Dr("MprId").ToString & "|" & Dr("CNumber").ToString & "|" & _
                 Dr("CDescription").ToString & "|" & Dr("GroupAddress").ToString & "|" & _
                 Dr("GroupPort").ToString & "|" & Dr("MaxBandwith").ToString & "|" & _
                 Dr("TTL").ToString & "|" & Dr("NumOfRetry").ToString & "|" & _
                 Dr("RetryInterval").ToString & "|" & Dr("Multimedia").ToString & "|" & _
                 Dr("StatusChannel").ToString & "|" & Dr("eExecDateTime").ToString & "|" & _
                 Dr("ePacketSize").ToString & "|" & Dr("eFDBuffer").ToString & "|" & _
                 Dr("eUniqueID").ToString & "|" & Dr("eFilename").ToString & "|" & _
                 Dr("eSendingInterval").ToString & "|" & Dr("eLoopback").ToString & "|" & Dr("TCPPortListener").ToString
            Dr.Close()
            weberConnection.Close()
            Response.Write(DirectCast(Filelist, String))
        Catch ex As Exception
            Response.Write(DirectCast("", String))
        Finally
        End Try

    End Sub

    Private Sub updateTrxChannel()
        'data passed in as JSON format
        Dim sr As New System.IO.StreamReader(Request.InputStream)
        Dim line As String = ""
        line = sr.ReadToEnd()

        Dim lineJson As String = line
        Dim cleanDataCTI As String = lineJson.Replace("""", "\""")
        Dim fixCleanDataCTI As String = cleanDataCTI.Replace("/", "\/")
        Dim jo As JObject = JObject.Parse(fixCleanDataCTI)
        Dim chnlIDstr As String = Replace(jo("chnlID").ToString, """", "")

        Dim Filelist As String

        Try

            Dim Com As SqlCommand
            Dim Dr As SqlDataReader

            Dim sqlCekMailKirim As String = "SELECT TrxChannelID, CNumber, FileList, PackageIdentity, DeliverySchedule, StatusTrxChannel, PackageDesc from TrxChannel where TrxChannelID='" & chnlIDstr & "'"
            Com = New SqlCommand(sqlCekMailKirim, weberConnection)
            weberConnection.Open()
            Dr = Com.ExecuteReader()
            Dr.Read()
            Filelist = Dr("TrxChannelID").ToString & "|" & Dr("CNumber").ToString & "|" & Dr("FileList").ToString & "|" & Dr("PackageIdentity").ToString & "|" & Dr("DeliverySchedule").ToString & "|" & Dr("StatusTrxChannel").ToString & "|" & Dr("PackageDesc").ToString
            Dr.Close()
            weberConnection.Close()

            Response.Write(DirectCast(Filelist, String))
        Catch ex As Exception
            Response.Write(DirectCast("", String))
        Finally
        End Try

    End Sub

    Private Sub updateViewMpr()
        'data passed in as JSON format
        Dim sr As New System.IO.StreamReader(Request.InputStream)
        Dim line As String = ""
        line = sr.ReadToEnd()

        Dim lineJson As String = line
        Dim cleanDataCTI As String = lineJson.Replace("""", "\""")
        Dim fixCleanDataCTI As String = cleanDataCTI.Replace("/", "\/")
        Dim jo As JObject = JObject.Parse(fixCleanDataCTI)
        Dim chnlIDstr As String = Replace(jo("chnlID").ToString, """", "")

        Dim Filelist As String

        Try

            Dim Com As SqlCommand
            Dim Dr As SqlDataReader

            Dim sqlCekMailKirim As String = "SELECT [ID],[MprID], [SiteName], [SiteAddress] FROM [HeaderMPR] where ID='" & chnlIDstr & "'"
            Com = New SqlCommand(sqlCekMailKirim, weberConnection)
            weberConnection.Open()
            Dr = Com.ExecuteReader()
            Dr.Read()
            Filelist = Dr("ID").ToString & "|" & Dr("MprID").ToString & "|" & Dr("SiteName").ToString & "|" & Dr("SiteAddress").ToString
            Dr.Close()
            weberConnection.Close()

            Response.Write(DirectCast(Filelist, String))
        Catch ex As Exception
            Response.Write(DirectCast("", String))
        Finally
        End Try

    End Sub

    Private Sub InsertHeaderChannel()
        Dim sr As New System.IO.StreamReader(Request.InputStream)
        Dim line As String = ""
        line = sr.ReadToEnd()
        Dim lineJson As String = line
        Dim cleanDataSuctomer As String = lineJson.Replace("""", "\""")
        Dim cleanDataSuctomer1 As String = cleanDataSuctomer.Replace("/", "\/")
        Dim jo As JObject = JObject.Parse(cleanDataSuctomer1)
        Dim GetCNumber As String = Replace(jo("ChannelNumber").ToString, """", "")
        Dim GetCDesc As String = Replace(jo("ChannelDesc").ToString, """", "")
        Dim GetTCPPort As String = Replace(jo("TCPPort").ToString, """", "")
        Dim GetGroupAddress As String = Replace(jo("GroupAddress").ToString, """", "")
        Dim GetPort As String = Replace(jo("GroupPort").ToString, """", "")
        Dim GetMaxBandwidth As String = Replace(jo("MaxBandwidth").ToString, """", "")
        Dim GetTTL As String = Replace(jo("TTL").ToString, """", "")
        Dim GetRetry As String = Replace(jo("Retry").ToString, """", "")
        Dim GetRetryInterval As String = Replace(jo("RetryInterval").ToString, """", "")
        Dim GetMultimedia As String = Replace(jo("Multimedia").ToString, """", "")
        Dim GetStatus As String = Replace(jo("Status").ToString, """", "")
        Dim GetTglExecute As String = Replace(jo("TglExecute").ToString, """", "")
        Dim GetPaketSize As String = Replace(jo("PaketSize").ToString, """", "")
        Dim GeteFDBuffer As String = Replace(jo("eFDBuffer").ToString, """", "")
        Dim GeteUniqueID As String = Replace(jo("eUniqueID").ToString, """", "")
        Dim GeteFilename As String = Replace(jo("eFilename").ToString, """", "")
        Dim GeteSendingInterval As String = Replace(jo("eSendingInterval").ToString, """", "")
        Dim GeteLoopback As String = Replace(jo("eLoopback").ToString, """", "")
        Dim GetMPRID As String = Replace(jo("MprID").ToString, """", "")
        Dim GetSession As String = Replace(jo("UserCreate").ToString, """", "")

        Dim Filelist As String
        Dim HslCount As String
        Dim Count As String = "SELECT COUNT(HeaderChannelID) As CekPort FROM HEADERCHANNEL WHERE CNumber='" & GetCNumber & "' And TCPPortListener ='" & GetTCPPort & "'"
        Com = New SqlCommand(Count, weberConnection)
        weberConnection.Open()
        Dr = Com.ExecuteReader()
        If Dr.Read() Then
            HslCount = Dr("CekPort").ToString
        End If
        Dr.Close()
        weberConnection.Close()
        If HslCount = 0 Then
            Try
                Using Sqlcon As New SqlConnection(strCon)
                    Using cmd As New SqlCommand()
                        Sqlcon.Open()
                        cmd.Connection = Sqlcon
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.CommandText = "SP_InsertHeaderChannel"
                        cmd.Parameters.Add(New SqlParameter("@pvchAction", SqlDbType.VarChar, 50))
                        cmd.Parameters.Add(New SqlParameter("@HeaderChannelID", SqlDbType.VarChar, 50))
                        cmd.Parameters.Add(New SqlParameter("@CNumber", SqlDbType.VarChar, 100))
                        cmd.Parameters.Add(New SqlParameter("@CDescription", SqlDbType.VarChar, 500))
                        cmd.Parameters.Add(New SqlParameter("@TCPPortListener", SqlDbType.VarChar, 100))
                        cmd.Parameters.Add(New SqlParameter("@GroupAddress", SqlDbType.VarChar, 100))
                        cmd.Parameters.Add(New SqlParameter("@GroupPort", SqlDbType.VarChar, 100))
                        cmd.Parameters.Add(New SqlParameter("@MaxBandwith", SqlDbType.VarChar, 100))
                        cmd.Parameters.Add(New SqlParameter("@TTL", SqlDbType.VarChar, 100))
                        cmd.Parameters.Add(New SqlParameter("@NumOfRetry", SqlDbType.VarChar, 100))
                        cmd.Parameters.Add(New SqlParameter("@RetryInterval", SqlDbType.VarChar, 100))
                        cmd.Parameters.Add(New SqlParameter("@Multimedia", SqlDbType.VarChar, 100))
                        cmd.Parameters.Add(New SqlParameter("@StatusChannel", SqlDbType.VarChar, 100))
                        cmd.Parameters.Add(New SqlParameter("@eExecDateTime", SqlDbType.VarChar, 100))
                        cmd.Parameters.Add(New SqlParameter("@ePacketSize", SqlDbType.VarChar, 100))
                        cmd.Parameters.Add(New SqlParameter("@eFDBuffer", SqlDbType.VarChar, 100))
                        cmd.Parameters.Add(New SqlParameter("@eUniqueID", SqlDbType.VarChar, 100))
                        cmd.Parameters.Add(New SqlParameter("@eFilename", SqlDbType.VarChar, 100))
                        cmd.Parameters.Add(New SqlParameter("@eSendingInterval", SqlDbType.VarChar, 100))
                        cmd.Parameters.Add(New SqlParameter("@eLoopback", SqlDbType.VarChar, 100))
                        cmd.Parameters.Add(New SqlParameter("@MprID", SqlDbType.VarChar, 100))

                        cmd.Parameters("@pvchAction").Value = "insert"
                        cmd.Parameters("@HeaderChannelID").Value = "Auto"
                        cmd.Parameters("@CNumber").Value = GetCNumber
                        cmd.Parameters("@CDescription").Value = GetCDesc
                        cmd.Parameters("@TCPPortListener").Value = GetTCPPort
                        cmd.Parameters("@GroupAddress").Value = GetGroupAddress
                        cmd.Parameters("@GroupPort").Value = GetPort
                        cmd.Parameters("@MaxBandwith").Value = GetMaxBandwidth
                        cmd.Parameters("@TTL").Value = GetTTL
                        cmd.Parameters("@NumOfRetry").Value = GetRetry
                        cmd.Parameters("@RetryInterval").Value = GetRetryInterval
                        cmd.Parameters("@Multimedia").Value = GetMultimedia
                        cmd.Parameters("@StatusChannel").Value = GetStatus
                        cmd.Parameters("@eExecDateTime").Value = GetTglExecute
                        cmd.Parameters("@ePacketSize").Value = GetPaketSize
                        cmd.Parameters("@eFDBuffer").Value = GeteFDBuffer
                        cmd.Parameters("@eUniqueID").Value = GeteUniqueID
                        cmd.Parameters("@eFilename").Value = GeteFilename
                        cmd.Parameters("@eSendingInterval").Value = GeteSendingInterval
                        cmd.Parameters("@eLoopback").Value = GeteLoopback
                        cmd.Parameters("@MprID").Value = GetMPRID
                        cmd.Parameters("@UserCreate").Value = GetSession
                        cmd.ExecuteNonQuery()

                    End Using
                End Using

                Response.Write(DirectCast("Success", String))
            Catch ex As Exception
                Response.Write(DirectCast("", String))
            Finally
            End Try
        Else
            Response.Write(DirectCast("Channel & TCP Port Already Exits", String))

        End If

		'log insert Header Channel
        Dim insertquery As String = "insert into LogMasterChannel (CNumber, MprID, CDescription, GroupAddress, GroupPort, MaxBandwith, " & _
                                    "TTL, NumOfRetry, RetryInterval, Multimedia, UserCreate, DateCreate, StatusChannel, " & _
                                    "eExecDateTime, ePacketSize, eFDBuffer, eUniqueID, eFilename, eSendingInterval, eLoopback, TCPPortListener, action) Values " & _
                                    "('" & GetCNumber & "', '" & GetMPRID & "', '" & GetCDesc & "', '" & GetGroupAddress & "', '" & GetPort & "', '" & GetMaxBandwidth & "', " & _
                                    "'" & GetTTL & "', '" & GetRetry & "', '" & GetRetryInterval & "', '" & GetMultimedia & "', '" & GetSession & "', Getdate(), '" & GetStatus & "', " & _
                                    "'" & GetTglExecute & "', '" & GetPaketSize & "', '" & GeteFDBuffer & "', '" & GeteUniqueID & "', '" & GeteFilename & "', ' " & GeteSendingInterval & "', '" & GeteLoopback & "', '" & GetTCPPort & "', 'Insert')"
        Com = New SqlCommand(insertquery, weberConnection)
        weberConnection.Open()
        Com.ExecuteNonQuery()
        weberConnection.Close()
		
    End Sub

    Private Sub UpdateHeaderChannel()
        Dim sr As New System.IO.StreamReader(Request.InputStream)
        Dim line As String = ""
        line = sr.ReadToEnd()
        Dim lineJson As String = line
        Dim cleanDataSuctomer As String = lineJson.Replace("""", "\""")
        Dim cleanDataSuctomer1 As String = cleanDataSuctomer.Replace("/", "\/")
        Dim jo As JObject = JObject.Parse(cleanDataSuctomer1)
        Dim HeaderID As String = Replace(jo("HeaderChannelID").ToString, """", "")
        Dim GetCNumber As String = Replace(jo("ChannelNumber").ToString, """", "")
        Dim GetCDesc As String = Replace(jo("ChannelDesc").ToString, """", "")
        Dim GetTCPPort As String = Replace(jo("TCPPort").ToString, """", "")
        Dim GetGroupAddress As String = Replace(jo("GroupAddress").ToString, """", "")
        Dim GetPort As String = Replace(jo("GroupPort").ToString, """", "")
        Dim GetMaxBandwidth As String = Replace(jo("MaxBandwidth").ToString, """", "")
        Dim GetTTL As String = Replace(jo("TTL").ToString, """", "")
        Dim GetRetry As String = Replace(jo("Retry").ToString, """", "")
        Dim GetRetryInterval As String = Replace(jo("RetryInterval").ToString, """", "")
        Dim GetMultimedia As String = Replace(jo("Multimedia").ToString, """", "")
        Dim GetStatus As String = Replace(jo("Status").ToString, """", "")
        Dim GetTglExecute As String = Replace(jo("TglExecute").ToString, """", "")
        Dim GetPaketSize As String = Replace(jo("PaketSize").ToString, """", "")
        Dim GeteFDBuffer As String = Replace(jo("eFDBuffer").ToString, """", "")
        Dim GeteUniqueID As String = Replace(jo("eUniqueID").ToString, """", "")
        Dim GeteFilename As String = Replace(jo("eFilename").ToString, """", "")
        Dim GeteSendingInterval As String = Replace(jo("eSendingInterval").ToString, """", "")
        Dim GeteLoopback As String = Replace(jo("eLoopback").ToString, """", "")
        Dim GetMPRID As String = Replace(jo("MprID").ToString, """", "")
        Dim strCommand As String = Replace(jo("sCmd").ToString, """", "")
        'Dim intPort As Integer = Replace(jo("iPort").ToString, """", "")
        'Dim strCommand As String = 4
        Dim intPort As Integer = 8800
        If strCommand = 1 Then
            strCommand = "HTTP_CMD_SEND_FILE_START"
        ElseIf strCommand = 2 Then
            strCommand = "HTTP_CMD_SEND_FILE_STOP"
        ElseIf strCommand = 3 Then
            strCommand = "HTTP_CMD_NUM_OF_PART"
        ElseIf strCommand = 4 Then
            strCommand = "HTTP_CMD_UPDATE_DATA"
        End If
        Dim HslCount As String

        Dim UpdateTrx As String = "Update HeaderChannel set eFilename='" & GeteFilename & "' where HeaderChannelID='" & HeaderID & "' "
        Comm = New SqlCommand(UpdateTrx, weberConnection)
        weberConnection.Open()
        Comm.ExecuteNonQuery()
        weberConnection.Close()

		
        ''log update
        '      Dim insertquery As String = "insert into LogMasterChannel (CNumber, MprID, CDescription, GroupAddress, GroupPort, MaxBandwith, " & _
        '                                  "TTL, NumOfRetry, RetryInterval, Multimedia, UserUpdate, DateUpdate, StatusChannel, " & _
        '                                  "eExecDateTime, ePacketSize, eFDBuffer, eUniqueID, eFilename, eSendingInterval, eLoopback, TCPPortListener, action) Values " & _
        '                                  "('" & GetCNumber & "', '" & GetMPRID & "', '" & GetCDesc & "', '" & GetGroupAddress & "', '" & GetPort & "', '" & GetMaxBandwidth & "', " & _
        '                                  "'" & GetTTL & "', '" & GetRetry & "', '" & GetRetryInterval & "', '" & GetMultimedia & "', '" & GetSession & "', Getdate(), '" & GetStatus & "', " & _
        '                                  "'" & GetTglExecute & "', '" & GetPaketSize & "', '" & GeteFDBuffer & "', '" & GeteUniqueID & "', '" & GeteFilename & "', ' " & GeteSendingInterval & "', '" & GeteLoopback & "', '" & GetTCPPort & "', 'Update')"
        '      Com = New SqlCommand(insertquery, weberConnection)
        '      weberConnection.Open()
        '      Com.ExecuteNonQuery()
        '      weberConnection.Close()

        'Using Sqlcon As New SqlConnection(strCon)
        '    Using cmd As New SqlCommand()
        '        Sqlcon.Open()
        '        cmd.Connection = Sqlcon
        '        cmd.CommandType = CommandType.StoredProcedure
        '        cmd.CommandText = "SP_InsertHeaderChannel"
        '        cmd.Parameters.Add(New SqlParameter("@pvchAction", SqlDbType.VarChar, 50))
        '        cmd.Parameters.Add(New SqlParameter("@HeaderChannelID", SqlDbType.VarChar, 50))
        '        cmd.Parameters.Add(New SqlParameter("@CNumber", SqlDbType.VarChar, 100))
        '        cmd.Parameters.Add(New SqlParameter("@CDescription", SqlDbType.VarChar, 500))
        '        cmd.Parameters.Add(New SqlParameter("@TCPPortListener", SqlDbType.VarChar, 100))
        '        cmd.Parameters.Add(New SqlParameter("@GroupAddress", SqlDbType.VarChar, 100))
        '        cmd.Parameters.Add(New SqlParameter("@GroupPort", SqlDbType.VarChar, 100))
        '        cmd.Parameters.Add(New SqlParameter("@MaxBandwith", SqlDbType.VarChar, 100))
        '        cmd.Parameters.Add(New SqlParameter("@TTL", SqlDbType.VarChar, 100))
        '        cmd.Parameters.Add(New SqlParameter("@NumOfRetry", SqlDbType.VarChar, 100))
        '        cmd.Parameters.Add(New SqlParameter("@RetryInterval", SqlDbType.VarChar, 100))
        '        cmd.Parameters.Add(New SqlParameter("@Multimedia", SqlDbType.VarChar, 100))
        '        cmd.Parameters.Add(New SqlParameter("@StatusChannel", SqlDbType.VarChar, 100))
        '        cmd.Parameters.Add(New SqlParameter("@eExecDateTime", SqlDbType.VarChar, 100))
        '        cmd.Parameters.Add(New SqlParameter("@ePacketSize", SqlDbType.VarChar, 100))
        '        cmd.Parameters.Add(New SqlParameter("@eFDBuffer", SqlDbType.VarChar, 100))
        '        cmd.Parameters.Add(New SqlParameter("@eUniqueID", SqlDbType.VarChar, 100))
        '        cmd.Parameters.Add(New SqlParameter("@eFilename", SqlDbType.VarChar, 100))
        '        cmd.Parameters.Add(New SqlParameter("@eSendingInterval", SqlDbType.VarChar, 100))
        '        cmd.Parameters.Add(New SqlParameter("@eLoopback", SqlDbType.VarChar, 100))
        '        cmd.Parameters.Add(New SqlParameter("@MprID", SqlDbType.VarChar, 100))

        '        cmd.Parameters("@pvchAction").Value = "update"
        '        cmd.Parameters("@HeaderChannelID").Value = HeaderID
        '        cmd.Parameters("@CNumber").Value = GetCNumber
        '        cmd.Parameters("@CDescription").Value = GetCDesc
        '        cmd.Parameters("@TCPPortListener").Value = GetTCPPort
        '        cmd.Parameters("@GroupAddress").Value = GetGroupAddress
        '        cmd.Parameters("@GroupPort").Value = GetPort
        '        cmd.Parameters("@MaxBandwith").Value = GetMaxBandwidth
        '        cmd.Parameters("@TTL").Value = GetTTL
        '        cmd.Parameters("@NumOfRetry").Value = GetRetry
        '        cmd.Parameters("@RetryInterval").Value = GetRetryInterval
        '        cmd.Parameters("@Multimedia").Value = GetMultimedia
        '        cmd.Parameters("@StatusChannel").Value = GetStatus
        '        cmd.Parameters("@eExecDateTime").Value = GetTglExecute
        '        cmd.Parameters("@ePacketSize").Value = GetPaketSize
        '        cmd.Parameters("@eFDBuffer").Value = GeteFDBuffer
        '        cmd.Parameters("@eUniqueID").Value = GeteUniqueID
        '        cmd.Parameters("@eFilename").Value = GeteFilename
        '        cmd.Parameters("@eSendingInterval").Value = GeteSendingInterval
        '        cmd.Parameters("@eLoopback").Value = GeteLoopback
        '        cmd.Parameters("@MprID").Value = GetMPRID

        '        cmd.ExecuteNonQuery()

        '    End Using
        'End Using


        Try
            Dim bytes(1024) As Byte
            Dim ipHostInfo As IPHostEntry = Dns.Resolve(Dns.GetHostName())
            Dim ipAddress As IPAddress = ipAddress.Parse("127.0.0.1")
            'port dibuat dinamis sesuai header channel
            'di semua exec socket
            Dim remoteEP As New IPEndPoint(ipAddress, intPort)
            Try
                senderX.Connect(remoteEP)
                ' Encode the data string into a byte array.
                Dim msg As Byte() = _
                    Encoding.ASCII.GetBytes(strCommand)
                ' Send the data through the socket.
                Dim bytesSent As Integer = senderX.Send(msg)
                ' Receive the response from the remote device.
                Dim bytesRec As Integer = senderX.Receive(bytes)


                senderX.GetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.KeepAlive, 1)
                ''Response.Write(DirectCast("{0}" & Encoding.ASCII.GetString(bytes, 0, bytesRec) & "", String))
                'ValueSocket = DirectCast("{0}" & Encoding.ASCII.GetString(bytes, 0, bytesRec) & "", String)
                ValueSocket = DirectCast(Encoding.ASCII.GetString(bytes, 0, bytesRec) & "", String)
                'Response.Write(ValueSocket)

                Response.Write(DirectCast("Success", String))
            Catch
                Response.Write(String.Format("Socket failed to connect {0}<br>", senderX.RemoteEndPoint))
            End Try

        Catch ex As Exception
            Response.Write(DirectCast("", String))
        Finally

        End Try
    End Sub

    Private Sub DeleteHeaderChannel()
        Dim sr As New System.IO.StreamReader(Request.InputStream)
        Dim line As String = ""
        line = sr.ReadToEnd()
        Dim lineJson As String = line
        Dim cleanDataSuctomer As String = lineJson.Replace("""", "\""")
        Dim cleanDataSuctomer1 As String = cleanDataSuctomer.Replace("/", "\/")
        Dim jo As JObject = JObject.Parse(cleanDataSuctomer1)
        Dim HeaderID As String = Replace(jo("HeaderChannelID").ToString, """", "")

        Using Sqlcon As New SqlConnection(strCon)
            Using cmd As New SqlCommand()
                Sqlcon.Open()
                cmd.Connection = Sqlcon
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "SP_InsertHeaderChannel"
                cmd.Parameters.Add(New SqlParameter("@pvchAction", SqlDbType.VarChar, 50))
                cmd.Parameters.Add(New SqlParameter("@HeaderChannelID", SqlDbType.VarChar, 50))
                cmd.Parameters.Add(New SqlParameter("@CNumber", SqlDbType.VarChar, 100))
                cmd.Parameters.Add(New SqlParameter("@CDescription", SqlDbType.VarChar, 500))
                cmd.Parameters.Add(New SqlParameter("@GroupAddress", SqlDbType.VarChar, 100))
                cmd.Parameters.Add(New SqlParameter("@GroupPort", SqlDbType.VarChar, 100))
                cmd.Parameters.Add(New SqlParameter("@MaxBandwith", SqlDbType.VarChar, 100))
                cmd.Parameters.Add(New SqlParameter("@TTL", SqlDbType.VarChar, 100))
                cmd.Parameters.Add(New SqlParameter("@NumOfRetry", SqlDbType.VarChar, 100))
                cmd.Parameters.Add(New SqlParameter("@RetryInterval", SqlDbType.VarChar, 100))
                cmd.Parameters.Add(New SqlParameter("@Multimedia", SqlDbType.VarChar, 100))
                cmd.Parameters.Add(New SqlParameter("@StatusChannel", SqlDbType.VarChar, 100))
                cmd.Parameters.Add(New SqlParameter("@eExecDateTime", SqlDbType.VarChar, 100))
                cmd.Parameters.Add(New SqlParameter("@ePacketSize", SqlDbType.VarChar, 100))
                cmd.Parameters.Add(New SqlParameter("@eFDBuffer", SqlDbType.VarChar, 100))
                cmd.Parameters.Add(New SqlParameter("@eUniqueID", SqlDbType.VarChar, 100))
                cmd.Parameters.Add(New SqlParameter("@eFilename", SqlDbType.VarChar, 100))
                cmd.Parameters.Add(New SqlParameter("@eSendingInterval", SqlDbType.VarChar, 100))
                cmd.Parameters.Add(New SqlParameter("@eLoopback", SqlDbType.VarChar, 100))

                cmd.Parameters("@pvchAction").Value = "delete"
                cmd.Parameters("@HeaderChannelID").Value = HeaderID
                cmd.Parameters("@CNumber").Value = "pass"
                cmd.Parameters("@CDescription").Value = "pass"
                cmd.Parameters("@GroupAddress").Value = "pass"
                cmd.Parameters("@GroupPort").Value = "pass"
                cmd.Parameters("@MaxBandwith").Value = "pass"
                cmd.Parameters("@TTL").Value = "pass"
                cmd.Parameters("@NumOfRetry").Value = "pass"
                cmd.Parameters("@RetryInterval").Value = "pass"
                cmd.Parameters("@Multimedia").Value = "pass"
                cmd.Parameters("@StatusChannel").Value = "pass"
                cmd.Parameters("@eExecDateTime").Value = "pass"
                cmd.Parameters("@ePacketSize").Value = "pass"
                cmd.Parameters("@eFDBuffer").Value = "pass"
                cmd.Parameters("@eUniqueID").Value = "pass"
                cmd.Parameters("@eFilename").Value = "pass"
                cmd.Parameters("@eSendingInterval").Value = "pass"
                cmd.Parameters("@eLoopback").Value = "pass"

                cmd.ExecuteNonQuery()

            End Using
        End Using
        Response.Redirect("mChannel.aspx")
    End Sub

    'Private Sub insertMPR()
    '    'data passed in as JSON format
    '    Dim sr As New System.IO.StreamReader(Request.InputStream)
    '    Dim line As String = ""
    '    line = sr.ReadToEnd()

    '    Dim lineJson As String = line
    '    Dim cleanDataCTI As String = lineJson.Replace("""", "\""")
    '    Dim fixCleanDataCTI As String = cleanDataCTI.Replace("/", "\/")
    '    Dim jo As JObject = JObject.Parse(fixCleanDataCTI)
    '    Dim MPRID As String = Replace(jo("MPRID").ToString, """", "")
    '    Dim MPRSiteName As String = Replace(jo("MPRSiteName").ToString, """", "")
    '    Dim MPRSiteAsddress As String = Replace(jo("MPRSiteAsddress").ToString, """", "")
    '    Dim Filelist As String
    '    Dim VMPRID As String
    '    Dim SMPRID As String = "SELECT COUNT (ID) AS DATA  FROM HEADERMPR WHERE MPRID='" & MprID & "'"
    '    Com = New SqlCommand(SMPRID, weberConnection)
    '    weberConnection.Open()
    '    Dr = Com.ExecuteReader()
    '    If Dr.Read() Then
    '        VMPRID = Dr("DATA").ToString
    '    End If
    '    Dr.Close()
    '    weberConnection.Close()
    '    If VMPRID = 0 Then
    '        Using Sqlcon As New SqlConnection(strCon)
    '            Using cmd As New SqlCommand()
    '                Sqlcon.Open()
    '                cmd.Connection = Sqlcon
    '                cmd.CommandType = CommandType.StoredProcedure
    '                cmd.CommandText = "SP_InsertMpr"
    '                cmd.Parameters.Add(New SqlParameter("@pvchAction", SqlDbType.VarChar, 50))
    '                cmd.Parameters.Add(New SqlParameter("@ID", SqlDbType.VarChar, 50))
    '                cmd.Parameters.Add(New SqlParameter("@MprID", SqlDbType.VarChar, 100))
    '                cmd.Parameters.Add(New SqlParameter("@SiteName", SqlDbType.VarChar, 200))
    '                cmd.Parameters.Add(New SqlParameter("@SiteAddress", SqlDbType.VarChar, 500))

    '                cmd.Parameters("@pvchAction").Value = "insert"
    '                cmd.Parameters("@ID").Value = "Auto"
    '                cmd.Parameters("@MprID").Value = MPRID
    '                cmd.Parameters("@SiteName").Value = MPRSiteName
    '                cmd.Parameters("@SiteAddress").Value = MPRSiteAsddress

    '                cmd.ExecuteNonQuery()

    '            End Using
    '        End Using
    '        'Display complete uploaded file details in gridview
    '        Response.Write(DirectCast("Success", String))
    '    Else
    '        Response.Write(DirectCast("MPRID Already Exits", String))
    '    End If
    'End Sub

    Private Sub UpdateSelect()
        Dim sr As New System.IO.StreamReader(Request.InputStream)
        Dim line As String = ""
        line = sr.ReadToEnd()
        Dim lineJson As String = line
        Dim cleanDataSuctomer As String = lineJson.Replace("""", "\""")
        Dim cleanDataSuctomer1 As String = cleanDataSuctomer.Replace("/", "\/")
        Dim jo As JObject = JObject.Parse(cleanDataSuctomer1)
        Dim strCommand As String
        Dim TrxMPRID As String = Replace(jo("id").ToString, """", "")
        Dim MprID As String = Replace(jo("ETO").ToString, """", "")
        Dim Filelist As String

        Try

            Dim Com As SqlCommand
            Dim Dr As SqlDataReader

            Dim sqlCekMailKirim As String = "select  IVC_ID, ETO from IVC_EMAIL_IN_TM where IVC_ID='" & TrxMPRID & "'"
            Com = New SqlCommand(sqlCekMailKirim, weberConnection)
            weberConnection.Open()
            Dr = Com.ExecuteReader()
            Dr.Read()
            Filelist = Dr("IVC_ID").ToString & "|" & Dr("ETO").ToString & ""
            Dr.Close()
            weberConnection.Close()

            Response.Write(DirectCast(Filelist, String))
        Catch ex As Exception
            Response.Write(DirectCast("", String))
        Finally
        End Try
    End Sub

    Private Sub UpdateActionTrxMPR()
        Dim sr As New System.IO.StreamReader(Request.InputStream)
        Dim line As String = ""
        line = sr.ReadToEnd()
        Dim lineJson As String = line
        Dim cleanDataSuctomer As String = lineJson.Replace("""", "\""")
        Dim cleanDataSuctomer1 As String = cleanDataSuctomer.Replace("/", "\/")
        Dim jo As JObject = JObject.Parse(cleanDataSuctomer1)
        Dim strCommand As String
        Dim TrxMPRID As String = Replace(jo("TrxMprID").ToString, """", "")
        Dim ChannelNumber As String = Replace(jo("ChannelNumber").ToString, """", "")
		Dim MprIDTrx As String = Replace(jo("MprIDTrx").ToString, """", "")
        Dim UserSession As String = Replace(jo("UserSession").ToString, """", "")
        Dim Filelist As String

        Using Sqlcon As New SqlConnection(strCon)
            Using cmd As New SqlCommand()
                Sqlcon.Open()
                cmd.Connection = Sqlcon
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "SP_AddTrxDetailMPR"
                cmd.Parameters.Add(New SqlParameter("@pvchAction", SqlDbType.VarChar, 50))
                cmd.Parameters.Add(New SqlParameter("@TrxMprID", SqlDbType.VarChar, 100))
                cmd.Parameters.Add(New SqlParameter("@MprID", SqlDbType.VarChar, 500))
                cmd.Parameters.Add(New SqlParameter("@CNumber", SqlDbType.VarChar, 500))
                cmd.Parameters.Add(New SqlParameter("@UserCreate", SqlDbType.VarChar, 100))

                cmd.Parameters("@pvchAction").Value = "update"
                cmd.Parameters("@TrxMprID").Value = TrxMPRID
                cmd.Parameters("@MprID").Value = MprIDTrx
                cmd.Parameters("@CNumber").Value = ChannelNumber
                cmd.Parameters("@UserCreate").Value = UserSession

                cmd.ExecuteNonQuery()

                Response.Write(DirectCast("Success", String))
            End Using
            Response.Write(DirectCast("", String))
        End Using
		
		'Log
		Dim insertquery As String = "insert into LogTrxMpr (MprID, CNumber, UserUpdate, DateUpdate, Action) Values ('" & MprIDTrx & "', '" & ChannelNumber & "', '" & UserSession & "', Getdate(), 'Update')"
        Com = New SqlCommand(insertquery, weberConnection)
        weberConnection.Open()
        Com.ExecuteNonQuery()
        weberConnection.Close()
		
    End Sub


    Private Sub sendSocketAsking()

        Dim sr As New System.IO.StreamReader(Request.InputStream)
        Dim line As String = ""
        line = sr.ReadToEnd()

        Dim lineJson As String = line
        Dim cleanDataCTI As String = lineJson.Replace("""", "\""")
        Dim fixCleanDataCTI As String = cleanDataCTI.Replace("/", "\/")
        Dim jo As JObject = JObject.Parse(fixCleanDataCTI)

        Dim strCommand As String = Replace(jo("sCmd").ToString, """", "")
        'Dim intPort As Integer = Replace(jo("iPort").ToString, """", "")
        'Dim GetHeaderChannelID As String = Replace(jo("HeaderChannelID").ToString, """", "")
        'Dim GetCNumber As String = Replace(jo("CNumber").ToString, """", "")
        'Dim GetCDesc As String = Replace(jo("CDesc").ToString, """", "")
        'Dim GetTCPPort As String = Replace(jo("iPort").ToString, """", "")
        Dim intPort As Integer = 8800
        If strCommand = 1 Then
            strCommand = "HTTP_CMD_SEND_FILE_START"
        ElseIf strCommand = 2 Then
            strCommand = "HTTP_CMD_SEND_FILE_STOP"
        ElseIf strCommand = 3 Then
            strCommand = "HTTP_CMD_NUM_OF_PART"
        ElseIf strCommand = 4 Then
            strCommand = "HTTP_CMD_UPDATE_DATA"
        End If
        Dim Filelist As String

        Try

            Dim bytes(1024) As Byte
            Dim ipHostInfo As IPHostEntry = Dns.Resolve(Dns.GetHostName())
            Dim ipAddress As IPAddress = ipAddress.Parse("127.0.0.1")

            'port dibuat dinamis sesuai header channel
            'di semua exec socket
            Dim remoteEP As New IPEndPoint(ipAddress, intPort)

            Try
                senderX.Connect(remoteEP)

                ' Encode the data string into a byte array.
                Dim msg As Byte() = _
                    Encoding.ASCII.GetBytes(strCommand)

                ' Send the data through the socket.

                Dim bytesSent As Integer = senderX.Send(msg)

                ' Receive the response from the remote device.
                Dim bytesRec As Integer = senderX.Receive(bytes)

                senderX.GetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.KeepAlive, 1)
                ''Response.Write(DirectCast("{0}" & Encoding.ASCII.GetString(bytes, 0, bytesRec) & "", String))
                'ValueSocket = DirectCast("{0}" & Encoding.ASCII.GetString(bytes, 0, bytesRec) & "", String)
                ValueSocket = DirectCast(Encoding.ASCII.GetString(bytes, 0, bytesRec) & "", String)
                Response.Write(ValueSocket)
                If strCommand = "HTTP_CMD_NUM_OF_PART" Then
                    Dim GetHeaderChannelID As String = Replace(jo("HeaderChannelID").ToString, """", "")
                    Dim CekHeaderChannel As String = "Select Cnumber, MprId from HeaderChannel Where HeaderChannelID='" & GetHeaderChannelID & "'"
                    Com = New SqlCommand(CekHeaderChannel, weberConnection)
                    weberConnection.Open()
                    Dr = Com.ExecuteReader()
                    Dr.Read()
                    CNumberAsking = Dr("Cnumber").ToString
                    MprIDAsking = Dr("MprId").ToString
                    Dr.Close()
                    weberConnection.Close()

                    Dim UpdateHeaderChannelAsking As String = "Update HeaderChannel set JumlahPart='" & ValueSocket & "' where HeaderChannelID='" & GetHeaderChannelID & "'"
                    Com = New SqlCommand(UpdateHeaderChannelAsking, weberConnection)
                    weberConnection.Open()
                    Com.ExecuteNonQuery()
                    weberConnection.Close()

                    Dim UpdateTrxChannelAsking As String = "Update TrxChannel set JumlahPart='" & ValueSocket & "' where CNumber='" & GetHeaderChannelID & "' And MprId='" & MprIDAsking & "'"
                    Com = New SqlCommand(UpdateTrxChannelAsking, weberConnection)
                    weberConnection.Open()
                    Com.ExecuteNonQuery()
                    weberConnection.Close()
                Else
                End If

            Catch
                Response.Write(String.Format("Socket failed to connect {0}<br>", senderX.RemoteEndPoint))
            End Try

        Catch ex As Exception
            Response.Write(DirectCast("", String))
        Finally

        End Try
    End Sub

    Private Sub UpdateUserId()
        Dim sr As New System.IO.StreamReader(Request.InputStream)
        Dim line As String = ""
        line = sr.ReadToEnd()
        Dim lineJson As String = line
        Dim cleanDataSuctomer As String = lineJson.Replace("""", "\""")
        Dim cleanDataSuctomer1 As String = cleanDataSuctomer.Replace("/", "\/")
        Dim jo As JObject = JObject.Parse(cleanDataSuctomer1)
        Dim UserId As String = Replace(jo("UserId").ToString, """", "")
        'Dim MprID As String = Replace(jo("MprID").ToString, """", "")
        Dim Filelist As String

        Try

            Dim Com As SqlCommand
            Dim Dr As SqlDataReader

            Dim sqlCekMailKirim As String = "select UserId, UserName, Password, Hak, UnitKerja from MsUser where UserId='" & UserId & "'"
            Com = New SqlCommand(sqlCekMailKirim, weberConnection)
            weberConnection.Open()
            Dr = Com.ExecuteReader()
            Dr.Read()
            Filelist = Dr("UserId").ToString & "|" & Dr("UserName").ToString & "|" & Dr("Password").ToString & "|" & Dr("Hak").ToString & "|" & Dr("UnitKerja").ToString
            Dr.Close()
            weberConnection.Close()

            Response.Write(DirectCast(Filelist, String))
        Catch ex As Exception
            Response.Write(DirectCast("", String))
        Finally
        End Try
    End Sub

    Private Sub UpdateUserTrustee()
        Dim sr As New System.IO.StreamReader(Request.InputStream)
        Dim line As String = ""
        line = sr.ReadToEnd()
        Dim lineJson As String = line
        Dim cleanDataSuctomer As String = lineJson.Replace("""", "\""")
        Dim cleanDataSuctomer1 As String = cleanDataSuctomer.Replace("/", "\/")
        Dim jo As JObject = JObject.Parse(cleanDataSuctomer1)
        Dim TrusteeID As String = Replace(jo("TrusteeID").ToString, """", "")
        'Dim MprID As String = Replace(jo("MprID").ToString, """", "")
        Dim Filelist As String

        Try

            Dim Com As SqlCommand
            Dim Dr As SqlDataReader

            Dim sqlCekMailKirim As String = "select TrusteeID, Hak, leveluser, Description, Home, TrxCh, TrxMP, stat, UsrMngt, Dashboard from usertrustee where TrusteeID='" & TrusteeID & "'"
            Com = New SqlCommand(sqlCekMailKirim, weberConnection)
            weberConnection.Open()
            Dr = Com.ExecuteReader()
            Dr.Read()
            Filelist = Dr("TrusteeID").ToString & "|" & Dr("Hak").ToString & "|" & Dr("leveluser").ToString & "|" & Dr("Home").ToString & "|" & Dr("TrxCh").ToString & "|" & Dr("TrxMP").ToString & "|" & Dr("stat").ToString & "|" & Dr("UsrMngt").ToString & "|" & Dr("Dashboard").ToString
            Dr.Close()
            weberConnection.Close()

            Response.Write(DirectCast(Filelist, String))
        Catch ex As Exception
            Response.Write(DirectCast("", String))
        Finally
        End Try
    End Sub

End Class