[<RequireQualifiedAccess>]
module AdventOfCode21.IO

open System.IO

let tryReadLines path =
    try
        File.ReadAllLines path |> Array.toList |> Ok
    with
    | _ -> Error "Could not read file"

let tryReadCSV path =
    try
        File.ReadAllText path |> String.splitCSV |> Ok
    with
    | _ -> Error "Could not read file"
