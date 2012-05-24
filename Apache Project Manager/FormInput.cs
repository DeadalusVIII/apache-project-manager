using System;
using System.Windows.Forms;

namespace Apache_Project_Manager
{
    public partial class FormInput : Form
    {
        public FormInput(String message, String title, String initialText)
        {
            InitializeComponent();

            this.labelMessage.Text = message;
            this.Text = title;
            this.textBoxInput.Text = initialText;
        }

        private void FormInputLoad(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void ButtonOkClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


        public String InputText
        {
            get { return textBoxInput.Text; }
            set { textBoxInput.Text = value; }
        }
    }
}
