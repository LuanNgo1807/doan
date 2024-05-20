using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMiniMap : MonoBehaviour
{

    //    [SerializeField] GameObject _player;
    Vector3 _offset = Vector3.zero;
    void Start()
    {
        _offset = transform.position - PlayerController.instance.transform.position;

    }

    void Update()
    {
        transform.position = _offset + PlayerController.instance.transform.position;

        transform.rotation = Quaternion.Euler(90f, PlayerController.instance.transform.position.y, 0f);
    }
}
