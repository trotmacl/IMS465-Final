using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float hp;
    public Cell cell;
    [SerializeField] public GameObject blip;
    public Cell target;

    // Start is called before the first frame update
    void Start()
    {
        hp = 3.0f;
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {
        if (cell.isSpotlight)
        {
            hp -= 1.5f;
        }
        else {
            hp -= 1.0f;
        }

        if (hp < 0.1f) {
            Destroy(this.gameObject);
        }
    }

    IEnumerator Attack() {
        yield return new WaitForSeconds(Random.Range(2, 9));
        target = GameObject.Find("Player").GetComponent<Player>().cell;
        blip.SetActive(true);
        target.enemyAttackIndicator.SetActive(true);
        StartCoroutine(BlipOff());
        StartCoroutine(LandAttack());
    }
    
    IEnumerator BlipOn() {
        yield return new WaitForSeconds(0.16f);
        if (target != null) {
            blip.SetActive(true);
            target.enemyAttackIndicator.SetActive(true);
            StartCoroutine(BlipOff());
        }
    }

    IEnumerator BlipOff() {
        yield return new WaitForSeconds(0.16f);
        if (target != null)
        {
            blip.SetActive(false);
            target.enemyAttackIndicator.SetActive(false);
            StartCoroutine(BlipOn());
        }
    }

    IEnumerator LandAttack() {
        yield return new WaitForSeconds(0.64f);
        target.ActivateEIndicator();
        if (target.isPlayerInside) {
            GameObject.Find("Player").GetComponent<Player>().TakeDamage();
        }
        target = null;
        StartCoroutine(Attack());
    }
    
}
