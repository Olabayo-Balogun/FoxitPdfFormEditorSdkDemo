using foxit.common;
using foxit.pdf;
using foxit.pdf.objects;
using System.Windows.Forms;
using System.Drawing;
using foxit.common.fxcrt;

namespace PdfFormEditor
{
    public partial class PdfEditor : Form
    {
        internal static PDFDoc ScannedDocument;
        internal string FilePath = "";
        internal static PDFPage Page;
        private static int pageCount;
        private static int width;
        private static int height;
        //The template name "Employee" is already embedded in the demo file, you can assign any name to your templates when using the SDK.
        private string savedTemplate = "Employee";

        public PdfEditor()
        {
            InitializeComponent();
            ScannedDocument = LoadDocument();            
        }


        private PDFDoc LoadDocument()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                Form imagesFlowLayoutPanel = new Form();
                openFileDialog.AddExtension = true;
                openFileDialog.Multiselect = false;
                openFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //For the purpose of this demo, the keys are used within the application.
                    //In a real world application, they should be treated as secret keys and protected accordingly
                    //Also note that the key is a trial one and is temporary, you're encouraged to signup to fully leverage Foxit's SDk.
                    string sn = "SXC5wsuLUEUO4OurtXCk18JnGcxp6hrx5I1X8TbpPYqwzwQ3vWxOkg==";
                    string key = "8f0YFUGMvRkN+ddwhrBxubRv+38Gz2ILMFDAylGsl9gEt83edTI+7gO6BL3Zwz4kg8iFbUBbTA0Fo1AkxlPp2d40Z8iMd8SHfgzBN4RXdnt8UAB+qfAI8OrWhPtzxO+yOivYHoRYeiFttZWqwI4X1fwdUGO37hYJVsD/EdiOZqAjvZBeI95cx5fY0CtsvH+NaMagwb6HwBNDT0dI45XNR9ycMEboU+Ia211DtwOplnZ25dOssAtBPNk21UxQnmZMQEwfr//15ssa7/OkxfZDJY1AlID9Vq8StY3iJCSn4q+t0dSoJkYM/lhZNkkn7OGPTjjx/WJ0yXN1SISFvrHgVbnLhwtVUnJ7wCz91NLIISUTmWRJRcEXu7CQmS4+QjDhBbtKAyG4urX9uNzkkn2Xbk/QN1D5Id6fYOrLxVwmjllIW7JASUgxpBRbt3qxYUuIZGxtu009yTB/NATboZS2FMngZD556sCMsT7Xb1JQwqyQ2WBRSm31qWi8g87e3MewMGaNW5T0P/NEqU619EX0RUiedSCm6ISqCeGXKqw1jJ4K56293J31qvn1DfwePzHg3O+Ga2eqHqERaNbCqtwGHpGo/DAa/r9qhipsO/W8BGfjDzRs9zvKvnjwIkoOoI/4HiQapyFG6F6rDW/C78gubmNjASjK9C9NtJ12F/qohlErie4gd8gik+L12bfrZPXs8j9pMNHFbzT50zYuRv0qt/f38goLxjKZkVS2V5do9n1ehlVf0Sq/EXzz+XX9xIjh6fL/0DykoTOXm8i/J40BOZ1e+0sDkI0vrYw6AvnFz1AKB6p4ROQyFUdmt5pRNlWRTMYxgrFf+jZ6g6LkmTd+d0+MT2MX45R2xKWF3JIiyrtZXxXplMur7dKe9B8B7rrJ8klvOnJzP8Buj4fHjxp8EFbBvscng1H5wdYrxB/PlWmH4ZY0iPn5zSP8Uauvy2osIRk/LadTjSSi3+z1XY7MkGai86eiu2EjQtlnnnEz0XWaguOJueVPErt7xGDgihqOeptG5nMwNi/S98/UX63lW/r9UNR40tN/1gGEropGpfHvDuviLWn8ANieWcxxlyL1U8D02lPoND/kfNBEsQY02ZWB+pZ2Qk3pLBuYL+YvkFabCyBXYVCp6Mjj7DYgg8jRPdtuxK5X9i4LveA9ViQI2tQcMfCsxS0YUf8bLxa4Yp7xJKfosFBACGSUU12XNaOEp9IrTkaXaqi+KTKUy5SI2JN5zD6Wjid43oDpi16eV39dLVlrRWI5MITj8rBrxg0CWyTLOwJ/um2vIqH1K9br27x0L5paRTxc9N7WIZci1gnxC8Jzjs5qwg==";
                    ErrorCode error_code = Library.Initialize(sn, key);
                    if (error_code != ErrorCode.e_ErrSuccess)
                    {
                        string message = "Unable to verify your SDK activation key";
                        string title = "Load Document Status";
                        MessageBox.Show(message, title);
                        return ScannedDocument;
                    }

