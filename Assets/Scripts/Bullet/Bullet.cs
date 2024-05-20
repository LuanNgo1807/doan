using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bullet : MonoBehaviour, ImoveBulletable
{
    public Vector3 _firePoint { get; set; }
    private float speed = 1f;
    public float power;
    public void Fly()
    {
        //  SoundManager.instance.OnPlayAudio(SoundType.AKFire);
        transform.position = Vector3.Lerp(transform.position, _firePoint, speed * Time.timeScale);
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.tag.ToString());
        //Debug.Log("1  Shoot player");
        if (collision.gameObject.tag.Equals("Enemy") /*|| collision.gameObject.tag.Equals("Player")*/)
        {
           // Debug.Log("2  Shoot player");
            IDamageable Damage = collision.gameObject.GetComponent<IDamageable>();
            if (Damage != null)
            {
                Damage.Damage(power);
            }
        
            ObjectPooler._instance.AddElement("Bullet", transform.gameObject);
            transform.gameObject.SetActive(false);
        }
        else if(collision.gameObject.tag.Equals("Obj"))
        {
            GameObject BulletMark = ObjectPooler._instance.SpawnFromPool("BulletMark1", transform.position,new Quaternion());
            BulletMark.transform.LookAt(PlayerController.instance.transform.position);
        }

    }

}