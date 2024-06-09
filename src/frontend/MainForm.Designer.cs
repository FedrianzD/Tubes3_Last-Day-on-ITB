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
        selectImageButton = new Button();
        searchButton = new Button();
        algorithmComboBox = new ComboBox();
        similarity = new Label();
        userPictureBox = new PictureBox();
        Result = new Label();
        time = new Label();
        MatchPictureBox = new PictureBox();
        statusStrip = new StatusStrip();
        Status = new ToolStripStatusLabel();
        TLP.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)userPictureBox).BeginInit();
        ((System.ComponentModel.ISupportInitialize)MatchPictureBox).BeginInit();
        statusStrip.SuspendLayout();
        SuspendLayout();
        // 
        // TLP
        // 
        TLP.Anchor = AnchorStyles.None;
        TLP.AutoSize = true;
        TLP.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        TLP.ColumnCount = 3;
        TLP.ColumnStyles.Add(new ColumnStyle());
        TLP.ColumnStyles.Add(new ColumnStyle());
        TLP.ColumnStyles.Add(new ColumnStyle());
        TLP.Controls.Add(title, 1, 0);
        TLP.Controls.Add(selectImageButton, 0, 3);
        TLP.Controls.Add(searchButton, 2, 3);
        TLP.Controls.Add(algorithmComboBox, 1, 3);
        TLP.Controls.Add(similarity, 2, 4);
        TLP.Controls.Add(userPictureBox, 0, 1);
        TLP.Controls.Add(Result, 2, 1);
        TLP.Controls.Add(time, 1, 4);
        TLP.Controls.Add(MatchPictureBox, 1, 1);
        TLP.Location = new Point(10, 0);
        TLP.Name = "TLP";
        TLP.RowCount = 4;
        TLP.RowStyles.Add(new RowStyle());
        TLP.RowStyles.Add(new RowStyle());
        TLP.RowStyles.Add(new RowStyle());
        TLP.RowStyles.Add(new RowStyle());
        TLP.RowStyles.Add(new RowStyle());
        TLP.Size = new Size(1307, 436);
        TLP.TabIndex = 0;
        TLP.Paint += TLP_Paint;
        // 
        // title
        // 
        title.AutoSize = true;
        title.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
        title.ForeColor = Color.RoyalBlue;
        title.Location = new Point(309, 0);
        title.Name = "title";
        title.Size = new Size(611, 30);
        title.TabIndex = 0;
        title.Text = "Aplikasi C# Tugas Besar 3 Strategi Algoritma 2023/2024";
        // 
        // selectImageButton
        // 
        selectImageButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        selectImageButton.AutoSize = true;
        selectImageButton.BackColor = SystemColors.Control;
        selectImageButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        selectImageButton.Location = new Point(3, 389);
        selectImageButton.Name = "selectImageButton";
        selectImageButton.Size = new Size(92, 27);
        selectImageButton.TabIndex = 2;
        selectImageButton.Text = "Select Image";
        selectImageButton.UseVisualStyleBackColor = false;
        selectImageButton.Click += SelectImageButton_Click;
        // 
        // searchButton
        // 
        searchButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        searchButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        searchButton.Location = new Point(926, 389);
        searchButton.Name = "searchButton";
        searchButton.Size = new Size(75, 27);
        searchButton.TabIndex = 3;
        searchButton.Text = "Search";
        searchButton.UseVisualStyleBackColor = true;
        searchButton.Click += StartSearch;
        // 
        // algorithmComboBox
        // 
        algorithmComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        algorithmComboBox.AutoCompleteCustomSource.AddRange(new string[] { "BM", "KMP" });
        algorithmComboBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        algorithmComboBox.FormattingEnabled = true;
        algorithmComboBox.ImeMode = ImeMode.Off;
        algorithmComboBox.Items.AddRange(new object[] { "BM", "KMP" });
        algorithmComboBox.Location = new Point(309, 389);
        algorithmComboBox.MaxDropDownItems = 2;
        algorithmComboBox.Name = "algorithmComboBox";
        algorithmComboBox.Size = new Size(166, 25);
        algorithmComboBox.Sorted = true;
        algorithmComboBox.TabIndex = 1;
        algorithmComboBox.Text = "Select Algorithms to Use";
        algorithmComboBox.SelectedIndexChanged += algorithm_SelectedIndexChanged;
        // 
        // similarity
        // 
        similarity.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        similarity.AutoSize = true;
        similarity.BackColor = Color.Transparent;
        similarity.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        similarity.ForeColor = Color.DarkOrange;
        similarity.Location = new Point(926, 419);
        similarity.Name = "similarity";
        similarity.Size = new Size(67, 17);
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
        Result.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        Result.AutoSize = true;
        Result.CausesValidation = false;
        Result.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        Result.Location = new Point(926, 33);
        Result.Margin = new Padding(3);
        Result.Name = "Result";
        Result.Size = new Size(378, 350);
        Result.TabIndex = 5;
        Result.Text = resources.GetString("Result.Text");
        Result.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // time
        // 
        time.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        time.AutoSize = true;
        time.BackColor = Color.Transparent;
        time.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        time.ForeColor = SystemColors.MenuHighlight;
        time.Location = new Point(309, 419);
        time.Name = "time";
        time.Size = new Size(148, 17);
        time.TabIndex = 1;
        time.Text = "Search Time: (hh:mm:ss)";
        // 
        // MatchPictureBox
        // 
        MatchPictureBox.Anchor = AnchorStyles.None;
        MatchPictureBox.BackColor = Color.Transparent;
        MatchPictureBox.BorderStyle = BorderStyle.FixedSingle;
        MatchPictureBox.InitialImage = (Image)resources.GetObject("MatchPictureBox.InitialImage");
        MatchPictureBox.Location = new Point(464, 33);
        MatchPictureBox.MaximumSize = new Size(300, 350);
        MatchPictureBox.Name = "MatchPictureBox";
        MatchPictureBox.Size = new Size(300, 350);
        MatchPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        MatchPictureBox.TabIndex = 2;
        MatchPictureBox.TabStop = false;
        // 
        // statusStrip
        // 
        statusStrip.Items.AddRange(new ToolStripItem[] { Status });
        statusStrip.Location = new Point(0, 449);
        statusStrip.Name = "statusStrip";
        statusStrip.Size = new Size(1404, 22);
        statusStrip.TabIndex = 7;
        statusStrip.Text = "statusStrip";
        // 
        // Status
        // 
        Status.ActiveLinkColor = SystemColors.Highlight;
        Status.BackColor = SystemColors.Control;
        Status.DisplayStyle = ToolStripItemDisplayStyle.Text;
        Status.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        Status.ForeColor = Color.Brown;
        Status.Name = "Status";
        Status.Size = new Size(77, 17);
        Status.Text = "NOT READY";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        ClientSize = new Size(1404, 471);
        Controls.Add(statusStrip);
        Controls.Add(TLP);
        Name = "MainForm";
        Text = "Aplikasi C# Tugas Besar 3 Strategi Algoritma 2023/2024";
        PaddingChanged += forceSizeLocationRecalc;
        DpiChangedBeforeParent += forceSizeLocationRecalc;
        DpiChangedAfterParent += forceSizeLocationRecalc;
        Resize += forceSizeLocationRecalc;
        TLP.ResumeLayout(false);
        TLP.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)userPictureBox).EndInit();
        ((System.ComponentModel.ISupportInitialize)MatchPictureBox).EndInit();
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
        forceSizeLocationRecalc(null, null);
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
            time.Text = new StringBuilder("Path: ").Append(selectedImagePath).ToString();
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
        if(send.path == null)
        {
            MessageBox.Show("Please select an image!");
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
        forceSizeLocationRecalc(null, null);
    }

    private void forceSizeLocationRecalc(object sender, EventArgs e)
    {
        Width = TLP.Width + 100;
        Height = TLP.Height + statusStrip.Height + 50;
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
