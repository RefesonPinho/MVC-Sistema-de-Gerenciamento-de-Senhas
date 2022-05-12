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
    public class TagMenu : BaseForm
    {
        readonly ListView listView;
        Button btnInsert;
        Button btnAlterar;
        Button btnExcluir;
        Button btnVoltar;

        public TagMenu() : base("Tag cadastradas")
        {
            this.listView = new ListView();
            this.listView.Dock = DockStyle.Fill;
            this.listView.View = View.Details;
            this.listView.Sorting = SortOrder.Ascending;

            // Create and initialize column headers for listView1.
            ColumnHeader listId = new ColumnHeader();
            listId.Text = "Id";
            listId.Width = -2;
            ColumnHeader listDescricao = new ColumnHeader();
            listDescricao.Text = "Descrição";
            listDescricao.Width = -2;

            // Add the column headers to listView1.
            this.listView.Columns.AddRange(new ColumnHeader[] 
                {listId, listDescricao});


                // Create items and add them to myListView.
			this.listView.View = View.Details;
			foreach(Tag item in TagController.GetTags())
            {
                ListViewItem listTag = new ListViewItem(item.Id + "");
                listTag.SubItems.Add(item.Descricao);	
                this.listView.Items.AddRange(new ListViewItem[]{listTag});
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
            this.Controls.Add(this.listView);
            this.Size = new System.Drawing.Size(550, 330);
            this.Text = "Informações do Tag:";
            }
        private void handleInsertClick(object sender, EventArgs e)
        {
            Views.TagInsert menu = new Views.TagInsert();
            menu.ShowDialog();
        }

        private void handleAlterarClick(object sender, EventArgs e)
        {
           Views.TagUpdate menu = new Views.TagUpdate();
            menu.ShowDialog();
        }
        private void handleExcluirClick(object sender, EventArgs e)
        {
            Views.TagDelete menu = new Views.TagDelete();
            menu.ShowDialog();
        }
        private void handleVoltarClik(object sender, EventArgs e)
        {
           Views.MenuPrincipal menu = new Views.MenuPrincipal();
            this.Close();
        }  

    }           
}
