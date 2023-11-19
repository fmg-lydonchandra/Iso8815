using System.Numerics;

namespace Iso8815;

public static class Extension
{
    public static float[] ToMatrix3X3Array(this Matrix4x4 matrix)
    {
        return new[]
        {
            matrix.M11, matrix.M12, matrix.M13,
            matrix.M21, matrix.M22, matrix.M23,
            matrix.M31, matrix.M32, matrix.M33,
        };
    }
}

public static class DoubleArrayExtension
{
    public static Vector3 ToVector3(this double[] array)
    {
        return new((float)array[0], (float)array[1], (float)array[2]);
    }

    public static Vector3 ToVector3(this float[] array)
    {
        return new(array[0], array[1], array[2]);
    }
}

public static class Vector3ArrayExtension
{
    public static double[] ToDoubleArray(this Vector3 array)
    {
        return new[] { (double)array.X, array.Y, array.Z };
    }

    public static float[] ToArray(this Vector3 array)
    {
        return new[] { array.X, array.Y, array.Z };
    }
}
