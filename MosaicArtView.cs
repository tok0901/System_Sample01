namespace System_Sample01;

public class MosaicArtView
{
    private Form form;
    private Image image;
    private Image popUpImage;
    private Size componentSize = new Size(60,40);
    public event EventHandler PanelClicked;
    public event PopupEventHandler PopUpDraw;
    public event EventHandler MouseEntered;
    public event EventHandler MouseLeaved;
    private string samplePath = @"c:\Users\toshi\Downloads\20250401平野稔喜.jpg";


    public MosaicArtView(Form form)
    { 
        this.form = form;

    }

    public void SetImage(Image image)
    {
        this.image = image;
    }
    public void SetPanel(int resolution)
    {

        //mainPanel情報定義
        Panel mainPanel = new Panel();
        mainPanel.Size = new Size(componentSize.Width*resolution,componentSize.Height*resolution);
        //mainPanel.Dock = DockStyle.Fill;

        this.form.Controls.Add(mainPanel);
        
        PictureBox pictureBox = new PictureBox();
        pictureBox.Image = Image.FromFile(samplePath);
        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBox.Dock = DockStyle.Fill;

        mainPanel.Controls.Add(pictureBox);

        //ポップアップ情報定義
        ImagePopUp imagePopUp = new ImagePopUp();
        imagePopUp.Image = this.popUpImage;
        imagePopUp.Tag = resolution;
        imagePopUp.Popup += OnPopUpDraw;

        for (int resolution_X = 0; resolution_X < resolution; resolution_X++)
        {
            for (int resolution_Y = 0; resolution_Y < resolution; resolution_Y++)
            {

                //subPanel情報定義
                TransparentPanel subPanel = new TransparentPanel();
                Rectangle rectangle = new Rectangle(new Point(resolution_X * 60, resolution_Y * 40),componentSize);
                subPanel.Bounds = rectangle;
                subPanel.BringToFront();
                // subPanel.Size = componentSize;
                // subPanel.Location = new Point(resolution_X * 60, resolution_Y * 40);
                //subPanel.BackColor = Color.Transparent;
                subPanel.BorderStyle = BorderStyle.FixedSingle;
                subPanel.Click += PanelClicked;
                subPanel.MouseEnter += OnMouseEntered;
                subPanel.MouseLeave += OnMouseLeaved;


                // //ポップアップ情報定義
                // ImagePopUp imagePopUp = new ImagePopUp();
                // imagePopUp.Image = this.popUpImage;
                // imagePopUp.Tag = resolution * resolution_Y + resolution_X;
                // imagePopUp.Popup += OnPopUpDraw;


                //Panelのポップアップ情報設定
                imagePopUp.SetToolTip(subPanel, $"{imagePopUp.Tag}");

                //FormのPanel設定
                mainPanel.Controls.Add(subPanel);
                //this.Dock = DockStyle.Fill;
            }
        }

       

        

    }
    private void OnPanelClicked(object? sender, EventArgs e)
    {
        PanelClicked(sender, e);
    }
    
    public void SetPopUpImage(Image popUpImage)
    {
        this.popUpImage = popUpImage;
    }

    public void OnPopUpDraw(object? sendar, PopupEventArgs e)
    {
        PopUpDraw(sendar, e);
    }

    public void OnMouseEntered(object? sendar,EventArgs e)
    {
        MouseEntered(sendar,e);
    }

    public void OnMouseLeaved(object? sendar,EventArgs e)
    {
        MouseLeaved(sendar,e);
    }

   
}
