using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private Cell[] outerCells;
    [SerializeField] private Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        int gapIndex1 = Random.Range(0, 4);
        int gapIndex2;
        if (Random.Range(0, 1) == 0)
        {
            gapIndex2 = (gapIndex1 + 1) % 4;
        }
        else {
            gapIndex2 = (gapIndex1 + 2) % 4;
        }

        for (int i = 0; i < 5; i++) {
            if (i != gapIndex1 && i != gapIndex2) {
                SpawnEnemy(i);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnEnemy(int index) {
        Cell cell = outerCells[index];
        Enemy newEnemy = (Enemy)Instantiate(enemy, new Vector3(cell.enemyX, 0.73f, cell.enemyZ), Quaternion.identity);
        cell.enemy = newEnemy;
        newEnemy.cell = cell;
    }

}
