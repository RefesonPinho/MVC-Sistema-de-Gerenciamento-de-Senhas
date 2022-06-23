using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.IO;
using Models;
using Controllers;
using static lib.Campos;
using lib;


namespace Views
{
    public class UsuarioUpdate : BaseForm
    {
        public delegate void HandleButton(object sender, EventArgs e);

        readonly Label lblUpdate;
        readonly Label lblId;
        readonly Label lblNome;
        readonly Label lblEmail;
        readonly Label lblSenha;
        readonly TextBox textNome;
        readonly TextBox textEmail;
        readonly TextBox textId;
        readonly TextBox textSenha;
        readonly Button btnConfirm1;
        readonly Button btnCancel1;

        public UsuarioUpdate() : base("Alterar Usuarios")
        {
            this.ClientSize = new System.Drawing.Size(400,400);
            this.lblId = new Label
            {
                Text = " Digite o Id  ",
                Location = new Point(120, 50),
                Size = new Size(240, 15)
            };

            textId = new TextBox
            {
                Location = new Point(10, 75),
                Size = new Size(360, 20)
            };

            this.lblNome = new Label
            {
                Text = " Digite o Nome ",
                Location = new Point(120, 100),
                Size = new Size(240, 15)
            };

            textNome = new TextBox
            {
                Location = new Point(10, 125),
                Size = new Size(360, 20)
            };

            this.lblEmail = new Label
            {
                Text = " Email",
                Location = new Point(120, 150)
            };

            textEmail = new TextBox
            {
                Location = new Point(10, 175),
                Size = new Size(360, 20)
            };

            this.lblSenha = new Label
            {
                Text = " Senha",
                Location = new Point(120, 200)
            };

            textSenha = new TextBox
            {
                Location = new Point(10, 225),
                Size = new Size(360, 20)
            };

            this.btnConfirm1 = new Campos.ButtonForm(this.Controls, "Confirmar", 80,300, this.handleConfirmClick);
            this.btnCancel1 = new Campos.ButtonForm(this.Controls, "Cancelar", 190, 300, this.handleCancelClick);



            this.Controls.Add(this.lblUpdate);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.textId);
            this.Controls.Add(this.textNome);
            this.Controls.Add(this.textEmail);
            this.Controls.Add(this.textSenha);
            this.Controls.Add(this.btnConfirm1);
            this.Controls.Add(this.btnCancel1);
            
               
        }
        private void handleConfirmClick(object sender, EventArgs e) 
        {       
            try
            {
                int Id;
                try
                {
                    Id = int.Parse(textId.Text); 
                }
                catch
                {
                    throw new Exception("ID inválido.");
                }
                
                UsuarioController.AlterarUsuario(
                    Id,
                    textNome.Text,
                    textEmail.Text,
                    textSenha.Text
                );

                MessageBox.Show("Dados alterados com sucesso.");
                Views.UsuarioMenu menu = new Views.UsuarioMenu();
                this.Close();

            }
            catch (System.Exception err)
            {
                MessageBox.Show($"Não foi possível inserir os dados. {err.Message}");
            }              
        }
        
        private void handleCancelClick(object sender, EventArgs e)
        {
            Views.MenuPrincipal menu = new Views.MenuPrincipal();
            this.Close();
        }  
    }       
}