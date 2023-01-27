<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section>
        <div class="container py-5 h-100">
            <div class="row d-flex justify-content-center h-100">
                <div class="col ">
                    <div class="card" style="border-radius: 15px;">
                        <div class="card-body p-4">
                            <div class="d-flex text-black">
                                <div class="flex-shrink-0">
                                    <asp:Image ID="img_profile" ImageUrl="~/ProfilePics/admin_iron-man-superhero-minimal-4k-1t.jpg" runat="server"
                                        alt="Generic placeholder image" CssClass="img-fluid"
                                        Style="width: 400px; border-radius: 10px;" />
                                </div>
                                <div class="ms-3">
                                    <asp:Label ID="lb_pname" CssClass="h1 text-uppercase" runat="server"></asp:Label>
                                    <div class="d-flex justify-content-start rounded-3 p-2 mb-4 mt-4"
                                        style="background-color: #efefef;">
                                        <div>
                                            <h5 class="text-muted mb-1">Photos</h5>
                                            <p id="lb_countPost" class="mb-0" runat="server">253</p>
                                        </div>
                                        <div class="px-3">
                                            <h5 class="text-muted mb-1">Followers</h5>
                                            <p class="mb-0" runat="server" id="lb_countFollowers">1026</p>
                                        </div>
                                        <div>
                                            <h5 class="text-muted mb-1">Following</h5>
                                            <p class="mb-0" runat="server" id="lb_countFollowing">478</p>
                                        </div>
                                    </div>
                                    <div class="d-flex pt-1">
                                        <button runat="server" onserverclick="editPname_ServerClick" id="Button3" type="button" class="btn btn-outline-primary mt"
                                            style="z-index: 1;">
                                            Edit profile
                                        </button>
                                    </div>
                                </div>
                            </div>
                            <asp:Panel ID="Panel1" runat="server" Visible="false" CssClass="mt-4">
                                <asp:Label ID="Label2" Text="Enter new username: " runat="server" />
                                <asp:TextBox ID="tb_updatedUser" runat="server" Width="40%" />
                                <asp:Button ID="Button4" runat="server" OnClick="btn_update_click" Text="Update" CssClass="btn btn-primary" />
                                <br />
                                <asp:FileUpload ID="fu_profile" runat="server" accept=".png,.jpg,.jpeg,.gif" CssClass="mt-3 mb-1" />
                                <asp:Button ID="Button5" runat="server" Text="Upload pic" OnClick="btn_updatePic_Click" CssClass="btn btn-primary" />
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
    <asp:Panel runat="server" ID="pan_posts" />
        </div>
    </section>
</asp:Content>
