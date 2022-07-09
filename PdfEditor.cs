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
        internal static PDFNameTree NameTree;
        internal PDFNameTree NewTemplateNameTree;
        private static int pageCount;
        private static int width;
        private static int height;
        private string savedTemplate = "pageTemplate";

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
                    string sn = "ot6HkKxmynOV6H7SCs0bZ1F8EwyMt8OY4Nc6hZZQaKpqedyGmwh2/w==";
                    string key = "8f0YFUNsvWkJ+VdwlrBxubTyFADaUzKsCTnsn3Str88uZqvOxGiG5Ovnvl3bGrsELZ0tlOE2mMiHkC/wMeMhm50ruBfjT39N2dV7TdoAiwDSDrfMr2MseAuwHHleoOIxy141Ld4JOWA6ukSanwSfRk2XHhT8Fb+D9RDiRMeutt9EbtXs38KdIXNuvydGhgPa1FF2UUbzuFilXtuMIDMoLYA00p2ZuEhU83fIUxfW9LGsBQ9/tyeXGhcjG1dwvU81jUDkav4v2+osM5ZVpx4T2Q6Vdm4/AOXDWgOZY7iXbm4tZs8XaTIgoUfNC8a2DcDCUHrfiOGeo+4fjAWmYgtAq82CkfeKQlgxDubRn4MLd4hq2CVbUQciGCi/z5el7dPE5SokErJPmLGqzfqUWoMWgM0d3dvcRb5O54SanMy+0Z4oNMwrepRZWbDVZHsfi0FMybETagUBo0s0cDZRwWUGJgOGJXzTVh163lyGkuqNxVv4d7Z5WpbNvm8H8ep5d5YA6+GJ5LSSnUSXZIc1wGDQUAn7SHhSbimO+OG5uhXGedrdKXpoDAXl/12OJbbkHg+IbxIlUATSNKMfMqxQJu1F10CO+R+fHByfzbou+cfMPddlpkkIVJ0tMSV+D8UQ3f0W+xC3gYp8PPG7IzSw293AuRxKj2t2P9PdXkDYcaeRkrO4M8SjwmSQkpVAbULA/eFLSidKJysW+EzelHB9m6yoLu9C0spCJeRi0V8+RN4xChMmmlVf0SifwSBhuCO4mfUKd8H5SFz+0Y6nKPFQ0i2BlYOk24CN1uSXnXmz6Hy7wtBqPah8RATUN/QiUpBKodxykH0VceCLpZo+DfgmKEu1QF7rJTJcvQCWDUOQ64iDXEhqFBReimZKX7VRi2u5ZNLYrxqkr8calhjKwr5Fz6RBKt2lgYwuiEFOJpLc7ZJjn3X+5y+fN1k3r0H9oj+sJqlaVOLaNwhFywVqjIUoqGVexql0HUcmMtY4r2HOHoJrHsIaq8xkhf/aHa5Ievc3NhyvSphG5IFIiuWMMB1zqMbCaim1IQjdCJMUJN+jPDTLgFbar2E6nPUT0dWlWcxwt6J2+0IphRUpEQYbeiMB1USPrW0t5Odzayf5o47kZCPyqsCHh/FWYV0grLa8rfYgg1RIxsppxK6jd9DfHT6Pr70YzG9r9j03c3wisCDZusYmEoSSe1B2l+ICI/UNBVgTtsiEp9IxTBqMOIX8wHO7w8xMEwwIOR65ZMLGqXwjPrYKdrA3JBTEUw/07aUvarLFhFE77UvvLyp/amWmuORahjaX1RbPsqkNoCpDjDqC0edu30UnIYNLV2JqIg==";
                    ErrorCode error_code = Library.Initialize(sn, key);
                    if (error_code != ErrorCode.e_ErrSuccess)
                    {
                        return ScannedDocument;
                    }

                    this.FilePath = openFileDialog.FileName.ToString();
                    ScannedDocument = new PDFDoc(this.FilePath);
                    var loadDocument = ScannedDocument.LoadW("");
                    if (error_code != ErrorCode.e_ErrSuccess)
                    {
                        Library.Release();
                        return ScannedDocument;
                    }
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
                    documentImage.Image = System.Drawing.Image.FromFile(imgPath);
                }
                return ScannedDocument;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void AddPage_Click(object sender, EventArgs e)
         {
            try
            {
                //Adding a counter helps to track how many times the "Add Page" button was clicked in order to handle the creation of multiple pages
                pageCount++;
                
                if (pageCount < 2)
                {
                    // "Page" below is used to retrieve specific page, in this case, the first page.
                    Page = ScannedDocument.GetPage(0);
                   
                    //"PDFNameTree" is used when converting creating a template out of a document. 
                    NameTree = new PDFNameTree(ScannedDocument, PDFNameTree.Type.e_Pages);

                    //The first input parameter "pageTemplate" is used to give the template a name.
                    //The template name can be used to subsequently call and manipulate the PDF document template.
                    NameTree.Add(savedTemplate, Page.GetDict());
                    //It's important to hide the page before you can use "HidePageTemplate" to add the page to the document.
                    ScannedDocument.HidePageTemplate(savedTemplate);
                    //"AddPageFromTemplate" is used to add a hidden page template to the document.
                    Page = ScannedDocument.AddPageFromTemplate(savedTemplate);
                    //I hardcoded "TemplatePage" to the file path to save the new template document to a new file rather than updating the original file
                    //As a personal convention, this can help in reconciling the original document with the template document
                    ScannedDocument.SaveAs($"{FilePath.Split('.').First()}TemplatePage.pdf", (int)PDFDoc.SaveFlags.e_SaveFlagNoOriginal);
                    int pageNumbers = ScannedDocument.GetPageCount();
                }
                else
                {
                    //The "pageIndexPosition" is used to get the location of the first template page (which changes as new pages are added).
                    int pageIndexPosition = pageCount - 2;                    
                    Page = ScannedDocument.GetPage(pageIndexPosition);
                    NewTemplateNameTree = new PDFNameTree(ScannedDocument, PDFNameTree.Type.e_Pages);

                    //The "savedTemplate{pageCount}" is used to give the template a dynamic name the more the user adds pages to the document.
                    NewTemplateNameTree.Add($"savedTemplate{pageCount}", Page.GetDict());
                    //Inserting a new page is needed as it'll be the blank page that the template will be added to
                    Page = ScannedDocument.InsertPage(2, width, height);
                    ScannedDocument.HidePageTemplate($"savedTemplate{pageCount}");

                    Page = ScannedDocument.AddPageFromTemplate($"savedTemplate{pageCount}");
                    ScannedDocument.SaveAs($"{FilePath.Split('.').First()}TemplatePage.pdf", (int)PDFDoc.SaveFlags.e_SaveFlagNoOriginal);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}