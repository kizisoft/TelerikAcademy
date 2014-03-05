namespace Infestation
{
    public class Tank : Unit
    {
        private const int initialHealth = 20;
        private const int initialPower = 25;
        private const int initialAggression = 25;

        public Tank(string id)
            : base(id, UnitClassification.Mechanical, Tank.initialHealth, Tank.initialPower, Tank.initialAggression)
        {

        }
    }
}