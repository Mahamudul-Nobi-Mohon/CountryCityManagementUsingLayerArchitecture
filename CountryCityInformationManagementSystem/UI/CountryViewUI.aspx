<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CountryViewUI.aspx.cs" Inherits="CountryCityInformationManagementSystem.UI.CountryViewUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <html lang="en" />
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Bootstrap 101 Template</title>

    <!-- Bootstrap -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
    <style type="text/css">
        .auto-style1 {
            width: 129px;
        }
    </style>
    <style type="text/css">
        .GridviewDiv {
            font-size: 100%;
            font-family: 'Lucida Grande', 'Lucida Sans Unicode', Verdana, Arial, Helevetica, sans-serif;
            color: #303933;
        }

        .headerstyle {
            color: #FFFFFF;
            border-right-color: #abb079;
            border-bottom-color: #abb079;
            background-color: #df5015;
            padding: 0.5em 0.5em 0.5em 0.5em;
            text-align: center;
        }
    </style>
</head>
<body>

    <form id="form1" runat="server">
        <div class="container">
            <div class="col-md-10 col-md-offset-1">
                    <table class="tab-content table table-bordered table-responsive">
                        <tr>
                            <div class="form-group">
                                <td class="auto-style1">
                                    <asp:Label ID="countryNameLabel" Text="Country Name" runat="server" />

                                </td>
                                <td>
                                    <asp:TextBox ID="countryNameTextBox" class="form-control" runat="server"></asp:TextBox>

                                </td>
                                <td>
                                    <asp:Button ID="searchButton" runat="server" class="btn btn-default" Text="Search" OnClick="searchButton_Click" />
                                </td>
                            </div>
                        </tr>

                    </table>
                    <asp:Label ID="messageLabel" runat="server"></asp:Label>
                    <br />

                    <div class="GridviewDiv">
                        <asp:GridView runat="server" ID="countryListGridView" AllowPaging="true" PageSize="10" AutoGenerateColumns="false" Width="100%" OnPageIndexChanging="gvDetails_PageIndexChanging">
                            <HeaderStyle CssClass="headerstyle" />
                            <Columns>
                                <asp:TemplateField HeaderText="serial No">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:BoundField DataField="Name" HeaderText="Country Name" />
                                <%--<asp:BoundField DataField="about" HeaderText="About" />--%>
                                <asp:TemplateField HeaderText="About">
                                          <ItemTemplate>
                                              <asp:Label runat="server" Text='<%#Eval("about") %>'></asp:Label>
                                          </ItemTemplate>
                                 </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
            
    </form>
    
    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="js/bootstrap.min.js"></script>
</body>
</html>



