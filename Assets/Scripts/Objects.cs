using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Object
{
    public int id;
    public string name;
    public bool state;
    public List<int> deck;
}

[System.Serializable]
public class DataBase
{
    public List<Object> dataBase;
}
