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

namespace Views
{
    public class UsuarioMenu : BaseForm
    {
    
        ListView listView1;
        Button btnInsert;
        Button btnAlterar;
        Button btnExcluir;
        Button btnVoltar;

        public UsuarioMenu() : base(" Usuários cadastrados")
        {
            ListView listView = new ListView();
            listView.Dock = DockStyle.Fill;
            listView.View = View.Details;
            listView.Sorting = SortOrder.Ascending;

            // Create and initialize column headers for listView1.
            ColumnHeader list0 = new ColumnHeader();
            list0.Text = "Id";
            list0.Width = -2;
            ColumnHeader list1 = new ColumnHeader();
            list1.Text = "Nome";
            list1.Width = -2;
            ColumnHeader list2= new ColumnHeader();
            list2.Text = "Email";
            list2.Width = -2;
            ColumnHeader list3= new ColumnHeader();
            list3.Text = "Senha";
            list3.Width = -2;

            // Add the column headers to listView1.
            listView.Columns.AddRange(new ColumnHeader[] 
                {list0, list1,list2,list3});


            // Create items and add them to myListView.
			listView.View = View.Details;
			foreach(Usuario item in UsuarioController.GetUsuarios())
            {
                ListViewItem listUsuario= new ListViewItem(item.Id + "");
                listUsuario.SubItems.Add(item.Nome);
                listUsuario.SubItems.Add(item.Email);
                listUsuario.SubItems.Add(item.Senha);	
                listView.Items.AddRange(new ListViewItem[]{listUsuario});
            }
        
            this.btnInsert = new Button();
            this.btnInsert.Text = "Inserir";
            this.btnInsert.Location = new Point(40, 230);
            this.btnInsert.Size = new Size(100, 30);
            this.btnInsert.Click += new EventHandler(this.handleInsertClick);

            this.btnAlterar = new Button();
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.Location = new Point(150, 230);
            this.btnAlterar.Size = new Size(100, 30);
            this.btnAlterar.Click += new EventHandler(this.handleAlterarClick);

            this.btnExcluir = new Button();
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.Location = new Point(260, 230);
            this.btnExcluir.Size = new Size(100, 30);
            this.btnExcluir.Click += new EventHandler(this.handleExcluirClick);

            this.btnVoltar = new Button();
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.Location = new Point(370, 230);
            this.btnVoltar.Size = new Size(100, 30);
            this.btnVoltar.Click += new EventHandler(this.handleVoltarClik);     

            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnVoltar);

                // Initialize the form.
            this.Controls.Add(listView);    
            this.Size = new System.Drawing.Size(550, 330);
            this.Text = "Informações das Usuarios:";
            }
        private void handleInsertClick(object sender, EventArgs e)
        {
            Views.UsuarioInsert menu = new Views.UsuarioInsert();
            menu.ShowDialog();
        }

        private void handleAlterarClick(object sender, EventArgs e)
        {
           Views.UsuarioUpdate menu = new Views.UsuarioUpdate();
            menu.ShowDialog();
        }
        private void handleExcluirClick(object sender, EventArgs e)
        {
            Views.UsuarioDelete menu = new Views.UsuarioDelete();
            menu.ShowDialog();
        }
        private void handleVoltarClik(object sender, EventArgs e)
        {
           Views.MenuPrincipal menu = new Views.MenuPrincipal();
            this.Close();       
        }  
    }           
}
