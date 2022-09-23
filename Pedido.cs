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
}