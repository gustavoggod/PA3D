using UnityEngine;
using UnityEditor;
using UnityEngine.ProBuilder;

public class GenerarMapaMarcio
{
    private static Transform root;

    [MenuItem("Marcio/Generar Mapa ProBuilder")]
    public static void GenerarMapa()
    {
        // Evitar duplicados
        GameObject anterior = GameObject.Find("MAP_MARCIO");
        if (anterior != null)
            Object.DestroyImmediate(anterior);

        GameObject mapa = new GameObject("MAP_MARCIO");
        root = mapa.transform;

        // =========================
        // INICIO
        // =========================

        CrearBloque(
            "Inicio_Suelo",
            new Vector3(0, -0.25f, 0),
            new Vector3(14, 0.5f, 10)
        );

        CrearBloque(
            "Inicio_Muro_Izquierdo",
            new Vector3(-7, 2, 0),
            new Vector3(0.5f, 4, 10)
        );

        CrearBloque(
            "Inicio_Muro_Derecho",
            new Vector3(7, 2, 0),
            new Vector3(0.5f, 4, 10)
        );

        // =========================
        // PASILLO
        // =========================

        CrearBloque(
            "Pasillo_Suelo",
            new Vector3(0, -0.25f, 11),
            new Vector3(8, 0.5f, 14)
        );

        CrearBloque(
            "Pasillo_Muro_Izquierdo",
            new Vector3(-4, 2, 11),
            new Vector3(0.5f, 4, 14)
        );

        CrearBloque(
            "Pasillo_Muro_Derecho",
            new Vector3(4, 2, 11),
            new Vector3(0.5f, 4, 14)
        );

        // =========================
        // SALA INFERIOR
        // =========================

        CrearBloque(
            "Sala_Suelo",
            new Vector3(0, -0.25f, 22),
            new Vector3(14, 0.5f, 9)
        );

        CrearBloque(
            "Sala_Muro_Izquierdo",
            new Vector3(-7, 2, 22),
            new Vector3(0.5f, 4, 9)
        );

        CrearBloque(
            "Sala_Muro_Derecho",
            new Vector3(7, 2, 22),
            new Vector3(0.5f, 4, 9)
        );

        CrearBloque(
            "Sala_Muro_Final",
            new Vector3(0, 2, 26.5f),
            new Vector3(14, 4, 0.5f)
        );

        // =========================
        // ESCALERA PROBUILDER
        // =========================

        ProBuilderMesh escalera =
            ShapeGenerator.GenerateStair(
                PivotLocation.Center,
                new Vector3(6, 4, 10),
                8,
                true
            );

        escalera.gameObject.name = "Escalera_ProBuilder";

        escalera.transform.position =
            new Vector3(0, 2, 31);

        escalera.transform.SetParent(root);

        // =========================
        // NIVEL SUPERIOR
        // =========================

        CrearBloque(
            "NivelSuperior_Suelo",
            new Vector3(0, 4, 39),
            new Vector3(14, 0.5f, 12)
        );

        CrearBloque(
            "NivelSuperior_Muro_Izquierdo",
            new Vector3(-7, 6, 39),
            new Vector3(0.5f, 4, 12)
        );

        CrearBloque(
            "NivelSuperior_Muro_Derecho",
            new Vector3(7, 6, 39),
            new Vector3(0.5f, 4, 12)
        );

        CrearBloque(
            "NivelSuperior_Muro_Final",
            new Vector3(0, 6, 45),
            new Vector3(14, 4, 0.5f)
        );

        // =========================
        // PUNTO DE INTERÉS
        // =========================

        CrearBloque(
            "PuntoInteres_Plataforma",
            new Vector3(0, 4.75f, 41),
            new Vector3(5, 0.5f, 4)
        );

        CrearBloque(
            "PuntoInteres_Pedestal",
            new Vector3(0, 6, 41),
            new Vector3(2, 2, 2)
        );

        // =========================
        // VERTICALIDAD
        // =========================

        CrearBloque(
            "Torre_Izquierda",
            new Vector3(-5, 5, 40),
            new Vector3(2, 10, 2)
        );

        CrearBloque(
            "Torre_Derecha",
            new Vector3(5, 5, 40),
            new Vector3(2, 10, 2)
        );

        Selection.activeGameObject = mapa;

        Debug.Log("MAPA PROBUILDER GENERADO CORRECTAMENTE.");
    }

    private static GameObject CrearBloque(
        string nombre,
        Vector3 posicion,
        Vector3 tamaño)
    {
        ProBuilderMesh mesh =
            ShapeGenerator.GenerateCube(
                PivotLocation.Center,
                tamaño
            );

        GameObject objeto = mesh.gameObject;

        objeto.name = nombre;
        objeto.transform.position = posicion;
        objeto.transform.SetParent(root);

        return objeto;
    }
}