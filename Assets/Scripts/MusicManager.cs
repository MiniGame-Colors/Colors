using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{
    /// <summary>
    /// 用于在其他脚本中调用该脚本
    /// </summary>
    #region 单例模式                              
    private static MusicManager _instance;


    public static MusicManager instance {
        get {
            return _instance;
        }
    }
    #endregion
    public float minPitch = 0.9f;              //最小音量
    public float maxPitch = 1.1f;              //最大音量

    public AudioSource efxSource;              //音效
    public AudioSource bgSource;               //背景音乐

    void Awake()
    {
        _instance = this;
    }
    /// <summary>
    /// 产生一个随机音量大小的音效
    /// </summary>
    /// <param name="clips"></param>
    public void RandomPlay(params AudioClip[] clips)
    {
        float pitch = Random.Range(minPitch, maxPitch);
        int index = Random.Range(0, clips.Length);
        AudioClip clip = clips[index];
        efxSource.clip = clip;
        efxSource.pitch = pitch;
        efxSource.Play();
    }
    /// <summary>
    /// 背景音乐停止
    /// </summary>
    public void StopBGMusic()
    {
        bgSource.Stop();
    }
    //需要新建一个空物体起名MusicManager,并将该脚本挂在上面，背景音乐挂在MusicManager上
    //音效挂在发出该声音的物体身上，使用时用MusicManager.instance.RandomPlay(chop1Audio, chop2Audio);
    //chop1Audio, chop2Audio是可随机选择的一个音效，可加入多个音效进行选择
    //MusicManager上的efxSource，bgSource不能为空，efxSource可选择与背景音乐相同不影响
}