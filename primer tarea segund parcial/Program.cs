using System;

// Clase base Vehiculo
public class Vehiculo
{
    private int velocidad = 0; // Encapsulación
    private string marca;
    private string modelo;

    public int Velocidad
    {
        get { return velocidad; }
        protected set { velocidad = value; } // Cambiado a protected para permitir modificaciones en clases derivadas
    }

    public string Marca
    {
        get { return marca; }
        set { marca = value; }
    }

    public string Modelo
    {
        get { return modelo; }
        set { modelo = value; }
    }

    // Métodos virtuales para ser sobrescritos
    public virtual void Acelerar(int cuanto)
    {
        Velocidad += cuanto;
        Console.WriteLine("Vas a {0} KMS / Hora", Velocidad);
    }

    public virtual void Frenar(int cuanto)
    {
        Velocidad -= cuanto;
        if (Velocidad < 0) Velocidad = 0; // Evitar velocidad negativa
        Console.WriteLine("Frenaste. Ahora vas a {0} KMS / Hora", Velocidad);
    }

    public virtual void Encender()
    {
        Console.WriteLine("El vehículo está encendido.");
    }

    public virtual void Apagar()
    {
        Console.WriteLine("El vehículo está apagado.");
    }
}

// Clase AutoDeCombustión (hereda de Vehiculo)
public class AutoDeCombustion : Vehiculo
{
    private int nivelCombustible;
    private int capacidadTanque;
    private string tipoCombustible;

    public int NivelCombustible
    {
        get { return nivelCombustible; }
        private set { nivelCombustible = value; }
    }

    public int CapacidadTanque
    {
        get { return capacidadTanque; }
        set { capacidadTanque = value; }
    }

    public string TipoCombustible
    {
        get { return tipoCombustible; }
        set { tipoCombustible = value; }
    }

    public override void Acelerar(int cuanto)
    {
        base.Acelerar(cuanto);
        NivelCombustible -= cuanto / 10; // Gasta combustible al acelerar
        Console.WriteLine("Nivel de combustible: {0}%", NivelCombustible);
    }

    public override void Frenar(int cuanto)
    {
        base.Frenar(cuanto);
        NivelCombustible -= cuanto / 20; // Gasta un poco de combustible al frenar
    }

    // Sobrescritura de Encender y Apagar con comportamiento propio
    public override void Encender()
    {
        Console.WriteLine("El auto de combustión está encendido y listo para andar.");
    }

    public override void Apagar()
    {
        Console.WriteLine("El auto de combustión está apagado. Asegúrate de no dejar luces encendidas.");
    }
}

// Clase Motocicleta (hereda de Vehiculo)
public class Motocicleta : Vehiculo
{
    private int cilindrada;
    private bool tieneSidecar;
    private string tipoLicencia;

    public int Cilindrada
    {
        get { return cilindrada; }
        set { cilindrada = value; }
    }

    public bool TieneSidecar
    {
        get { return tieneSidecar; }
        set { tieneSidecar = value; }
    }

    public string TipoLicencia
    {
        get { return tipoLicencia; }
        set { tipoLicencia = value; }
    }

    public override void Acelerar(int cuanto)
    {
        base.Acelerar(cuanto * 2); // Acelera más rápido
    }

    public override void Frenar(int cuanto)
    {
        base.Frenar(cuanto);
        Console.WriteLine("La motocicleta ha frenado.");
    }

    // Sobrescritura de Encender y Apagar con comportamiento propio
    public override void Encender()
    {
        Console.WriteLine("La motocicleta está encendida. Lista para rodar.");
    }

    public override void Apagar()
    {
        Console.WriteLine("La motocicleta está apagada. No olvides el casco.");
    }
}

// Clase Camion (hereda de Vehiculo)
public class Camion : Vehiculo
{
    private int capacidadCarga;
    private int pesoActual;
    private string tipoCarga;

    public int CapacidadCarga
    {
        get { return capacidadCarga; }
        set { capacidadCarga = value; }
    }

    public int PesoActual
    {
        get { return pesoActual; }
        set { pesoActual = value; }
    }

    public string TipoCarga
    {
        get { return tipoCarga; }
        set { tipoCarga = value; }
    }

    public override void Acelerar(int cuanto)
    {
        base.Acelerar(cuanto / 2); // Acelera más lento
    }

    public override void Frenar(int cuanto)
    {
        base.Frenar(cuanto);
        Console.WriteLine("El camión ha frenado.");
    }

    // Sobrescritura de Encender y Apagar con comportamiento propio
    public override void Encender()
    {
        Console.WriteLine("El camión está encendido. Motor en marcha.");
    }

    public override void Apagar()
    {
        Console.WriteLine("El camión está apagado. Recuerda revisar la carga.");
    }
}

// Clase de prueba para ejecutar el código
public class Program
{
    public static void Main(string[] args)
    {
        // Crear un Auto de Combustión
        AutoDeCombustion auto = new AutoDeCombustion
        {
            Marca = "Toyota",
            Modelo = "Corolla",
            CapacidadTanque = 50,
            TipoCombustible = "Gasolina"
        };

        auto.Encender();
        auto.Acelerar(20);
        auto.Frenar(10);
        auto.Apagar();

        Console.WriteLine("\n");

        // Crear una Motocicleta
        Motocicleta moto = new Motocicleta
        {
            Marca = "Honda",
            Modelo = "CBR600RR",
            Cilindrada = 600,
            TieneSidecar = false,
            TipoLicencia = "A"
        };

        moto.Encender();
        moto.Acelerar(20);
        moto.Frenar(10);
        moto.Apagar();

        Console.WriteLine("\n");

        // Crear un Camión
        Camion camion = new Camion
        {
            Marca = "Volvo",
            Modelo = "FH16",
            CapacidadCarga = 20000,
            PesoActual = 15000,
            TipoCarga = "Material de construcción"
        };

        camion.Encender();
        camion.Acelerar(20);
        camion.Frenar(10);
        camion.Apagar();
    }
}