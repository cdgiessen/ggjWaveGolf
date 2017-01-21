using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshDeformer : MonoBehaviour
{
    public int rows = 1; //squares in the grid, not vertices
    public int cols = 1;

    public float width = 10;
    public float height = 10;

    private Mesh mesh;

    public float hitRadius = 0.5f;

    public Vector3 waveOrigin = new Vector3(0.5f, 0, 0.5f);
    private float waveAmplitude = 1;
    private float waveDissapationRate;
    private float timeSinceStart = 0;
    public float angularFreq = Mathf.PI * 2 * 10;
    public float steepness = 1;
    public float MaxHeight = 2;
    public float midValue = 1f;
    Vector3[] vertsToDeform;

    private Vector3 oldWavePosition;

    // Use this for initialization
    void Start()
    {
        GetComponent<MeshFilter>().mesh = CreateMesh(rows, cols);
        mesh = GetComponent<MeshFilter>().mesh;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                waveOrigin = hit.point;

                // Do something with the object that was hit by the raycast.
            }
        }
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        waveOrigin.x += xAxis*Time.deltaTime;
        waveOrigin.z += zAxis * Time.deltaTime;

        if (oldWavePosition != waveOrigin)
        {
            vertsToDeform = mesh.vertices;
            int counter = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Vector3 vertPos = vertsToDeform[counter];
                    float distance = Mathf.Abs((vertPos - waveOrigin).magnitude);
                    //Vector3 finalPos = new Vector3(vertPos.x, Mathf.Sin(distance - timeSinceStart*angularFreq), vertPos.z);
                    Vector3 finalPos = new Vector3(vertPos.x, -MaxHeight / (1 + Mathf.Pow(2.71828f, -steepness * (distance - midValue))), vertPos.z);

                    vertsToDeform[counter] = finalPos;
                    counter++;
                }
            }
            mesh.vertices = vertsToDeform;
        }
        oldWavePosition = waveOrigin;
        timeSinceStart += Time.deltaTime;
    }

    public Mesh CreateMesh(int rows, int cols)
    {
        Vector3[] verts = new Vector3[(rows + 1 )* (cols + 1)];
        int[] indicies = new int[(rows) * (cols) * 6];
        Vector3[] normals = new Vector3[(rows + 1) * (cols + 1)];
        Vector2[] uv = new Vector2[(rows + 1) * (cols + 1)];

        int counter = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                verts[counter] = new Vector3(i * width / rows, 0, j * height / cols);
                normals[counter] = Vector3.up;
                uv[counter] = new Vector2(i / rows, j / cols);
                counter++;
            }
        }

        counter = 0;
        for (int i = 0; i < rows - 1; i++)
        {
            for (int j = 0; j < cols - 1; j++)
            {
                indicies[counter++] = cols * (i) + j;
                indicies[counter++] = cols * (i) + (j + 1);
                indicies[counter++] = cols * (i + 1) + (j);
                indicies[counter++] = cols * (i + 1) + (j);
                indicies[counter++] = cols * (i) + (j + 1);
                indicies[counter++] = cols * (i + 1) + (j + 1);
            }
        }

        Mesh mesh = new Mesh();
        mesh.vertices = verts;
        mesh.triangles = indicies;
        mesh.normals = normals;
        mesh.uv = uv;
        return mesh;
    }
}