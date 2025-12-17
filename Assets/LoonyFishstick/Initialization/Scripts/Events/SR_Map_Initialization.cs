
namespace LF.Initialization
{
    public readonly struct SR_Map_Initialization
    {
        public SR_Map_Initialization(string mapName, int hexasphereSubdivisions)
        {
            this.mapName = mapName;
            this.hexasphereSubdivisions = hexasphereSubdivisions;
        }

        public readonly string mapName;
        public readonly int hexasphereSubdivisions;
    }
}
