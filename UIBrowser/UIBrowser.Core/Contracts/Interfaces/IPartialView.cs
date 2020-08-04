namespace UIBrowser.Core
{
    public interface IPartialView
    {
        string Caption { get; }

        string[] LabelLevels { get; }
    }
}
