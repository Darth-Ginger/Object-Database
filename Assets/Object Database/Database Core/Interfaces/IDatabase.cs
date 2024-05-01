

namespace Database.Core
{

    /// <summary>
    /// reserve 0 = 100 for me. Use anything past 100
    /// </summary>
    // public enum DatabaseID
    // {    
    //     GameDatabase = 100
    // }
    public interface IDatabase
    {
        void SetSearchFolders(string[] newfolders);
        string[] GetSearchFolders();
        string[] GetAllNames();
        ISaveJsonConfig[] GetJsons();
        UnityEngine.Object GetDatabaseObjectBySlotIndex(int slotIndex);
        int GetWindowRowSize();
        DatabaseID GetDatabaseType();

        UnityEngine.Object GetMyObject();

    }

}