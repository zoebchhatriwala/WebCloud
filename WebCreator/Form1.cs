using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebCreator
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        
        
       
        

        private void clear_Click(object sender, EventArgs e)
        {
            input.Text = "";
        }

        

        private void open_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|html files (*.html)|*.html|css files (*.css)|*.css|php files (*.php)|*.php|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            input.Text = File.ReadAllText(openFileDialog1.FileName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
            
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            display();
        }

        private void save_Click(object sender, EventArgs e)
        {
             
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|html files (*.html)|*.html|css files (*.css)|*.css|php files (*.php)|*.php|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
               File.WriteAllText(saveFileDialog1.FileName, input.Text);
            }
         }

        private void submit_Click(object sender, EventArgs e)
        {
            display();
        }
        private void display()
        {

            web.DocumentText = input.Text;
            if (web.DocumentTitle != "")
            {
                
                tabPage1.Text = web.DocumentTitle;
                
            }
            else
            {
                tabPage1.Text = "Output";
            }
        }

        private void about_Click(object sender, EventArgs e)
        {
            MessageBox.Show("WebCloud is a Live Html Viewer for Developing Html Websites.\nApplication Developed By: Zoeb Chhatriwala\nHelp:-\n1. Enter Full Path of any File e.g: c:\\folder\\img.jpg\n2. Use Ctrl+r|Submit to Run");
        }

        private void input_KeyPress(object sender, KeyPressEventArgs e)
        {
            int key = e.KeyChar;
            if (key==1)
            {
                input.SelectAll();
            }
           else if (key==18)
            {
                display();
            }
        }
        
    }
    }

