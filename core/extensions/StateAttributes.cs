using UIFrameworkCSharp.core.attributes;
using UIFrameworkCSharp.core.enums;

namespace UIFrameworkCSharp.core.extensions;

public static class StateAttributes
{
    public static string GetName(this State state)
    {
        var field = state.GetType().GetField(state.ToString());
        var attribute = (StateProperty)field.GetCustomAttributes(typeof(StateProperty), false)[0];
        return attribute.Name;
    }

    public static int GetId(this State state)
    {
        var field = state.GetType().GetField(state.ToString());
        var attribute = (StateProperty)field.GetCustomAttributes(typeof(StateProperty), false)[0];
        return attribute.Id;
    }
}
