using AITest;

Network network = new Network(new int[3] { 3, 3, 3 }, new double[][] { new double[3] { 1, 2, 3 }, new[] {4.0, 5, 6}, new[] {7.0, 8, 9} });
var temp = network.Compute(new double[3] { 1, 2, 3 });
Array.ForEach(temp, x => Console.WriteLine(x));
