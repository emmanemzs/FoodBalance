<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Landing.aspx.cs" Inherits="Proj1.Landing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="StyleSheet1.css">

    
    <script> <!-- Build Button Scroll -->
    function scrollToSelect() {
        const target = document.getElementById("main2");
        if (target) {
            target.scrollIntoView({ behavior: "smooth" });
        }
    }
    </script>

</head>

<body>
    <form id="form1" runat="server">
        <div class="headback"></div> <!-- Headder Background -->
        <div class="mainback"></div> <!-- Main Area Background Image -->

        <div class="container">
                <!-- All content in container for spacing-->
            <header class="header" id="header">

                <div class="ht1">  <!-- logo -->
			        <p>Balanced Bites - Build your Meal</p> 
		        </div>
		
		        <div class="ht2" id="ht2"> <!-- head text 2 project title -->
			        <p>Cgt 45600 - Project 1</p>
		        </div>
            </header>

            <div class="main1" id="main1">  <!-- Builder intro -->
                <div class="main1Content" id="main1Content">
                    <h3 class="MB">Meal Builder</h3>
                    <h2 class="BB">Balanced Bites</h2>
                    
                    <asp:Button ID="Button1" runat="server" Text="Build" CssClass="build-button" UseSubmitBehavior="false" OnClientClick="scrollToSelect(); return false;"/>
                </div>
               </div>
            </div>
            <div class="main2"id="main2"> <!-- selection area -->
                <div class="main2Content" id="main2Content">
                    <div class="selectText"> 
                        <p>Select</p>
                    </div>
                    <div class="descript"> 
                        <p>Create a balanced and delicious meal by selecting ingredients across proteins, grains, fruits, and more.
                                 /n Customize your plate and receive instant feedback on how well your meal is balanced. </p>
                    </div>
                    <div class="selectButton"> <!-- Navigation -->
                        <asp:Button ID="Button2" runat="server" Text="Breakfast" CssClass="meal-button" OnClick="Nav" />
                        <asp:Button ID="Button3" runat="server" Text="Lunch" CssClass="meal-button" OnClick="Nav"/>
                        <asp:Button ID="Button4" runat="server" Text="Dinner"  CssClass="meal-button"  OnClick="Nav"/>
                        <asp:Button ID="Button5" runat="server" Text="Snacks" CssClass="meal-button"  OnClick="Nav"/>
                    </div>

                </div>
            </div>
            <div>

            </div>
        </div>
    </form>
</body>
</html>
