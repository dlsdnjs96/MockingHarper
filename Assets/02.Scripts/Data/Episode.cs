using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.WebRequestMethods;



[Serializable]
public class NextClip
{
    [Header("연결된 클립 명")]
    public string nextClip;
    [Header("클릭 생성 기간 (x : 시작 시간, y : 종료 시간)")]
    public Vector2 range;
    [Header("클릭 위치")]
    public Vector2 position;
    [Header("클릭 크기")]
    public float radius;
}



[CreateAssetMenu(fileName = "Episode", menuName= "Data/Episode")]
public class Episode : ScriptableObject
{

    public bool isFirstClip { get { return _isFirstClip; } }
    [SerializeField] bool _isFirstClip;

    public string clipName { get { return _clipName; } }
    [SerializeField] string _clipName;

    public string defaultNextClip { get { return _defaultNextClip; } }
    [SerializeField] string _defaultNextClip;


    public List<NextClip> nextClips {  get { return _nextClips; } }
    [SerializeField] List<NextClip> _nextClips;

}
