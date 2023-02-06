<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignUpPage.aspx.cs" Inherits="SignUpPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet.css" rel="stylesheet" />
    <!-- Font Awesome -->
    <link
      href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css"
      rel="stylesheet"
    />
    <!-- Google Fonts -->
    <link
      href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap"
      rel="stylesheet"
    />
    <!-- MDB -->
    <link
      href="https://cdnjs.cloudflare.com/ajax/libs/mdb-ui-kit/6.1.0/mdb.min.css"
      rel="stylesheet"
    />
    <!-- MDB -->
    <script
      type="text/javascript"
      src="https://cdnjs.cloudflare.com/ajax/libs/mdb-ui-kit/6.1.0/mdb.min.js"
    ></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.2/font/bootstrap-icons.css" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" ></script>
</head>
<body>
    <section class="vh-100">
      <div class="container py-5 h-100">
        <div class="row d-flex justify-content-center align-items-center h-100">
          <div class="col-12 col-md-8 col-lg-6 col-xl-5">
            <div class="card shadow-5-strong" style="border-radius: 1rem;">
              <div class="card-body p-5">
                
                <div class="text-center">
                    <h3 class="mb-5">Sign Up</h3>
                </div>
                <form runat="server">

                    <div class="form mb-4">
                      <label class="form-label" for="tb_username">Enter Username:</label>
                      <asp:TextBox ID="tb_username" runat="server" class="form-control"></asp:TextBox>  
                    </div>

                    <div class="form mb-4">
                      <label class="form-label" for="typePasswordX-2">Create new Password:</label>
                      <asp:TextBox ID="tb_password" runat="server" class="form-control" TextMode="Password"></asp:TextBox>  
                    </div>

                    <div class="form mb-5">
                      <label class="form-label" for="typePasswordX-2">Profile Image:</label>
                      <asp:FileUpload ID="fu_profile" runat="server"  accept=".png,.jpg,.jpeg,.gif" CssClass="form-control"/>
                    </div>

                    <asp:button class="btn btn-dark btn-lg btn-block" runat="server" type="submit" id="btn_signUp" Text="Sign Up" OnClick="btn_signUp_Click"></asp:button>
                    
                    <div class="mt-4 text-center">
                      <p class="mb-0">Already have an account? <a href="LoginPage.aspx" class="fw-bold" runat="server">Login</a>
                      </p>
                    </div>
                    <asp:Label ID="lb_msg" ForeColor="Red" runat="server"></asp:Label>
                </form>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
</body>
</html>
