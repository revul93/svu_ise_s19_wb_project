<%@ Page Title="الرئيسية" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContent" Runat="Server">
    <style>

        #charityHeading {
            margin-top: 10px;
        }
        #charityLogo {
            display: block;
            width: 60px;
            margin: 0 auto;
            height: auto;
        }
        #charityName {
            text-align: center;
            font-size: 1.5rem;
        }

        #bannerImage {
            display: block;
            width: 100%;
        }

    </style>
</asp:Content>


<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContnet" Runat="Server">
    <header>
        <div id="charityHeading">
            <img id="charityLogo" src="Images\logo.png" alt="Charity logo"/>
            <p id="charityName">الجمعية الخيرية لإدارة دور الأيتام<br />National Charity for Orphanage Management</p>
        </div>
        <nav>
            <ul>
                <li>الرئيسية</li>
                <li>دور الأيتام</li>
                <li>تبرع الآن</li>
                <li><a href="Login.aspx">تسجيل دخول</a></li>
            </ul>
        </nav>
    </header>

    <section>
        <!--- Banner Image -->
        <img src="banner.png" id="bannerImage" alt="Banner Image" />
    </section>
    <section>
        <!--- General Info -->
        <div>دور الأيتام</div>
        <div>الأيتام</div>
        <div>الأيتام المكفولين</div>
        <br />
        <div>المتبرعين</div>
        <div>إجمالي التبرعات</div>
        <div>كن منهم، تبرع الآن</div>
    </section>
    <section>
        <!-- About NCOM -->
        <div>من نحن</div>
        <div>رؤيتنا</div>
        <div>أهدافنا</div>
        <div>رسالتنا</div>
        <div>قيمنا</div>
        <div>شعارنا</div>
    </section>
    <section>
        <!-- Contact Information -->
        <div>الهاتف</div>
        <div>الإيميل</div>
        <div>الموقع</div>
        <div>العنوان</div>
        <div>فيسبوك</div>
        <div>تويتر</div>
        <div>انستجرام</div>
    </section>
</asp:Content>

