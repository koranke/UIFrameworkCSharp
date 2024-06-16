namespace UIFrameworkCSharp.core.utilities;

public static class RandomData
{
    public static Bogus.Faker en = new Bogus.Faker("en");
    public static Bogus.Faker jp = new Bogus.Faker("ja");

    public static string GetRandomString(int length)
    {
        return en.Random.AlphaNumeric(length);
    }

    public static int GetRandomInt(int max)
    {
        return en.Random.Number(0, max);
    }

    public static string GetRandomPassword(int length)
    {
        return en.Internet.Password(length, false, "[0-9]+|[A-Z]+|[a-z]+|[!@#$%^&*<>{}]+");
    }

    public static T GetRandomItemFromList<T>(T[] items)
    {
        return GetRandomItemFromList(new List<T>(items));
    }

    public static T GetRandomItemFromList<T>(List<T> items)
    {
        if (items == null)
        {
            throw new ArgumentNullException("Failed to get random item. List is null.");
        }

        return items[RandomData.GetRandomInt(items.Count)];
    }
}
