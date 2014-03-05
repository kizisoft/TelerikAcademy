namespace Infestation
{
    using System.Collections.Generic;
    using System.Linq;

    class Queen : Parasite
    {
        private const int initialHealth = 30;
        private const int initialPower = 1;
        private const int initialAggression = 1;

        public Queen(string id)
            : base(id, UnitClassification.Psionic, Queen.initialHealth, Queen.initialPower, Queen.initialAggression)
        {
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            UnitInfo optimalAttackableUnit = new UnitInfo(null, UnitClassification.Unknown, 0, int.MaxValue, 0);
            int minHealth = int.MaxValue;

            foreach (var unit in attackableUnits)
            {
                if (unit.Health < minHealth)
                {
                    optimalAttackableUnit = unit;
                    minHealth = unit.Health;
                }
            }

            return optimalAttackableUnit;
        }
    }
}