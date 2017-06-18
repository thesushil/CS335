namespace SheepAndWolves
{
    public struct StateSide
    {
        public readonly int SheepCount, WolvesCount;
        public bool HasBoat;

        public StateSide(int sheepCount, int wolvesCount, bool hasBoat)
        {
            SheepCount = sheepCount;
            WolvesCount = wolvesCount;
            HasBoat = hasBoat;
        }
    }
}