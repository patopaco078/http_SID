using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class DataBaseHandler : MonoBehaviour
{
    public DataBase db;
    int actualObjectId = 0;
    int actualCardId = 0;

    [SerializeField] TextMeshProUGUI name;
    [SerializeField] TextMeshProUGUI cardNumber;
    void Start()
    {
        string data = File.ReadAllText(Application.dataPath + "/Json/db.json");
        db =  JsonUtility.FromJson<DataBase>(data);
    }

    public Object SearshObject(int id)
    {
        return db.dataBase.Find(Object => Object.id == id);
    }

    public void NextObject()
    {
        if(actualObjectId < db.dataBase.Count -1)
            actualObjectId++;
        else
            actualObjectId = 0;

        name.text = "name: " + db.dataBase[actualObjectId].name;
        NextCard();
    }
    public void NextCard()
    {
        if (actualCardId < db.dataBase[actualObjectId].deck.Count - 1)
            actualCardId++;
        else
            actualCardId = 0;

        cardNumber.text = db.dataBase[actualObjectId].deck[actualCardId].ToString();
    }
}
