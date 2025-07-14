namespace System_Sample02;

public class ImagePopUp : ToolTip
{
    public Image Image;
    public int resizeWidth;
    public int resizeHeight;

    public ImagePopUp(int Width, int Height)
    {
        this.OwnerDraw = true;
        this.resizeWidth = Width;
        this.resizeHeight = Height;
        this.InitialDelay = 1;

        this.Draw += new DrawToolTipEventHandler(OnDrawImage);
        this.Popup += new PopupEventHandler(OnPopUp);
    }

    public void OnDrawImage(object? sendar, DrawToolTipEventArgs e)
    {
        e.Graphics.DrawImage(this.Image, new Rectangle(new Point(0, 0), new Size(resizeWidth, resizeHeight)));
    }

    public void OnPopUp(object? sendar, PopupEventArgs e)
    {
        e.ToolTipSize = new Size(resizeWidth, resizeHeight);
    }
}
