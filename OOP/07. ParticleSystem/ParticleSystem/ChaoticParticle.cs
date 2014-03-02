namespace ParticleSystem
{
    using System;
    using System.Collections.Generic;

    public class ChaoticParticle : Particle
    {
        public ChaoticParticle(MatrixCoords position, MatrixCoords speed, Random randomGenerator, uint maxAbsSpeedCoord)
            : base(position, speed)
        {
            this.RandomGenerator = randomGenerator;
            this.MinSpeedCoord = -(int)maxAbsSpeedCoord;
            this.MaxSpeedCoord = (int)maxAbsSpeedCoord;
        }

        public Random RandomGenerator { get; private set; }
        public int MinSpeedCoord { get; private set; }
        public int MaxSpeedCoord { get; private set; }

        public override char[,] GetImage()
        {
            return new char[,] { { (char)1 } };
        }

        protected override void Move()
        {
            base.Move();
            int particleRowSpeed = this.RandomGenerator.Next(this.MinSpeedCoord, this.MaxSpeedCoord + 1);
            int particleColSpeed = this.RandomGenerator.Next(this.MinSpeedCoord, this.MaxSpeedCoord + 1);
            MatrixCoords particleSpeed = new MatrixCoords(particleRowSpeed, particleColSpeed);
            this.Accelerate(new MatrixCoords(-this.Speed.Row, -this.Speed.Col));
            this.Accelerate(particleSpeed);
        }
    }
}