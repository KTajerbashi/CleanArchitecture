namespace Design.Pattern.Library.Flyweight.Game
{
    public abstract class SoldierFlyWeight
    {
        public string SoldierType { get; set; }

        public void SetSoldierType(string soldierType)
        {
            this.SoldierType = soldierType;
        }
        public abstract void Render(int x, int y, int z, int number);
    }
    public class ConcreteSoldierFlyWeight : SoldierFlyWeight
    {
        public override void Render(int x, int y, int z, int number)
        {
            /// نمایش سرباز در محل مناسب
            Console.WriteLine(@$"
Soldier Type : {SoldierType}
Soldier Location x = {x} y = {y} z = {z}
Soldier Number : {number}
");
        }
    }


    public class SoldierFlyWeightFactory
    {
        private static Dictionary<string, SoldierFlyWeight> FlyWeights = new Dictionary<string, SoldierFlyWeight>();
        public SoldierFlyWeight GetSoldier(string soldierType)
        {
            SoldierFlyWeight soldierFlyWeight = null;
            if (FlyWeights.TryGetValue(soldierType, out soldierFlyWeight))
            {
            }
            else
            {
                SoldierFlyWeight concreteFlyWeight = new ConcreteSoldierFlyWeight();
                concreteFlyWeight.SetSoldierType(soldierType);
                FlyWeights.Add(soldierType, concreteFlyWeight);
            }

            return FlyWeights[soldierType];
        }
    }
}
