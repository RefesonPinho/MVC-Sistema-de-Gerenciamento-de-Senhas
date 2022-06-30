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
    public class TagInsert : BaseForm
    {
        public delegate void HandleButton(object sender, EventArgs e);

        readonly Label lblInsert;
        readonly Label lblDescricao;
        readonly TextBox textDescricao;
        readonly Button btnConfirm1;
        readonly Button btnCancel1;

        public TagInsert() : base("Inserir Tag")
        {
            this.ClientSize = new System.Drawing.Size(400,300);
            this.lblInsert = new Label
            {
                Text = "Dados Tag:",
                Location = new Point(120, 50)
            };

            this.lblDescricao = new Label
            {
                Text = " Descricao",
                Location = new Point(120, 100)
            };

            textDescricao = new TextBox
            {
                Location = new Point(10, 125),
                Size = new Size(360, 20)
            };

            this.btnConfirm1 = new Campos.ButtonForm(this.Controls, "Confirmar", 80,200, this.handleConfirmClick);
            this.btnCancel1 = new Campos.ButtonForm(this.Controls, "Cancelar", 190, 200, this.handleCancelClick);

            this.Controls.Add(this.lblInsert);
            this.Controls.Add(this.btnConfirm1);
            this.Controls.Add(this.btnCancel1);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.btnConfirm1);
            this.Controls.Add(this.btnCancel1);
            this.Controls.Add(this.textDescricao);
               
        }
        private void handleConfirmClick(object sender, EventArgs e) 
        {
                  
            try
            {
                TagController.InserirTag(
                    textDescricao.Text
                );

                MessageBox.Show("Dados inseridos com sucesso.");
                Views.TagMenu menu = new Views.TagMenu();
                this.Close();

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