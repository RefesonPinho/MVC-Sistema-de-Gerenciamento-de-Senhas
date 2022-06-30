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
    public class UsuarioInsert : BaseForm
    {
        public delegate void HandleButton(object sender, EventArgs e);

        readonly Label lblInsert;
        readonly Label lblNome;
        readonly TextBox textNome;
        readonly Label lblEmail;
        readonly TextBox textEmail;
        readonly Label lblSenha;
        readonly TextBox textSenha;
        readonly Button btnConfirm1;
        readonly Button btnCancel1;

        public UsuarioInsert() : base("Inserir Usuario")
        {
            this.ClientSize = new System.Drawing.Size(400,400);
            this.lblInsert = new Label
            {
                Text = "Dados Usuario:",
                Location = new Point(100, 50)
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

            this.Controls.Add(this.lblInsert);
            this.Controls.Add(this.btnConfirm1);
            this.Controls.Add(this.btnCancel1);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.btnConfirm1);
            this.Controls.Add(this.btnCancel1);
            this.Controls.Add(this.textNome);
            this.Controls.Add(this.textSenha);
            this.Controls.Add(this.textEmail);
               
        }
        private void handleConfirmClick(object sender, EventArgs e) 
        {
                  
            try
            {
                DialogResult confirm = MessageBox.Show(
                    "Deseja realmente confirmar?",
                    "CONFIRMAR",
                    MessageBoxButtons.YesNo
                );

                if (confirm == DialogResult.Yes) {
                    UsuarioController.InserirUsuario(
                        textNome.Text,
                        textEmail.Text,
                        textSenha.Text
                        
                    );
                    MessageBox.Show("Dados inseridos com sucesso.");
                    Views.UsuarioMenu menu = new Views.UsuarioMenu();
                    this.Close();
                }


            }
            catch (System.Exception)
            {
                MessageBox.Show("Não foi possível inserir os dados.");
            }              
        }

        private void handleCancelClick(object sender, EventArgs e)
        {
            using (Views.MenuPrincipal menu = new Views.MenuPrincipal())
            {
            }
            this.Close();
        }  
    }       
}