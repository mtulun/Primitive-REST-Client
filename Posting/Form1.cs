using Posting.Http_Methods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Posting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ShowLabel();
        }

        private void btnHit_Click(object sender, EventArgs e)
        {
            RestClient client = new RestClient();
            client.EndPoint = txtRequestUri.Text;

            switch(cbHttpMethods.Text)
            {
                case "POST":
                    client.HttpMethod = HttpMethods.POST;
                    client.PostJSON = txtPOSTData.Text;
                    break;
                default:
                    client.HttpMethod = HttpMethods.GET;
                    break;
            }


            client.UserName = txtUserName.Text;
            client.Password = txtPassword.Text;

            DebugOutput("--> REST Client Created...");

            string response = string.Empty;
            response = client.MakeRequest();

            txtResponse.Text = response;
            DebugOutput(response);
        }


        private void DebugOutput(string debug)
        {
            try
            {
                Debug.Write(debug + " " + Environment.NewLine);
                txtResponse.Text = txtResponse.Text + debug + Environment.NewLine;
                txtResponse.SelectionStart = txtResponse.TextLength;
                txtResponse.ScrollToCaret();
            }
            catch (Exception exc)
            {

                Debug.Write(exc.Message, ToString() + Environment.NewLine);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtResponse.Text = string.Empty;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtResponse.Text);
        }

        private void ShowLabel()
        {
            Label postData = new Label();
            Controls.Add(postData);
            postData.Text = "Post Json:";
            postData.ForeColor = Color.White;
            postData.BackColor = Color.Gray;
            postData.AutoSize = true;
            postData.Location = new Point(23, 51);
        }
    }
}
