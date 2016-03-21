package chapter10;

import java.io.File;

public class LoadTester
{
    public static void main(String[] args) {
        try {
            SubwayLoader loader = new SubwayLoader();
            Subway objectville = loader.loadFromFile(new File("ObjectvilleSubway.txt"));
            
            System.out.println("Testing stations");
            if (    objectville.hasStation("DRY Drive") &&
                    objectville.hasStation("Weather-O-Rama, Inc.") &&
                    objectville.hasStation("Boards 'R' Us")) {
                System.out.println("... station test passed successfully.");
            }
            else
            {
                System.out.println("...station test FAILED.");
                System.exit(-1);
            }
            
            System.out.println("\nTesting connections...");
            if (objectville.hasConnection("DRY Drive", "Head First Theater", "Meyer Line") &&
                objectville.hasConnection("LSP Lane", "JavaBeans Boulevard", "Booch Line") &&
                objectville.hasConnection("OOA&D Oval", "Head First Labs", "Gamma Line")) {
                System.out.println("...connections test passed succesfully.");
            }
            else
            {
                System.out.println("...connections test FAILED");
                System.exit(-1);
            }
        } catch (Exception e) {
            e.printStackTrace(System.out);
        }
    }
}
