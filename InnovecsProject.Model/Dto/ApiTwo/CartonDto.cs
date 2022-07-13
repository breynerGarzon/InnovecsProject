namespace InnovecsProject.Model.Dto.ApiTwo
{
    public class CartonDto
    {
        public int High { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public int Volumen { get { return High * Width * Length; } }
    }
}