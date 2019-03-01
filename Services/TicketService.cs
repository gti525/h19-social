using System;
using ASPNETCoreHeroku.DAL;
using ASPNETCoreHeroku.Models;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mime;
using HandlebarsDotNet;
using IronPdf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Swashbuckle.AspNetCore.Swagger;

namespace ASPNETCoreHeroku.Services
{
    public interface ITicketService
    {
        IEnumerable<Ticket> GetTicketsByClientId(int id);
        Ticket GetTicketByTicketId(int id);
        void AddTicket(Ticket ticket);
        ActionResult printPDF(int id);
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

        public Ticket GetTicketByTicketId(int id)
        {
            return _ticketDAL.GetTicketByTicketId(id);
        }

        public void AddTicket(Ticket ticket)
        {
            _ticketDAL.AddTicket(ticket);
        }

        public ActionResult printPDF(int id)
        {
            Ticket ticket = _ticketDAL.GetTicketByTicketId(id);

            IronPdf.HtmlToPdf Renderer = new IronPdf.HtmlToPdf();
            Renderer.PrintOptions.CssMediaType = PdfPrintOptions.PdfCssMediaType.Print;

            string html = File.ReadAllText("PDFs/event_ticket_3.html");
            var template = Handlebars.Compile(html);
            var data = new
            {
                EventName = ticket.EventName,
                Artist = ticket.Artist,
                Date = ticket.Date,
                Location = ticket.Location,
                Id = ticket.Id
            };

            var res = template(data);

            Renderer.RenderHtmlAsPdf(
                    //"<h1>Ticket Id</h1> <br> <p>" + ticket.Id.ToString() +
                    //"</p> <p>" + ticket.EventName.ToString() +
                    //"</p> <p>" + ticket.Artist.ToString() +
                    //"</p> <p>" + ticket.Date.ToString() +
                    //"</p> <p>" + ticket.Location.ToString() +
                    //"</p>"
                    
                    res

                    )
                .SaveAs("PDFs/"+ ticket.EventName + "_Ticket_" + ticket.Id + ".pdf");
            
            var fileStream = new FileStream("PDFs/TicketPDF.pdf", FileMode.Open, FileAccess.Read);
            var fsResult = new FileStreamResult(fileStream, "application/pdf");
            return fsResult;
        }
    }
}
