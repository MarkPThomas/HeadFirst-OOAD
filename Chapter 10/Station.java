package chapter10;

public class Station
{
    private String name;
    
    public Station(String name) {
        this.name = name;
    }
    
    public String getName() {
        return name;
    }
    
    public boolean equals(Object obj) {
        if (obj instanceof Station) {
            Station otherStation = (Station) obj;
            if (otherStation.getName().equalsIgnoreCase(name))
            {
                return true;
            }
        }
        return false;
    }
    
    public int hashCode() {
        return name.toLowerCase().hashCode();
    }
}
