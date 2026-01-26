namespace casus.Mierentuin.Models;

public class objectconverter
{
    public objectconverter()
    {
        Console.Write("a");
    }
    
    public static Dictionary<string, string> Diernaartabel(Dier dier)
    {
        Dictionary<string,string> DierDict = new Dictionary<string,string>();
        DierDict.Add("Dierid",dier.DierID.ToString());
        DierDict.Add("Naam",dier.Naam);
        DierDict.Add("Typedier",dier.Typedier);
        DierDict.Add("Notitie",dier.Notitie);
        return DierDict;
    }

    public static Dier DierFabriek(Dictionary<string, string> DierDict)
    {
        Dier ditDier = new Dier(int.Parse(DierDict["Dierid"]),DierDict["Naam"], DierDict["Typedier"], DierDict["Notitie"]);
        return ditDier;
    }
}