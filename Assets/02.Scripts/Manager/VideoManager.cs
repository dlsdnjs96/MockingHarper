using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    [SerializeField] VideoClip[] sources;

    public Dictionary<string, VideoClip> clips { get; private set; }

    VideoPlayer videoPlayer;


    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        clips = new Dictionary<string, VideoClip>();
        for (int i = 0; i < sources.Length; i++)
        {
            print("sources[i].name " + sources[i].name);
            clips[sources[i].name] = sources[i];
        }
    }

    int num = 1;

    public void SwitchingClip()
    {
        double playedTime = videoPlayer.time;
        print("playedTime " + playedTime);
        num++;
        videoPlayer.clip = clips[((num%5) + 1).ToString()];
        videoPlayer.time = playedTime;
    }
    public void ChangeClip(string clipName)
    {
        double playedTime = videoPlayer.time;
        videoPlayer.clip = clips[clipName];
        videoPlayer.time = playedTime;
    }
}
