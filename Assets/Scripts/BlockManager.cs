using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public Transform blockPrefab;

    private void Start()
    {
        RandomizeBlockPosition();
    }

    private void RandomizeBlockPosition()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int k = -8; k < 9; k= k+2)
            {
                Transform block = Instantiate(this.blockPrefab);
                block.position = new Vector3((k*0.8f), Mathf.Round(i+1), 0.0f);
            }
        }       
    }
}
