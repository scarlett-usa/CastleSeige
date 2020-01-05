using System.Collections.Generic;
using UnityEngine;

public class PositionController : MonoBehaviour
{
    [SerializeField] private Material _HOVER_MATERIAL;
    [SerializeField] private Material _STANDARD_MATERIAL;
    [SerializeField] private Renderer _renderer;

    private void OnMouseEnter()
    {
        _renderer.material = _HOVER_MATERIAL;
    }
    private void OnMouseExit()
    {
        _renderer.material = _STANDARD_MATERIAL;
    }
}
