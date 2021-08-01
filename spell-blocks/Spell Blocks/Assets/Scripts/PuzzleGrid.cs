using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGrid : MonoBehaviour
{
    public Sprite EMPTY;
    public Sprite[] BlockSprites;
    public Transform BlocksContainer;
    public Transform Background;
    public int Columns = 4;
    public int Rows = 6;
    public float alpha = 0.8f;
    private Block[,] Blocks;
    private Vector2 Offset;


    private void AddBlock(Block b, int r, int c)
    {
        if(r < 0 || r >= Rows || c < 0 || c >= Columns)
        {
            return;
        }
        GameObject blockObject = new GameObject();
        blockObject.transform.parent = BlocksContainer;
        blockObject.transform.localPosition = Offset + new Vector2(c + 1, -r - 1);
        blockObject.name = $"({r},{c})";
        SpriteRenderer renderer = blockObject.AddComponent<SpriteRenderer>();
        renderer.sprite = b.Sprite;
        
    }

    private Sprite GetBackgroundTile(int r, int c)
    {

        if (c >= 0 && c < Columns && r >= 0 && r < Rows)
        {
            return PuzzleBox.Instance.EMPTY;
        }
        else if (c == -1 && r == -1)
        {
            return PuzzleBox.Instance.TOP_LEFT;
        }
        else if (c == Columns && r == -1)
        {
            return PuzzleBox.Instance.TOP_RIGHT;
        }
        else if (c == Columns && r == Rows)
        {
            return PuzzleBox.Instance.BOTTOM_RIGHT;
        }
        else if (c == -1 && r == Rows)
        {
            return PuzzleBox.Instance.BOTTOM_LEFT;
        }
        else if (c == -1)
        {
            return PuzzleBox.Instance.LEFT;
        }
        else if (r == -1)
        {
            return PuzzleBox.Instance.TOP;
        }
        else if (c == Columns)
        {
            return PuzzleBox.Instance.RIGHT;
        }
        else if (r == Rows)
        {
            return PuzzleBox.Instance.BOTTOM;
        }
        throw new System.InvalidOperationException($"Illegal column, row combination: {c},{r}");
    }

    private void AddBackground(int r, int c)
    {
        GameObject background = new GameObject();
        background.transform.parent = Background;
        background.transform.localPosition = Offset + new Vector2(c + 1, -r - 1);
        background.name = $"({r},{c})";
        SpriteRenderer renderer = background.AddComponent<SpriteRenderer>();
        renderer.sprite = GetBackgroundTile(r, c);
        Color newColor = renderer.material.color;
        newColor.a = alpha;
        renderer.material.color = newColor;
    }

    // Start is called before the first frame update
    void Start()
    {
        //TODO: Need to resize if rows / columns change
        Offset = new Vector2(-(Columns+1) / 2f, (Rows+1) / 2f);

        foreach (Transform t in BlocksContainer)
        {
            UnityEngine.Object.Destroy(t.gameObject);
        }

        foreach(Transform t in Background)
        {
            UnityEngine.Object.Destroy(t.gameObject);
        }

        Blocks = new Block[Rows, Columns];
        for(int r = -1; r <= Rows; r++)
        {
            for (int c = -1; c <= Columns; c++)
            {
                int n = UnityEngine.Random.Range(0, BlockSprites.Length);
                Block b = new Block(BlockSprites[n]);
                AddBlock(b, r, c);
                AddBackground(r, c);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
