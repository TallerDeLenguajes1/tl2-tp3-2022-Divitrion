public class Cadete : Persona
{
    public List<Pedido> listadoPedidos;

    public void JornalACobrar()
    {

    }

    public Cadete()
    {
        listadoPedidos=new List<Pedido>();
    }

    public void recibirPedido(Pedido pedido)
    {
        listadoPedidos.Add(pedido);
    }
}