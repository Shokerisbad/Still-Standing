using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveMenuScript : MonoBehaviour
{ 
    public List<EntityPropertiesScript> entitiesToSave = new List<EntityPropertiesScript>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    

    public void CreateNewSave(int id)
    {

    }


    public void SaveAllEntities() {
        foreach (EntityPropertiesScript entity in FindObjectsOfType<EntityPropertiesScript>()) {
            entity.SaveEntityData();
        }
        Debug.Log("Game saved for all entities.");
    }
    
    public void LoadAllEntities() {
        foreach (EntityPropertiesScript entity in FindObjectsOfType<EntityPropertiesScript>()) {
            entity.LoadEntityData();
        }
        Debug.Log("Game loaded for all entities.");
    }
    
}
