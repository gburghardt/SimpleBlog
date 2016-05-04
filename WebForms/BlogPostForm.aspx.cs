using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms.Models;

namespace WebForms
{
    public partial class BlogPostForm : System.Web.UI.Page
    {
        private DataAccess dbAccess = new DataAccess();

        protected BlogPost Post { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                // Process the form
                int id = Convert.ToInt32(hfId.Value);
                BlogPost post = null;

                if (id > 0)
                {
                    // Update the blog post
                    post = dbAccess.FindBlogPost(id);
                }
                else
                {
                    // Create a new blog post
                    post = new BlogPost();
                }

                post.Title = txtTitle.Text;
                post.Body = txtBody.Text;
                post.PublishDate = DateTime.Parse(txtPublishDate.Text);

                if (id > 0)
                {
                    dbAccess.UpdateBlogPost(post);
                }
                else
                {
                    dbAccess.CreateBlogPost(post);
                }

                Response.Redirect("~/Default.aspx");
            }
            else
            {
                // Display the form

                if (string.IsNullOrEmpty(Request.Params["id"]))
                {
                    Post = new BlogPost();
                    Post.PublishDate = DateTime.Now;
                }
                else
                {
                    Post = dbAccess.FindBlogPost(Convert.ToInt32(Request.Params["id"]));
                }

                DataBind();
            }
        }
    }
}