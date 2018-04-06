// Learn more about F# at http://fsharp.org

open System

let RandomFruits count = 
    let fruits = [|"apple"; "pear" ; "banana"; "orange"; "cantelope"|]
    let r = Random()
    [|
        for i in 1..count do
            let index = r.Next(5)
            yield fruits.[index]    
    |]

[<EntryPoint>]
let main argv =
    for x in argv do
        printfn "%A" (RandomFruits (x |> int))

    0 // return an integer exit code
