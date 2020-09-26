using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGenerator : MonoBehaviour
{
    public GameObject enemyObj;
    private float counter = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (counter > 0) {
            counter -= Time.deltaTime;
        }
        else if (counter <= 0) {
            Vector3 x_enm_a = new Vector3(Random.Range(-19, 19), -11, 0);
            Vector3 x_enm_b = new Vector3(Random.Range(-19, 19), 11, 0);
            Vector3 y_enm_a = new Vector3(19, Random.Range(-11, 11), 0);
            Vector3 y_enm_b = new Vector3(-19, Random.Range(-11, 11), 0);

            GameObject a = Instantiate(enemyObj, x_enm_a, Quaternion.identity);
            GameObject b = Instantiate(enemyObj, x_enm_b, Quaternion.identity);
            GameObject c = Instantiate(enemyObj, y_enm_a, Quaternion.identity);
            GameObject d = Instantiate(enemyObj, y_enm_b, Quaternion.identity);

            List<float> co = new List<float>();
            co.Add(Random.Range(0.3f, 0.9f));
            co.Add(Random.Range(0.3f, 1.5f));
            co.Add(Random.Range(0.6f, 1.3f));
            co.Add(Random.Range(1.2f, 1.9f));
            co.Add(Random.Range(1.2f, 1.9f));
            co.Add(Random.Range(1.2f, 1.9f));

            counter = co[Random.Range(0, 6)];
        }
    }
}
