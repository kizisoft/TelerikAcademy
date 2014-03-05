namespace Infestation
{
    public class AggressionCatalyst : Supplement
    {
        private const int powerEffect = 0;
        private const int healthEffect = 0;
        private const int aggressionEffect = 3;

        public AggressionCatalyst()
            : base(AggressionCatalyst.powerEffect, AggressionCatalyst.healthEffect, AggressionCatalyst.aggressionEffect)
        {
        }
    }
}