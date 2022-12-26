<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditProfile.aspx.cs" Inherits="EditProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container d-flex align-items-center justify-content-center border">
        
            <asp:TextBox ID="tb_editPname" runat="server" />
            <asp:Button ID="btn_edit" runat="server" OnClick="btn_edit_Click"/>
        
    </div>
</asp:Content>

