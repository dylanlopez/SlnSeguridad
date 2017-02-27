namespace Domain_Layer.Dtos.Sistemas
{
    public class DSistemaDto
    {
        public DSistemaDto()
        {
            Id = 0;
            Codigo = string.Empty;
            Nombre = string.Empty;
            Abreviatura = string.Empty;
            Descripcion = string.Empty;
            Estado = '\0';
        }

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }
        public string Descripcion { get; set; }
        public char Estado { get; set; }
    }
}