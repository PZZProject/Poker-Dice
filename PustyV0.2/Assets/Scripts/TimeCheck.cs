using UnityEngine;

public class TimeCheck : MonoBehaviour {
    private float time= 8.0f;

    void Update()
    {
        if (time < 0)
        {
            print("Time elapsed");
            this.gameObject.SetActive(false);
        }
        time -= Time.deltaTime;
    }
}
