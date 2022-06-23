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

        readonly Label lblInsert;
        readonly Label lblNome;
        readonly TextBox textNome;
        readonly Label lblDescricao;
        readonly TextBox textDescricao;
        readonly Button btnConfirm1;
        readonly Button btnCancel1;

        public CategoriaInsert() : base("Inserir Categoria")
        {
            this.ClientSize = new System.Drawing.Size(400,300);
            this.lblInsert = new Label
            {
                Text = "Dados Categoria:",
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

            this.lblDescricao = new Label
            {
                Text = " Descricao",
                Location = new Point(120, 150)
            };

            textDescricao = new TextBox
            {
                Location = new Point(10, 175),
                Size = new Size(360, 20)
            };

            this.btnConfirm1 = new Campos.ButtonForm(this.Controls, "Confirmar", 80,240, this.handleConfirmClick);
            this.btnCancel1 = new Campos.ButtonForm(this.Controls, "Cancelar", 190, 240, this.handleCancelClick);

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