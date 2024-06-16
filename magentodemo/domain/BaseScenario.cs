namespace UIFrameworkCSharp.magentodemo.domain;

public class BaseScenario
{
    protected bool needsPopulation = true;

    protected T GetNonNull<T>(T itemDefault, T itemOptional)
    {
        return itemOptional == null ? itemDefault : itemOptional;
    }

    protected T GetNonNull<T>(T itemDefault, Func<T> supplier)
    {
        if (itemDefault != null)
        {
            return itemDefault;
        }
        else
        {
            if (supplier == null)
            {
                return default(T);
            }
            return supplier();
        }
    }
}
