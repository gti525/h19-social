using ASPNETCoreHeroku.DAL;
using ASPNETCoreHeroku.Models;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;

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
            Renderer.RenderHtmlAsPdf(
                    "<h1>Ticket Id</h1> <br> <p>" + ticket.Id.ToString() +
                    "</p> <p>" + ticket.EventName.ToString() +
                    "</p> <p>" + ticket.Artist.ToString() +
                    "</p> <p>" + ticket.Date.ToString() +
                    "</p> <p>" + ticket.Location.ToString() +
                    "</p>")
                .SaveAs("PDFs/TicketPDF.pdf");

            var fileStream = new FileStream("PDFs/TicketPDF.pdf", FileMode.Open, FileAccess.Read);
            var fsResult = new FileStreamResult(fileStream, "application/pdf");

            return fsResult;
        }
    }
}
