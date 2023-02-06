<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PostEditForm.aspx.cs" Inherits="PostEditForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="card-body w-50 mx-auto">
        <label>Post Title</label>
        <asp:TextBox runat="server" ID="tb_postTitle" CssClass="form-control mb-3" />
        <asp:Image runat="server" ID="img_postImg" CssClass="img-thumbnail w-50" ImageUrl="postImg/1.jpg" />
        <asp:FileUpload runat="server" ID="fu_postImg" CssClass="form-control mb-3" />
        <label>Post Description</label>
        <asp:TextBox runat="server" ID="tb_postDes" CssClass="form-control mb-3" />
        <asp:Button runat="server" ID="btn_submit" CssClass="btn btn-primary" Text="Submit" OnClick="btn_submit_Click"/>
    </div>
</asp:Content>

