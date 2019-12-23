<%@ Page Title="تبرع الآن" Language="C#" MasterPageFile="~/Masters/DefaultLayout.master" AutoEventWireup="true" CodeFile="Donate.aspx.cs" Inherits="Donate" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContent" Runat="Server">
    <link href="Style/form.css" rel="stylesheet" />
</asp:Content>


<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContent" Runat="Server">
    <form method="post" runat="server" class="form-container">
        <asp:Label runat="server" CssClass="required"> الجمعية: </asp:Label>
        <asp:DropDownList ID="orphanageDropDownList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="OrphanageDropDownList_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="orphanageDropDownList"></asp:RequiredFieldValidator>

        <asp:Label runat="server" CssClass="required"> الحملة: </asp:Label>
        <asp:DropDownList ID="planDropDownList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PlanDropDownList_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="planDropDownList"></asp:RequiredFieldValidator>

        <asp:Label runat="server" CssClass="required"> كمية التبرع: </asp:Label>
        <asp:TextBox TextMode="Number" ID="amountTextBox" runat="server" CssClass="form-control">الكمية: </asp:TextBox>
        <asp:RangeValidator ID="amountRangeValidator" runat="server" MinimumValue="1" MaximumValue="1000000000" CssClass="validation" ControlToValidate="amountTextBox" ErrorMessage="لا يمكن استقبال الكمية التي ادخلتها، إذا كنت تعتقد أنها كمية صحيحة، نرجو التواصل معنا"></asp:RangeValidator>
        
        <asp:Label runat="server" CssClass="required"> طريقة التبرع: </asp:Label>
        <asp:DropDownList ID="methodDropDownList" runat="server" CssClass="form-control"></asp:DropDownList>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="methodDropDownList"></asp:RequiredFieldValidator>
        
        <asp:Label runat="server" CssClass="required"> الإسم: </asp:Label>
        <asp:TextBox ID="nameTextBox" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="nameTextBox" ErrorMessage="يرجى إدخال الاسم"></asp:RequiredFieldValidator>

        <asp:Label runat="server" CssClass="required"> المحافظة: </asp:Label>
        <asp:DropDownList ID="cityDropDownList" runat="server" CssClass="form-control">
            <asp:ListItem>حلب</asp:ListItem>
            <asp:ListItem>دمشق</asp:ListItem>
            <asp:ListItem>حمص</asp:ListItem>
            <asp:ListItem>اللاذقية</asp:ListItem>
            <asp:ListItem>حماة</asp:ListItem>
            <asp:ListItem>ادلب</asp:ListItem>
            <asp:ListItem>طرطوس</asp:ListItem>
            <asp:ListItem>الرقة</asp:ListItem>
            <asp:ListItem>دير الزور</asp:ListItem>
            <asp:ListItem>السويداء</asp:ListItem>
            <asp:ListItem>الحسكة</asp:ListItem>
            <asp:ListItem>درعا</asp:ListItem>
            <asp:ListItem>القنيطرة</asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="cityDropDownList"></asp:RequiredFieldValidator>
        
        <asp:Label runat="server"> اسم الشارع: </asp:Label>
        <asp:TextBox ID="streetTextBox" runat="server" CssClass="form-control"></asp:TextBox>
        
        <asp:Label runat="server"> تفاصيل العنوان: </asp:Label>
        <asp:TextBox ID="addressTextBox" runat="server" CssClass="form-control"></asp:TextBox>
       
        <asp:Label runat="server" CssClass="required"> رقم الهاتف: </asp:Label>
        <asp:TextBox ID="mobileTextBox" runat="server" TextMode="Phone" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="mobileTextBox" CssClass="validation" ErrorMessage="يرجى تزويدنا برقم الهاتف"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator runat="server" ControlToValidate="mobileTextBox" ValidationExpression="09[0-9]{8}" CssClass="validation" ErrorMessage="يرجى إدخال رقم جوال صحيح"></asp:RegularExpressionValidator>
        
        <asp:Label runat="server"> البريد الالكتروني: </asp:Label>
        <asp:TextBox ID="emailTextBox" runat="server" TextMode="Email" CssClass="form-control"></asp:TextBox>
        
        <asp:Button ID="submitButton" runat="server" Text="إرسال" CssClass="form-control button-control" OnClick="submitButton_Click"/>
    </form>
</asp:Content>

