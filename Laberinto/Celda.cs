using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laberinto
{
    class Celda
    {
        //             Izquierda, Arriba, Derecha, Abajo, caminado, recorrido
        bool[] paredes = { true,   true,    true,  true,   false,   false};
        // 0 = Bloque, 1 = Camino, 2 = Inicio, 3 = Final
        int tipoDeCelda = 0;
        Point ubicacion, esquinaInferiorIzquierda, esquinaSuperiorDerecha, esquinaInferiorDerecha;
        Size tamanio;
        Graphics graphics;
        Pen lapiz;
        Brush relleno;

        public Celda(Graphics graphics, Pen lapiz, Point ubicacion, Size tamanio)
        {
            this.graphics = graphics;
            this.lapiz = lapiz;
            this.ubicacion = ubicacion;
            this.tamanio = tamanio;
            this.esquinaInferiorIzquierda = new Point(ubicacion.X, ubicacion.Y + tamanio.Height);
            this.esquinaSuperiorDerecha = new Point(ubicacion.X + tamanio.Width, ubicacion.Y);
            this.esquinaInferiorDerecha = new Point(ubicacion.X + tamanio.Width, ubicacion.Y + tamanio.Height);
        }
        public void QuitarPared(int indice)
        {
            paredes[indice] = false;
        }
        public void DibujarCelda()
        {
            DibujarParedes();
            DibujarBloque();
            if (paredes[5])
            {
                DibujarCaminoRecorrido();
            }
        }
        private void DibujarBloque()
        {
            switch (tipoDeCelda)
            {
                case 0:
                    relleno = new SolidBrush(Color.DarkBlue);
                    break;
                case 1:
                    relleno = new SolidBrush(Color.FromArgb(0,0,192));
                    break;
                case 2:
                    relleno = new SolidBrush(Color.Green);
                    break;
                case 3:
                    relleno = new SolidBrush(Color.Red);
                    break;
                default:
                    break;
            }
            graphics.FillRectangle(relleno, ubicacion.X, ubicacion.Y, tamanio.Width, tamanio.Height);
        }
        private void DibujarParedes()
        {
            for(int i = 0; i < 4; i++)
            {
                if (paredes[i])
                {
                    DibujarPared(i);
                }
            }
        }
        private void DibujarPared(int i)
        {
            switch (i)
            {
                case 0:
                    graphics.DrawLine(lapiz, ubicacion, esquinaInferiorIzquierda);
                    break;
                case 1:
                    graphics.DrawLine(lapiz, ubicacion, esquinaSuperiorDerecha);
                    break;
                case 2:
                    graphics.DrawLine(lapiz, esquinaSuperiorDerecha, esquinaInferiorDerecha);
                    break;
                case 3:
                    graphics.DrawLine(lapiz, esquinaInferiorIzquierda, esquinaInferiorDerecha);
                    break;
                default:
                    break;
            }
            
        }
        public void DibujarCaminoRecorrido()
        {
            relleno = new SolidBrush(Color.Gold);
            graphics.FillEllipse(relleno, new Rectangle(ubicacion, tamanio));
        }
        public void SetTipoDeCelda(int tipo)
        {
            this.tipoDeCelda = tipo;
        }
        public int GetTipoDeCelda()
        {
            return tipoDeCelda;
        }
        public void SetTamanio(Size tamanio)
        {
            this.tamanio = tamanio;
            this.esquinaInferiorIzquierda = new Point(ubicacion.X, ubicacion.Y + tamanio.Height);
            this.esquinaSuperiorDerecha = new Point(ubicacion.X + tamanio.Width, ubicacion.Y);
            this.esquinaInferiorDerecha = new Point(ubicacion.X + tamanio.Width, ubicacion.Y + tamanio.Height);

        }
        public void SetUbicacion(Point ubicacion)
        {
            this.ubicacion = ubicacion;
        }
        public void SetGraphics(Graphics graphics)
        {
            this.graphics = graphics;
        }
        public bool[] GetParedes()
        {
            return paredes;
        }
    }
}
