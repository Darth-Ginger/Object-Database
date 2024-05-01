using UnityEngine;

namespace Database.Core
{
    [CreateAssetMenu(fileName = "DatabaseID", menuName = "DatabaseConfig/DatabaseID")]
    public class DatabaseID : ScriptableObject
    {
        public string DatabaseName;
        public int ID;
    }
}