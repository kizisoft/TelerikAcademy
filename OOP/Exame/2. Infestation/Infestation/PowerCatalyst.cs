namespace Infestation
{
    public class PowerCatalyst : Supplement
    {
        private const int powerEffect = 3;
        private const int healthEffect = 0;
        private const int aggressionEffect = 0;

        public PowerCatalyst()
            : base(PowerCatalyst.powerEffect, PowerCatalyst.healthEffect, PowerCatalyst.aggressionEffect)
        {
        }
    }
}