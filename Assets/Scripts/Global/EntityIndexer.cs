public static class EntityIndexSystem
{
    private static int globalEntityCount = 0;

    public static int GetNextEntityID()
    {
        return ++globalEntityCount;
    }
}
