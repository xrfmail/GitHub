using System;
using System.Collections.Generic;
using System.Text;
using SuperDog;

// V1.0.0.0.1   DX  20180720    Create the demo for SuperDog

namespace dog_test
{
    class Program
    {
        static void Main(string[] args)
        {
            DogDemo dog = new DogDemo();
            //dog.RunDemo(DogDemo.defaultScope);

            if (dog.CheckFeatureID("42"))
            {
                Console.WriteLine("Continue to run the app....");
            }
            Console.WriteLine("end");
        }
    }
}
