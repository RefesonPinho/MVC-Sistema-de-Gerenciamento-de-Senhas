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
    public class CategoriaMenu : BaseForm
    {
        readonly ListView listView1;
        readonly Button btnInsert;
        readonly Button btnAlterar;
        readonly Button btnExcluir;
        readonly Button btnVoltar;

        public CategoriaMenu() : base("Categorias cadastradas")
        {
            this.ClientSize = new System.Drawing.Size(400,400);
            ListView listView1 = new ListView
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
                Text = "Descrição",
                Width = -2
            };

            // Add the column headers to listView1.
            listView1.Columns.AddRange(new ColumnHeader[] 
                {list0, list1,list2});


                // Create items and add them to myListView.
			listView1.View = View.Details;
			foreach(Categoria item in CategoriaController.GetCategorias())
            {
                ListViewItem listCategoria= new ListViewItem(item.Id + "");
                listCategoria.SubItems.Add(item.Nome);
                listCategoria.SubItems.Add(item.Descricao);	
                listView1.Items.AddRange(new ListViewItem[]{listCategoria});
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
            this.Controls.Add(listView1);    
            this.Controls.Add(this.listView1);
            this.Size = new System.Drawing.Size(550, 330);
            this.Text = "Informações das Categorias:";
            }
        private void handleInsertClick(object sender, EventArgs e)
        {
            Views.CategoriaInsert menu = new Views.CategoriaInsert();
            menu.ShowDialog();
        }

        private void handleAlterarClick(object sender, EventArgs e)
        {
           Views.CategoriaUpdate menu = new Views.CategoriaUpdate();
            menu.ShowDialog();
        }
        private void handleExcluirClick(object sender, EventArgs e)
        {
            Views.CategoriaDelete menu = new Views.CategoriaDelete();
            menu.ShowDialog();
        }
        private void handleVoltarClik(object sender, EventArgs e)
        {
           Views.MenuPrincipal menu = new Views.MenuPrincipal();
            this.Close();
        }  
    }           
}
