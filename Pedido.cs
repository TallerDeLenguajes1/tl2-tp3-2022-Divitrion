public enum Estado
{
    Pendiente,
    EnCurso,
    Entregado
}

public class Pedido
{
    public int nro;
    public string obs;
    public Cliente cliente;
    public Estado estado;

    public Pedido(Cliente cliente)
    {
        this.obs = "a";
        this.cliente = new Cliente();
        this.estado = Estado.Pendiente;
    }
}