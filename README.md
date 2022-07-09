# PdfFormEditor
A .Net Core Windows Form that helps you add template pages to an existing PDF document using Foxit PDF SDK

It runs on .Net 6.0 runtime, you should have .Net 6 SDK or runtime installed on your system to be able to run this appliction

### Running the Windows Form

**Step 1:** Navigate to "\PdfFormEditor.sln" within the application file path.

**Step 2:** Double-click the "PdfFormEditor.sln" file to open the application using your IDE.

**Step 4:** Run the solution.

**Step 5:** Select a PDF document you'd like to work with, a "DemoDocument.pdf" sample can be found in the "/SampleDocs" file path within this solution.

**Note:** This application was built to accept PDF documents.

**Step 6:** Click on the "Add Page" button to add a template page to the document.

### Closing the Windows Form
**Step 1:** click on the "X" at the top right corner of the document to close the application.

### Checking Your PDF Template Form
**Step 1:** Check for a document with suffix "TemplatePage" in the same path as the PDF document you selected to review the PDF template page.

**Note:** The document will have a Foxit PDF SDK watermark across the generated document because it's a trial version. 