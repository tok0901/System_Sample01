namespace System_Sample02;

public class MosaicArtViewController
{
    MosaicArtView view;
    private string samplePath =  @"C:\Users\12811104\Documents\SystemMosaicArtPictureViewr\Sample_System01\Template\sample2.jpg";
    private string componentPath = @"C:\Users\12811104\Documents\SystemMosaicArtPictureViewr\Sample_System01\Template\sample1.jpg";

    public MosaicArtViewController(Form form,MosaicArtView mosaicArtView)
    {
        this.view = mosaicArtView;
        view.form = form;
        view.ToolTipPopUp += SetImage;
        view.SetImage(Image.FromFile(samplePath));
        view.SetPanel(10);
    }

    private void SetImage(object? sendar, PopupEventArgs e)
    {
        view.SetPopUpImage( Image.FromFile(componentPath));
    }
}
