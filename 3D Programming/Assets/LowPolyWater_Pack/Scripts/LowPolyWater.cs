using UnityEngine;

namespace LowPolyWater
{
    public class LowPolyWater : MonoBehaviour
    {
        private float waveHeight = 2.0f;
        public float WaveHeight {
            get { return waveHeight; }
            set { waveHeight = value; }
        }
        private float waveFrequency = 0.5f;
        public float WaveFrequency {
            get { return waveFrequency; }
            set { waveFrequency = value; }
        }
        private float waveLength = 10f;
        public float WaveLength {
            get { return waveLength; }
            set { waveLength = value; }
        }

        public Vector3 waveOriginPosition = new Vector3(100f, 0.0f, 100f);

        MeshFilter meshFilter;
        Mesh mesh;
        Vector3[] vertices;

        MeshCollider meshCol;

        private void Awake()
        {
            //Get the Mesh Filter of the gameobject
            meshFilter = GetComponent<MeshFilter>();
            meshCol = GetComponent<MeshCollider>();
        }

        void Start()
        {
            CreateMeshLowPoly(meshFilter);
        }

        MeshFilter CreateMeshLowPoly(MeshFilter mf)
        {
            mesh = mf.sharedMesh;
            //Get the original vertices of the gameobject's mesh
            Vector3[] originalVertices = mesh.vertices;

            //Get the list of triangle indices of the gameobject's mesh
            int[] triangles = mesh.triangles;

            //Create a vector array for new vertices 
            Vector3[] vertices = new Vector3[triangles.Length];
            
            //Assign vertices to create triangles out of the mesh
            for (int i = 0; i < triangles.Length; i++)
            {
                vertices[i] = originalVertices[triangles[i]];
                triangles[i] = i;
            }

            //Update the gameobject's mesh with new vertices
            mesh.vertices = vertices;
            mesh.SetTriangles(triangles, 0);
            mesh.RecalculateBounds();
            mesh.RecalculateNormals();
            this.vertices = mesh.vertices;

            return mf;
        }
        
        void FixedUpdate()
        {
            GenerateWaves();
            //  This if i want to have the boat float on the water with rigid bodies
            //meshCol.sharedMesh = meshFilter.mesh;
        }

        void GenerateWaves()
        {
            for (int i = 0; i < vertices.Length; i++)
            {
                Vector3 v = vertices[i];

                //Initially set the wave height to 0
                v.y = 0.0f;

                //Get the distance between wave origin position and the current vertex
                float distance = Vector3.Distance(v, waveOriginPosition);
                distance = (distance % waveLength) / waveLength;

                //Oscilate the wave height via sine to create a wave effect
                v.y = waveHeight * Mathf.Sin(Time.time * Mathf.PI * 2.0f * waveFrequency
                + (Mathf.PI * 2.0f * distance));
                
                //Update the vertex
                vertices[i] = v;
            }

            //Update the mesh properties
            mesh.vertices = vertices;
            mesh.RecalculateNormals();
            mesh.MarkDynamic();
            meshFilter.mesh = mesh;
        }
    }
}