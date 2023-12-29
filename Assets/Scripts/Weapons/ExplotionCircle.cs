using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplotionCircle : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;

    private Grenade grenade;

    [SerializeField] private Color color1 = Color.white;
    [SerializeField] private Color color2 = Color.black;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(Explode());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Expand(float radius) 
    {
        spriteRenderer.transform.localScale = new Vector3(radius, radius, radius);
    }

    private void ChangeColor(Color color) 
    {
        spriteRenderer.color = color;
    }

    private IEnumerator Explode() 
    {
        Expand(grenade.GetRadius() / 2);
        ChangeColor(color2);
        yield return new WaitForFixedUpdate();
        Expand(grenade.GetRadius());
        ChangeColor(color1);

        yield return new WaitForFixedUpdate();
        Destroy(gameObject);
    }
}
