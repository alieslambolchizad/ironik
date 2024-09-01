<%@ Page Title="" Language="C#" MasterPageFile="~/Panel/Shop/Site1.Master" AutoEventWireup="true" CodeBehind="ChangePass.aspx.cs" Inherits="Ironika_Theme1.Panel.Shop.ChangePass" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>تغییر کلمه عبور/پنل کاربری</title>
    <style>
        .RadToolTip, RadToolTip * {
            top: 25% !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_TitlePage" runat="server">
    <li><a href="/">خانه</a> </li>
    <li class="active">تغییر کلمه عبور</li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_PageName" runat="server">
    <h1>تغییر کلمه عبور</h1>
    <small class="subtitle">صفحه تغییر کلمه عبور </small>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder_Body" runat="server">
    <div class="panel widget light-widget">
        <div class="panel-heading no-title"></div>

        <div class="panel-body">
            <h2 class="mgbt-xs-20">تغییر کلمه عبور
            </h2>
            <div class="form-horizontal">

                <div class="form-group">
                    <div class="col-md-6">
                        <div class="label-wrapper">
                            <label class="control-label">کلمه عبور قبلی <span class="vd_red">*</span></label><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtOldPass" ForeColor="Red" ValidationGroup="as_Register" ErrorMessage="کلمه عبور قبلی را وارد کنید"></asp:RequiredFieldValidator>
                        </div>
                        <div class="vd_input-wrapper">
                            <asp:TextBox runat="server" TextMode="Password" class="required" ID="TxtOldPass"></asp:TextBox>

                            <asp:HiddenField ID="hi_Id" runat="server" />


                        </div>
                    </div>
                    <div class="col-md-6">
                    </div>
                </div>

                <div class="form-group">

                    <div class="col-md-6">
                        <div class="label-wrapper">
                            <label class="control-label">کلمه عبور جدید <span class="vd_red">*</span></label><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtNewpass" ForeColor="Red" ValidationGroup="as_Register" ErrorMessage="کلمه عبور جدید را وارد کنید"></asp:RequiredFieldValidator>
                        </div>
                        <div class="vd_input-wrapper" id="first-name-input-wrapper">
                            <asp:TextBox runat="server" TextMode="Password" class="required" ID="TxtNewpass"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="label-wrapper">
                            <label class="control-label">تکرار کلمه عبور جدید <span class="vd_red">*</span></label><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtDuplicatepass" ForeColor="Red" ValidationGroup="as_Register" ErrorMessage="تکرار کلمه عبور جدید را وارد کنید"></asp:RequiredFieldValidator>
                        </div>
                        <div class="vd_input-wrapper">
                            <asp:TextBox runat="server" TextMode="Password" class="required" ID="TxtDuplicatepass"></asp:TextBox>
                        </div>
                    </div>


                </div>




                <div class="form-group">

                    <div class="col-md-12 mgbt-xs-5" style="direction: rtl; text-align: center">


                        <asp:Button class="btn vd_btn vd_btn-bevel vd_bg-green font-semibold" Width="120px" runat="server" ValidationGroup="as_Register" ID="submit_register" OnClick="submit_register_Click" Text="ثبت"></asp:Button>
                        <asp:Button class="btn vd_btn vd_btn-bevel vd_bg-yellow font-semibold" Width="120px" runat="server" ID="BtnCancel" OnClick="BtnCancel_Click" Text="پاک کردن"></asp:Button>
                        <br />
                        <asp:CompareValidator ID="rg1" runat="server" ControlToValidate="TxtDuplicatepass" ValidationGroup="as_Register" ControlToCompare="TxtNewpass" ForeColor="Red" ErrorMessage="کلمه عبور با تکرار آن مطابقت ندارد"></asp:CompareValidator>
                        <asp:Literal ID="Literal_Message" runat="server"></asp:Literal>
                        <telerik:RadToolTip ID="RadToolTip_Message" Position="Center" class="PopUpMy" runat="server"></telerik:RadToolTip>

                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>




