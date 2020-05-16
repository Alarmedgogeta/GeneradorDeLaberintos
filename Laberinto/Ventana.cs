using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laberinto
{
    public partial class frmLaberinto : Form
    {
        GeneradorDeLaberintos laberinto;
        int tamanio = 0;
        Graphics p;
        Pen lapiz;
        public frmLaberinto()
        {
            InitializeComponent();
            cmbTamanio.SelectedIndex = 0;
            ActualizarComponentes();
            p = mapa.CreateGraphics();
            lapiz = new Pen(Color.Black);
            lapiz.Width = 5;
            laberinto = new GeneradorDeLaberintos(p, lapiz);
        }

        private void FrmLaberinto_Resize(object sender, EventArgs e)
        {
            ActualizarComponentes();
        }

        private void ActualizarComponentes()
        {
            label3.Size = new Size(this.Size.Width - 40, label3.Size.Height);
            mapa.Size = new Size((this.Size.Width-(mapa.Location.X*3)), this.Size.Height - (mapa.Location.Y * 2));
            label1.Location = new Point((this.Size.Width / 2) - (label1.Size.Width / 2), label1.Location.Y);
            label2.Location = new Point((this.Size.Width / 2) - (label2.Size.Width), (this.Size.Height / 2) - (label2.Size.Height / 2));
            label3.Location = new Point((this.Size.Width / 2) - (label3.Size.Width / 2), label3.Location.Y);
            cmbTamanio.Location = new Point((this.Size.Width / 2), (this.Size.Height / 2) - (cmbTamanio.Size.Height / 2));
            btnJugar.Location = new Point((this.Size.Width / 2) + (btnJugar.Size.Width), this.Size.Height - 80);
            btnSolucionar.Location = new Point((mapa.Location.X+mapa.Size.Width-btnSolucionar.Size.Width), this.Size.Height - 80);
            btnMenu.Location = new Point((this.Size.Width / 2) - (btnSalir.Size.Width * 2), this.Size.Height - 80);
            btnSalir.Location = new Point(mapa.Location.X, btnJugar.Location.Y);
            if(btnMenu.Visible)
            {
                Graphics g = mapa.CreateGraphics();
                g.Clear(mapa.BackColor);
                laberinto.ActualizarTamanio(g, mapa.Size);
            }
        }

        private void BtnJugar_Click(object sender, EventArgs e)
        {
            mapa.Visible = true;
            btnMenu.Visible = true;
            btnSolucionar.Visible = true;
            btnJugar.Visible = false;
            laberinto.DefinirArregloDeCeldasSegunTamanio(tamanio, mapa.Size);
            laberinto.DibujarCeldas(mapa.CreateGraphics());
            laberinto.GenerarLaberinto();
            mapa.Focus();
            btnSolucionar.Enabled = true;
        }

        private void BtnMenu_Click(object sender, EventArgs e)
        {
            mapa.Visible = false;
            btnJugar.Visible = true;
            btnMenu.Visible = false;
            btnSolucionar.Visible = false;
        }

        private void CmbTamanio_SelectedValueChanged(object sender, EventArgs e)
        {
            this.tamanio = cmbTamanio.SelectedIndex;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FrmLaberinto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine("Tecla press");
            if (btnJugar.Visible)
            {
                if (e.KeyChar == (int)Keys.Left)
                {
                    laberinto.MarcarCamino(0);
                }
                else if (e.KeyChar == (int)Keys.Up)
                {
                    laberinto.MarcarCamino(1);
                }
                else if (e.KeyChar == (int)Keys.Right)
                {
                    laberinto.MarcarCamino(2);
                }
                else if (e.KeyChar == (int)Keys.Down)
                {
                    laberinto.MarcarCamino(3);
                }

            }
        }

        private void BtnSolucionar_Click(object sender, EventArgs e)
        {
            laberinto.EncontrarSolucion();
            btnSolucionar.Enabled = false;
        }
    }
}
