using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using Random = UnityEngine.Random; // DoTween 네임스페이스 필요

[System.Serializable]
public class Move
{
    public float x;
    public float y;
    public float waitTime = 0f;
    public string beforeComment = String.Empty;
    public string afterComment = String.Empty;

    public Move(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public Vector2 ToVector2()
    {
        return new Vector2(x, y);
    }
}

public class Character : MonoBehaviour
{
    public List<Move> path = new List<Move>();
    public float moveSpeed = 2f;
    public Vector2 waitTimeRange = new Vector2(1f, 3f);
    public GameObject bubble;
    public TextMeshProUGUI text;

    private Vector3 startLocalPosition;

    void Start()
    {
        startLocalPosition = transform.localPosition;
        path.Insert(0, new Move(startLocalPosition.x, startLocalPosition.y));
        StartCoroutine(MoveLoop());
    }

    IEnumerator MoveLoop()
    {
        while (true)
        {
            // 1. 경로 이동
            foreach (var move in path)
            {
                yield return MoveToTween(move.ToVector2());
                yield return new WaitForSeconds(move.waitTime);
                if (move.beforeComment != String.Empty)
                {
                    StartCoroutine(PopBubble(move.beforeComment));
                }
            }

            // 2. 랜덤 대기
            yield return new WaitForSeconds(Random.Range(waitTimeRange.x, waitTimeRange.y));
            
            // 3. 원위치 복귀
            for (int i = path.Count - 1; i >= 0; i--)
            {
                yield return MoveToTween(path[i].ToVector2());
                yield return new WaitForSeconds(path[i].waitTime);
                if (path[i].afterComment != String.Empty)
                {
                    StartCoroutine(PopBubble(path[i].afterComment));
                }
            }

            // 4. 랜덤 대기
            yield return new WaitForSeconds(Random.Range(waitTimeRange.x, waitTimeRange.y));
        }
    }

    IEnumerator MoveToTween(Vector3 localTarget)
    {
        float distance = Vector3.Distance(transform.localPosition, localTarget);
        float duration = distance / moveSpeed;

        Tween moveTween = transform.DOLocalMove(localTarget, duration).SetEase(Ease.Linear);
        yield return moveTween.WaitForCompletion();

        transform.localPosition = localTarget; // 보정
    }
    
    IEnumerator PopBubble(string comment)
    {
        bubble.SetActive(true);
        text.text = comment;
        
        yield return new WaitForSeconds(2f);
        bubble.SetActive(false);
    }
}