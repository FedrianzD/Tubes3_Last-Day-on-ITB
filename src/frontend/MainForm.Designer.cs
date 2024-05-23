using System.Windows.Forms;

namespace frontend;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(this.TLP);
        Name = "MainForm";
        Text = "MainForm";
        ResumeLayout(false);
    }

    #endregion

    #region Andhika's Code
    private void InitializeUI()
    {
        // Create TLP to make Responsive UI
        this.TLP = new TableLayoutPanel();
        SuspendLayout();
        // 
        // TLP = TableLayoutPanel
        // 
        this.TLP.Name = "TLP";
        this.TLP.Dock = DockStyle.Fill;
        this.TLP.ColumnCount = 2;
        this.TLP.RowCount = 1;
        this.TLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        this.TLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        this.TLP.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

        // Input PictureBox
        this.userPictureBox = new PictureBox();
        this.userPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        this.userPictureBox.BorderStyle = BorderStyle.FixedSingle;
        this.userPictureBox.BackColor = Color.LightGray;
        this.userPictureBox.Dock = DockStyle.Fill;

        // Default PictureBox
        this.MatchPictureBox = new PictureBox();
        this.MatchPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        this.MatchPictureBox.BorderStyle = BorderStyle.FixedSingle;
        this.MatchPictureBox.BackColor = Color.LightGray;
        this.MatchPictureBox.Dock = DockStyle.Fill;

        // Add PictureBoxes to TableLayoutPanel
        this.TLP.Controls.Add(this.userPictureBox, 0, 0);
        this.TLP.Controls.Add(this.MatchPictureBox, 1, 0);

        // Add TableLayoutPanel to the form
        Controls.Add(this.TLP);

        // Load default image
        LoadImage("");

        // Add button to select user image
        this.selectImageButton = new Button();
        this.selectImageButton.Text = "Select Image";
        this.selectImageButton.Click += SelectImageButton_Click;
        this.TLP.Controls.Add(this.selectImageButton, 0, 1);
    }

    // Load image
    private void LoadImage(string imagePath)
    {
        if (!string.IsNullOrEmpty(imagePath))
        {
            try
            {
                this.userPictureBox.Image = Image.FromFile(imagePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading image: " + ex.Message);
            }
        }
        else
        {
            try
            {
                this.userPictureBox.Image = Image.FromFile("C:\\Users\\Acer\\tmp\\Tubes3_Last-Day-on-ITB\\src\\frontend\\assets\\placeholder.png");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading default image");
            }
        }
    }

    // Prompt to select image
    private void SelectImageButton_Click(object sender, EventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
        openFileDialog.Title = "Select an Image File";

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            string selectedImagePath = openFileDialog.FileName;
            LoadImage(selectedImagePath);
        }
    }

    #endregion

    private TableLayoutPanel TLP;
    private PictureBox userPictureBox;
    private PictureBox MatchPictureBox;
    private Button selectImageButton;
}
