<%@ Page Title="" Language="C#" MasterPageFile="~/Panel/Shop/Site1.Master" AutoEventWireup="true" CodeBehind="OrderFilter.aspx.cs" Inherits="Ironika_Theme1.Panel.Shop.OrderFilter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>بازه تاریخ در سفارشات /پنل کاربری </title>
    <script type="text/javascript">
        function openModalRegister() {
            $('#ModalRegister').modal('show');
        }

    </script>
    <link href="../../Content/css/PersianDatePicker.min.css" rel="stylesheet" />   
    <script src="../../Scripts/PersianDatePicker.min.js"></script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_TitlePage" runat="server">
    <li><a href="/">خانه</a> </li>
    <li class="active">بازه تاریخ در سفارشات</li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_PageName" runat="server">
    <h1>بازه تاریخ در سفارشات</h1>
    <small class="subtitle">لیست بازه تاریخ در سفارشات</small>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder_Body" runat="server">
    <div class="panel widget light-widget">
        <div class="panel-heading no-title"></div>

        <div class="panel-body">
            <h2 class="mgbt-xs-20">مدیریت لیست بازه تاریخ در سفارشات
            </h2>
            <div class="form-horizontal">

                <div class="form-group">
                    <div class="col-md-6">
                        <div class="label-wrapper">
                            <label class="control-label">از تاریخ <span class="vd_red">*</span></label><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtStartDate" ForeColor="Red" ValidationGroup="as_Register" ErrorMessage="از تاریخ را وارد کنید"></asp:RequiredFieldValidator>
                        </div>
                        <div class="vd_input-wrapper" >
                            <asp:TextBox runat="server" class="required" ID="TxtStartDate"></asp:TextBox>

                           
                        </div>
                    </div>
                    <div class="col-md-6">
                       <div class="label-wrapper">
                            <label class="control-label">تا تاریخ <span class="vd_red">*</span></label><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtEndDate" ForeColor="Red" ValidationGroup="as_Register" ErrorMessage="تا تاریخ را وارد کنید"></asp:RequiredFieldValidator>
                        </div>
                        <div class="vd_input-wrapper" >
                            <asp:TextBox runat="server" class="required" ID="TxtEndDate"></asp:TextBox>

                           
                        </div>
                    </div>
                </div>
              
              
                <div class="form-group">

                    <div class="col-md-12 mgbt-xs-5" style="direction: rtl; text-align: center">


                        <asp:Button class="btn vd_btn vd_btn-bevel vd_bg-green font-semibold" Width="120px" runat="server" ValidationGroup="as_Register" ID="submit_register" OnClick="submit_register_Click" Text="مشاهده گزارش"></asp:Button>
                        <asp:Button class="btn vd_btn vd_btn-bevel vd_bg-yellow font-semibold" Width="120px" runat="server" ID="BtnCancel" OnClick="BtnCancel_Click" Text="پاک کردن"></asp:Button>
                        <br />
                        <asp:Literal ID="Literal_Message" runat="server"></asp:Literal>
                      
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="panel widget light-widget">
        <div class="panel-heading no-title"></div>
        <div class="panel-body" style="direction: rtl; text-align: right">
            <h2 class="mgbt-xs-20">لیست سفارشات</h2><asp:HiddenField ID="Hi_Order" runat="server" />
            <asp:GridView ID="List_Project" OnRowCommand="List_Project_RowCommand" RowStyle-CssClass="GvGrid" runat="server" AllowPaging="True" PageSize="30" AutoGenerateColumns="False"  DataKeyNames="OrderId" Width="90%" Style="margin-right: 5%; margin-left: 5%" GridLines="Horizontal">
                <Columns>
                    <asp:TemplateField HeaderText="مشتری">
                        <ItemTemplate>
                            <%# NumberFormat_Register(int.Parse(Eval("RegisterId").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                   
                    <asp:TemplateField HeaderText="تلفن">
                        <ItemTemplate>
                            <%# NumberFormat_RegisterTele(int.Parse(Eval("RegisterId").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="ایمیل">
                        <ItemTemplate>
                            <%# NumberFormat_RegisterEmail(int.Parse(Eval("RegisterId").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="تاریخ ثبت ">
                        <ItemTemplate>
                            <%# NumberFormat_Date(DateTime.Parse(Eval("DateSales").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="جزئیات سفارش">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" CommandArgument='<%#   DataBinder.Eval(Container.DataItem,"OrderId") %>'>جزئیات سفارش</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="تاریخ سفارش">
                        <ItemTemplate>
                            <%# NumberFormat_Date(DateTime.Parse(Eval("DateSales").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
                <HeaderStyle BackColor="#DDDDDD" ForeColor="#666666" HorizontalAlign="right" VerticalAlign="Middle" Height="40px" Font-Bold="True" Font-Size="14px" />
                <RowStyle CssClass="GridItemStyle" HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="Black" Font-Size="14px" Height="35px" />
            </asp:GridView>

            <asp:ObjectDataSource ID="ObjectDataSource_Project" runat="server" EnablePaging="True" SelectMethod="GetProvider_SupperDate"
                SelectCountMethod="GetProvider_Count_SupperDate" TypeName="Ironika_Theme1.Models.Order_Manager" DeleteMethod="delete" OnSelecting="ObjectDataSource_Project_Selecting">
                <DeleteParameters>
                    <asp:Parameter Name="OrderId" Type="Int32" />
                </DeleteParameters>
                <SelectParameters>
                    <asp:Parameter Name="SupperId" Type="Int32" />
                    <asp:Parameter Name="StartDate" Type="DateTime" />
                    <asp:Parameter Name="EndDate" Type="DateTime" />
                    <asp:Parameter Name="Text" Type="String" />
                    <asp:Parameter Name="startRowIndex" Type="Int32" />
                    <asp:Parameter Name="maximumRows" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </div>
     <div class="modal fade" id="ModalRegister" style="width: 80% !important; left: 10% !important; right: 10% !important" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="direction: rtl; text-align: right">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title">مشخصات فاکتور خرید</h4>
                </div>
                <div class="modal-body" style="direction: rtl; text-align: right">
                    <div class="card">
                        <div class="card-body">
                            <!-- Content Header (Page header) -->


                            <!-- Main content -->
                            <section class="invoice">
                                <!-- title row -->
                                <div class="row mt-3">
                                    <div class="col-lg-4">
                                        <h4 id="DivNo" runat="server"></h4>
                                    </div>
                                    <div class="col-lg-4">
                                        <h5 id="DivName" runat="server"></h5>
                                    </div>
                                    <div class="col-lg-4">
                                        <h5 class="float-sm-right" id="DivDate" runat="server"></h5>
                                    </div>
                                </div>

                                <hr>
                                <div class="row invoice-info">
                                    <div class="col-sm-4 invoice-col">
                                        سفارش دهنده :
                        <address id="DivOner" runat="server">
                        </address>
                                    </div>
                                    <!-- /.col -->
                                    <div class="col-sm-4 invoice-col">
                                        تحویل گیرنده :
                        <address id="DivDelivery" runat="server">
                        </address>
                                    </div>
                                    <!-- /.col -->
                                    <div class="col-sm-4 invoice-col">
                                        <b id="DivNo1" runat="server"></b>
                                        <br>
                                        <br>
                                        <b>تعداد اقلام کل سفارش:</b><span id="DivCount" runat="server"></span><br>
                                        <b>مبلغ کل پرداختی:</b><span id="DivAllPrice" runat="server"></span><br>
                                    </div>
                                    <!-- /.col -->
                                </div>
                                <!-- /.row -->

                                <!-- Table row -->
                                <div class="row">
                                    <div class="col-12 table-responsive" id="DivTabel" style="height: 200px; max-height: 200px; overflow: auto" runat="server">
                                    </div>
                                    <!-- /.col -->
                                </div>
                                <!-- /.row -->

                                <div class="row">
                                    <!-- accepted payments column -->
                                    <div class="col-lg-6 payment-icons">
                                        <p class="lead">آدرس ارسالی:</p>

                                        <p id="DivAddress" runat="server" class="bg-light p-2 mt-3 rounded">
                                        </p>
                                    </div>
                                    <!-- /.col -->
                                    <div class="col-lg-6">
                                        <p class="lead">مبلغ پرداختی </p>
                                        <div class="table-responsive">
                                            <table class="table">
                                                <tbody>
                                                    <tr>
                                                        <th style="width: 50%">جمع کل:</th>
                                                        <td id="DivTottal" runat="server"></td>
                                                    </tr>


                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                    <!-- /.col -->
                                </div>
                                <!-- /.row -->

                                <!-- this row will not appear when printing -->
                                <hr>
                                <div class="row no-print">
                                    <div class="col-lg-3">
                                        <asp:HiddenField ID="HiddenField1" runat="server" />
                                    </div>
                                    <div class="col-lg-9">
                                        <div class="float-sm-right">
                                            <button type="button" id="BtnPrint" onclick="target ='_blank';" runat="server" onserverclick="BtnPrint_ServerClick" class="btn btn-success m-1"><i class="fa fa-credit-card"></i>چاپ فاکتور</button>

                                        </div>
                                    </div>
                                </div>
                            </section>
                            <!-- /.content -->
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>






