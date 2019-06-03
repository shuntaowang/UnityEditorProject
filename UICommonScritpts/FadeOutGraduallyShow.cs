using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 渐隐渐显  父节点下的所有字节点进行不断的渐隐渐显的效果显示
/// </summary>
public class FadeOutGraduallyShow : MonoBehaviour
{
    List<Transform> transforms = new List<Transform>();
    public float times; //实现次数
    public float delayTime;//延迟执行时间
    public float internalTime;//间隔时间

    // Use this for initialization
    void Start()
    {
        foreach (Transform item in transform)
        {
            transforms.Add(item);

        }
        FadeOutOrFadeOutGraduallyShow();
        InvokeRepeating("FadeOutOrFadeOutGraduallyShow", 2, (delayTime+internalTime)*2+0.15f);
    }

    // Update is called once per frame
    void Update()
    {

    }


    int excuteTimes = 0;
    void FadeOutOrFadeOutGraduallyShow()
    {
        if (excuteTimes >= times)
            CancelInvoke("FadeOutOrFadeOutGraduallyShow");
        excuteTimes++;
        foreach (Transform item in transforms)
        {
            UISprite uISprite = item.GetComponent<UISprite>();
            if (uISprite == null)
                uISprite = item.gameObject.AddComponent<UISprite>();

            TweenAlpha tweenAlpha = uISprite.GetComponent<TweenAlpha>();
            if (tweenAlpha == null)
                tweenAlpha = uISprite.gameObject.AddComponent<TweenAlpha>();
            tweenAlpha.delay = delayTime;
            tweenAlpha.duration = internalTime;
            tweenAlpha.from = 1;
            tweenAlpha.to = 0;
            tweenAlpha.PlayForward();
            tweenAlpha.AddOnFinished(() => { tweenAlpha.PlayReverse(); });
        }
    }
}
