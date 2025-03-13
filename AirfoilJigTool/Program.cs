using System;
using AirfoilJigTool;

class Program
{
    static void Main(string[] args)
    {

    Console.WriteLine("Welcome to the Airfoil Jig Generator!");
    string airfoil = @"
                                                                      
        ******************************                                
    *****                             ************                    
 ***                                             **********           
 *                                                         ********   
*                                                                 ****
 *                                                         ********   
 ***                                             **********           
    *****                             ************                    
        ******************************                                
        ";

    
        Console.WriteLine(airfoil);

        var validator = new ParameterValidator();
            var parameters = validator.ValidateAndParse(args);

            Console.WriteLine($"Chord Length: {parameters["--chordlength"]}");
            Console.WriteLine($"Thickness: {parameters["--thickness"]}");
    }
}
