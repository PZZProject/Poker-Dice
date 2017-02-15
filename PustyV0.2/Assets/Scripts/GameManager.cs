using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class GameManager : MonoBehaviour {
    #region Variables
    private bool IsActive = false;
    private bool diceMoved = false; 
    private Transform previous=null;
    private List<Transform> transList= new List<Transform>();
    private List<GameObject> inactiveDie= new List<GameObject>();
    public List<Vector3> rerollPosition;
    public List<Quaternion> rerollRotaion;
    public List<GameObject> die;
    public List<Text> dieValues;
    public GameObject shootButton;
    public GameObject rerollButton;
    public GameObject timeManager;
    public GameObject rerollText;
    public Text text;
    public int wynik { get; set; }
    public int currentValue { get; set; }
    public int licznik { get; set; }
    public int temporary { get; set; } 
    #endregion
    void Start()
    { 
        wynik = 0;
        licznik = 0;
        rerollButton.gameObject.SetActive(false);
        rerollText.gameObject.SetActive(false);
        timeManager.gameObject.SetActive(false);
        shootButton.name = "Fire";
    }

    void Update()
    {
        wynik = 0;
        OnMouseClick();
        CheckTime();
        PrintScore();
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
        diceMoved = true;
    }

    private void PrintScore()
    {
        foreach (var item in die)
        {
            wynik += item.GetComponent<DisplayCurrentDieValue>().currentValue;
        }
        text.text = "Score:\n" + wynik;
        foreach (var item in dieValues)
        {
            item.text = "Die " + (dieValues.IndexOf(item) + 1) + " = " + die[dieValues.IndexOf(item)].GetComponent<DisplayCurrentDieValue>().currentValue;
        }
    }

    public void TimerActivate()
    {
        timeManager.gameObject.SetActive(true);
    }
    
    private void CheckTime()
    {
        if (timeManager.activeSelf)
        {
            IsActive = true;
        }
        if (IsActive == true && timeManager.activeSelf == false)
        {
            MoveDice();
            IsActive = false;
        }
    }

    private void OnMouseClick()
    {
        if (diceMoved)
        {
            rerollText.gameObject.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = gameObject.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    #region Switch
                    Transform selected = hit.transform;
                    switch (hit.transform.gameObject.tag)
                    {
                        case "Die":
                            if (transList.Contains(selected))
                            {
                                selected.gameObject.SetActive(false);
                                transList.Remove(selected);
                                print("1 Deselected");
                            }
                            else
                            {
                                transList.Add(selected);
                                print("1 Selected");
                            }
                            break;
                        case "Die 2":
                            if (transList.Contains(selected))
                            {
                                transList.Remove(selected);
                                print("Die2 Deselected");
                            }
                            else
                            {
                                transList.Add(selected);
                                print("Die2 Selected");
                            }
                            break;
                        case "Die 3":
                            if (transList.Contains(selected))
                            {
                                print("Die3 Deselected");
                                transList.Remove(selected);
                            }
                            else
                            {
                                transList.Add(selected);
                                print("Die3 Selected");
                            }
                            break;
                        case "Die 4":
                            if (transList.Contains(selected))
                            {
                                print("Die4 Deselected");
                                transList.Remove(selected);
                            }
                            else
                            {
                                transList.Add(selected);
                                print("Die4 Selected");
                            }
                            break;
                        case "Die 5":
                            if (transList.Contains(selected))
                            {
                                print("Die5 Deselected");
                                transList.Remove(selected);
                            }
                            else
                            {
                                transList.Add(selected);
                                print("Die5 Selected");
                            }
                            break;
                    }
                    if (transList.Count > 0)
                    {
                        rerollButton.gameObject.SetActive(true);
                    }
                    else
                    {
                        rerollButton.gameObject.SetActive(false);
                    } 
                    #endregion                    
                }
            }
        }
    }

    public void Reroll()
    {
        Rigidbody rb;
        for (int i = 0; i < transList.Count; i++)
        {   
            foreach (GameObject element in die)
            {
                if (element.transform == transList[i])
                {
                    rb = element.GetComponent<Rigidbody>();
                    rb.isKinematic = false;
                }
            }
        }
        foreach(GameObject element in die)
        {
            rb = element.GetComponent<Rigidbody>();
            if(rb.isKinematic == true)
            {
                element.gameObject.SetActive(false);
            }
        }
    }
}
