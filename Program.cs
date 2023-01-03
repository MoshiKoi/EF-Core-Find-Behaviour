int id;

Console.WriteLine("Setting up database:");
using (var db = new BloggingContext())
{
    Console.WriteLine($" - Database path: {db.DbPath}.");
    Console.WriteLine(" - Adding blog: http://blogs.msdn.com/adonet");
    var blog = new Blog { Url = "http://blogs.msdn.com/adonet" };
    db.Add(blog);
    db.SaveChanges();
    id = blog.BlogId;
}

Console.WriteLine($"Blog Id: {id}");

Console.WriteLine("Adding post");
using (var db = new BloggingContext())
{
    var blog = db.Blogs.Find(id);
    blog.Posts.Add(new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
    db.SaveChanges();
    Console.WriteLine($" - Number of Posts: {blog.Posts.Count()}");
}

Console.WriteLine($"Test: Finding blog with id: {id}");

using (var db = new BloggingContext())
{
    var blog = db.Blogs.Find(id);
    Console.WriteLine($" - Found blog: {blog.Url}");
    Console.WriteLine($" - Number of Posts: {blog.Posts.Count()}");
}

Console.WriteLine("Delete the blog");
using (var db = new BloggingContext())
{
    var blog = db.Blogs.Find(id);
    db.Remove(blog);
    db.SaveChanges();
}