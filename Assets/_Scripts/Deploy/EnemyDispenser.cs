using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDispenser : MonoBehaviour
{

    //private int currDay = 0;
    [SerializeField]private int eneNum;
    [SerializeField]private float eneSpawnTime = 0.0f;
    [SerializeField] private GameObject _Enemy;
    private float eneSpawnMinX = 9.1f;
    private float eneSpawnMaxX = 10.0f;
    private float eneSpawnMinY = -3.45f;
    private float eneSpawnMaxY = 1.4f;

    private float levelspawntime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        eneNum = (GameManager.Instance.day+1) * 2;
        GameManager.Instance.eneLeft = eneNum;
        levelspawntime = 10.0f / eneNum;
    }

    // Update is called once per frame
    void Update()
    {
        eneSpawnTime-=Time.deltaTime;
        if (eneSpawnTime <= 0 && eneNum > 0)
        {
            float randomSpawnX = Random.Range(eneSpawnMinX, eneSpawnMaxX);
            float randomSpawnY = Random.Range(eneSpawnMinY, eneSpawnMaxY);
            Vector3 position = new Vector3(randomSpawnX, randomSpawnY);
            Instantiate(_Enemy,position,Quaternion.identity);

            eneNum--;
            eneSpawnTime = levelspawntime;
        }
    }
}
