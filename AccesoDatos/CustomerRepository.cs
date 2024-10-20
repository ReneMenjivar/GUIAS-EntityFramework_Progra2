﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class CustomerRepository
    {
        public NorthwindEntities contexto = new NorthwindEntities();

        public List<Customers> ObtenerTodos()
        {
            var cliente = from custM in contexto.Customers select custM;

            return cliente.ToList();

        }
        public Customers ObtenerPorID(string id)
        {
            var clientes = from cm in contexto.Customers where cm.CustomerID == id select cm;
            return clientes.FirstOrDefault();


        }

        public int InsertarCliente(Customers customers)
        {
            contexto.Customers.Add(customers);
            return contexto.SaveChanges();
        }

        public int actualizarCliente(Customers customers)
        {
            var registro = ObtenerPorID(customers.CustomerID);
            if (registro != null)
            {
                registro.CustomerID = customers.CustomerID;
                registro.CompanyName = customers.CompanyName;
                registro.ContactName = customers.ContactName;
                registro.ContactTitle = customers.ContactTitle;
                registro.Address = customers.Address;
            }
            return contexto.SaveChanges();
        }

        public int borrarCliente(string id)
        {
            var registro = ObtenerPorID(id);
            if (registro != null)
            {
                contexto.Customers.Remove(registro);
                return contexto.SaveChanges();
            }
            return 0;
        }
} }
