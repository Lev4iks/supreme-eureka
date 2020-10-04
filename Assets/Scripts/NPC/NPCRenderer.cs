using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCRenderer : MonoBehaviour
{
    [SerializeField]
    Sprite[] NPCSprites;

    private SpriteRenderer _Renderer;

    // Start is called before the first frame update
    void Start()
    {
        _Renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        string index = "";
        if (_Renderer.sprite.name[_Renderer.sprite.name.Length - 2] != '_')
        {
            if (_Renderer.sprite.name[_Renderer.sprite.name.Length - 3] != '_')
                index += _Renderer.sprite.name[_Renderer.sprite.name.Length - 3];
            index += _Renderer.sprite.name[_Renderer.sprite.name.Length - 2];
        }
        index += _Renderer.sprite.name[_Renderer.sprite.name.Length - 1];

        if (NPCSprites.Length == 0)
            Debug.LogWarning("Missing Animation Sprites");

        else
        {
            if (int.TryParse(index, out int j))
            {
                if (j >= NPCSprites.Length)
                {
                    Debug.LogWarning($"Sprite with Index: {j} does not exist in Animation Sprites!");
                    _Renderer.sprite = null;
                }
                else
                {
                    _Renderer.sprite = NPCSprites[j];

                }
            }
        }
    }
}
