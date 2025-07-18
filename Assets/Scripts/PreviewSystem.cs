using System;
using UnityEngine;

[Serializable]
public class PreviewSystem
{
    [SerializeField] private float _previewYOffset = 0.06f;
    [SerializeField] private float _indicatorYOffset = 0.015f;
    [SerializeField] private GameObject _cellIndicator;
    [SerializeField] private Material _previewMaterialsPrefab;

    private GameObject _previewObject;
    private Material _previewMaterialInstance;

    private Renderer _cellIndicatorRenderer;

    public void Initialize()
    {
        _previewMaterialInstance = new Material(_previewMaterialsPrefab);
        _cellIndicator.SetActive(false);
        _cellIndicatorRenderer = _cellIndicator.GetComponent<Renderer>();
    }

    public void StartShowingPlacementPreview(GameObject prefab, Vector2Int size)
    {
        _previewObject = GameObject.Instantiate(prefab);

        PreparePreview(_previewObject);
        PrepareCursor(size);
        _cellIndicator.SetActive(true);
    }

    public void StopShowingPreview()
    {
        _cellIndicator.SetActive(false);
        GameObject.Destroy(_previewObject);
    }

    public void UpdatePosition(Vector3 position, bool validity)
    {
        MovePreview(position);
        MoveCursor(position);
        AppllyFeedBack(validity);
    }

    public void UpdateRotation()
    {
        var rotationAngle = 90.0f;

        _previewObject.transform.Rotate(0f, rotationAngle, 0f);
        _cellIndicator.transform.Rotate(0f, 0f, rotationAngle);
    }

    private void AppllyFeedBack(bool validity)
    {
        Color c = validity ? Color.white : Color.red;
        _cellIndicatorRenderer.material.color = c;
        c.a = 0.5f;
        _previewMaterialInstance.color = c;
    }

    private void MoveCursor(Vector3 position)
    {
        _cellIndicator.transform.position = new Vector3(position.x, position.y + _indicatorYOffset, position.z);
    }

    private void MovePreview(Vector3 position)
    {
        _previewObject.transform.position = new Vector3(position.x, position.y + _previewYOffset, position.z);
    }

    private void PreparePreview(GameObject previewObject)
    {
        Renderer[] renderers = previewObject.GetComponentsInChildren<Renderer>();
        
        foreach (Renderer renderer in renderers)
        {
            Material[] materials = renderer.materials;

            for (int i = 0; i < materials.Length; i++)
            {
                materials[i] = _previewMaterialInstance;
            }

            renderer.materials = materials;
        }
    }

    private void PrepareCursor(Vector2Int size)
    {
        if (size.x > 0 || size.y > 0)
        {
            _cellIndicator.transform.localScale = new Vector3(size.x, size.y, 1);
            _cellIndicatorRenderer.material.mainTextureScale = size;
        }
    }
}
