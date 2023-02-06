<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="dashboard.aspx.cs" Inherits="dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
    <asp:ScriptManager ID="SM_post" runat="server" />
    <asp:UpdatePanel ID="UP_SM_post" runat="server">
        <ContentTemplate>
    <div class="container mt-5 w-50" id="pan_posts" runat="server">
                <%--<asp:Panel ID="pan_posts" runat="server" />--%>
    </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

