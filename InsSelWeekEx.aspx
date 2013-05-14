<%@ Page Language="C#" MasterPageFile="~/Instructor.master" AutoEventWireup="true" CodeFile="InsSelWeekEx.aspx.cs" Inherits="InsSelWeekEx" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Height="19px" Style="font-weight: bold;
        font-size: medium; left: 181px; color: limegreen; font-family: Calibri; position: absolute;
        top: 256px; font-variant: normal" Text="Please indicate the course of this test:"
        Width="272px"></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" BackColor="ControlLightLight"
        DataSourceID="SqlDataSource2" DataTextField="course_id" DataValueField="course_id"
        ForeColor="Black" OnDataBound="DropDownList1_DataBound" 
        Style="font-size: small; left: 514px; font-family: Calibri; position: absolute;
        top: 256px" Width="241px">
    </asp:DropDownList>
    <asp:Button ID="Button1" runat="server" Height="41px" OnClick="Button1_Click1" Style="left: 437px;
        position: absolute; top: 299px" Text="Proceed to Next Step" Width="141px" />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        CellPadding="0" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None"
        Height="97px" OnDataBound="GridView1_DataBound" OnLoad="GridView1_Load" 
        PageSize="20" Style="font-size: small; left: 190px; font-family: Calibri; position: absolute;
        top: 368px" Width="537px" DataKeyNames="lo_id">
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <asp:TemplateField HeaderText="Select which topic/s to add" SortExpression="topic_id">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("topic_id") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <table style="width: 658px">
                        <tr>
                            <td style="width: 153px; height: 20px">
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("lo_id") %>'></asp:Label></td>
                            <td colspan="4" style="height: 20px">
                                <asp:CheckBox ID="CheckBox1" runat="server" Text='<%# Eval("l_desc") %>' /></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="DarkSeaGreen" ForeColor="White" HorizontalAlign="Center" />
        <EmptyDataTemplate>
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Height="19px" Style="font-size: small;
                left: 5px; color: white; font-style: italic; font-family: Calibri; position: static;
                top: 56px" Text="No course selected. Please choose a course." Width="243px"></asp:Label>
        </EmptyDataTemplate>
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="SeaGreen" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="Snow" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource10" runat="server" ConnectionString="<%$ ConnectionStrings:CIT examsConnectionString39 %>"
        SelectCommand="SELECT lo_id, l_code, course, l_desc, week FROM learnObjectives WHERE (course = @course) ORDER BY week">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList1" Name="course" PropertyName="SelectedValue"
                Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
                                &nbsp;
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:CIT examsConnectionString16 %>"
        SelectCommand="SELECT DISTINCT course_id FROM course WHERE (sec_handler = @sec_handler)">
        <SelectParameters>
            <asp:SessionParameter Name="sec_handler" SessionField="user" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>

