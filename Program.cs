using static System.Console;
string dni=string.Empty;
decimal salario;
decimal retencion;
decimal sNeto;
double gradosCelsius;
bool check=false;
bool continuar = true;
    while (continuar)
    {
        Clear();
        WriteLine("==========================================");
        WriteLine("Menu principal");
        WriteLine("");
        WriteLine("1-DNI");
        WriteLine("");
        WriteLine("2-Calcular el Salario Neto");
        WriteLine("");
        WriteLine("3-Convertir Grados Celsius a Farenheit");
        WriteLine("");
        WriteLine("0-Salir");
        WriteLine("");
        WriteLine("==========================================");
        Write("Insete una opcion: ");
        int opcion = Convert.ToInt32(ReadLine());
        switch (opcion)
        {
            case 1:
               Write("Escriba su numero de DNI:");
               dni=ReadLine();
               check=validarDNI(dni);
               if(check==true){
                WriteLine("DNI Correcto");
               }else{
                WriteLine("DNI Incorrecto");
               }

                break;
            case 2:
                Write("Introduzca el salario base: ");
                salario=Convert.ToInt32(ReadLine());
                Write("Introduzca la retencion: ");
                retencion=Convert.ToInt32(ReadLine());

                sNeto=CalcularSalarioNeto(salario,retencion);
                WriteLine("El salario neto es de : "+ sNeto);

                break;
            case 3:
                Write("Introduzca los grados celsius: ");
                gradosCelsius=Convert.ToInt32(ReadLine());
            
                gradosCelsius=ConvertirCelsiusAFahrenheit(gradosCelsius);
                WriteLine("Los Grados Celsius son: "+ gradosCelsius + " grados Farenheit");

                break;
            case 0:
                continuar = false;
                break;
            default:
                WriteLine("Entre un valor válido");
                break;
        }
        if (continuar) 
        {
            WriteLine("Presione cualquier tecla para continuar...");
            ReadKey(); //Console.ReadKey();
        }
    }
bool validarDNI(string dni)
{
    bool valido = false;
    if (dni.Length == 9)
    {
        string numero = dni.Substring(0, 8);
        string letra = dni.Substring(8, 1).ToUpper();
        if (int.TryParse(numero, out int n))
        {
            int resto = n % 23;
            string letras = "TRWAGMYFPDXBNJZSQVHLCKE";
            valido = letra == letras[resto].ToString();
        }
    }
    return valido;
}
decimal CalcularSalarioNeto(decimal salarioBruto, decimal retencion)
{
    decimal salarioNeto = salarioBruto - (salarioBruto * retencion / 100);
    return salarioNeto;
}

double ConvertirCelsiusAFahrenheit(double gradosCelsius)
{
    double gradosFahrenheit = (gradosCelsius * 9 / 5) + 32;
    return gradosFahrenheit;
}