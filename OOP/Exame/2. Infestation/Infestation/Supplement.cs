namespace Infestation
{
    abstract public class Supplement : ISupplement
    {
        private int powerEffect;
        private int healthEffect;
        private int aggressionEffect;

        public Supplement(int powerEffect, int healthEffect, int aggressionEffect)
        {
            this.powerEffect = powerEffect;
            this.healthEffect = healthEffect;
            this.aggressionEffect = aggressionEffect;
        }

        public virtual int PowerEffect
        {
            get { return this.powerEffect; }
        }

        public virtual int HealthEffect
        {
            get { return this.healthEffect; }
        }

        public virtual int AggressionEffect
        {
            get { return this.aggressionEffect; }
        }

        public virtual void ReactTo(ISupplement otherSupplement)
        {
        }
    }
}