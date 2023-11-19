using System.Numerics;

namespace Iso8815;

public class Rotation
{
    public static Quaternion CreateRotationQuaternion(double rollInRadians, double pitchInRadians, double yawInRadians)
    {
        return Quaternion.CreateFromYawPitchRoll((float)yawInRadians, (float)pitchInRadians, (float)rollInRadians);
    }

    public static Matrix4x4 CreateRotationMatrix(double rollInRadians, double pitchInRadians, double yawInRadians)
    {
        var rotationQuaternion = CreateRotationQuaternion(rollInRadians, pitchInRadians, yawInRadians);
        return Matrix4x4.CreateFromQuaternion(rotationQuaternion);
    }

    public static Vector3 Rotate(Vector3 inputXyz, Vector3 rpyInRadians)
    {
        // Important! this is YZX (not XYZ)
        var inputYzx = new Vector3(inputXyz.Y, inputXyz.Z, inputXyz.X);

        // First, create the rotation matrix based on the rpy values.
        var rotationQuaternion = CreateRotationQuaternion(rpyInRadians.X, rpyInRadians.Y, rpyInRadians.Z);
        var result = Vector3.Transform(inputYzx, rotationQuaternion);

        // Important! this is ZXY (not XYZ)
        return new Vector3(result.Z, result.X, result.Y);
    }


}
