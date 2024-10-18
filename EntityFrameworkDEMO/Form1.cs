using AccesoDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkDEMO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private CustomerRepository cr = new CustomerRepository();
        private void btnObtenerTodos_Click(object sender, EventArgs e)
        {
            var cliente = cr.ObtenerTodos();
            dgvCustomers.DataSource = cliente;

        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            var cliente = cr.ObtenerPorID(txbObtenerTodos.Text);
            List<Customers> lista1 = new List<Customers>
            {
                cliente
            };
            if (cliente != null)
            {
                LlenarCampos(cliente);
            }
            dgvCustomers.DataSource = lista1; 

        }

        private Customers CrearCliente()
        {
            var cliente = new Customers()
            {
                CustomerID = txbCustomerID.Text,
                CompanyName = txbCompanyName.Text,
                ContactName = txbContactName.Text,
                ContactTitle = txbContactTitle.Text,
                Address = txbAddress.Text,
            };
            return cliente;
        }

        private void LlenarCampos(Customers customers)
        {
            txbCustomerID.Text = customers.CustomerID;
            txbCompanyName.Text = customers.CompanyName;
            txbContactName.Text = customers.ContactName;
            txbContactTitle.Text = customers.ContactTitle;
            txbAddress.Text = customers.Address;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            var cliente = CrearCliente();
            var resultado = cr.InsertarCliente(cliente);
            MessageBox.Show($"Se insertó {resultado}");
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            var cliente = CrearCliente();
            cr.actualizarCliente(cliente);
            
            var resultado = cr.ObtenerPorID(cliente.CustomerID);
            List<Customers> lista1 = new List<Customers> { resultado };

            dgvCustomers.DataSource = lista1;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            var eliminadas = cr.borrarCliente(txbCustomerID.Text);
            MessageBox.Show($"Se eliminó {eliminadas} filas");
        }
    }
}
