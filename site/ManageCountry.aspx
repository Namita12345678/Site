
 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageCountry.aspx.cs" Inherits="site.ManageCountry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   
    <form runat="server">
         <nav>
              <section class="vh-200"  style= "background-color:lightskyblue">
        <div class="row" style="margin-left:-3px;margin-top:20px;margin-bottom:20px";">
       
    <div class="row" style="margin-left: auto; margin-right: auto; text-align: center;">
        <asp:LinkButton ID="country" runat="server" Text="Country" Style="font-size:25px;" OnClick="btn_Click1"></asp:LinkButton>

        <asp:LinkButton ID="LinkButton1" runat="server"  Text="State" Style="margin-left:5px;font-size:25px;" OnClick="btn_Click2"></asp:LinkButton>
       
                <asp:LinkButton ID="LinkButton2" runat="server"  Text="City" Style="margin-left:5px;font-size:25px;" OnClick="btn_Click3"> </asp:LinkButton>


        </div>
       
       </div>
     </section>
    </nav>

         <%--<div class="col-sm-3">
                         <div class="toggle-switch toggle-switch-demo" data-ts-color="blue">
                                        <label for="ts3" class="ts-label">IsDisplay</label>
                                        <input id="ts3" type="checkbox" hidden="hidden" runat="server" ClientIdMode="Static" checked="checked" />
                                        <label for="ts3" class="ts-helper"></label>
                                    </div>
                      
                    </div>--%>
        
      <div style="margin-left: auto; margin-right: auto; text-align: center;">
    <asp:Label ID="Label" runat="server" Text="Country"  Font-Size="30"></asp:Label>
  </div>

  <table style="padding-left:500px" class="table table-responsive">
            <tr>
              <td>Country Name</td>
                <td>Country code</td>
                <th></th>
            </tr>
            <tr>
                   <td><%--<input type="text" id="txtname" class="form-control" />--%>
                       <asp:TextBox ID="txtname" runat="server" class="form-control"></asp:TextBox>
                   </td>
                <td><%--<input type="text" id="txtcode" class="form-control" />--%>
                    <asp:TextBox ID="txtcode" runat="server" class="form-control"></asp:TextBox>
                </td>
                </tr>

           
               <tr>
                  <td colspan="2"><center><asp:CheckBox runat="server" ID="chkisdisplay" Text="Is Display" /></center></td>
                   </tr>
           
            <tr>
                <td colspan="2"><center><asp:Button  runat="server" ID="btnsubmit" Text="Submit" OnClick="btnsubmit_Click"/></td>
                <asp:Label runat="server" ID="lblid" Visible="false"></asp:Label></center>
                </tr>

 


        </table>
        <br>
        <br>

        <asp:Repeater ID="rptr" runat="server" OnItemCommand="rptr_ItemCommand">
                    <HeaderTemplate>
                        <table id="data-table-basic" class="table table-striped" style="margin-left:470px">
    

                            <thead >

                                <tr>
                            
                                    <th>Sr.No</th>
                                   
                                    <th>Country Name</th>
                                    <th>Country Code</th>
                                    <th>Edit</th>
                                    <th>Delete</th>
                                </tr>
                            </thead>

                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>

                        <tr >
                            <td ><%#  Container.ItemIndex + 1 %></td>

                           
                            <td><%#Eval("CountryName")%></td>
                            <td><%#Eval("CountryCode")%></td>
                            <td>

                                <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit" ToolTip="Edit" Text="Edit" CommandArgument='<%#Eval("CountryId")%>' class="btn btn-login btn-success btn-float ">
                                </asp:LinkButton>


                            </td>
                            <td>
                                <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" ToolTip="Delete" Text="Delete" CommandArgument='<%#Eval("CountryId")%>' class="btn btn-login btn-danger btn-float" OnCountryClick="javascript:return window.confirm('Are You Sure You Want To Delete?')">
                                </asp:LinkButton>
                            </td>
                        </tr>


                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                                
                        </table>
                                   
                    </FooterTemplate>
                </asp:Repeater>
    </form>



</body>
</html>
