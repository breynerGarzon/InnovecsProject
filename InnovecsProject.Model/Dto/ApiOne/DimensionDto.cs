namespace InnovecsProject.Model.Dto.ApiOne
{
    public class DimensionDto
    {
        public int High { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public int Volumen { get { return High * Width * Length; } }
    }
}