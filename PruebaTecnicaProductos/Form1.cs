using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PruebaTecnicaProductos.Datos;

namespace PruebaTecnicaProductos
{
    public partial class frmProductos : Form
    {
        DaoProductos dao = new DaoProductos();

        public frmProductos()
        {
            InitializeComponent();
            dataGridView1.DataSource = dao.listarProductos();
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow currentRow = dataGridView1.CurrentRow;
            string nombre = currentRow.Cells["Nombre"].Value.ToString();
            string descripcion = currentRow.Cells["Descripcion"].Value.ToString();
            string precio = currentRow.Cells["Precio"].Value.ToString();
            string cantidad = currentRow.Cells["Cantidad"].Value.ToString();

            txtNombre.Text = nombre;
            txtDescripcion.Text = descripcion;
            txtPrecio.Text = precio;
            textBox1.Text = cantidad;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string descripcion = txtDescripcion.Text; 
            decimal precio = decimal.Parse(txtPrecio.Text);
            int cantidad = Int32.Parse(textBox1.Text);
            bool creado = false; 

            if ((nombre != "") && (precio >= 0) && (cantidad >= 0)) {
                creado = dao.crearProducto(nombre, descripcion, precio, cantidad);
                MessageBox.Show("producto creado correctamente");
            }

            if (creado == false)
            {
                MessageBox.Show("El producto no se pudo crear, los campos no pueden estar vacios");
            }
            dataGridView1.DataSource = dao.listarProductos();

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            DataGridViewRow currentRow = dataGridView1.CurrentRow;

            int id = Int32.Parse(currentRow.Cells["IdProducto"].Value.ToString()); 
            string nombre = txtNombre.Text;
            string descripcion = txtDescripcion.Text;
            decimal precio = decimal.Parse(txtPrecio.Text);
            int cantidad = Int32.Parse(textBox1.Text);
            bool editado = false;

            if ((nombre != "") && (precio >= 0) && (cantidad >= 0))
            {
                editado = dao.editar(id,nombre, descripcion, precio, cantidad);
                MessageBox.Show("producto editado correctamente");
            }

            if (editado == false)
            {
                MessageBox.Show("El producto no se pudo crear, por favor seleccione un Producto");
            }
            dataGridView1.DataSource = dao.listarProductos();

        }

        private void LimpiarCampos()
        {
            textBox1.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtNombre.Text = "";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DataGridViewRow currentRow = dataGridView1.CurrentRow;

            int id = Int32.Parse(currentRow.Cells["IdProducto"].Value.ToString());
            string nombre = txtNombre.Text;
            string descripcion = txtDescripcion.Text;
            decimal precio = decimal.Parse(txtPrecio.Text);
            int cantidad = Int32.Parse(textBox1.Text);
            bool editado = false;

            if (id != null)
            {
                if ((nombre != "") && (precio >= 0) && (cantidad >= 0))
                {
                    DialogResult dialogResult = MessageBox.Show("Seguro que quiere eliminar el producto", "responda si o no", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        dao.eliminar(id);
                        MessageBox.Show("Producto Eliminado correctamente");
                        dataGridView1.DataSource = dao.listarProductos();
                    }            
                }  

            }
            else
            {
                MessageBox.Show("No se seleccionó un ID");
            }


        }
    }
}
