using UnityEngine;
using UnityEditor;

public class ArreglarMaterialesURP
{
    [MenuItem("Marcio/Arreglar materiales rosados")]
    static void Arreglar()
    {
        Shader shader = Shader.Find("Universal Render Pipeline/Lit");

        if (shader == null)
        {
            Debug.LogError("No se encontró el shader Universal Render Pipeline/Lit.");
            return;
        }

        Material material = new Material(shader);
        material.name = "Material_Mapa_URP";
        material.SetColor("_BaseColor", new Color(0.55f, 0.55f, 0.55f, 1f));

        int contador = 0;

        GameObject mapa = GameObject.Find("MAP_MARCIO");

        if (mapa != null)
        {
            MeshRenderer[] renderers = mapa.GetComponentsInChildren<MeshRenderer>(true);

            foreach (MeshRenderer renderer in renderers)
            {
                renderer.sharedMaterial = material;
                contador++;
            }
        }

        GameObject cube = GameObject.Find("Cube");
        if (cube != null)
        {
            MeshRenderer renderer = cube.GetComponent<MeshRenderer>();
            if (renderer != null)
            {
                renderer.sharedMaterial = material;
                contador++;
            }
        }

        GameObject cube1 = GameObject.Find("Cube (1)");
        if (cube1 != null)
        {
            MeshRenderer renderer = cube1.GetComponent<MeshRenderer>();
            if (renderer != null)
            {
                renderer.sharedMaterial = material;
                contador++;
            }
        }

        Debug.Log("Materiales corregidos: " + contador);
    }
}