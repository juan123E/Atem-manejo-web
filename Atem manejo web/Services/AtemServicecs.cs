using BMDSwitcherAPI;
using System.Runtime.InteropServices;

public class AtemService
{
    private IBMDSwitcherDiscovery switcherDiscovery;
    private IBMDSwitcher switcher;

    public AtemService()
    {
        // Instanciar el objeto de descubrimiento sin usar CoCreateInstance
        switcherDiscovery = new CBMDSwitcherDiscovery();
    }

    public String Connect(string ipAddress)
    {
        var answer = "";

        try
        {
            // Conectar al ATEM usando la dirección IP
            switcherDiscovery.ConnectTo(ipAddress, out switcher, out _); 
            Console.WriteLine("Conexión exitosa al ATEM");
            Console.WriteLine(ipAddress);
            answer = "Conexión exitosa al ATEM";
            return answer;
        }
        catch (COMException ex)
        {
            Console.WriteLine($"Error COM: {ex.Message}, Código HRESULT: {ex.HResult}");
            Console.WriteLine(ipAddress);
            answer = "error";
            return answer;
        }
    }
     
}
