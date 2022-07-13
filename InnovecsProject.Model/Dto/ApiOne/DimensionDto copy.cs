namespace InnovecsProject.Model.Dto.ApiOne
{
    public class DimensionPriceDto
    {
        public int High { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public int Volumen { get { return High * Width * Length; } }
        public int Price { get; set; }
        public int Distance { get; set; }
    }
}