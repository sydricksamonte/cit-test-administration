<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudSummary.aspx.cs" Inherits="Exams" Title="Summary" MasterPageFile="~/blank.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" Height="445px" Style="font-size: small; left: 247px;
        background-image: url(Images/tabla7.png); color: white; font-family: 'Lucida Sans';
        position: absolute; top: 17px; background-color: transparent; z-index: 100;" Width="560px">
        <asp:Label ID="Label1" runat="server" Style="left: 65px; color: limegreen; position: absolute;
            top: 26px" Text="Lastname, Firstname (Middle name),"></asp:Label>
        &nbsp;
        <asp:Label ID="Hello" runat="server" Style="left: 25px; position: absolute; top: 26px"
            Text="Name:"></asp:Label>
        &nbsp; &nbsp;
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CIT examsConnectionString6 %>"
            SelectCommand="SELECT * FROM [answers] WHERE (([exam_code] = @exam_code2) AND ([user_id] = @user_id)) ORDER BY [ques_id]">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="exam_code2" PropertyName="SelectedValue"
                    Type="String" />
                <asp:SessionParameter Name="user_id" SessionField="user" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpExams_SelectedIndexChanged"
            Style="font-size: small; left: 320px; font-family: 'Lucida Sans'; position: absolute;
            top: 54px" Width="1px" DataSourceID="SqlDataSource4" DataTextField="exam_code" DataValueField="exam_code" Enabled="False" OnDataBound="drpExams_DataBound">
        </asp:DropDownList>
        &nbsp;
        <asp:DropDownList ID="drpExams" runat="server" AutoPostBack="True"
            OnSelectedIndexChanged="drpExams_SelectedIndexChanged" Style="font-size: small;
            left: 126px; font-family: 'Lucida Sans'; position: absolute; top: 54px" Width="253px" DataSourceID="SqlDataSource3" DataTextField="pname" DataValueField="pname" OnDataBound="drpExams_DataBound1" Enabled="False">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:CIT examsConnectionString7 %>"
            SelectCommand="SELECT [pname] FROM [exam_results] WHERE (([user_id] = @user_id) AND ([d_taken] <> @d_taken)) ORDER BY [d_taken] DESC&#13;&#10;">
            <SelectParameters>
                <asp:SessionParameter Name="user_id" SessionField="user" Type="String" />
                <asp:Parameter DefaultValue="NOT TAKEN" Name="d_taken" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        &nbsp; &nbsp;
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:CIT examsConnectionString8 %>"
            SelectCommand="SELECT [exam_code] FROM [exam_results] WHERE (([user_id] = @user_id) AND ([d_taken] <> @d_taken)) ORDER BY [d_taken] DESC">
            <SelectParameters>
                <asp:SessionParameter Name="user_id" SessionField="user" Type="String" />
                <asp:Parameter DefaultValue="NOT TAKEN" Name="d_taken" />
            </SelectParameters>
        </asp:SqlDataSource>
        &nbsp; &nbsp;
        <asp:ListBox ID="listStud" runat="server" Height="17px" Style="left: -306px; position: absolute;
            top: 279px" Width="83px" OnLoad="listStud_SelectedIndexChanged" Visible="False"></asp:ListBox>
        <asp:ListBox ID="listCor" runat="server" Height="18px" Style="left: -284px; position: absolute;
            top: 222px" Width="73px" OnLoad="listCor_Load" Visible="False"></asp:ListBox>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server"></asp:SqlDataSource>
        &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Panel ID="Panel3" runat="server" Style="left: -15px; position: absolute; top: -4px">
        <asp:ListBox ID="ListBox1" runat="server" Height="327px" Style="left: 129px; position: absolute;
            top: 95px; text-align: left; font-size: medium; font-family: Calibri;" Width="271px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged"></asp:ListBox>
        <asp:Label ID="lblAll" runat="server" Font-Bold="True" Font-Size="X-Large" Style="left: 455px;
            color: limegreen; position: absolute; top: 205px" Text="00"></asp:Label>
        <asp:Label ID="Label5" runat="server" Font-Size="Medium" Style="left: 419px; color: limegreen;
            position: absolute; top: 142px" Text="Total Score:" Width="106px"></asp:Label>
        <asp:Label ID="Label6" runat="server" Font-Size="Medium" Style="left: 411px; color: limegreen;
            position: absolute; top: 240px" Text="Status:"></asp:Label>
        <asp:Label ID="lblStat" runat="server" Font-Size="Medium" Style="left: 470px; color: limegreen;
            position: absolute; top: 239px" Text="Passed"></asp:Label>
        <asp:Label ID="lblCorAns" runat="server" Font-Bold="True" Font-Overline="False" Font-Size="X-Large"
            Font-Underline="True" Style="left: 455px; color: limegreen; position: absolute;
            top: 174px" Text="00"></asp:Label>
        <asp:Label ID="lblPerc" runat="server" Font-Bold="True" Font-Size="XX-Large" Style="font-size: 50px;
            left: 426px; position: absolute; top: 271px" Text="00"></asp:Label>
        </asp:Panel><asp:ImageButton ID="ImageButton2s" runat="server" BackColor="Transparent" Enabled="False"
        Height="279px" ImageAlign="Left" ImageUrl="~/Images/logo_new.png"
        PostBackUrl="~/InsHome.aspx" Style="left: -213px; position: absolute; top: -52px"
        Width="200px" />
        <asp:Label ID="Label3" runat="server" Font-Size="Medium" Style="left: 21px; color: limegreen;
            position: absolute; top: 3px" Text="Score summary"></asp:Label>
    </asp:Panel>
   
</asp:Content>


