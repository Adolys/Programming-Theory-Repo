using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SelectCharacter : MonoBehaviour
{
    private void Start()
    {
        transform.DOScaleY(1.05f, 0.5f).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnDestroy()
    {
        DOTween.Kill(transform);
    }
}
