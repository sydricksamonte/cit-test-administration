<%@ Page Language="C#"  AutoEventWireup="true" CodeFile="CreateExam.aspx.cs" Inherits="CreateExam" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link rel = "stylesheet" href = "Images/Maintestyle.css" type = "text/css" media = "screen" />

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Malayan Colleges Laguna | Exam Creator </title>
</head>
<body bgcolor="white">
    <form id="form1" runat="server">
    <div>
        &nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;
        <asp:Panel ID="Panel3" runat="server" Style="z-index: 120; left: 726px; position: absolute;
            top: 54px" BackColor="LightGray" Height="48px" Width="238px">
            <asp:DropDownList ID="DropDownList2" runat="server" Style="z-index: 100; left: 7px;
                position: absolute; top: 22px" Width="124px">
                <asp:ListItem Value="Easy">Easy</asp:ListItem>
                <asp:ListItem Value="Average">Average</asp:ListItem>
                <asp:ListItem Value="Hard">Difficult</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="Button6" runat="server" OnClick="Button6_Click2" Style="z-index: 101;
                left: 166px; position: absolute; top: 20px" Text="Change" />
            <asp:Label ID="Label17" runat="server" Font-Names="Segoe UI" Font-Size="Medium" Style="z-index: 102;
                left: 7px; position: absolute; top: 2px" Text="Points "></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" MaxLength="2" Style="z-index: 104; left: 136px;
                position: absolute; top: 21px" Width="18px">1</asp:TextBox>
        </asp:Panel>
        &nbsp;&nbsp;
        <asp:LinkButton ID="LinkButton1" runat="server" Font-Names="Segoe UI" Font-Size="Small"
            ForeColor="Red" Height="10px" OnClick="LinkButton1_Click1" Style="left: 728px;
            position: absolute; top: 7px" Width="55px"></asp:LinkButton>
        &nbsp;
        <asp:LinkButton ID="LinkButton2" runat="server" Font-Names="Segoe UI" Font-Size="Small"
            ForeColor="Red" Height="25px" OnClick="LinkButton2_Click1"
            Style="left: 306px; position: absolute; top: 111px" Visible="False" Width="452px"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton3" runat="server" Font-Names="Segoe UI" Font-Size="Small"
            ForeColor="Red" Height="16px" OnClick="LinkButton3_Click" Style="left: 306px;
            position: absolute; top: 111px" Visible="False" Width="451px"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton4" runat="server" Font-Names="Segoe UI" Font-Size="Small"
            ForeColor="Red" Height="18px" OnClick="LinkButton4_Click" Style="left: 306px;
            position: absolute; top: 111px" Visible="False" Width="452px"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton5" runat="server" Font-Names="Segoe UI" Font-Size="X-Small"
            ForeColor="Red" Height="32px" OnClick="LinkButton5_Click" Style="left: 512px;
            position: absolute; top: 28px" Visible="False" Width="196px"></asp:LinkButton>
        <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:SYARACONN %>"
            SelectCommand="SELECT question_table.*, answers.ans, question_table.exam_code AS Expr1, answers.user_id FROM answers INNER JOIN question_table ON answers.ques_id = question_table.ques_id AND answers.exam_code = question_table.exam_code WHERE (answers.ans = N'noanswerxxx') AND (answers.user_id = N'2009102144') AND (question_table.exam_code = N'a')">
        </asp:SqlDataSource>
        <asp:Label ID="Label26" runat="server" Font-Names="Calibri" Font-Size="Small" ForeColor="#404040"
            Style="z-index: 107; left: 290px; position: absolute; top: 33px" Text="Easy questions:"></asp:Label>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:RACHELCONN %>"
                SelectCommand="SELECT * FROM [question_table] WHERE (([typeEx] = @typeEx) AND ([exam_code] = @exam_code)) ORDER BY [ques_desc]" DeleteCommand="DELETE FROM [question_table] WHERE [ques_id] = @ques_id" InsertCommand="INSERT INTO [question_table] ([ins_id], [ques_id], [exam_code], [typeEx], [ques_desc], [ans_a], [ans_b], [ans_c], [ans_d], [ans_e], [ans_f], [ans_g], [ans_h], [ans_i], [ans_j], [l_outcomes], [p_date], [imgLoc], [l_o], [c_o], [copy_type], [pt], [dif]) VALUES (@ins_id, @ques_id, @exam_code, @typeEx, @ques_desc, @ans_a, @ans_b, @ans_c, @ans_d, @ans_e, @ans_f, @ans_g, @ans_h, @ans_i, @ans_j, @l_outcomes, @p_date, @imgLoc, @l_o, @c_o, @copy_type, @pt, @dif)" UpdateCommand="UPDATE [question_table] SET [ques_desc] = @ques_desc, [ans_a] = @ans_a, [ans_b] = @ans_b,  [l_o] = @l_o, [c_o] = @c_o, [pt] = @pt, [dif] = @dif WHERE [ques_id] = @ques_id">
                <SelectParameters>
                    <asp:Parameter DefaultValue="ToF" Name="typeEx" Type="String" />
                    <asp:SessionParameter Name="exam_code" SessionField="exname" Type="String" />
                </SelectParameters>
                <DeleteParameters>
                    <asp:Parameter Name="ques_id" Type="String" />
                </DeleteParameters>
                <UpdateParameters>
                    <asp:Parameter Name="ins_id" Type="String" />
                    <asp:Parameter Name="exam_code" Type="String" />
                    <asp:Parameter Name="typeEx" Type="String" />
                    <asp:Parameter Name="ques_desc" Type="String" />
                    <asp:Parameter Name="ans_a" Type="String" />
                    <asp:Parameter Name="ans_b" Type="String" />
                    <asp:Parameter Name="ans_c" Type="String" />
                    <asp:Parameter Name="ans_d" Type="String" />
                    <asp:Parameter Name="ans_e" Type="String" />
                    <asp:Parameter Name="ans_f" Type="String" />
                    <asp:Parameter Name="ans_g" Type="String" />
                    <asp:Parameter Name="ans_h" Type="String" />
                    <asp:Parameter Name="ans_i" Type="String" />
                    <asp:Parameter Name="ans_j" Type="String" />
                    <asp:Parameter Name="l_outcomes" Type="String" />
                    <asp:Parameter Name="p_date" Type="String" />
                    <asp:Parameter Name="imgLoc" Type="String" />
                    <asp:Parameter Name="l_o" Type="String" />
                    <asp:Parameter Name="c_o" Type="String" />
                    <asp:Parameter Name="copy_type" Type="String" />
                    <asp:Parameter Name="pt" Type="Int32" />
                    <asp:Parameter Name="dif" Type="String" />
                    <asp:Parameter Name="ques_id" Type="String" />
                </UpdateParameters>
                <InsertParameters>
                    <asp:Parameter Name="ins_id" Type="String" />
                    <asp:Parameter Name="ques_id" Type="String" />
                    <asp:Parameter Name="exam_code" Type="String" />
                    <asp:Parameter Name="typeEx" Type="String" />
                    <asp:Parameter Name="ques_desc" Type="String" />
                    <asp:Parameter Name="ans_a" Type="String" />
                    <asp:Parameter Name="ans_b" Type="String" />
                    <asp:Parameter Name="ans_c" Type="String" />
                    <asp:Parameter Name="ans_d" Type="String" />
                    <asp:Parameter Name="ans_e" Type="String" />
                    <asp:Parameter Name="ans_f" Type="String" />
                    <asp:Parameter Name="ans_g" Type="String" />
                    <asp:Parameter Name="ans_h" Type="String" />
                    <asp:Parameter Name="ans_i" Type="String" />
                    <asp:Parameter Name="ans_j" Type="String" />
                    <asp:Parameter Name="l_outcomes" Type="String" />
                    <asp:Parameter Name="p_date" Type="String" />
                    <asp:Parameter Name="imgLoc" Type="String" />
                    <asp:Parameter Name="l_o" Type="String" />
                    <asp:Parameter Name="c_o" Type="String" />
                    <asp:Parameter Name="copy_type" Type="String" />
                    <asp:Parameter Name="pt" Type="Int32" />
                    <asp:Parameter Name="dif" Type="String" />
                </InsertParameters>
            </asp:SqlDataSource><asp:Button ID="Button10" runat="server" Style="left: 641px; position: absolute; top: 60px; z-index: 112;"
                Text="Clear All" Width="68px" OnClick="Button10_Click" UseSubmitBehavior="False" ValidationGroup="B" BackColor="IndianRed" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" Font-Names="Segoe UI" />
        <asp:Button ID="Button11" runat="server" Style="left: 524px; position: absolute; top: 60px; z-index: 112;"
                Text="Add More Items.." Width="112px" OnClick="Button11_Click" UseSubmitBehavior="False" ValidationGroup="B" BackColor="SeaGreen" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" Font-Names="Segoe UI" />
        <asp:Label ID="Label25" runat="server" Font-Names="Calibri" Font-Size="Small" ForeColor="#404040"
            Style="z-index: 107; left: 290px; position: absolute; top: 65px" Text="Difficult questions:"></asp:Label>
        <asp:Label ID="Labelde" runat="server" Font-Names="Calibri" Font-Size="Small" ForeColor="#404040"
            Style="z-index: 107; left: 448px; position: absolute; top: 34px" Text="1"></asp:Label>
        <asp:Label ID="Labelda" runat="server" Font-Names="Calibri" Font-Size="Small" ForeColor="#404040"
            Style="z-index: 107; left: 448px; position: absolute; top: 49px" Text="1"></asp:Label>
        <asp:Label ID="Labeldd" runat="server" Font-Names="Calibri" Font-Size="Small" ForeColor="#404040"
            Style="z-index: 107; left: 448px; position: absolute; top: 64px" Text="1"></asp:Label>
        <asp:Label ID="Label29" runat="server" Font-Names="Calibri" Font-Size="Small" ForeColor="#404040"
            Style="z-index: 107; left: 465px; position: absolute; top: 34px" Text="Point(s)"></asp:Label>
        <asp:Label ID="Label30" runat="server" Font-Names="Calibri" Font-Size="Small" ForeColor="#404040"
            Style="z-index: 107; left: 465px; position: absolute; top: 49px" Text="Point(s)"></asp:Label>
        <asp:Label ID="Label31" runat="server" Font-Names="Calibri" Font-Size="Small" ForeColor="#404040"
            Style="z-index: 107; left: 465px; position: absolute; top: 64px" Text="Point(s)"></asp:Label>
        <asp:Label ID="Label22" runat="server" Font-Names="Calibri" Font-Size="Small" ForeColor="#404040"
            Style="z-index: 107; left: 290px; position: absolute; top: 49px" Text="Average questions:"></asp:Label>
            <asp:Button ID="Button2" runat="server" Style="font-size: small; left: 723px; font-family: 'Lucida Sans';
                position: absolute; top: 6px; z-index: 101;" Text="Publish now.." Height="22px" OnClick="Button2_Click1" Width="117px" UseSubmitBehavior="False" ValidationGroup="B" />
            <asp:Button ID="Button8" runat="server" OnClick="Button8_Click" Style="left: 843px;
                position: absolute; top: 6px; z-index: 102;" Text="Go Back" Width="101px" />
            <asp:Label ID="Label3" runat="server" Height="5px" Style="left: -8px; position: absolute;
                top: 30px; text-align: left; z-index: 103;" Text="Open other test files:" Width="185px" Font-Names="Calibri" Font-Size="Medium" ForeColor="#404040" Visible="False"></asp:Label>
            <asp:Button ID="Button9" runat="server" Style="font-size: small; left: 723px; font-family: 'Lucida Sans';
                position: absolute; top: 6px; z-index: 104;" Text="Save & Close" Height="22px" OnClick="Button9_Click" Width="117px" UseSubmitBehavior="False" ValidationGroup="B" />
            <asp:DropDownList ID="drpExams" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpExams_SelectedIndexChanged"
                Style="left: -54px; font-family: 'Lucida Sans'; position: absolute; top: 46px; z-index: 105;"
                Width="293px" DataSourceID="SqlDataSource2" DataTextField="exam_code" Visible="False">
            </asp:DropDownList>
            <asp:Label ID="Label23" runat="server" Style="left: 260px; position: absolute; top: 12px; z-index: 106;" Font-Bold="True" Font-Italic="False" ForeColor="#404040" Font-Names="Calibri" Font-Size="Small"></asp:Label>
            <asp:Label ID="Label4" runat="server" ForeColor="#404040" Style="left: 177px; position: absolute;
                top: 10px; z-index: 107;" Text="Draft Name:" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:RACHELCONN %>"
                SelectCommand="SELECT * FROM [question_table] WHERE (([typeEx] = @typeEx) AND ([exam_code] = @exam_code)) ORDER BY [ques_desc]" ProviderName="<%$ ConnectionStrings:CIT examsConnectionString40.ProviderName %>" DeleteCommand="DELETE FROM [question_table] WHERE [ques_id] = @ques_id" InsertCommand="INSERT INTO [question_table] ([ins_id], [ques_id], [exam_code], [typeEx], [ques_desc], [ans_a], [ans_b], [ans_c], [ans_d], [ans_e], [ans_f], [ans_g], [ans_h], [ans_i], [ans_j], [l_outcomes], [p_date], [imgLoc], [l_o], [c_o], [copy_type], [pt], [dif]) VALUES (@ins_id, @ques_id, @exam_code, @typeEx, @ques_desc, @ans_a, @ans_b, @ans_c, @ans_d, @ans_e, @ans_f, @ans_g, @ans_h, @ans_i, @ans_j, @l_outcomes, @p_date, @imgLoc, @l_o, @c_o, @copy_type, @pt, @dif)" UpdateCommand="UPDATE [question_table] SET  [ques_desc] = @ques_desc, [ans_a] = @ans_a, [l_o] = @l_o, [c_o] = @c_o, [pt] = @pt, [dif] = @dif WHERE [ques_id] = @ques_id">
                <SelectParameters>
                    <asp:Parameter DefaultValue="Iden" Name="typeEx" Type="String" />
                    <asp:SessionParameter Name="exam_code" SessionField="exname" Type="String" />
                </SelectParameters>
                <DeleteParameters>
                    <asp:Parameter Name="ques_id" Type="String" />
                </DeleteParameters>
                <UpdateParameters>
                    <asp:Parameter Name="ins_id" Type="String" />
                    <asp:Parameter Name="exam_code" Type="String" />
                    <asp:Parameter Name="typeEx" Type="String" />
                    <asp:Parameter Name="ques_desc" Type="String" />
                    <asp:Parameter Name="ans_a" Type="String" />
                    <asp:Parameter Name="ans_b" Type="String" />
                    <asp:Parameter Name="ans_c" Type="String" />
                    <asp:Parameter Name="ans_d" Type="String" />
                    <asp:Parameter Name="ans_e" Type="String" />
                    <asp:Parameter Name="ans_f" Type="String" />
                    <asp:Parameter Name="ans_g" Type="String" />
                    <asp:Parameter Name="ans_h" Type="String" />
                    <asp:Parameter Name="ans_i" Type="String" />
                    <asp:Parameter Name="ans_j" Type="String" />
                    <asp:Parameter Name="l_outcomes" Type="String" />
                    <asp:Parameter Name="p_date" Type="String" />
                    <asp:Parameter Name="imgLoc" Type="String" />
                    <asp:Parameter Name="l_o" Type="String" />
                    <asp:Parameter Name="c_o" Type="String" />
                    <asp:Parameter Name="copy_type" Type="String" />
                    <asp:Parameter Name="pt" Type="Int32" />
                    <asp:Parameter Name="dif" Type="String" />
                    <asp:Parameter Name="ques_id" Type="String" />
                </UpdateParameters>
                <InsertParameters>
                    <asp:Parameter Name="ins_id" Type="String" />
                    <asp:Parameter Name="ques_id" Type="String" />
                    <asp:Parameter Name="exam_code" Type="String" />
                    <asp:Parameter Name="typeEx" Type="String" />
                    <asp:Parameter Name="ques_desc" Type="String" />
                    <asp:Parameter Name="ans_a" Type="String" />
                    <asp:Parameter Name="ans_b" Type="String" />
                    <asp:Parameter Name="ans_c" Type="String" />
                    <asp:Parameter Name="ans_d" Type="String" />
                    <asp:Parameter Name="ans_e" Type="String" />
                    <asp:Parameter Name="ans_f" Type="String" />
                    <asp:Parameter Name="ans_g" Type="String" />
                    <asp:Parameter Name="ans_h" Type="String" />
                    <asp:Parameter Name="ans_i" Type="String" />
                    <asp:Parameter Name="ans_j" Type="String" />
                    <asp:Parameter Name="l_outcomes" Type="String" />
                    <asp:Parameter Name="p_date" Type="String" />
                    <asp:Parameter Name="imgLoc" Type="String" />
                    <asp:Parameter Name="l_o" Type="String" />
                    <asp:Parameter Name="c_o" Type="String" />
                    <asp:Parameter Name="copy_type" Type="String" />
                    <asp:Parameter Name="pt" Type="Int32" />
                    <asp:Parameter Name="dif" Type="String" />
                </InsertParameters>
            </asp:SqlDataSource>
        &nbsp;
        <asp:Panel ID="Panel1" runat="server" Height="414px" Style="z-index: 109; left: 5px;
            position: absolute; top: 91px" Width="288px" Font-Names="Calibri" Font-Size="Medium" ForeColor="White" BackColor="Transparent">
        <asp:ImageButton ID="ImageButton3" runat="server" Enabled="False" Height="476px"
            ImageUrl="~/Images/tabla890.png" Style="z-index: 100; left: 0px; position: absolute;
            top: 0px; background-color: transparent" Width="290px" OnClick="ImageButton3_Click" />
            <asp:DropDownList ID="DropDownList3" runat="server" SelectedValue='<%# Bind("dif") %>'
                Style="z-index: 127; left: 105px; position: absolute; top: 386px" Width="91px">
                <asp:ListItem Selected="True">Easy</asp:ListItem>
                <asp:ListItem>Average</asp:ListItem>
                <asp:ListItem>Hard</asp:ListItem>
            </asp:DropDownList>
            &nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCO"
                ErrorMessage="*" SetFocusOnError="True" Style="z-index: 103; left: 224px; position: absolute;
                top: 60px" ValidationGroup="aaaa" Width="13px"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtLO"
                ErrorMessage="*" SetFocusOnError="True" Style="z-index: 104; left: 127px; position: absolute;
                top: 62px" ValidationGroup="aaaa" Width="13px"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtLO"
                ErrorMessage="*" SetFocusOnError="True" Style="z-index: 105; left: -65px; position: absolute;
                top: 663px" ValidationGroup="aaaa" Width="13px"></asp:RequiredFieldValidator>
            <asp:Label ID="Label12" runat="server" Style="z-index: 106; left: 36px; position: absolute;
                top: -87px"></asp:Label>
            <asp:TextBox ID="txtQ" runat="server" Style="z-index: 107; left: 20px; position: absolute;
                top: 113px" Height="32px" TextMode="MultiLine" Width="237px"></asp:TextBox>
        <asp:Label ID="Label1" runat="server" Style="z-index: 108; left: 12px; position: absolute;
            top: 89px" Text="Question*"></asp:Label>
            <asp:Label ID="Label28" runat="server" Font-Size="Small" Style="z-index: 108; left: 17px;
                position: absolute; top: 444px" Text="* Required Fields"></asp:Label>
            <asp:Label ID="Label9" runat="server" Font-Size="Small" Style="z-index: 109; left: 127px;
                position: absolute; top: 160px" Text="Add Image"></asp:Label>
            <asp:Label ID="Label13" runat="server" Font-Size="Small" Style="z-index: 110; left: 53px;
                position: absolute; top: 22px" Text="Select a topic:"></asp:Label>
            <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Size="Small" Style="z-index: 111;
                left: 29px; position: absolute; top: 43px"></asp:Label>
            <asp:Label ID="Label27" runat="server" Font-Bold="True" Font-Size="Medium" Style="z-index: 111;
                left: 10px; position: absolute; top: 2px">Add Questions</asp:Label>
            &nbsp;
            &nbsp;&nbsp;
            <asp:Panel ID="panMC" runat="server" Height="135px" Style="z-index: 112; left: 30px;
                position: absolute; top: 237px" Width="219px">
                <asp:TextBox ID="mccor" runat="server" Style="z-index: 100; left: 76px; position: absolute;
                    top: 4px" Width="162px" TabIndex="1"></asp:TextBox>
                <asp:TextBox ID="mcb" runat="server" Style="z-index: 101; left: 76px; position: absolute;
                    top: 28px" Width="162px" TabIndex="2"></asp:TextBox>
                <asp:TextBox ID="mcc" runat="server" Style="z-index: 102; left: 77px; position: absolute;
                    top: 52px" Width="161px" TabIndex="3"></asp:TextBox>
                <asp:TextBox ID="mcd" runat="server" Style="z-index: 103; left: 77px; position: absolute;
                    top: 76px" Width="161px" TabIndex="4"></asp:TextBox>
                <asp:Label ID="Label7" runat="server" Style="z-index: 104; left: 0px; position: absolute;
                    top: 76px" Text="Choice #3"></asp:Label>
                <asp:TextBox ID="mce" runat="server" Style="z-index: 105; left: 77px; position: absolute;
                    top: 100px" Width="161px" TabIndex="5"></asp:TextBox>
                &nbsp;
                <asp:Label ID="Label8" runat="server" Style="z-index: 106; left: -2px; position: absolute;
                    top: 98px" Text="Choice #4"></asp:Label>
                <asp:Label ID="Label6" runat="server" Style="z-index: 107; left: -1px; position: absolute;
                    top: 50px" Text="Choice #2"></asp:Label>
                <asp:Label ID="Label2" runat="server" Style="z-index: 108; left: 0px; position: absolute;
                    top: 0px" Text="Answer*"></asp:Label>
                <asp:Label ID="Label5" runat="server" Style="z-index: 109; left: 0px; position: absolute;
                    top: 26px" Text="Choice #1*"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="mccor"
                    ErrorMessage="*" SetFocusOnError="True" Style="z-index: 110; left: 243px; position: absolute;
                    top: 0px" ValidationGroup="aaaa"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="mcb"
                    ErrorMessage="*" SetFocusOnError="True" Style="z-index: 112; left: 244px; position: absolute;
                    top: 24px" ValidationGroup="aaaa"></asp:RequiredFieldValidator>
            </asp:Panel>
            <asp:Panel ID="panIden" runat="server" Height="135px" Style="z-index: 113; left: 30px;
                position: absolute; top: 237px" Visible="False" Width="219px">
                <asp:TextBox ID="txtidenAns" runat="server" Style="z-index: 100; left: 79px; position: absolute;
                    top: 4px" Width="159px" TabIndex="1"></asp:TextBox>
                &nbsp; &nbsp;
                <asp:Label ID="Label15" runat="server" Style="z-index: 101; left: 0px; position: absolute;
                    top: 0px" Text="Answer*"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtidenAns"
                    ErrorMessage="*" SetFocusOnError="True" Style="z-index: 103; left: 243px; position: absolute;
                    top: 0px" ValidationGroup="aaaa"></asp:RequiredFieldValidator>
            </asp:Panel>
            <asp:Panel ID="panTOF" runat="server" Height="135px" Style="z-index: 114; left: 30px;
                position: absolute; top: 237px" Visible="False" Width="219px">
                &nbsp; &nbsp;&nbsp;
                <asp:RadioButton ID="RadioButton4" runat="server" Checked="True" GroupName="cc" Style="z-index: 100;
                    left: 46px; position: absolute; top: 17px" Text="True" ValidationGroup="ccc" />
                <asp:RadioButton ID="RadioButton5" runat="server" GroupName="cc" Style="z-index: 101;
                    left: 46px; position: absolute; top: 40px" Text="False" ValidationGroup="ccc" />
            </asp:Panel>
            <asp:ImageButton ID="imgQues" runat="server" BackColor="Transparent" Height="72px"
                ImageUrl="~/Images/NoImage_small.png" Style="z-index: 115; left: 31px; position: absolute;
                top: 160px" Width="82px" TabIndex="33" />
            <asp:FileUpload ID="FileUpload1" runat="server" Style="z-index: 116; left: 128px;
                position: absolute; top: 180px" Width="142px" />
            <asp:Button ID="Button7" runat="server" OnClick="uptof" Style="z-index: 117; left: 144px;
                position: absolute; top: 203px" Text="Upload Image" UseSubmitBehavior="False"
                ValidationGroup="C" Width="96px" />
            <asp:Button ID="Button1" runat="server" Font-Names="Calibri" Height="26px" OnClick="add"
                Style="z-index: 118; left: 103px; position: absolute; top: 415px" Text="Add Item"
                UseSubmitBehavior="False" ValidationGroup="aaaa" Width="96px" />
            <asp:TextBox ID="txtLO" runat="server" MaxLength="4" Style="z-index: 119; left: 68px;
                position: absolute; top: 64px" Width="55px"></asp:TextBox>
            <asp:Label ID="Label10" runat="server" Style="z-index: 120; left: 42px; position: absolute;
                top: 62px" Text="LO*"></asp:Label>
            <asp:Label ID="Label16" runat="server" Style="z-index: 121; left: 43px; position: absolute;
                top: 387px" Text="Difficulty"></asp:Label>
            <asp:TextBox ID="txtCO" runat="server" MaxLength="4" Style="z-index: 122; left: 162px;
                position: absolute; top: 63px" Width="55px"></asp:TextBox>
            <asp:Label ID="Label11" runat="server" Style="z-index: 123; left: 135px; position: absolute;
                top: 62px" Text="CO*"></asp:Label>
            &nbsp;
            <asp:RadioButton ID="RadioButton2" runat="server" AutoPostBack="True" Font-Size="Small"
                ForeColor="LimeGreen" GroupName="aa" OnCheckedChanged="RadioButton2_CheckedChanged1"
                Style="z-index: 124; left: 44px; position: absolute; top: 479px" Text="Identification" Visible="False" />
            2008100034
            <asp:RadioButton ID="RadioButton3" runat="server" AutoPostBack="True" Font-Size="Small"
                ForeColor="LimeGreen" GroupName="aa" OnCheckedChanged="RadioButton3_CheckedChanged"
                Style="z-index: 125; left: 44px; position: absolute; top: 459px" Text="True or False" Visible="False" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtQ"
                ErrorMessage="*" SetFocusOnError="True" Style="z-index: 126; left: 265px; position: absolute;
                top: 106px" ValidationGroup="aaaa"></asp:RequiredFieldValidator>
        </asp:Panel>
        &nbsp; &nbsp;
        &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
        <asp:Label ID="Label18" runat="server" Font-Names="Calibri" Font-Size="Small" ForeColor="#404040"
            Style="z-index: 107; left: 409px; position: absolute; top: 33px" Text="0%"></asp:Label>
        <asp:Label ID="Label19" runat="server" Font-Names="Calibri" Font-Size="Small" ForeColor="#404040"
            Style="z-index: 107; left: 409px; position: absolute; top: 48px" Text="0%"></asp:Label>
        <asp:Label ID="Label20" runat="server" Font-Names="Calibri" Font-Size="Small" ForeColor="#404040"
            Style="z-index: 107; left: 409px; position: absolute; top: 64px" Text="0%"></asp:Label>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%$ ConnectionStrings:RACHELCONN %>' SelectCommand="SELECT * FROM [question_table] WHERE (([typeEx] = @typeEx) AND ([exam_code] = @exam_code)) ORDER BY [ques_desc]" OldValuesParameterFormatString="original_{0}" DeleteCommand="DELETE FROM [question_table] WHERE [ques_id] = @original_ques_id" InsertCommand="INSERT INTO [question_table] ([ins_id], [ques_id], [exam_code], [typeEx], [ques_desc], [ans_a], [ans_b], [ans_c], [ans_d], [ans_e], [ans_f], [ans_g], [ans_h], [ans_i], [ans_j], [l_outcomes], [p_date], [imgLoc], [l_o], [c_o], [copy_type], [pt], [dif]) VALUES (@ins_id, @ques_id, @exam_code, @typeEx, @ques_desc, @ans_a, @ans_b, @ans_c, @ans_d, @ans_e, @ans_f, @ans_g, @ans_h, @ans_i, @ans_j, @l_outcomes, @p_date, @imgLoc, @l_o, @c_o, @copy_type, @pt, @dif)" UpdateCommand="UPDATE [question_table] SET [ques_desc] = @ques_desc, [ans_a] = @ans_a, [ans_b] = @ans_b, [ans_c] = @ans_c, [ans_d] = @ans_d, [ans_e] = @ans_e, [l_o] = @l_o, [c_o] = @c_o, [pt] = @pt, [dif] = @dif WHERE [ques_id] = @original_ques_id">
            <SelectParameters>
                <asp:Parameter DefaultValue="MC" Name="typeEx" Type="String" />
                <asp:SessionParameter Name="exam_code" SessionField="exname" Type="String" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="ins_id" Type="String" />
                <asp:Parameter Name="exam_code" Type="String" />
                <asp:Parameter Name="typeEx" Type="String" />
                <asp:Parameter Name="ques_desc" Type="String" />
                <asp:Parameter Name="ans_a" Type="String" />
                <asp:Parameter Name="ans_b" Type="String" />
                <asp:Parameter Name="ans_c" Type="String" />
                <asp:Parameter Name="ans_d" Type="String" />
                <asp:Parameter Name="ans_e" Type="String" />
                <asp:Parameter Name="ans_f" Type="String" />
                <asp:Parameter Name="ans_g" Type="String" />
                <asp:Parameter Name="ans_h" Type="String" />
                <asp:Parameter Name="ans_i" Type="String" />
                <asp:Parameter Name="ans_j" Type="String" />
                <asp:Parameter Name="l_outcomes" Type="String" />
                <asp:Parameter Name="p_date" Type="String" />
                <asp:Parameter Name="imgLoc" Type="String" />
                <asp:Parameter Name="l_o" Type="String" />
                <asp:Parameter Name="c_o" Type="String" />
                <asp:Parameter Name="copy_type" Type="String" />
                <asp:Parameter Name="pt" Type="Int32" />
                <asp:Parameter Name="dif" Type="String" />
                <asp:Parameter Name="original_ques_id" Type="String" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="ins_id" Type="String" />
                <asp:Parameter Name="ques_id" Type="String" />
                <asp:Parameter Name="exam_code" Type="String" />
                <asp:Parameter Name="typeEx" Type="String" />
                <asp:Parameter Name="ques_desc" Type="String" />
                <asp:Parameter Name="ans_a" Type="String" />
                <asp:Parameter Name="ans_b" Type="String" />
                <asp:Parameter Name="ans_c" Type="String" />
                <asp:Parameter Name="ans_d" Type="String" />
                <asp:Parameter Name="ans_e" Type="String" />
                <asp:Parameter Name="ans_f" Type="String" />
                <asp:Parameter Name="ans_g" Type="String" />
                <asp:Parameter Name="ans_h" Type="String" />
                <asp:Parameter Name="ans_i" Type="String" />
                <asp:Parameter Name="ans_j" Type="String" />
                <asp:Parameter Name="l_outcomes" Type="String" />
                <asp:Parameter Name="p_date" Type="String" />
                <asp:Parameter Name="imgLoc" Type="String" />
                <asp:Parameter Name="l_o" Type="String" />
                <asp:Parameter Name="c_o" Type="String" />
                <asp:Parameter Name="copy_type" Type="String" />
                <asp:Parameter Name="pt" Type="Int32" />
                <asp:Parameter Name="dif" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
        &nbsp;
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click2" Style="left: 306px;
                position: absolute; top: 86px; z-index: 110;" Text="Multiple Choice items" UseSubmitBehavior="False"
                ValidationGroup="B" Width="133px" BackColor="White" BorderColor="Silver" BorderWidth="1px" Font-Names="Segoe UI" />
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Style="left: 443px;
                position: absolute; top: 86px; z-index: 111;" Text="True or False items" UseSubmitBehavior="False"
                ValidationGroup="B" Width="133px" BackColor="Gray" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" Font-Names="Segoe UI" />
            <asp:Button ID="Button5" runat="server" Style="left: 577px; position: absolute; top: 86px; z-index: 112;"
                Text="Identification items" Width="133px" OnClick="Button5_Click" UseSubmitBehavior="False" ValidationGroup="B" BackColor="Gray" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" Font-Names="Segoe UI" />
        &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp;
        &nbsp;&nbsp; &nbsp;&nbsp;
            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False"
            DataKeyNames="ques_id" DataSourceID="SqlDataSource4" Style="left: 304px; position: absolute; top: 131px; z-index: 114; background-image: none;" Width="712px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" EnableModelValidation="True" OnRowDeleted="GridView1_RowDeleted" OnRowUpdated="GridView1_RowUpdated" OnRowEditing="editRow" AllowPaging="True" OnRowCreated="GridView3_RowCreated" CellPadding="3" GridLines="Horizontal" AutoGenerateEditButton="True" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="0px" OnDataBound="GridView3_DataBound" BackColor="White" Font-Names="Calibri" Visible="False">
                <RowStyle BackColor="#E7E7FF" ForeColor="Black" BorderStyle="None" Font-Size="Small" />
                <EmptyDataRowStyle BorderColor="Gray" ForeColor="Cyan" />
                <Columns>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                                OnClick="LinkButton1_Click5" Text="Delete"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
               
                    <asp:BoundField DataField="ques_desc" HeaderText="Question" SortExpression="ques_desc">
                        <ItemStyle Width="300px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ans_a" HeaderText="Answer" SortExpression="ans_a" />
                    <asp:BoundField DataField="pt" HeaderText="Point(s)" SortExpression="pt" />
                    <asp:BoundField DataField="l_o" HeaderText="LO" SortExpression="l_o" />
                    <asp:BoundField DataField="c_o" HeaderText="CO" SortExpression="c_o" />
                    <asp:TemplateField HeaderText="Difficulty" SortExpression="dif">
                        <EditItemTemplate>
                            <asp:DropDownList ID="DropDownList3" runat="server" SelectedValue='<%# Bind("dif") %>'
                                Width="156px">
                                <asp:ListItem>Easy</asp:ListItem>
                                <asp:ListItem>Average</asp:ListItem>
                                <asp:ListItem>Hard</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("dif") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ques_id" HeaderText="ques_id" ReadOnly="True" SortExpression="ques_id"
                        Visible="False" />
                    <asp:BoundField DataField="imgLoc" HeaderText="imgLoc" SortExpression="imgLoc" Visible="False" />
                    <asp:TemplateField HeaderText="Question (Image file)">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton2" runat="server" Height="57px" ImageUrl='<%# Eval("imgLoc") %>'
                                Width="95px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                <EmptyDataTemplate>
                    <span style="color: #000000; font-size: large;">No data.</span>
                </EmptyDataTemplate>
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                <HeaderStyle BackColor="Gray" Font-Bold="False" ForeColor="#F7F7F7" BorderColor="Gray" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="True" CssClass="HeaderStyle" Font-Size="Small" />
                <AlternatingRowStyle BackColor="#F7F7F7" />
            </asp:GridView>
        <asp:GridView ID="GridViewToF" runat="server" AutoGenerateColumns="False"
            DataKeyNames="ques_id" DataSourceID="SqlDataSource3" Style="left: 304px; position: absolute; top: 131px; z-index: 115; background-image: none;" Width="712px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" EnableModelValidation="True" OnRowDeleted="GridView1_RowDeleted" OnRowUpdated="GridView1_RowUpdated" OnRowEditing="editRow" AllowPaging="True" OnRowCreated="aa" CellPadding="3" GridLines="Horizontal" AutoGenerateEditButton="True" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="0px" OnDataBound="GridView3_DataBound" BackColor="White" Font-Names="Calibri" Visible="False">
            <RowStyle BackColor="#E7E7FF" ForeColor="Black" BorderStyle="None" Font-Size="Small" />
            <EmptyDataRowStyle BorderColor="Gray" ForeColor="Cyan" />
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                            OnClick="LinkButton1_Click4" Text="Delete"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ques_desc" HeaderText="Question" SortExpression="ques_desc">
                    <ItemStyle Width="250px" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Answer" SortExpression="ans_a">
                    <EditItemTemplate>
                        &nbsp;<asp:DropDownList ID="DropDownList4" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged1"
                            Width="114px">
                            <asp:ListItem Selected="True">True</asp:ListItem>
                            <asp:ListItem>False</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label ID="Label24" runat="server" Text='<%# Bind("ans_a") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("ans_a") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Joker" SortExpression="ans_b">
                    <EditItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("ans_b") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("ans_b") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="pt" HeaderText="Point(s)" SortExpression="pt" />
                <asp:BoundField DataField="l_o" HeaderText="LO" SortExpression="l_o" />
                <asp:BoundField DataField="c_o" HeaderText="CO" SortExpression="c_o" />
                <asp:TemplateField HeaderText="Difficulty" SortExpression="dif">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList33" runat="server" SelectedValue='<%# Bind("dif") %>'
                            Width="156px">
                            <asp:ListItem>Easy</asp:ListItem>
                            <asp:ListItem>Average</asp:ListItem>
                            <asp:ListItem>Hard</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("dif") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ques_id" HeaderText="ques_id" ReadOnly="True" SortExpression="ques_id"
                        Visible="False" />
                <asp:BoundField DataField="imgLoc" HeaderText="imgLoc" SortExpression="imgLoc" Visible="False" />
                <asp:TemplateField HeaderText="Image">
                    <ItemTemplate>
                        &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" Height="57px" ImageUrl='<%# Eval("imgLoc") %>'
                            Width="95px" />
                    </ItemTemplate>
                    <ItemStyle Width="50px" />
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <HeaderStyle BackColor="Gray" Font-Bold="False" ForeColor="#F7F7F7" BorderColor="Gray" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="True" CssClass="HeaderStyle" Font-Size="Small" />
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <EmptyDataTemplate>
                <span style="font-size: 18pt; color: #000000">No data.</span>
            </EmptyDataTemplate>
        </asp:GridView><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
            DataKeyNames="ques_id" DataSourceID="SqlDataSource1" Style="left: 304px; position: absolute; top: 131px; z-index: 116; background-image: none;" Width="712px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" EnableModelValidation="True" OnRowDeleted="GridView1_RowDeleted" OnRowUpdated="GridView1_RowUpdated" OnRowEditing="editRow" AllowPaging="True" OnRowCreated="aaa" CellPadding="3" GridLines="Horizontal" AutoGenerateEditButton="True" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="0px" OnDataBound="GridView3_DataBound" BackColor="White" Font-Names="Calibri">
            <RowStyle BackColor="#E7E7FF" ForeColor="Black" BorderStyle="None" Font-Size="Small" />
            <EmptyDataRowStyle BorderColor="Gray" ForeColor="Cyan" />
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                            OnClick="LinkButton1_Click3" Text="Delete"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ques_desc" HeaderText="Question" SortExpression="ques_desc">
                    <ItemStyle Width="150px" />
                </asp:BoundField>
                <asp:BoundField DataField="ans_a" HeaderText="Answer" SortExpression="ans_a" />
                <asp:BoundField DataField="ans_b" HeaderText="Choice 1" SortExpression="ans_b" />
                <asp:BoundField DataField="ans_c" HeaderText="Choice 2" SortExpression="ans_c" />
                <asp:BoundField DataField="ans_d" HeaderText="Choice 3" SortExpression="ans_d" />
                <asp:BoundField DataField="ans_e" HeaderText="Choice 4" SortExpression="ans_e" />
                <asp:BoundField DataField="pt" HeaderText="Point(s)" SortExpression="pt" />
                <asp:BoundField DataField="l_o" HeaderText="LO" SortExpression="l_o" />
                <asp:BoundField DataField="c_o" HeaderText="CO" SortExpression="c_o" />
                <asp:TemplateField HeaderText="Difficulty" SortExpression="dif">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList3" runat="server" SelectedValue='<%# Bind("dif") %>'
                            Width="156px">
                            <asp:ListItem>Easy</asp:ListItem>
                            <asp:ListItem>Average</asp:ListItem>
                            <asp:ListItem>Hard</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("dif") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ques_id" HeaderText="ques_id" ReadOnly="True" SortExpression="ques_id"
                        Visible="False" />
                <asp:BoundField DataField="imgLoc" HeaderText="imgLoc" SortExpression="imgLoc" Visible="False" />
                <asp:TemplateField HeaderText="Image file">
                    <ItemTemplate>
                        &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" Height="57px" ImageUrl='<%# Eval("imgLoc") %>'
                            Width="95px" />
                    </ItemTemplate>
                    <ItemStyle Width="50px" />
                    <EditItemTemplate>
                        &nbsp;<br />
                        <br />
                        &nbsp;<br />
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <HeaderStyle BackColor="Gray" Font-Bold="False" ForeColor="#F7F7F7" BorderColor="Gray" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="True" CssClass="HeaderStyle" Font-Size="Small" />
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <EmptyDataTemplate>
                <span style="font-size: large; color: black">No data.</span>
            </EmptyDataTemplate>
        </asp:GridView>
        &nbsp;&nbsp;&nbsp;
            <asp:RadioButton ID="radmc" runat="server" AutoPostBack="True" Checked="True"
                Font-Size="Small" ForeColor="LimeGreen" GroupName="aa" OnCheckedChanged="RadioButton1_CheckedChanged1"
                Style="z-index: 117; left: 48px; position: absolute; top: 531px" Text="Multiple Choice" Font-Names="Calibri" Visible="False" />
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:CIT examsConnectionString3 %>" SelectCommand="SELECT DISTINCT [exam_code] FROM [question_table] WHERE (([ins_id] = @ins_id) AND ([ques_id] NOT LIKE '%' + @ques_id + '%') AND ([p_date] = @p_date2))">
                <SelectParameters>
                    <asp:SessionParameter Name="ins_id" SessionField="user" Type="String" />
                    <asp:Parameter DefaultValue="AUO878728MchbMhajOl%" Name="ques_id" Type="String" />
                    <asp:Parameter DefaultValue=" " Name="p_date2" />
                </SelectParameters>
            </asp:SqlDataSource>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        &nbsp;<br />
        <asp:Label ID="Label21" runat="server" Font-Names="Calibri" Font-Size="Medium" ForeColor="White"
            Style="z-index: 107; left: 0px; position: absolute; top: 2px" Text="Draft Name:"></asp:Label>
        <br />
        &nbsp; 
        <asp:CheckBox ID="CheckBox1" runat="server" Font-Names="Calibri" Font-Size="Small"
            ForeColor="#E0E0E0" Style="z-index: 118; left: -55px; position: absolute; top: 468px" />
        &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged2"
            Style="z-index: 119; left: 148px; position: absolute; top: 111px" Width="48px" AutoPostBack="True">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:JOELCONN %>"
            SelectCommand="SELECT * FROM [course_topics] WHERE (CONTAINS([l_o], @l_o)) ORDER BY [week]">
            <SelectParameters>
                <asp:SessionParameter Name="l_o" SessionField="weeks" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:Panel ID="Panel2" runat="server">
        </asp:Panel>
    </div>
    </form>
</body>
</html>
