using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application.Services.userservices;
using Autofac;
using Models;

namespace Presentation
{
    public partial class RegisterUser : Form
    {
        private readonly IUserService userService;
        public RegisterUser()
        {
            InitializeComponent();

            var container = Autofac.Inject();

            //MyProjectContext context = new MyProjectContext();
            //IBookRepository bookRepository = new BookRepository(context);
            //IBookServices bookService = new BookServices(bookRepository);

            userService = container.Resolve<IUserService>();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Text;
            var email = txtEmail.Text.Trim();
            var firstName = txtFirstName.Text.Trim();
            var lastName = txtLastName.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("❗اسم المستخدم وكلمة المرور مطلوبة");
                return;
            }

            var existingUser = await userService.GetByUsernameAsync(username);
            if (existingUser != null)
            {
                MessageBox.Show("❌ اسم المستخدم مستخدم بالفعل");
                return;
            }

            var newUser = new User
            {
                Username = username,
                PasswordHash = password, // يفضّل تعمل Hash هنا
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                DateCreated = DateTime.Now,
                Role = UserRole.Customer,
                IsActive = true
            };

            await userService.RegisterAsync(newUser);
            MessageBox.Show("✅ تم إنشاء الحساب بنجاح!");

            this.Close(); // رجع المستخدم للـ LogIn
        }
    }
    }
}
