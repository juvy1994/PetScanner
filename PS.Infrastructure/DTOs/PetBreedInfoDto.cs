public class PetBreedInfoDto
{
    public string nombre_raza { get; set; }
    public string especie { get; set; }
    public string origen { get; set; }
    public CaracteristicasFisicas caracteristicas_fisicas { get; set; }
    public string comportamiento { get; set; }
    public Alimentacion alimentacion { get; set; }
    public CuidadosEspeciales cuidados_especiales { get; set; }
    public List<EnfermedadComun> enfermedades_comunes { get; set; }

    public class CaracteristicasFisicas
    {
        public string tamano { get; set; }
        public string peso { get; set; }
        public string esperanza_vida { get; set; }
        public string pelaje { get; set; }
    }

    public class Alimentacion
    {
        public string tipo_recomendada { get; set; }
        public string porciones { get; set; }
        public string frecuencia { get; set; }
    }

    public class CuidadosEspeciales
    {
        public string ejercicio { get; set; }
        public string socializacion { get; set; }
    }

    public class EnfermedadComun
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string prevencion { get; set; }
    }

    public string UrlImage { get; set; }
}