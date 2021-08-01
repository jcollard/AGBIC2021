using System;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBox
{
    public static readonly PuzzleBox Instance = new PuzzleBox();

    public readonly Sprite EMPTY;

    public readonly Sprite TOP_LEFT;
    public readonly Sprite TOP_RIGHT;
    public readonly Sprite BOTTOM_RIGHT;
    public readonly Sprite BOTTOM_LEFT;

    public readonly Sprite LEFT;
    public readonly Sprite TOP;
    public readonly Sprite RIGHT;
    public readonly Sprite BOTTOM;

    private PuzzleBox()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites/PuzzleBox");
        List<SpriteRenderer> renderers = new List<SpriteRenderer>();

        // THE ORDER SHOULD BE THE ORDER OF THE SPRITES
        EMPTY = sprites[0];
        TOP_LEFT = sprites[1];
        TOP_RIGHT = sprites[2];
        BOTTOM_RIGHT = sprites[3];
        BOTTOM_LEFT = sprites[4];

        LEFT = sprites[5];
        TOP = sprites[6];
        RIGHT = sprites[7];
        BOTTOM = sprites[8];
    }
}
