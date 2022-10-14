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

    public bool poseoBocha(int nro)
    {
        return listadoPedidos.Any(pedido => pedido.nro == nro);
    }

    public void removeBocha(int nro)
    {
        var pedidocursed = listadoPedidos.Find(pedido => pedido.nro == nro);
        listadoPedidos.Remove(pedidocursed);
    }
}