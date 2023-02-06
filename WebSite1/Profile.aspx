<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <section>
        <div class="container py-5 h-100">
            <div class="row  justify-content-center h-100  w-100 ">
                <div class="col ">
                    <div class="card" style="border-radius: 15px;">
                        <div class="card-body p-4">
                            <div class="d-block text-black">
                                <div class="flex-shrink-0">
                                    <asp:Image ID="img_profile" runat="server"
                                        alt="Generic placeholder image" CssClass="img-fluid"
                                        Style="width: 400px; border-radius: 10px;" />
                                    <asp:Label ID="lb_pname" CssClass="h1 text-uppercase" runat="server"></asp:Label>
                                    <asp:Button ID="btn_edit" Text="Edit" OnClick="editPname_ServerClick" runat="server" CssClass="btn btn-dark ms-3" />
                                </div>
                            </div>
                        
                                <%--old--%>

                                <div class="row w-75 m-auto mt-2">
                                    <div class="col">
                                        <div class="card border-dark m-3 " style="max-width: 20rem;">
                                            <div class="card-body">
                                                <h4 class="card-title text-center fs-1" runat="server" id="lb_countFollowers">250K</h4>
                                            </div>
                                            <button runat="server" onserverclick="btn_Followers_ServerClick" id="btn_Followers" class="card-header fs-3 bg-dark text-white text-center">Followers</button>
                                        </div>
                                    </div>

                                    <div class="col">
                                        <div class="card border-dark m-3" style="max-width: 20rem;">
                                            <div class="card-body">
                                                <h4 class="card-title text-center fs-1" runat="server" id="lb_countFollowing">100K</h4>
                                            </div>
                                            <%--<div class="card-header fs-3 bg-dark text-white text-center">Following</div>--%>
                                            <%--<button runat="server" onserverclick="btn_Following_ServerClick" id="btn_Following" class="card-header fs-3 bg-dark text-white text-center">Following</button>--%>
                                            <asp:LinkButton OnClick="btn_Following_ServerClick" ID="btn_Following" class="card-header fs-3 bg-dark text-white text-center text-decoration-none" runat="server" Text="Following"></asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="col">
                                        <div class="card border-dark m-3" style="max-width: 20rem;">
                                            <div class="card-body">
                                                <h4 class="card-title text-center fs-1" runat="server" id="lb_countPost">10</h4>
                                            </div>
                                            <div class="card-header fs-3 bg-dark text-white text-center">Posts</div>
                                        </div>
                                    </div>
                                </div>
                             </div>
                        <div class="m-auto mb-4">

                        <asp:Panel ID="Panel1" runat="server" Visible="false" CssClass="mt-4">
                            <asp:Label ID="Label2" Text="Enter new username: " runat="server" />
                            <asp:TextBox ID="tb_updatedUser" runat="server" Width="40%"/>
                            <asp:Button ID="Button4" runat="server" OnClick="btn_update_click" Text="Update" CssClass="btn btn-dark" />
                            <br />
                            <asp:FileUpload ID="fu_profile" runat="server" accept=".png,.jpg,.jpeg,.gif" CssClass="mt-3 mb-1 form-control" />
                            <asp:Button ID="Button5" runat="server" Text="Upload pic" OnClick="btn_updatePic_Click" CssClass="btn btn-dark form-control" />
                        </asp:Panel>
                        </div>
                    </div>
                            </div>
                    </div>
                </div>

                                <%--<div class="card-body">
                <h4 class="card-title">dark card title</h4>
                <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
            </div>--%>
  
        <asp:Panel runat="server" ID="pan_posts" />

    </section>

</asp:Content>
