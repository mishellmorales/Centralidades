using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centralidades
{
    class Grafo
    {
        private Dictionary<int, List<int>> adyacencias;

        public Grafo()
        {
            adyacencias = new Dictionary<int, List<int>>();
        }

        // Método para agregar nodos al grafo
        public void AgregarNodo(int nodo)
        {
            if (!adyacencias.ContainsKey(nodo))
            {
                adyacencias[nodo] = new List<int>();
            }
        }

        // Método para agregar una arista entre dos nodos
        public void AgregarArista(int nodo1, int nodo2)
        {
            if (adyacencias.ContainsKey(nodo1) && adyacencias.ContainsKey(nodo2))
            {
                adyacencias[nodo1].Add(nodo2);
                adyacencias[nodo2].Add(nodo1);
            }
        }

        // Calcular la centralidad de grado
        public int CentralidadGrado(int nodo)
        {
            return adyacencias.ContainsKey(nodo) ? adyacencias[nodo].Count : 0;
        }

        // Calcular la centralidad de cercanía usando BFS (Breadth-First Search)
        public double CentralidadCercania(int nodo)
        {
            int totalNodos = adyacencias.Count;
            int[] distancias = BFS(nodo);
            int sumaDistancias = 0;

            foreach (int distancia in distancias)
            {
                if (distancia > 0)
                {
                    sumaDistancias += distancia;
                }
            }

            return sumaDistancias > 0 ? (double)(totalNodos - 1) / sumaDistancias : 0;
        }

        // Algoritmo BFS para calcular distancias más cortas
        private int[] BFS(int nodoInicio)
        {
            int[] distancias = new int[adyacencias.Count];
            Queue<int> cola = new Queue<int>();
            HashSet<int> visitados = new HashSet<int>();

            cola.Enqueue(nodoInicio);
            visitados.Add(nodoInicio);
            distancias[nodoInicio] = 0;

            while (cola.Count > 0)
            {
                int nodoActual = cola.Dequeue();

                foreach (int vecino in adyacencias[nodoActual])
                {
                    if (!visitados.Contains(vecino))
                    {
                        cola.Enqueue(vecino);
                        visitados.Add(vecino);
                        distancias[vecino] = distancias[nodoActual] + 1;
                    }
                }
            }

            return distancias;
        }

        // Método para mostrar la centralidad de grado de todos los nodos
        public void MostrarCentralidadGrado()
        {
            Console.WriteLine("Centralidad de Grado:");
            foreach (var nodo in adyacencias.Keys)
            {
                Console.WriteLine($"Nodo {nodo}: {CentralidadGrado(nodo)}");
            }
        }

        // Método para mostrar la centralidad de cercanía de todos los nodos
        public void MostrarCentralidadCercania()
        {
            Console.WriteLine("Centralidad de Cercanía:");
            foreach (var nodo in adyacencias.Keys)
            {
                Console.WriteLine($"Nodo {nodo}: {CentralidadCercania(nodo):F2}");
            }
        }
    }
}
