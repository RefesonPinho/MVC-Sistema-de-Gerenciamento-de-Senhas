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
    public class CategoriaUpdate : BaseForm
    {
        public delegate void HandleButton(object sender, EventArgs e);

        readonly Label lblUpdate;
        readonly Label lblId;
        readonly Label lblNome;
        readonly Label lblDescricao;
        readonly TextBox textNome;
        readonly TextBox textDescricao;
        readonly TextBox textId;
        readonly Button btnConfirm1;
        readonly Button btnCancel1;

        public CategoriaUpdate() : base("Alterar Tags")
        {
            this.ClientSize = new System.Drawing.Size(400,400);
            this.lblUpdate = new Label
            {
                Text = "Dados Tag:",
                Location = new Point(100, 50)
            };

            this.lblId = new Label
            {
                Text = " Digite o Id que deseja alterar ",
                Location = new Point(80, 100),
                Size = new Size(240, 20)
            };

            textId = new TextBox
            {
                Location = new Point(10, 125),
                Size = new Size(360, 20)
            };

            this.lblNome = new Label
            {
                Text = " Nome",
                Location = new Point(120, 150)
            };

            textNome = new TextBox
            {
                Location = new Point(10, 175),
                Size = new Size(360, 20)
            };

            this.lblDescricao = new Label
            {
                Text = " Descricao",
                Location = new Point(120, 200)
            };

            textDescricao = new TextBox
            {
                Location = new Point(10, 225),
                Size = new Size(360, 20)
            };

            this.btnConfirm1 = new Campos.ButtonForm(this.Controls, "Confirmar", 80,300, this.handleConfirmClick);
            this.btnCancel1 = new Campos.ButtonForm(this.Controls, "Cancelar", 190, 300, this.handleCancelClick);

            

            this.Controls.Add(this.lblUpdate);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.lblId);
             this.Controls.Add(this.lblNome);
            this.Controls.Add(this.textId);
            this.Controls.Add(this.textNome);
            this.Controls.Add(this.textDescricao);
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
                
                CategoriaController.AlterarCategoria(
                    Id,
                    textNome.Text,
                    textDescricao.Text
                );

                MessageBox.Show("Dados alterados com sucesso.");
                Views.CategoriaMenu menu = new Views.CategoriaMenu();
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