namespace OOP_Labb_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Geometry circle = new Circle();
            //Geometry square = new Square();
            //Geometry rectangle = new Rectangle();

            //circle.Area();
            //square.Area();
            //rectangle.Area();

            // Creating a list based on geometry class
            List<Geometry> shapes = new List<Geometry>
            {
                // Add to the list each child class
                new Rectangle(),
                new Square(),
                new Circle(),
                // general triangle
                new Triangle(5.5, 3.2, 7),
                // right-angled triangle
                new Triangle(5.5, 3.2, true)
            };
            // Iteriate through each shape
            // Circle, square & rectangle
            foreach (var shape in shapes)
            {
                // Based och the current shape
                // We will call the correct override method
                Console.WriteLine(shape.GetType().Name);
                Console.WriteLine($"Area: {shape.Area()}");
                Console.WriteLine($"Circumference: {shape.Circumference()}");
                Console.WriteLine("----------------------");
            }

            //---- THE MENU ----//
            bool running = true;
            while (running)
            {
                Console.WriteLine("Välj från menyn vilken form du vill ha och mata sedan in längd/er\n" +
                    "1. Rectangle\n" +
                    "2. Square\n" +
                    "3. Circle\n" +
                    "4. Rätvinklig Triangel\n" +
                    "5. Visa sorterad lista\n" +
                    "6. Exit");
                int choice;
                if(!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Felaktig inmatning, ange ett nummer mellan 1 - 5");
                    continue;
                }
                else
                {
                    double length;
                    double width;
                    switch (choice)
                    { 
                        case 1:
                            Console.Write("Välj längd: ");
                            length = double.Parse(Console.ReadLine());
                            Console.Write("Välj bredd: ");
                            width = double.Parse(Console.ReadLine());
                            shapes.Add(new Rectangle(length, width));
                            break;
                        case 2:
                            Console.Write("Välj längd: ");
                            length = double.Parse(Console.ReadLine());
                            shapes.Add(new Square(length));
                            break;
                        case 3:
                            Console.Write("Välj radie: ");
                            double radius = double.Parse(Console.ReadLine());
                            shapes.Add(new Circle(radius));
                            break;
                        case 4:
                            Console.Write("Välj höjd: ");
                            length = double.Parse(Console.ReadLine());
                            Console.Write("Välj bredd: ");
                            width = double.Parse(Console.ReadLine());
                            shapes.Add(new Triangle(length, width, true));
                            break;
                        case 5:
                            var sortedShapes = SortShapes(shapes);
                            foreach (var shape in sortedShapes)
                            {
                                Console.WriteLine(shape.GetType().Name);
                                Console.WriteLine($"Area: {shape.Area()}");
                                Console.WriteLine($"Circumference: {shape.Circumference()}");
                                Console.WriteLine("----------------------");
                            }
                            break;
                        case 6:
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Felaktigt nummer, välj mellan 1 - 5.");
                            break;
                    }
                }
            }

            Console.ReadKey();
        }
        public static List<Geometry> SortShapes(List<Geometry> shapes)
        {
            // Use list shapes with method OrderBy, sorting the list
            // Then create a new list and return it.
            return shapes.OrderBy(shape => shape.Area()).ToList();
        }
    }
}
