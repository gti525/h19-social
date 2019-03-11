using System;
using ASPNETCoreHeroku.DAL;
using ASPNETCoreHeroku.Models;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.DrawingCore;
using System.IO;
using System.Net;
using System.Net.Mime;
using HandlebarsDotNet;
using IronPdf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using QRCoder;
using Swashbuckle.AspNetCore.Swagger;
using Bitmap = System.Drawing.Bitmap;

namespace ASPNETCoreHeroku.Services
{
    public interface ITicketService
    {
        IEnumerable<Ticket> GetTicketsByClientId(int id);
        IEnumerable<Ticket> GetTicketsByClientIdWithoutClientRelation(int id);
        Ticket GetTicketByTicketId(int id);
        void AddTicket(int id, Ticket ticket);
        void printPDF(int id);
    }

    public class TicketService : ITicketService
    {
        private readonly ITicketDAL _ticketDAL;

        public TicketService(ITicketDAL ticketDAL)
        {
            _ticketDAL = ticketDAL;
        }

        public IEnumerable<Ticket> GetTicketsByClientId(int id)
        {
            return _ticketDAL.GetTicketsByClientId(id);
        }

        public IEnumerable<Ticket> GetTicketsByClientIdWithoutClientRelation(int id)
        {
            return _ticketDAL.GetTicketsByClientIdWithoutClientRelation(id);
        }

        public Ticket GetTicketByTicketId(int id)
        {
            return _ticketDAL.GetTicketByTicketId(id);
        }

        public void AddTicket(int id, Ticket ticket)
        {
            _ticketDAL.AddTicket(id, ticket);
        }

        public void printPDF(int id)
        {
            Ticket ticket = _ticketDAL.GetTicketByTicketId(id);

            IronPdf.HtmlToPdf Renderer = new IronPdf.HtmlToPdf();
            Renderer.PrintOptions.CssMediaType = PdfPrintOptions.PdfCssMediaType.Print;

            string html = File.ReadAllText("PDFs/event_ticket_3.html");
            var template = Handlebars.Compile(html);

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(ticket.Id.ToString(), QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImg = qrCode.GetGraphic(5, "#ffffff", "000000");

            string root = Path.GetFullPath("PDFs/event_ticket_3.html");

            string outputFileName = root + "QRCode.bmp";
            using (MemoryStream memory = new MemoryStream())
            {
                using (FileStream fs = new FileStream(outputFileName, FileMode.Create, FileAccess.ReadWrite))
                {
                    qrCodeImg.Save(memory, ImageFormat.Jpeg);
                    byte[] bytes = memory.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                }
            }

            var data = new
            {
                EventName = ticket.EventName,
                Artist = ticket.Artist,
                Date = ticket.Date,
                Location = ticket.Location,
                Id = ticket.Id,
                BarCode = outputFileName
            };

            var res = template(data);

            Renderer.RenderHtmlAsPdf(res)
                .SaveAs("PDFs/"+ ticket.EventName + "_Ticket_" + ticket.Id + ".pdf");
        }
    }
}
