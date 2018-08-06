using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketToy1
{
    public class Entity
    {
        private static readonly int positionOffset = -132;
        private static readonly int velocityOffset = 140;
        private int index;
        private byte[] signature;
        private int signatureLocation = 0;
        private bool nonExistent = false;
        private MemoryEditor memEditor;

        public EntitySettings Settings = new EntitySettings();
        public string CustomType = "";
        public byte[] FullSignature
        {
            get
            {
                track();
                if (nonExistent)
                {
                    return null;
                }
                return memEditor.ReadMemory(signatureLocation, 16);
            }
        }
        public float PositionX
        {
            get
            {
                track();
                if (nonExistent)
                {
                    return float.NaN;
                }
                byte[] posX = memEditor.ReadMemory(signatureLocation + positionOffset, 4);
                return BitConverter.ToSingle(posX, 0);
            }
            set
            {
                track();
                if (nonExistent)
                {
                    return;
                }
                byte[] posX = BitConverter.GetBytes(value);
                memEditor.WriteMemory(signatureLocation + positionOffset, posX);
            }
        }
        public float PositionZ
        {
            get
            {
                track();
                if (nonExistent)
                {
                    return float.NaN;
                }
                byte[] posZ = memEditor.ReadMemory(signatureLocation + positionOffset + 4, 4);
                return BitConverter.ToSingle(posZ, 0);
            }
            set
            {
                track();
                if (nonExistent)
                {
                    return;
                }
                byte[] posZ = BitConverter.GetBytes(value);
                memEditor.WriteMemory(signatureLocation + positionOffset + 4, posZ);
            }
        }
        public float PositionY
        {
            get
            {
                track();
                if (nonExistent)
                {
                    return float.NaN;
                }
                byte[] posY = memEditor.ReadMemory(signatureLocation + positionOffset + 8, 4);
                return BitConverter.ToSingle(posY, 0);
            }
            set
            {
                track();
                if (nonExistent)
                {
                    return;
                }
                byte[] posY = BitConverter.GetBytes(value);
                memEditor.WriteMemory(signatureLocation + positionOffset + 8, posY);
            }
        }
        public float VelocityX
        {
            get
            {
                track();
                if (nonExistent)
                {
                    return float.NaN;
                }
                byte[] velX = memEditor.ReadMemory(signatureLocation + velocityOffset, 4);
                return BitConverter.ToSingle(velX, 0);
            }
            set
            {
                track();
                if (nonExistent)
                {
                    return;
                }
                byte[] velX = BitConverter.GetBytes(value);
                memEditor.WriteMemory(signatureLocation + velocityOffset, velX);
            }
        }
        public float VelocityZ
        {
            get
            {
                track();
                if (nonExistent)
                {
                    return float.NaN;
                }
                byte[] velZ = memEditor.ReadMemory(signatureLocation + velocityOffset + 4, 4);
                return BitConverter.ToSingle(velZ, 0);
            }
            set
            {
                track();
                if (nonExistent)
                {
                    return;
                }
                byte[] velZ = BitConverter.GetBytes(value);
                memEditor.WriteMemory(signatureLocation + velocityOffset + 4, velZ);
            }
        }
        public float VelocityY
        {
            get
            {
                track();
                if (nonExistent)
                {
                    return float.NaN;
                }
                byte[] velY = memEditor.ReadMemory(signatureLocation + velocityOffset + 8, 4);
                return BitConverter.ToSingle(velY, 0);
            }
            set
            {
                track();
                if (nonExistent)
                {
                    return;
                }
                byte[] velY = BitConverter.GetBytes(value);
                memEditor.WriteMemory(signatureLocation + velocityOffset + 8, velY);
            }
        }

        public Entity(byte[] Signature, Process RL, int Index = 0)
        {
            signature = Signature;
            memEditor = new MemoryEditor(RL);
            index = Index;
            track();
        }
        public Entity(byte[] Signature, int KnownAddress, Process RL)
        {
            signature = Signature;
            signatureLocation = KnownAddress;
            memEditor = new MemoryEditor(RL);
            index = 0;
            track();
        }
        public void PrintCoordinates()
        {
            Console.WriteLine("X: " + PositionX + " Y: " + PositionY + " Z: " + PositionZ);
        }
        private void track()
        {
            if (!memEditor.ReadMemory(signatureLocation, signature.Length).SequenceEqual(signature))
            {
                nonExistent = true;
            }
        }
    }
}
