using System.Collections;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {

    public GameObject[] enemies;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool stop;
    public GameObject ScoreText;
    public static double theScore = 1;
    //Use this for initialization

    int randEnemy;
    void Start () {
        StartCoroutine(waitSpawner());
        theScore = 1;

	}
	
	// Update is called once per frame
	void Update () {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
        ScoreText.GetComponent<Text>().text = "SCORE: " + theScore;
        theScore = theScore + 1;
    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds (startWait) ;

       
        while (!stop)
        {
            randEnemy = Random.Range (0, 2);

            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 1, Random.Range(-spawnValues.z, spawnValues.z));

            Instantiate(enemies[randEnemy], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
           
            yield return new WaitForSeconds(spawnWait); 
        }
    }
}
