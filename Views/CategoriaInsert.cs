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
    public class CategoriaInsert : BaseForm
    {
        public delegate void HandleButton(object sender, EventArgs e);

        Label lblInsert;
        Label lblNome;
        TextBox textNome;
        Label lblDescricao;
        TextBox textDescricao;
        Button btnConfirm1;
        Button btnCancel1;

        public CategoriaInsert() : base("Inserir Categoria")
        {
            this.lblInsert = new Label();
            this.lblInsert.Text = "Dados Categoria:";
            this.lblInsert.Location = new Point(100, 50);

            this.lblNome = new Label();
            this.lblNome.Text = " Digite o Nome ";
            this.lblNome.Location = new Point(120, 100);
            this.lblNome.Size = new Size(240,15);

            textNome = new TextBox();
            textNome.Location = new Point(10,125);
            textNome.Size = new Size(360,20);
            
            this.lblDescricao = new Label();
            this.lblDescricao.Text = " Descricao";
            this.lblDescricao.Location = new Point(120, 150);

            textDescricao = new TextBox();
            textDescricao.Location = new Point(10,175);
            textDescricao.Size = new Size(360,20);

            this.btnConfirm1 = new Campos.ButtonForm(this.Controls, "Confirmar", 40,240, this.handleConfirmClick);
            this.btnCancel1 = new Campos.ButtonForm(this.Controls, "Cancelar", 150, 240, this.handleCancelClick);

            this.Controls.Add(this.lblInsert);
            this.Controls.Add(this.btnConfirm1);
            this.Controls.Add(this.btnCancel1);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.btnConfirm1);
            this.Controls.Add(this.btnCancel1);
            this.Controls.Add(this.textNome);
            this.Controls.Add(this.textDescricao);
               
        }
        private void handleConfirmClick(object sender, EventArgs e) 
        {
                  
            try
            {
                CategoriaController.InserirCategoria(
                    textNome.Text,
                    textDescricao.Text
                );

                MessageBox.Show("Dados inseridos com sucesso.");
                Views.CategoriaMenu menu = new Views.CategoriaMenu();
                this.Close();

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