using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frag : MonoBehaviour, ImoveBulletable
{
    public Vector3 _firePoint { get; set; }
    [SerializeField] float speed = 1f;
    [SerializeField] GameObject _explosion;
    public void Fly()
    {
        transform.position = Vector3.Lerp(transform.position, _firePoint, speed * Time.timeScale);
        StartCoroutine(WaitTimeExplosion());
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    StartCoroutine(WaitTimeExplosion());
    //}

    //void OnEnable()
    //{
    
    //}

        IEnumerator WaitTimeExplosion()
    {
        yield return new WaitForSeconds(0.5f);
        _explosion.SetActive(true);
     GameManager._instance.gamePlay.CheckEnemysColistionWihtBoom(transform);
        yield return new WaitForSeconds(1f);
        ObjectPooler._instance.AddElement("Bomb2", gameObject);
        _explosion.SetActive(false);
        gameObject.SetActive(false);
    }    

 }
