internal class Program
{
    public class Arbol  //clase
    {
        public float sueldos;
        public Arbol izq;   //rama (nodo) izquierda
        public Arbol der;   //rama (nodo) derecha

        public Arbol()  //constructor
        {
            this.izq = null;
            this.der = null;
            this.sueldos = 0;
        }
    }
    private static void Main(string[] args)
    {
        Console.Title = "ARBOL - INSERTAR, ELIMINAR, BUSCAR Y RECORRER EN PREORDEN -";
        int op = 0; int continuar; // variables de opcion
        raiz = null;
        Console.Clear();

        while (op != 5)
        {
            string[] OpcionesMenu = { "Insertar sueldo", "Recorrido en orden previo", "Eliminar sueldo", "Busqueda de un sueldo", "Salida" };
            var Menu = new Menu(OpcionesMenu, 1, 1);

            Menu.ModifyMenuCentered();
            Menu.CenterMenuToConsole();
            Menu.ResetCursorVisible();
            op = Menu.RunMenu();
             switch (op)
             {
                case 0: //insercion
                    do
                    {
                        Console.Clear();
                        Console.Write("INSERTAR SUELDO \n\n");
                        Insertar();
                        Console.Write("\n\n¿Desea ingresar otro sueldo? Si = [1] / No = [2]: ");
                        continuar = Convert.ToInt32(Console.ReadLine());
                    } while (continuar.Equals(1));
                    Console.WriteLine("\n\nInsercion exitosa ENTER para continuar");
                    Console.ReadKey();
                    break;

                case 1: //Recorrido preorden

                    Console.Clear();
                    Console.Write("RECORRIDO EN ORDEN PREVIO \n\n");
                    PreOrden(raiz);
                    Console.WriteLine("\n\nFin del recorrido...presione ENTER para continuar");
                    Console.ReadKey();
                    break;

                case 2: //Eliminacion

                    Console.Clear();
                    Console.Write("ELIMINAR SUELDO \n\n");
                    Console.Write("¿Que Sueldo desea eliminar?");
                    float elim = Convert.ToSingle(Console.ReadLine());
                    Eliminar(ref raiz, elim);
                    Console.WriteLine("\n\nPresione ENTER para continuar");
                    Console.ReadKey();
                    break;

                case 3: //busqueda

                    Console.Clear();
                    Console.Write("BUSQUEDA DE UN SUELDO \n\n");
                    Console.Write("¿Que Sueldo desea buscar?");
                    float busca = Convert.ToSingle(Console.ReadLine());
                    Buscar(ref raiz, busca);
                    Console.WriteLine("\n\nPresione ENTER para continuar");
                    Console.ReadKey();
                    break;

                case 4: //salida
                    Console.Clear();
                    Environment.Exit(0);
                    break;

            }
        }
    }

    public static float sue; //variable calificacion
    static Arbol raiz; //variable raiz
    static Arbol q; static Arbol p;

    public static void Insertar()
    {
        Console.Write("Ingrese el sueldo: "); //captura
        sue = Convert.ToSingle(Console.ReadLine());

        int bandera;

        if (raiz == null)  //raiz
        {
            raiz = new Arbol
            {
                sueldos = sue,
                izq = null,
                der = null,
            };
            Console.WriteLine("\n\nSueldo insertado...");
        }
        else
        {
            p = raiz; bandera = 0;
            do
            {
                //insercion dependiendo del valor
                if (sue >= p.sueldos)  //busqueda lado derecho
                {
                    if (p.der == null)
                    {
                        q = new Arbol
                        {
                            sueldos = sue,
                            izq = null,
                            der = null,
                        }; p.der = q;
                        bandera = 1;
                    }
                    else p = p.der;
                }
                else
                {
                    if (p.izq == null)  //busqueda lado izquierdo
                    {
                        q = new Arbol
                        {
                            sueldos = sue,
                            izq = null,
                            der = null,
                        }; p.izq = q;
                        bandera = 1;
                    }
                    else p = p.izq;
                }
            } while (bandera == 0);
            Console.WriteLine("\n\nSueldo insertado...");
        }
    }
    //Metodos recorridos
    public static void PreOrden(Arbol raiz)  //R I D
    {
        if (raiz != null)
        {
            Console.Write(" {0:C} ", raiz.sueldos);
            PreOrden(raiz.izq);  //recursividad
            PreOrden(raiz.der);
        }
    }

    public static void Eliminar(ref Arbol raiz, float elim)
    {
        if (raiz != null)
        {
            if (elim < raiz.sueldos)
            {
                Eliminar(ref raiz.izq, elim);   //recursividad
            }
            else
            {
                if (elim > raiz.sueldos)
                {
                    Eliminar(ref raiz.der, elim);  //recursividad
                }
                else
                {
                    if (elim > raiz.sueldos)
                    {
                        Eliminar(ref raiz.der, elim);  //recursividad
                    }
                    else  //acomoda los nodos dependiendo de la eliminacion
                    {
                        Arbol elimina = raiz;
                        if (elimina.der == null)
                        {
                            raiz = elimina.izq;
                        }
                        else
                        {
                            if (elimina.izq == null)
                            {
                                raiz = elimina.der;
                            }
                            else
                            {
                                Arbol auxiliar = null;
                            Arbol aux = raiz.izq;
                            bool bandera = false;
                           while (aux.der != null)
                            {
                                auxiliar = aux;
                                aux = aux.der;
                                bandera = true;
                            }
                            raiz.sueldos = aux.sueldos;
                            elimina = aux;
                            if (bandera == true)
                            {
                                auxiliar.der = aux.izq;
                            }
                            else
                            {
                                raiz.izq = aux.izq;
                            }
                        
                        }
                    }
                    Console.WriteLine("\nSueldo {0:C} eliminado", elim);
                }
               }

            }
        }
        else
        {
            Console.WriteLine("\nEl sueldo {0:C} no existe", elim);
        }
    }

    public static void Buscar(ref Arbol raiz, float busca)  //metodo para buscar sueldos
    {
        if (raiz == null)  //si no hay elementos
        {
            Console.WriteLine("\nEl sueldo {0:C} no existe en el arbol binario", busca);
        }
        else
        {
            if (busca == raiz.sueldos)
            {
                Console.WriteLine("\nEl sueldo {0:C} si existe en el arbol binario", busca);
            }
            else
            {
                if (busca < raiz.sueldos)
                {
                    Buscar(ref raiz.izq, busca);  //recursividad rama izquierda
                }
                else
                {
                    Buscar(ref raiz.der, busca);  //recursividad rama derecha
                }
            }
        }
    }
}