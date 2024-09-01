<%@ Page Title="" Language="C#" MasterPageFile="~/Panel/Shop/Site1.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Ironika_Theme1.Panel.Shop.Contact" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>اطلاعات تماس/پنل کاربری</title>
    <style>
        .RadToolTip, RadToolTip * {
            top: 25% !important;
        }

        #ctl00_ContentPlaceHolder_Body_TxtPrice {
            font-family: webyekan !important;
            height: 30px !important;
            padding: 4px 6px !important;
            width: 220px !important;
        }

        html body .RadInput_Default .riTextBox, html body .RadInputMgr_Default {
            background-color: #E5E5E5 !important;
            border: 0px !important;
        }

        .RadUpload .ruFileWrap {
            height: 46px !important;
        }

        .RadUpload_Default .ruButton {
            display: none !important;
        }

        .RadUpload .ruBrowse {
            background-position: unset !important;
            width: 100px !important;
        }

        .RadUpload input.ruFileInput {
            font: 20px monospace !important;
        }

        .RadUpload .ruStyled .ruFileInput {
            opacity: 1 !important;
        }

        .RadAsyncUpload span.ruFileWrap {
            width: 100% !important;
        }

        .RadUpload .ruFakeInput {
            height: 30px !important;
            border: 0px !important;
            background-color: #E5E5E5 !important;
        }

        .RadUpload_Default .ruStyled .ruFileInput {
            border: 0px !important;
        }

        .RadUpload {
            width: 100% !important;
        }

        .RadUpload_Default .ruDropZone, .RadUpload_Default_rtl .ruDropZone {
            color: #000;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_TitlePage" runat="server">
    <li><a href="/">خانه</a> </li>
    <li class="active">اطلاعات تماس</li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_PageName" runat="server">
    <h1>اطلاعات تماس</h1>
    <small class="subtitle">مدیریت اطلاعات تماس </small>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder_Body" runat="server">
    <div class="panel widget light-widget">
        <div class="panel-heading no-title"></div>

        <div class="panel-body">
            <h2 class="mgbt-xs-20">مدیریت اطلاعات تماس
            </h2>
            <div class="form-horizontal">

                <div class="form-group">
                    <div class="col-md-6">
                        <div class="label-wrapper">
                            <label class="control-label">عنوان سوپرمارکت <span class="vd_red">*</span></label><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtName" ForeColor="Red" ValidationGroup="as_Register" ErrorMessage="عنوان سوپرمارکت را وارد کنید"></asp:RequiredFieldValidator>
                        </div>
                        <div class="vd_input-wrapper" id="first-name-input-wrapper">
                            <asp:TextBox runat="server" class="required" ID="TxtTitle"></asp:TextBox>

                            <asp:HiddenField ID="hi_Id" runat="server" />
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="label-wrapper">
                            <label class="control-label">لوگوی سوپرمارکت <span class="vd_red">*</span> <span style="color: red; font-size: 14px; font-weight: bold">سایز تصویر 340 در 332 پیکسل می باشد</span></label>
                        </div>
                        <div class="vd_input-wrapper">
                            <telerik:RadAsyncUpload ID="RadAsyncUpload_Logo" MultipleFileSelection="Automatic" runat="server"
                                AllowedFileExtensions="jpg,jpeg,png,gif" AutoAddFileInputs="False"
                                MaxFileSize="150000000" OnClientValidationFailed="validationFailed"
                                OnFileUploaded="RadAsyncUpload_Logo_FileUploaded">
                            </telerik:RadAsyncUpload>
                        </div>

                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-6">
                        <div class="label-wrapper">
                            <label class="control-label">نام مالک سوپر مارکت<span class="vd_red">*</span></label><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TxtName" ForeColor="Red" ValidationGroup="as_Register" ErrorMessage="نام مالک سوپر مارکت را وارد کنید"></asp:RequiredFieldValidator>
                        </div>
                        <div class="vd_input-wrapper">
                            <asp:TextBox runat="server" class="required" ID="TxtName"></asp:TextBox>

                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="label-wrapper">
                            <label class="control-label">نام خانوادگی <span class="vd_red">*</span></label><asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TxtLastName" ForeColor="Red" ValidationGroup="as_Register" ErrorMessage="نام خانوادگی را وارد کنید"></asp:RequiredFieldValidator>
                        </div>
                        <div class="vd_input-wrapper">
                            <asp:TextBox runat="server" class="required" ID="TxtLastName"></asp:TextBox>
                        </div>
                    </div>

                </div>
                <div class="form-group">
                    <div class="col-md-6">
                        <div class="label-wrapper">
                            <label class="control-label">تلفن<span class="vd_red">*</span></label><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtTele" ForeColor="Red" ValidationGroup="as_Register" ErrorMessage="تلفن را وارد کنید"></asp:RequiredFieldValidator>
                        </div>
                        <div class="vd_input-wrapper" id="company-input-wrapper">
                            <asp:TextBox runat="server" class="required" ID="TxtTele"></asp:TextBox>
                            <asp:HiddenField ID="Hi_Logo" runat="server" />
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="label-wrapper">
                            <label class="control-label">موبایل <span class="vd_red">*</span></label><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TxtMobile" ForeColor="Red" ValidationGroup="as_Register" ErrorMessage="موبایل را وارد کنید"></asp:RequiredFieldValidator>
                        </div>
                        <div class="vd_input-wrapper">
                            <asp:TextBox runat="server" class="required" ID="TxtMobile"></asp:TextBox>
                        </div>
                    </div>

                </div>

                <div class="form-group">
                    <div class="col-md-6">
                        <div class="label-wrapper">
                            <label class="control-label">ایمیل </label>
                        </div>
                        <div class="vd_input-wrapper">
                            <asp:TextBox runat="server" class="required" ID="TxtEmail"></asp:TextBox>


                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="label-wrapper">
                            <label class="control-label">واتس آپ </label>
                        </div>
                        <div class="vd_input-wrapper">
                            <asp:TextBox runat="server" class="required" ID="TxtWhatsup"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-6">
                        <div class="label-wrapper">
                            <label class="control-label">تلگرام</label>
                        </div>
                        <div class="vd_input-wrapper">
                            <asp:TextBox runat="server" class="required" ID="TxtTelegram"></asp:TextBox>


                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="label-wrapper">
                            <label class="control-label">اینستاگرام </label>
                        </div>
                        <div class="vd_input-wrapper">
                            <asp:TextBox runat="server" class="required" ID="TxtInstagram"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-12">
                        <div class="label-wrapper">
                            <label class="control-label">آدرس <span class="vd_red">*</span></label><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TxtAddress" ForeColor="Red" ValidationGroup="as_Register" ErrorMessage="آدرس را وارد کنید"></asp:RequiredFieldValidator>
                        </div>
                        <div class="vd_input-wrapper">
                            <asp:TextBox runat="server" class="required" ID="TxtAddress"></asp:TextBox>


                        </div>
                    </div>
                </div>

                <div class="form-group">

                    <div class="col-md-12 mgbt-xs-5" style="direction: rtl; text-align: center">


                        <asp:Button class="btn vd_btn vd_btn-bevel vd_bg-green font-semibold" Width="120px" runat="server" ValidationGroup="as_Register" ID="submit_register" OnClick="submit_register_Click" Text="ثبت"></asp:Button>
                        <asp:Button class="btn vd_btn vd_btn-bevel vd_bg-yellow font-semibold" Width="120px" runat="server" ID="BtnCancel" OnClick="BtnCancel_Click" Text="پاک کردن"></asp:Button>
                        <br />
                        <asp:Literal ID="Literal_Message" runat="server"></asp:Literal>
                        <telerik:RadToolTip ID="RadToolTip_Message" Position="Center" class="PopUpMy" runat="server"></telerik:RadToolTip>

                    </div>
                </div>
            </div>
        </div>
    </div>
   
</asp:Content>
