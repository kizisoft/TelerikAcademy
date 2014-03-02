using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    public class ParticleRepeller : ParticleAttractor
    {
        public ParticleRepeller(MatrixCoords position, MatrixCoords speed, int repellerPower) :
            base(position, speed, repellerPower)
        {
        }

        public override char[,] GetImage()
        {
            return new char[,] { { '+' } };
        }
    }
}
