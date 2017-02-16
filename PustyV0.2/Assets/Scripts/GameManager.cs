using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

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
    public List<Button> formButtons;
    public List<Text> formScores;
    public int[] numberOfDiscardedMesh;
    public int[] playerOneValues;
    public int[] playerTwoValues;
    public GameObject shootButton;
    public GameObject rerollButton;
    public GameObject timeManager;
    public GameObject rerollText;
    public Text text;
    public int wynik { get; set; }
    public int currentValue { get; set; }
    public int licznik { get; set; }
    public int temporary { get; set; }
    public int sum1;
    public int sum2;

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

    void FixedUpdate()
    {
        #region test
        /*temporary = 0;
        foreach (var item in die)
        {
            temporary += item.GetComponent<DisplayCurrentDieValue>().currentValue;
        }
        foreach (var item in formButtons)
        {
            item.GetComponentInChildren<Text>().text = temporary.ToString();
        }*/
        #endregion
        UpdatingArray();
        CheckingFigures();
        wynik = 0;
        UpdatingSums();
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

    public void UpdatingArray()
    {
        for (int i = 0; i < numberOfDiscardedMesh.Length; i++)
        {
            numberOfDiscardedMesh[i] = 0;
        }

        foreach (var item in die)
        {
            switch (item.GetComponent<DisplayCurrentDieValue>().currentValue)
            {
                case 1:
                    numberOfDiscardedMesh[0]++;
                    break;
                case 2:
                    numberOfDiscardedMesh[1]++;
                    break;
                case 3:
                    numberOfDiscardedMesh[2]++;
                    break;
                case 4:
                    numberOfDiscardedMesh[3]++;
                    break;
                case 5:
                    numberOfDiscardedMesh[4]++;
                    break;
                case 6:
                    numberOfDiscardedMesh[5]++;
                    break;
                default:
                    break;
            }
        }
    }

    public void CheckingFigures()
    {
        // One Button
        formButtons[0].GetComponentInChildren<Text>().text = numberOfDiscardedMesh[0].ToString();
        playerOneValues[0] = numberOfDiscardedMesh[0];
        //Two Button
        formButtons[1].GetComponentInChildren<Text>().text = (numberOfDiscardedMesh[1] * 2).ToString();
        playerOneValues[1] = numberOfDiscardedMesh[1] * 2;
        //Three Button
        formButtons[2].GetComponentInChildren<Text>().text = (numberOfDiscardedMesh[2] * 3).ToString();
        playerOneValues[2] = numberOfDiscardedMesh[2] * 3;
        //Four Button
        formButtons[3].GetComponentInChildren<Text>().text = (numberOfDiscardedMesh[3] * 4).ToString();
        playerOneValues[3] = numberOfDiscardedMesh[3] * 4;
        //Five Button
        formButtons[4].GetComponentInChildren<Text>().text = (numberOfDiscardedMesh[4] * 5).ToString();
        playerOneValues[4] = numberOfDiscardedMesh[4] * 5;
        //Six Button
        formButtons[5].GetComponentInChildren<Text>().text = (numberOfDiscardedMesh[5] * 6).ToString();
        playerOneValues[5] = numberOfDiscardedMesh[5] * 6;
        //Triple Button
        for (int i = 0; i < numberOfDiscardedMesh.Length; i++)
        {
            if (numberOfDiscardedMesh[i] > 2)
            {
                formButtons[6].GetComponentInChildren<Text>().text = (3 * (i + 1)).ToString();
                break;
            }
            else
            {
                formButtons[6].GetComponentInChildren<Text>().text = 0.ToString();
            }
        }
        //Quad Button
        for (int i = 0; i < numberOfDiscardedMesh.Length; i++)
        {
            if (numberOfDiscardedMesh[i] > 3)
            {
                formButtons[7].GetComponentInChildren<Text>().text = (4 * (i + 1)).ToString();
                break;
            }
            else
            {
                formButtons[7].GetComponentInChildren<Text>().text = 0.ToString();
            }
        }
        //FullHouse Button
        int fullthree = 0;
        int fulltwo = 0;
        for (int i = 0; i < numberOfDiscardedMesh.Length; i++)
        {
            if (numberOfDiscardedMesh[i] == 3)
            {
                fullthree = 3 * (i + 1);
            }
            if (numberOfDiscardedMesh[i] == 2)
            {
                fulltwo = 2 * (i + 1);
            }
        }
        if (fullthree > 0 && fulltwo > 0)
        {
            formButtons[8].GetComponentInChildren<Text>().text = (fullthree + fulltwo + 5).ToString();
            playerOneValues[8] = fullthree + fulltwo + 5;
        }
        else
        {
            formButtons[8].GetComponentInChildren<Text>().text = 0.ToString();
            playerOneValues[8] = fullthree + fulltwo + 5;
        }
        //Small street
        bool existSmallStreet = true;
        for (int i = 0; i < numberOfDiscardedMesh.Length - 1; i++)
        {
            if (numberOfDiscardedMesh[i] != 1)
            {
                existSmallStreet = false;
            }

        }
        if (existSmallStreet)
        {
            formButtons[9].GetComponentInChildren<Text>().text = 25.ToString();
            playerOneValues[9] = 25;
        }
        else
        {
            formButtons[9].GetComponentInChildren<Text>().text = 0.ToString();
            playerOneValues[9] = 0;
        }
        //Full street
        bool existFullStreet = true;
        for (int i = 1; i < numberOfDiscardedMesh.Length; i++)
        {
            if (numberOfDiscardedMesh[i] != 1)
            {
                existFullStreet = false;
            }

        }
        if (existFullStreet)
        {
            formButtons[10].GetComponentInChildren<Text>().text = 30.ToString();
            playerOneValues[10] = 30;
        }
        else
        {
            formButtons[10].GetComponentInChildren<Text>().text = 0.ToString();
            playerOneValues[10] = 0;
        }
        //General
        for (int i = 0; i < numberOfDiscardedMesh.Length; i++)
        {
            if (numberOfDiscardedMesh[i] > 4)
            {
                formButtons[11].GetComponentInChildren<Text>().text = (5 * (i + 1) + 15).ToString();
                playerOneValues[11] = 5 * (i + 1) + 15;
                break;
            }
            else
            {
                formButtons[11].GetComponentInChildren<Text>().text = 0.ToString();
                playerOneValues[11] = 0;
            }
        }
        //Chance
        int chance = 0;
        for (int i = 0; i < numberOfDiscardedMesh.Length; i++)
        {
            chance += numberOfDiscardedMesh[i] * (i + 1);
        }
        formButtons[12].GetComponentInChildren<Text>().text = chance.ToString();
        playerOneValues[12] = chance;
    }

    public void UpdatingSums()
    {
        sum1 = sum2 = 0;
        for (int i = 0; i < 13; i++)
        {
            sum1 += Int32.Parse(formButtons[i].GetComponentInChildren<Text>().text);
        }
        for (int i = 13; i < 26; i++)
        {
            sum2 += Int32.Parse(formButtons[i].GetComponentInChildren<Text>().text);
        }
        formScores[0].text = sum1.ToString();
        formScores[1].text = sum2.ToString();
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
