using System.Numerics;

namespace EulerProject.Problems;

public interface ISolvable<out T> where T : struct, INumber<T>
{
    static abstract string AsString();

    static abstract T Solution();
}

public interface ISequential<out TEnum, out TRawEnum>
    where TEnum : struct, INumber<TEnum>
    where TRawEnum : struct
{
    static abstract IEnumerable<TEnum> Sequence();

    static abstract IEnumerable<TRawEnum> RawSequence();
}