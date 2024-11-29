static class ScribbleStringExtension
{
    // we add `this` key word to make it an extension function
    public static int wordCount(this string s)
    {
        string[] splitted = s.Split(' ');
        return splitted.Length;
    }
}
