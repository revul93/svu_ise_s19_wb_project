<%@ Page Title="إدارة دور الأيتام" Language="C#" MasterPageFile="~/Masters/AdminLayout.master" AutoEventWireup="true" CodeFile="OrphanageManagement.aspx.cs" Inherits="OrphanageManagement" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContent" Runat="Server">
    <link href="Style/List.css" rel="stylesheet" />
    <link href="Style/Orphanage.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContent" Runat="Server">
    <div class="link-list">
        <div class="link-list-item">
            <a href="AddOrphanage.aspx" class="btn btn-success btn-lg">إضافة دار أيتام</a>
        </div>
        <div class="link-list-item">
            <a href="EditOrphanage.aspx" class="btn btn-success btn-lg">تعديل دور أيتام</a>
        </div>
    </div>
    <div class="list-container">
        <asp:PlaceHolder ID="orphanagesList" runat="server">
        </asp:PlaceHolder>

    </div>
</asp:Content>

