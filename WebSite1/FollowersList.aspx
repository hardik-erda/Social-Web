﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FollowersList.aspx.cs" Inherits="FollowersList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="d-flex">

    <div class="m-auto text-center w-50" >
    <asp:Panel runat="server" ID="pan_searchlist"/>
    </div>
    </div>
    <div class="card mb-5 border-dark w-50 mt-5 p-2 ms-5" id="div" runat="server">
        <label class="card-header text-danger">No Follower Found !!</label>
    </div>
</asp:Content>

