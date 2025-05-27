<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lunch.aspx.cs" Inherits="Proj1.Lunch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
    <link rel="stylesheet" href="StyleSheet1.css">
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />

        <div>
             <div class="headback"></div>
             <div class="mainback"></div>

             <div class="container">
                     <!-- All content in container -->
                 <header class="header" id="header">

                     <div class="ht1">  <!-- logo -->
		                    <p>Balanced Bites - Build your Meal</p> 
	                    </div>
	
	                    <div class="ht2" id="ht2"> <!-- head text 2 -->
		                    <p>Cgt 45600 - Project 1</p>
	                    </div>
                 </header>

                 <div class="bMainContent">
                    <div class="back">
                        <div class="backButton">
                            <asp:Button ID="Button1" runat="server" Text="Back" CssClass="back-button" OnClick="Button1_Click" />
                        </div>
                    </div>
                </div>
                 <div class="meal-builder-section">
                  <!-- Left Column -->
                  <div class="meal-builder-left">
                    <h2>Build your</h2>
                    <h1>Lunch</h1>

                    <div class="food-select-header">
                      <h3>Select your foods</h3>
                       <asp:Button ID="Button12" runat="server" Text="Clear All" OnClick="Button12_Click" CssClass="clear-categories" />

                    </div>

                      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                           <ContentTemplate>
                    <div class="food-grid">
                        <asp:Button ID="Button2" runat="server" Text="Chicken - 0" CssClass="food-buttonP" OnClick="Add_Food" />
                        <asp:Button ID="Button3" runat="server" Text="Tofu - 0" CssClass="food-buttonP" OnClick="Add_Food" />
                        <asp:Button ID="Button4" runat="server" Text="Bread - 0" CssClass="food-buttonG" OnClick="Add_Food" />
                        <asp:Button ID="Button5" runat="server" Text="Ham - 0" CssClass="food-buttonP" OnClick="Add_Food" />
                        <asp:Button ID="Button6" runat="server" Text="Rice - 0" CssClass="food-buttonG" OnClick="Add_Food" />
                        <asp:Button ID="Button7" runat="server" Text="Raspberries - 0" CssClass="food-buttonF" OnClick="Add_Food" />
                        <asp:Button ID="Button8" runat="server" Text="Kiwi - 0" CssClass="food-buttonF" OnClick="Add_Food" />
                        <asp:Button ID="Button9" runat="server" Text="Blueberry - 0" CssClass="food-buttonF" OnClick="Add_Food" />
                        <asp:Button ID="Button10" runat="server" Text="Sweet Potato - 0" CssClass="food-buttonV" OnClick="Add_Food" />
                        <asp:Button ID="Button11" runat="server" Text="Brocolli - 0" CssClass="food-buttonV" OnClick="Add_Food" />

                        <asp:Button ID="Button13" runat="server" Text="Clear Protien" CssClass="clear-categories" OnClick="Button12_Click"/>
                        <asp:Button ID="Button14" runat="server" Text="Clear Vegetable" CssClass="clear-categories" OnClick="Button12_Click"/>
                        <asp:Button ID="Button15" runat="server" Text="Clear Fruit" CssClass="clear-categories" OnClick="Button12_Click"/>
                        <asp:Button ID="Button16" runat="server" Text="Clear Grain" CssClass="clear-categories" OnClick="Button12_Click"/>
                    </div>
                               </ContentTemplate>
                          </asp:UpdatePanel>
                  </div>

                  <!-- Right Column -->
                  <div class="meal-builder-right">
                      <figure class="chart">
                         <div id="circle" runat="server" ></div>
                      </figure>

                   <!--   <div class="tally">
                            <asp:Label ID="LabelVeg" runat="server" Text="Vegetables: 0" />
                            <asp:Label ID="LabelFruit" runat="server" Text="Fruits: 0" />
                            <asp:Label ID="LabelProtein" runat="server" Text="Proteins: 0" />
                            <asp:Label ID="LabelGrain" runat="server" Text="Grains: 0" />
                        </div> -->
                  </div>
                </div>
               </div>
                    

        </div>
    </form>
</body>
</html>
