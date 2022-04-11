using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.IO;
using lib;


namespace Views
{
    public delegate void HandleButton(object sender, EventArgs e);
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }

    public class Login : Form
    {
        private System.ComponentModel.IContainer components = null;

        Campos.Field fieldUser;
        Campos.Field fieldPass;

        Button btnConfirm;
        Button btnCancel;

        public Login()
        {
            this.fieldUser = new Campos.Field(this.Controls, "Usuário", 20, true);
            this.fieldPass = new Campos.Field(this.Controls, "Senha", 80, true, true);
            this.fieldPass.textField.ForeColor = System.Drawing.Color.Red;
            this.btnConfirm = new Campos.ButtonForm(this.Controls, "Confirmar", 100, 180, this.handleConfirmClick);
            this.btnCancel = new Campos.ButtonForm(this.Controls, "Cancelar", 100, 220, this.handleCancelClick);
            
            this.components = new System.ComponentModel.Container();
        }

        private void handleConfirmClick(object sender, EventArgs e) {
            DialogResult result;

            result = MessageBox.Show(
                $"Usuário: {this.fieldUser.textField.Text}" +
                $"\nSenha: {this.fieldPass.textField.Text}",
                "Titulo da Mensagem",
                MessageBoxButtons.YesNo
            );

            if (result == DialogResult.Yes)
            {
                MenuPrincipal menu = new MenuPrincipal();
                menu.ShowDialog();
                this.Close();
            }
            else
            {
                Console.WriteLine("Clicou não");
            }
        }
        
        private void handleCancelClick(object sender, EventArgs e) {
            this.Close();
        }

    }

    public class MenuPrincipal : Form
    {
        private System.ComponentModel.IContainer components = null;

        Label lblLogin;

        Button btnTag;
        Button btnCategoria;
        Button btnProcedi;
        Button btnEspeciali;
        Button btnSala;
        Button btnAgendamento;
        Button btnCancel;

        Button btnCnfirm1;
        Button btnCancel1;
        public MenuPrincipal() 
        {
            this.lblLogin = new Label();
            this.lblLogin.Text = "Olá Fulano";
            this.lblLogin.Location = new Point(117, 20);

            this.btnTag = new Button();
            this.btnTag.Text = "Tag";
            this.btnTag.Location = new Point(40, 60);
            this.btnTag.Size = new Size(100, 30);
            this.btnTag.Click += new EventHandler(this.handleTagClick);

            this.btnCategoria = new Button();
            this.btnCategoria.Text = "Categoria";
            this.btnCategoria.Location = new Point(160, 60);
            this.btnCategoria.Size = new Size(100, 30);
            this.btnCategoria.Click += new EventHandler(this.handleCategoriaClick);

            this.btnProcedi = new Button();
            this.btnProcedi.Text = "Procedimento";
            this.btnProcedi.Location = new Point(40, 100);
            this.btnProcedi.Size = new Size(100, 30);
            this.btnProcedi.Click += new EventHandler(this.handleProcedimentoClick);

            this.btnEspeciali = new Button();
            this.btnEspeciali.Text = "Especialidade";
            this.btnEspeciali.Location = new Point(160, 100);
            this.btnEspeciali.Size = new Size(100, 30);
            this.btnEspeciali.Click += new EventHandler(this.handleEspecialidadeClick);

            this.btnSala = new Button();
            this.btnSala.Text = "Sala";
            this.btnSala.Location = new Point(40, 140);
            this.btnSala.Size = new Size(100, 30);
            this.btnSala.Click += new EventHandler(this.handleSalaClick);

            this.btnAgendamento = new Button();
            this.btnAgendamento.Text = "Agendamento";
            this.btnAgendamento.Location = new Point(160, 140);
            this.btnAgendamento.Size = new Size(100, 30);
            this.btnAgendamento.Click += new EventHandler(this.handleAgendamentoClick);

            this.btnCancel = new Button();
            this.btnCancel.Text = "Sair";
            this.btnCancel.Location = new Point(110, 200);
            this.btnCancel.Size = new Size(80, 30);
            this.btnCancel.Click += new EventHandler(this.handleCancelClick);

            this.Controls.Add(this.lblLogin);

            this.Controls.Add(this.btnTag);
            this.Controls.Add(this.btnCategoria);
            this.Controls.Add(this.btnProcedi);
            this.Controls.Add(this.btnEspeciali);
            this.Controls.Add(this.btnSala);
            this.Controls.Add(this.btnAgendamento);
            this.Controls.Add(this.btnCancel);

        }
        private void handleCategoriaClick(object sender, EventArgs e)
        {
            Views.CategoriaMenu menu = new Views.CategoriaMenu();
            menu.ShowDialog();
        }
        private void handleTagClick(object sender, EventArgs e)
        {
            Views.TagMenu menu = new Views.TagMenu();
            menu.ShowDialog();
        }
        private void handleProcedimentoClick(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();
            menu.ShowDialog();
            this.Close();
        }
        private void handleEspecialidadeClick(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();
            menu.ShowDialog();
            this.Close();
        }
        private void handleSalaClick(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();
            menu.ShowDialog();
            this.Close();
        }
         private void handleAgendamentoClick(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();
            menu.ShowDialog();
            this.Close();
        }
        private void handleCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
   
}
