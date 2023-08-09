using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;
using TMPro;
using System;

public class DataBaseHandler : MonoBehaviour
{
    public DataBase db;
    int actualObjectId = 0;
    int actualCardId = 0;

    [SerializeField] TextMeshProUGUI name;
    [SerializeField] TextMeshProUGUI cardNumber;
    void Start()
    {
        StartCoroutine(GetText());
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

    [ContextMenu("leer simple")]
    public void starcorrutinenet()
    {
        StartCoroutine(GetText());
    }

    IEnumerator GetText()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://my-json-server.typicode.com/patopaco078/http_SID/db");
        yield return www.SendWebRequest();
        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);

            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;

            //string textwww = File.ReadAllText(www.downloadHandler.text);
            //Debug.Log(textwww);
            db = JsonUtility.FromJson<DataBase>(www.downloadHandler.text);
        }
        
    }
}
