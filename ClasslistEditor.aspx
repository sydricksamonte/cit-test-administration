<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClasslistEditor.aspx.cs" Inherits="CreateExam" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Malayan Colleges Laguna | Classlist Editor </title>
</head>
<body bgcolor="#ffffff">
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1"
            Height="1px" Style="font-size: small; font-family: 'Arial Unicode MS'; left: 51px; position: absolute; top: 351px;" Width="755px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" ShowFooter="True" OnLoad="GridView1_Load" EnableModelValidation="True" OnRowDeleted="GridView1_RowDeleted" OnRowUpdated="GridView1_RowUpdated" OnRowEditing="GridView1_RowEditing" OnRowCreated="GridView1_RowCreated" DataKeyNames="stud_course_id" CellPadding="4" ForeColor="#333333" GridLines="None" ShowHeader="False" Visible="False">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:TemplateField HeaderText="stud_id" SortExpression="stud_id">
                    <EditItemTemplate>
                        <table style="left: 118px; width: 650px; top: 201px">
                            <tr>
                                <td style="width: 117px; height: 22px">
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("stud_course_id") %>' />
                                </td>
                                <td style="width: 137px; height: 22px">
                                    &nbsp;<asp:Label ID="Label5" runat="server" Font-Names="Arial Narrow" Font-Size="Small"
                                        Style="font-weight: bold; font-size: 10pt; left: 46px; font-family: 'Arial Narrow';
                                        position: static; top: 210px" Text="Stud No." Width="57px"></asp:Label>
                                    <asp:TextBox ID="studNo" runat="server" Text='<%# Bind("stud_id") %>' Width="126px" OnTextChanged="studNo_TextChanged1"></asp:TextBox></td>
                                <td style="width: 391px; height: 22px">
                                    <asp:Label ID="Label1" runat="server" Font-Names="Arial Narrow" Font-Size="Small"
                                        Style="font-weight: bold; font-size: 10pt; left: 46px; font-family: 'Arial Narrow';
                                        position: static; top: 210px" Text="Student Name:" Width="107px"></asp:Label>&nbsp;
                                    <asp:TextBox ID="studNa" runat="server" Text='<%# Bind("stud_name") %>' Width="366px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <table style="left: 118px; width: 787px; top: 201px">
                            <tr>
                                <td style="width: 117px; height: 22px">
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                </td>
                                <td style="width: 137px; height: 22px">
                                    &nbsp;<asp:Label ID="Label5" runat="server" Font-Names="Arial Narrow" Font-Size="Small"
                                        Style="font-weight: bold; font-size: 10pt; left: 46px; font-family: 'Arial Narrow';
                                        position: static; top: 210px" Text="Stud No." Width="57px" Visible="False"></asp:Label>
                                    <asp:TextBox ID="studNo" runat="server" Width="126px" AutoPostBack="True" OnTextChanged="studNo_TextChanged" Visible="False"></asp:TextBox></td>
                                <td style="width: 508px; height: 22px">
                                    <asp:Label ID="Label1" runat="server" Font-Names="Arial Narrow" Font-Size="Small"
                                        Style="font-weight: bold; font-size: 10pt; left: 46px; font-family: 'Arial Narrow';
                                        position: static; top: 210px" Text="Student Name:" Width="107px" Visible="False"></asp:Label>
                                    <asp:TextBox ID="studNa" runat="server" Width="513px" Visible="False"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="width: 117px; height: 19px">
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                </td>
                                <td style="width: 137px; height: 19px">
                                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click2" Text="Add student" Font-Names="Calibri" Visible="False" /></td>
                                <td style="width: 508px; height: 19px">
                                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; 
                                    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Style="z-index: 100;
                                        left: 274px; position: absolute; top: 108px" Text="Add" Visible="False" Width="73px" />
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="left: 118px; width: 788px; top: 201px; border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none;">
                            <tr>
                                <td style="width: 48px; height: 22px">
                                    &nbsp;</td>
                                <td style="width: 150px; height: 22px">
                                    <asp:Label ID="lblCourse" runat="server" Style="font-weight: normal; font-size: 12pt;
                                        left: 46px; font-family: 'Arial Rounded MT Bold'; position: static; top: 210px"
                                        Text='<%# Eval("stud_id") %>' Width="67px" Font-Names="Segoe UI" Font-Size="Small"></asp:Label></td>
                                <td style="width: 400px; height: 22px">
                                    <asp:Label ID="lblTitle" runat="server" Style="font-weight: normal; font-size: 12pt;
                                        left: 46px; font-family: 'Arial Rounded MT Bold'; position: static; top: 210px"
                                        Text='<%# Eval("stud_name") %>' Width="432px" Font-Names="Segoe UI"></asp:Label></td>
                            </tr>
                        </table>
                                    <asp:HiddenField ID="HiddenField2" runat="server" Value='<%# Eval("stud_course_id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="stud_course_id" ReadOnly="True" SortExpression="stud_course_id"
                    Visible="False" />
            </Columns>
            <EmptyDataRowStyle BorderColor="Gray" ForeColor="Cyan" />
            <EmptyDataTemplate>
                &nbsp;&nbsp;
                <asp:Label ID="lblTitle" runat="server" ForeColor="RoyalBlue" Style="font-weight: normal;
                    font-size: 12pt; left: 46px; font-family: 'Arial Rounded MT Bold'; position: static;
                    top: 210px" Text="Type in Student Number and Student name of each student" Width="508px"></asp:Label>
                <table style="left: 118px; width: 650px; top: 201px">
                    <tr>
                        <td style="width: 117px; height: 22px">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        </td>
                        <td style="width: 137px; height: 22px">
                            &nbsp;<asp:Label ID="Label5" runat="server" Font-Names="Arial Narrow" Font-Size="Small"
                                ForeColor="Black" Style="font-weight: bold; font-size: 10pt; left: 46px; font-family: 'Arial Narrow';
                                position: static; top: 210px" Text="Stud No." Width="57px"></asp:Label>
                            <asp:TextBox ID="studNo" runat="server" Width="126px"></asp:TextBox></td>
                        <td style="width: 391px; height: 22px">
                            <asp:Label ID="Label1" runat="server" Font-Names="Arial Narrow" Font-Size="Small"
                                ForeColor="Black" Style="font-weight: bold; font-size: 10pt; left: 46px; font-family: 'Arial Narrow';
                                position: static; top: 210px" Text="Student Name:" Width="107px"></asp:Label>
                            <asp:TextBox ID="studNa" runat="server" Width="366px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 117px; height: 19px">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                        </td>
                        <td style="width: 137px; height: 19px">
                            <asp:Button ID="Button1" runat="server" OnClick="AddtoEmpty" Text="Add student" />
                            <asp:Label ID="Label2" runat="server" ForeColor="White" Style="font-size: small;
                                left: 321px; color: white; font-family: 'Lucida Sans'; position: absolute; top: 402px"
                                Text="Upload"></asp:Label>
                            &nbsp; &nbsp;&nbsp;
                        </td>
                        <td style="width: 391px; height: 19px">
                            &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        </td>
                    </tr>
                </table>
                <span style="color: black">No data</span>
            </EmptyDataTemplate>
            <RowStyle BackColor="#EFF3FB" Font-Names="Segoe UI" Font-Size="Medium" />
            <FooterStyle BackColor="White" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="ActiveCaption" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RACHELCONN %>"
            SelectCommand="SELECT [stud_course_id], [stud_id], [stud_name] FROM [classlist] WHERE (([prof_id] = @prof_id) AND ([sec] = @sec) AND ([course_code] = @course_code) AND ([stud_course_id] LIKE '%' + @stud_course_id + '%')) ORDER BY [stud_name]" DeleteCommand="DELETE FROM [classlist] WHERE [stud_course_id] = @original_stud_course_id" InsertCommand="INSERT INTO [classlist] ([stud_course_id], [stud_id], [stud_name]) VALUES (@stud_course_id, @stud_id, @stud_name)" UpdateCommand="UPDATE [classlist] SET [stud_id] = @stud_id, [stud_name] = @stud_name WHERE [stud_course_id] = @original_stud_course_id" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:SessionParameter Name="prof_id" SessionField="user" Type="String" />
                <asp:SessionParameter Name="sec" SessionField="section" Type="String" />
                <asp:SessionParameter Name="course_code" SessionField="course" Type="String" />
                <asp:ControlParameter ControlID="lblTerm" Name="stud_course_id" PropertyName="Text"
                    Type="String" />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="original_stud_course_id" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="stud_id" Type="String" />
                <asp:ControlParameter ControlID="GridView1" Name="stud_name" PropertyName="SelectedValue"
                    Type="String" />
                <asp:Parameter Name="original_stud_course_id" Type="String" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="stud_course_id" Type="String" />
                <asp:Parameter Name="stud_id" Type="String" />
                <asp:Parameter Name="stud_name" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;<br />
        <asp:Label ID="Label12" runat="server" Style="left: 557px; position: absolute; top: 106px"
            Text="Label" Width="108px" Visible="False"></asp:Label>
        <br />
        <br />
        &nbsp;
        <asp:Panel ID="Panel1" runat="server" Height="80px" Style="left: 98px; position: absolute;
            top: 28px; font-size: small; color: white; font-family: 'Lucida Sans';" Width="511px">
            <asp:ImageButton ID="ImageButton2" runat="server" Height="54px" ImageUrl="~/Images/toolbar.png"
                Style="left: 9px; position: absolute; top: 16px" Width="624px" Enabled="False" />
            <asp:Button ID="Button3" runat="server" Style="font-size: small; left: 31px; font-family: 'Lucida Sans';
                position: absolute; top: 27px" Text="Back to home" Height="22px" OnClick="Button2_Click1" Width="117px" />
            &nbsp; &nbsp;
            &nbsp;
            <asp:Label ID="Label23" runat="server" Style="left: 100px; position: absolute; top: -17px" Font-Bold="True" Font-Italic="False" ForeColor="#404040" Visible="False"></asp:Label>
            <asp:Label ID="Label4" runat="server" ForeColor="#404040" Style="left: 20px; position: absolute;
                top: -17px" Text="Exam Name:" Visible="False"></asp:Label>
            <asp:Label ID="Label6" runat="server" ForeColor="#404040" Style="left: 285px; position: absolute;
                top: -17px" Text="All Rights Reserved. © 2011 Malayan Colleges Laguna" Width="356px"></asp:Label>
            <asp:Label ID="Label3" runat="server" ForeColor="Red" Style="left: -20px; position: absolute;
                top: 306px" Visible="False" Width="867px"></asp:Label>
            &nbsp; &nbsp; &nbsp;
            &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;
            &nbsp; &nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click2" Style="font-size: medium;
                left: 29px; font-family: Calibri; position: absolute; top: 24px" Text="Save & Close"
                Visible="False" Width="121px" />
        </asp:Panel>
        &nbsp;&nbsp;
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/mcl.png" Style="left: 98px;
            position: absolute; top: 111px" />
        <asp:Label ID="Label2" runat="server" Font-Names="Berlin Sans FB Demi" Font-Size="X-Large"
            Style="left: 363px; position: absolute; top: 205px" Text="CLASSLIST"></asp:Label>
        <table style="left: 101px; width: 728px; position: absolute; top: 246px; height: 64px;">
            <tr>
                <td style="width: 201px; height: 21px">
                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
                    <asp:Label ID="lblTerm" runat="server" Style="font-weight: normal; font-size: 12pt;
                        left: 46px; font-family: 'Arial Rounded MT Bold'; position: static; top: 210px"
                        Text="2011-2012 / 1T" Width="132px"></asp:Label></td>
                <td style="width: 150px; height: 21px">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    <asp:Label ID="lblCourse" runat="server" Style="font-weight: normal; font-size: 12pt;
                        left: 46px; font-family: 'Arial Rounded MT Bold'; position: static; top: 210px"
                        Text="CS199L" Width="67px"></asp:Label></td>
                <td style="height: 21px; width: 295px;">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblTitle" runat="server" Style="font-weight: normal; font-size: 12pt;
                        left: 46px; font-family: 'Arial Rounded MT Bold'; position: static; top: 210px"
                        Text="CAPSTONE PROJECT" Width="239px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 201px; height: 18px">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    <asp:Label ID="Label8" runat="server" Font-Names="Arial Narrow" Font-Size="Small"
                        Style="font-weight: bold; font-size: 10pt; left: 46px; font-family: 'Arial Narrow';
                        position: static; top: 210px" Text="SCHOOL YEAR/TERM" Width="140px"></asp:Label>
                    &nbsp; &nbsp;
                </td>
                <td style="width: 150px; height: 18px">
                    &nbsp; &nbsp; &nbsp; &nbsp;
                    <asp:Label ID="Label5" runat="server" Font-Names="Arial Narrow" Font-Size="Small"
                        Style="font-weight: bold; font-size: 10pt; left: 46px; font-family: 'Arial Narrow';
                        position: static; top: 210px" Text="COURSE CODE" Width="106px"></asp:Label></td>
                <td style="height: 18px; width: 295px;">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
                    &nbsp;
                    <asp:Label ID="Label7" runat="server" Font-Names="Arial Narrow" Font-Overline="False"
                        Font-Size="Small" Style="font-weight: bold; font-size: 10pt; left: 46px; font-family: 'Arial Narrow';
                        position: static; top: 210px" Text="COURSE TITLE" Width="101px"></asp:Label></td>
            </tr>
        </table>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4"
            DataKeyNames="stud_course_id" DataSourceID="SqlDataSource1" ForeColor="#333333"
            GridLines="None" Style="font-size: medium; left: 51px; font-family: 'Segoe UI';
            position: absolute; top: 348px" Width="883px">
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="stud_course_id" HeaderText="stud_course_id" ReadOnly="True"
                    SortExpression="stud_course_id" Visible="False" />
                <asp:BoundField DataField="stud_id" HeaderText="Student Number" SortExpression="stud_id" />
                <asp:BoundField DataField="stud_name" HeaderText="Name" SortExpression="stud_name">
                    <ItemStyle Width="400px" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
