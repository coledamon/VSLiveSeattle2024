/*
--------------------------------
STRINGS
------------------------------
*/
//Task 1 
//string msg = "Please say \"help\" for assistance";//old
//string msg2 = @"Please say ""help"" for assistance";//newer (verbatim strings)
//string msg3 = """Please say "help" for assistance"""; //raw string literals newest
//Console.WriteLine(msg);


//Task 2 Create a multiline congratulattions message
//bool goodCredit = true;
//bool newVehicle = true;

//if(goodCredit)
//{
//    if(newVehicle)
//    {
//        string congrats = "Congratulations on your new vehicle! \n We hope you enjoy driving it!";
//        string congrats2 = @"
//                            Congratulations on your new vehicle!
//                            We hope you enjoy driving it!"; //Verbatim strings take into account the space to the left as well, so this doesn't look nice
//        string congrats3 = """
//                            Congratulations on your new vehicle!
//                            We hope you enjoy driving it!
//                            """;//Raw string literals base starting spacing based on left-most quotation in last quotation block
//        Console.WriteLine(congrats);
//    }
//}

//Task 3: Create a JSON file with sample data
//string vehicleJSON = """
//                    {
//                        "id": 1,
//                        "name": "AT-AT",
//                        "price": 1999.99
//                    }
//                    """;//raw strings start on the line below the first quotation block

//If for some reason you need 3 quotes IN the block, msft thought of that and you can use 4 quotes on top and bottom

//Task 4: Use a variable or expression in a string (interpolation)
//const string pageTitle = "Vehicle Detail";
//const string header = $"Header: {
//    (pageTitle == "" 
//    ? "No title" 
//    : pageTitle)}"; //can make const, just have to make all variables referenced also consts
//Can also do multiline in the interpolation
//Console.WriteLine(header);


//Task 5: use a variable or expression in a JSON string (interpolation)
//string vehicleName = "AT-AT";
//decimal price = 1999.99m;
//string vehicleJSON = $@"
//    {{
//        ""id"": 1,
//        ""name"": ""{vehicleName}"",
//        ""price"": {price}
//    }}";
//string vehicleJSONRaw = $$"""
//    {
//        "id": 1,
//        "name": "{{vehicleName}}",
//        "price": {{price}}
//    }
//    """;//In order to distinguish difference between interpolation and raw curly brackets, the number of curly braces for interpolation must match the number of dollar signs used



/*
 ------------------------------
SWITCH EXPRESSIONS/PATTERN MATCHING
------------------------------
*/
//int quantity = 5;
//string itemText = "";
//switch(quantity)
//{
//    case 0:
//        itemText = "No items";
//        break;
//    case 1:
//        itemText = "One item";
//        break;
//    default:
//        itemText = $"{quantity} items";
//        break;
//}

//itemText = quantity switch
//{
//    0 => "No items",
//    1 => "One item",
//    _ => $"{quantity} items",
//};

//itemText = quantity switch //warns if it doesn't handle all possible values
//{
//    0 => "No items",
//    1 => "One item",
//};

//itemText = quantity switch
//{
//    0 => "No items",
//    1 => "One item",
//    _ => $"{quantity} items",
//    2 => "Two items", //warns if unreachable pattern
//};

//itemText = quantity switch
//{
//    <= 0 => "No items", //supports patterns
//    1 => "One item",
//    >=2 => $"{quantity} items",
//};

//itemText = quantity switch //supports logic operators
//{
//    <= 0 => "No items",
//    1 => "One item",
//    >=2 and < 12 => $"{quantity} items",
//    < 20 and not 12 => "Not 12 items",
//    _ => "Too many items"
//};


//int CountItems()
//{
//    return 5;
//}

//itemText = CountItems() switch //supports logic operators
//{
//    <= 0 => "No items",
//    1 => "One item",
//    var q => $"{q} items" //auto captures variable returned from CountItems()
//};

//itemText = CountItems() switch //supports logic operators
//{
//    <= 0 => "No items",
//    1 => "One item",
//    var q when q >= 2 && q < 12 => $"{q} items", //guard clause (must use boolean logic, not expression)
//    < 20 and not 12 => "Not 12 items",
//    _ => "Too many items"
//};

