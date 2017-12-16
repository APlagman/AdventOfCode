using System;
using System.Collections.Generic;

namespace AdventSolutions
{
    public class Firewall
    {
        class Layer
        {
            public int ScannerPosition { get; private set; } = 0;
            public int Depth { get; }
            public int Range { get; }
            private int directionStep = 1;

            public Layer(int depth, int range)
            {
                Depth = depth;
                Range = range;
            }

            public void Tick()
            {
                ScannerPosition += directionStep;
                if (ScannerPosition == Range - 1 || ScannerPosition == 0)
                    directionStep *= -1;
            }

            public void Reset()
            {
                ScannerPosition = 0;
                directionStep = 1;
            }
        }

        public int FinalLayer { get; private set; } = 0;
        private List<Layer> securityLayers = new List<Layer>();

        public void AddLayer(int depth, int range)
        {
            if (depth > FinalLayer)
                FinalLayer = depth;
            securityLayers.Add(new Layer(depth, range));
        }

        public (int Severity, bool Caught) Pass()
        {
            if (!Caught(0))
                return (0, false);
            bool caught = false;
            Reset();
            int severity = 0;
            int packetLayer = 0;
            while (packetLayer <= FinalLayer)
            {
                Layer securityLayer = securityLayers.Find(layer => layer.Depth == packetLayer);
                if (securityLayer?.ScannerPosition == 0)
                {
                    caught = true;
                    severity += securityLayer.Depth * securityLayer.Range;
                }
                Tick();
                ++packetLayer;
            }
            return (severity, caught);
        }

        public int MinimumDelay()
        {
            int delay = 0;
            while (Caught(delay))
                ++delay;
            return delay;
        }

        private bool Caught(int delay)
        {
            foreach (Layer securityLayer in securityLayers)
            {
                if ((delay + securityLayer.Depth) % ((securityLayer.Range - 1) * 2) == 0)
                    return true;
            }
            return false;
        }

        private void Tick()
        {
            securityLayers.ForEach(layer => layer.Tick());
        }

        private void Reset()
        {
            securityLayers.ForEach(layer => layer.Reset());
        }
    }
}
