public class Cliente
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Correo { get; set; }
    public string Empresa { get; set; }
    public ICollection<Factura>? Facturas { get; set; }
}