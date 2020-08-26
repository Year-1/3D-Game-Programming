using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class PlaneMaker : MonoBehaviour
{
    //  Brackeys proc gen tutorials helped here.
    //  Used as water prefab would override the plane prefab. This was used to make the plane flat again.
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    public int width, height;

    void Awake()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();
    }

    //  Cretae a plane with size determined by inspector.
    void CreateShape()
    {
        vertices = new Vector3[(width + 1) * (height + 1)];

        int i = 0;
        for (int y = 0; y <= height; y++) {
            for (int x = 0; x <= width; x++) {
                vertices[i] = new Vector3(x, 0, y);
                i++;
            }
        }

        triangles = new int[width * height * 6];
        int vert = 0;
        int tris = 0;
        for (int yy = 0; yy < height; yy++) {
            for (int xx = 0; xx < width; xx++) {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + width + 1;
                triangles[tris + 2] = vert + 1;

                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + width + 1;
                triangles[tris + 5] = vert + width + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }
    }

    //  Updates the mesh to the created shape(plane).
    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
}
