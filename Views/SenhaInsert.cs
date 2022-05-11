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
    public class SenhaInsert : BaseForm
    {
        public delegate void HandleButton(object sender, EventArgs e);

        Label lblInsert;
        Label lblNome;
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

        public SenhaInsert() : base("Inserir Senha")
        {
            this.lblInsert = new Label();
            this.lblInsert.Text = "Dados Senha:";
            this.lblInsert.Location = new Point(100, 50);

            this.lblNome = new Label();
            this.lblNome.Text = " Digite o Nome ";
            this.lblNome.Location = new Point(120, 100);
            this.lblNome.Size = new Size(240,15);

            textNome = new TextBox();
            textNome.Location = new Point(10,125);
            textNome.Size = new Size(360,20);
            
            this.lblCategoria = new Label();
            this.lblCategoria.Text = " Categoria";
            this.lblCategoria.Location = new Point(120, 150);

            textCategoria = new TextBox();
            textCategoria.Location = new Point(10,175);
            textCategoria.Size = new Size(360,20);

            this.lblUrl = new Label();
            this.lblUrl.Text = " Url";
            this.lblUrl.Location = new Point(120, 200);

            textUrl = new TextBox();
            textUrl.Location = new Point(10,225);
            textUrl.Size = new Size(360,20);

            this.lblUsuario = new Label();
            this.lblUsuario.Text = " Usuario";
            this.lblUsuario.Location = new Point(120, 250);

            textUsuario = new TextBox();
            textUsuario.Location = new Point(10,275);
            textUsuario.Size = new Size(360,20);

            this.lblSenha = new Label();
            this.lblSenha.Text = " Senha";
            this.lblSenha.Location = new Point(120, 300);

            textSenha = new TextBox();
            textSenha.Location = new Point(10,325);
            textSenha.Size = new Size(360,20);

            this.lblProcedimento = new Label();
            this.lblProcedimento.Text = " Procedimento";
            this.lblProcedimento.Location = new Point(120, 350);

            TextProcedimento = new TextBox();
            TextProcedimento.Location = new Point(10,375);
            TextProcedimento.ClientSize = new Size(360, 450);
            

            this.btnConfirm1 = new Campos.ButtonForm(this.Controls, "Confirmar", 40,420, this.handleConfirmClick);
            this.btnCancel1 = new Campos.ButtonForm(this.Controls, "Cancelar", 150, 420, this.handleCancelClick);

            this.Controls.Add(this.lblInsert);
            this.Controls.Add(this.btnConfirm1);
            this.Controls.Add(this.btnCancel1);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.lblProcedimento);
            this.Controls.Add(this.textNome);
            this.Controls.Add(this.textCategoria);
            this.Controls.Add(this.textUrl);
            this.Controls.Add(this.textUsuario);
            this.Controls.Add(this.textSenha);
            this.Controls.Add(this.TextProcedimento);
               
        }
        private void handleConfirmClick(object sender, EventArgs e) 
        {
            int CategoriaId = int.Parse(textCategoria.Text);     
            try
            {
                DialogResult confirm = MessageBox.Show(
                    "Deseja realmente confirmar?",
                    "CONFIRMAR",
                    MessageBoxButtons.YesNo
                );

                if (confirm == DialogResult.Yes) {
                    SenhaController.InserirSenha(
                        textNome.Text,
                        CategoriaId,
                        textUrl.Text,
                        textUsuario.Text,
                        textSenha.Text,
                        TextProcedimento.Text
                        
                    );
                    MessageBox.Show("Dados inseridos com sucesso.");
                    Views.SenhaMenu menu = new Views.SenhaMenu();
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
            Views.MenuPrincipal menu = new Views.MenuPrincipal();
            this.Close();
        }  
    }       
}