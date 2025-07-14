namespace System_Sample02;

public class MosaicArtView
{
    public Form form;
    private Image image;
    private ImagePopUp imagePopUp;
    Size componentSize = new Size(60, 40);
    public event PopupEventHandler ToolTipPopUp;
    public event EventHandler PanelClicked;


    public void SetImage(Image image)
    {
        this.image = image;
    }

    public void SetPanel(int resolution)
    {
        //ポップアップ情報定義
        imagePopUp = new ImagePopUp(400, 300);
        imagePopUp.OwnerDraw = true;
        imagePopUp.Popup += OnToolTipPopUp;

        //モザイクアート画像パネル情報定義
        Panel mainPanel = new Panel();
        mainPanel.Size = new Size(resolution * componentSize.Width, resolution * componentSize.Height);
        mainPanel.Location = new Point((this.form.ClientSize.Width - mainPanel.Width) / 2, (this.form.ClientSize.Height - mainPanel.Height) / 2);
        mainPanel.BackgroundImage = this.image;
        mainPanel.BackgroundImageLayout = ImageLayout.Stretch;

        //モザイクアート構成画像パネル設定処理
        for (int resolution_X = 0; resolution_X < resolution; resolution_X++)
        {
            for (int resolution_Y = 0; resolution_Y < resolution; resolution_Y++)
            {

                //モザイクアート構成画像パネル情報定義
                Panel panel = new Panel()
                {
                    Size = this.componentSize,
                    Location = new Point(resolution_X * componentSize.Width, resolution_Y * componentSize.Height)
                };
                panel.BackColor = Color.Transparent;
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.Click += OnPanelClicked;

                //モザイクアート構成画像パネルのポップアップ情報設定
                imagePopUp.SetToolTip(panel, $"{resolution * resolution_X + resolution * resolution_Y}");

                //モザイクアート画像パネルへモザイクアート構成画像パネル設定
                mainPanel.Controls.Add(panel);

            }
        }

        //画面へモザイクアート画像パネル設定
        this.form.Controls.Add(mainPanel);
    }

    public void SetPopUpImage(Image popUpImage)
    {
        this.imagePopUp.Image = popUpImage;
    }

    private void OnToolTipPopUp(object? sendar, PopupEventArgs e)
    {
        ToolTipPopUp(sendar, e);
    }

    private void OnPanelClicked(object? sendar, EventArgs e)
    {
        PanelClicked(sendar, e);
    }
    


}

