namespace Infestation
{
    public class Weapon : Supplement
    {
        private const int powerEffect = 10;
        private const int healthEffect = 0;
        private const int aggressionEffect = 3;

        private bool isActive;

        public Weapon()
            : base(Weapon.powerEffect, Weapon.healthEffect, Weapon.aggressionEffect)
        {
            this.isActive = false;
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
            var weaponrySkill = otherSupplement as WeaponrySkill;
            if (weaponrySkill != null)
            {
                this.isActive = true;
            }
        }
    }
}