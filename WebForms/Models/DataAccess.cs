using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebForms.Models
{
    public class DataAccess
    {
        private const string SQL_CREATE = "INSERT dbo.BlogPosts VALUES (@Title, @Body, @PublishDate)";

        private const string SQL_UPDATE = @"UPDATE dbo.BlogPosts
                                            SET Title = @Title,
                                                Body = @Body,
                                                PublishDate = @PublishDate
                                            WHERE Id = @Id";
        
        private const string SQL_DELETE = "DELETE FROM dbo.BlogPosts WHERE Id = @Id";

        private const string SQL_FIND = "SELECT * FROM dbo.BlogPosts WHERE Id = @Id";
        
        private const string SQL_FIND_ALL = "SELECT * FROM dbo.BlogPosts ORDER BY PublishDate DESC";

        public void CreateBlogPost(BlogPost post)
        {
            using (SqlConnection connection = OpenConnection())
            {
                SqlCommand command = new SqlCommand(SQL_CREATE, connection);

                command.Parameters.AddWithValue("@Title", post.Title);
                command.Parameters.AddWithValue("@Body", post.Body);
                command.Parameters.AddWithValue("@PublishDate", post.PublishDate);

                // Execute the INSERT statement
                command.ExecuteNonQuery();
            }
        }

        public void UpdateBlogPost(BlogPost post)
        {
            using (SqlConnection connection = OpenConnection())
            {
                SqlCommand command = new SqlCommand(SQL_UPDATE, connection);

                command.Parameters.AddWithValue("@Title", post.Title);
                command.Parameters.AddWithValue("@Body", post.Body);
                command.Parameters.AddWithValue("@PublishDate", post.PublishDate);
                command.Parameters.AddWithValue("@Id", post.Id);

                // Execute the UPDATE statement
                command.ExecuteNonQuery();
            }
        }

        public void DeleteBlogPost(BlogPost post)
        {
            using (SqlConnection connection = OpenConnection())
            {
                SqlCommand command = new SqlCommand(SQL_DELETE, connection);

                command.Parameters.AddWithValue("@Id", post.Id);

                // Execute the UPDATE statement
                command.ExecuteNonQuery();
            }
        }

        public BlogPost FindBlogPost(int blogPostId)
        {
            using (SqlConnection connection = OpenConnection())
            {
                BlogPost post = null;
                SqlCommand command = new SqlCommand(SQL_FIND, connection);

                command.Parameters.AddWithValue("@Id", blogPostId);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    post = new BlogPost();
                    FillBlogPost(post, reader);
                }

                return post;
            }
        }

        private void FillBlogPost(BlogPost post, SqlDataReader reader)
        {
            post.Id = Convert.ToInt32(reader["Id"]);
            post.Body = reader["Body"].ToString();
            post.PublishDate = Convert.ToDateTime(reader["PublishDate"]);
            post.Title = reader["Title"].ToString();
        }

        public List<BlogPost> FindAllBlogPosts()
        {
            using (SqlConnection connection = OpenConnection())
            {
                List<BlogPost> posts = new List<BlogPost>();
                SqlCommand command = new SqlCommand(SQL_FIND_ALL, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    BlogPost post = new BlogPost();
                    FillBlogPost(post, reader);
                    posts.Add(post);
                }

                return posts;
            }
        }

        private string ConnectionString
        {
            get { return System.Configuration.ConfigurationManager.ConnectionStrings["Blog"].ConnectionString; }
        }

        private SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            connection.Open();

            return connection;
        }
    }
}