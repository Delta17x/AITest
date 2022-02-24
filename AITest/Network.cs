namespace AITest
{
    public class Network
    {
        private int[] counts;
        private double[][] weights;

        public int Layers { get { return counts.Count(); } }

        public int NodeCount
        {
            get
            {
                return Nodes.Length;
            }
        }

        public int[] Counts
        {
            get { return counts; }
            set { counts = value; }
        }

        public double[][] Weights
        {
            get { return weights; }
            set { weights = value; }
        }
        public Node[][] Nodes;

        public Network(int[] _counts, double[][]? _weights = null)
        {
            counts = _counts;
            if (_weights == null)
            {
                _weights = new double[Layers][];
                for (int i = 0; i < _weights.Count(); i++)
                {
                    _weights[i] = new double[counts[i]];
                }
            }
            weights = _weights;
            if (weights.Count() != Layers)
            {
                throw new ArgumentException("Invalid amount of weights.");
            }
            for (int i = 0; i < weights.Count(); i++)
            {
                if (weights[i].Length != counts[i])
                {
                    throw new ArgumentException("Invalid amount of weights.");
                }
            }

            Nodes = new Node[Layers][];
            for (int i = 0; i < Layers; i++)
            {
                Nodes[i] = new Node[counts[i]];
            }
            for (int i = 0; i < Nodes.Count(); i++)
            {
                for (int j = 0; j < Nodes[i].Length; j++)
                {
                    Nodes[i][j] = new Node(weights[i][j]);
                }
            }
            for (int i = 0; i < Layers - 1; i++)
            {
                for (int j = 0; j < Nodes[i].Length; j++)
                {
                    Nodes[i][j].Next = Nodes[i + 1];
                }
            }
        }

        public double[] Compute(double[] inp)
        {
            if (inp.Length != counts[0])
            {
                throw new ArgumentException("Invalid amount of inputs.");
            }

            double[] ret = new double[counts[counts.Length - 1]];
            for (int i = 0; i < Nodes[0].Length; i++)
            {
                Nodes[0][i].Process(inp[i]);
            }
            for (int i = 0; i < ret.Length; i++)
            {
                ret[i] = Nodes[Nodes.Count() - 1][i].Value;
            }
            return ret;       
        }
    }
}
