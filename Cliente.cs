public class Cliente : Persona
{
    public string DatoReferenciaDireccion;
    public int cantPedidos;

    public Cliente()
    {
        this.DatoReferenciaDireccion="referencias";
        cantPedidos= 0;
    }
}