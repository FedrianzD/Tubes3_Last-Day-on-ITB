using Gabungan;
using Database_Operation;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text;

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
        Result = new Label();
        statusStrip = new StatusStrip();
        Status = new ToolStripStatusLabel();
        TLP.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)MatchPictureBox).BeginInit();
        ((System.ComponentModel.ISupportInitialize)userPictureBox).BeginInit();
        statusStrip.SuspendLayout();
        SuspendLayout();
        // 
        // TLP
        // 
        TLP.Anchor = AnchorStyles.None;
        TLP.AutoScroll = true;
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
        TLP.Controls.Add(Result, 2, 1);
        TLP.Location = new Point(0, 0);
        TLP.Margin = new Padding(0);
        TLP.Name = "TLP";
        TLP.RowCount = 4;
        TLP.RowStyles.Add(new RowStyle());
        TLP.RowStyles.Add(new RowStyle());
        TLP.RowStyles.Add(new RowStyle());
        TLP.RowStyles.Add(new RowStyle());
        TLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        TLP.Size = new Size(1256, 437);
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
        time.Size = new Size(137, 15);
        time.TabIndex = 1;
        time.Text = "Search Time: (hh:mm:ss)";
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
        // Result
        // 
        Result.Anchor = AnchorStyles.None;
        Result.AutoSize = true;
        Result.CausesValidation = false;
        Result.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        Result.Location = new Point(839, 103);
        Result.Name = "Result";
        Result.Size = new Size(414, 209);
        Result.TabIndex = 5;
        Result.Text = resources.GetString("Result.Text");
        // 
        // statusStrip
        // 
        statusStrip.Items.AddRange(new ToolStripItem[] { Status });
        statusStrip.Location = new Point(0, 449);
        statusStrip.Name = "statusStrip";
        statusStrip.Size = new Size(1484, 22);
        statusStrip.TabIndex = 7;
        statusStrip.Text = "statusStrip";
        // 
        // Status
        // 
        Status.ActiveLinkColor = SystemColors.Highlight;
        Status.BackColor = SystemColors.ActiveBorder;
        Status.DisplayStyle = ToolStripItemDisplayStyle.Text;
        Status.ForeColor = SystemColors.Highlight;
        Status.Name = "Status";
        Status.Size = new Size(69, 17);
        Status.Text = "NOT READY";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        ClientSize = new Size(1484, 471);
        Controls.Add(statusStrip);
        Controls.Add(TLP);
        Name = "MainForm";
        Text = "Aplikasi C# Tugas Besar 3 Strategi Algoritma 2023/2024";
        TLP.ResumeLayout(false);
        TLP.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)MatchPictureBox).EndInit();
        ((System.ComponentModel.ISupportInitialize)userPictureBox).EndInit();
        statusStrip.ResumeLayout(false);
        statusStrip.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    #region Functions
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
                MessageBox.Show(new StringBuilder("Error loading image: ").Append(ex.Message).ToString());
            }
        }
        else
        {
            try
            {
                target.Image = Image.FromFile(@"C:\Users\Acer\tmp\Tubes3_Last-Day-on-ITB\src\frontend\assets\placeholder.png");
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
            Status.Text = "READY";
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
        if (!(send.algo == 0 || send.algo == 1))
        {
            MessageBox.Show("Missing Algorithm");
            return;
        }
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        try
        {
            (string path, string Name, string CorruptName, float percent) result = Gabungan.Gabungan.getPathAndName(send.path, send.algo);
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00} ", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            time.Text = new StringBuilder("Search Time: ").Append(elapsedTime).ToString();
            showResult(result);
        }
        catch (Exception ex)
        {
            MessageBox.Show(new StringBuilder("Error: ").Append(ex.Message).ToString());
        }
    }

    private void showResult((string path, string Name, string CorruptName, float percent) result)
    {
        LoadImage(MatchPictureBox, result.path);
        similarity.Text = new StringBuilder("Similarity: ").Append(result.percent + "%").ToString();
        (string NIK, string nama, string tempat_lahir, string tanggal_lahir, string jenis_kelamin, string golongan_darah, string alamat, string agama, string status_perkawinan, string pekerjaan, string kewarganegaraan) query = Database_Operation.DB.SearchDatabaseWithName(result.Name);
        Result.Text = new StringBuilder($"NIK               :   {query.NIK}\n").Append(
                                        $"Nama              :   {result.Name}\n").Append(
                                        $"Tempat Lahir      :   {query.tempat_lahir}\n").Append(
                                        $"Tanggal Lahir     :   {query.tanggal_lahir}\n").Append(
                                        $"Jenis Kelamin     :   {query.jenis_kelamin}\n").Append(
                                        $"Golongan Darah    :   {query.golongan_darah}\n").Append(
                                        $"Alamat            :   {query.alamat}\n").Append(
                                        $"Agama             :   {query.agama}\n").Append(
                                        $"Status Perkawinan :   {query.status_perkawinan}\n").Append(
                                        $"Pekerjaan         :   {query.pekerjaan}\n").Append(
                                        $"Kewarganegaraan   :   {query.kewarganegaraan}\n")
                                        .ToString();
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
    private Label Result;
    private ToolStripStatusLabel Status;
    private StatusStrip statusStrip;
}
