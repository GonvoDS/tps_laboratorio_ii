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
        }
        private void Limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            lstOperaciones.Items.Clear();
            cmbOperador.SelectedItem = null;
            lblResultado.Text = "RESULTADO";
        }
        private double Operar(string numero1, string numero2, string operador)
        {
            Operando operando1 = new Operando(numero1);
            Operando operando2 = new Operando(numero2);
            char.TryParse(operador, out char miOperador);
            return Calculadora.Operar(operando1, operando2, miOperador);
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            string operador = "";
            bool operar = true;
            if(string.IsNullOrEmpty(txtNumero1.Text) || string.IsNullOrEmpty(txtNumero2.Text) 
                || double.TryParse(txtNumero1.Text,out double numero1)== false || double.TryParse(txtNumero2.Text,out double numero2)== false)     
            {
                MessageBox.Show("Los casilleros para los numeros se encuentran en blanco o ingresaron un valor invalido, por favor ingrese los numeros correspondientes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                operar = false;
            }
            if(cmbOperador.SelectedItem is null)
            {
                cmbOperador.Text = "+";
                operador = cmbOperador.Text;

            }
            else
            {
                operador = cmbOperador.Text;

            }
            if(operar)
            {
                btnConvertirABinario.Enabled = true;
                btnConvertirADecimal.Enabled = false;
                lblResultado.Text = Operar(txtNumero1.Text,txtNumero2.Text,operador).ToString();
                lstOperaciones.Items.Add($"{txtNumero1.Text} {operador} {txtNumero2.Text} = {lblResultado.Text}");
            }         
                                     
                        
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Desea cerrar la calculadora?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Dispose();
            }
        }
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Desea cerrar la calculadora?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Dispose();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string numeroConvertido = lblResultado.Text.ToString();
            if(double.TryParse(numeroConvertido, out double resultado))
            {
            lblResultado.Text = Operando.DecimalBinario(resultado).ToString();
            lstOperaciones.Items.Add($"{numeroConvertido} convertido a binario = {lblResultado.Text}");
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = true;       

            }
            else
            {
                MessageBox.Show("No es posible convertir el numero a binario", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string numeroConvertido = lblResultado.Text.ToString();
            lblResultado.Text = Operando.BinarioDecimal(numeroConvertido).ToString();
            lstOperaciones.Items.Add($"{numeroConvertido} convertido a Decimal = {lblResultado.Text}");
            btnConvertirABinario.Enabled = true;
            btnConvertirADecimal.Enabled = false;


        }
    }
}
