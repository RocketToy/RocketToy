using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketToy1
{
    public class Threshold
    {
        public bool GreaterThanEnabled = false;
        public float GreaterThanThreshold;
        public bool LessThanEnabled = false;
        public float LessThanThreshold;
        public bool SimulateCollision = false;
    }
    public class EntitySettings
    {
        public Threshold PosXThresh = new Threshold();
        public Threshold PosYThresh = new Threshold();
        public Threshold PosZThresh = new Threshold();
        public Threshold VelXThresh = new Threshold();
        public Threshold VelYThresh = new Threshold();
        public Threshold VelZThresh = new Threshold();
    }
}
