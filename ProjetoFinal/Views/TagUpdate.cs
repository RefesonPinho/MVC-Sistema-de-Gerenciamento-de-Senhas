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

        private System.ComponentModel.IContainer components = null;
        TextBox text;
        Label lblUpdate;
        Label lblId;
        Label lblDescricao;
        TextBox textDescricao;
        TextBox textId;
        Button btnConfirm1;
        Button btnCancel1;

        public TagUpdate() : base("Alterar Tag")
        {
            this.lblUpdate = new Label();
            this.lblUpdate.Text = "Dados Tag:";
            this.lblUpdate.Location = new Point(100, 50);

            this.lblId = new Label();
            this.lblId.Text = " Digite o Id da Tag que deseja alterar ";
            this.lblId.Location = new Point(80, 100);
            this.lblId.Size = new Size(240,15);

            textId = new TextBox();
            textId.Location = new Point(10,125);
            textId.Size = new Size(360,20);
            
            this.lblDescricao = new Label();
            this.lblDescricao.Text = " Descricao";
            this.lblDescricao.Location = new Point(120, 150);

            textDescricao = new TextBox();
            textDescricao.Location = new Point(10,175);
            textDescricao.Size = new Size(360,20);

            this.btnConfirm1 = new Campos.ButtonForm(this.Controls, "Confirmar", 40,240, this.handleConfirmClick);
            this.btnCancel1 = new Campos.ButtonForm(this.Controls, "Cancelar", 150, 240, this.handleCancelClick);

            
            
            this.components = new System.ComponentModel.Container();

            this.Controls.Add(this.lblUpdate);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.textId);
            this.Controls.Add(this.textDescricao);
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
                
                TagController.AlterarTag(
                    Id,
                    textDescricao.Text
                );

                MessageBox.Show("Dados alterados com sucesso.");
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