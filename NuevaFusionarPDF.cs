using iText.Kernel.Pdf;
using iText.Kernel.Utils; // Para PdfMerger

﻿namespace NuevaLibPDF
{
public class NuevaFusionarPDF
{

  public List<string> FilesPdf{get;set;}
  public string OutputPdf{get;set;}
  
  public NuevaFusionarPDF(List<string> filesPdf, string outputPdf)
  {
   this.FilesPdf=filesPdf;
   this.OutputPdf=outputPdf;
  }

 public void MergeFiles()
    {
        using (PdfDocument pdfDoc = new PdfDocument(new PdfWriter(OutputPdf)))
        {
            PdfMerger merger = new PdfMerger(pdfDoc);

            foreach (string file in FilesPdf)
            {
                PdfDocument srcDoc = new PdfDocument(new PdfReader(file));
                merger.Merge(srcDoc, 1, srcDoc.GetNumberOfPages());
                srcDoc.Close();
            }
        }
     }
}
}
