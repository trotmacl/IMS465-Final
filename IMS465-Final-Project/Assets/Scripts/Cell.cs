using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{

    [SerializeField] public bool isSpotlight;
    [SerializeField] public float enemyX;
    [SerializeField] public float enemyZ;
    [SerializeField] public float playerX;
    [SerializeField] public float playerZ;
    public bool isPlayerInside;
    public Enemy enemy;
    [SerializeField] public GameObject playerAttackIndicator;
    [SerializeField] public GameObject enemyAttackIndicator;

    // Start is called before the first frame update
    void Start()
    {
        isPlayerInside = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<Player>() != null && Mathf.Abs(FindObjectOfType<Player>().transform.position.z - playerZ) < 0.1f && Mathf.Abs(FindObjectOfType<Player>().transform.position.x - playerX) < 0.1f)
        {
            isPlayerInside = true;
        }
        else {
            isPlayerInside = false;
        }

        if (playerAttackIndicator.activeSelf) {
            StartCoroutine(DeactivatePIndicator());
        }
    }

    IEnumerator DeactivatePIndicator() {
        yield return new WaitForSeconds(0.5f);
        playerAttackIndicator.SetActive(false);
    }

    IEnumerator DeactivateEIndicator()
    {
        yield return new WaitForSeconds(0.5f);
        enemyAttackIndicator.SetActive(false);
    }

    public void ActivateEIndicator() {
        enemyAttackIndicator.SetActive(true);
        StartCoroutine(DeactivateEIndicator());
    }
}
