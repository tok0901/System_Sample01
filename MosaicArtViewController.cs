namespace System_Sample01;

public class MosaicArtViewController
{
    private string samplePath = @"c:\Users\toshi\Downloads\20250401平野稔喜.jpg";
    private MosaicArtView mosaicArtView;
    public MosaicArtViewController(MosaicArtView mosaicArtView)
    {
        this.mosaicArtView = mosaicArtView;
        mosaicArtView.PopUpDraw += SetPopUpImage;
        mosaicArtView.MouseEntered += DisplayPopUpImage;
        mosaicArtView.MouseLeaved += RemovePopUpImage;
    }
    public void Display()
    {
        mosaicArtView.SetPanel(25);
    }

    private void SetPopUpImage(object? sendar, PopupEventArgs e)
    {
        mosaicArtView.SetPopUpImage(Image.FromFile(samplePath));
        Size reSize = new Size(((ImagePopUp)sendar).resizeWidth, ((ImagePopUp)sendar).resizeHeight);
        e.ToolTipSize = reSize;
        Console.WriteLine("successController");
    }

    private void DisplayPopUpImage(object? sendar,EventArgs e)
    {

    }

    private void RemovePopUpImage(object? sendar,EventArgs e){

    }
    

}
