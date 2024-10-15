using System;
public class InventarioProductos
{
    static string[] nombres = new string[1000];
    static double[] precios = new double[1000];
    static int[] cantidades = new int[1000];
    static int contadorProductos = 0;

    public static void agregar_producto(ref string nombre, ref double precio, ref int cantidad)
    {
        if (contadorProductos < 1000)
        {
            nombres[contadorProductos] = nombre;
            precios[contadorProductos] = precio;
            cantidades[contadorProductos] = cantidad;
            contadorProductos++;
            Console.WriteLine($"Producto {nombre} añadido al inventario.");
        }
        else
        {
            Console.WriteLine("El inventario está lleno. No se pueden añadir más productos.");
        }
    }

    public static void actualizar_stock(ref string nombre, ref int nuevaCantidad)
    {
        for (int i = 0; i < contadorProductos; i++)
        {
            if (nombres[i] == nombre)
            {
                cantidades[i] = nuevaCantidad;
                Console.WriteLine($"Stock del producto {nombre} actualizado a {nuevaCantidad} unidades.");
                return;
            }
        }
        Console.WriteLine($"Producto {nombre} no encontrado en el inventario.");
    }

    public static void calcular_valor_total(ref double valorTotal)
    {
        valorTotal = 0;
        for (int i = 0; i < contadorProductos; i++)
        {
            valorTotal += precios[i] * cantidades[i];
        }
    }

    public static void Main(string[] args)
    {
        int op;
        do
        {
            Console.WriteLine("\nSeleccione la opción deseada: ");
            Console.WriteLine("(1) Agregar nuevo producto");
            Console.WriteLine("(2) Actualizar stock de un producto");
            Console.WriteLine("(3) Calcular valor total del inventario");
            Console.WriteLine("(4) Salir");
            Console.Write("Elija una opción: ");

            op = int.Parse(Console.ReadLine());
            switch (op)
            {
                case 1:
                    string nombre = "";
                    double precio = 0;
                    int cantidad = 0;

                    Console.Write("Ingrese el nombre del producto: ");
                    nombre = Console.ReadLine();
                    Console.Write("Ingrese el precio del producto: ");
                    precio = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Ingrese la cantidad en stock: ");
                    cantidad = Convert.ToInt32(Console.ReadLine());

                    agregar_producto(ref nombre, ref precio, ref cantidad);
                    break;

                case 2:
                    Console.Write("Ingrese el nombre del producto a actualizar: ");
                    nombre = Console.ReadLine();
                    Console.Write("Ingrese la nueva cantidad en stock: ");
                    cantidad = Convert.ToInt32(Console.ReadLine());

                    actualizar_stock(ref nombre, ref cantidad);
                    break;

                case 3:
                    double valorTotal = 0;
                    calcular_valor_total(ref valorTotal);
                    Console.WriteLine($"El valor total del inventario es: {valorTotal}");
                    break;

                case 4: Console.WriteLine("¡Adiós!"); break;

                default: Console.WriteLine("Opción inválida, vuelva a intentarlo."); break;
            }
        }
        while (op != 4);
    }
}