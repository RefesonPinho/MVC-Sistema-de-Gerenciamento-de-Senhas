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
    public class SenhaUpdate : BaseForm
    {
        public delegate void HandleButton(object sender, EventArgs e);

        Label lblUpdate;
        Label lblId;
        TextBox textId;
       Label lblNome;
        TextBox textNome;
        Label lblCategoria;
        ComboBox comboBoxCategoria;
        Label lblUrl;
        TextBox textUrl;
        Label lblUsuario;
        TextBox textUsuario;
        Label lblSenha;
        TextBox textSenha;
        Label lblProcedimento;
        TextBox textProcedimento;
        Label lblTag;
        CheckBox checkBoxTag;
        Button btnConfirm;
        Button btnCancel;

        public SenhaUpdate() : base("Alterar Usuarios")
        {

            this.lblUpdate = new Label();
            this.lblUpdate.Text = "Dados Senha:";
            this.lblUpdate.Location = new Point(100, 50);
            
            this.lblId = new Label();
            this.lblId.Text = " Digite o Id  ";
            this.lblId.Location = new Point(120, 75);
            this.lblId.Size = new Size(240,15);

            textId = new TextBox();
            textId.Location = new Point(10,100);
            textId.Size = new Size(360,20);

            this.lblNome = new Label();
            this.lblNome.Text = " Digite o Nome ";
            this.lblNome.Location = new Point(120, 125);
            this.lblNome.Size = new Size(240,15);

            textNome = new TextBox();
            textNome.Location = new Point(10,150);
            textNome.Size = new Size(360,20);
            
            this.lblCategoria = new Label();
            this.lblCategoria.Text = " Categoria";
            this.lblCategoria.Location = new Point(120, 175);

            string[] categoriasSuggestion = CategoriaController
                .GetCategorias()
                .Select(categoria => categoria.ToSuggestion())
                .ToArray();
            this.comboBoxCategoria = new ComboBox{
                Location = new Point(10, 200),
                Size = new Size(360, 20),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            this.comboBoxCategoria.Items.AddRange(categoriasSuggestion);

            this.lblUrl = new Label
            {
                Text = " Url",
                Location = new Point(120, 225)
            };

            textUrl = new TextBox
            {
                Location = new Point(10, 250),
                Size = new Size(360, 20)
            };

            this.lblUsuario = new Label
            {
                Text = " Usuario",
                Location = new Point(120, 275)
            };

            textUsuario = new TextBox
            {
                Location = new Point(10, 300),
                Size = new Size(360, 20)
            };

            this.lblSenha = new Label
            {
                Text = " Senha",
                Location = new Point(120, 325)
            };

            textSenha = new TextBox
            {
                Location = new Point(10, 350),
                Size = new Size(360, 20)
            };

            this.lblProcedimento = new Label
            {
                Text = " Procedimento",
                Location = new Point(120, 375)
            };

            textProcedimento = new TextBox
            {
                Location = new Point(10, 400),
                ClientSize = new Size(360, 20)
            };

            this.lblTag = new Label
            {
                Text = " Tags",
                Location = new Point(120, 425)
            };


           this.Controls.Add(this.lblUpdate);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.textId);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.textNome);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.comboBoxCategoria);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.textUrl);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.textUsuario);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.textSenha);
            this.Controls.Add(this.lblProcedimento);
            this.Controls.Add(this.textProcedimento);
            this.Controls.Add(this.lblTag);
            this.Controls.Add(this.checkBoxTag);
            

            this.btnConfirm = new ButtonForm(this.Controls, "Confirmar", 40,480, this.handleConfirmClick);
            this.btnCancel = new ButtonForm(this.Controls, "Cancelar", 150, 480, this.handleCancelClick);
            
               
        }

        private void handleConfirmClick(object sender, EventArgs e) 
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

            string[] comboValue = comboBoxCategoria.Text.Split(" ");
            int CategoriaId = int.Parse(comboValue[0]);
            try
            {
                DialogResult confirm = MessageBox.Show(
                    "Deseja realmente confirmar?",
                    "CONFIRMAR",
                    MessageBoxButtons.YesNo
                );

                if (confirm == DialogResult.Yes) {
                    SenhaController.AlterarSenha(
                        Id,
                        textNome.Text,
                        CategoriaId,
                        textUrl.Text,
                        textUsuario.Text,
                        textSenha.Text,
                        textProcedimento.Text
                        
                    );
                    MessageBox.Show("Dados inseridos com sucesso.");
                    SenhaMenu menu = new SenhaMenu();
                    this.Close();
                }


            }
            catch
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