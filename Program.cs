// Cargar datos de cadeteria
// Cargar datos de cadetes
Cadeteria cadeteria = new Cadeteria();
for (int i = 0; i < 5; i++)
{
    var cadetowo = new Cadete();
    cadetowo.id = i + 1;
    cadeteria.ListadoCadetes.Add(cadetowo);
}

var Pedidos = new List<Pedido>();
var Clientes = new List<Cliente>();

for (int i = 0; i < 5; i++)
{
    Cliente cliente = new Cliente();
    cliente.nombre = "Client" + (i + 1);
    Clientes.Add(cliente);
}

do
{
    Console.WriteLine("Que tarea quiere ejecutar");
    Console.WriteLine("[1] Dar de alta pedidos");
    Console.WriteLine("[2] Asignar un pedido");
    Console.WriteLine("[3] Cambiar de estado un pedido");
    Console.WriteLine("[4] Cambiar un pedido de cadete");
    var coso = Convert.ToInt32(Console.ReadLine());
    switch (coso)
    {
        case 1:
            AltaPedido(Pedidos, Clientes);
            break;
        case 2:
            AsignarPedido(Pedidos, cadeteria);
            break;
        case 3:
            CambiarEstado(cadeteria);
        break;
        case 4:
            CambiarCadete(cadeteria);
        break;
    }

} while (true);

static void AltaPedido(List<Pedido> Pedidos, List<Cliente> Clientes)
{
    int contador = 1;
    Console.WriteLine("Ingrese el cliente que hace el pedido\n");
    foreach (var cliente in Clientes)
    {
        Console.WriteLine($"Cliente numero: {contador}");
        Console.WriteLine($"Nombre del Cliente: {cliente.nombre}");
        Console.WriteLine($"Cantidad de pedidos a su nombre: {cliente.cantPedidos}");
        Console.WriteLine("----------------------------------");
        contador++;
    }
    contador = Convert.ToInt32(Console.ReadLine());
    Clientes[contador - 1].cantPedidos++;
    Pedido pedido = new Pedido(Clientes[contador - 1]);
    pedido.nro = managerDePedidos.contador;
    managerDePedidos.sumarPedido();
    Pedidos.Add(pedido);

}

static void AsignarPedido(List<Pedido> Pedidos, Cadeteria cadeteria)
{
    Console.WriteLine("Ingrese el nro del pedido a asignar");

    foreach (var pedido in Pedidos)
    {
        Console.WriteLine($"Pedido numero: {pedido.nro}");
        Console.WriteLine($"Cliente: {pedido.cliente.nombre}");
        Console.WriteLine($"Estado del pedido: {pedido.estado}");
        Console.WriteLine("----------------------------------");
    }

    int index = Convert.ToInt32(Console.ReadLine());
    var pedidoAsignable = Pedidos.Find(pedido => pedido.nro == index);

    Console.WriteLine("A que cadete quiere asignarle el pedido");

    foreach (var cadete in cadeteria.ListadoCadetes)
    {
        Console.WriteLine($"Cadete numero: {cadete.id}");
        Console.WriteLine($"Nombre del cadete: {cadete.nombre}");
        Console.WriteLine($"Cantidad de pedidos actual: {cadete.listadoPedidos.Count()}");
        Console.WriteLine("----------------------------------");
    }

    index = Convert.ToInt32(Console.ReadLine());

    var cadeteAsignable = cadeteria.ListadoCadetes.Find(cadete => cadete.id == index);

    Console.WriteLine(cadeteAsignable.id);
    cadeteAsignable.listadoPedidos.Add(pedidoAsignable);
    Pedidos.Remove(pedidoAsignable);
}

