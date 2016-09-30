<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="xx.aspx.vb" Inherits="Helpdesk_Application.xx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">
    <title></title>
    <!-- Bootstrap core CSS -->
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet">

    <!-- Font Awesome -->
    <link href="css/font-awesome.min.css" rel="stylesheet">

    <!-- Pace -->
    <link href="css/pace.css" rel="stylesheet">

    <!-- Chosen -->
    <link href="css/chosen/chosen.min.css" rel="stylesheet" />

    <!-- Datepicker -->
    <link href="css/datepicker.css" rel="stylesheet" />

    <!-- Timepicker -->
    <link href="css/bootstrap-timepicker.css" rel="stylesheet" />

    <!-- Slider -->
    <link href="css/slider.css" rel="stylesheet" />

    <!-- Tag input -->
    <link href="css/jquery.tagsinput.css" rel="stylesheet" />

    <!-- WYSIHTML5 -->
    <link href="css/bootstrap-wysihtml5.css" rel="stylesheet" />

    <!-- Dropzone -->
    <link href='css/dropzone/dropzone.css' rel="stylesheet" />


</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-sm-2">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h1 class="panel-title">
                            <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseThree"><strong>Mail Folder &nbsp;<i class="fa fa-sort-down"></i></strong>
                            </a>
                        </h1>
                    </div>
                    <div id="collapseThree" class="panel-collapse collapse">
                        <div class="panel-body">
                            <a href="#">
                                <i class="fa fa-inbox fa-lg"></i>
                                <span class="m-left-xs">Inbox</span>
                                <span class="badge badge-success pull-right">19</span>
                            </a>
                            <hr />
                           
                            <a href="#">
                                <i class="fa fa-envelope fa-lg"></i>
                                <span class="m-left-xs">Sent Mail</span>
                                <span class="badge badge-danger pull-right">1</span>
                            </a>
                            <hr />
                            <a href="#">
                                <i class="fa fa-pencil fa-lg"></i><span class="m-left-xs">Drafts</span>
                            </a>

                        </div>
                    </div>
                </div>
            </div>
            <!-- /.col -->
            <div class="col-sm-10">
                <div class="tab-content">
                    <div class="panel panel-default table-responsive">
                        <div class="panel-heading">
                            <a class="btn btn-sm btn-info"><i class="fa fa-plus"></i>&nbsp;Write Mail</a>
                            <span class="label label-info pull-right">
                                <asp:Label ID="lbl_jumlah_facebook" runat="server" Text="100 item"></asp:Label></span>
                        </div>
                        <div class="padding-md clearfix">
                            <table class="table table-striped" id="dataTable">
                                <thead>
                                    <tr>
                                        <th style="width: 50px;">Action</th>
                                        <th style="width: 200px;">From</th>
                                        <th>Subject</th>
                                        <th style="width: 150px;">Date</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Literal ID="ltr_email" runat="server"></asp:Literal>
                                     <asp:FileUpload ID="ww" Width="100%" runat="server" />
                                    <asp:Button ID="Btn_upload" runat="server" Text="Update" CssClass="btn btn-success" />
                                    <asp:Label ID="lblcc" runat="server"></asp:Label>
                                </tbody>
                            </table>
                        </div>
                        <!-- /panel -->
                    </div>

                </div>
                <!-- /panel -->
            </div>
            <!-- /.col -->
        </div>
        <!-- /.row -->
        <div class="modal fade" id="ModalEmail">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4>Channel Email</h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label class="control-label col-lg-3">Email</label>
                            <div class="col-lg-2">
                                <asp:TextBox ID="txt_account_email" runat="server"></asp:TextBox>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </div>
                            <!-- /.col -->
                        </div>
                       
                    </div>
                    <div class="modal-footer">
                        <button class="btn btn-success btn-sm" data-dismiss="modal" aria-hidden="true">Close</button>
                        <%--  <a href="#" class="btn btn-danger btn-sm">Submit</a>--%>
                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>

    </form>

    <script>
        function updateHeaderChannel(id) {
            var json = "{'id':'" + id + "'}";
            var ajaxPage = "Function/IndomaretAction.aspx?Save=1&ket=UpdateHeaderChannel"; //this page is where data is to be retrieved and processed
            var options = {
                type: "POST",
                url: ajaxPage,
                data: json,
                contentType: "application/json;charset=utf-8",
                dataType: "text",
                async: false,
                success: function (response) {
                    alert("success: " + dataType);
                },
                ////error: function (msg) { alert("failed: " + msg); }
            };

            ////execute the ajax call and get a response
            var returnText = $.ajax(options).responseText;
            //alert(returnText);
            var arr = returnText.split('|');
            //alert(arr[6]);
            document.getElementById("txt_account_email").value = id;
            document.getElementById("TextBox1").text = arr[0];
        }

       
    </script>
    <!-- Le javascript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->

    <!-- Jquery -->
    <script src="js/jquery-1.10.2.min.js"></script>

    <!-- Bootstrap -->
    <script src="bootstrap/js/bootstrap.min.js"></script>

    <!-- Chosen -->
    <script src='js/chosen.jquery.min.js'></script>

    <!-- Mask-input -->
    <script src='js/jquery.maskedinput.min.js'></script>

    <!-- Datepicker -->
    <script src='js/bootstrap-datepicker.min.js'></script>

    <!-- Timepicker -->
    <script src='js/bootstrap-timepicker.min.js'></script>

    <!-- Slider -->
    <script src='js/bootstrap-slider.min.js'></script>

    <!-- Tag input -->
    <script src='js/jquery.tagsinput.min.js'></script>

    <!-- WYSIHTML5 -->
    <script src='js/wysihtml5-0.3.0.min.js'></script>
    <script src='js/uncompressed/bootstrap-wysihtml5.js'></script>

    <!-- Dropzone -->
    <script src='js/dropzone.min.js'></script>

    <!-- Modernizr -->
    <script src='js/modernizr.min.js'></script>

    <!-- Pace -->
    <script src='js/pace.min.js'></script>

    <!-- Popup Overlay -->
    <script src='js/jquery.popupoverlay.min.js'></script>

    <!-- Slimscroll -->
    <script src='js/jquery.slimscroll.min.js'></script>

    <!-- Cookie -->
    <script src='js/jquery.cookie.min.js'></script>

    <!-- Endless -->
    <script src="js/endless/endless_form.js"></script>
    <script src="js/endless/endless.js"></script>

</body>
</html>
