using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodnStuff.View.Recipe_Searcher
{
    public partial class RecipeControl : System.Web.UI.UserControl
    {
        public ImageButton image
        {
            get { return ImageButton1; }            
        }
        public HyperLink textlink
        {
            get { return HyperLink1; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}