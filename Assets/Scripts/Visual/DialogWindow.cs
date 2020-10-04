using UnityEngine;


public class DialogWindow : MonoBehaviour
{
    private Sprite _sprite;
    
    private void Start()
    {
        _sprite = Resources.Load<Sprite>("DialogWindow");
    }

    public void CreateWindow()
    {
        GameObject window = Instantiate(new GameObject(), gameObject.transform);
        window.AddComponent<SpriteRenderer>();
        window.GetComponent<SpriteRenderer>().sprite = _sprite;
    }

}