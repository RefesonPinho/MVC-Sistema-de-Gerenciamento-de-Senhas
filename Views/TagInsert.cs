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

        Label lblInsert;
        Label lblDescricao;
        TextBox textDescricao;
        Button btnConfirm1;
        Button btnCancel1;

        public TagInsert() : base("Inserir Tag")
        {
            this.lblInsert = new Label();
            this.lblInsert.Text = "Dados Tag:";
            this.lblInsert.Location = new Point(100, 50);
            
            this.lblDescricao = new Label();
            this.lblDescricao.Text = " Descricao";
            this.lblDescricao.Location = new Point(120, 100);

            textDescricao = new TextBox();
            textDescricao.Location = new Point(10,125);
            textDescricao.Size = new Size(360,20);

            this.btnConfirm1 = new Campos.ButtonForm(this.Controls, "Confirmar", 40,240, this.handleConfirmClick);
            this.btnCancel1 = new Campos.ButtonForm(this.Controls, "Cancelar", 150, 240, this.handleCancelClick);

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
            Views.MenuPrincipal menu = new Views.MenuPrincipal();
            this.Close();
        }  
    }       
}