using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    public class ParticleRepeller : ParticleAttractor
    {
        public ParticleRepeller(MatrixCoords position, MatrixCoords speed, int repellerPower, int repellerRadius) :
            base(position, speed, repellerPower)
        {
            this.RepellerRadius = repellerRadius;
        }

        public int RepellerRadius { get; private set; }

        public override char[,] GetImage()
        {
            return new char[,] { { '+' } };
        }
    }
}
