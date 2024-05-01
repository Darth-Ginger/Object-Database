using UnityEngine;
using UnityEditor;

namespace Database.Core
{
    // [CreateAssetMenu(fileName = "DatabaseEntityID", menuName = "DatabaseConfig/DatabaseEntityID")]
    public abstract class DatabaseEntity : ScriptableObject, IDBEntity, ISaveJsonConfig
    {
        public string Name { get; set; }
        public TextAsset Config { get => GetTextAsset(); set => SetTextAsset(value); }
        protected DatabaseEntityID ID { get => GetID(); set => SetID(); }

        public DatabaseEntityID GetID() => ID;
        

        public void SetID()
        {
            // Find all DBEntity assets and determine the next available DatabaseID
            string[] guids = AssetDatabase.FindAssets($"t:DatabaseEntity");
            int maxValue = 0;
            foreach (string guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                DatabaseEntity existingEntity = AssetDatabase.LoadAssetAtPath<DatabaseEntity>(path);
                if (existingEntity.GetID().ID > maxValue)
                {
                    maxValue = existingEntity.GetID().ID;
                }
            }
            ID = new DatabaseEntityID(Name, maxValue + 1);  // Set to the next available value
        }

        #region    json interface

        public void SetTextAsset(TextAsset textAsset)
        {
            Config = textAsset;
        }
        public TextAsset GetTextAsset()
        {
            return Config;
        }
        public Object GetObject()
        {
            return this;
        }

        #endregion json interface

    }

    public struct DatabaseEntityID {
        public string Name { get; private set; }
        public int ID      { get; private set; }

        public DatabaseEntityID(string name, int id) {
            Name = name;
            ID = id;
        }
        public DatabaseEntityID GetID() => this;
    }
}