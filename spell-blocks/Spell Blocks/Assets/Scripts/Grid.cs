using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public Sprite EMPTY;
    public Sprite[] BlockSprites;
    public Transform BlocksContainer;
    public int Columns = 6;
    public int Rows = 8;
    private Block[,] Blocks;


    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform t in BlocksContainer)
        {
            UnityEngine.Object.Destroy(t.gameObject);
        }
        Blocks = new Block[Rows, Columns];
        for(int r = 0; r < Rows; r++)
        {
            for (int c = 0; c < Columns; c++)
            {
                int n = Random.Range(0, BlockSprites.Length);
                Block b = new Block(BlockSprites[n]);
                GameObject blockObject = new GameObject();
                blockObject.transform.parent = BlocksContainer;
                blockObject.transform.localPosition = new Vector2(c, -r);
                blockObject.name = $"({r},{c})";
                SpriteRenderer renderer = blockObject.AddComponent<SpriteRenderer>();
                renderer.sprite = b.Sprite;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
