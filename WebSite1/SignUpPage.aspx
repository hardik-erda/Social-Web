<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignUpPage.aspx.cs" Inherits="SignUpPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.2/font/bootstrap-icons.css" />
</head>
<body>
   <div class="container d-flex justify-content-center align-items-center">
        <div class="card border-primary mb-3 " style="max-width: 20rem;">
            <div class="card-header">Sign Up</div>
            <div class="card-body">
                <form runat="server" >
                    <label class="form-label" >Enter Username</label>
                    <asp:TextBox ID="tb_username" runat="server" class="form-control"></asp:TextBox>
                    <label class="form-label">Create new Password</label>
                    <asp:TextBox ID="tb_password" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
                    <label class="form-label">Profile Image: </label>
                    <asp:FileUpload ID="fu_profile" runat="server"  accept=".png,.jpg,.jpeg,.gif"/>
                    <asp:button class="btn btn-primary mt-3" runat="server" type="submit" id="btn_signUp" Text="Sign up" OnClick="btn_signUp_Click"></asp:button><br/>
                    <a href="LoginPage.aspx"  class="text-secondary ">Already have account?</a><br />
                    <asp:Label ID="lb_msg" ForeColor="Red" runat="server"></asp:Label>
                    </form>
            </div>
        </div>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
</body>
</html>
