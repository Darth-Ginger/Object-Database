
using UnityEngine;

namespace Database.Core
{
    /// <summary>
    /// Interface definition for database entities 
    /// </summary>
    interface IDBEntity
    {
        [SerializeField]
        string Name          { get; set; }

        [SerializeField]
        TextAsset Config     { get; set; }
        
        
        public void SetID();
        public DatabaseEntityID GetID();



    }
}
