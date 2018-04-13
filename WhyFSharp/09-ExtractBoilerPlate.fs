(** All three of these functions have the same pattern:

    Set up the initial value
    Set up an action function that will be performed on each element inside the loop.
    Call the library function List.fold. This is a powerful, general purpose function which starts with the initial value and then runs the action function for each element in the list in turn.
**)

let product n = 
    let initialValue = 1
    let action productSoFar x = productSoFar * x
    [1..n] |> List.fold action initialValue

//test
product 10

let sumOfOdds n = 
    let initialValue = 0
    let action sumSoFar x = if x%2=0 then sumSoFar else sumSoFar+x 
    [1..n] |> List.fold action initialValue

//test
sumOfOdds 10

let alternatingSum n = 
    let initialValue = (true,0)
    let action (isNeg,sumSoFar) x = if isNeg then (false,sumSoFar-x)
                                             else (true ,sumSoFar+x)
    [1..n] |> List.fold action initialValue |> snd

//test
alternatingSum 100

// ***************************** //

type NameAndSize= {Name:string;Size:int}
 
let maxNameAndSize list = 
    
    let innerMaxNameAndSize initialValue rest = 
        let action maxSoFar x = if maxSoFar.Size < x.Size then x else maxSoFar
        rest |> List.fold action initialValue 

    // handle empty lists
    match list with
    | [] -> None
    | first::rest -> 
        let max = innerMaxNameAndSize first rest
        Some max


//test
let list = [
    {Name="Alice"; Size=10}
    {Name="Bob"; Size=1}
    {Name="Carol"; Size=12}
    {Name="David"; Size=5}
    ]    
maxNameAndSize list
maxNameAndSize []

// use the built in function
list |> List.maxBy (fun item -> item.Size)
[] |> List.maxBy (fun item -> item.Size) // Exception Thrown...

let maxNameAndSizeSafe list = 
    match list with
    | [] -> 
        None
    | _ -> 
        let max = list |> List.maxBy (fun item -> item.Size)
        Some max

maxNameAndSizeSafe list
maxNameAndSizeSafe []



(** 

    The key program logic is emphasized and made explicit. The important differences between the functions become very clear, while the commonalities are pushed to the background.
    The boilerplate loop code has been eliminated, and as a result the code is more condensed than the C# version (4-5 lines of F# code vs. at least 9 lines of C# code)
    There can never be a error in the loop logic (such as off-by-one) because that logic is not exposed to us.
**)