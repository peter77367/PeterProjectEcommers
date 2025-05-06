using Application.Services.userservices;
using System.Windows.Forms;
using Autofac;
using Context;
using Infrastructrure;
using Microsoft.EntityFrameworkCore;

namespace Presentation
{
    public partial class LogIn : Form
    {
        private readonly IUserService userService;
        public LogIn()
        {
            InitializeComponent();

            var container = Autofac.Inject();

            //MyProjectContext context = new MyProjectContext();
            //IBookRepository bookRepository = new BookRepository(context);
            //IBookServices bookService = new BookServices(bookRepository);

             userService = container.Resolve<IUserService>();

          
        }
    private async void button1_Click(object sender, EventArgs e)
        {
        

            var username = txtusername.Text;
            var password = txtuserpassword.Text;
           
            var user = await userService.LoginAsync(username, password);

            if (user != null)
            {
                MessageBox.Show($"welcomeeeeeeeeeee");
                // Open main form
                var home = new HomePage();
                home.Show();
                this.Hide();
            }
            else
            {
              var r = new RegisterUser();
                r.Show();
                this.Hide();
                // lblStatus.Text = "❌ اسم المستخدم أو كلمة السر غير صحيحة";
                // lblStatus.ForeColor = Color.Red;
                // lblStatus.Visible = true;
                // lblStatus.Text = "❌ اسم المستخدم أو كلمة السر غير صحيحة";
            }
        }
    }
}
