namespace Infestation
{
    using System.Collections.Generic;
    using System.Linq;

    public class Marine : Human
    {
        public Marine(string id)
            : base(id)
        {
            this.AddSupplement(new WeaponrySkill());
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            IEnumerable<UnitInfo> lesPowerUnits = from unit in attackableUnits
                                                  where (unit.Power <= this.Aggression)&&(unit.Id!=this.Id)
                                                  select unit;

            UnitInfo optimalAttackableUnit = new UnitInfo(null, UnitClassification.Unknown, 0, int.MaxValue, 0);
            int maxHealth = int.MinValue;

            foreach (var unit in lesPowerUnits)
            {
                if (unit.Health > maxHealth)
                {
                    optimalAttackableUnit = unit;
                    maxHealth = unit.Health;
                }
            }

            return optimalAttackableUnit;
        }
    }
}