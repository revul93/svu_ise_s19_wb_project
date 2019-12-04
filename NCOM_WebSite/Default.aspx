<%@ Page Title="الرئيسية" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContent" Runat="Server">
    <link rel="stylesheet" href="StyleSheet.css" />
</asp:Content>


<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContnet" Runat="Server">
    <header>
        <div id="charityHeading">
            <img id="charityLogo" src="Images\logo.png" alt="Charity logo"/>
            <p id="charityName">الجمعية الخيرية لإدارة دور الأيتام<br />National Charity for Orphanage Management</p>
        </div>
        <nav>
            <ul>
                <li><a href="#">الرئيسية</a></li>
                <li><a href="#">دور الأيتام</a></li>
                <li><a href="#">تبرع الآن</a></li>
                <li id="loginButton"><a href="Login.aspx">تسجيل دخول</a></li>
            </ul>
        </nav>
    </header>

    <section>
        <!--- Banner Image -->
        <img src="Images/OrphanKidsEating.jpg" id="bannerImage" alt="Banner Image" />
    </section>
    <section>
        <!--- General Info -->
        <div class="container">
            <div class="row">
                <div class="col generalInfoItems">
                    <p>دور الأيتام</p>
                    <asp:Label runat="server" ID="numOrphanages"></asp:Label>
                </div>
                <div class="col generalInfoItems">
                    <p>الأيتام المكفولين</p>
                    <asp:Label runat="server" ID="numSpoOrphans"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col generalInfoItems">
                    <p>المتبرعين</p>
                    <asp:Label runat="server" ID="numDonors"></asp:Label>
                </div>
                <div class="col generalInfoItems">
                    <p>إجمالي التبرعات</p>
                    <asp:Label runat="server" ID="totalDonations"></asp:Label>
                </div>
            </div>
             <div class="row">
                <div class="col">
                    <button class="generalInfoItems">كن منهم، تبرع الآن</button>
                </div>
            </div>
        </div>

    </section>
    <section>
        <!-- About NCOM -->
        <div class="container">
            <div class="row">
                <div class="col">
                    <p>من نحن</p>
                    <p> جمعية خيرية تشكل حلقة وصل بينكم وبين دور الأيتام المنتشرة في سوريا، وذلك لنعرفكم عليها ونطلعكم على مستلزمات كل دار ومتطلباتها.</p>
                </div>
                <div class="col">
                    <p>أهدافنا</p>
                    <p>وصول أسرع وأسهل لتحقيق المساعدة، والتعاون مع الجميع بما فيه مصلحة اليتيم.</p>
                </div>
                <div class="col">
                    <p>رؤيتنا</p>
                    <p>المضي يدا بيد لتوفير حياة كريمة لأيتام سوريا.</p>
                </div>
            </div>"
        </div>
    </section>
    <footer>
        <!-- Contact Information -->
        <address>
            الهاتف <a href="tel:+963112255110"> +963 112 255 110 </a><br />
            الإيميل: <a href="mailto:info@ncom.sy">info@ncom.sy</a><br />
            العنوان: دمشق، شارع النهضة، حي الوحدة، مبنى 511<br />
            فيسبوك: <a href="http://www.facebook.com/NCOM/">NCOM</a>
            انستحرام: <a href="https://www.instagram.com/NCOM/">@NCOM</a>
        </address>
    </footer>
</asp:Content>

