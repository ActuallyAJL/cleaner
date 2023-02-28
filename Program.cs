using iTextSharp.text.pdf;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    public static void Main(string[] args)
    {
        List<string> filelist = args.ToList();

        foreach (var filename in filelist)
        {
            PdfReader pdf = new PdfReader(filename);

            // string invoiceNumberText = "";
            // string invoiceDateText = "";
            // string headerText = "";
            // string billToPartyText = "";
            // string billOfLadingText = "";
            // string termsText = "";
            // string shipperDollarValueText = "";
            // string consigneeDollarValueAndDescriptionText = "";
            // string totalDollarValueText = "";

            Console.WriteLine("\n +++++ START DOCUMENT +++++ " + filename + "\n");
            for (int page = 1; page <= pdf.NumberOfPages; page++)
            {
                Console.WriteLine("\n ----- START PAGE ----- " + page + "\n");
                var pdfPageText = iTextSharp.text.pdf.parser.PdfTextExtractor.GetTextFromPage(pdf, page);
                Console.WriteLine(pdfPageText);
                Console.WriteLine("\n ----- END PAGE ----- " + page + "\n");

                // invoiceNumberText = new Regex(@"INVOICE DATE[\n\r](?<INVOICE_NUMBER_REG>[0-9]{8,8})").Match(pdfPageText).Groups["INVOICE_NUMBER_REG"].Value.ToUpper();
                // invoiceDateText = new Regex(@"INVOICE DATE[\n\r][0-9]{8,8}\s(?<INVOICE_DATE_REG>\d{1,2}/\d{1,2}/\d{4,4})").Match(pdfPageText).Groups["INVOICE_DATE_REG"].Value.ToUpper();
                // headerText = new Regex(@"\d{1,2}/\d{1,2}/\d{4,4}[\r\n](?<HEADER_REG>.*(?=[\r\n]))").Match(pdfPageText).Groups["HEADER_REG"].Value.ToUpper();
                // billToPartyText = new Regex(@"BILL TO:[\n\r](?<BILL_TO_PARTY_REG>.*(?=[\r\n]))").Match(pdfPageText).Groups["BILL_TO_PARTY_REG"].Value.ToUpper();
                // billOfLadingText = new Regex(@"B/L#\s(?<BILL_OF_LADING_REG>[A-Z]{3,3}[0-9\-\s]{7,11})").Match(pdfPageText).Groups["BILL_OF_LADING_REG"].Value.ToUpper();
                // termsText = new Regex(@"TERMS\s\s(?<TERMS_REG>.*(?=[\n\r]))").Match(pdfPageText).Groups["TERMS_REG"].Value.ToUpper();
                // shipperDollarValueText = new Regex(@"LINE[\s]HAUL[\s]:[\s\w,$][^\d]*(?<SHIPPER_DOLLAR_VALUE_REG>[0-9.]*)").Match(pdfPageText).Groups["SHIPPER_DOLLAR_VALUE_REG"].Value.ToUpper();
                //consigneeDollarValueAndDescriptionText = new Regex(@"(?<CONSIGNEE_DOLLAR_VALUE_AND_DESCRIPTION_REG>pattern)").Match(pdfPageText).Groups["CONSIGNEE_DOLLAR_VALUE_AND_DESCRIPTION_REG"].Value.ToUpper();
                // totalDollarValueText = new Regex(@"TOTAL\s\$(?<TOTAL_DOLLAR_VALUE_REG>[0-9,]{1,6}\.[0-9]{2,2})").Match(pdfPageText).Groups["TOTAL_DOLLAR_VALUE_REG"].Value.ToUpper();
            }
            Console.WriteLine("\n +++++ END DOCUMENT +++++ " + filename + "\n");

            // Console.WriteLine("\n ///// START SUMMARY ///// \n");
            // Console.WriteLine("Invoice Number::::::::: " + invoiceNumberText);
            // Console.WriteLine("Invoice Date::::::::::: " + invoiceDateText);
            // Console.WriteLine("Header::::::::::::::::: " + headerText);
            // Console.WriteLine("Bill To Party:::::::::: " + billToPartyText);
            // Console.WriteLine("Bill Of Lading::::::::: " + billOfLadingText);
            // Console.WriteLine("Terms:::::::::::::::::: " + termsText);
            // Console.WriteLine("Shipper Dollar Value::: " + shipperDollarValueText);
            // Console.WriteLine("Consignee Dollar Value: " + consigneeDollarValueAndDescriptionText);
            // Console.WriteLine("Total Dollar Value::::: " + Convert.ToDecimal(totalDollarValueText));
            // Console.WriteLine("\n ///// END SUMMARY ///// \n");
        };
    }
}