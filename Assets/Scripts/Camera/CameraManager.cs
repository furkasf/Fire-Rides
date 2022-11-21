using Assets.Scripts;
using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Volume volume;
    [SerializeField] private Material screenShootMaterial;
    [SerializeField] private GameObject ScrenShotMesh;
    [SerializeField] private float zOffset;

    private ColorAdjustments _colorAdjustments;
    private VolumeParameter<float> _hueShift = new VolumeParameter<float>();
    private Transform _target;
    private bool _targetIsFound;
    private bool _isShaken;

    private void Start()
    {
        volume.profile.TryGet<ColorAdjustments>(out _colorAdjustments);
    }

    private void OnEnable()
    {
        CameraSiganls.onGetTargetPos += OnGetTargetPos;
        CameraSiganls.onTargetDeath += OnTargetDeath;
        CameraSiganls.onChangeColor += OnChangeColor;
        CameraSiganls.onResetColor += OnResetColor;
        CameraSiganls.OnScreanShootToTexture += OnScreanShootToTexture;
    }

    private void OnDisable()
    {
        CameraSiganls.onGetTargetPos -= OnGetTargetPos;
        CameraSiganls.onTargetDeath -= OnTargetDeath;
        CameraSiganls.onChangeColor -= OnChangeColor;
        CameraSiganls.onResetColor -= OnResetColor;
        CameraSiganls.OnScreanShootToTexture -= OnScreanShootToTexture;
    }

    private void LateUpdate()
    {
        if (!_targetIsFound && !_isShaken) return;
        transform.position = new Vector3(transform.position.x, transform.position.y, _target.position.z + zOffset);
    }

    private IEnumerator OnScreanShootToTexture()
    {
        yield return new WaitForEndOfFrame();

        int width = Screen.width;
        int height = Screen.height;

        Texture2D texture = new Texture2D(width, height, TextureFormat.ARGB32, false);
        Rect rect = new Rect(0, 0, width, height);
        texture.ReadPixels(rect, 0, 0);
        texture.Apply();

        screenShootMaterial.SetTexture(Shader.PropertyToID("_BaseMap"), texture);
        ScrenShotMesh.SetActive(true); //or call with siganl or blend to camera Class
        UISignals.onDisActivateUI();
    }

    private void OnGetTargetPos(Transform target)
    {
        _target = target;
        _targetIsFound = true;
    }

    private void OnTargetDeath()
    {
        UISignals.onDisActivateUI();
        _isShaken = true;
        _target = null; 
        StartCoroutine(OnScreanShootToTexture());
        transform.DOShakePosition(3).OnComplete(() =>
        {
            _isShaken = false;
        });
        _targetIsFound = false;
    }

    private void OnResetColor()
    {
        _hueShift.value = 0;
        _colorAdjustments.hueShift.SetValue(_hueShift);
    }

    private void OnChangeColor()
    {
        _hueShift.value += -10f;
        _colorAdjustments.hueShift.SetValue(_hueShift);
    }
}