namespace casus.Mierentuin.Models;

public class staticvorigmenu
{
    Interfaceprogram vorigmenu;
    public staticvorigmenu()
    {
        
    }
    public void setterug(Interfaceprogram menu)
    {
        vorigmenu = menu;
    }
    public bool terug()
    {
        vorigmenu.Startinterface();
        return true;
    }
}