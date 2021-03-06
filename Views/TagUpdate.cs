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
    public class TagUpdate : BaseForm
    {
        public delegate void HandleButton(object sender, EventArgs e);

        readonly Label lblUpdate;
        readonly Label lblId;
        readonly Label lblDescricao;
        readonly TextBox textDescricao;
        readonly TextBox textId;
        readonly Button btnConfirm1;
        readonly Button btnCancel1;

        public TagUpdate() : base("Alterar Tags")
        {
            this.ClientSize = new System.Drawing.Size(400,300);
            lblUpdate = new Label
            {
                Text = "Dados Tag:",
                Location = new Point(100, 50)
            };

            lblId = new Label
            {
                Text = " Digite o Id deseja alterar ",
                Location = new Point(80, 100),
                Size = new Size(240, 15)
            };

            textId = new TextBox
            {
                Location = new Point(10, 125),
                Size = new Size(360, 20)
            };

            lblDescricao = new Label
            {
                Text = " Descricao",
                Location = new Point(80, 150),
                Size = new Size(240, 15)
            };

            textDescricao = new TextBox
            {
                Location = new Point(10, 175),
                Size = new Size(360, 20)
            };

            this.btnConfirm1 = new Campos.ButtonForm(this.Controls, "Confirmar", 80,240, this.handleConfirmClick);
            this.btnCancel1 = new Campos.ButtonForm(this.Controls, "Cancelar", 190, 240, this.handleCancelClick);

            this.Controls.Add(this.lblUpdate);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.textId);
            this.Controls.Add(this.textDescricao);
            this.Controls.Add(this.btnConfirm1);
            this.Controls.Add(this.btnCancel1);
            
               
        }
        private void handleConfirmClick(object sender, EventArgs e) 
        {     
            try
            {
                int Id = int.Parse(textId.Text);
                try
                {
                    Id = int.Parse(textId.Text); 
                }
                catch
                {
                    throw new Exception("ID inv??lido.");
                }
                
                TagController.AlterarTag(
                    Id,
                    textDescricao.Text
                );

                MessageBox.Show("Dados alterados com sucesso.");
                Views.TagMenu menu = new Views.TagMenu();
                this.Close();

            }
            catch (System.Exception err)
            {
               MessageBox.Show($"N??o foi poss??vel inserir os dados. {err.Message}");
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