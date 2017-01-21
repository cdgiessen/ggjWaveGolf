using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshDeformer : MonoBehaviour
{
    public int rows = 1; //squares in the grid, not vertices
    public int cols = 1;

    public float width = 10; //size of grid
    public float height = 10;

    public float UpdateRange = 2; //how close the player needs to be for this mesh to update itself

    private Mesh mesh;

    private float waveAmplitude = 1;
    private float waveDissapationRate;
    
    public float angularFreq = Mathf.PI * 2 * 10;
    public float steepness = 1;
    public float MaxHeight = 2;
    public float midValue = 1f;

    public Transform player;
    private bool shouldUpdate;

    private bool ringWave = false;
    private Vector3 ringCenter;
    private float ringTimer;

    // Use this for initialization
    void Start()
    {
        //if(GetComponent<MeshFilter>().mesh == null)
            GetComponent<MeshFilter>().mesh = CreateMesh(rows, cols);
        
        mesh = GetComponent<MeshFilter>().mesh;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        UpdateMeshGeometry();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                player.position = hit.point;

                // Do something with the object that was hit by the raycast.
            }
        }*/

        if ((player.position - (transform.position + transform.parent.position)).magnitude < UpdateRange)
        {
            UpdateMeshGeometry();
        }
        
    }

    public void UpdateMeshGeometry()
    {
        Vector3[] vertsToDeform = mesh.vertices; 
        Vector3[] normalsToDeform = mesh.normals; 
        int counter = 0;
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                Vector3 vertPos = new Vector3(vertsToDeform[counter].x, 0 , vertsToDeform[counter].z) ;
                float distance = ((vertPos + transform.position + transform.parent.position) - player.position).magnitude;
                //Vector3 finalPos = new Vector3(vertPos.x, Mathf.Sin(distance - timeSinceStart*angularFreq), vertPos.z);   
                float valLogistics = MaxHeight / (1 + Mathf.Pow(2.71828f, -steepness * (distance - midValue)));
                Vector3 finalPos = new Vector3(vertPos.x, -valLogistics + MaxHeight, vertPos.z);
                vertsToDeform[counter] = finalPos;

                float xDiff = 0, zDiff = 0;
                if(i == 0) {
                    xDiff = (vertsToDeform[(cols * i + j)].y - vertsToDeform[(cols * (i + 1) + j)].y);
                } else if (i == rows - 1){
                    xDiff = (vertsToDeform[(cols * (i - 1) + j)].y - vertsToDeform[(cols * i + j)].y);
                } else {
                    xDiff = (vertsToDeform[(cols * (i - 1) + j)].y - vertsToDeform[(cols * (i + 1) + j)].y);
                }
                if (j == 0) {
                    zDiff = (vertsToDeform[(cols * i + j)].y - vertsToDeform[(cols * i + j + 1)].y);
                } else if (j == cols - 1) {
                    zDiff = (vertsToDeform[(cols * i + j - 1)].y - vertsToDeform[(cols * i + j)].y);
                } else {
                    zDiff = (vertsToDeform[(cols * i + j - 1)].y - vertsToDeform[(cols * i + j + 1)].y);
                }
                normalsToDeform[counter] = new Vector3(xDiff, 1, zDiff).normalized;
                counter++;
            }
        }
        mesh.vertices = vertsToDeform;
        mesh.normals = normalsToDeform;
    }

    public void ShouldUpdate()
    {
        shouldUpdate = true;
    }

    public void ShouldNotUpdate()
    {
        shouldUpdate = false;
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
                verts[counter] = new Vector3(i * width / (rows - 1) - width/2, 0, j * height / (cols - 1) - height/2);
                normals[counter] = Vector3.up;
                uv[counter] = new Vector2(i * width / (rows - 1), j * height / (cols - 1));
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
        mesh.name = "Ground Mesh";
        mesh.vertices = verts;
        mesh.triangles = indicies;
        mesh.normals = normals;
        mesh.uv = uv;
        return mesh;
    }
}