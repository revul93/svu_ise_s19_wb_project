<%@ Page Title="الرئيسية" Language="C#" MasterPageFile="~/DefaultLayout.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="DefaultHead" ContentPlaceHolderID="headContent" Runat="Server">
    <link rel="Default.css" href="StyleSheet.css" />
</asp:Content>

<asp:Content ID="DefaultBody" ContentPlaceHolderID="bodyContent" Runat="Server">
    <section>
        <div id="carouselExampleSlidesOnly" class="carousel slide" data-ride="carousel">
          <div class="carousel-inner">
            <div class="carousel-item active">
                <img src="Images/child-865116_1920.jpg" class="d-block w-75" />
            </div>
            <div class="carousel-item">
              <img src="Images/heroesbrief-1600362.jpg" class="d-block w-75" />
            </div>
            <div class="carousel-item">
              <img src="Images/OrphanGirlPainting.jpg" class="d-block w-75" />
            </div>
          </div>
        </div>
    </section>
    <section>
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
            </div>
        </div>
    </section>
</asp:Content>
