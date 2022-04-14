using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.IO;
using lib;


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

        Campos.Field fieldUser;
        Campos.Field fieldPass;

        Button btnConfirm;
        Button btnSair;

        public Login()
        {
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

        Label lblLogin;

        Button btnTag;
        Button btnCategoria;
        Button btnUsuario;
        Button btnSenha;
        Button btnSenhaTag;
        Button btnSair;

        
        public MenuPrincipal() 
        {
            this.lblLogin = new Label();
            this.lblLogin.Text = "Olá Fulano";
            this.lblLogin.Location = new Point(117, 20);

            this.btnTag = new Button();
            this.btnTag.Text = "Tag";
            this.btnTag.Location = new Point(40, 60);
            this.btnTag.Size = new Size(100, 30);
            this.btnTag.Click += new EventHandler(this.handleTagClick);

            this.btnCategoria = new Button();
            this.btnCategoria.Text = "Categoria";
            this.btnCategoria.Location = new Point(160, 60);
            this.btnCategoria.Size = new Size(100, 30);
            this.btnCategoria.Click += new EventHandler(this.handleCategoriaClick);

            this.btnUsuario = new Button();
            this.btnUsuario.Text = "Usuario";
            this.btnUsuario.Location = new Point(40, 100);
            this.btnUsuario.Size = new Size(100, 30);
            this.btnUsuario.Click += new EventHandler(this.handleUsuarioClick);

            this.btnSenha = new Button();
            this.btnSenha.Text = "Senha";
            this.btnSenha.Location = new Point(160, 100);
            this.btnSenha.Size = new Size(100, 30);
            this.btnSenha.Click += new EventHandler(this.handleSenhaClick);

            this.btnSenhaTag = new Button();
            this.btnSenhaTag.Text = "SenhaTag";
            this.btnSenhaTag.Location = new Point(40, 140);
            this.btnSenhaTag.Size = new Size(100, 30);
            this.btnSenhaTag.Click += new EventHandler(this.handleSenhaTagClick);


            this.btnSair = new Button();
            this.btnSair.Text = "Sair";
            this.btnSair.Location = new Point(110, 200);
            this.btnSair.Size = new Size(80, 30);
            this.btnSair.Click += new EventHandler(this.handleSairClick);

            this.Controls.Add(this.lblLogin);

            this.Controls.Add(this.btnTag);
            this.Controls.Add(this.btnCategoria);
            this.Controls.Add(this.btnUsuario);
            this.Controls.Add(this.btnSenha);
            this.Controls.Add(this.btnSenhaTag);
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
            this.Close();
        }
        private void handleSenhaClick(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();
            menu.ShowDialog();
            this.Close();
        }
        private void handleSenhaTagClick(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();
            menu.ShowDialog();
            this.Close();
        }
         
        private void handleSairClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
   
}
