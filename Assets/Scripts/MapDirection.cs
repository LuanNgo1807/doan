using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class MapDirection : MonoBehaviour
{
    private NavMeshAgent _agent;
    public LineRenderer line;
    public Vector3 target;
    private float currentTime;
    private int index = 0;
    public float scrollSpeed;
    float moveSpeed = 20;
    public bool isMove;

    private void Start()
    {
        isMove = false;
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (!isMove)
            return;
        if (Vector3.Distance(target, transform.position) <= 2)
        {
            isMove = false;
            StartCoroutine(DisableMapDirection());
            Debug.Log("stop");
            GameManager._instance.gamePlay.SetCantFindObj();
        }

        float offset = Time.time * scrollSpeed;
        line.materials[0].SetTextureOffset("_MainTex", new Vector2(-offset, 0));

        currentTime += Time.deltaTime;
        if (currentTime >= 2 * 0.2f / moveSpeed)
        {
            line.positionCount = line.positionCount + 1;
            int a = index + 1;
            line.materials[0].mainTextureScale = new Vector2(a, 1);

            line.SetPosition(index, transform.position);
            currentTime = 0;
            index++;
        }
    }

    public void SetUp(Vector3 Destination, Vector3 Target)
    {
        currentTime = 0f;
        transform.position = Destination;
        line.positionCount = 0;
        index = 0;
        target = Target;
        _agent.SetDestination(target);
        _agent.speed = moveSpeed;

        line.materials[0].mainTextureScale = new Vector2(1, 1);
        line.materials[0].SetTextureOffset("_MainTex", new Vector2(0, 0));
        isMove = true;
    }

    private Vector3 cached_pos;
    public void FindDirection(bool cached)
    {
        if (cached)
        {
            cached_pos = transform.position;
        }

        transform.position = cached_pos;

      //  Vector3 target = GameController.Instance.taskManager.GetPosNextTask();

        Vector3 destination = new Vector3(PlayerController.instance.posDesMap.position.x, 1f, PlayerController.instance.posDesMap.position.z);
        SetUp(destination, target);
    }
    IEnumerator DisableMapDirection()
    {
        yield return new WaitForSeconds(10f);
        if (!isMove)
        {
           // UiGamePlay.instance.SetActiveMapTutorialBtn(true);

            line.positionCount = 0;
        }

    }
}