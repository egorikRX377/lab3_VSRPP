using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace lab3_VSRPP
{
    public partial class Form1 : Form
    {
        private ListBox listBoxLeft;
        private ListBox listBoxRight;
        private Button btnMoveRight;
        private Button btnMoveLeft;
        private Button btnMoveAllRight;
        private Button btnMoveAllLeft;
        private TextBox textBoxNewItem;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.listBoxLeft = new ListBox();
            this.listBoxRight = new ListBox();
            this.btnMoveRight = new Button();
            this.btnMoveLeft = new Button();
            this.btnMoveAllRight = new Button();
            this.btnMoveAllLeft = new Button();
            this.textBoxNewItem = new TextBox();
            this.btnAdd = new Button();
            this.btnEdit = new Button();
            this.btnDelete = new Button();

            this.listBoxLeft.Location = new System.Drawing.Point(12, 12);
            this.listBoxLeft.Size = new System.Drawing.Size(120, 160);

            this.listBoxRight.Location = new System.Drawing.Point(252, 12);
            this.listBoxRight.Size = new System.Drawing.Size(120, 160);

            this.btnMoveRight.Text = "->";
            this.btnMoveRight.Location = new System.Drawing.Point(150, 30);
            this.btnMoveRight.Click += new EventHandler(this.btnMoveRight_Click);

            this.btnMoveLeft.Text = "<-";
            this.btnMoveLeft.Location = new System.Drawing.Point(150, 70);
            this.btnMoveLeft.Click += new EventHandler(this.btnMoveLeft_Click);

            this.btnMoveAllRight.Text = "Move All ->";
            this.btnMoveAllRight.Location = new System.Drawing.Point(150, 110);
            this.btnMoveAllRight.Click += new EventHandler(this.btnMoveAllRight_Click);

            this.btnMoveAllLeft.Text = "Move All <-";
            this.btnMoveAllLeft.Location = new System.Drawing.Point(150, 150);
            this.btnMoveAllLeft.Click += new EventHandler(this.btnMoveAllLeft_Click);

            this.textBoxNewItem.Location = new System.Drawing.Point(12, 190);
            this.textBoxNewItem.Size = new System.Drawing.Size(120, 20);

            this.btnAdd.Text = "Add";
            this.btnAdd.Location = new System.Drawing.Point(12, 220);
            this.btnAdd.Click += new EventHandler(this.btnAdd_Click);

            this.btnEdit.Text = "Edit";
            this.btnEdit.Location = new System.Drawing.Point(12, 250);
            this.btnEdit.Click += new EventHandler(this.btnEdit_Click);

            this.btnDelete.Text = "Delete";
            this.btnDelete.Location = new System.Drawing.Point(12, 280);
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);

            this.ClientSize = new System.Drawing.Size(384, 311);
            this.Controls.Add(this.listBoxLeft);
            this.Controls.Add(this.listBoxRight);
            this.Controls.Add(this.btnMoveRight);
            this.Controls.Add(this.btnMoveLeft);
            this.Controls.Add(this.btnMoveAllRight);
            this.Controls.Add(this.btnMoveAllLeft);
            this.Controls.Add(this.textBoxNewItem);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Text = "ListBox Management";
        }

        private void btnMoveRight_Click(object sender, EventArgs e)
        {
            MoveSelectedItem(listBoxLeft, listBoxRight);
        }

        private void btnMoveLeft_Click(object sender, EventArgs e)
        {
            MoveSelectedItem(listBoxRight, listBoxLeft);
        }

        private void btnMoveAllRight_Click(object sender, EventArgs e)
        {
            MoveAllItems(listBoxLeft, listBoxRight);
        }

        private void btnMoveAllLeft_Click(object sender, EventArgs e)
        {
            MoveAllItems(listBoxRight, listBoxLeft);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxNewItem.Text))
            {
                listBoxLeft.Items.Add(textBoxNewItem.Text);
                textBoxNewItem.Clear();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listBoxLeft.SelectedItem != null && !string.IsNullOrWhiteSpace(textBoxNewItem.Text))
            {
                int selectedIndex = listBoxLeft.SelectedIndex;
                listBoxLeft.Items[selectedIndex] = textBoxNewItem.Text;
                textBoxNewItem.Clear();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBoxLeft.SelectedItem != null)
            {
                listBoxLeft.Items.Remove(listBoxLeft.SelectedItem);
            }
        }

        private void MoveSelectedItem(ListBox fromListBox, ListBox toListBox)
        {
            if (fromListBox.SelectedItem != null)
            {
                toListBox.Items.Add(fromListBox.SelectedItem);
                fromListBox.Items.Remove(fromListBox.SelectedItem);
            }
        }

        private void MoveAllItems(ListBox fromListBox, ListBox toListBox)
        {
            foreach (var item in fromListBox.Items)
            {
                toListBox.Items.Add(item);
            }
            fromListBox.Items.Clear();
        }
    }
}

