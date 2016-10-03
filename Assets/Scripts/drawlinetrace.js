﻿ #pragma strict
 
 @script RequireComponent(LineRenderer)
 
 var lineRenderer : LineRenderer;
 var myPoints : Vector3[];
 
 var c1: Color = Color.white;
 var c2: Color = Color(1,1,1,0);
 
 function Start () {
     lineRenderer = GetComponent(LineRenderer);
     lineRenderer.SetWidth(0.5,0.5);
     lineRenderer.SetColors(c1,c2);
 }
 
 function Update () {
 
     if(myPoints){
         lineRenderer.SetVertexCount(myPoints.Length);
         lineRenderer.SetColors(c1,c2);
         for(var i = 0;i<myPoints.Length;i++){
             lineRenderer.SetPosition(i,myPoints[i]);   
         }
     }
     else
     lineRenderer.SetVertexCount(0);
     
     if(Input.touchCount > 0){
     if(Input.touches[0].phase == TouchPhase.Began)
         InvokeRepeating("AddPoint",.03,.03);
     } 
     else{
         CancelInvoke();
         myPoints = null;
     }
 }
 
 function AddPoint(){
    
     var tempPoints : Vector3[];
 
     if(!myPoints)
         tempPoints = new Vector3[1];
     else{
         tempPoints = new Vector3[myPoints.Length+1];
                
         for(var j = 0; j < myPoints.Length; j++)
             tempPoints[j] = myPoints[j];
     }
         var tempPos : Vector3 = Input.mousePosition;
     tempPos.z = 10;
     
    tempPoints[j] = Camera.main.ScreenToWorldPoint(tempPos);
    
    myPoints = new Vector3[tempPoints.Length]; 
    myPoints = tempPoints;   
 }
 