namespace ParticleSystem
{
    using System;
    using System.Collections.Generic;

    public class ChickenParticle : ChaoticParticle
    {
        private int timeToLay;
        private int layingTime;

        public ChickenParticle(MatrixCoords position, MatrixCoords speed, Random randomGenerator, uint maxAbsSpeedCoord, MatrixCoords minMaxTickPerLay)
            : base(position, speed, randomGenerator, maxAbsSpeedCoord)
        {
            this.MinMaxTickPerLay = minMaxTickPerLay;
            SetRandomLayingTimeAndTimeToLay();
        }

        public MatrixCoords MinMaxTickPerLay { get; private set; }

        public override char[,] GetImage()
        {
            return new char[,] { { '^' } };
        }

        public override IEnumerable<Particle> Update()
        {
            if (this.timeToLay > 0)
            {
                this.timeToLay--;
                return base.Update();
            }

            List<Particle> produced = new List<Particle>();

            if (this.layingTime > 0)
            {
                this.layingTime--;
                return produced;
            }

            SetRandomLayingTimeAndTimeToLay();

            Particle p = new ChickenParticle(this.Position, this.Speed, this.RandomGenerator, (uint)this.MaxSpeedCoord, ((ChickenParticle)this).MinMaxTickPerLay);
            produced.Add(p);
            var baseProduced = base.Update();
            produced.AddRange(baseProduced);
            return produced;
        }

        private void SetRandomLayingTimeAndTimeToLay()
        {
            this.timeToLay = this.RandomGenerator.Next(this.MinMaxTickPerLay.Row, this.MinMaxTickPerLay.Col + 1);
            this.layingTime = this.RandomGenerator.Next(this.MinMaxTickPerLay.Row, this.MinMaxTickPerLay.Col + 1);
        }
    }
}