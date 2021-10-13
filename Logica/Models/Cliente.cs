﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Cliente : ICrudBase, IPersona
    {
        // Estos atributos vienen de IPersona

        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }

        // Estas funciones vienen de ICrudBase

        public bool Agregar()
        {
            bool R = false;


            return R;
        }

        public bool Editar()
        {
            bool R = false;


            return R;
        }

        public bool Eliminar()
        {
            bool R = false;


            return R;
        }


        // Ahora agregamos los atributos que no estaban en las interfaces
        public int IDCliente { get; set; }
        public string Direccion { get; set; }
        public bool EnviarPromos { get; set; }

        // Se analiza si hay atributos compuestos y se agregan

        public ClienteCategoria MiCategoria { get; set; }

        // Cuando tenemos atributos compuestos es necesario instanciarlos en el constructor de la clase

        public Cliente()
        {
            MiCategoria = new ClienteCategoria();
        }


        // Ahora agregamos las funciones que no estaban en interfaces

        bool ConsultarPorID(int ID) 
        {

            bool R = false;


            return R;
        }

        bool ConsultarPorCedula(string Cedula)
        {

            bool R = false;


            return R;
        }


        public DataTable ListarActivos()
        {
            DataTable R = new DataTable();

            return R;
        
        }

        public DataTable ListarInactivos()
        {
            DataTable R = new DataTable();

            return R;

        }


    }
}
