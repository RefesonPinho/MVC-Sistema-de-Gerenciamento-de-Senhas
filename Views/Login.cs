using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.IO;
using Views;
using lib;
using Models;

namespace Views
{
    public delegate void HandleButton(object sender, EventArgs e);
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }

    public class Login : Form
    {
        readonly Campos.Field fieldUser;
        readonly Campos.Field fieldPass;
        readonly Button btnConfirm;
        readonly Button btnSair;

        public Login()

        {
            this.ClientSize = new System.Drawing.Size(300,300);
            this.fieldUser = new Campos.Field(this.Controls, "Usuário", 20, true);
            this.fieldPass = new Campos.Field(this.Controls, "Senha", 80, true, true);
            this.fieldPass.textField.ForeColor = System.Drawing.Color.Red;
            this.btnConfirm = new Campos.ButtonForm(this.Controls, "Confirmar", 100, 180, this.handleConfirmClick);
            this.btnSair = new Campos.ButtonForm(this.Controls, "Cancelar", 100, 220, this.handleCancelClick);
            
        }

        private void handleConfirmClick(object sender, EventArgs e) {
            DialogResult result;

            result = MessageBox.Show(
                $"Usuário: {this.fieldUser.textField.Text}" +
                $"\nSenha: {this.fieldPass.textField.Text}",
                "Titulo da Mensagem",
                MessageBoxButtons.YesNo
            );

            if (result == DialogResult.Yes)
            {
                MenuPrincipal menu = new MenuPrincipal();
                menu.ShowDialog();
                this.Close();
            }
            else
            {
                Console.WriteLine("Clicou não");
            }
        }
        
        private void handleCancelClick(object sender, EventArgs e) {
            this.Close();
        }

    }

    public class MenuPrincipal : Form
    {
        readonly Label lblLogin;
        readonly Button btnTag;
        readonly Button btnCategoria;
        readonly Button btnUsuario;
        readonly Button btnSenha;
        readonly Button btnSair;

        
        public MenuPrincipal() 
        {
            this.lblLogin = new Label
            {
                Text = $"Olá {Usuario.UsuarioAuth}",
                Location = new Point(117, 20)
            };

            this.btnTag = new Button
            {
                Text = "Tag",
                Location = new Point(40, 60),
                Size = new Size(100, 30)
            };
            this.btnTag.Click += new EventHandler(this.handleTagClick);

            this.btnCategoria = new Button
            {
                Text = "Categoria",
                Location = new Point(160, 60),
                Size = new Size(100, 30)
            };
            this.btnCategoria.Click += new EventHandler(this.handleCategoriaClick);

            this.btnUsuario = new Button
            {
                Text = "Usuario",
                Location = new Point(40, 130),
                Size = new Size(100, 30)
            };
            this.btnUsuario.Click += new EventHandler(this.handleUsuarioClick);

            this.btnSenha = new Button
            {
                Text = "Senha",
                Location = new Point(160, 130),
                Size = new Size(100, 30)
            };
            this.btnSenha.Click += new EventHandler(this.handleSenhaClick);


            this.btnSair = new Button
            {
                Text = "Sair",
                Location = new Point(110, 200),
                Size = new Size(80, 30)
            };
            this.btnSair.Click += new EventHandler(this.handleSairClick);

            this.Controls.Add(this.lblLogin);

            this.Controls.Add(this.btnTag);
            this.Controls.Add(this.btnCategoria);
            this.Controls.Add(this.btnUsuario);
            this.Controls.Add(this.btnSenha);
            this.Controls.Add(this.btnSair);

        }
        private void handleCategoriaClick(object sender, EventArgs e)
        {
            Views.CategoriaMenu menu = new Views.CategoriaMenu();
            menu.ShowDialog();
        }
        private void handleTagClick(object sender, EventArgs e)
        {
            Views.TagMenu menu = new Views.TagMenu();
            menu.ShowDialog();
        }
        private void handleUsuarioClick(object sender, EventArgs e)
        {
            UsuarioMenu menu = new UsuarioMenu();
            menu.ShowDialog();
            
        }
        private void handleSenhaClick(object sender, EventArgs e)
        {
            SenhaMenu menu = new SenhaMenu();
            menu.ShowDialog();
            
        }
               
        private void handleSairClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
   
}
