using EulerProject.Problems;
using EulerProject.Utils.MathUtils;

Console.WriteLine(string.Join(", ", SequenceGeneration.Pandigitals(-1, 1, -2, 3, -6)));
Console.WriteLine(string.Join(", ", TrigonometryUtils.BerggrensTripletLevel(3)));
Console.WriteLine(P047.AsString());
Console.WriteLine(string.Join(", ", P047.RawSequence()));
Console.WriteLine(P058.AsString());
Console.WriteLine(P045.Solution());
Console.WriteLine(P045.GenerateTuple().ToString());