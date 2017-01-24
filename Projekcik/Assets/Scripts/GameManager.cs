using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class GameManager : MonoBehaviour {
    public List<GameObject> die;
    public List<Text> dieValues;
    public GameObject btn;
    public Text text;
    public int wynik  { get; set; }
    public int currentValue { get; set; }
    void Start()
    {
        wynik = 0;
    }

    void Update()
    {
        foreach (var item in die)
        {
            wynik += item.GetComponent<DisplayCurrentDieValue>().currentValue;
        }
        text.text = "Score:\n" + wynik;
        print(wynik);
        wynik = 0;

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
