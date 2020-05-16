using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laberinto
{
    class PilaDeCeldas
    {
        int contador = 0;
        Celda[] pila;
        public PilaDeCeldas(int tamanio)
        {
            this.pila = new Celda[tamanio];
        }
        public int GetContador()
        {
            return contador;
        }
        private bool EstaLleno()
        {
            return contador == pila.Length;
        }
        private bool EstaVacio()
        {
            return contador == 0;
        }
        public void Push(Celda celda)
        {
            if (!EstaLleno())
            {
                pila[contador] = celda;
                contador++;
            }
        }
        public Celda Pop()
        {
            Celda celda = null;
            if (!EstaVacio())
            {
                contador--;
                celda = pila[contador];
                pila[contador] = null;
            }
            return celda;
        }
    }
}
