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
