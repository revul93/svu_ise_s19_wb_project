<%@ Page Title="تبرع الآن" Language="C#" MasterPageFile="~/DefaultLayout.master" AutoEventWireup="true" CodeFile="Donate.aspx.cs" Inherits="Donate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" Runat="Server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" Runat="Server">
    <form method="post" runat="server">
        <asp:DropDownList ID="orphanageDropDownList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="OrphanageDropDownList_SelectedIndexChanged">
        </asp:DropDownList>

        <asp:DropDownList ID="planDropDownList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="planDropDownList_SelectedIndexChanged">
        </asp:DropDownList>

        <input type="number" min="1" step="1" value="1" name="amountInput" />

         <asp:DropDownList ID="methodDropDownList" runat="server">
         </asp:DropDownList>
        <input type="text" name="nameInput" required />
        <input type="text" name="cityInput" required />
        <input type="text" name="streetInput" required />
        <input type="text" name="addressInput" required />
        <input type="tel" name="mobileInput" required />
        <input type="email" name="emailInput" />
        <input type="submit" value="إرسال"/>
    </form>
</asp:Content>

