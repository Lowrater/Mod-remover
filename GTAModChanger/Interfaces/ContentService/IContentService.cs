namespace GTAModChanger.Interfaces.ContentService
{
    public interface IContentService
    {
        string modFolder { get; set; }
        string rootFolder { get; set; }

        /// <summary>
        /// Gets folder path of the selected folder from the user
        /// </summary>
        /// <returns></returns>
        string GetFolderPath();

        /// Removes the mod from the RootFolderPath depending on the content from the ModFolderPath
        /// </summary>
        /// <param name="RootFolderPath"></param>
        /// <param name="ModFolderPath"></param>
        void RemoveMods(string RootFolderPath, string ModFolderPath);


        /// <summary>
        /// Adds the mod from the ModFolderPath depending on the content from the RootFolderPath
        /// </summary>
        /// <param name="RootFolderPath"></param>
        /// <param name="ModFolderPath"></param>
        void AddMods(string RootFolderPath, string ModFolderPath);

    }
}