[<RequireQualifiedAccess>]
module AdventOfCode21.Console

let printResult =
    function
    | Ok value ->
        printfn "Output: %A" value
        0
    | Error e ->
        eprintfn "Error: %s" e
        1

let passLog o =
    printfn "%A" o
    o

let passLogWith formatter o =
    printfn "%A" (formatter o)
    o
