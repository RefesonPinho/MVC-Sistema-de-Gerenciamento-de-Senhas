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
    public class SenhaUpdate : BaseForm
    {
        public delegate void HandleButton(object sender, EventArgs e);

        Label lblUpdate;
        Label lblNome;
        Label lblId;
        TextBox textId;
        TextBox textNome;
        Label lblCategoria;
        TextBox textCategoria;
        Label lblUrl;
        TextBox textUrl;
        Label lblUsuario;
        TextBox textUsuario;
        Label lblSenha;
        TextBox textSenha;
        Label lblProcedimento;
        TextBox TextProcedimento;
        Button btnConfirm1;
        Button btnCancel1;

        public SenhaUpdate() : base("Alterar Usuarios")
        {

            this.lblUpdate = new Label();
            this.lblUpdate.Text = "Dados Senha:";
            this.lblUpdate.Location = new Point(100, 50);
            
            this.lblId = new Label();
            this.lblId.Text = " Digite o Id  ";
            this.lblId.Location = new Point(120, 75);
            this.lblId.Size = new Size(240,15);

            textId = new TextBox();
            textId.Location = new Point(10,100);
            textId.Size = new Size(360,20);

            this.lblNome = new Label();
            this.lblNome.Text = " Digite o Nome ";
            this.lblNome.Location = new Point(120, 125);
            this.lblNome.Size = new Size(240,15);

            textNome = new TextBox();
            textNome.Location = new Point(10,150);
            textNome.Size = new Size(360,20);
            
            this.lblCategoria = new Label();
            this.lblCategoria.Text = " Categoria";
            this.lblCategoria.Location = new Point(120, 175);

            textCategoria = new TextBox();
            textCategoria.Location = new Point(10,200);
            textCategoria.Size = new Size(360,20);

            this.lblUrl = new Label();
            this.lblUrl.Text = " Url";
            this.lblUrl.Location = new Point(120, 225);

            textUrl = new TextBox();
            textUrl.Location = new Point(10,250);
            textUrl.Size = new Size(360,20);

            this.lblUsuario = new Label();
            this.lblUsuario.Text = " Usuario";
            this.lblUsuario.Location = new Point(120, 275);

            textUsuario = new TextBox();
            textUsuario.Location = new Point(10,300);
            textUsuario.Size = new Size(360,20);

            this.lblSenha = new Label();
            this.lblSenha.Text = " Senha";
            this.lblSenha.Location = new Point(120, 325);

            textSenha = new TextBox();
            textSenha.Location = new Point(10,350);
            textSenha.Size = new Size(360,20);

            this.lblProcedimento = new Label();
            this.lblProcedimento.Text = " Procedimento";
            this.lblProcedimento.Location = new Point(120, 375);

            TextProcedimento = new TextBox();
            TextProcedimento.Location = new Point(10,400);
            TextProcedimento.ClientSize = new Size(360,20);

            this.btnConfirm1 = new Campos.ButtonForm(this.Controls, "Confirmar", 40,460, this.handleConfirmClick);
            this.btnCancel1 = new Campos.ButtonForm(this.Controls, "Cancelar", 150, 460, this.handleCancelClick);



            this.Controls.Add(this.lblUpdate);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblProcedimento);
            this.Controls.Add(this.textId);
            this.Controls.Add(this.textNome);
            this.Controls.Add(this.textCategoria);
            this.Controls.Add(this.textSenha);
            this.Controls.Add(this.textUrl);
            this.Controls.Add(this.textUsuario);
            this.Controls.Add(this.TextProcedimento);
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

                 int CategoriaId;
                try
                {
                   CategoriaId = int.Parse(textCategoria.Text); 
                }
                catch
                {
                    throw new Exception("ID inválido.");
                }
                
                SenhaController.AlterarSenha(
                    Id,
                    textNome.Text,
                    CategoriaId,
                    textUrl.Text,
                    textUsuario.Text,
                    textSenha.Text,
                    TextProcedimento.Text
                );

                MessageBox.Show("Dados alterados com sucesso.");
                Views.SenhaMenu menu = new Views.SenhaMenu();
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