static void CambiarEstado(Cadeteria cadeteria)
{
    int index;
    Cadete cadeteConPedido;
    Pedido pedidoCambiable = null;

    Console.WriteLine("Elija el pedido a cambiar de estado\n");

    foreach (var cadete in cadeteria.ListadoCadetes)
    {
        if (cadete.listadoPedidos.Count() > 0)
        {
            Console.WriteLine($"Id Del Cadete: {cadete.id}");
            Console.WriteLine($"Nombre del cadete: {cadete.nombre}");
            Console.WriteLine($"Cantidad de pedidos actual: {cadete.listadoPedidos.Count()}");
            Console.WriteLine("///PEDIDOS ASIGNADOS A ESTE CADETE///\n");
            foreach (var pedido in cadete.listadoPedidos)
            {
                Console.WriteLine($"Pedido numero: {pedido.nro}");
                Console.WriteLine($"Cliente: {pedido.cliente.nombre}");
                Console.WriteLine($"Estado del pedido: {pedido.estado}");
                Console.WriteLine("----------------------------------");
            }
        }
    }
        Console.WriteLine("----------------------------------\n");
        index = Convert.ToInt32(Console.ReadLine());
        cadeteConPedido = cadeteria.ListadoCadetes.Find(cadete => cadete.listadoPedidos.Any(pedido => pedido.nro == index));
        pedidoCambiable = cadeteConPedido.listadoPedidos.Find(pedido => pedido.nro == index);
     Console.WriteLine("A que estado quiere cambiarlo? [1] Pendiente [2]En Curso [3]Entregado");
        index = Convert.ToInt32(Console.ReadLine());
        switch (index)
        {
            case 1:
                pedidoCambiable.estado = Estado.Pendiente;
                break;
            case 2:
                pedidoCambiable.estado = Estado.EnCurso;
                break;
            case 3: 
                pedidoCambiable.estado = Estado.Entregado;
                break;
        }
}

static void CambiarCadete(Cadeteria cadeteria)
{
    int index;
    Cadete cadeteConPedido;
    Pedido pedidoCambiable = null;

    Console.WriteLine("Elija el pedido a cambiar de cadete\n");

    foreach (var cadete in cadeteria.ListadoCadetes)
    {
        if (cadete.listadoPedidos.Count() > 0)
        {
            Console.WriteLine($"Id Del Cadete: {cadete.id}");
            Console.WriteLine($"Nombre del cadete: {cadete.nombre}");
            Console.WriteLine($"Cantidad de pedidos actual: {cadete.listadoPedidos.Count()}");
            Console.WriteLine("///PEDIDOS ASIGNADOS A ESTE CADETE///\n");
            foreach (var pedido in cadete.listadoPedidos)
            {
                if (pedido != null)
                {
                    Console.WriteLine($"Pedido numero: {pedido.nro}");
                    Console.WriteLine($"Cliente: {pedido.cliente.nombre}");
                    Console.WriteLine($"Estado del pedido: {pedido.estado}");
                    Console.WriteLine("----------------------------------");
                }
            }
        }
    }
    index = Convert.ToInt32(Console.ReadLine());
    cadeteConPedido = cadeteria.ListadoCadetes.Find(cadete => cadete.listadoPedidos.Any(pedido => pedido.nro == index));
    pedidoCambiable = cadeteConPedido.listadoPedidos.Find(pedido => pedido.nro == index);
    cadeteConPedido.listadoPedidos.Remove(pedidoCambiable);

    Console.WriteLine("A que cadete quiere asignarle el pedido");

    foreach (var cadete in cadeteria.ListadoCadetes)
    {
        Console.WriteLine($"Cadete numero: {cadete.id}");
        Console.WriteLine($"Nombre del cadete: {cadete.nombre}");
        Console.WriteLine($"Cantidad de pedidos actual: {cadete.listadoPedidos.Count()}");
        Console.WriteLine("----------------------------------");
    }

    index = Convert.ToInt32(Console.ReadLine());

    var cadeteAsignable = cadeteria.ListadoCadetes.Find(cadete => cadete.id == index);

    cadeteAsignable.listadoPedidos.Add(pedidoCambiable);
}

public static class managerDePedidos
{
    public static int contador=1;

    public static void sumarPedido()
    {
        contador++;
    }
}