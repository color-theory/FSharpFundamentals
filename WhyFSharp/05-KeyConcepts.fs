//Function oriented rather than object oriented.
let square x = x * x

// functions as values
let squareclone = square
let result = [1..10] |> List.map squareclone

// functions taking other functions as parameters
let execFunction aFunc aParam = aFunc aParam
let result2 = execFunction square 12


// Every chunk of code is an expression with a returnable value, instead of a statement.

// Algebraic Types

//product types
//declare it
type IntAndBool = {intPart: int; boolPart: bool}

//use it
let x = {intPart=1; boolPart=false}

//sum types
//declare it
type IntOrBool = 
  | IntChoice of int
  | BoolChoice of bool

//use it
let y = IntChoice 42
let z = BoolChoice true

//Patern Matching

//if conditional
match (1 = 2) with
    | true -> printfn "true" //true branch
    | false -> printfn "false" // false branch

//select case
match 3 with
    | 1 -> printfn "1" //case 1
    | 2 -> printfn "2" //case 2
    | _ -> printfn "other" //case other


//Loops (done with recursion)
let rec i myList =  match myList with
| [] -> printfn ""     // Empty case
| first::rest -> 
    printfn "%A" first
    i rest
    
i [1;2;4;5;6]


(*
Pattern matching with union types
We mentioned above that F# supports a “union” or “choice” type. 
This is used instead of inheritance to work with different variants of an underlying type.
Pattern matching works seamlessly with these types to create a flow of control for each choice.
In the following example, we create a Shape type representing four different shapes
and then define a draw function with different behavior for each kind of shape. 
This is similar to polymorphism in an object oriented language, but based on functions.
*)

type Shape =        // define a "union" of alternative structures
    | Circle of radius:int 
    | Rectangle of height:int * width:int
    | Point of x:int * y:int 
    | Polygon of pointList:(int * int) list

let draw shape =    // define a function "draw" with a shape param
  match shape with
  | Circle radius -> 
      printfn "The circle has a radius of %d" radius
  | Rectangle (height,width) -> 
      printfn "The rectangle is %d high by %d wide" height width
  | Point (x,y) ->
      printfn "The point is at coord (%d, %d)" x y     
  | Polygon points -> 
      printfn "The polygon is made of these points %A" points
  | _ -> printfn "I don't recognize this shape"

let circle = Circle(10)
let rect = Rectangle(4,5)
let point = Point(2,3)
let polygon = Polygon( [(1,1); (2,2); (3,3)])

[circle; rect; polygon; point] |> List.iter draw
