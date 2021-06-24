using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using BzKovSoft.ObjectSlicer;
using BzKovSoft.ObjectSlicerSamples;
public class Sliser : MonoBehaviour
{
    [SerializeField] private GameObject _blade;
    [SerializeField] private float _duration;
    [SerializeField] private float _offset;
    [SerializeField] private float _tiameReload;
    private BzKnife _knife;
    private float _currentTime;
    private void Start()
    {
       _knife = _blade.GetComponentInChildren<BzKnife>();
    }
    private void Update()
    {
        _currentTime += Time.deltaTime;
        if(Input.GetMouseButton(0) && _currentTime >= _tiameReload)
        {
            _knife.BeginNewSlice();
            _blade.transform.DOMoveY(_blade.transform.position.y - _offset, _duration / 2f).SetLoops(2, LoopType.Yoyo);
            _currentTime = 0;
        }
    }
}
