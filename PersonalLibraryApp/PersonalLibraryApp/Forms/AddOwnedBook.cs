﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalLibraryApp.Forms
{
    public partial class AddOwnedBook : Form
    {
        private Book book = new Book();
        private OwnedBooks ownedBook = new OwnedBooks();
        public bool IsAdd { get; set; }
        public AddOwnedBook()
        {
            InitializeComponent();
        }

        private void AddOwnedBook_Load(object sender, EventArgs e)
        {
            if (IsAdd)
            {
                txtBookID.Enabled = true;
            }
            else
            {
                txtBookID.Enabled = false;
                SetBookFields(book);
            }
        }

        private void rbtnNewBook_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            txtDescription.Enabled = true;
        }

        private void rbtnExistingBook_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            txtDescription.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rbtnExistingBook.Checked)
            {
                if (ValidateForm())
                {
                    ownedBook = new OwnedBooks(book, true, dtpDateBought.Value);
                    this.Hide();
                }
            }
            else
            {
                if (ValidateForm())
                {
                    book = new Book(txtBookID.Text, txtTitle.Text, txtDescription.Text, txtAuthorSName.Text);
                    ownedBook = new OwnedBooks(book, true, dtpDateBought.Value);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        internal OwnedBooks GetOwnedBook()
        {
            return ownedBook;
        }

        internal void SetBook(Book book)
        {
            this.book = book;
        }

        private bool ValidateForm()
        {
            if (txtTitle.Text == "")
            {
                MessageBox.Show("Please enter the title");
                return false;
            }
            if (txtBookID.Text == "")
            {
                MessageBox.Show("Please enter the book ID");
                return false;
            }
            if (txtAuthorSName.Text == "")
            {
                MessageBox.Show("Please enter the author name");
                return false;
            }
            if (txtDescription.Text == "")
            {
                MessageBox.Show("Please describe the book");
                return false;
            }
            if (dtpDateBought.Value > DateTime.Now)
            {
                MessageBox.Show("Date bought cannot be in the future");
                return false;
            }
            return true;
        }

        private void SetBookFields(Book book)
        {
            txtBookID.Text = book.BookId;
            txtTitle.Text = book.Title;
            txtDescription.Text = book.Description;
            txtAuthorSName.Text = book.AuthorLastName;
        }
    }
}
