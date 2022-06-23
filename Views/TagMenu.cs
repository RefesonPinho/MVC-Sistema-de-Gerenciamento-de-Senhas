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
        readonly Button btnInsert;
        readonly Button btnAlterar;
        readonly Button btnExcluir;
        readonly Button btnVoltar;

        public TagMenu() : base("Tag cadastradas")
        {
            this.ClientSize = new System.Drawing.Size(400,700);
            this.listView = new ListView
            {
                Dock = DockStyle.Fill,
                View = View.Details,
                Sorting = SortOrder.Ascending
            };

            // Create and initialize column headers for listView1.
            ColumnHeader listId = new ColumnHeader
            {
                Text = "Id",
                Width = -2
            };
            ColumnHeader listDescricao = new ColumnHeader
            {
                Text = "Descrição",
                Width = -2
            };

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
