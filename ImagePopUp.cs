namespace System_Sample01;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class ImagePopUp : ToolTip
{

    public Image Image;
    public int resizeWidth = 500;
    public int resizeHeight = 600;
    public ImagePopUp()
    {
        this.OwnerDraw = true;
        this.InitialDelay = 1;
        this.AutoPopDelay = int.MaxValue;
        this.Popup+= OnPopUpImage;
        this.Draw += OnDrawImage;
        Console.WriteLine("Constracter");
       
    }

    public void OnDrawImage(object? sendar,DrawToolTipEventArgs e )
    {

        Size reSize = new Size(resizeWidth,resizeHeight);
        Point location = new Point(0,0);
        Rectangle rectangle = new Rectangle(location,reSize);

        //リサイズのための描画オプション設定
        e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

        Console.WriteLine($"{this.Image}");

        e.Graphics.DrawImage(this.Image, rectangle);

        Console.WriteLine($"X:{resizeWidth},Y:{resizeHeight}");

    }

    public void OnPopUpImage(object? sendar,PopupEventArgs e)
    {
        //e.ToolTipSize = new Size(resizeWidth, resizeHeight);
        Console.WriteLine("success_ImagePopUp");
    }

}

