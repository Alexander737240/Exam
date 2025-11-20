using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Экзамен
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.booksTableAdapter.Fill(this.bookStoreDBDataSet.Books);

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string filter = "";
            string searchTerm = txtSearch.Text.Replace("'", "''");

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                filter = $"Title LIKE '%{searchTerm}%' OR Author LIKE '%{searchTerm}%' OR Genre LIKE '%{searchTerm}%'";
            }
            this.booksBindingSource.Filter = filter;
        }
        private void SaveData()
        {
            try
            {
                booksTableAdapter.Update(bookStoreDBDataSet.Books);
                MessageBox.Show("Данные сохранены");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения: " + ex.Message);
            }
            this.booksTableAdapter.Fill(this.bookStoreDBDataSet.Books);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var newRow = bookStoreDBDataSet.Books.NewBooksRow();
            newRow.Title = "Новая книга";
            newRow.Author = "Автор";
            newRow.Publisher = "Издательство";
            newRow.Pages = 100;
            newRow.Genre = "Жанр";
            newRow.Year = DateTime.Now.Year;
            newRow.CostPrice = 10;
            newRow.SalePrice = 15;
            newRow.Quantity = 10;

            bookStoreDBDataSet.Books.AddBooksRow(newRow);
            SaveData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var rowView = (DataRowView)dataGridView1.CurrentRow.DataBoundItem;
                rowView.Row.Delete();
                SaveData();
            }
            else
            {
                MessageBox.Show("Выберите книгу для удаления");
            }
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var rowView = (DataRowView)dataGridView1.CurrentRow.DataBoundItem;
                DataRow row = rowView.Row;

                int currentQuantity = (int)row["Quantity"];

                if (currentQuantity > 0)
                {
                    row["Quantity"] = currentQuantity - 1;
                    SaveData();
                }
                else
                {
                    MessageBox.Show("Нет в наличии для продажи");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }
    }
}

