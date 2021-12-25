[<RequireQualifiedAccess>]
module AdventOfCode21.IO

open System.IO

let tryReadLines path =
    try
        File.ReadAllLines path |> Array.toList |> Ok
    with
    | _ -> Error "Could not read file"

let tryReadText path =
    try
        File.ReadAllText path |> Ok
    with
    | _ -> Error "Could not read file"

let tryReadCSV path = tryReadText path |> Result.map String.splitCSV
