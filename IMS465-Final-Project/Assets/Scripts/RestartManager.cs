using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartManager : MonoBehaviour
{

    [SerializeField] private Player playerPrefab;
    [SerializeField] private EnemySpawner enemySpawner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            //Destroy game objects
            Destroy(GameObject.Find("Player"));
            while (GameObject.FindWithTag("Enemy") != null) {
                Destroy(GameObject.FindWithTag("Enemy"));
            }
            Destroy(GameObject.Find("EnemySpawner"));
            //Respawn game objects
            Instantiate(playerPrefab, new Vector3(1.03f, 1.04f, -4.84f), Quaternion.identity);
            Instantiate(enemySpawner);
        }
    }
}
