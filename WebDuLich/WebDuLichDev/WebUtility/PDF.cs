using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace WebDuLichDev.WebUtility
{
    internal class PDFSettings
    {
        public static int MarginLeft { get { return 60; } }
        public static int MarginRight { get { return 60; } }
        public static int MarginTop { get { return 100; } }
        public static int MarginBottom { get { return 50; } }
        public static int LogoScale { get { return 27; } }

    }
    public class PDFFactory
    {
        public static void GeneratePDF(string Html, string FileName)
        {
            var template = new PDFTemplate();

            Document doc = new Document(PageSize.A4, PDFSettings.MarginLeft, PDFSettings.MarginRight, PDFSettings.MarginTop, PDFSettings.MarginBottom);
            
            // Change the content type to application/pdf !Important
            HttpContext.Current.Response.ContentType = "application/pdf";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + FileName + ".pdf");

            // Get Instance of pdfWriter to be able to create the document in the OutputStream
            PdfWriter writer = PdfWriter.GetInstance(doc, HttpContext.Current.Response.OutputStream);

            writer.PageEvent = template;
            doc.Open();
            parseHTML(doc, Html);
            doc.Close();
            HttpContext.Current.Response.Flush();
        }

        private static void parseHTML(Document doc, string html)
        {
            HTMLWorker htmlWorker = new HTMLWorker(doc);
            htmlWorker.Style = GenerateStyleSheet();
            string html_clear = html.Replace("\r", "").Replace("\n", "").Replace("  ", "");
            //Try adding source strings for each image in content
            string tempPostContent = getImage(html_clear);       
            StringReader reader = new StringReader(tempPostContent);

            htmlWorker.Parse(reader);
            doc.AddSubject("PDF-DuLichVietNam");
            doc.AddKeywords("KhoaLuanTotNghiep");
            doc.AddCreator("An-Hau Team @2013-2014");

        }
        public static string getImage(string input)
        {
            if (input == null)
                return string.Empty;
            string tempInput = input;
            string pattern = @"<img(.|\n)+?>";
            string src = string.Empty;
            HttpContext context = HttpContext.Current;

            //Change the relative URL's to absolute URL's for an image, if any in the HTML code.
            foreach (Match m in Regex.Matches(input, pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline |

            RegexOptions.RightToLeft))
            {
                if (m.Success)
                {
                    string tempM = m.Value;
                    string pattern1 = "src=[\'|\"](.+?)[\'|\"]";
                    Regex reImg = new Regex(pattern1, RegexOptions.IgnoreCase | RegexOptions.Multiline);
                    Match mImg = reImg.Match(m.Value);

                    if (mImg.Success)
                    {
                        src = mImg.Value.ToLower().Replace("src=", "").Replace("\"", "");

                        if (src.ToLower().Contains("http://") == false)
                        {
                            //Insert new URL in img tag
                            src = "src=\"" + context.Request.Url.Scheme + "://" +
                                context.Request.Url.Authority + src + "\"";
                            try
                            {
                                tempM = tempM.Remove(mImg.Index, mImg.Length);
                                tempM = tempM.Insert(mImg.Index, src);

                                //insert new url img tag in whole html code
                                tempInput = tempInput.Remove(m.Index, m.Length);
                                tempInput = tempInput.Insert(m.Index, tempM);
                            }
                            catch (Exception e)
                            {

                            }
                        }
                    }
                }
            }
            return tempInput;
        }

        string getSrc(string input)
        {
            string pattern = "src=[\'|\"](.+?)[\'|\"]";
            System.Text.RegularExpressions.Regex reImg = new System.Text.RegularExpressions.Regex(pattern,
                System.Text.RegularExpressions.RegexOptions.IgnoreCase |
                System.Text.RegularExpressions.RegexOptions.Multiline);
            System.Text.RegularExpressions.Match mImg = reImg.Match(input);
            if (mImg.Success)
            {
                return mImg.Value.Replace("src=", "").Replace("\"", ""); ;
            }

            return string.Empty;
        }
        private static StyleSheet GenerateStyleSheet()
        {
            FontFactory.Register(Path.Combine(HttpContext.Current.Server.MapPath("/Content/Fonts/"), "times.ttf"), "Arial");
            FontFactory.Register(Path.Combine(HttpContext.Current.Server.MapPath("/Content/Fonts/"), "times.ttf"));
            FontFactory.Register(Path.Combine(HttpContext.Current.Server.MapPath("/Content/Fonts/"), "times.ttf"));

            StyleSheet css = new StyleSheet();

            css.LoadTagStyle("body", "face", "Arial");
            css.LoadTagStyle("body", "encoding", "Identity-H");
            css.LoadTagStyle("body", "size", "13pt");
            css.LoadTagStyle("h1", "size", "30pt");
            css.LoadTagStyle("h1", "style", "line-height:30pt;font-weight:bold;");
            css.LoadTagStyle("h2", "size", "22pt");
            css.LoadTagStyle("h2", "style", "line-height:30pt;font-weight:bold;margin-top:5pt;margin-bottom:12pt;");
            css.LoadTagStyle("h3", "size", "15pt");
            css.LoadTagStyle("h3", "style", "line-height:25pt;font-weight:bold;margin-top:1pt;margin-bottom:15pt;");
            css.LoadTagStyle("h4", "size", "13pt");
            css.LoadTagStyle("h4", "style", "line-height:23pt;margin-top:1pt;margin-bottom:15pt;");
            css.LoadTagStyle("hr", "width", "100%");
            css.LoadTagStyle("a", "style", "text-decoration:underline;");
            css.LoadTagStyle(HtmlTags.HEADERCELL, HtmlTags.BORDERWIDTH, "0.5");
            css.LoadTagStyle(HtmlTags.HEADERCELL, HtmlTags.BORDERCOLOR, "#333");
            css.LoadTagStyle(HtmlTags.HEADERCELL, HtmlTags.BACKGROUNDCOLOR, "#cccccc");
            css.LoadTagStyle(HtmlTags.CELL, HtmlTags.BACKGROUNDCOLOR, "#EFEFEF");
            css.LoadTagStyle(HtmlTags.CELL, HtmlTags.BORDERWIDTH, "0.5");
            css.LoadTagStyle(HtmlTags.CELL, HtmlTags.BORDERCOLOR, "#333");
            return css;
        }

    }

    internal class PDFTemplate : iTextSharp.text.pdf.PdfPageEventHelper
    {
        float TEXTSIZE = 13;
        public PdfTemplate total;
        //I create a font object to use within my footer
        protected Font FooterFont
        {
            get
            {
                String fontFile = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/Fonts/"), "times.ttf");
                BaseFont baseFont = BaseFont.CreateFont(fontFile, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                Font font = new Font(baseFont,7);
                return font;
            }
        }
        protected Font HeaderFont
        {
            get
            {
                String fontFile = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/Fonts/"), "times.ttf");
                BaseFont baseFont = BaseFont.CreateFont(fontFile, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                Font font = new Font(baseFont,TEXTSIZE);
                return font;
            }
        }

        //I create a font object to use within my footer
        protected BaseFont BaseFnt
        {
            get
            {
                return BaseFont.CreateFont(Path.Combine(HttpContext.Current.Server.MapPath("/Content/Fonts/"), "times.ttf"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            }
        }

        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            total = writer.DirectContent.CreateTemplate(100, 100);
            total.BoundingBox = new Rectangle(-20, -20, 100, 100);
        }

        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            total.BeginText();
            total.SetFontAndSize(BaseFnt, TEXTSIZE);
            total.SetTextMatrix(0, 0);
            int pageNumber = writer.PageNumber - 1;
            total.ShowText("(" + pageNumber + ")");
            total.EndText();
        }

        //override the OnStartPage event handler to add our header
        public override void OnStartPage(PdfWriter writer, Document doc)
        {
            PdfContentByte cb = writer.DirectContent;
            cb.SaveState();
            string text = writer.PageNumber.ToString();
            float textBase = doc.Top;

            //Sidnummrering
            cb.BeginText();
            cb.SetFontAndSize(BaseFnt, TEXTSIZE);
            float adjust = BaseFnt.GetWidthPoint("0", TEXTSIZE);
            cb.SetTextMatrix(doc.Right - TEXTSIZE - adjust, textBase + 40);
            cb.ShowText(text);
            cb.EndText();

            //Datum
            cb.BeginText();
            cb.SetFontAndSize(BaseFnt, TEXTSIZE);
            cb.SetTextMatrix(doc.Right - 90, textBase + 20);
            // cb.NewlineText();
            cb.ShowText("Date: " + DateTime.Now.ToShortDateString());
            cb.EndText();

            cb.AddTemplate(total, doc.Right - adjust, textBase + 40);
            cb.RestoreState();

            PdfPTable headerTbl = new PdfPTable(1);
            headerTbl.TotalWidth = doc.PageSize.Width - (PDFSettings.MarginRight + PDFSettings.MarginLeft);

            Image logo = Image.GetInstance(HttpContext.Current.Server.MapPath("/Data/Avatar/City/Logo_TimelessCharm_V.png"));
            logo.ScalePercent(PDFSettings.LogoScale);

            //create instance of a table cell to contain the logo
            PdfPCell cell = new PdfPCell(logo);
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.PaddingLeft = PDFSettings.MarginLeft;
            cell.PaddingTop = PDFSettings.MarginTop;
            cell.Border = 0;
            headerTbl.AddCell(cell);

            headerTbl.WriteSelectedRows(0, -1, 0, (doc.PageSize.Height + PDFSettings.MarginBottom), writer.DirectContent);

        }

        public override void OnEndPage(PdfWriter writer, Document doc)
        {

            PdfPTable footerTbl = new PdfPTable(2);
            //set the width of the table to be the same as the document
            footerTbl.TotalWidth = doc.PageSize.Width - (PDFSettings.MarginRight + PDFSettings.MarginLeft);

            Paragraph para = new Paragraph("Team:", FooterFont);
            para.Add(Environment.NewLine);
            para.Add("Võ Tiến An - Trương Công Hậu");
            para.Add(Environment.NewLine);
            para.Add("@2013 - PDF Document");
            PdfPCell cell = new PdfPCell(para);
            cell.Border = Rectangle.TOP_BORDER;
            cell.BorderWidthTop = .5f;
            // cell.PaddingLeft = 20;
            footerTbl.AddCell(cell);

            // 2nd cell 
            para = new Paragraph("Việt Nam Vẻ Đẹp Bất Tận", FooterFont);
            para.Add(Environment.NewLine);
            para.Add("Ứng Dụng Du Lịch");
            para.Add(Environment.NewLine);
            para.Add("VietNam");
            cell = new PdfPCell(para);
            cell.Border = Rectangle.TOP_BORDER;
            cell.BorderWidthTop = .5f;
            footerTbl.AddCell(cell);

           
            //write the rows out to the PDF output stream.
            footerTbl.WriteSelectedRows(0, -1, PDFSettings.MarginLeft, (PDFSettings.MarginBottom), writer.DirectContent);
        }

        
       
    }

}