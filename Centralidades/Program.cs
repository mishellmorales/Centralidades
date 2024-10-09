namespace Centralidades
{
    // Programa principal para probar las centralidades
    class Program
    {
        static void Main()
        {
            Grafo grafo = new Grafo();

            // Agregar nodos al grafo (simulando usuarios en una red social)
            for (int i = 0; i < 5; i++)
            {
                grafo.AgregarNodo(i);
            }

            // Agregar aristas (simulando relaciones de amistad)
            grafo.AgregarArista(0, 1);
            grafo.AgregarArista(0, 2);
            grafo.AgregarArista(1, 3);
            grafo.AgregarArista(2, 4);
            grafo.AgregarArista(3, 4);

            // Mostrar las centralidades
            grafo.MostrarCentralidadGrado();
            grafo.MostrarCentralidadCercania();
            Console.Read();
        }
    }
}