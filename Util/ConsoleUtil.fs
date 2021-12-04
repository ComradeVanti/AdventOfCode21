[<RequireQualifiedAccess>]
module AdventOfCode21.Console

let printResult =
    function
    | Ok value ->
        printf "%A" value
        0
    | Error e ->
        printf "Error: %s" e
        1
