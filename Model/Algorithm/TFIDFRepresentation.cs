namespace Model.Algorithm
{
    public class TFIDFRepresentation
    {
        public double[] DistinguishingFeaturesDF { get; set; }
        public double[] DistinguishingFeaturesIDF { get; set; }

        public TFIDFRepresentation(int distinguishingFeaturesNumber)
        {
            DistinguishingFeaturesDF = new double[distinguishingFeaturesNumber];
            DistinguishingFeaturesIDF = new double[distinguishingFeaturesNumber];
        }
    }
}
