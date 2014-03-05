namespace Infestation
{
    public class HealthCatalyst : Supplement
    {
        private const int powerEffect = 0;
        private const int healthEffect = 3;
        private const int aggressionEffect = 0;

        public HealthCatalyst()
            : base(HealthCatalyst.powerEffect, HealthCatalyst.healthEffect, HealthCatalyst.aggressionEffect)
        {
        }
    }
}