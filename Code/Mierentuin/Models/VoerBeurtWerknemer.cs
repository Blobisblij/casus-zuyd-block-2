namespace casus.Mierentuin.Models;

public class VoerBeurtWerknemer
{
    private int voerbeurtID;

    public int VoerBeurtID
    {
        get { return voerbeurtID; }
        set { voerbeurtID = value; }
    }
    
    private int werknemerID;

    public int WerknemerID
    {
        get { return werknemerID; }
        set { werknemerID = value; }
    }

    public VoerBeurtWerknemer(int VoerBeurtID, int WerknemerID)
    {
        this.VoerBeurtID = VoerBeurtID;
        this.WerknemerID = WerknemerID;
    }
}