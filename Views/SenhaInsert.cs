using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Models;
using Controllers;
using static lib.Campos;
using lib;

namespace Views
{
    public class SenhaInsert : BaseForm
    {
        public delegate void HandleButton(object sender, EventArgs e);

        readonly Label lblInsert;
        readonly Label lblNome;
        readonly TextBox textNome;
        readonly Label lblCategoria;
        readonly ComboBox comboBoxCategoria;
        readonly Label lblUrl;
        readonly TextBox textUrl;
        readonly Label lblUsuario;
        readonly TextBox textUsuario;
        readonly Label lblSenha;
        readonly TextBox textSenha;
        readonly Label lblProcedimento;
        readonly TextBox textProcedimento;
        readonly Label lblTag;
        CheckBox tag;
        readonly Button btnConfirm;
        readonly Button btnCancel;

        public SenhaInsert() : base("Inserir Senha")
        {
            this.lblInsert = new Label {
                Text = "Dados Senha:",
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

            this.lblCategoria = new Label
            {
                Text = " Categoria",
                Location = new Point(120, 150)
            };

            string[] categoriasSuggestion = CategoriaController
                .GetCategorias()
                .Select(categoria => categoria.ToSuggestion())
                .ToArray();
            this.comboBoxCategoria = new ComboBox{
                Location = new Point(10, 175),
                Size = new Size(360, 20),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            this.comboBoxCategoria.Items.AddRange(categoriasSuggestion);

            this.lblUrl = new Label
            {
                Text = " Url",
                Location = new Point(120, 200)
            };

            textUrl = new TextBox
            {
                Location = new Point(10, 225),
                Size = new Size(360, 20)
            };

            this.lblUsuario = new Label
            {
                Text = " Usuario",
                Location = new Point(120, 250)
            };

            textUsuario = new TextBox
            {
                Location = new Point(10, 275),
                Size = new Size(360, 20)
            };

            this.lblSenha = new Label
            {
                Text = " Senha",
                Location = new Point(120, 300)
            };

            textSenha = new TextBox
            {
                Location = new Point(10, 325),
                Size = new Size(360, 20)
            };

            this.lblProcedimento = new Label
            {
                Text = " Procedimento",
                Location = new Point(120, 350)
            };

            textProcedimento = new TextBox
            {
                Location = new Point(10, 375),
                ClientSize = new Size(360, 450)
            };

            this.lblTag = new Label
            {
                Text = " Tags",
                Location = new Point(120, 400)
            };


            // Create and initialize a CheckBox.   
            
            CheckBox tag = new CheckBox
            {
                // Make the check box control appear as a toggle button.
                Appearance = Appearance.Button,
                Location = new Point(10, 425),
                Size = new Size(360, 20),

                // Turn off the update of the display on the click of the control.
                AutoCheck = false
            };



            this.Controls.Add(this.lblInsert);
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
            this.Controls.Add(this.tag);
            
            this.btnConfirm = new ButtonForm(this.Controls, "Confirmar", 40,480, this.handleConfirmClick);
            this.btnCancel = new ButtonForm(this.Controls, "Cancelar", 150, 480, this.handleCancelClick);
 
        }
        private void handleConfirmClick(object sender, EventArgs e) 
        {
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
                    SenhaController.InserirSenha(
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