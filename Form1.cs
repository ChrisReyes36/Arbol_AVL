using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arbol_AVL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int cont = 0;
        int dato = 0;
        int datob = 0;
        int cont2 = 0;

        DibujaAVL arbolAVL = new DibujaAVL(null);
        DibujaAVL arbolAVL_Letra = new DibujaAVL(null);
        Graphics g;

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g = e.Graphics;

            arbolAVL.DibujarArbol(g, this.Font, Brushes.White, Brushes.Black, Pens.White, datob, Brushes.Black);
            datob = 0;

            if (pintaR == 1)
            {
                arbolAVL.colorear(g, this.Font, Brushes.Black, Brushes.Yellow, Pens.Blue, arbolAVL.Raiz, rbtnPost.Checked, rbtnOrden.Checked, rbtnPreor.Checked);
                pintaR = 0;
            }
            if (pintaR == 2)
            {
                arbolAVL.colorearB(g, this.Font, Brushes.White, Brushes.Red, Pens.White, arbolAVL.Raiz, int.Parse(txtValor.Text));
                pintaR = 0;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtValor.Text == "")
                errorProvider1.SetError(txtValor, "Valor obligatorio");
            else
            {
                try
                {
                    dato = int.Parse(txtValor.Text);
                    arbolAVL.Insertar(dato);
                    txtValor.Clear();
                    txtValor.Focus();
                    lblAltura.Text = arbolAVL.Raiz.getAltura(arbolAVL.Raiz).ToString();
                    lblRotacion.Text = arbolAVL.Raiz.tipoRotacion; //Obtiene el valor del tipo de rotacion
                    cont++;
                    cont++;
                    Refresh();
                    Refresh();
                    Refresh();
                }
                catch (Exception)
                {
                    errorProvider1.SetError(txtValor, "Debe ser numérico");
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtValor.Text == "")
                errorProvider1.SetError(txtValor, "Valor obligatorio");
            else
            {
                try
                {
                    dato = int.Parse(txtValor.Text);
                    txtValor.Clear();
                    arbolAVL.Eliminar(dato);
                    lblAltura.Text = arbolAVL.Raiz.getAltura(arbolAVL.Raiz).ToString();
                    lblRotacion.Text = arbolAVL.Raiz.tipoRotacion; //Obtiene el valor del tipo de rotacion
                    Refresh();
                    Refresh();
                    Refresh();
                    cont2++;
                }
                catch (Exception)
                {
                    errorProvider1.SetError(txtValor, "Debe ser numérico");
                }
            }
            Refresh(); Refresh(); Refresh();
        }

        int pintaR = 0;

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtValor.Text == "")
                errorProvider1.SetError(txtValor, "Valor obligatorio");
            else
            {
                try
                {
                    datob = int.Parse(txtValor.Text);
                    arbolAVL.buscar(datob);
                    pintaR = 2;
                    Refresh();
                    txtValor.Clear();
                }
                catch (Exception)
                {
                    errorProvider1.SetError(txtValor, "Debe ser numérico");
                }
            }
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                errorProvider1.Clear();
                if (txtValor.Text == "")
                    errorProvider1.SetError(txtValor, "Valor obligatorio");
                else
                {
                    try
                    {
                        dato = int.Parse(txtValor.Text);
                        if (dato > 0)
                        {
                            arbolAVL.Insertar(dato);
                            txtValor.Clear();
                            txtValor.Focus();
                            lblAltura.Text = arbolAVL.Raiz.getAltura(arbolAVL.Raiz).ToString();
                            lblRotacion.Text = arbolAVL.Raiz.tipoRotacion; //Obtiene el valor del tipo de rotacion
                            cont++;
                            Refresh();
                            Refresh();
                            Refresh();
                        }
                        else
                            errorProvider1.SetError(txtValor, "Debe ser un número mayor que 0");
                    }
                    catch (Exception)
                    {
                        errorProvider1.SetError(txtValor, "Debe ser un numero mayor que 0");
                    }
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
