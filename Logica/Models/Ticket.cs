using System;
using System.Collections.Generic;

namespace Logica.Models
{
    public class Ticket
    {
        public int IDTicket { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }

        public string TicketTitulo { get; set; }

        public string TicketDescripcion { get; set; }

        public int CantidadTiempo { get; set; }

        public bool Pagado { get; set; }

        public bool Activo { get; set; }


        public Ticket()
        {
            CantidadTiempo = 0;

            MiCategoria = new TicketCategoria();
            MiCliente = new Cliente();
            MiListaDeUsuarios = new List<UsuarioTicket>();

        }


        // esta clase es la maás complicada en composiciones

        public TicketCategoria MiCategoria { get; set; }

        public Cliente MiCliente { get; set; }

        // composicion multiple, o sea es la tabla de muchos a muchos
        public List<UsuarioTicket> MiListaDeUsuarios { get; set; }


        // funciones

        public bool Agregar()
        {
            bool R = false;

            return R;
        
        
        }

        public bool Eliminar()
        {
            bool R = false;

            return R;


        }

        public bool IniciarTicket()
        {
            bool R = false;

            return R;


        }

        public bool FinalizarTicket()
        {
            bool R = false;

            return R;


        }

        public bool EstablecerPagado()
        {
            bool R = false;

            return R;


        }



    }
}
