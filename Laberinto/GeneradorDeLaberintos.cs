using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Laberinto
{
    class GeneradorDeLaberintos
    {
        Graphics graphics;
        Pen lapiz;
        Celda[,] celdas;
        Size tamanio, margen;
        int opcionDeTamanio, filas, columnas;
        PilaDeCeldas pila;
        //Estos puntos son para dezplazarme por dentro de la matriz de celdas
        Point inicio, final, actual;
        Random aleatoreo = new Random();
        public GeneradorDeLaberintos(Graphics graphics, Pen lapiz)
        {
            this.graphics = graphics;
            this.lapiz = lapiz;
        }
        public void DefinirArregloDeCeldasSegunTamanio(int opcionDeTamanio, Size panel)
        {
            this.opcionDeTamanio = opcionDeTamanio;
            switch (opcionDeTamanio)
            {
                case 0:
                    filas = 3;
                    columnas = 8;
                    break;
                case 1:
                    filas = 5;
                    columnas = 11;
                    break;
                case 2:
                    filas = 8;
                    columnas = 18;
                    break;
                default:
                    break;
            }
            int width = (int) Math.Floor((double) panel.Width / columnas);
            int height = (int)Math.Floor((double)panel.Height / filas);
            this.tamanio = new Size(width, height);
            this.margen = new Size((panel.Width % (columnas*tamanio.Width))/2, 
                (panel.Height % (filas*tamanio.Height))/2);
            celdas = new Celda[columnas, filas];
            for (int i = 0; i < columnas; i++)
            {
                for (int j = 0; j < filas; j++)
                {
                    celdas[i, j] = new Celda(graphics, lapiz, new Point(((i * tamanio.Width) + this.margen.Width),
                        ((j * tamanio.Height) + this.margen.Height)), tamanio);
                }
            }
            pila = new PilaDeCeldas(celdas.Length);
        }
        public void ActualizarTamanio(Graphics graphics, Size panel)
        {
            this.graphics = graphics;
            int width = (int)Math.Floor((double)panel.Width / columnas);
            int height = (int)Math.Floor((double)panel.Height / filas);
            this.tamanio = new Size(width, height);
            for(int i = 0; i < columnas; i++)
            {
                for(int j = 0; j < filas; j++)
                {
                    celdas[i, j].SetUbicacion(new Point(((i * tamanio.Width) + this.margen.Width),
                        ((j * tamanio.Height) + this.margen.Height)));
                    celdas[i, j].SetTamanio(this.tamanio);
                }
            }
            DibujarCeldas(graphics);
        }
        public void DibujarCeldas(Graphics graphics)
        {
            this.graphics = graphics;
            for (int i = 0; i < columnas; i++)
            {
                for (int j = 0; j < filas; j++)
                {
                    celdas[i, j].SetGraphics(graphics);
                    celdas[i, j].DibujarCelda();
                }
            }
        }
        public void GenerarLaberinto()
        {
            inicio = new Point(0, 0);
            final = new Point(columnas - 1, filas - 1);
            celdas[inicio.X,inicio.Y].SetTipoDeCelda(2);
            pila.Push(celdas[inicio.X, inicio.Y]);
            actual = new Point(0, 0);
            Celda pop;
            do
            {
                while (SePuedeHacerCamino(actual))
                {
                    HacerCamino();
                }
                pop = pila.Pop();
                actual = ConseguirUbicacionEnLaMatriz(pop);
            }
            while (pop != null);
            celdas[final.X, final.Y].SetTipoDeCelda(3);
            DibujarCeldas(graphics);
        }
        private Point ConseguirUbicacionEnLaMatriz(Celda celda)
        {
            for(int i = 0; i< columnas; i++)
            {
                for(int j=0; j< filas; j++)
                {
                    if (celda == celdas[i, j])
                    {
                        return new Point(i, j);
                    }
                }
            }
            return new Point(0, 0);
        }
        public void HacerCamino()
        {
            int tipoDePosicion = TipoDePosicion();
            int siguiente;
            if(tipoDePosicion < 4)
            {
                siguiente = aleatoreo.Next(0, 2);
            }
            else if(tipoDePosicion < 8)
            {
                siguiente = aleatoreo.Next(0, 3);
            }
            else
            {
                siguiente = aleatoreo.Next(0, 4);
            }
            switch (tipoDePosicion)
            {
                case 0:
                    if ((siguiente == 0) && (celdas[1, 0].GetTipoDeCelda() == 0))
                    {
                        celdas[1, 0].SetTipoDeCelda(1);
                        celdas[1, 0].QuitarPared(0);
                        celdas[0, 0].QuitarPared(2);
                        pila.Push(celdas[1,0]);
                        actual.X = 1;
                        actual.Y = 0;
                    }
                    else if((siguiente == 1) && (celdas[0, 1].GetTipoDeCelda() == 0))
                    {
                        celdas[0, 1].SetTipoDeCelda(1);
                        celdas[0, 1].QuitarPared(1);
                        celdas[0, 0].QuitarPared(3);
                        pila.Push(celdas[0, 1]);
                        actual.X = 0;
                        actual.Y = 1;
                    }
                    break;
                case 1:
                    if ((siguiente == 0) && (celdas[(columnas-2), 0].GetTipoDeCelda() == 0))
                    {
                        celdas[(columnas - 2), 0].SetTipoDeCelda(1);
                        celdas[(columnas - 2), 0].QuitarPared(2);
                        celdas[(columnas - 1), 0].QuitarPared(0);
                        pila.Push(celdas[(columnas - 2), 0]);
                        actual.X = (columnas - 2);
                        actual.Y = 0;
                    }
                    else if ((siguiente == 1) && (celdas[(columnas-1), 1].GetTipoDeCelda() == 0))
                    {
                        celdas[(columnas-1), 1].SetTipoDeCelda(1);
                        celdas[(columnas - 1), 1].QuitarPared(1);
                        celdas[(columnas-1), 0].QuitarPared(3);
                        pila.Push(celdas[(columnas - 1), 1]);
                        actual.X = (columnas - 1);
                        actual.Y = 1;
                    }
                    break;
                case 2:
                    if ((siguiente == 0) && (celdas[(columnas-2), (filas-1)].GetTipoDeCelda() == 0))
                    {
                        celdas[(columnas-2), (filas-1)].SetTipoDeCelda(1);
                        celdas[(columnas - 2), (filas - 1)].QuitarPared(2);
                        celdas[(columnas - 1), (filas - 1)].QuitarPared(0);
                        pila.Push(celdas[(columnas - 2), (filas - 1)]);
                        actual.X = (columnas - 2);
                        actual.Y = (filas - 1);
                    }
                    else if ((siguiente == 1) && (celdas[(columnas-1), (filas-2)].GetTipoDeCelda() == 0))
                    {
                        celdas[(columnas - 1), (filas-2)].SetTipoDeCelda(1);
                        celdas[(columnas - 1), (filas - 2)].QuitarPared(3);
                        celdas[(columnas - 1), (filas-1)].QuitarPared(1);
                        pila.Push(celdas[(columnas - 1), (filas - 2)]);
                        actual.X = (columnas - 1);
                        actual.Y = (filas - 2);
                    }
                    break;
                case 3:
                    if ((siguiente == 0) && (celdas[1, (filas-1)].GetTipoDeCelda() == 0))
                    {
                        celdas[1, (filas-1)].SetTipoDeCelda(1);
                        celdas[1, (filas - 1)].QuitarPared(0);
                        celdas[actual.X, actual.Y].QuitarPared(2);
                        pila.Push(celdas[1, (filas - 1)]);
                        actual.X = 1;
                        actual.Y = (filas - 1);
                    }
                    else if ((siguiente == 1) && (celdas[0, (filas-2)].GetTipoDeCelda() == 0))
                    {
                        celdas[0, (filas-2)].SetTipoDeCelda(1);
                        celdas[0, (filas - 2)].QuitarPared(3);
                        celdas[actual.X, actual.Y].QuitarPared(1);
                        pila.Push(celdas[0, (filas - 2)]);
                        actual.X = 0;
                        actual.Y = (filas - 2);
                    }
                    break;
                case 4:
                    if ((siguiente == 0) && (celdas[0, (actual.Y-1)].GetTipoDeCelda() == 0))
                    {
                        celdas[0, (actual.Y - 1)].SetTipoDeCelda(1);
                        celdas[0, (actual.Y - 1)].QuitarPared(3);
                        celdas[actual.X, actual.Y].QuitarPared(1);
                        pila.Push(celdas[0, (actual.Y - 1)]);
                        actual.X = 0;
                        actual.Y = (actual.Y - 1);
                    }
                    else if ((siguiente == 1) && (celdas[1, actual.Y].GetTipoDeCelda() == 0))
                    {
                        celdas[1, actual.Y].SetTipoDeCelda(1);
                        celdas[1, actual.Y].QuitarPared(0);
                        celdas[actual.X, actual.Y].QuitarPared(2);
                        pila.Push(celdas[1, actual.Y]);
                        actual.X = 1;
                        actual.Y = actual.Y;
                    }
                    else if ((siguiente == 2) && (celdas[0, (actual.Y+1)].GetTipoDeCelda() == 0))
                    {
                        celdas[0, (actual.Y + 1)].SetTipoDeCelda(1);
                        celdas[0, (actual.Y + 1)].QuitarPared(1);
                        celdas[actual.X, actual.Y].QuitarPared(3);
                        pila.Push(celdas[0, (actual.Y + 1)]);
                        actual.X = 0;
                        actual.Y = (actual.Y + 1);
                    }
                    break;
                case 5:
                    if ((siguiente == 0) && (celdas[actual.X, (actual.Y-1)].GetTipoDeCelda() == 0))
                    {
                        celdas[actual.X, (actual.Y - 1)].SetTipoDeCelda(1);
                        celdas[actual.X, (actual.Y - 1)].QuitarPared(3);
                        celdas[actual.X, actual.Y].QuitarPared(1);
                        pila.Push(celdas[actual.X, (actual.Y - 1)]);
                        actual.X = actual.X;
                        actual.Y = (actual.Y - 1);
                    }
                    else if ((siguiente == 1) && (celdas[(actual.X-1), actual.Y].GetTipoDeCelda() == 0))
                    {
                        celdas[(actual.X-1), actual.Y].SetTipoDeCelda(1);
                        celdas[(actual.X - 1), actual.Y].QuitarPared(2);
                        celdas[actual.X, actual.Y].QuitarPared(0);
                        pila.Push(celdas[(actual.X - 1), actual.Y]);
                        actual.X = (actual.X - 1);
                        actual.Y = actual.Y;
                    }
                    else if ((siguiente == 2) && (celdas[actual.X, (actual.Y + 1)].GetTipoDeCelda() == 0))
                    {
                        celdas[actual.X, (actual.Y + 1)].SetTipoDeCelda(1);
                        celdas[actual.X, (actual.Y + 1)].QuitarPared(1);
                        celdas[actual.X, actual.Y].QuitarPared(3);
                        pila.Push(celdas[actual.X, (actual.Y + 1)]);
                        actual.X = actual.X;
                        actual.Y = (actual.Y + 1);
                    }
                    break;
                case 6:
                    if ((siguiente == 0) && (celdas[(actual.X-1), actual.Y].GetTipoDeCelda() == 0))
                    {
                        celdas[(actual.X-1), actual.Y].SetTipoDeCelda(1);
                        celdas[(actual.X - 1), actual.Y].QuitarPared(2);
                        celdas[actual.X, actual.Y].QuitarPared(0);
                        pila.Push(celdas[(actual.X - 1), actual.Y]);
                        actual.X = (actual.X - 1);
                        actual.Y = actual.Y;
                    }
                    else if ((siguiente == 1) && (celdas[actual.X, (actual.Y+1)].GetTipoDeCelda() == 0))
                    {
                        celdas[actual.X, (actual.Y+1)].SetTipoDeCelda(1);
                        celdas[actual.X, (actual.Y + 1)].QuitarPared(1);
                        celdas[actual.X, actual.Y].QuitarPared(3);
                        pila.Push(celdas[actual.X, (actual.Y + 1)]);
                        actual.X = actual.X;
                        actual.Y = (actual.Y + 1);
                    }
                    else if ((siguiente == 2) && (celdas[(actual.X+1), actual.Y].GetTipoDeCelda() == 0))
                    {
                        celdas[(actual.X + 1), actual.Y].SetTipoDeCelda(1);
                        celdas[(actual.X + 1), actual.Y].QuitarPared(0);
                        celdas[actual.X, actual.Y].QuitarPared(2);
                        pila.Push(celdas[(actual.X + 1), actual.Y]);
                        actual.X = (actual.X + 1);
                        actual.Y = actual.Y;
                    }
                    break;
                case 7:
                    if ((siguiente == 0) && (celdas[(actual.X - 1), actual.Y].GetTipoDeCelda() == 0))
                    {
                        celdas[(actual.X - 1), actual.Y].SetTipoDeCelda(1);
                        celdas[(actual.X - 1), actual.Y].QuitarPared(2);
                        celdas[actual.X, actual.Y].QuitarPared(0);
                        pila.Push(celdas[(actual.X - 1), actual.Y]);
                        actual.X = (actual.X - 1);
                        actual.Y = actual.Y;
                    }
                    else if ((siguiente == 1) && (celdas[actual.X, (actual.Y - 1)].GetTipoDeCelda() == 0))
                    {
                        celdas[actual.X, (actual.Y - 1)].SetTipoDeCelda(1);
                        celdas[actual.X, (actual.Y - 1)].QuitarPared(3);
                        celdas[actual.X, actual.Y].QuitarPared(1);
                        pila.Push(celdas[actual.X, (actual.Y - 1)]);
                        actual.X = actual.X;
                        actual.Y = (actual.Y - 1);
                    }
                    else if ((siguiente == 2) && (celdas[(actual.X + 1), actual.Y].GetTipoDeCelda() == 0))
                    {
                        celdas[(actual.X + 1), actual.Y].SetTipoDeCelda(1);
                        celdas[(actual.X + 1), actual.Y].QuitarPared(0);
                        celdas[actual.X, actual.Y].QuitarPared(2);
                        pila.Push(celdas[(actual.X + 1), actual.Y]);
                        actual.X = (actual.X + 1);
                        actual.Y = actual.Y;
                    }
                    break;
                case 8:
                    if ((siguiente == 0) && (celdas[(actual.X - 1), actual.Y].GetTipoDeCelda() == 0))
                    {
                        celdas[(actual.X - 1), actual.Y].SetTipoDeCelda(1);
                        celdas[(actual.X - 1), actual.Y].QuitarPared(2);
                        celdas[actual.X, actual.Y].QuitarPared(0);
                        pila.Push(celdas[(actual.X - 1), actual.Y]);
                        actual.X = (actual.X - 1);
                        actual.Y = actual.Y;
                    }
                    else if ((siguiente == 1) && (celdas[actual.X, (actual.Y - 1)].GetTipoDeCelda() == 0))
                    {
                        celdas[actual.X, (actual.Y - 1)].SetTipoDeCelda(1);
                        celdas[actual.X, (actual.Y - 1)].QuitarPared(3);
                        celdas[actual.X, actual.Y].QuitarPared(1);
                        pila.Push(celdas[actual.X, (actual.Y - 1)]);
                        actual.X = actual.X;
                        actual.Y = (actual.Y - 1);
                    }
                    else if ((siguiente == 2) && (celdas[(actual.X + 1), actual.Y].GetTipoDeCelda() == 0))
                    {
                        celdas[(actual.X + 1), actual.Y].SetTipoDeCelda(1);
                        celdas[(actual.X + 1), actual.Y].QuitarPared(0);
                        celdas[actual.X, actual.Y].QuitarPared(2);
                        pila.Push(celdas[(actual.X + 1), actual.Y]);
                        actual.X = (actual.X + 1);
                        actual.Y = actual.Y;
                    }
                    else if ((siguiente == 3) && (celdas[actual.X, (actual.Y + 1)].GetTipoDeCelda() == 0))
                    {
                        celdas[actual.X, (actual.Y + 1)].SetTipoDeCelda(1);
                        celdas[actual.X, (actual.Y + 1)].QuitarPared(1);
                        celdas[actual.X, actual.Y].QuitarPared(3);
                        pila.Push(celdas[actual.X, (actual.Y + 1)]);
                        actual.X = actual.X;
                        actual.Y = (actual.Y + 1);
                    }
                    break;
                default:
                    break;
            }
        }
        /*El método "TipoDePosicion" devuelve un valor tipo int que representa en que clase de posición
         *se encuentra la actual con respecto a las demás celdas en el siguiente orden
         *0 = origen, 1 = esquina superior derecha, 2 = esquina inferior derecha, 
         *3 = ezquina inferior izquierda, 4 = primera columna, 5 = ultima columna,
         *6 = primera fila, 7 = última fila, 8 = cualquiera del centro*/
        private int TipoDePosicion()
        {
            if ((actual.X == 0) && (actual.Y == 0))
            {
                return 0;
            }
            else if ((actual.X == (columnas - 1)) && (actual.Y == 0))
            {
                return 1;
            }
            else if ((actual.X == (columnas - 1)) && actual.Y == (filas - 1))
            {
                return 2;
            }
            else if ((actual.X == 0) && (actual.Y == (filas - 1)))
            {
                return 3;
            }
            else if (actual.X == 0)
            {
                return 4;
            }
            else if (actual.X == (columnas - 1))
            {
                return 5;
            }
            else if (actual.Y == 0)
            {
                return 6;
            }
            else if (actual.Y == (filas - 1))
            {
                return 7;
            }
            else
            {
                return 8;
            }
        }
        private bool SePuedeHacerCamino(Point posicionActual)
        {
            int tipoDePosicion = TipoDePosicion();
            switch (tipoDePosicion)
            {
                case 0:
                    return ((celdas[1, 0].GetTipoDeCelda() == 0) || (celdas[0, 1].GetTipoDeCelda() == 0));
                case 1:
                    return ((celdas[(posicionActual.X - 1), 0].GetTipoDeCelda() == 0) ||
                 (celdas[posicionActual.X, 1].GetTipoDeCelda() == 0));
                case 2:
                    return ((celdas[(posicionActual.X - 1), posicionActual.Y].GetTipoDeCelda() == 0) ||
                 (celdas[posicionActual.X, (posicionActual.Y - 1)].GetTipoDeCelda() == 0));
                case 3:
                    return ((celdas[posicionActual.X, (posicionActual.Y - 1)].GetTipoDeCelda() == 0) ||
                        (celdas[(posicionActual.X + 1), posicionActual.Y].GetTipoDeCelda() == 0));
                case 4:
                    return ((celdas[posicionActual.X, (posicionActual.Y - 1)].GetTipoDeCelda() == 0) ||
                        (celdas[(posicionActual.X + 1), posicionActual.Y].GetTipoDeCelda() == 0) ||
                        (celdas[posicionActual.X, (posicionActual.Y + 1)].GetTipoDeCelda() == 0));
                case 5:
                    return ((celdas[posicionActual.X, (posicionActual.Y - 1)].GetTipoDeCelda() == 0) ||
                        (celdas[(posicionActual.X - 1), posicionActual.Y].GetTipoDeCelda() == 0) ||
                        (celdas[posicionActual.X, (posicionActual.Y + 1)].GetTipoDeCelda() == 0));
                case 6:
                    return ((celdas[(posicionActual.X - 1), posicionActual.Y].GetTipoDeCelda() == 0) ||
                        (celdas[posicionActual.X, (posicionActual.Y + 1)].GetTipoDeCelda() == 0) ||
                        (celdas[(posicionActual.X + 1), posicionActual.Y].GetTipoDeCelda() == 0));
                case 7:
                    return ((celdas[(posicionActual.X - 1), posicionActual.Y].GetTipoDeCelda() == 0) ||
                        (celdas[posicionActual.X, (posicionActual.Y - 1)].GetTipoDeCelda() == 0) ||
                        (celdas[(posicionActual.X + 1), posicionActual.Y].GetTipoDeCelda() == 0));
                case 8:
                    return ((celdas[(posicionActual.X - 1), posicionActual.Y].GetTipoDeCelda() == 0) ||
                        (celdas[posicionActual.X, (posicionActual.Y - 1)].GetTipoDeCelda() == 0) ||
                        (celdas[(posicionActual.X + 1), posicionActual.Y].GetTipoDeCelda() == 0) ||
                        (celdas[posicionActual.X, (posicionActual.Y + 1)].GetTipoDeCelda() == 0));
                default:
                    return false;
            }
        }
        public void EncontrarSolucion()
        {
            Celda celdaActual;
            celdaActual = celdas[actual.X, actual.Y];
            pila.Push(celdaActual);
            celdaActual.GetParedes()[4] = true;
            bool sePudoAvanzar = true;
            do
            {
                for (int i = 0; i < 4; i++)
                {
                    if (SePuedeAvanzar(i))
                    {
                        sePudoAvanzar = true;
                        Avanzar(i);
                        break;
                    }
                    else
                    {
                        sePudoAvanzar = false;
                    }
                }
                if (!sePudoAvanzar)
                {
                    celdaActual.GetParedes()[5] = false;
                    actual = ConseguirUbicacionEnLaMatriz(pila.Pop());
                }
                celdaActual = celdas[actual.X, actual.Y];
                DibujarCeldas(graphics);
            }
            while (celdaActual.GetTipoDeCelda() != 3);
        }
        public void Avanzar(int direccion)
        {
            switch (direccion)
            {
                case 0:
                    actual.X--;
                    break;
                case 1:
                    actual.Y--;
                    break;
                case 2:
                    actual.X++;
                    break;
                case 3:
                    actual.Y++;
                    break;
                default:
                    break;
            }
            pila.Push(celdas[actual.X, actual.Y]);
            celdas[actual.X, actual.Y].GetParedes()[4] = true;
            celdas[actual.X, actual.Y].GetParedes()[5] = true;
        }
        public void MarcarCamino(int direccion)
        {
            if (SePuedeAvanzar(direccion))
            {
                switch (direccion)
                {
                    case 0:
                        actual.X--;
                        break;
                    case 1:
                        actual.Y--;
                        break;
                    case 2:
                        actual.X++;
                        break;
                    case 3:
                        actual.Y++;
                        break;
                    default:
                        break;
                }
                celdas[actual.X, actual.Y].GetParedes()[4] = true;
            }
        }
        private bool SePuedeAvanzar(int direccion)
        {
            bool[] paredes = celdas[actual.X, actual.Y].GetParedes();
            bool caminado = false;
            switch (TipoDePosicion())
            {
                case 0:
                    switch (direccion)
                    {
                        case 2:
                            caminado = (celdas[actual.X + 1, actual.Y].GetParedes()[4]);
                            break;
                        case 3:
                            caminado = (celdas[actual.X, actual.Y + 1].GetParedes()[4]);
                            break;
                        default:
                            break;
                    }
                    break;
                case 1:
                    switch (direccion)
                    {
                        case 0:
                            caminado = (celdas[actual.X - 1, actual.Y].GetParedes()[4]);
                            break;
                        case 3:
                            caminado = (celdas[actual.X, actual.Y + 1].GetParedes()[4]);
                            break;
                        default:
                            break;
                    }
                    break;
                case 2:
                    switch (direccion)
                    {
                        case 0:
                            caminado = (celdas[actual.X - 1, actual.Y].GetParedes()[4]);
                            break;
                        case 1:
                            caminado = (celdas[actual.X, actual.Y - 1].GetParedes()[4]);
                            break;
                        default:
                            break;
                    }
                    break;
                case 3:
                    switch (direccion)
                    {
                        case 1:
                            caminado = (celdas[actual.X, actual.Y - 1].GetParedes()[4]);
                            break;
                        case 2:
                            caminado = (celdas[actual.X + 1, actual.Y].GetParedes()[4]);
                            break;
                        default:
                            break;
                    }
                    break;
                case 4:
                    switch (direccion)
                    {
                        case 1:
                            caminado = (celdas[actual.X, actual.Y - 1].GetParedes()[4]);
                            break;
                        case 2:
                            caminado = (celdas[actual.X + 1, actual.Y].GetParedes()[4]);
                            break;
                        case 3:
                            caminado = (celdas[actual.X, actual.Y + 1].GetParedes()[4]);
                            break;
                        default:
                            break;
                    }
                    break;
                case 5:
                    switch (direccion)
                    {
                        case 0:
                            caminado = (celdas[actual.X - 1, actual.Y].GetParedes()[4]);
                            break;
                        case 1:
                            caminado = (celdas[actual.X, actual.Y - 1].GetParedes()[4]);
                            break;
                        case 3:
                            caminado = (celdas[actual.X, actual.Y + 1].GetParedes()[4]);
                            break;
                        default:
                            break;
                    }
                    break;
                case 6:
                    switch (direccion)
                    {
                        case 0:
                            caminado = (celdas[actual.X - 1, actual.Y].GetParedes()[4]);
                            break;
                        case 2:
                            caminado = (celdas[actual.X + 1, actual.Y].GetParedes()[4]);
                            break;
                        case 3:
                            caminado = (celdas[actual.X, actual.Y + 1].GetParedes()[4]);
                            break;
                        default:
                            break;
                    }
                    break;
                case 7:
                    switch (direccion)
                    {
                        case 0:
                            caminado = (celdas[actual.X - 1, actual.Y].GetParedes()[4]);
                            break;
                        case 1:
                            caminado = (celdas[actual.X, actual.Y - 1].GetParedes()[4]);
                            break;
                        case 2:
                            caminado = (celdas[actual.X + 1, actual.Y].GetParedes()[4]);
                            break;
                        default:
                            break;
                    }
                    break;
                case 8:
                    switch (direccion)
                    {
                        case 0:
                            caminado = (celdas[actual.X - 1, actual.Y].GetParedes()[4]);
                            break;
                        case 1:
                            caminado = (celdas[actual.X, actual.Y - 1].GetParedes()[4]);
                            break;
                        case 2:
                            caminado = (celdas[actual.X + 1, actual.Y].GetParedes()[4]);
                            break;
                        case 3:
                            caminado = (celdas[actual.X, actual.Y + 1].GetParedes()[4]);
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            return (!(paredes[direccion])&&(!caminado));
        }
    }
}
