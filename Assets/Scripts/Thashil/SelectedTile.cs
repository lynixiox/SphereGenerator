using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedTile : MonoBehaviour
{

    public Camera camera;

    public GameManager gameManager;
    public GameObject selectedObject;
    public GameObject hoverObject;
    public GameObject currentSelectedObject;
    public GameObject currentHoverObject;


    public Material selectedMaterial;
    public Material hoverMaterial;
    public Material defaultMaterial;
   
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse Press");
            if (Physics.Raycast(ray, out hit))
            {

                Debug.Log("Object Name " + hit.collider.name);
                if (hit.collider.gameObject.tag == "Tile")
                {
                    selectedObject = hit.collider.gameObject;
                    gameManager.selectedTile = selectedObject.GetComponent<TerraTile>();
                    selectedObject.GetComponent<Renderer>().material = selectedMaterial;

                    if (!currentSelectedObject)
                    {
                        currentSelectedObject = selectedObject;
                        currentSelectedObject.GetComponent<Renderer>().material = selectedMaterial;
                    }
                    else if (currentSelectedObject != selectedObject)
                    {
                        currentSelectedObject.GetComponent<Renderer>().material = currentSelectedObject.GetComponent<TerraTile>().material;
                        currentSelectedObject = selectedObject;
                    }
                }
                else if (hit.collider.gameObject.tag == "canvas")
                {
                    Debug.Log("Hitting canvas");
                }

            }
            else
            {
                if (!selectedObject)
                {
                    Debug.Log("no Selected Object");
                }
                else
                {
                    currentSelectedObject.GetComponent<Renderer>().material = currentSelectedObject.GetComponent<TerraTile>().material;

                }

            }
        }

        if (true)
        {
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.name);
                if (hit.collider.gameObject.tag == "Tile")
                {
                    hoverObject = hit.collider.gameObject;
                    if (!currentHoverObject)
                    {

                        currentHoverObject = hoverObject;


                    }
                    if (hoverObject == currentSelectedObject || hoverObject == selectedObject)
                    {
                        return;
                    }
                    else
                    {
                        if (currentHoverObject != hoverObject)
                        {
                            if (currentHoverObject == selectedObject || currentHoverObject == currentSelectedObject)
                            {
                                currentHoverObject.GetComponent<Renderer>().material = currentSelectedObject.GetComponent<Renderer>().material;
                            }
                            else
                            {

                                currentHoverObject.GetComponent<Renderer>().material = currentHoverObject.GetComponent<TerraTile>().material;
                            }
                        }
                        hoverObject.GetComponent<Renderer>().material = hoverMaterial;
                        currentHoverObject = hoverObject;

                    }


                }


            }
            else
            {
                if (!currentHoverObject)
                {
                    Debug.Log("Fuck all");
                }
                else if (currentSelectedObject)
                {
                    Debug.Log("Object selected");
                    currentHoverObject.GetComponent<Renderer>().material = currentHoverObject.GetComponent<TerraTile>().material;
                    currentSelectedObject.GetComponent<Renderer>().material = selectedMaterial;

                }
                else
                {
                    currentHoverObject.GetComponent<Renderer>().material = currentHoverObject.GetComponent<TerraTile>().material;
                }
            }
        }



    }

}
