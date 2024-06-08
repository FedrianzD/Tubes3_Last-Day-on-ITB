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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        TLP = new TableLayoutPanel();
        title = new Label();
        userPictureBox = new PictureBox();
        MatchPictureBox = new PictureBox();
        selectImageButton = new Button();
        TLP.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)userPictureBox).BeginInit();
        ((System.ComponentModel.ISupportInitialize)MatchPictureBox).BeginInit();
        SuspendLayout();
        // 
        // TLP
        // 
        TLP.AutoSize = true;
        TLP.ColumnCount = 3;
        TLP.ColumnStyles.Add(new ColumnStyle());
        TLP.ColumnStyles.Add(new ColumnStyle());
        TLP.ColumnStyles.Add(new ColumnStyle());
        TLP.ColumnStyles.Add(new ColumnStyle());
        TLP.Controls.Add(title, 1, 0);
        TLP.Controls.Add(userPictureBox, 0, 1);
        TLP.Controls.Add(MatchPictureBox, 1, 1);
        TLP.Controls.Add(selectImageButton, 0, 2);
        TLP.Location = new Point(0, 0);
        TLP.Name = "TLP";
        TLP.RowCount = 3;
        TLP.RowStyles.Add(new RowStyle());
        TLP.RowStyles.Add(new RowStyle());
        TLP.RowStyles.Add(new RowStyle());
        TLP.RowStyles.Add(new RowStyle());
        TLP.Size = new Size(836, 417);
        TLP.TabIndex = 0;
        TLP.Paint += TLP_Paint;
        // 
        // title
        // 
        title.AutoSize = true;
        title.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        title.Location = new Point(309, 0);
        title.Name = "title";
        title.Size = new Size(524, 30);
        title.TabIndex = 0;
        title.Text = "Aplikasi C# Tugas Besar 3 Strategi Algoritma 2023/2024";
        // 
        // userPictureBox
        // 
        userPictureBox.BackColor = Color.Transparent;
        userPictureBox.BorderStyle = BorderStyle.FixedSingle;
        userPictureBox.InitialImage = (Image)resources.GetObject("userPictureBox.InitialImage");
        userPictureBox.Location = new Point(3, 33);
        userPictureBox.Name = "userPictureBox";
        userPictureBox.Size = new Size(300, 350);
        userPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        userPictureBox.TabIndex = 1;
        userPictureBox.TabStop = false;
        // 
        // MatchPictureBox
        // 
        MatchPictureBox.BackColor = Color.Transparent;
        MatchPictureBox.BorderStyle = BorderStyle.FixedSingle;
        MatchPictureBox.InitialImage = (Image)resources.GetObject("MatchPictureBox.InitialImage");
        MatchPictureBox.Location = new Point(309, 33);
        MatchPictureBox.Name = "MatchPictureBox";
        MatchPictureBox.Size = new Size(300, 350);
        MatchPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        MatchPictureBox.TabIndex = 2;
        MatchPictureBox.TabStop = false;
        // 
        // selectImageButton
        // 
        selectImageButton.AutoSize = true;
        selectImageButton.Location = new Point(3, 389);
        selectImageButton.Name = "selectImageButton";
        selectImageButton.Size = new Size(84, 25);
        selectImageButton.TabIndex = 2;
        selectImageButton.Text = "Select Image";
        selectImageButton.Click += SelectImageButton_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(950, 450);
        Controls.Add(TLP);
        Name = "MainForm";
        Text = "MainForm";
        TLP.ResumeLayout(false);
        TLP.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)userPictureBox).EndInit();
        ((System.ComponentModel.ISupportInitialize)MatchPictureBox).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    #region Andhika's Code
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
            catch (Exception)
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
    private Label title;
    private PictureBox userPictureBox;
    private PictureBox MatchPictureBox;
    private Button selectImageButton;
}
