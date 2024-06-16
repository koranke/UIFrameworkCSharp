using NLog;
using UIFrameworkCSharp.core;

namespace UIFrameworkCSharp.tests.magentoTests;

[TestClass]
public abstract class TestBase
{
    protected static Logger logger;
    public TestContext TestContext { get; set; }

    public TestBase()
    {
        logger = LogManager.GetLogger(GetType().Name);
    }

    [TestInitialize]
    public void Setup()
    {
        logger.Info($"\nTest Started: {TestContext.TestName}");
    }

    [TestCleanup]
    public void Cleanup()
    {
        switch(TestContext.CurrentTestOutcome)
        {
            case UnitTestOutcome.Passed:
                logger.Info($"Test Passed: {TestContext.TestName}");
                break;
            case UnitTestOutcome.Failed:
                logger.Error($"Test Failed: {TestContext.TestName}");
                SeleniumUtilities.TakeScreenshot(TestContext);
                break;
            default:
                logger.Warn($"Test Inconclusive: {TestContext.TestName}");
                break;
        }
        SeleniumManager.CloseCurrentDriver();
    }

}
