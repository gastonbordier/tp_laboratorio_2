using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
            this.cmbOperador.SelectedIndex = 0;
            this.FormClosing += new FormClosingEventHandler(Form_FormClosing);
        }

        void Form_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (Cerrar() == false)
            {
                e.Cancel = true;
            }
            // Autosave and clear up ressources
        }


        /// <summary>
        /// Accion al hacer clic en el boton cerrar. Cierra la aplicacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private bool Cerrar()
        {
            MessageBoxButtons botones = MessageBoxButtons.YesNo;
            DialogResult ventanaConfirmacion = MessageBox.Show("¿Esta seguro que desea salir?", "Salir", botones);

            if (ventanaConfirmacion == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        /// <summary>
        /// Accion del boton Limpiar. Contiene al metodo siguiente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }


        /// <summary>
        /// Borra los datos introducidos en los cuadros de texto, 
        /// en el label resultado y en establece el comboBox en su index 0.
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.lblResultado.Text = "0";
            this.cmbOperador.SelectedIndex = 0;

        }


        /// <summary>
        /// Accion del boton operar. Establece el label con el texto del resultado del metodo siguiente, Operar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {

            this.lblResultado.Text = Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text).ToString();

            if (this.cmbOperador.Text == " ")
            {
                this.cmbOperador.Text = "+";

            }

            string operacionString = this.txtNumero1.Text + ' ' + this.cmbOperador.Text + ' ' + this.txtNumero2.Text + " = " + this.lblResultado.Text;

            this.lstOperaciones.Items.Add(operacionString);
        }


        /// <summary>
        /// Metodo que toma los dos string de la aplicacion Form y el string elegido
        /// en el combobox para crear dos objetos numeros y realizar la operacion 
        /// matematica deseada mediante el metodo Operar de la clase estatica 
        /// Calculadora
        /// </summary>
        /// <param name="numero1">el primer miembro de la operacion. </param>
        /// <param name="numero2">el segundo miebro de la operacion. </param>
        /// <param name="operador">El caracter que identifica al operador de la funcion</param>
        /// <returns>el double resultado de la operacion</returns>
        private double Operar(string numero1, string numero2, string operador)
        {

            Operando objetoOperando1 = new Operando(numero1);
            Operando objetoOperando2 = new Operando(numero2);


            return Calculadora.Operar(objetoOperando1, objetoOperando2, operador);


        }


        /// <summary>
        /// Accion del boton Convertir a Decimal. Convierte el numero contenido en el 
        /// label del resultado a decimal si es posible. Caso contrario devuelve
        /// "Valor invalido"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando numero = new Operando();

            this.lblResultado.Text = numero.BinarioDecimal(this.lblResultado.Text);
        }

        /// <summary>
        /// Accion del boton Convertir a Decimal. Convierte el numero contenido en el 
        /// label del resultado a decimal si es posible. Caso contrario devuelve
        /// "Valor invalido"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Operando numero = new Operando();
            string temp = this.lblResultado.Text;

            this.lblResultado.Text = numero.DecimalBinario(temp);

        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }
    }

}
