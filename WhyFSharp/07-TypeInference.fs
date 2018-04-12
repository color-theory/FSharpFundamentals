let Where source predicate = 
    //use the standard F# implementation
    Seq.filter predicate source

let GroupBy source keySelector = 
    //use the standard F# implementation
    Seq.groupBy keySelector source



(** 
The type inference algorithm is excellent at gathering 
information from many sources to determine the types. 
In the following example, it correctly deduces that 
the list value is a list of strings.
**)
let i  = 1
let s = "hello"
let tuple  = s,i      // pack into tuple
let s2,i2  = tuple    // unpack
let list = [s2]       // type is string list

//And in this example, it correctly deduces that the 
//sumLengths function takes a list of strings and returns an int.
let sumLengths strList = 
    strList |> List.map String.length |> List.sum