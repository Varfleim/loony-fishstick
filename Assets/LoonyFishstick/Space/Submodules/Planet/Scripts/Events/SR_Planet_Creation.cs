namespace LF.Planet
{
    public readonly struct SR_Planet_Creation
    {
        public SR_Planet_Creation(
            string planetName)
        {
            this.planetName = planetName;
        }

        public readonly string planetName;
    }
}