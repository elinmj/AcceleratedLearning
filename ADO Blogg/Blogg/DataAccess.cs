using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Blogg.Domain;

namespace Blogg
{
    class DataAccess
    {
        private string conString = "Server=(localdb)\\MSSQLLocalDB; Database=Blogg";

        internal List<Blogpost> GetAllBlogPostsBrief()
        {
            var sql = @"SELECT BlogPostId, Author, Title
                        FROM BlogPost";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                var list = new List<Blogpost>();

                while (reader.Read())
                {
                    var bp = new Blogpost
                    {
                        Id = reader.GetSqlInt32(0).Value,
                        Author = reader.GetSqlString(1).Value,
                        Title = reader.GetSqlString(2).Value,
                        //Created = reader.GetDateTime(3).Date
                    };

                    list.Add(bp);
                }

                return list;
            }

        }

        internal void UpdateBlogpost(Blogpost blogpost)
        {
            string sql = $@"UPDATE BlogPost
                        SET Title = @Title
                        WHERE BlogPostId = @Id";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("Title", blogpost.Title));
                command.Parameters.Add(new SqlParameter("Id", blogpost.Id));
                command.ExecuteNonQuery();
            }

        }

        internal Blogpost GetPostById(int id)
        {
            var sql = $@"SELECT Id, Author, Title
                        FROM Blogg
                        WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {

                connection.Open();
                command.Parameters.Add(new SqlParameter("Id", id));

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                    return new Blogpost
                    {
                        Id = reader.GetSqlInt32(0).Value,
                        Author = reader.GetSqlString(1).Value,
                        Title = reader.GetSqlString(2).Value,
                        //Created = reader.GetSqlDateTime(3).Value
                    };
                else
                    return null;

            }
        }

        internal void DeleteBlogPost(Blogpost blogpost)
        {
            var sql = @"DELETE FROM BlogPostTag
                        WHERE BlogPostId=@Id
                        DELETE FROM Comment 
                        WHERE BlogPostId=@Id
                        DELETE FROM BlogPost 
                        WHERE BlogPostId=@Id";


            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {

                connection.Open();
                command.Parameters.Add(new SqlParameter("Id", blogpost.Id));
                command.ExecuteNonQuery();
            }
        }

        internal void AddBlogPost(Blogpost blogpost)
        {
            string sql = $@"INSERT INTO BlogPost (Author, Title, Created) 
                         VALUES (@Author, @Title, @Created)";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                //command.Parameters.Add(new SqlParameter("Id", blogpost.Id));
                command.Parameters.Add(new SqlParameter("Author", blogpost.Author));
                command.Parameters.Add(new SqlParameter("Title", blogpost.Title));
                command.Parameters.Add(new SqlParameter("Created", blogpost.Created));
                command.ExecuteNonQuery();
            }
        }

        internal List<Blogpost> GetAllTags()
        {
            var sql = @"SELECT Tag
                        FROM Tag";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                var list = new List<Blogpost>();

                while (reader.Read())
                {
                    var bp = new Blogpost
                    {
                        Tag = reader.GetSqlString(0).Value
                    };

                    list.Add(bp);
                }

                return list;
            }
        }

        internal bool DoesTagPostCombinationExist(Blogpost blogpost)
        {
            string sql = $@"SELECT Tag, BlogPostId
                         FROM BlogPostTag
                         WHERE Tag=@Tag AND BlogPostId=@Id";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("Tag", blogpost.Tag));
                command.Parameters.Add(new SqlParameter("Id", blogpost.Id));

                SqlDataReader reader = command.ExecuteReader();
                bool doesTagPostCombinationExist = reader.Read();
                return doesTagPostCombinationExist;
            }
        }

        internal void DeleteTag(Blogpost blogpost)
        {
            var sql = @"DELETE FROM Tag
                        WHERE Tag=@Tag";


            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {

                connection.Open();
                command.Parameters.Add(new SqlParameter("Tag", blogpost.Tag));
                command.ExecuteNonQuery();
            }
        }



        internal bool DoesTagExist(Blogpost blogpost)
        {
            string sql = $@"SELECT Tag
                         FROM Tag
                         WHERE Tag=@Tag";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("Tag", blogpost.Tag));
                SqlDataReader reader = command.ExecuteReader();
                bool doesTagExist = reader.Read();
                return doesTagExist;
            }
        }
         
        internal void AddTag(Blogpost blogpost)
        {
            string sql = $@"INSERT INTO Tag (Tag) 
                         VALUES (@Tag)";
                        
            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("Tag", blogpost.Tag));
                command.ExecuteNonQuery();
            }
        }

        internal void AddTagToBlogPost(Blogpost blogpost)
        {
            string sql = $@"INSERT INTO BlogPostTag (BlogPostId, Tag)
                         VALUES (@Id, @Tag)";
                         

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("Id", blogpost.Id));
                command.Parameters.Add(new SqlParameter("Tag", blogpost.Tag));
                command.ExecuteNonQuery();
            }
        }

        internal List<Blogpost> ShowComments(Blogpost blogpost)
        {
            var sql = @"SELECT Comment
                        FROM Comment
                        WHERE BlogPostId=@Id";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {

                connection.Open();
                command.Parameters.Add(new SqlParameter("Id", blogpost.Id));


                SqlDataReader reader = command.ExecuteReader();

                var list = new List<Blogpost>();

                while (reader.Read())
                {
                    var bp = new Blogpost
                    {
                        Comment = reader.GetSqlString(0).Value
                    };

                    list.Add(bp);
                }

                return list;
            }
        }
        

        internal void AddComment(Blogpost blogpost)
        {
            string sql = $@"INSERT INTO Comment (BlogPostId, Comment)
                         VALUES (@Id, @Comment)";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("Comment", blogpost.Comment));
                command.Parameters.Add(new SqlParameter("Id", blogpost.Id));
                command.ExecuteNonQuery();
            }
        }
    }

}
