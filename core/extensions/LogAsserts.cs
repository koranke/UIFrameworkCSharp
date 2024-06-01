using NLog;

namespace UIFrameworkCSharp.core.extensions;

public static class LogAsserts
{
    public static void LogAssert(this Logger logger, bool condition, string message)
    {
        if (!condition)
        {
            logger.Error(message);
            Assert.Fail(message);
        }
    }
}
