using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFx;
    [SerializeField] Transform  Parent;
    [SerializeField] int ScorePerHit = 12;

    [SerializeField] int hits =10;

    ScoreBoard scoreBoard;
    void Start()
    {
        somecollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }
    private void somecollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }


     void OnParticleCollision(GameObject other)
    {
        scoreBoard.scoreHit(ScorePerHit);
        hits = hits - 1;
        if(hits<1)
        {
            killEnemy();
        }
        
    }
    private void killEnemy()
    {
        GameObject Fx = Instantiate(deathFx, transform.position, Quaternion.identity);
        Fx.transform.parent = Parent;
        Destroy(gameObject);
    }
}
