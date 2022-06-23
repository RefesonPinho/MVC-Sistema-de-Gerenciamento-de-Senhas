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
    public class SenhaMenu : BaseForm
    {
        readonly Button btnInsert;
        readonly Button btnAlterar;
        readonly Button btnExcluir;
        readonly Button btnVoltar;
        internal static readonly object listSenha;

        public SenhaMenu() : base(" Senhas cadastradas")
        {
            ListView listView = new ListView
            {
                Dock = DockStyle.Fill,
                View = View.Details,
                Sorting = SortOrder.Ascending
            };

            // Create and initialize column headers for listView1.
            ColumnHeader list0 = new ColumnHeader
            {
                Text = "Id",
                Width = -2
            };
            ColumnHeader list1 = new ColumnHeader
            {
                Text = "Nome",
                Width = -2
            };
            ColumnHeader list2 = new ColumnHeader
            {
                Text = "Categoria",
                Width = -2
            };
            ColumnHeader list3 = new ColumnHeader
            {
                Text = "Url",
                Width = -2
            };
            ColumnHeader list4 = new ColumnHeader
            {
                Text = "Usuário",
                Width = -2
            };
            ColumnHeader list5 = new ColumnHeader
            {
                Text = "Procedimento",
                Width = -2
            };

            // Add the column headers to listView1.
            listView.Columns.AddRange(new ColumnHeader[] 
                {list0, list1,list2,list3,list4,list5});


            // Create items and add them to myListView.
			listView.View = View.Details;
			foreach(Senha item in SenhaController.GetSenhas())
            {
                ListViewItem listSenha= new ListViewItem(item.Id + "");
                listSenha.SubItems.Add(item.Nome);
                listSenha.SubItems.Add(item.CategoriaId + "");
                listSenha.SubItems.Add(item.Url);
                listSenha.SubItems.Add(item.Usuario);
                listSenha.SubItems.Add(item.Procedimento);
                listSenha.SubItems.Add(item.Procedimento);		
                listView.Items.AddRange(new ListViewItem[]{listSenha});
            }

            ListView listView1 = new ListView();
            listView.Dock = DockStyle.Fill;
            listView.View = View.Details;
            listView.Sorting = SortOrder.Ascending;

            // Create and initialize column headers for listView1.
            ColumnHeader list6 = new ColumnHeader
            {
                Text = "Senha",
                Width = -2
            };
            ColumnHeader list7 = new ColumnHeader
            {
                Text = "Tag id",
                Width = -2
            };

            // Add the column headers to listView1.
            listView1.Columns.AddRange(new ColumnHeader[] 
                {list6,list7});

            listView1.View = View.Details;
			foreach(SenhaTag item in SenhaTagController.GetSenhaTags())
            {
                ListViewItem listSenha1= new ListViewItem(item.Id + "");
                listSenha1.SubItems.Add(item.SenhaId + "");
                listSenha1.SubItems.Add(item.TagId + "");		
                listView.Items.AddRange(new ListViewItem[]{listSenha1});
            }


            this.btnInsert = new Button
            {
                Text = "Inserir",
                Location = new Point(40, 230),
                Size = new Size(100, 30)
            };
            this.btnInsert.Click += new EventHandler(this.handleInsertClick);

            this.btnAlterar = new Button
            {
                Text = "Alterar",
                Location = new Point(150, 230),
                Size = new Size(100, 30)
            };
            this.btnAlterar.Click += new EventHandler(this.handleAlterarClick);

            this.btnExcluir = new Button
            {
                Text = "Excluir",
                Location = new Point(260, 230),
                Size = new Size(100, 30)
            };
            this.btnExcluir.Click += new EventHandler(this.handleExcluirClick);

            this.btnVoltar = new Button
            {
                Text = "Voltar",
                Location = new Point(370, 230),
                Size = new Size(100, 30)
            };
            this.btnVoltar.Click += new EventHandler(this.handleVoltarClik);     

            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnVoltar);

                // Initialize the form.
            this.Controls.Add(listView);    
            this.Size = new System.Drawing.Size(550, 330);
            this.Text = "Informações das Senhas:";
            }
        private void handleInsertClick(object sender, EventArgs e)
        {
            Views.SenhaInsert menu = new Views.SenhaInsert();
            menu.ShowDialog();
        }

        private void handleAlterarClick(object sender, EventArgs e)
        {
           Views.SenhaUpdate menu = new Views.SenhaUpdate();
            menu.ShowDialog();
        }
        private void handleExcluirClick(object sender, EventArgs e)
        {
            Views.SenhaDelete menu = new Views.SenhaDelete();
            menu.ShowDialog();
        }
        private void handleVoltarClik(object sender, EventArgs e)
        {
           Views.MenuPrincipal menu = new Views.MenuPrincipal();
            this.Close();       
        }  
    }           
}
