namespace SheepAndWolves
{
    public struct StateSide
    {
        public int SheepCount, WolfCount;
        public bool HasBoat;

        public StateSide(int sheepCount, int wolfCount, bool hasBoat)
        {
            SheepCount = sheepCount;
            WolfCount = wolfCount;
            HasBoat = hasBoat;
        }
    }
}