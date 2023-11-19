using System.Numerics;
using Shouldly;

namespace Iso8815.Tests;

public class UnitTest1
{
    [Fact]
    public void TestOneAxis()
    {
        var rpyInRadians = new[] { (float)Math.PI / 2, 0, 0 };

        var result = Rotation.Rotate(Vector3.UnitX, rpyInRadians.ToVector3());
        result.ToArray().ShouldBe(new float[] { 1, 0, 0 }, 1E-6);

        // PITCH
        // TODO: confirm positive 90deg pitch result in Z == -1
        rpyInRadians = new[] { 0, (float)Math.PI / 2, 0 };
        result = Rotation.Rotate(Vector3.UnitX, rpyInRadians.ToVector3());
        result.ToArray().ShouldBe(new float[] { 0, 0, -1 }, 1E-6);

        // YAW
        rpyInRadians = new[] { 0, 0, (float)Math.PI / 2 };

        result = Rotation.Rotate(Vector3.UnitX, rpyInRadians.ToVector3());
        result.ToArray().ShouldBe(new float[] { 0, 1, 0 }, 1E-6);
    }

    [Fact]
    public void TestMultiAxis()
    {
        var rpyInRadians = new[] { (float)Math.PI / 2, Math.PI / 2, 0 };
        var result = Rotation.Rotate(Vector3.UnitX, rpyInRadians.ToVector3());
        result.ToArray().ShouldBe(new float[] { 0, 0, -1 }, 1E-6);

        // Test with rotation around multiple axes
        rpyInRadians = new[] { Math.PI / 2, Math.PI / 2, Math.PI / 2 };
        result = Rotation.Rotate(Vector3.UnitX, rpyInRadians.ToVector3());

        result.ToArray().ShouldBe(new float[] { 0, 0, -1 }, 1E-6);
    }
}
