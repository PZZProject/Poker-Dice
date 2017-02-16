using UnityEngine;

public class TimeCheck : MonoBehaviour {
    private float time= 8.0f;
    //up
    void Update()
    {
        if (time < 0)
        {
            print("Time elapsed");
            this.gameObject.SetActive(false);
            time = 8.0f;
        }
        time -= Time.deltaTime;
    }
}
