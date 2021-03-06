﻿<%@ Page Title="الرئيسية" Language="C#" MasterPageFile="~/Masters/DefaultLayout.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="DefaultHead" ContentPlaceHolderID="headContent" Runat="Server">
    <link href="Style/Default.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="DefaultBody" ContentPlaceHolderID="bodyContent" Runat="Server">
    <section id="welcome-images">
        <div id="carousel" class="carousel slide carousel-fade" data-ride="carousel">
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <img src="Images/child-865116_1920.jpg" class="d-block w-100" />
                </div>
                <div class="carousel-item">
                    <img src="Images/heroesbrief-1600362.jpg" class="d-block w-100" />
                </div>
                <div class="carousel-item">
                    <img src="Images/OrphanGirlPainting.jpg" class="d-block w-100" />
                </div>
            </div>
            <a class="carousel-control-prev" href="#carousel" role="button" data-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="sr-only">السابق</span>
            </a>
            <a class="carousel-control-next" href="#carousel" role="button" data-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="sr-only">التالي</span>
            </a>
        </div>
    </section> 

    <section>
        <asp:Label class="definition" text= "تعرف علينا" runat="server"></asp:Label>
        <div class="items-container ">
            <div class="items">
                <p class="aboutUsItemTitle">من نحن</p>
                <hr />
                <p> جمعية خيرية تشكل حلقة وصل بينكم وبين دور الأيتام المنتشرة في سوريا، وذلك لنعرفكم عليها ونطلعكم على مستلزمات كل دار ومتطلباتها.</p>
            </div>
            <div class="items">
                <p class="aboutUsItemTitle">أهدافنا</p>
                <hr />
                <p>وصول أسرع وأسهل لتحقيق المساعدة، والتعاون مع الجميع بما فيه مصلحة اليتيم.</p>
            </div>
            <div class="items">
                <p class="aboutUsItemTitle">رؤيتنا</p>
                <hr />
                <p>المضي يدا بيد لتوفير حياة كريمة لأيتام سوريا.</p>
            </div>
        </div>
    </section>

    <section>
        <div class="items-container">
            <div class="items">
                <p class="aboutUsItemTitle">دور الأيتام</p><hr />
                <asp:Label class="info-data" runat="server" ID="numOrphanages"></asp:Label>
            </div>
            <div class="items">
                <p class="aboutUsItemTitle">الأيتام المكفولين</p><hr />
                <asp:Label class="info-data" runat="server" ID="numSpoOrphans"></asp:Label>
            </div>
            <div class="items">
                <p class="aboutUsItemTitle">المتبرعين</p><hr />
                <asp:Label class="info-data" runat="server" ID="numDonors"></asp:Label>
            </div>
            <div class="items">
                <p class="aboutUsItemTitle">إجمالي التبرعات</p><hr />
                <asp:Label class="info-data" runat="server" ID="totalDonations"></asp:Label><br />
            </div>
        </div>
    </section>

    <section>
        <div class="donate">
            <asp:Label class="definition" text= "شتاؤهم أدفأ بعطائكم" runat="server"  ID="Label1"></asp:Label>
            <a id="donate-button" href="Donate.aspx">من أجلهم تبرع الآن!</a>
        </div>
    </section>
</asp:Content>
