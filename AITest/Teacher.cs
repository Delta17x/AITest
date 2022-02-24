using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITest
{
    public class Teacher
    {
        private int perGen = 1;
        private int maxGens = 1;
        private int[] counts;
        private double[][] samples;
        private double[] correctVals;

        public int PerGen => perGen;
        public int MaxGens => maxGens;

        public Teacher(int[] Counts, double[][] Samples, double[] CorrectVals, int StudentsPerGen, int MaxGens)
        {
            counts = Counts;
            samples = Samples;
            correctVals = CorrectVals;
            perGen = StudentsPerGen;
            maxGens = MaxGens;
        }

        public Network Teach()
        {
            return teach(0, new Network(counts));
        }

        private double averageScore(Network network)
        {
            double score = 0;
            for (int i = 0; i < samples.Count(); i++)
            {
                double[] temp = network.Compute(samples[i]);
                
            }
            return score / samples.Count();
        }
           // return net.Compute(samples[sample]).Max();

        private Network teach(int ind, Network best)
        {
            Random random = new Random();
            double[][] bestWeights = best.Weights;
            if (ind != maxGens)
            {
                Network[] networks = new Network[perGen];
                Network newBest = best;

                for (int i = 0; i < networks.Length; i++)
                {
                    double[][] weights = bestWeights;

                    for (int j = 0; j < bestWeights.Count(); j++)
                    {
                        for (int k = 0; k < bestWeights[j].Length; k++)
                        {
                            weights[j][k] += 2 * random.NextDouble() - 1; 
                        }
                    }
                    networks[i] = new Network(counts, weights);

                }

                return teach(ind++, newBest);
            }
            return best;
        }
    }
}
