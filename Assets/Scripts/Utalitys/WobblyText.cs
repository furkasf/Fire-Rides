using TMPro;
using UnityEngine;

public class WobblyText : MonoBehaviour
{
    [SerializeField] private TMP_Text _textCompanent;

    private void Update()
    {
        _textCompanent.ForceMeshUpdate();
        var textInfo = _textCompanent.textInfo;
        for (int i = 0; i < textInfo.characterCount; ++i)
        {
            var charInfo = textInfo.characterInfo[i];

            if (!charInfo.isVisible) continue;

            var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;

            for (int j = 0; j < 4; ++j)//each char consist of 4 vertices
            {
                var originalPositions = verts[charInfo.vertexIndex + j];
                //override vertices with with modified version
                verts[charInfo.vertexIndex + j] = originalPositions + new Vector3(0, Mathf.Sin(Time.time * 2 + originalPositions.x * 0.01f) * 10f, 0);
            }
        }

        for (int i = 0; i < textInfo.meshInfo.Length; ++i)
        {
            var meshInfo = textInfo.meshInfo[i];
            meshInfo.mesh.vertices = meshInfo.vertices;
            _textCompanent.UpdateGeometry(meshInfo.mesh, i);
        }
    }
}