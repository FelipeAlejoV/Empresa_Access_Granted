public class Factura
{
    public int Id { get; set; }
    public string Servicio { get; set; }
    public decimal Monto { get; set; }
    public DateTime Fecha { get; set; }

    public int ClienteId { get; set; }
    public Cliente? Cliente { get; set; }
}