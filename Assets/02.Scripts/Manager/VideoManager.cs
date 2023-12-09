using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    [SerializeField] VideoClip[] sources;
    [SerializeField] Episode[] _episodes;

    public Dictionary<string, VideoClip> clips { get; private set; }
    public Dictionary<string, Episode> episodes { get; private set; }

    VideoPlayer videoPlayer;
    Episode currentEpisode;

    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        videoPlayer.loopPointReached += OnEndOfClip;



        clips = new Dictionary<string, VideoClip>();
        for (int i = 0; i < sources.Length; i++)
            clips[sources[i].name] = sources[i];

        episodes = new Dictionary<string, Episode>();
        foreach (var it in _episodes)
        {
            episodes[it.clipName] = it;
            if (it.isFirstClip) currentEpisode = it;
        }


    }

    int num = 1;

    public void SwitchingClip()
    {
        double playedTime = videoPlayer.time;
        print("playedTime " + playedTime);
        num++;
        videoPlayer.clip = clips[((num % 5) + 1).ToString()];
        videoPlayer.time = playedTime;
    }
    public void ChangeClip(string clipName)
    {
        double playedTime = videoPlayer.time;
        videoPlayer.clip = clips[clipName];
        videoPlayer.time = playedTime;
    }

    void OnEndOfClip(VideoPlayer source)
    {
        Debug.Log("OnEndOfClip");
        videoPlayer.clip = clips[currentEpisode.defaultNextClip];
        videoPlayer.Play();

    }
}
