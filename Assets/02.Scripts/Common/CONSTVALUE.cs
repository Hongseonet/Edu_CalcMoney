using System;

public class CONSTVALUE : MonoSingleton<CONSTVALUE>
{
    public bool ISDEV; //is dev mode ?
    public bool ISEDITORON; //is editor on ?
    public float SCALEFACTOR; //canvas scale factor
    public float SCALING; //object scale
    public string MOUSEMODE; //mouse mode : panning, rotating, zooming
    public bool ISONCANVAS; //is hover on canvas ?
    public bool ISINTERACTINGCANVAS;

    public bool CAMERALOCK; //current page index
    public bool ISTRANSLUCENT; //is translucent mode on?
}