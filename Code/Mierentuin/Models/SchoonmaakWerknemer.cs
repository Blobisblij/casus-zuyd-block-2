namespace casus.Mierentuin.Models;

public class SchoonmaakWerknemer
{
    private int schoonmaakbeurtID;

    public int SchoonmaakBeurtID
    {
        get { return schoonmaakbeurtID; }
        set { schoonmaakbeurtID = value; }
    }
    
    private int werknemerID;

    public int WerknemerID
    {
        get { return werknemerID; }
        set { werknemerID = value; }
    }

    public SchoonmaakWerknemer(int SchoonmaakbeurtID, int WerknemerID)
    {
        this.schoonmaakbeurtID = SchoonmaakbeurtID;
        this.WerknemerID = WerknemerID;
    }
}