using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDispenser : MonoBehaviour
{

    private int currDay = GameManager.Instance.day;
    [SerializeField]private int eneNum;
    [SerializeField]private float eneSpawnTime = 0.0f;
    [SerializeField] private GameObject _Enemy;
    private float eneSpawnMinX = 10.0f;
    private float eneSpawnMaxX = 15.0f;
    private float eneSpawnMinY = -3.35f;
    private float eneSpawnMaxY = 1.4f;

    // Start is called before the first frame update
    void Start()
    {
        eneNum = currDay * 2;
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
            eneSpawnTime = Random.Range(1.0f,5.0f);
        }
    }
}
