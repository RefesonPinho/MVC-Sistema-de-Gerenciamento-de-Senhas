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
                Text = $"Olá {Usuario.UsuarioAuth.Nome}",
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

        public MenuPrincipal(Label lblLogin, Button btnTag, Button btnCategoria, Button btnUsuario, Button btnSenha, Button btnSair)
        {
            this.lblLogin = lblLogin;
            this.btnTag = btnTag;
            this.btnCategoria = btnCategoria;
            this.btnUsuario = btnUsuario;
            this.btnSenha = btnSenha;
            this.btnSair = btnSair;
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