using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileComponent : MonoBehaviour
{
    [HideInInspector] public SquadManager squadManager;
    [HideInInspector] public enum ColorState { none, highlight };

    [Header("Tile")]
    [SerializeField] public Transform[] tilePositions;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private float defaultOpacity = 0.25f;
    [SerializeField] private float hoverOpacity = 0.75f;
    [SerializeField] private Color defaultColor = new Color(1f, 1f, 1f, 0.25f);
    [SerializeField] public Color highlightColor = new Color(1f, 1f, 0f, 0.25f);

    private void Start()
    {
        SetColor(ColorState.none);
    }

    private void OnMouseOver()
    {
        if (Input.GetButtonDown("Order Squad") && squadManager.selectedSquad)
        {
            squadManager.selectedSquad.SetTargetTile(this);
        }
    }

    private void OnMouseEnter()
    {
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, hoverOpacity);
    }

    private void OnMouseExit()
    {
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, defaultOpacity);
    }

    public void SetColor(ColorState newColor)
    {
        switch (newColor)
        {
            case ColorState.none:
                sprite.color = defaultColor;
                break;
            case ColorState.highlight:
                sprite.color = highlightColor;
                break;
            default: break;
        }
    }
}
