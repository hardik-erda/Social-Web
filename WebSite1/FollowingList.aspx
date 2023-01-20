<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FollowingList.aspx.cs" Inherits="FollowingList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:Panel runat="server" ID="pan_searchlist"/>
    <div class="card mb-5 border-primary w-50 mt-5 p-2 mx-auto " id="div" runat="server">
        <label class="card-header text-danger">your are not Following anyone !!</label>
    </div>
</asp:Content>

