// Cargar datos de cadeteria
// Cargar datos de cadetes

var Pedidos = new List<Pedido>();

Cadeteria cadeteria = new Cadeteria();
Console.WriteLine("Que tarea quiere ejecutar");
Console.WriteLine("[1] Dar de alta pedidos");
Console.WriteLine("[2] Asignar un pedido");
Console.WriteLine("[3] Cambiar de estado un pedido");
Console.WriteLine("[4] Cambiar un pedido de cadete");
int nro = 0;

//Dar de alta pedidos

Pedido pedidoRemovible = (cadeteria.ListadoCadetes.

//Ingresar pedidos

Console.WriteLine("Ingrese el nro del pedido a asignar");

foreach (var pedido in Pedidos)
{
    Console.WriteLine($"Pedido numero: {pedido.nro}");
    Console.WriteLine($"Cliente: {pedido.cliente.nombre}");
    Console.WriteLine($"Estado del pedido: {pedido.estado}");
    Console.WriteLine("----------------------------------");
}

int index= Convert.ToInt32(Console.ReadLine());
var pedidoAsignable = Pedidos[index+1];

Console.WriteLine("A que cadete quiere asignarle el pedido");

foreach (var cadete in cadeteria.ListadoCadetes)
{
    Console.WriteLine($"Pedido numero: {cadete.id}");
    Console.WriteLine($"Nombre del cadete: {cadete.nombre}");
    Console.WriteLine($"Cantidad de pedidos actual: {cadete.listadoPedidos.Count()}");
    Console.WriteLine("----------------------------------");   
}

index= Convert.ToInt32(Console.ReadLine());

cadeteria.ListadoCadetes[index+1].listadoPedidos.Add(pedidoAsignable);

//Cambiar de estado un pedido

Console.WriteLine("Elija el pedido a cambiar");

foreach (var cadete in cadeteria.ListadoCadetes)
{
    Console.WriteLine($"Pedido numero: {cadete.id}");
    Console.WriteLine($"Nombre del cadete: {cadete.nombre}");
    Console.WriteLine($"Cantidad de pedidos actual: {cadete.listadoPedidos.Count()}");
    foreach (var pedido in cadete.listadoPedidos)
    {
        Console.WriteLine($"Pedido numero: {pedido.nro}");
        Console.WriteLine($"Cliente: {pedido.cliente.nombre}");
        Console.WriteLine($"Estado del pedido: {pedido.estado}");
        Console.WriteLine("----------------------------------");
        
    }
    Console.WriteLine("----------------------------------");
}



