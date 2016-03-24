using UnityEngine;
using System.Collections;
using System;

public class shallow_wave : MonoBehaviour
{
    int size;
    // previous height field of the mesh
    float[,] old_h;
    // current height field of the mesh
    float[,] h;
    // new height field of the mesh
    float[,] new_h;

    System.Random r = new System.Random ();

    // Use this for initialization
    void Start ()
    {
        size = 64;
        old_h = new float[size, size];
        h = new float[size, size];
        new_h = new float[size, size];
    
        //Resize the mesh into a size*size grid
        Mesh mesh = GetComponent<MeshFilter> ().mesh;
        mesh.Clear ();
        Vector3[] vertices = new Vector3[size * size];
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++) {
                vertices [i * size + j].x = i * 0.2f - size * 0.1f;
                vertices [i * size + j].y = 0;
                vertices [i * size + j].z = j * 0.2f - size * 0.1f;
            }
        int[] triangles = new int[(size - 1) * (size - 1) * 6];
        int index = 0;
        for (int i = 0; i < size - 1; i++)
            for (int j = 0; j < size - 1; j++) {
                triangles [index * 6 + 0] = (i + 0) * size + (j + 0);
                triangles [index * 6 + 1] = (i + 0) * size + (j + 1);
                triangles [index * 6 + 2] = (i + 1) * size + (j + 1);
                triangles [index * 6 + 3] = (i + 0) * size + (j + 0);
                triangles [index * 6 + 4] = (i + 1) * size + (j + 1);
                triangles [index * 6 + 5] = (i + 1) * size + (j + 0);
                index++;
            }
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals ();
    }

    void Shallow_Wave ()
    {	
        float rate = 0.005f;
        float damping = 0.999f;

        new_h = Heights.New_H(old_h, h, damping, rate);

        old_h = h;
        h = new_h;
    }


    // Update is called once per frame
    void Update ()
    {
        Mesh mesh = GetComponent<MeshFilter> ().mesh;
        Vector3[] vertices = mesh.vertices;

        h = Heights.From_Vertices(vertices);

        if (Input.GetKeyDown ("r")) {
            float m = UnityEngine.Random.Range (0.05F, 0.1F);
            int i = r.Next (size - 1);
            int j = r.Next (size - 1);

            h [i, j] += m;

        }

        for(int s=0; s < 8; s++)
        {
            Shallow_Wave();
        }

        Vector3[] newVertices = Heights.To_Vertex_Ys(h, vertices);


        //Step 1: Copy vertices.y into h

        //Step 2: User interaction
    
        //Step 3: Run Shallow Wave

        //Step 4: Copy h back into mesh
        

//        mesh.vertices = vertices;
        mesh.vertices = newVertices;
        mesh.RecalculateNormals ();

    }
}
