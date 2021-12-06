[<RequireQualifiedAccess>]
module AdventOfCode21.IO

open System
open System.IO


let private splitAt (c: char) (s: string) =
    s.Split(c, StringSplitOptions.RemoveEmptyEntries)
    |> Array.toList

let private splitCSV s = s |> splitAt ','

let tryReadLines path =
    try
        File.ReadAllLines path |> Array.toList |> Ok
    with
    | _ -> Error "Could not read file"

let tryReadCSV path =
    try
        File.ReadAllText path |> splitCSV |> Ok
    with
    | _ -> Error "Could not read file"
