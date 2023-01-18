<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container mt-5 ms-auto">
        <div class="card border-primary">
            <div class="card-header fs-1">
                
                <asp:image id="img_profile" imageurl="~/ProfilePics/admin_iron-man-superhero-minimal-4k-1t.jpg" runat="server" cssclass="rounded-circle" width="180" height="180" />
                <asp:label id="lb_pname" runat="server" />
                <button runat="server" onserverclick="editPname_ServerClick" id="editPname" class="btn btn-secondary"><i class="bi bi-pencil-fill">Edit</i></button>
                <asp:panel id="Panel1" runat="server" visible="false">
                    <asp:Label ID="lb_username" Text="Enter new username: " runat="server" Font-Size="24"/>
                    <asp:TextBox ID ="tb_updatedUser" runat="server" Font-Size="16"/>
                    <asp:Button ID="btn_update" runat="server" OnClick="btn_update_click" Text="Update" CssClass="btn btn-primary"/>
                    <br />
                     <asp:FileUpload ID="fu_profile" runat="server" Font-Size="16" accept=".png,.jpg,.jpeg,.gif" />
                    <asp:Button ID="btn_updatePic" runat="server" Text="Upload pic" OnClick="btn_updatePic_Click" CssClass="btn btn-primary"/>
                </asp:panel>
            </div>


            <div class="row w-75 m-auto">
                <div class="col">
                    <div class="card border-primary m-3 " style="max-width: 20rem;">
                        <div class="card-body">
                            <h4 class="card-title text-center fs-1" runat="server" id="lb_countFollowers">250K</h4>
                        </div>
                        <button runat="server" onserverclick="btn_Followers_ServerClick" id="btn_Followers" class="card-header fs-3 bg-primary text-white text-center">Followers</button>
                    </div>
                </div>

                <div class="col">
                    <div class="card border-primary m-3" style="max-width: 20rem;">
                        <div class="card-body">
                            <h4 class="card-title text-center fs-1" runat="server" id="lb_countFollowing">100K</h4>
                        </div>
                        <%--<div class="card-header fs-3 bg-primary text-white text-center">Following</div>--%>
                        <button runat="server" onserverclick="btn_Followers_ServerClick" id="btn_Following" class="card-header fs-3 bg-primary text-white text-center">Following</button>
                    </div>
                </div>
                <div class="col">
                    <div class="card border-primary m-3" style="max-width: 20rem;">
                        <div class="card-body">
                            <h4 class="card-title text-center fs-1" runat="server" id="lb_countPost">10</h4>
                        </div>
                        <div class="card-header fs-3 bg-primary text-white text-center">Posts</div>
                    </div>
                </div>
            </div>

            <%--<div class="card-body">
                <h4 class="card-title">Primary card title</h4>
                <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
            </div>--%>
        </div>


<%--        <div class="card mb-5 border-primary w-50 mt-5    ">
            <h3 class="card-header" id="card_profileName" runat="server">Profile name</h3>
            <div class="card-body">
                <h5 class="card-title" id="card_title_profile" runat="server">Special title treatment</h5>
            </div>
            
            <asp:image id="img_post" runat="server" imageurl="PostImg/1.jpg" cssclass="img-fluid" />
            <div class="card-body">
                <p class="card-text" runat="server" id="card_des_profile">Description</p>
            </div>
            <div class="card-body">
                <h3 runat="server" id="card_like_profile"></h3>
                <button  class="btn btn-outline-primary" runat="server" onserverclick="Unnamed_ServerClick">
                    <i class="bi bi-hand-thumbs-up-fill"></i>Like</button>

            </div>--%>
        </div>
            <asp:Panel runat="server" ID="pan_posts" />
</asp:Content>

