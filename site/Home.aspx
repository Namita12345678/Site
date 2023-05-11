<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="site.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--<link href="Site/Css/Background.css" rel="stylesheet" />--%>
    <script>
        .font{
            font
    }
    </script>
    
    
</head>
<body>
    
   <form id="form1" runat="server">
       
        <section class="vh-500"  style= "background-image: url('https://wallpaperaccess.com/full/233066.jpg'); height:100vh; ">
       
   <div style="margin-left: auto; margin-right: auto; text-align:center; padding: 250px 0;">
<%--    <asp:Label ID="Label" runat="server" Text="Welcome"  Font-Size="30"></asp:Label>--%>
       <asp:LinkButton ID="lnk" runat="server" Text="Welcome" Style="color:black;font-size: 4rem;
text-decoration: none;" OnClick="lnk_Click"></asp:LinkButton>
  </div>





       

</section>
</form>
</body>
</html>