using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms.Models;

namespace WebForms
{
    public partial class _Default : Page
    {
        private DataAccess dbAccess = new DataAccess();

        protected IEnumerable BlogPosts { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            BlogPosts = dbAccess.FindAllBlogPosts();
            DataBind();
        }
    }
}