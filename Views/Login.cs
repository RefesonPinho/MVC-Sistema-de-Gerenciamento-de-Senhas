using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.IO;
using Views;
using lib;
using Models;

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
        readonly Campos.Field fieldUser;
        readonly Campos.Field fieldPass;
        readonly Button btnConfirm;
        readonly Button btnSair;

        public Login()

        {
            this.ClientSize = new System.Drawing.Size(300,300);
            this.fieldUser = new Campos.Field(this.Controls, "Usuário", 20, true);
            this.fieldPass = new Campos.Field(this.Controls, "Senha", 80, true, true);
            this.fieldPass.textField.ForeColor = System.Drawing.Color.Red;
            this.btnConfirm = new Campos.ButtonForm(this.Controls, "Confirmar", 100, 180, this.handleConfirmClick);
            this.btnSair = new Campos.ButtonForm(this.Controls, "Cancelar", 100, 220, this.handleCancelClick);
            
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
                Usuario.Auth(
                    this.fieldUser.textField.Text,
                    this.fieldPass.textField.Text
                );
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
}
