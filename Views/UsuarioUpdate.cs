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

        Label lblUpdate;
        Label lblId;
        Label lblNome;
        Label lblEmail;
        Label lblSenha;

        TextBox textNome;
        TextBox textEmail;
        TextBox textId;
        TextBox textSenha;
        
        Button btnConfirm1;
        Button btnCancel1;

        public UsuarioUpdate() : base("Alterar Usuarios")
        {


            this.lblId = new Label();
            this.lblId.Text = " Digite o Id  ";
            this.lblId.Location = new Point(120, 50);
            this.lblId.Size = new Size(240,15);

            textId = new TextBox();
            textId.Location = new Point(10,75);
            textId.Size = new Size(360,20);

            this.lblNome = new Label();
            this.lblNome.Text = " Digite o Nome ";
            this.lblNome.Location = new Point(120, 100);
            this.lblNome.Size = new Size(240,15);

            textNome = new TextBox();
            textNome.Location = new Point(10,125);
            textNome.Size = new Size(360,20);
            
            this.lblEmail = new Label();
            this.lblEmail.Text = " Email";
            this.lblEmail.Location = new Point(120, 150);

            textEmail = new TextBox();
            textEmail.Location = new Point(10,175);
            textEmail.Size = new Size(360,20);

            this.lblSenha = new Label();
            this.lblSenha.Text = " Senha";
            this.lblSenha.Location = new Point(120, 200);

            textSenha = new TextBox();
            textSenha.Location = new Point(10,225);
            textSenha.Size = new Size(360,20);

            this.btnConfirm1 = new Campos.ButtonForm(this.Controls, "Confirmar", 40,260, this.handleConfirmClick);
            this.btnCancel1 = new Campos.ButtonForm(this.Controls, "Cancelar", 150, 260, this.handleCancelClick);



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