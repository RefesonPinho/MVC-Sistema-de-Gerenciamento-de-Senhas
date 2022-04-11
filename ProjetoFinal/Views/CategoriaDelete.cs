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
    public class CategoriaDelete : BaseForm
    {
        public delegate void HandleButton(object sender, EventArgs e);

        private System.ComponentModel.IContainer components = null;
        Label lblDelete;
        Label lblId;
        TextBox textId;
        Button btnConfirm1;
        Button btnCancel1;

        public CategoriaDelete() : base("Deletar Categoria")
        {
            this.lblDelete = new Label();
            this.lblDelete.Text = "Dados Categoria:";
            this.lblDelete.Location = new Point(100, 50);

            this.lblId = new Label();
            this.lblId.Text = " Digite o Id que deseja Excluir ";
            this.lblId.Location = new Point(80, 100);
            this.lblId.Size = new Size(240,15);

            textId = new TextBox();
            textId.Location = new Point(10,125);
            textId.Size = new Size(360,20);

            this.btnConfirm1 = new Campos.ButtonForm(this.Controls, "Confirmar", 40,240, this.handleConfirmClick);
            this.btnCancel1 = new Campos.ButtonForm(this.Controls, "Cancelar", 150, 240, this.handleCancelClick);

            
            
            this.components = new System.ComponentModel.Container();

            this.Controls.Add(this.lblDelete);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.textId);
            this.Controls.Add(this.btnConfirm1);
            this.Controls.Add(this.btnCancel1);
            
               
        }
        private void handleConfirmClick(object sender, EventArgs e) {
                  
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
                
                CategoriaController.ExcluirCategoria(
                    Id
                );

                MessageBox.Show("Dados excluidos com sucesso.");
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