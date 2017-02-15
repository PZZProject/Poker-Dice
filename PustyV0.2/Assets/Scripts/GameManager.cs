using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using Mono.Data.Sqlite;
using System.Data;


public class GameManager : MonoBehaviour {
    private bool IsActive=false;
    public List<Vector3> rerollPosition;
    public List<Quaternion> rerollRotaion;
    public List<GameObject> die;
    public List<Text> dieValues;
    public GameObject shootButton;
    public GameObject rerollButton;
    public GameObject timeManager;
    public Text text;
    public int wynik  { get; set; }
    public int currentValue { get; set; }
    public int licznik { get; set; }
    public int temporary { get; set; }
    void Start()    
    {
        wynik = 0;
        licznik = 0;
        rerollButton.gameObject.SetActive(false);
        shootButton.name = "Fire";
        timeManager.gameObject.SetActive(false);
    }

    void Update()
    {
        wynik = 0;
        foreach (var item in die)
        {
            wynik += item.GetComponent<DisplayCurrentDieValue>().currentValue;
        }
        text.text = "Score:\n" + wynik;
        if(timeManager.activeSelf)
        {
            IsActive = true;
        }
        if(IsActive==true && timeManager.activeSelf == false)
        {
            MoveDice();
            IsActive = false;
        }
        #region CommentedBlock
        //print(wynik);
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
        #endregion

        foreach (var item in dieValues)
        {
            item.text = "Die " + (dieValues.IndexOf(item) + 1) + " = " + die[dieValues.IndexOf(item)].GetComponent<DisplayCurrentDieValue>().currentValue;
        }
    }   

    public void MoveDice()
    {
        Rigidbody rb;
        int value;
        for(int i = 0; i < die.Count; i++)
        {
            die[i].transform.position = new Vector3(rerollPosition[i].x, rerollPosition[i].y, rerollPosition[i].z);
            value = die[i].GetComponent<DisplayCurrentDieValue>().currentValue;
            die[i].transform.rotation = Quaternion.Euler(rerollRotaion[value - 1].x, rerollRotaion[value - 1].y, rerollRotaion[value - 1].z);
            rb = die[i].GetComponent<Rigidbody>();
            rb.isKinematic = true;
        }
    }

    public void TimerActivate()
    {
        timeManager.gameObject.SetActive(true);
    }
}
