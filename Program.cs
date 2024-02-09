using System.Reflection.Metadata;

int opcion = 0;
List<Persona> listaPersonas = new List<Persona>();

while (opcion != 2)
{

    try
    {
        Console.WriteLine("Desea ingresar datos: ");
        Console.WriteLine("1.Si 2.no ");
        opcion = int.Parse(Console.ReadLine());
        Console.Clear();
        if (opcion == 1)
        {
            pedirDatos();

        }
        if (opcion == 2)
        {
            filtrar();
        }
        if (opcion > 2 || opcion < 1)
        {
            Console.WriteLine("Debe seleccionar sola las opciones (1 o 2)");
        }

    }
    catch (Exception error)
    {
        Console.WriteLine("La opcio seleccionada tiene que ser un numero (1 o 2)");
    }

}
void pedirDatos()
{
    int hijos;
    int estrato;
    bool verificacionHijos;
    bool verificacionEstrato;
    Persona persona = new Persona();

    Console.WriteLine("Ingrese cantidad de hijos");
    verificacionHijos = int.TryParse(Console.ReadLine(), out hijos);//Realiza verificacion sobre el dato ingresado

    while (!verificacionHijos)
    {
        Console.WriteLine("Debe ser ingresado formato numerico");
        Console.WriteLine("Ingrese cantidad de hijos");
        verificacionHijos = int.TryParse(Console.ReadLine(), out hijos);
    }

    Console.WriteLine("Ingrese estrato social");
    verificacionEstrato = int.TryParse(Console.ReadLine(), out estrato);

    while (!verificacionEstrato)
    {
        Console.Write("Debe ingresar en formato numerico");
        verificacionEstrato = int.TryParse(Console.ReadLine(), out estrato);
    }

    persona.hijos = hijos;
    persona.estrato = estrato;
    listaPersona.Add(persona);

    int bono = Precio(persona.hijos, persona.estrato);
    persona.bono = bono;
    Console.WriteLine(bono);


    Console.ReadLine();
    Console.Clear();

}

void filtrar()
{
    int totalPersonasE1 = 0;
    int cantidadDineroE1 = 0;
    int totalPersonasE2 = 0;
    int cantidadDineroE2 = 0;
    int sinHijos = 0;
    int dineroSinHijos = 0;
    int dosHijos = 0;
    int dineroDosHijos = 0;
    int tresHijos = 0;
    int dineroTresHijos = 0;
    int totalBonosPagados = 0;

    foreach (Persona persona in listaPersonas)
    {
        totalBonosPagados += persona.bono;
        if (persona.estrato == 1)
        {
            totalPersonasE1++;
            cantidadDineroE1 += persona.bono;
        }
        else if (persona.estrato == 2)
        {
            totalPersonasE2++;
            cantidadDineroE2 += cantidadDineroE1 + persona.bono;
        }

        if (persona.hijos == 0)
        {
            sinHijos++;
            dineroSinHijos += persona.bono;
        }
        else if (persona.hijos <= 2)
        {
            dosHijos++;
            dineroDosHijos += persona.bono;

        }
        else
        {
            tresHijos++;
            dineroTresHijos += persona.bono;
        }
    }
    mostar(totalPersonasE1, totalPersonasE2, cantidadDineroE1, cantidadDineroE2, sinHijos, dosHijos, tresHijos, dineroSinHijos, dineroDosHijos, dineroTresHijos, totalBonosPagados);
}

void mostar(int TPE1, int TPE2, int CDE1, int CDE2, int SH, int DH, int TH, int DSH, int DDH, int DTH, int TPB)
{
    int numeroPersona = 1;
    foreach (Persona persona in listaPersona)
    {
        Console.WriteLine($"Persona #${numeroPersona}");
        Console.WriteLine($"Hijos: ${persona.hijos}");
        Console.WriteLine($"Estrato: ${persona.estrato}");
        Console.WriteLine($"Bono: ${persona.bono}");
        Console.WriteLine("");

        numeroPersona++;
    }
    Console.ReadLine();
    Console.Clear();

    Console.WriteLine($"Total de personas peternecietes a estrato 1: {TPE1}");
    Console.WriteLine($"Total de personas peternecietes a estrato 2: {TPE2}");
    Console.WriteLine($"Total de dinero entregado a estrato 1: {CDE1}");
    Console.WriteLine($"Total de dinero entregado a estrato 2: {CDE2}");
    Console.WriteLine("");

    Console.WriteLine($"Cantidad de personas que no tienen hijos: {SH}");
    Console.WriteLine($"Cantidad de personas que tienen hasta dos hijos: {DH}");
    Console.WriteLine($"Cantidad de personas que tienen mayor o igual a tres hijos: {TH}");
    Console.WriteLine("");

    Console.WriteLine($"Total de dinero entregado a los que no tiene hijos {DSH}");
    Console.WriteLine($"Total de dinero entregado a los que tienen hasta dos hijos {DDH}");
    Console.WriteLine($"Total de dinero entregado a los que tienen mayor o igual a tres hijos {DTH}");
    Console.WriteLine("");
    Console.WriteLine($"Total por bonos pagados: {TPB}");


}
//recuperar bono
int Precio(int hijos, int estrato)
{
    int bono = 0;
    if (estrato == 1)
    {
        if (hijos == 0)
        {
            bono = 50000;
        }
        else if (hijos == 1 || hijos == 2)
        {
            bono = 25000;
        }
        else
        {
            bono = 30000;
        }
    }
    else if (estrato == 2)
    {
        if (hijos == 0)
        {
            bono = 46500;
        }
        else if (hijos == 1 || hijos == 2)
        {
            bono = 21500;
        }
        else
        {
            bono = 26500;
        }
    }


    return bono;
}
class Persona
{
    public int hijos { get; set; }
    public int estrato { get; set; }
    public int bono { get; set; }
}


