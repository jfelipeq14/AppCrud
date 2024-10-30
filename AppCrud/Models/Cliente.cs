namespace AppCrud.Models
{
    public class Cliente
    {
        public int IdEmpleado { get; set; }
        public int IdUsuario { get; set; }
        public int IdMunicipio { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Sexo { get; set; }
        public string TipoDeSangre { get; set; }
        public string Eps { get; set; }
        public bool Estado { get; set; }
    }
}
