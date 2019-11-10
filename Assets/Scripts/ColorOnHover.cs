using UnityEngine;
using System.Linq;

public class ColorOnHover : MonoBehaviour
{
    public Color vari;
    public Renderer meshrenderer;

    Color[] alkuperaisetVarit;

    // Start is called before the first frame update
    void Start()
    {
        if (meshrenderer == null) 
            meshrenderer = GetComponent<MeshRenderer>();

        alkuperaisetVarit = meshrenderer.materials.Select(x => x.color).ToArray();
    }

    private void OnMouseEnter()
    {
        foreach(Material mat in meshrenderer.materials)
        {
            mat.color *= vari;
        }
    }

    private void OnMouseExit()
    {
        for (int i = 0; i < alkuperaisetVarit.Length; i++)
        {
            meshrenderer.materials[i].color = alkuperaisetVarit[i];
        }
    }
}
