<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddNewPost.aspx.cs" Inherits="AddNewPost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="d-flex justify-content-center mt-5">
    <div class="card mb-5 border-dark w-50 p-5">
        <label class="card-text h4">Title for post: </label>
        <asp:TextBox ID="tb_title" runat="server" CssClass="form-control mb-3 mt-2"/>
        <label class="card-text mb-2 h4">Img for post: </label>
        <asp:FileUpload runat="server" ID="fu_post" accept=".png,.jpg,.jpeg,.gif" CssClass="form-control"/>
        <label class="card-text mt-3 mb-2 h4">Description for post: </label>
        <textarea id="ta_des" runat="server" class="form-control"/>
        <asp:Button runat="server" ID="btn_post" Text="Post" OnClick="btn_post_Click" CssClass="btn btn-dark mt-3"/>
    </div>
    </div>
</asp:Content>