//bool inStock = true;
//bool creditApproved = true;
//itemText = CountItems() switch //supports logic operators
//{
//    <= 0 => "No items",
//    _ when !inStock => "Out of stock",
//    1 => "One item",
//    var q when creditApproved => $"{q} items", //guard clause
//    _ => "Credit not approved for more than 1 item"
//};


//Task 7: Display different text based on the quantity with tuple pattern

//int? quantity = 5;
//bool inStock = true;
//bool creditApproved = true;
//string itemText = (quantity, inStock, creditApproved) switch
//{
//    ( <= 0 or null, _, _) => "No items",
//    (_, false, _) => "Out of stock",
//    (1, true, _) => "One item",
//    (_, true, true) => $"{quantity} items",
//    _ => ""
//};


//Task 8: Display different text based on the quantity with type pattern

//string PrepareMessage<T>(IEnumerable<T> info) //helps when dealing with generics, auto tries to cast to different types
//{
//    string message = info switch
//    {
//        null => "Value is null",
//        List<int> list => $"List has {list.Count} items",
//        List<string> list => string.Join(", ", list),
//        _ => "Value is not a list of integers or strings"
//    };
//    return message;
//}





//Task 1 : Pull items from the end of an array
//string[] cast = ["Frodo", "Bilbo", "Gandalf", "Aragorn", "Arwen", "Eowyn"];
//string lastPerson = cast[cast.Length - 1];
//string lastPersonNew = cast[^1]; //Index From End Operator 
//string secondLastPersonNew = cast[^2];
//syntax works on anything that's countable
//char a = "asdfasfd"[^3];

//Task 2 : Pull a subset of items from an array
//string[] cast = ["Frodo", "Bilbo", "Gandalf", "Aragorn", "Arwen", "Eowyn"];
//Console.WriteLine(string.Join(", ", cast));

//string[] hobbitCast = cast[1..3];//range operators [inclusive..exclusive] (returns bilbo & gandalf)
//string[] notHobbits = cast[2..^0]; //take from 2 until end
//string[] notHobbitsNoCaret = cast[2..]; //easy way to do to end

//int x = 2;
//string[] notHobbitsVar = cast[x..]; //works with variables inside of range too

//Task 3: Pass a range to a method

//void displayStats(int[] sequence, Range range)
//{
//    Console.WriteLine(sequence[range].Min());
//    Console.WriteLine(sequence[range].Max());
//    Console.WriteLine(sequence[range].Average());
//}

//displayStats([10, 20, 30, 40, 50], 2..4);
//displayStats([10, 20, 30, 40, 50], ..);//whole range

//Range only works with arrays and strings, not all IEnumerables
//Copied not referenced (which is why it doesn't work with lists)

//Index type
//string text = "This is some text!";
//Index bang = ^1;
//Console.WriteLine(text[bang]);
//Console.WriteLine(text[^text.Length]);


//Range type
//string text = "This is some text!";
//Range some = 8..12;
//Console.WriteLine(text[some]);//just some
//Console.WriteLine(text[..4]);//First word



/*
-----------------------
DATES
-----------------------
*/

//Task 1: Track a date without a time
//DateTime hireDateTime = new (2024, 7, 14); //Target-typed new expression (don't have to do new DateTime(x,y,z)
//Console.WriteLine(hireDateTime);

//DateOnly hireDate = new DateOnly(2024, 7, 14);
//Console.WriteLine(hireDate);

//DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);

//Track a time without a date

//TimeSpan alarmTimeSpan = new(7, 0, 0); //How stuff has been done in the past bc no dedicated "time" object
//Console.WriteLine(alarmTimeSpan);

//TimeOnly alarmTime = new (7, 0, 0);
//Console.WriteLine(alarmTime);

//TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);

//Determine if a store is open
//TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
//TimeOnly open = new(10, 0, 0);
//TimeOnly close = new(18, 0, 0);

//if(currentTime.IsBetween(open, close))
//{
//    Console.WriteLine("It's open!");
//}
//else
//{
//    Console.WriteLine("It's closed.");
//}

//no IsBetween for DateOnly unfortunately












