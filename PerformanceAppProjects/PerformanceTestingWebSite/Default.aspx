<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://www.google.com/jsapi"></script>
    <script src="Scripts/Chart.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="sm" runat="server">
        </asp:ScriptManager>
        <div id="mainPage">
            <%--<div id="menuPanel">
                <h2>Menu</h2>
            </div>--%>
            <div id="postPanel">
                <div class="post">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div id="GLResultsChart" style="height: 500px;" runat="server"></div>
                            <br />
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="GLButton" />
                        </Triggers>
                    </asp:UpdatePanel>  
                </div>
                <div class="post">
                     <asp:GridView ID="GLDeviceList" runat="server" CellPadding="4" 
                        EnableModelValidation="True" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="Enabled">
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    </asp:GridView>
                    <br />
                    <asp:Button ID="GLButton" runat="server" Text="Draw Chart" 
                        onclick="DrawGLButton_Click"></asp:Button>
                </div>  
                <div class="post">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div id="FLOPResultsChart" style="height: 500px;" runat="server"></div>
                            <br />
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="FLOPSButton" />
                        </Triggers>
                    </asp:UpdatePanel>  
                </div>
                <div class="post">
                     <asp:GridView ID="FLOPDeviceList" runat="server" CellPadding="4" 
                        EnableModelValidation="True" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="Enabled">
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    </asp:GridView>
                    <br />
                    <asp:Button ID="FLOPSButton" runat="server" Text="Draw Chart" 
                        onclick="DrawFLOPSButton_Click"></asp:Button>
                </div>  
            </div>
            
        </div>
    </form>
</body>
</html>
