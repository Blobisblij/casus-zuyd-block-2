namespace casus.Mierentuin.Models;
// deze klas word vooral gebruik voor de data dus eigelijk is het alleen de constructor
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