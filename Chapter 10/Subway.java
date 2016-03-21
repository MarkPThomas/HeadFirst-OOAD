package chapter10;

import java.util.*;

public class Subway
{
    private List stations;
    private List connections;
    private Map network;
    
    public Subway() {
        this.stations = new LinkedList();
        this.connections = new LinkedList();
        this.network = new HashMap();
    }
    
    public void addStation(String stationName) {
        if (!this.hasStation(stationName)) {
            Station station = new Station(stationName);
            stations.add(station);
        }
    }
    
    public boolean hasStation(String stationName) {
        return stations.contains(new Station(stationName));
    }
    
    public void addConnection(String station1Name, String station2Name, String lineName) {
        if ((this.hasStation(station1Name)) && (this.hasStation(station2Name))) {
            Station station1 = new Station(station1Name);
            Station station2 = new Station(station2Name);
            Connection connection = new Connection(station1, station2, lineName);
            connections.add(connection);
            connections.add(new Connection(station2, station1, connection.getLineName()));
            
            addToNetwork(station1, station2);
            addToNetwork(station2, station1);
        }
        else
        {
            throw new RuntimeException("Invalid connection: [" + station1Name + ", " + station2Name + ", " + lineName + "]");
        }
    }
    
    private void addToNetwork(Station station1, Station station2) {
        if (network.keySet().contains(station1)) {
            List connectingStations = (List) network.get(station1);
            if (!connectingStations.contains(station2)) {
                connectingStations.add(station2);
            }
        } else {
            List connectingStations = new LinkedList();
            connectingStations.add(station2);
            network.put(station1, connectingStations);
        }
    }
    
    public List getDirections(String startStationName, String endStationName) {
        if (!this.hasStation(startStationName) || !this.hasStation(endStationName))
        {
            throw new RuntimeException("Stations entered do not exist on this subway");
        }
        
        Station start = new Station(startStationName);
        Station end = new Station(endStationName);
        List route = new LinkedList();
        List reachableStations = new LinkedList();
        Map previousStations = new HashMap();
        List neighbors = (List)network.get(start);
        
        for (Iterator i = neighbors.iterator(); i.hasNext(); ) {
            Station station = (Station) i.next();
            if (station.equals(end)) {
                route.add(getConnection(start, end));
                return route;
            } else {
                reachableStations.add(station);
                previousStations.put(station, start);
            }
        }
        
        List nextStations = new LinkedList();
        nextStations.addAll(neighbors);
        Station currentStation = start;
        
        searchLoop:
        for (int i = 1; i < stations.size(); i++) {
            List tmpNextStations = new LinkedList();
            for (Iterator j = nextStations.iterator(); j.hasNext(); ) {
                Station station = (Station) j.next();
                reachableStations.add(station);
                currentStation = station;
                List currentNeighbors = (List) network.get(currentStation);
                for (Iterator k = currentNeighbors.iterator(); k.hasNext(); ) {
                    Station neighbor = (Station) k.next();
                    if (neighbor.equals(end)) {
                        reachableStations.add(neighbor);
                        previousStations.put(neighbor, currentStation);
                        break searchLoop;
                    } else if (!reachableStations.contains(neighbor)) {
                        reachableStations.add(neighbor);
                        tmpNextStations.add(neighbor);
                        previousStations.put(neighbor, currentStation);
                    }
                }
            }
            nextStations = tmpNextStations;
        }
        
        //We've found the path now!
        boolean keepLooping = true;
        Station keyStation = end;
        Station station;
        
        while (keepLooping) {
            station = (Station) previousStations.get(keyStation);
            route.add(0, getConnection(station, keyStation));
            if (start.equals(station)) {
                keepLooping = false;
            }
            keyStation = station;
        }
        
        return route;
    }
    
    private Connection getConnection(Station station1, Station station2) {
        for (Iterator i = connections.iterator(); i.hasNext(); ) {
            Connection connection = (Connection) i.next();
            Station one = connection.getStation1();
            Station two = connection.getStation2();
            if ((station1.equals(one)) && station2.equals(two)) {
                return connection;
            }
        }
        return null;
    }
        
    
    public boolean hasConnection(String station1Name, String station2Name, String lineName) {
        Station station1 = new Station(station1Name);
        Station station2 = new Station(station2Name);
        for (Iterator i = connections.iterator(); i.hasNext(); ) {
            Connection connection = (Connection) i.next();
            if (connection.getLineName().equalsIgnoreCase(lineName)) {
                if ((connection.getStation1().equals(station1)) &&
                    (connection.getStation2().equals(station2)))
                {
                    return true;
                }
            }
        }
        return false;
    }
                
}
