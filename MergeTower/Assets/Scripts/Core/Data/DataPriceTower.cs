namespace Towers
{
    public class DataPriceTower
    {
        private TypeTower typeTower;
        private int priceTower;

        public TypeTower GetTypeTower { get => typeTower; }
        public int GetPriceTower { get => priceTower; }

        public DataPriceTower(TypeTower typeTower, int priceTower)
        {
            this.typeTower = typeTower;
            this.priceTower = priceTower;
        }
    }
}