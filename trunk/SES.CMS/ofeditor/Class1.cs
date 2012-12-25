using System;

/// <summary>
/// Summary description for Quote
/// </summary>
public class ArticleOD
{
 
    private Int32 _ArticleID;
    private String _Title;

    public ArticleOD()
    {

    }

    public ArticleOD(int _ArticleID, string _Title)
    {
        this._ArticleID = _ArticleID;
        this._Title = _Title;
    }
    //New



    public Int32 ArticleID
    {
        get { return _ArticleID; }
        set { _ArticleID = value; }
    }

   
    public String Title
    {
        get { return _Title; }
        set { _Title = value; }
    }
}