                    this.FilePath = openFileDialog.FileName.ToString();
                    ScannedDocument = new PDFDoc(this.FilePath);
                    var loadDocument = ScannedDocument.LoadW("");
                    if (error_code != ErrorCode.e_ErrSuccess)
                    {
                        string message = "Unable to verify your SDK activation key";
                        string title = "Load Document Status";
                        MessageBox.Show(message, title);
                        Library.Release();
                        return ScannedDocument;
                    }
                    //The purpose of the lines of code between line 59 and 81 is to render the first page of the selected PDF document in the windows form 
                    Page = ScannedDocument.GetPage(0);
                    Page.StartParse((int)PDFPage.ParseFlags.e_ParsePageNormal, null, false);
                    width = (int)(Page.GetWidth());
                    height = (int)(Page.GetHeight());

                    Matrix2D matrix = Page.GetDisplayMatrix(0, 0, width, height, Page.GetRotation());

                    // Prepare a bitmap for rendering.
                    foxit.common.Bitmap bitmap = new foxit.common.Bitmap(width, height, foxit.common.Bitmap.DIBFormat.e_DIBRgb32);
                    System.Drawing.Bitmap sbitmap = bitmap.GetSystemBitmap();
                    Graphics draw = Graphics.FromImage(sbitmap);
                    draw.Clear(System.Drawing.Color.White);

                    // Render page
                    Renderer render = new Renderer(bitmap, false);
                    render.StartRender(Page, matrix, null);

                    // Add the bitmap to image and save the image.
                    foxit.common.Image image = new foxit.common.Image();
                    string imgPath = $"{FilePath.Split('.').First()}IndexPage.jpg";
                    image.AddFrame(bitmap);
                    image.SaveAs(imgPath);
                    DocumentImage.Image = System.Drawing.Image.FromFile(imgPath);
                }
                return ScannedDocument;
            }
            catch (Exception ex)
            {
                string message = "An error occured, please contact your tech support";
                string title = "Load Document Status";
                MessageBox.Show(message, title);
                throw;
            }
        }

        private void AddPage_Click(object sender, EventArgs e)
         {
            try
            {
                //Adding a counter helps to track how many times the "Add Page" button was clicked in order to handle the creation of multiple pages
                pageCount++;

                //"AddPageFromTemplate" is used to add a hidden page template to the document.
                //Note that the "AddPageFromTemplate" method is used once per template name, upon calling the method, the hidden template is used and the name is released.
                Page = ScannedDocument.AddPageFromTemplate(savedTemplate);
                //I hardcoded "TemplatePage" to the file path to save the new template document to a new file rather than updating the original file
                //As a personal convention, this can help in reconciling the original document with the template document
                ScannedDocument.SaveAs($"{FilePath.Split('.').First()}TemplatePage.pdf", (int)PDFDoc.SaveFlags.e_SaveFlagNoOriginal);
                int pageNumbers = ScannedDocument.GetPageCount();
                string message = $"PDF template page created!";
                string title = "PDF Template Status";
                MessageBox.Show(message, title);
            }
            catch (Exception ex)
            {
                string message = "The page template was already added";
                string title = "PDF Template Status";
                MessageBox.Show(message, title);
                throw;
            }
        }
    }
}
