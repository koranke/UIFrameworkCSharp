using System.Diagnostics;

namespace UIFrameworkCSharp.core;

public class ProjectUtilities
{
    public static string GetTestName()
    {
        StackTrace stackTrace = new StackTrace();
        for (int i = 0; i < stackTrace.FrameCount; i++)
        {
            if (stackTrace.GetFrame(i).GetMethod().GetCustomAttributes(typeof(TestMethodAttribute), false).Length > 0)
            {
                string methodName = stackTrace.GetFrame(i).GetMethod().Name;
                string className = stackTrace.GetFrame(i).GetMethod().DeclaringType.Name;
                return $"{className}.{methodName}";
            }
        }
        return "Unknown";
    }

    public static string GetProjectDirectory()
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string projectDirectory = currentDirectory.Substring(0, currentDirectory.IndexOf("bin"));
        return projectDirectory;
    }

    public static string GetScreenshotDirectory()
    {
        return GetProjectRelatedDirectory("screenshots");
    }

    public static string GetLogDirectory()
    {
        return GetProjectRelatedDirectory("logs");
    }

    public static string GetProjectRelatedDirectory(string targetChildDirectory)
    {
        string projectDirectory = GetProjectDirectory();
        string childDirectory = projectDirectory + targetChildDirectory;

        if (!Directory.Exists(childDirectory))
        {
            Directory.CreateDirectory(childDirectory);
        }
        return childDirectory;
    }

}
