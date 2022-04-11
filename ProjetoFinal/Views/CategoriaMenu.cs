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
        private System.ComponentModel.IContainer components = null;

        ListView listView1;
        Button btnInsert;
        Button btnAlterar;
        Button btnExcluir;
        Button btnVoltar;

        public CategoriaMenu() : base("Categorias cadastradas")
        {
            ListView listView1 = new ListView();
            listView1.Dock = DockStyle.Fill;
            listView1.View = View.Details;
            listView1.Sorting = SortOrder.Ascending;

            // Create and initialize column headers for listView1.
            ColumnHeader list0 = new ColumnHeader();
            list0.Text = "Id";
            list0.Width = -2;
            ColumnHeader list1 = new ColumnHeader();
            list1.Text = "Nome";
            list1.Width = -2;
            ColumnHeader list2= new ColumnHeader();
            list2.Text = "Descrição";
            list2.Width = -2;

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
            
            this.components = new System.ComponentModel.Container();

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
