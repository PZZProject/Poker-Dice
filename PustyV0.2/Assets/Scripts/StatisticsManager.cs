using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class StatisticsManager : MonoBehaviour {

    public Text wyniki;
    public Text label;
    public Text nicki;

    // Use this for initialization
    void Start () {

        string conn = "URI=file:" + Application.dataPath + "/BazaTemp.s3db"; 
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sql = "SELECT * FROM Players ORDER BY score DESC LIMIT 8";
        dbcmd.CommandText = sql;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            string player_name = reader.GetString(0);
            int score = reader.GetInt32(1);

            nicki.text += player_name + "\n";
            wyniki.text += score + "\n";
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
