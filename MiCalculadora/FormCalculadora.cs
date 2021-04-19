using System;
using System.Windows.Forms;
using Entidades;


namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {

        /// <summary>
        /// Constructor de la aplicacion Windows Form. Inicia con el combobox de la 
        /// operacion establecido en la primera opcion, que es la suma
        /// </summary>
        public FormCalculadora()
        {


            InitializeComponent();
            this.cmbOperador.SelectedIndex = 0;

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

            Numero objetoNumero1 = new Numero(this.txtNumero1.Text);
            Numero objetoNumero2 = new Numero(this.txtNumero2.Text);

            return Calculadora.Operar(objetoNumero1, objetoNumero2, operador);

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
            Numero numero = new Numero();

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
            Numero numero = new Numero();
            string temp = this.lblResultado.Text;

            this.lblResultado.Text = numero.DecimalBinario(temp);

        }
    }
}
