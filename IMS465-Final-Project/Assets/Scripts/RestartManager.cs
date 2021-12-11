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
        if (Input.GetKeyDown(KeyCode.R))
        {
            //Destroy game objects
            if (FindObjectOfType<Player>() != null) {
                Destroy(FindObjectOfType<Player>().gameObject);
            }
            Destroy(FindObjectOfType<EnemySpawner>().gameObject);
            //Respawn game objects
            Player newPlayer = (Player)Instantiate(playerPrefab, new Vector3(1.03f, 1.04f, -4.84f), Quaternion.identity);
            newPlayer.cell = GameObject.Find("CellSpotlight").GetComponent<Cell>();
            Instantiate(enemySpawner);
        }
    }
}
