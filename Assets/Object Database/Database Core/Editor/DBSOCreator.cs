using UnityEditor;
using UnityEngine;


namespace Database.Core
{
    public class DBSOCreator : EditorWindow
    {
        private string DatabaseEntity = "DefaultEntity";
        private string DatabaseName   = "DefaultEntityDatabase";
        private int ID = 0;

        [MenuItem("Tools/DB/Create Database")]
        public static void ShowWindow()
        {
            GetWindow<DBSOCreator>("Create Database").PopulateNextAvailableValue();
        }

        void OnGUI()
        {
            GUILayout.Label("Database Settings", EditorStyles.boldLabel);
            DatabaseEntity = EditorGUILayout.TextField("What Entity will be in this Database?", DatabaseEntity);
            ID = EditorGUILayout.IntField("Value", ID);

            if (GUILayout.Button("Create Config"))
            {
                CreateConfig();
                GetWindow<DBSOCreator>("Create Database").PopulateNextAvailableValue();
            }
        }

        void CreateConfig()
        {
            // Create new DatabaseID
            DatabaseID newDatabaseID = CreateInstance<DatabaseID>();
            newDatabaseID.DatabaseName = $"{DatabaseEntity}Database";
            newDatabaseID.ID = ID;

            AssetDatabase.CreateAsset(newDatabaseID, $"Assets/Database Core/Data/DB Types/{DatabaseName}.asset");
            AssetDatabase.SaveAssets();

            // Create Database

            // Create Database Entity
           


            EditorUtility.FocusProjectWindow();
            Selection.activeObject = newDatabaseID;
        }

        void PopulateNextAvailableValue()
        {
            // Find all Config assets and determine the next available DatabaseID
            string[] guids = AssetDatabase.FindAssets("t:DatabaseID");
            int maxValue = 0;
            foreach (string guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                DatabaseID existingConfig = AssetDatabase.LoadAssetAtPath<DatabaseID>(path);
                if (existingConfig.ID > maxValue)
                {
                    maxValue = existingConfig.ID;
                }
            }
            ID = maxValue + 1;  // Set to the next available value
            DatabaseName = "<Default>Database";
        }
    

        //@todo Create Database and Entity from Templates
        void CreateDatabase() {
            // #SCRIPTNAME#
            string scriptName = $"{DatabaseEntity}Database3";
            // #DBEntity#
            string dbEntity = DatabaseEntity;
        }

        void CreateDatabaseEntity() {
            // #SCRIPTNAME#
            string scriptName = DatabaseEntity;

        }
    
    
    }
}