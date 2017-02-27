namespace Domain_Layer.Dtos.Sistemas
{
    public class DMenuDto
    {
        public DMenuDto()
        {
            Id = 0;
            Codigo = string.Empty;
            Nombre = string.Empty;
            Ruta = string.Empty;
            Descripcion = string.Empty;
            Estado = '\0';
            Modulo = new DModuloDto();
        }

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Ruta { get; set; }
        public string Descripcion { get; set; }
        public char Estado { get; set; }
        public DModuloDto Modulo { get; set; }
    }
}