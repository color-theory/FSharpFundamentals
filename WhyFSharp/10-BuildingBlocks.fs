// building blocks
let add2 x = x + 2
let mult3 x = x * 3
let square x = x * x

// test
[1..10] |> List.map add2 |> printfn "%A"
[1..10] |> List.map mult3 |> printfn "%A"
[1..10] |> List.map square |> printfn "%A" 

//Now we want to create new functions that build on these:

// new composed functions
let add2ThenMult3 = add2 >> mult3 // add2 then mult3 same as: let add2ThenMult3 x = mult3 (add2 x)
let mult3ThenSquare = mult3 >> square 

// test
add2ThenMult3 5
mult3ThenSquare 5
[1..10] |> List.map add2ThenMult3 |> printfn "%A"
[1..10] |> List.map mult3ThenSquare |> printfn "%A"


// EXTENDING FUNCTIONS

// helper functions;
let logMsg msg x = printf "%s%i" msg x; x     //without linefeed
let logMsgN msg x = printfn "%s%i" msg x; x   //with linefeed

// new composed function with new improved logging!
let mult3ThenSquareLogged = 
   logMsg "before=" 
   >> mult3 
   >> logMsg " after mult3=" 
   >> square
   >> logMsgN " result=" 

// test
mult3ThenSquareLogged 5
[1..10] |> List.map mult3ThenSquareLogged //apply to a whole list

// ************************** //

// Composing a list of functions into a single function
let listOfFunctions = [
   mult3; 
   square;
   add2;
   logMsgN "result=";
   ]

// compose all functions in the list into a single one
let allFunctions = List.reduce (>>) listOfFunctions 

//test
allFunctions 5

// **************************** //

//domain specific language DSL
// set up the vocabulary
type DateScale = Hour | Hours | Day | Days | Week | Weeks
type DateDirection = Ago | Hence

// define a function that matches on the vocabulary
let getDate interval scale direction =
    let absHours = match scale with
                   | Hour | Hours -> 1 * interval
                   | Day | Days -> 24 * interval
                   | Week | Weeks -> 24 * 7 * interval
    let signedHours = match direction with
                      | Ago -> -1 * absHours 
                      | Hence ->  absHours 
    System.DateTime.Now.AddHours(float signedHours)

// test some examples
let example1 = getDate 5 Days Ago
let example2 = getDate 1 Hour Hence

// the C# equivalent would probably be more like this:
// getDate().Interval(5).Days().Ago()
// getDate().Interval(1).Hour().Hence()


(** How you might use c# and fluent interfaces
FluentShape.Default
   .SetColor("red")
   .SetLabel("box")
   .OnClick( s => Console.Write("clicked") );

**)