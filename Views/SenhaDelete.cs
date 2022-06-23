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
    public class SenhaDelete : BaseForm
    {
        public delegate void HandleButton(object sender, EventArgs e);

        readonly Label lblDelete;
        readonly Label lblId;
        readonly TextBox textId;
        readonly Button btnConfirm1;
        readonly Button btnCancel1;

        public SenhaDelete() : base("Deletar Senha")
        {
            this.ClientSize = new System.Drawing.Size(400,300);
            this.lblDelete = new Label
            {
                Text = "Dados Senha:",
                Location = new Point(100, 50)
            };

            this.lblId = new Label
            {
                Text = " Digite o Id que deseja Excluir ",
                Location = new Point(80, 100),
                Size = new Size(240, 15)
            };

            textId = new TextBox
            {
                Location = new Point(10, 125),
                Size = new Size(360, 20)
            };

            this.btnConfirm1 = new Campos.ButtonForm(this.Controls, "Confirmar", 80,200, this.handleConfirmClick);
            this.btnCancel1 = new Campos.ButtonForm(this.Controls, "Cancelar", 190, 200, this.handleCancelClick);

        
            this.Controls.Add(this.lblDelete);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.textId);
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

                DialogResult confirm = MessageBox.Show(
                    "Deseja realmente Excluir esse item?",
                    "CONFIRMAR",
                    MessageBoxButtons.YesNo
                );

                if (confirm == DialogResult.Yes) {
                    SenhaController.ExcluirSenha(
                        Id
                        
                    );
                    MessageBox.Show("Dados excluidos com sucesso.");
                    Views.SenhaMenu menu = new Views.SenhaMenu();
                    this.Close();
                }  
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