


<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageCity.aspx.cs" Inherits="site.ManageCity" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
           <nav>
                 <section class="vh-800"  style= "background-color:lightskyblue">
        <div class="row" style="margin-left:-3px;margin-top:20px;margin-bottom:20px";">
       
    <div class="row" style="margin-left: auto; margin-right: auto; text-align: center;">
        <asp:LinkButton ID="counrty" runat="server" Text="Country" Style="font-size:25px;" OnClick="btn_Click1"></asp:LinkButton>

        <asp:LinkButton ID="LinkButton1" runat="server"  Text="State" Style="margin-left:5px;font-size:25px;" OnClick="btn_Click2"></asp:LinkButton>
       
        <asp:LinkButton ID="LinkButton2" runat="server"  Text="City" Style="margin-left:5px;font-size:25px;" OnClick="btn_Click3"> </asp:LinkButton>


        </div>
       
       </div>
     </section>
    </nav>
       
       <div style="margin-left: auto; margin-right: auto; text-align: center;">
    <asp:Label ID="Label" runat="server" Text="City"  Font-Size="30"></asp:Label>
           <br />
           <br />
 
        <table style="padding-left:500px" class="table table-responsive">
            <tr>
                <td width="40%"> Select Country :</td>
                <td>
                    <asp:DropDownList runat="server" ID="drpcountry" OnSelectedIndexChanged="Drpcountry_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>

                </td>
            </tr>
            <tr>
                <td width="40%"> Select State :</td>
                <td>
                    <asp:DropDownList runat="server" ID="drpstate"></asp:DropDownList>

                </td>
            </tr>
            <tr>
                <td>City Name:</td>
                <td>
                    <asp:TextBox runat="server" ID="txtcityname">

                    </asp:TextBox></td>
            </tr>
           
            <tr>
                <td>Is Display:</td>
                <td>
                    <asp:CheckBox runat="server" ID="chkisdisplay" /></td>
            </tr>
            <tr>
                <td colspan="2"><center>
                    
                   <asp:Button  runat="server" ID="btnsubmit" Text="Submit" OnClick="btnsubmit_Click"/>
                 <asp:Label runat="server" ID="lblid" Visible="false"></asp:Label>
                     </center></td>

              
            </tr>
            
        </table>

            <asp:Repeater ID="rptr" runat="server" OnItemCommand="rptr_ItemCommand">
                    <HeaderTemplate>
                        <table id="data-table-basic" class="table table-striped" style="margin-left:450px">
                            <thead>
                                <tr>
                                    <th>Sr.No</th>
                                    <th>Country </th>
                                     <th>State </th>
                                    <th>City </th>
                                    <th>Edit</th>
                                    <th>Delete</th>
                                </tr>
                            </thead>

                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>

                        <tr>
                            <td><%#  Container.ItemIndex + 1 %></td>
                             <td><%#Eval("Cot.CountryName")%></td>
                            <td><%#Eval("St.StateName")%></td>
                            <td><%#Eval("Ct.CityName")%></td>
                            <td>

                                <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit" ToolTip="Edit" CommandArgument='<%#Eval("Ct.CityId")%>' class="btn btn-login btn-success btn-float ">
                                </asp:LinkButton>


                            </td>
                            <td>
                                <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" ToolTip="Delete" CommandArgument='<%#Eval("Ct.CityId")%>' class="btn btn-login btn-danger btn-float" OnCityClick="javascript:return window.confirm('Are You Sure You Want To Delete?')">
                                </asp:LinkButton>
                            </td>
                        </tr>


                    </ItemTemplate>
                   
                                   
          
                </asp:Repeater>
               
    </form>
   
</body>
</html>
