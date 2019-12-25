<%@ Page Title="إدارة التبرعات" Language="C#" MasterPageFile="~/Masters/ManagerLayout.master" AutoEventWireup="true" CodeFile="EditDonation.aspx.cs" Inherits="EditDonation" %>


<asp:Content ID="headContent" ContentPlaceHolderID="headContent" Runat="Server">
    <link href="Style/Form.css" rel="stylesheet" />
</asp:Content>


<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContent" Runat="Server">
    <form method="post" runat="server">
        <asp:panel ID="mainPanel" runat="server" CssClass="form-container">
            <asp:Label runat="server" CssClass="required">رقم التبرع</asp:Label>
            <asp:DropDownList runat="server" ID="donationDropDownList" CssClass="form-control" OnSelectedIndexChanged="donationDropDownList_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem Text="---- اختر رقم التبرع المراد تعديله ---" selected="selected" disabled="disabled" Value="-1"></asp:ListItem>
            </asp:DropDownList>
            
            <asp:Button ID="deleteButton" runat="server" CssClass="btn btn-danger btn-lg form-control" Text="حذف التبرع" OnClick="deleteButton_Click" /> 
        </asp:panel>

        <asp:Panel ID="subPanel" runat="server" CssClass="form-container">
            <asp:Label runat="server">اسم المتبرع: </asp:Label>
            <asp:Label ID="donorNameLabel" runat="server" CssClass="form-control" ></asp:Label>

             <asp:Label runat="server">اسم الحملة: </asp:Label>
            <asp:Label ID="planNameLabel" runat="server" CssClass="form-control" ></asp:Label>

            <asp:Label runat="server"> عنوان المتبرع: </asp:Label>
            <asp:TextBox ID="donorAddressLabel" runat="server" CssClass="form-control"></asp:TextBox>

            <asp:Label runat="server">الهاتف: </asp:Label>
            <asp:Label ID="telephoneLabel" runat="server" CssClass="form-control"></asp:Label>

            <asp:Label runat="server">البريد الإلكتروني: </asp:Label>
            <asp:Label ID="emailTextLabel" runat="server" CssClass="form-control" ></asp:Label>

            <asp:Label runat="server">نوع التبرع: </asp:Label>
            <asp:Label ID="typeLabel" runat="server" CssClass="form-control" ></asp:Label>

            <asp:Label runat="server">الكمية: </asp:Label>
            <asp:Label ID="amountLabel" runat="server" CssClass="form-control"></asp:Label>

            
            <label>
                <asp:CheckBox runat="server" ID="donorContactedCheckBox" />
                تم التواصل مع المتبرع ؟
            </label>

            <label>
                <asp:CheckBox runat="server" ID="donationCollectedCheckBox" />
                تم تحصيل التبرع ؟
            </label>

            <asp:Button ID="saveButton" runat="server" CssClass="btn btn-success btn-lg form-control" OnClick="saveButton_Click" Text="حفظ التعديلات" />
        </asp:Panel>
    </form>
</asp:Content>
