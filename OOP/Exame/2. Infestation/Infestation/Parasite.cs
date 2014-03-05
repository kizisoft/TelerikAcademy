namespace Infestation
{
    using System.Collections.Generic;
    using System.Linq;

    public class Parasite : Unit
    {
        private const int initialHealth = 1;
        private const int initialPower = 1;
        private const int initialAggression = 1;

        public Parasite(string id)
            : base(id, UnitClassification.Biological, Parasite.initialHealth, Parasite.initialPower, Parasite.initialAggression)
        {
        }

        protected Parasite(string id, UnitClassification unitType, int health, int power, int aggression)
            : base(id, unitType, health, power, aggression)
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

        public override Interaction DecideInteraction(IEnumerable<UnitInfo> units)
        {
            IEnumerable<UnitInfo> attackableUnits = units.Where((unit) => this.CanAttackUnit(unit));

            UnitInfo optimalAttackableUnit = GetOptimalAttackableUnit(attackableUnits);

            if (optimalAttackableUnit.Id != null)
            {
                return new Interaction(new UnitInfo(this), optimalAttackableUnit, InteractionType.Infest);
            }

            return Interaction.PassiveInteraction;
        }

        protected override bool CanAttackUnit(UnitInfo unit)
        {
            if (this.Id != unit.Id)
            {
                var unitClassificationRequired = InfestationRequirements.RequiredClassificationToInfest(unit.UnitClassification);
                if (this.UnitClassification == unitClassificationRequired)
                {
                    return true;
                }
            }

            return base.CanAttackUnit(unit);
        }
    }
}