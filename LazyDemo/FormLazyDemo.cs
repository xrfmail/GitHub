using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//V0.0.0.1  20150820    DX  create
//http://kb.cnblogs.com/page/99182/

namespace LazyDemo
{
    public partial class FormLazyDemo : Form
    {
        public class Apple
        {
            public static string GetString()
            {
                return DateTime.Now.ToLongTimeString();
            }
        }

        public class Blog
        {
            public int Id { get; private set; }
            public Lazy<List<Article>> Articles { get; private set; }
            public Blog(int id)
            {
                this.Id = id;
                Articles = new Lazy<List<Article>>(() => ArticleServices.GetArticesByBlogID(id));
                Console.WriteLine("BlogUser Initializer");
            }
        }
        public class Article
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public DateTime PublishDate { get; set; }
        }

        public class ArticleServices
        {
            public static List<Article> GetArticesByBlogID(int blogID)
            {
                List<Article> articles = new List<Article>
                {
            new Article{Id=1,Title="Lazy Load",PublishDate=DateTime.Parse("2011-4-20")},
            new Article{Id=2,Title="Delegate",PublishDate=DateTime.Parse("2011-4-21")},
            new Article{Id=3,Title="Event",PublishDate=DateTime.Parse("2011-4-22")},
            new Article{Id=4,Title="Thread",PublishDate=DateTime.Parse("2011-4-23")
            }
                };

                Console.WriteLine("Article Initalizer");
                return articles;
            }
        }


        public FormLazyDemo()
        {
            InitializeComponent();
        }

        private void btnLazyDemo1_Click(object sender, EventArgs e)
        {
            ///这行代码表明：要创建一个延迟加载的字符串对象s
            ///原型为Lazy<T> 对象名=new Lazy<T>(Fun<T>)
            ///采用泛型委托进行构造，实例化此委托时要求必须是返回值T类型的方法
            ///如在本例中，T为string，则TestLazy.GetString方法的返回值必须也是string类型
            Lazy<string> s = new Lazy<string>(Apple.GetString);
            Console.WriteLine(s.IsValueCreated);            //返回False
            Console.WriteLine(s.Value);                          //返回S的当前值
            Console.WriteLine(s.IsValueCreated);            //返回True 
        }

        private void btnLazyDemo2_Click(object sender, EventArgs e)
        {
            Blog blogUser = new Blog(1);
            Console.WriteLine("blogUser has been initialized");

            foreach (var article in blogUser.Articles.Value)
            {
                Console.WriteLine(article.Title);
            }
        }
    }
}
