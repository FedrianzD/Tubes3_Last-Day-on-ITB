using System.Windows.Forms;
using System.Diagnostics;
using Gabungan;

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
        MatchPictureBox = new PictureBox();
        selectImageButton = new Button();
        searchButton = new Button();
        algorithmComboBox = new ComboBox();
        time = new Label();
        similarity = new Label();
        userPictureBox = new PictureBox();
        TLP.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)MatchPictureBox).BeginInit();
        ((System.ComponentModel.ISupportInitialize)userPictureBox).BeginInit();
        SuspendLayout();
        // 
        // TLP
        // 
        TLP.AllowDrop = true;
        TLP.Anchor = AnchorStyles.None;
        TLP.AutoScroll = true;
        TLP.AutoSize = true;
        TLP.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        TLP.ColumnCount = 3;
        TLP.ColumnStyles.Add(new ColumnStyle());
        TLP.ColumnStyles.Add(new ColumnStyle());
        TLP.ColumnStyles.Add(new ColumnStyle());
        TLP.ColumnStyles.Add(new ColumnStyle());
        TLP.Controls.Add(title, 1, 0);
        TLP.Controls.Add(MatchPictureBox, 1, 1);
        TLP.Controls.Add(selectImageButton, 0, 3);
        TLP.Controls.Add(searchButton, 2, 3);
        TLP.Controls.Add(algorithmComboBox, 1, 3);
        TLP.Controls.Add(time, 1, 4);
        TLP.Controls.Add(similarity, 2, 4);
        TLP.Controls.Add(userPictureBox, 0, 1);
        TLP.Location = new Point(12, 12);
        TLP.Name = "TLP";
        TLP.RowCount = 4;
        TLP.RowStyles.Add(new RowStyle());
        TLP.RowStyles.Add(new RowStyle());
        TLP.RowStyles.Add(new RowStyle());
        TLP.RowStyles.Add(new RowStyle());
        TLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        TLP.Size = new Size(917, 437);
        TLP.TabIndex = 0;
        TLP.Paint += TLP_Paint;
        // 
        // title
        // 
        title.AutoSize = true;
        title.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        title.ForeColor = Color.RoyalBlue;
        title.Location = new Point(309, 0);
        title.Name = "title";
        title.Size = new Size(524, 30);
        title.TabIndex = 0;
        title.Text = "Aplikasi C# Tugas Besar 3 Strategi Algoritma 2023/2024";
        // 
        // MatchPictureBox
        // 
        MatchPictureBox.Anchor = AnchorStyles.None;
        MatchPictureBox.BackColor = Color.Transparent;
        MatchPictureBox.BorderStyle = BorderStyle.FixedSingle;
        MatchPictureBox.InitialImage = (Image)resources.GetObject("MatchPictureBox.InitialImage");
        MatchPictureBox.Location = new Point(421, 33);
        MatchPictureBox.MaximumSize = new Size(430, 350);
        MatchPictureBox.Name = "MatchPictureBox";
        MatchPictureBox.Size = new Size(300, 350);
        MatchPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        MatchPictureBox.TabIndex = 2;
        MatchPictureBox.TabStop = false;
        // 
        // selectImageButton
        // 
        selectImageButton.AutoSize = true;
        selectImageButton.BackColor = SystemColors.Control;
        selectImageButton.Location = new Point(3, 389);
        selectImageButton.Name = "selectImageButton";
        selectImageButton.Size = new Size(84, 25);
        selectImageButton.TabIndex = 2;
        selectImageButton.Text = "Select Image";
        selectImageButton.UseVisualStyleBackColor = false;
        selectImageButton.Click += SelectImageButton_Click;
        // 
        // searchButton
        // 
        searchButton.Location = new Point(839, 389);
        searchButton.Name = "searchButton";
        searchButton.Size = new Size(75, 23);
        searchButton.TabIndex = 3;
        searchButton.Text = "Search";
        searchButton.UseVisualStyleBackColor = true;
        searchButton.Click += StartSearch;
        // 
        // algorithmComboBox
        // 
        algorithmComboBox.AutoCompleteCustomSource.AddRange(new string[] { "BM", "KMP" });
        algorithmComboBox.FormattingEnabled = true;
        algorithmComboBox.ImeMode = ImeMode.Off;
        algorithmComboBox.Items.AddRange(new object[] { "BM", "KMP" });
        algorithmComboBox.Location = new Point(309, 389);
        algorithmComboBox.MaxDropDownItems = 2;
        algorithmComboBox.Name = "algorithmComboBox";
        algorithmComboBox.Size = new Size(166, 23);
        algorithmComboBox.Sorted = true;
        algorithmComboBox.TabIndex = 1;
        algorithmComboBox.Text = "Select Algorithms to Use";
        algorithmComboBox.SelectedIndexChanged += algorithm_SelectedIndexChanged;
        // 
        // time
        // 
        time.AutoSize = true;
        time.BackColor = Color.Transparent;
        time.Location = new Point(309, 417);
        time.Name = "time";
        time.Size = new Size(77, 15);
        time.TabIndex = 1;
        time.Text = "Search Time: ";
        // 
        // similarity
        // 
        similarity.AutoSize = true;
        similarity.BackColor = Color.Transparent;
        similarity.Location = new Point(839, 417);
        similarity.Name = "similarity";
        similarity.Size = new Size(62, 15);
        similarity.TabIndex = 4;
        similarity.Text = "Similarity: ";
        // 
        // userPictureBox
        // 
        userPictureBox.Anchor = AnchorStyles.None;
        userPictureBox.BackColor = Color.Transparent;
        userPictureBox.BorderStyle = BorderStyle.FixedSingle;
        userPictureBox.InitialImage = (Image)resources.GetObject("userPictureBox.InitialImage");
        userPictureBox.Location = new Point(3, 33);
        userPictureBox.MaximumSize = new Size(300, 350);
        userPictureBox.Name = "userPictureBox";
        userPictureBox.Size = new Size(300, 350);
        userPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        userPictureBox.TabIndex = 1;
        userPictureBox.TabStop = false;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1064, 461);
        Controls.Add(TLP);
        Name = "MainForm";
        Text = "MainForm";
        TLP.ResumeLayout(false);
        TLP.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)MatchPictureBox).EndInit();
        ((System.ComponentModel.ISupportInitialize)userPictureBox).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    #region Andhika's Code
    // Load image
    private void LoadImage(PictureBox target, string imagePath)
    {
        if (!string.IsNullOrEmpty(imagePath))
        {
            try
            {
                target.Image = Image.FromFile(imagePath);
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
                target.Image = Image.FromFile("C:\\Users\\Acer\\tmp\\Tubes3_Last-Day-on-ITB\\src\\frontend\\assets\\placeholder.png");
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
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.tiff;*.tif";
        openFileDialog.Title = "Select an Image File";

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            string selectedImagePath = openFileDialog.FileName;
            send.path = selectedImagePath;
            time.Text = selectedImagePath;
            LoadImage(userPictureBox, selectedImagePath);
        }
    }

    // Change the selected algoritm
    private void algorithm_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (algorithmComboBox.SelectedIndex == 0)
        {
            send.algo = algorithmComboBox.SelectedIndex;
        }
        else if (algorithmComboBox.SelectedIndex == 1)
        {
            send.algo = algorithmComboBox.SelectedIndex;
        }
    }

    // To start the search using the selected algorithm
    private void StartSearch(object sender, EventArgs e)
    {
        if(!(send.algo == 0 || send.algo == 1))
        {
            throw new Exception("Missing Algorithm");
        }
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        (string path, string Name, string CorruptName, float percent) result  = Gabungan.Gabungan.getPathAndName(send.path, send.algo);
        stopwatch.Stop();
        TimeSpan ts = stopwatch.Elapsed;
        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
        time.Text = "Search Time: " + elapsedTime;
        afterSearch(result);
    }

    private void afterSearch((string path, string Name, string CorruptName, float percent) result)
    {
        LoadImage(MatchPictureBox, result.path);

    }

    #endregion

    private TableLayoutPanel TLP;
    private Label title;
    private PictureBox userPictureBox;
    private PictureBox MatchPictureBox;
    private Button selectImageButton;
    private ComboBox algorithmComboBox;
    private Button searchButton;
    private Label time;
    private Label similarity;
    private (string path, int algo) send = (null, -1);
}
