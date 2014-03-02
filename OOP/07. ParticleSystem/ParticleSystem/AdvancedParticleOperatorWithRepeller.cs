namespace ParticleSystem
{
    using System;
    using System.Collections.Generic;

    public class AdvancedParticleOperatorWithRepeller : AdvancedParticleOperator
    {
        List<ParticleAttractor> attractors = new List<ParticleAttractor>();
        List<Particle> particles = new List<Particle>();

        public override IEnumerable<Particle> OperateOn(Particle p)
        {
            var attractorCandidate = p as ParticleAttractor;
            if (attractorCandidate == null)
            {
                this.particles.Add(p);
            }
            else
            {
                this.attractors.Add(attractorCandidate);
            }

            return base.OperateOn(p);
        }

        public override void TickEnded()
        {
            foreach (var attractor in this.attractors)
            {
                foreach (var particle in this.particles)
                {
                    var currAcceleration = GetAccelerationFromParticleToAttractor(attractor, particle);
                    ParticleRepeller pr = attractor as ParticleRepeller;
                    if (pr != null && Distance(pr, particle) <= pr.RepellerRadius)
                    {
                        currAcceleration = new MatrixCoords(-currAcceleration.Row, -currAcceleration.Col);
                    }

                    particle.Accelerate(currAcceleration);
                }
            }

            this.attractors.Clear();
            this.particles.Clear();
        }

        private static MatrixCoords GetAccelerationFromParticleToAttractor(ParticleAttractor attractor, Particle particle)
        {
            var currParticleToAttractorVector = attractor.Position - particle.Position;

            int pToAttrRow = currParticleToAttractorVector.Row;
            pToAttrRow = DecreaseVectorCoordToPower(attractor, pToAttrRow);

            int pToAttrCol = currParticleToAttractorVector.Col;
            pToAttrCol = DecreaseVectorCoordToPower(attractor, pToAttrCol);

            var currAcceleration = new MatrixCoords(pToAttrRow, pToAttrCol);
            return currAcceleration;
        }

        private static int DecreaseVectorCoordToPower(ParticleAttractor attractor, int pToAttrCoord)
        {
            if (Math.Abs(pToAttrCoord) > attractor.Power)
            {
                pToAttrCoord = (pToAttrCoord / (int)Math.Abs(pToAttrCoord)) * attractor.Power;
            }
            return pToAttrCoord;
        }

        private static int Distance(Particle p1, Particle p2)
        {
            return (int)Math.Sqrt((p1.Position.Row - p2.Position.Row) * (p1.Position.Row - p2.Position.Row) + (p1.Position.Col - p2.Position.Col) * (p1.Position.Col - p2.Position.Col));
        }
    }
}