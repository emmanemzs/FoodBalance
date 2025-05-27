using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Proj1
{
    public partial class Lunch : System.Web.UI.Page
    {
        private void IncrementCategory(string category)
        {
            int currentCount = (int)(Session[category] ?? 0);
            currentCount++;
            Session[category] = currentCount;
            UpdatePiechart();
        }
        private void UpdateLabels()
        {
            LabelVeg.Text = "Vegetables: " + Session["Vegetables"];
            LabelFruit.Text = "Fruits: " + Session["Fruits"];
            LabelProtein.Text = "Proteins: " + Session["Proteins"];
            LabelGrain.Text = "Grains: " + Session["Grains"];


            //circle.Attributes.CssStyle.Add("background-image", "conic-gradient(blue, red)");


        }
        private void UpdatePiechart()
        {
            int Veg = (int)(Session["Vegetables"] ?? 0);
            int Fruit = (int)(Session["Fruits"] ?? 0);
            int Protein = (int)(Session["Proteins"] ?? 0);
            int Grain = (int)(Session["Grains"] ?? 0);

            int ratio = 360 / (Veg + Fruit + Protein + Grain);
            Veg = Veg * ratio;
            Fruit = Fruit * ratio + Veg;
            Protein = Protein * ratio + Fruit;
            Grain = Grain * ratio + Protein;

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
            string buttonText = button.Text;
            int positionSp = buttonText.LastIndexOf(' ');

            string oldNum = buttonText.Substring(positionSp + 1);

            button.Text = buttonText.Replace(oldNum, "0");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
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
            Response.Redirect("~/Landing.aspx");
        }

        protected void Add_Food(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string cssName = clickedButton.CssClass;

            if (cssName.EndsWith("V"))
            {
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

            string buttonText = clickedButton.Text;
            int positionSp = buttonText.LastIndexOf(' ');

            string oldNum = buttonText.Substring(positionSp + 1);
            int newNum = Convert.ToInt32(oldNum) + 1;

            clickedButton.Text = buttonText.Replace(oldNum, Convert.ToString(newNum));



            UpdateLabels();

        }

        protected void Button12_Click(object sender, EventArgs e)
        {

            Button clickedButton = (Button)sender;
            string butCategory = clickedButton.Text;

            string category = "All";

            if (butCategory.Contains("Protien"))
            {
                Clear_Food_Button(Button2);
                Clear_Food_Button(Button3);
                Clear_Food_Button(Button5);
                Session["Proteins"] = 0;
                UpdatePiechart();


            }
            else if (butCategory.Contains("Vegetable"))
            {
                Clear_Food_Button(Button10);
                Clear_Food_Button(Button11);
                Session["Vegetables"] = 0;
                UpdatePiechart();


            }
            else if (butCategory.Contains("Fruit"))
            {
                Clear_Food_Button(Button7);
                Clear_Food_Button(Button8);
                Clear_Food_Button(Button9);
                Session["Fruits"] = 0;
                UpdatePiechart();


            }
            else if (butCategory.Contains("Grain"))
            {
                Clear_Food_Button(Button4);
                Clear_Food_Button(Button6);
                Session["Grains"] = 0;
                UpdatePiechart();


            }
            else
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