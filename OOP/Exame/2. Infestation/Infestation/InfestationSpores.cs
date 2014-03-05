namespace Infestation
{
    public class InfestationSpores : Supplement
    {
        private const int powerEffect = -1;
        private const int healthEffect = 0;
        private const int aggressionEffect = 20;

        private bool isActive;

        public InfestationSpores()
            : base(InfestationSpores.powerEffect, InfestationSpores.healthEffect, InfestationSpores.aggressionEffect)
        {
            this.isActive = true;
        }

        public override int AggressionEffect
        {
            get
            {
                if (this.isActive)
                {
                    return base.AggressionEffect;
                }

                return 0;
            }
        }

        public override int PowerEffect
        {
            get
            {
                if (this.isActive)
                {
                    return base.PowerEffect;
                }

                return 0;
            }
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            var infestationSpore = otherSupplement as InfestationSpores;
            if (infestationSpore != null && infestationSpore.isActive)
            {
                this.isActive = false;
            }
        }
    }
}