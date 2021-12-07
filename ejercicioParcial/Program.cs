//Se tiene una lista de 50 vendedores donde cada uno posee un código de vendedor y una cantidad de dinero recaudado. 
//Luego se ingresa código de vendedor, precio unitario de un producto y la cantidad vendida del mismo para actualizar el total de ventas 
//(suponer que el código de vendedor ingresado es válido). El ingreso de datos finaliza cuando el código del vendedor es 0 (inexistente). 
//Se pide:
//Actualizar el total de ventas por cada vendedor (dinero). 
//Generar un vector de los vendedores que han vendido más de 300 productos y mostrarlo por pantalla (si existe). 
//Ordenar el vector de vendedores por la cantidad de dinero recaudado de mayor a menor con arrastre de código de vendedor. 
//Mostrar todos los vectores luego de todos los procesos.

using System;

namespace ejercicioParcial
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] codigo = new int[] { 1, 2, 3, 4, 5 };
            float[] dinero = new float[] { 0, 0, 0, 0,0 };
            int[] cantidadVec = new int[5];
            float precio = 0;
            int cantidad = 0;
            int respuesta = 0;
            int[] masTrescientos = new int[5];
            float nuevoTotal = 0;
            int c = 0;
            int k = 0;
            int x = 5;
            float auxDinero = 0;
            int auxCodigo = 0;
            

            Console.WriteLine("Ingrese el código de vendedor: ");
            respuesta = int.Parse(Console.ReadLine());
            while (respuesta != 0)
            {
                int min = 0;
                int max = 5 - 1;
                int pivote;
                int pos = -1;
                Console.WriteLine("Ingrese el precio del producto vendido: ");
                precio = float.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese la cantidad vendida ");
                cantidad = int.Parse(Console.ReadLine());
                nuevoTotal = cantidad * precio;

                while ((min <= max) && (pos < 0))
                {
                    pivote = (min + max) / 2;
                    if (codigo[pivote] == respuesta)
                        pos = pivote;
                    if (codigo[pivote] < respuesta)
                        min = pivote + 1;
                    else
                        max = pivote - 1;
                }
                if (pos >= 0)
                {
                    dinero[pos] = nuevoTotal + dinero[pos];
                    cantidadVec[pos] = cantidad;
                    Console.WriteLine("El nuevo total vendido para este código es: " + dinero[pos]);
                }
                else
                { 
                    Console.WriteLine("El código es inexistente!!!!");
                }
                Console.WriteLine("Ingrese el código de vendedor: ");
                respuesta = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < 5; i++)
            {
                if(cantidadVec[i] > 300)
                {
                    masTrescientos[c] = codigo[i];
                    c++;
                }
            }            

            //genero un nuevo vector con ventas superiores a 300
            while ( k == 0)
            {
                k = 1;
                x--;
                for (int i = 0; i < x; i++)
                {
                    if (dinero[i] < dinero[i + 1])
                    {
                        k = 0;
                        auxDinero = dinero[i];
                        dinero[i] = dinero[i + 1];
                        dinero[i + 1] = auxDinero;

                        auxCodigo = codigo[i];
                        codigo[i] = codigo[i + 1];
                        codigo[i + 1] = auxCodigo;
                    }
                }
            }
            //muestro el vector generado con ventas mayores a 300 productos.
            if (c == 0)
            {
                Console.WriteLine("\nNigún vendedor supero los 300 productos vendidos.");
            }
            else
            {
                Console.WriteLine("\nListado de vendedores que han vendido mas de 300 productos:\n");
                for (int i = 0; i < c; i++)
                {
                    Console.WriteLine("Codigo de vendedor: " + masTrescientos[i]);
                }
            }
            //muestro el vector de ventas ordenado
            Console.WriteLine("\nListado ordenado de menor a mayor segun el dinero recaudado\n");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Codigo de vendedor: " + codigo[i] + " dinero total: " + dinero[i]);
            }

            //muestro el todos los datos de los vendedores
            Console.WriteLine("\nDatos de todos los vendedores: ");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("\nCódigo del vendedor:" + codigo[i]);
                Console.WriteLine("Dinero recaudado:" + dinero[i]);
                Console.WriteLine("Cantidad de productos vendidos:" + cantidadVec[i]);
            }

        }
    }
}
