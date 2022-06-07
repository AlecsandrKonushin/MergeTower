using Core;
using UnityEngine;

namespace SystemTouch
{
    public class TouchSystem : MonoBehaviour
    {
        private bool isCanDrag = true;
        private bool dragNow = false;
        private Camera mainCamera;
        private GameObject selectedObject;

        private Vector3 mScreenDownPosition;
        private Vector3 mWorldDownPosition;
        private Vector3 mCameraDownPosition;

        public Camera SetCamera { set => mainCamera = value; }      

        //private void FixedUpdate()
        //{
        //    if (dragNow)
        //    {
        //        if (selectedObjectTransform != null)
        //        {

        //            Vector3 inputPosition = new Vector3(Input.GetAxis("Mouse X") * speed * Time.deltaTime, Input.GetAxis("Mouse Y") * speed * Time.deltaTime, selectedObjectTransform.position.z);
        //            //Vector3 newPosition = mainCamera.ScreenToWorldPoint(inputPosition);
        //            //newPosition.z = selectedObjectTransform.transform.position.z;
        //            Debug.Log($"mouse pos = {inputPosition}");

        //            selectedObjectTransform.Translate(inputPosition * speed);
        //        }
        //    }
        //}

        private Vector3 GetPlaneInteractivePoint(Vector3 screenPosition, float plane = 0)
        {
            var ray = mainCamera.ScreenPointToRay(screenPosition);
            Vector3 dir = ray.direction;
            if (dir.y.Equals(0)) return Vector3.zero;
            float num = (plane - ray.origin.y) / dir.y;
            return ray.origin + ray.direction * num;
        }

        private void Update()
        {
            if (isCanDrag)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    RaycastHit hit;
                    Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.transform.tag == NamesData.TagTower)
                        {
                            dragNow = true;
                            selectedObject = hit.transform.gameObject;
                        }

                        mScreenDownPosition = Input.mousePosition;
                        mWorldDownPosition = hit.collider.gameObject.transform.position;
                        mCameraDownPosition = Camera.main.transform.position;
                    }
                }

                if (Input.GetMouseButtonUp(0))
                {
                    dragNow = false;
                    selectedObject = null;
                }

                if (selectedObject)
                {
                    var down = GetPlaneInteractivePoint(mScreenDownPosition,
                        selectedObject.transform.position.y);
                    var move = GetPlaneInteractivePoint(Input.mousePosition,
                        selectedObject.transform.position.y);
                    var offset = move - down;
                    selectedObject.transform.position = mWorldDownPosition + offset;
                }
            }

            //if (Input.GetMouseButtonDown(0) && !mSelectedBuilding && !mSelectedMap)
            //{
            //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //    RaycastHit hit;
            //    if (Physics.Raycast(ray, out hit))
            //    {
            //        string tag = hit.collider.gameObject.tag;
            //        switch (tag)
            //        {
            //            case TagDefine.BUILDING:
            //                mSelectedBuilding = hit.collider.gameObject;
            //                break;
            //            case TagDefine.MAP:
            //                mSelectedMap = hit.collider.gameObject;
            //                break;
            //        }

            //        mScreenDownPosition = Input.mousePosition;
            //        mWorldDownPosition = hit.collider.gameObject.transform.position;
            //        mCameraDownPosition = Camera.main.transform.position;
            //    }
            //}
            //else if (Input.GetMouseButtonUp(0))
            //{
            //    mSelectedBuilding = null;
            //    mSelectedMap = null;
            //}
        }
    }
}