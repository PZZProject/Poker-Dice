using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using Mono.Data.Sqlite;
using System.Data;


public class GameManager : MonoBehaviour {
    public List<GameObject> die;
    public List<Text> dieValues;
    public GameObject btn;
    public Text text;
    public int wynik  { get; set; }
    public int currentValue { get; set; }
    public int licznik { get; set; }
    public int temporary { get; set; }
    void Start()    
    {
        wynik = 0;
        licznik = 0;
    }

    void Update()
    {
        foreach (var item in die)
        {
            wynik += item.GetComponent<DisplayCurrentDieValue>().currentValue;
        }
        text.text = "Score:\n" + wynik;
        print(wynik);
        /*if (wynik == temporary)
        {
            licznik++;
        }
        temporary = wynik;
        ///--------------------------------------
        if (licznik == 150)
        {
            string conn = "URI=file:" + Application.dataPath + "/BazaTemp.s3db"; //Path to database.
            IDbConnection dbconn;
            dbconn = (IDbConnection)new SqliteConnection(conn);
            dbconn.Open(); //Open connection to the database.
            IDbCommand dbcmd = dbconn.CreateCommand();
            string sql = "INSERT INTO statystyka (Score) VALUES ('" + wynik + "')";
            dbcmd.CommandText = sql;
            dbcmd.ExecuteNonQuery();
            /*IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                int value = reader.GetInt32(0);
                string name = reader.GetString(1);
                int rand = reader.GetInt32(2);

                Debug.Log("value= " + value + "  name =" + name + "  random =" + rand);
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;
        }
        
        ///--------------------------------------
        wynik = 0;
        */
        ///TODO
        /*foreach (var item in dieValues)     
        {
            item.text = "Die " + (dieValues.IndexOf(item) + 1) + " = " + die[dieValues.IndexOf(item)].GetComponent<DisplayCurrentDieValue>().currentValue;
        }*/
        foreach (var item in dieValues)
        {
            item.text = "Die " + (dieValues.IndexOf(item) + 1) + " = " + die[dieValues.IndexOf(item)].GetComponent<DisplayCurrentDieValue>().currentValue;
        }
    }   


}
