using System;
using System.Collections;
using UnityEngine;

public class CameraSiganls
{
    public static Action<Transform> onGetTargetPos;
    public static Action onTargetDeath;
    public static Action onChangeColor;
    public static Action onResetColor;
    public static Func<IEnumerator> OnScreanShootToTexture;
}