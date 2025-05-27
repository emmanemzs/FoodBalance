using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Proj1
{
    public partial class Breakfast : System.Web.UI.Page
    {
        private void IncrementCategory(string category)
        {
            // keep track of number of times category is clicked
            int currentCount = (int)(Session[category] ?? 0);
            currentCount++;
            Session[category] = currentCount;
            UpdatePiechart();
        }

        private void UpdatePiechart()
        {
            //update the pie chart when a category is clicked

            int Veg = (int)(Session["Vegetables"] ?? 0);
            int Fruit = (int)(Session["Fruits"] ?? 0);
            int Protein = (int)(Session["Proteins"] ?? 0);
            int Grain = (int)(Session["Grains"] ?? 0);

            //calculate degrees for pie chart
            int ratio = 360 / (Veg + Fruit + Protein + Grain);
            Veg = Veg * ratio;
            Fruit = Fruit * ratio + Veg;
            Protein = Protein * ratio + Fruit;
            Grain = Grain * ratio + Protein;


            //update pie chart css with javascript
            String javascriptFunct = "document.getElementById('circle').style.backgroundImage = 'conic-gradient(*)'";

            String vegSlice = $"#ABCEA9 0 {Veg}deg,";
            String fruitSlice = $"#E66E7D 0 {Fruit}deg,";
            String proteinSlice = $"#A3B8DC 0 {Protein}deg,";
            String grainSlice = $"#FFF2C4  0 {Grain}deg";

            String conic_arguments = vegSlice + fruitSlice + proteinSlice + grainSlice;

            javascriptFunct = javascriptFunct.Replace("*", conic_arguments);

            //circle.Attributes["onClick"] = javascriptFunct;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "UpdatePie", javascriptFunct, true);

        }

        private void Clear_Food_Button(Button button)
        {
            //clears the buttons that are given when called
            string buttonText = button.Text;
            int positionSp = buttonText.LastIndexOf(' ');

            string oldNum = buttonText.Substring(positionSp + 1);

            button.Text = buttonText.Replace(oldNum, "0");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //reset counter
            if (!IsPostBack)
            {
                Session["Vegetables"] = 0;
                Session["Fruits"] = 0;
                Session["Proteins"] = 0;
                Session["Grains"] = 0;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //back button
            Response.Redirect("~/Landing.aspx");
        }

        protected void Add_Food(object sender, EventArgs e)
        {
            // adding the button clicked to the right category using specified css classes

            Button clickedButton = (Button)sender;
            string cssName = clickedButton.CssClass;

            if (cssName.EndsWith("V")){
                IncrementCategory("Vegetables");
            }
            else if (cssName.EndsWith("F"))
            {
                IncrementCategory("Fruits");
            }
            else if (cssName.EndsWith("P"))
            {
                IncrementCategory("Proteins");
            }
            else if (cssName.EndsWith("G"))
            {
                IncrementCategory("Grains");
            }

            // adding number to button when clicked 

            string buttonText = clickedButton.Text;
            int positionSp =buttonText.LastIndexOf(' ');

            string oldNum = buttonText.Substring(positionSp + 1);
            int newNum = Convert.ToInt32(oldNum) + 1;

            clickedButton.Text = buttonText.Replace(oldNum, Convert.ToString(newNum));

            

            

        }
        
        protected void Button12_Click(object sender, EventArgs e)
        {
            // clear button

            Button clickedButton = (Button)sender;
            string butCategory = clickedButton.Text;

        

            if (butCategory.Contains("Protien")) // clears all protien
            {
                Clear_Food_Button(Button2);
                Clear_Food_Button(Button3);
                Clear_Food_Button(Button5);
                Session["Proteins"] = 0;
                UpdatePiechart();


            }
            else if (butCategory.Contains("Vegetable")) // clears all veg
            {
                Clear_Food_Button(Button10);
                Clear_Food_Button(Button11);
                Session["Vegetables"] = 0;
                UpdatePiechart();


            }
            else if (butCategory.Contains("Fruit")) // clears all fruit
            {
                Clear_Food_Button(Button7);
                Clear_Food_Button(Button8);
                Clear_Food_Button(Button9);
                Session["Fruits"] = 0;
                UpdatePiechart();


            }
            else if (butCategory.Contains("Grain")) // clears all grain
            {
                Clear_Food_Button(Button4);
                Clear_Food_Button(Button6);
                Session["Grains"] = 0;
                UpdatePiechart();


            }
            else // clears all
            {
                Clear_Food_Button(Button2);
                Clear_Food_Button(Button3);
                Clear_Food_Button(Button4);
                Clear_Food_Button(Button5);
                Clear_Food_Button(Button6);
                Clear_Food_Button(Button7);
                Clear_Food_Button(Button8);
                Clear_Food_Button(Button9);
                Clear_Food_Button(Button10);
                Clear_Food_Button(Button11);

                Session["Vegetables"] = 0;
                Session["Fruits"] = 0;
                Session["Proteins"] = 0;
                Session["Grains"] = 0;

                string js = "document.getElementById('circle').style.backgroundImage = '';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ResetPieChart", js, true);
            }


            



            

            
            
        }
    }
}